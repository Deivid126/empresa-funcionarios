using CRUD_empresas.DTO_s;
using CRUD_empresas.Models.Entites;

namespace CRUD_empresas.Repositorys.Interfaces
{
    public interface IFuncionarioService
    {
        Task<bool> CreateFuncionario(FuncionarioDTO funcionario);

        Task<bool> DeleteFuncionarioo(int id);

        Task<bool> AcicionarTarefaFuncionario(int tarefaid, int funcionarioid);

        Task<bool> UpdateFuncionario(FuncionarioDTO funcionario, int id);

        Task<IEnumerable<Funcionarios>> GetFuncionarios();

        Task<Funcionarios> GetFuncionarioById(int id);
    }
}
