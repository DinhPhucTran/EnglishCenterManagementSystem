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
    public class ThoiGianHocDAO : DBConnection
    {
        public ThoiGianHocDAO()
        {

        }
        public bool themThoiGianHoc(ThoiGianHoc tgh)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("THOIGIAN_HOC_INSERT", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaLop", tgh.MMaLop);
                command.Parameters.AddWithValue("@MaThu", tgh.MMaThu);
                command.Parameters.AddWithValue("@MaCa", tgh.MMaCa);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex);
            }
            return false;
        }
        public bool insertThoiGianHoc(ThoiGianHoc tgh)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("THOIGIAN_HOC_INSERT", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaLop", tgh.MMaLop);
                command.Parameters.AddWithValue("@MaThu", tgh.MMaThu);
                command.Parameters.AddWithValue("@MaCa", tgh.MMaCa);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex);
            }
            return false;
        }
        public bool xoaThoiGianHoc(String maLop)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("THOIGIAN_HOC_DELETE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaLop", maLop);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex);
                connection.Close();
            }
            return false;
        }

        public bool suaThoiGianHoc(ThoiGianHoc tgh)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("THOIGIAN_HOC_UPDATE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaLop", tgh.MMaLop);
                command.Parameters.AddWithValue("@MaThu", tgh.MMaThu);
                command.Parameters.AddWithValue("@MaCa", tgh.MMaCa);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex);
            }
            return false;
        }

        public List<ThoiGianHoc> getThoiGianHocCuaLop(String maLop)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("THOIGIAN_HOC_CUA_LOP", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaLop", maLop);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<ThoiGianHoc> list = new List<ThoiGianHoc>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ThoiGianHoc tgh = new ThoiGianHoc();
                    tgh.MMaLop = dt.Rows[i][0].ToString();
                    tgh.MMaThu = dt.Rows[i][1].ToString();
                    tgh.MMaCa = dt.Rows[i][2].ToString();
                    list.Add(tgh);
                }
                connection.Close();
                return list;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex);
                return null;
            }
        } 
    }
    

}


