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
    public class PermissionDAO: DBConnection
    {
        public bool insertPermission(Permission p)
        {
            bool result = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("", connection);
                cmd.Parameters.AddWithValue("@mIdPermission", p.MIdPermission);
                cmd.Parameters.AddWithValue("@NamePermission", p.MNamePermision);
                cmd.ExecuteNonQuery();
                result = true;
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public bool deletePermission(String idPer)
        {
            bool result = false;
            return result;
        }
    }
}
