using CRUD_empresas.DTO_s;
using CRUD_empresas.Models.Entites;

namespace CRUD_empresas.Repositorys.Interfaces
{
    public interface ITarefaService
    {
        Task<bool> CreateTarefa(TarefaDTO tarefa);

        Task<bool> DeleteTarefa(int id);

        Task<bool> UpdateTarefa(TarefaDTO tarefa, int id);

        Task<IEnumerable<Tarefa>> GetTarefas();

        Task<Tarefa> GetTarefaById(int id);
    }
}
