using CRUD_empresas.Database;
using CRUD_empresas.Interfaces;
using CRUD_empresas.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace CRUD_empresas.Repositorys
{
    public class DepartamentoRepository : BaseRepository,IDepartamentoRepository
    {
        public readonly ContextDB _contextdb;
        public DepartamentoRepository(ContextDB context) : base(context)
        {
            _contextdb = context;
        }

        public async Task<IEnumerable<Departamento>> GetAllDepartamentos()
        {
            return await _contextdb.Departamentos.Include(x => x.Funcionarios).ToListAsync();
        }

        public async Task<Departamento> GetDepartamentoById(int Id)
        {
            var departamento = await _contextdb.Departamentos
                .Include(x => x.Funcionarios)
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();
     
           if (departamento == null)
             {
                throw new Exception("Departamento não encontrado");
             }

           return departamento;
            
        }
    }
}
