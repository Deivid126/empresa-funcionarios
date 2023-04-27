namespace CRUD_empresas.Models.Entites
{
    public class Empresa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Segmento { get; set; }

        public ICollection<Funcionarios> Funcionarios { get; set; } = new List<Funcionarios>();
    }
}
