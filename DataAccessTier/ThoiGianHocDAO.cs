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
    public class ThoiGianHocDAO: DBConnection
    {
        public ThoiGianHocDAO()
        {
        }

        public bool insertThoiGianHoc(ThoiGianHoc tgHoc)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Close();
                }
                SqlCommand cmd = new SqlCommand("THOIGIAN_HOC_INSERT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaLop", tgHoc.MMaLop);
                cmd.Parameters.AddWithValue("@MaThu", tgHoc.MMaThu);
                cmd.Parameters.AddWithValue("@MaCa", tgHoc.MMaCa);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }
    }
}
