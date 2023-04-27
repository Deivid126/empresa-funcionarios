using CRUD_empresas.Interfaces;
using CRUD_empresas.Models.Entites;

namespace CRUD_empresas.Repositorys.Interfaces
{
    public interface IEmpresaRepository : IBaseRepository
    {
        Task<IEnumerable<Empresa>> GetAllEmpresas();
        Task<Empresa> GetEmpresaById(int Id);

        Task<bool> GetEmpresaCNPJ(string cnpj);
    }
}
