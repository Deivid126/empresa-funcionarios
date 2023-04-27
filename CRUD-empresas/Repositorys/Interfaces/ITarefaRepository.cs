using CRUD_empresas.Interfaces;
using CRUD_empresas.Models.Entites;
using System.Collections.Generic;

namespace CRUD_empresas.Repositorys.Interfaces
{
    public interface ITarefaRepository : IBaseRepository
    {
        Task<IEnumerable<Tarefa>> GetAllTarefas();
        Task<Tarefa> GetTarefaById(int Id);
    }
}
