using AutoMapper;
using CRUD_empresas.DTO_s;
using CRUD_empresas.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_empresas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {

        private readonly IDepartamentoService _service;

        public DepartamentoController(IDepartamentoService service)
        {
           _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        { 
        
        var departamentos = await _service.GetDepartamentos();


            return Ok(departamentos);
        
        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {

            var departamento = await _service.GetDepartamentoById(id);

            return Ok(departamento);  
        
        
        }

        [HttpPost]
        public async Task<IActionResult> Create(DepartamentoDTO departamento) 
        {


            var result =  await _service.CreateDepartamento(departamento);

            if (!result)  return BadRequest("Departamento não pode ser criado");

            return Ok("Departamento criado");


        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteDepartamento(id);

            
            if (!result) BadRequest("Verifcar o Id do Departamento");
           

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarDepartamento(int id, DepartamentoDTO departamento) 
        {
        
            var result = await _service.UpdateDepartamento(departamento, id);

            if (!result) return BadRequest("Verificar o Id");

            return Ok("Departamento Atualizado com Sucesso");

        
        }
    }
}
