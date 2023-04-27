using CRUD_empresas.DTO_s;
using CRUD_empresas.Models.Entites;

namespace CRUD_empresas.Repositorys.Interfaces
{
    public interface IEmpresaService
    {
        Task<bool> CreateEmpresa(EmpresaDTO empresa);

        Task<bool> DeleteEmpresa(int id);


        Task<bool> UpdateEmpresa(EmpresaDTO empresa, int id);

        Task<IEnumerable<Empresa>> GetEmpresas();

        Task<Empresa> GetEmpresaById(int id);
    }
}
