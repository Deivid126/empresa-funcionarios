using CRUD_empresas.DTO_s;
using CRUD_empresas.Models.Entites;

namespace CRUD_empresas.Repositorys.Interfaces
{
    public interface IDepartamentoService
    {
        Task<bool> CreateDepartamento(DepartamentoDTO departamento);

        Task<bool> DeleteDepartamento(int id);

        Task<bool> UpdateDepartamento(DepartamentoDTO departamento, int id);

        Task<IEnumerable<Departamento>> GetDepartamentos();

        Task<Departamento> GetDepartamentoById(int id);

    }
}
