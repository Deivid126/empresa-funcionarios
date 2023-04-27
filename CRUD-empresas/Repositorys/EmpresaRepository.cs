using CRUD_empresas.Database;
using CRUD_empresas.Models.Entites;
using CRUD_empresas.Repositorys.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD_empresas.Repositorys
{
    public class EmpresaRepository : BaseRepository, IEmpresaRepository
    {
        public readonly ContextDB _contextdb;
        public EmpresaRepository(ContextDB context) : base(context)
        {
            _contextdb = context;
        }

        public async Task<IEnumerable<Empresa>> GetAllEmpresas()
        {
            return await _contextdb.Empresas.
                Include(x=>x.Funcionarios).ToListAsync();
        }

        public async Task<Empresa> GetEmpresaById(int Id)
        {

            var empresas = await _contextdb.Empresas
                .Include(x => x.Funcionarios)
                .Where(x => x.Id == Id)
                .FirstOrDefaultAsync();

            if (empresas == null)
            {
                throw new Exception("Empresa não encontrada");
            }

            return empresas;
        }

        public async Task<bool> GetEmpresaCNPJ(string cnpj)
        {
            var empresa = await _contextdb.Empresas.Where(x => x.CNPJ == cnpj).FirstOrDefaultAsync();

            if (empresa != null) return true;

            return false;

        }
    }
}
