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
    public class ThuDAO: DBConnection
    {
        public ThuDAO()
        { }

        public List<Thu> getAllThu()
        {
            List<Thu> result = new List<Thu>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("Select * from THU", connection);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    result.Add(new Thu(dt.Rows[i]["MaThu"].ToString(), dt.Rows[i]["TenThu"].ToString()));
                }
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
