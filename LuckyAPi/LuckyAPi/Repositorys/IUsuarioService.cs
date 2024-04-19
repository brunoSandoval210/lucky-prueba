using LuckyAPi.Models;

namespace LuckyAPi.Repositorys
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> ObtenerUsuarios();
        Usuario ObtenerUsuarioPorId(int id);
        void InsertarUsuario(Usuario usuario);
        void ActualizarUsuario(Usuario usuario);
        void EliminarUsuario(int id);
    }
}
