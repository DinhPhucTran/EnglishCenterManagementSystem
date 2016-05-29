using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;


namespace DataAccessTier
{
    public class ThiXepLopDAO:DBConnection
    {
        public ThiXepLopDAO() { }
        public List<ThiXepLop> getListThiXepLop()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("THI_XEP_LOP_LIST", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<ThiXepLop> list = new List<ThiXepLop>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ThiXepLop txl = new ThiXepLop();
                    txl.MMaThiXL = dt.Rows[i][0].ToString();
                    txl.MMaPhong = dt.Rows[i][1].ToString();
                    txl.MCaThi = dt.Rows[i][2].ToString();
                    txl.MDeThi = dt.Rows[i][3].ToString();
                    txl.MNgayThi = DateTime.Parse(dt.Rows[i][4].ToString());
                    list.Add(txl);
                }
                connection.Close();
                return list;
            }
            catch (Exception)
            {
                connection.Close();
                return null;
            }
        }

        public bool themThiXepLop(ThiXepLop txl)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("THI_XEP_LOP_INSERT", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaThiXL", txl.MMaThiXL);
                command.Parameters.AddWithValue("@MaPhong", txl.MMaPhong);
                command.Parameters.AddWithValue("@CaThi", txl.MCaThi);
                command.Parameters.AddWithValue("@MaDeThi", txl.MDeThi);
                command.Parameters.AddWithValue("@NgayThi", txl.MNgayThi);
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

        public bool suaThiXepLop(ThiXepLop txl)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("THI_XEP_LOP_UPDATE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaThiXL", txl.MMaThiXL);
                command.Parameters.AddWithValue("@MaPhong", txl.MMaPhong);
                command.Parameters.AddWithValue("@CaThi", txl.MCaThi);
                command.Parameters.AddWithValue("@MaDeThi", txl.MDeThi);
                command.Parameters.AddWithValue("@NgayThi", txl.MNgayThi);
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

        public bool xoaThiXepLop(String maTxl)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("THI_XEP_LOP_INSERT", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaThiXL", maTxl);
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
