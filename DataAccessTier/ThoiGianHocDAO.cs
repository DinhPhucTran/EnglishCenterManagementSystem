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
                SqlCommand command = new SqlCommand("THOI_GIAN_HOC_INSERT", connection);
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
                SqlCommand command = new SqlCommand("THOI_GIAN_HOC_INSERT", connection);
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
        public bool xoaThoiGianHoc(String maTg)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("THOI_GIAN_HOC_DELETE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaLop", maTg);
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
                SqlCommand command = new SqlCommand("THOI_GIAN_HOC_UPDATE", connection);
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
    }
    

}


