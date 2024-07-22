namespace dvp_server.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public required string Nombres {  get; set; }
        public required string Apellidos { get; set; }
        public required string Tipo_documento { get; set; }
        public double Numero_documento { get; set; }
        public required string Email {  get; set; }
        public DateTime Fecha_creacion { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
