using AutoMapper;
using CRUD_empresas.DTO_s;
using CRUD_empresas.Models.Entites;
using CRUD_empresas.Repositorys.Interfaces;

namespace CRUD_empresas.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly IMapper _mapper;
        private readonly ITarefaRepository _repository;

        public TarefaService(IMapper mapper, ITarefaRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<bool> CreateTarefa(TarefaDTO tarefa)
        {
           var tarefaadd = _mapper.Map<Tarefa>(tarefa);

            _repository.Add(tarefaadd);

            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteTarefa(int id)
        {
            var tarefa = await _repository.GetTarefaById(id);

            if(tarefa != null) 
            {
            
                _repository.Delete(tarefa);

                return await _repository.SaveChangesAsync();
           
            }

            return false;
        }

        public async Task<Tarefa> GetTarefaById(int id)
        {
            var tarefa = await _repository.GetTarefaById(id);

            return tarefa;
        }

        public async Task<IEnumerable<Tarefa>> GetTarefas()
        {
           var tarefas = await _repository.GetAllTarefas();

           return tarefas;
        }

        public async Task<bool> UpdateTarefa(TarefaDTO tarefa, int id)
        {
            var tarefabanco = await _repository.GetTarefaById(id);

            var tarefaatualizar = _mapper.Map(tarefa, tarefabanco);

            _repository.Update(tarefaatualizar);

            return await _repository.SaveChangesAsync();
        }
    }
}
