namespace GlobalSolution.DTO
{
    public class LembreteDTO
    {
        public int Id { get; set; }
        public string Mensagem { get; set; } = null!;
        public DateTime DataHora { get; set; }
        public long UsuarioId { get; set; }
    }
}