namespace LuckyAPi.DTOS
{
    public class UsuarioCreateDTO
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Dni { get; set; }
        public double? Sueldo { get; set; }
        public int departamento_id { get; set; }
    }
}
