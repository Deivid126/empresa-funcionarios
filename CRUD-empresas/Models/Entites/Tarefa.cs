using CRUD_empresas.Enums;
using CRUD_empresas.Models;

namespace CRUD_empresas.Models.Entites
{
    public class Tarefa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Description { get; set; }


        public Status Status { get; set; }

        public ICollection<Funcionarios> Funcionarios { get; set; } = new List<Funcionarios>();
    }
}
