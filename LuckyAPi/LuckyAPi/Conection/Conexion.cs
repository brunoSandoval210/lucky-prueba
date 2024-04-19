using System.Data.SqlClient;

namespace LuckyAPi.Conection
{
    public class Conexion
    {
        private readonly string _connectionString;
        public Conexion(string valor)
        {
            _connectionString = valor;
        }
        public SqlConnection obtenerConexion()
        {
            var conexion = new SqlConnection(_connectionString);
            conexion.Open();
            return conexion;
        }
    }
}
