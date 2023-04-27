using CRUD_empresas.Database;
using CRUD_empresas.Models.Entites;
using CRUD_empresas.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD_empresas.Repositorys
{
    public class TarefaRepository : BaseRepository,ITarefaRepository
    {
        public readonly ContextDB _contextDB;

        public TarefaRepository(ContextDB contextDB) : base(contextDB)
        {
            _contextDB = contextDB;
        }

        public async Task<IEnumerable<Tarefa>> GetAllTarefas()
        {
            return await _contextDB.Tarefas.
                Include(x=> x.Funcionarios).ToListAsync();
        }

        public async Task<Tarefa> GetTarefaById(int Id)
        {
            var tarefa = await _contextDB.Tarefas
                .Include(x => x.Funcionarios)
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();

            if (tarefa == null)
            {
                throw new Exception("Tarefa não encontrado");
            }

            return tarefa;
        }
    }
}
