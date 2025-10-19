using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PROYECTO._03data
{
    static class BaseDatos
    {
        // Propiedades públicas
        public static string Error { get; set; }
        public static int NumRegModif { get; set; }

        // Método que establece la conexión con la base de datos
        private static MySqlConnection Conectar()
        {
            var conexionCadena = "datasource=127.0.0.1; port=3306; username=root; password=; database=academia;";
            return new MySqlConnection(conexionCadena);
        }

        // Consulta SELECT que devuelve un DataTable
        public static DataTable Consulta(string sql)
        {
            using (var conexionBD = Conectar())
            {
                var adapter = new MySqlDataAdapter(sql, conexionBD);
                try
                {
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    NumRegModif = 0;
                    Error = string.Empty;
                    return dataSet.Tables[0];
                }
                catch (Exception e)
                {
                    Error = e.Message;
                    NumRegModif = -1;
                    return null;
                }
            }
        }

        // Consulta de acción (INSERT, UPDATE, DELETE) que devuelve el número de registros modificados
        public static int Modificacion(string sql)
        {
            using (var conexionBD = Conectar())
            {
                try
                {
                    var comando = new MySqlCommand(sql, conexionBD);
                    conexionBD.Open();
                    NumRegModif = comando.ExecuteNonQuery();
                    Error = string.Empty;
                    return NumRegModif;
                }
                catch (MySqlException ex)
                {
                    Error = ex.Message;
                    NumRegModif = -1;
                    return NumRegModif;
                }
            }
        }
    }
}

