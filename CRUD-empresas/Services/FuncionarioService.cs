using AutoMapper;
using CRUD_empresas.DTO_s;
using CRUD_empresas.Models.Entites;
using CRUD_empresas.Repositorys.Interfaces;

namespace CRUD_empresas.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;
        private readonly IMapper _mapper;

        public FuncionarioService(IFuncionarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AcicionarTarefaFuncionario(int tarefaid, int funcionarioid)
        {
            var tarefa = await _repository.GetFuncionarioTarefa(funcionarioid, tarefaid);

            if (tarefa != null) return false;

            var tarefas = new FuncionarioTarefa
            {

                FuncionarioId = funcionarioid,
                TarefaId = tarefaid,

            };

            _repository.Add(tarefas);

            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> CreateFuncionario(FuncionarioDTO funcionario)
        {
            var tarefa = _mapper.Map<Funcionarios>(funcionario);

            _repository.Add(tarefa);

            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteFuncionarioo(int id)
        {
           var tarefa = await _repository.GetFuncionarioById(id);

            if(tarefa != null) 
            {
                _repository.Delete(tarefa);

                return await _repository.SaveChangesAsync();
            
            }

            return false;
        }

        public async Task<Funcionarios> GetFuncionarioById(int id)
        {
            var tarefa = await _repository.GetFuncionarioById(id);

            return tarefa;
        }

        public async Task<IEnumerable<Funcionarios>> GetFuncionarios()
        {
            var tarefas = await _repository.GetAllFuncionarios();

            return tarefas;
        }

        public async Task<bool> UpdateFuncionario(FuncionarioDTO funcionario, int id)
        {
            var funcionariobanco = await _repository.GetFuncionarioById(id);

            if(funcionariobanco != null) 
            
            {
                var funcionarioatualizar = _mapper.Map(funcionario, funcionariobanco);

                _repository.Update(funcionarioatualizar);

                return await _repository.SaveChangesAsync();
            }

            return false;
        }
    }
}
