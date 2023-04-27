using AutoMapper;
using CRUD_empresas.DTO_s;
using CRUD_empresas.Models.Entites;
using CRUD_empresas.Repositorys.Interfaces;

namespace CRUD_empresas.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _repository;
        private readonly IMapper _mapper;

        public EmpresaService(IEmpresaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateEmpresa(EmpresaDTO empresa)
        {
            var result = await _repository.GetEmpresaCNPJ(empresa.CNPJ);

            if(!result)             
            {

                var empresaadd = _mapper.Map<Empresa>(empresa);

                _repository.Add(empresaadd);

                return await _repository.SaveChangesAsync();    
            }

            return false;
        }

        public async Task<bool> DeleteEmpresa(int id)
        {
            var empresa = await _repository.GetEmpresaById(id);

            if(empresa != null) 
            { 
            
                _repository.Delete(empresa);

                return await _repository.SaveChangesAsync();
            
            }

            return false;
        }

        public async Task<Empresa> GetEmpresaById(int id)
        {
            var empresa = await _repository.GetEmpresaById(id);

            return empresa;
        }

        public async Task<IEnumerable<Empresa>> GetEmpresas()
        {
            var empresas = await _repository.GetAllEmpresas();

            return empresas;
        }

        public async Task<bool> UpdateEmpresa(EmpresaDTO empresa, int id)
        {
            var empresabanco = await _repository.GetEmpresaById(id);

            if(empresabanco != null) 
            {

                var empresaatualizar = _mapper.Map(empresa, empresabanco);

                _repository.Update(empresaatualizar);

                return await _repository.SaveChangesAsync();
            
            }

            return false;
        }
    }
}
