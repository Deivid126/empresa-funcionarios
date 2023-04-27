using AutoMapper;
using CRUD_empresas.DTO_s;
using CRUD_empresas.Models.Entites;
using CRUD_empresas.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_empresas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {

        private readonly IEmpresaService _service;

        public EmpresaController(IEmpresaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
        
            var empresas = await _service.GetEmpresas();

            return Ok(empresas);
        
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        { 
        
            var empresa = await _service.GetEmpresaById(id);

            return Ok(empresa);
            
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmpresaDTO empresa) 
        {

            var result = await _service.CreateEmpresa(empresa);

            if(!result) return BadRequest("CNPJ já em uso");

            return Ok("Empresa Criada com Sucesso");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {

            var result = await _service.DeleteEmpresa(id);

            if (!result) return BadRequest("Verificar o Id");

            return Ok("Empresa apagada");
        
        
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEmpresa(int id, EmpresaDTO empresa) 
        {

            var result = await _service.UpdateEmpresa(empresa, id);

            if (!result) return BadRequest("Verificar o Id da empresa");

            return Ok("Empresa Atualizada");
        
        }
    }
}
