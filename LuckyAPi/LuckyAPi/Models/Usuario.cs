namespace LuckyAPi.Models
{
    public class Usuario
    {
        public int usuario_id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Dni { get; set; }
        public double? Sueldo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int departamento_id { get; set; }
        public virtual Departamento Departamento { get; set; }

    }
}
