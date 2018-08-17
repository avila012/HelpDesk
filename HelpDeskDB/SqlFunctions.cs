using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace HelpDeskDB
{
    public class SqlFunctions
    {
        private SqlConnection Conex { get; set; }

        public SqlFunctions()
        {
            Conex = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
        }

        /// <summary>
        /// Metodo para ejecutar todas las operaciones Insert, Delete y Update
        /// </summary>
        /// <param name="query">Query a ejecutar</param>
        public async Task<bool> ExecSQL(string query)
        {
            using (var con = Conex)
            {
                await con.OpenAsync();
                using (var cmd = Conex.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    return await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                }
            }
        }

        /// <summary>
        /// Metodo para ejecutar todas las operaciones Insert, Delete y Update
        /// </summary>
        /// <param name="query">Query a ejecutar</param>
        public async Task<bool> ExecProcedure(string query, SqlParameter[] Params)
        {
            using (var con = Conex)
            {
                await con.OpenAsync();
                using (var cmd = Conex.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(Params);
                    return await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                }
            }
        }

        /// <summary>
        /// Metodo para la extraccion de datos
        /// </summary>
        /// <param name="query">Query a ejecutar</param>
        /// <returns>Retorna un DataTable con los datos</returns>
        public async Task<DataTable> LoadData(string query)
        {
            DataTable dt = new DataTable();

            using (var con = Conex)
            {
                await con.OpenAsync();
                using (var cmd = Conex.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    var result = await cmd.ExecuteReaderAsync();

                    if (result.HasRows)
                    {
                        dt.Load(result);
                    }
                }

                return dt;
            }
        }
    }
}
