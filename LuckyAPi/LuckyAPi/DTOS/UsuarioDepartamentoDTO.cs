namespace LuckyAPi.DTOS
{
    public class UsuarioDepartamentoDTO
    {
        public int usuario_id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Dni { get; set; }
        public double? Sueldo { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
