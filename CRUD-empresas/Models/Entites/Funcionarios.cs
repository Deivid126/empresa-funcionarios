using CRUD_empresas.Models;

namespace CRUD_empresas.Models.Entites
{
    public class Funcionarios
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int EmpresaId { get; set; }

        public Empresa Empresa { get; set; }

        public int DepartamentoId { get; set; }

        public Departamento Departamento { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
}
