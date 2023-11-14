namespace SGPI.Models
{
    public class PagoUsuario
    {
        public int IdPago { get; set; }
        public string? Nombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public int? NumDoc { get; set; }
        public string? Programa { get; set; }
        public double? ValorPago { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
