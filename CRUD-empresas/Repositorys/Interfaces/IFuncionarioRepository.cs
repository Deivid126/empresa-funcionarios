using CRUD_empresas.Interfaces;
using CRUD_empresas.Models.Entites;

namespace CRUD_empresas.Repositorys.Interfaces
{
    public interface IFuncionarioRepository : IBaseRepository
    {
        Task<IEnumerable<Funcionarios>> GetAllFuncionarios();
        Task<Funcionarios> GetFuncionarioById(int Id);

        Task<FuncionarioTarefa> GetFuncionarioTarefa(int funcionarioId, int tarefaId);
    }
}
