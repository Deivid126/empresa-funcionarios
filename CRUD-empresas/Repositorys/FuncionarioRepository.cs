using CRUD_empresas.Database;
using CRUD_empresas.DTO_s;
using CRUD_empresas.Interfaces;
using CRUD_empresas.Models.Entites;
using CRUD_empresas.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD_empresas.Repositorys
{
    public class FuncionarioRepository : BaseRepository, IFuncionarioRepository
    {
        public readonly ContextDB _contextDB;

        public FuncionarioRepository(ContextDB contextDB):base(contextDB) 
        {
            _contextDB = contextDB;
        }

        public async Task<IEnumerable<Funcionarios>> GetAllFuncionarios()
        {
            return await _contextDB.Funcionarios.
                Include(x=> x.Tarefas).
                Include(x => x.Departamento).
                Include(x => x.Empresa).
                ToListAsync();
                        
        }

        public async Task<Funcionarios> GetFuncionarioById(int Id)
        {
            var funcionario = await _contextDB.Funcionarios
                .Include(x => x.Departamento)
                .Include(x => x.Empresa)
                .Include(x => x.Tarefas)
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();

            if(funcionario == null)
            {
                throw new Exception("Funcionário não encontrado");
            }

            return funcionario;

        }

        public async Task<FuncionarioTarefa> GetFuncionarioTarefa(int funcionarioId, int tarefaId)
        {
            return await _contextDB.FuncionarioTarefas
                .Where(x=> x.TarefaId == tarefaId && x.FuncionarioId ==  funcionarioId)
                .FirstOrDefaultAsync();
        }
    }
}
