namespace LuckyAPi.Models
{
    public class Departamento
    {
        public int departamento_id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        
    }
}
