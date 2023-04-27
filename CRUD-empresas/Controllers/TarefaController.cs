using AutoMapper;
using CRUD_empresas.DTO_s;
using CRUD_empresas.Models.Entites;
using CRUD_empresas.Repositorys;
using CRUD_empresas.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_empresas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
       private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TarefaDTO tarefaDTO) 
        {

                var result = await _tarefaService.CreateTarefa(tarefaDTO);

                if(!result) return BadRequest("Não foi possível salvar");

                return Ok("Tarefa Salva");

            
        
        }
        [HttpGet]
        public async Task<IActionResult> Get() 
        {

            var tarefas = await _tarefaService.GetTarefas();

            return Ok(tarefas);
        
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        {
        
            var tarefa = await _tarefaService.GetTarefaById(id);

            return Ok(tarefa);
        
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tarefaService.DeleteTarefa(id);

            if (!result) return BadRequest("Error, verificar o Id informado");

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, TarefaDTO tarefa)
        {
            var result = await _tarefaService.UpdateTarefa(tarefa, id);

            if (!result) return BadRequest("Verificar o Id");

            return Ok("Tarefa Atualizada com Sucesso");
        }

    }
}
