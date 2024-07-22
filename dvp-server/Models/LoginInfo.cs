namespace dvp_server.Models
{
    public class LoginInfo
    {
        public string Tipo_documento { get; set; }
        public double Numero_documento { get; set; }
        public string? Password { get; set; }
    }
}
