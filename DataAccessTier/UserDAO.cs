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
    public class UserDAO: DBConnection
    {
        public bool checkUser(User user)
        {
            bool result = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("USER_ISEXIST", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mUsername", user.MUsername);
                cmd.Parameters.AddWithValue("@mPassword", user.MPassword);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (int.Parse(dt.Rows[0][0].ToString()) == 1)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public List<User> getListUser()
        {
            List<User> result = new List<User>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("USER_LIST", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                result = dt.AsEnumerable().Select(m =>
                   new User
                   {
                       MUsername = m.Field<String>("mUsername"),
                       MPassword = m.Field<String>("mPassword"),
                       MPermission = m.Field<String>("mPermission")
                   }).ToList();
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
