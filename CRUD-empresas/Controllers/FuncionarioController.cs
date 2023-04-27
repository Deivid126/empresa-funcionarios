using AutoMapper;
using CRUD_empresas.DTO_s;
using CRUD_empresas.Models.DTO_s;
using CRUD_empresas.Models.Entites;
using CRUD_empresas.Repositorys.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CRUD_empresas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
       private readonly IFuncionarioService _service;

        public FuncionarioController(IFuncionarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        { 
        
            var funcionarios = await _service.GetFuncionarios();

            return Ok(funcionarios);
        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) 
        { 
        
            var funcionario = await _service.GetFuncionarioById(id);

            return Ok(funcionario);
        
        
        }

        [HttpPost("criar-funcionario")]
        public async Task<IActionResult> Create(FuncionarioDTO funcionario)
        {

           var result = await _service.CreateFuncionario(funcionario);

           if(!result) return BadRequest("Verifique os parametros");

           return Ok("Funcionario Criado");


        }

        [HttpPost("atribuir-tarefa")]
        public async Task<IActionResult> AdicionarTarefasFuncionario(TarefasFuncionaioDTO tarefasFuncionario) 
        {

            int tarefaId =tarefasFuncionario.TarefaId;
            int funcionarioId = tarefasFuncionario.FuncionarioId;

            if (tarefaId <= 0 || funcionarioId <= 0) return BadRequest("Dados inválidos");

            var result = await _service.AcicionarTarefaFuncionario(tarefaId, funcionarioId);

            if (!result) return BadRequest("Error,Tarefa Já atribuida");

            return Ok("Tarefa Atribuida com Sucesso");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteFuncionarioo(id);

            if (!result) return BadRequest("Verificar o Id");

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarFuncionario(int id, FuncionarioDTO funcionario) 
        {


            var result = await _service.UpdateFuncionario(funcionario, id);

            if (!result) return BadRequest("Verificar os parametros ou o Id");

            return Ok("Funcionario Atualizado com Sucesso");
        
        }
    }
}
