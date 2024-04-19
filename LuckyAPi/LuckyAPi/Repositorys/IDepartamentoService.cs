using LuckyAPi.Models;

namespace LuckyAPi.Repositorys
{
    public interface IDepartamentoService
    {
        IEnumerable<Departamento> ObtenerDepartamentos();
        IEnumerable<Usuario>ObtenerUsuariosDepartamento(int id);
        void InsertarDepartamento(Departamento departamento);
        void EliminarDepartamento(int id);
        public Departamento ObtenerDepartamentoPorId(int id);
    }
}
