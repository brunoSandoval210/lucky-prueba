using Dapper;
using LuckyAPi.Conection;
using LuckyAPi.Models;
using System.Data;
using System.Data.SqlClient;

namespace LuckyAPi.Repositorys
{
    public class UsuarioServiceImpl : IUsuarioService
    {
        private readonly Conexion _conexion;
        public UsuarioServiceImpl(Conexion conexion)
        {
            _conexion = conexion;
        }
        public void ActualizarUsuario(Usuario usuario)
        {
            using (var conexion = _conexion.obtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@usuario_id", usuario.usuario_id, DbType.Int32);
                parametros.Add("@nombre", usuario.Nombre, DbType.String);
                parametros.Add("@apellido", usuario.Apellido, DbType.String);
                parametros.Add("@dni", usuario.Dni, DbType.String);
                parametros.Add("@sueldo", usuario.Sueldo, DbType.Double);
                parametros.Add("@departamento_id ", usuario.departamento_id, DbType.Int32);
                conexion.Execute("actualizarUsuario", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public void EliminarUsuario(int id)
        {
            using (var conexion = _conexion.obtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@usuario_id", id, DbType.Int32);
                conexion.Execute("eliminarUsuario", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public void InsertarUsuario(Usuario usuario)
        {
            using (var conexion = _conexion.obtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@nombre", usuario.Nombre, DbType.String);
                parametros.Add("@apellido", usuario.Apellido, DbType.String);
                parametros.Add("@dni", usuario.Dni, DbType.String);
                parametros.Add("@sueldo", usuario.Sueldo, DbType.Double);
                parametros.Add("@departamento_id ", usuario.departamento_id, DbType.Int32);
                try
                {
                    conexion.Execute("insertarUsuario", parametros, commandType: CommandType.StoredProcedure);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al insertar usuario: " + ex.Message);
                    throw;
                }
                //conexion.Execute("insertarUsuario", parametros, commandType: CommandType.StoredProcedure);
            }
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            using (var conexion = _conexion.obtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@usuario_id", id, DbType.Int32);
                return conexion.QueryFirstOrDefault<Usuario>("obtenerUsuarioPorId", parametros, commandType: CommandType.StoredProcedure);
            }

        }

        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            using (var conexion = _conexion.obtenerConexion())
            {
                return conexion.Query<Usuario>("obtenerUsuarios", commandType: CommandType.StoredProcedure);
            }
        }
    }
}
