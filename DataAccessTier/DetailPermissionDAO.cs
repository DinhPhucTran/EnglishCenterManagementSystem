using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DataAccessTier
{
    public class DetailPermissionDAO: DBConnection
    {
        public List<String> getListTabByPermission(String permission)
        {
            List<String> result = new List<string>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("DETAIL_PERMISSION_GET_TAB", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mIdPermission", permission);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                result = dt.AsEnumerable().Select(m => m.Field<String>("mIdTab")).ToList();
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        } 
    }
}
