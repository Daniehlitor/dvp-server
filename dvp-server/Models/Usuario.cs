namespace dvp_server.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Password {  get; set; }
        public DateTime Fecha_creacion { get; set; }
    }
}
