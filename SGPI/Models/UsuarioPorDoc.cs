namespace SGPI.Models
{
    public class UsuarioPorDoc
    {
        public int IdUsuario { get; set; }
        public  string? Nombre { get; set; }
        public  string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public  string? Email { get; set; }
        public  string? TipoDocumento { get; set; }
        public  int Documento { get; set; }
        public  bool? Activo { get; set; }
        public  string? Genero { get; set; }
        public  string? Rol { get; set; }
        public  string? Programa { get; set; }
    }
}
