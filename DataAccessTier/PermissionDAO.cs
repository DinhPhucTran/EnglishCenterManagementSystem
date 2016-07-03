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

        public List<Permission> getListPermission()
        {
            List<Permission> result = new List<Permission>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("PERMISSION_LIST", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                result = dt.AsEnumerable().Select(m => new Permission
                {
                    MIdPermission = m.Field<String>("mIdPermission"),
                    MNamePermision = m.Field<String>("mNamePermission")
                }).ToList();
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public Permission selectPermissionById(String id)
        {
            Permission result = new Permission();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("PERMISSION_SELECT", connection);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                result.MIdPermission = id;
                result.MNamePermision = dt.Rows[0]["mNamePermission"].ToString();
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
