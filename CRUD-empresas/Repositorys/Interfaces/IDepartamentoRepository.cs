using CRUD_empresas.DTO_s;
using CRUD_empresas.Models.Entites;

namespace CRUD_empresas.Interfaces
{
    public interface IDepartamentoRepository : IBaseRepository
    {

        Task<IEnumerable<Departamento>> GetAllDepartamentos();
        Task<Departamento> GetDepartamentoById(int Id);
    
    }
}
