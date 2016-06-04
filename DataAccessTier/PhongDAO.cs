using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public class PhongDAO : DBConnection
    {
        public PhongDAO() { }

        public List<Phong> getListPhong()
        {
            List<Phong> result = new List<Phong>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("PHONG_LIST", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Phong td = new Phong(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                    result.Add(td);
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            return result;
        }

        public bool themPhong(Phong p)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("PHONG_INSERT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaPhong", p.MMaPhong);
                cmd.Parameters.AddWithValue("@TenPhong", p.MTenPhong);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
            return true;
        }

        public bool xoaPhong(String maPhong)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("PHONG_DELETE", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
            return true;
        }

        public bool suaPhong(Phong phong)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("PHONG_UPDATE", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaPhong", phong.MMaPhong);
                cmd.Parameters.AddWithValue("@TenPhong", phong.MTenPhong);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
            return true;
        }
    
    }
       
}
