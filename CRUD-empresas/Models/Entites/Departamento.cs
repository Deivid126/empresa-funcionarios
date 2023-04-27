namespace CRUD_empresas.Models.Entites
{
    public class Departamento
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public ICollection<Funcionarios> Funcionarios { get; set; } = new List<Funcionarios>();
    }
}
