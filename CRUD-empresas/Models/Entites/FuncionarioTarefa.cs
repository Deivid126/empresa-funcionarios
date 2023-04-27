namespace CRUD_empresas.Models.Entites
{
    public class FuncionarioTarefa
    {
        public int FuncionarioId { get; set; }
        public Funcionarios Funcionarios { get; set; }

        public int TarefaId { get; set; }

        public Tarefa Tarefa { get; set;}
    }
}
