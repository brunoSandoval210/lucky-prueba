using Dapper;
using LuckyAPi.Conection;
using LuckyAPi.Models;
using System.Data.SqlClient;
using System.Data;

namespace LuckyAPi.Repositorys
{
    public class DepartamentoServiceImpl : IDepartamentoService
    {
        private readonly Conexion _conexion;
        public DepartamentoServiceImpl(Conexion conexion)
        {
            _conexion = conexion;
        }

        public void EliminarDepartamento(int id)
        {
            using (var conexion = _conexion.obtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@departamento_id ", id, DbType.Int32);
                try
                {
                    conexion.Execute("eliminarDepartamento", parametros, commandType: CommandType.StoredProcedure);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al eliminar el departamento: " + ex.Message);
                    throw;
                }
            }
        }

        public void InsertarDepartamento(Departamento departamento)
        {
            using (var conexion = _conexion.obtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@nombre", departamento.Nombre, DbType.String);
              
                try
                {
                    conexion.Execute("insertarDepartamento", parametros, commandType: CommandType.StoredProcedure);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al insertar un departamento: " + ex.Message);
                    throw;
                }
            }
        }
        public Departamento ObtenerDepartamentoPorId(int id)
        {
            using (var conexion = _conexion.obtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@departamento_id ", id, DbType.Int32);
                return conexion.QueryFirstOrDefault<Departamento>("obtenerDepartamentoPorId", parametros, commandType: CommandType.StoredProcedure);
            }

        }
        public IEnumerable<Departamento> ObtenerDepartamentos()
        {
            using (var conexion = _conexion.obtenerConexion())
            {
                return conexion.Query<Departamento>("obtenerDepartamentos", commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Usuario> ObtenerUsuariosDepartamento(int id) 
        {
            using (var conexion = _conexion.obtenerConexion())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@departamento_id ", id, DbType.Int32);
                return conexion.Query<Usuario>("obtenerUsuariosDepartamento",parametros, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
