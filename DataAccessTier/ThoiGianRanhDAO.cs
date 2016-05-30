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
    public class ThoiGianRanhDAO: DBConnection
    {
        public ThoiGianRanhDAO()
        {
        }

        public bool insertThoiGianRanh(ThoiGianRanh tgRanh)
        {
            bool result = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("THOIGIAN_RANH_INSERT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHV", tgRanh.MMaHV);
                cmd.Parameters.AddWithValue("@MaThu", tgRanh.MMaThu);
                cmd.Parameters.AddWithValue("@MaCa", tgRanh.MMaCa);
                cmd.ExecuteNonQuery();
                result = true;
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            return result;
        }
    }
}
