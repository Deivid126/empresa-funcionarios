using AutoMapper;
using CRUD_empresas.Database;
using CRUD_empresas.DTO_s;
using CRUD_empresas.Interfaces;
using CRUD_empresas.Models.Entites;
using CRUD_empresas.Repositorys.Interfaces;

namespace CRUD_empresas.Services
{
    public class DepartamentoService : IDepartamentoService
    {
 
        private readonly IDepartamentoRepository _repository;
        private readonly IMapper _mapper;

        public DepartamentoService( IDepartamentoRepository repository, IMapper mapper)
        {
            
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateDepartamento(DepartamentoDTO departamento)
        {
            var departamentoadd = _mapper.Map<Departamento>(departamento);

            _repository.Add(departamentoadd);

            return await _repository.SaveChangesAsync();
               
        }

        public async Task<bool> DeleteDepartamento(int id)
        {
            var departamento = await _repository.GetDepartamentoById(id);

            if(departamento != null) 
            {

                _repository.Delete(departamento);

                return await _repository.SaveChangesAsync();
            
            }

            return false;
        }

        public async Task<Departamento> GetDepartamentoById(int id)
        {
            
            var departamento = await _repository.GetDepartamentoById(id);

        
            return departamento;
            
        
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentos()
        {
            var departamentos = await _repository.GetAllDepartamentos();

            return departamentos;
        }

        public async Task<bool> UpdateDepartamento(DepartamentoDTO departamento, int id)
        {
            var departamentobanco = await _repository.GetDepartamentoById(id);

            if (departamentobanco != null) 
            {


                var departamentoadd = _mapper.Map(departamento,departamentobanco);

                _repository.Update(departamentoadd);

                return await _repository.SaveChangesAsync();
            
            }


            return false;


        }
    }
}
