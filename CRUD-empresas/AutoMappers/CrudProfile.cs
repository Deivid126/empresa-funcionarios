using AutoMapper;
using CRUD_empresas.Database;
using CRUD_empresas.DTO_s;
using CRUD_empresas.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace CRUD_empresas.Mappers
{
    public class CrudProfile : Profile
    {

      

        public CrudProfile() 
        {


            CreateMap<TarefaDTO, Tarefa>();
            CreateMap<EmpresaDTO, Empresa>();
            CreateMap<DepartamentoDTO, Departamento>();
            CreateMap<FuncionarioDTO, Funcionarios>();
        }

        
    }
}
