﻿using System;
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
    }
}