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
        public bool isConnectionOpen()
        {
            bool result;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    result = true;
                }
                else
                {
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public bool addUser(User user)
        {
            bool result = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("USER_INSERT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mUsername", user.MUsername);
                cmd.Parameters.AddWithValue("@mPassword", user.MPassword);
                cmd.Parameters.AddWithValue("@mPermission", user.MPermission);
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

        public bool isExist(String username)
        {
            bool result = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("USER_CHECK_USERNAME", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mUserName", username);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
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

        public User selectUserByUsername(String name)
        {
            User user = new User();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("USER_SELECT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", name);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                user.MUsername = dt.Rows[0]["mUsername"].ToString();
                user.MPassword = dt.Rows[0]["mPassword"].ToString();
                user.MPermission = dt.Rows[0]["mPermission"].ToString();
                connection.Close();
            } catch(Exception){
                connection.Close();
            }
            return user;
        }

        public Permission selectPermissonById(String Id)
        {
            Permission per = new Permission();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("PERMISSION_SELECT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Id);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                per.MIdPermission = dt.Rows[0]["mIdPermission"].ToString();
                per.MNamePermision = dt.Rows[0]["mNamePermission"].ToString();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            return per;
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

        public String getPermissionByUser(User user)
        {
            String result = "";
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("USER_GET_PERMISSION", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mUsername", user.MUsername);
                cmd.Parameters.AddWithValue("@mPassword", user.MPassword);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                result = dt.Rows[0][0].ToString();
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public bool updatePassword(String username, String pass)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("USER_UPDATE_PASSWORD", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }
    }
}
