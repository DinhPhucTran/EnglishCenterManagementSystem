using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DataAccessTier
{
    class TrinhDoDAO: DBConnection
    {

        public TrinhDoDAO():base()
        {
        }

        public bool themTrinhDo(TrinhDo trinhDo)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("TRINH_DO_INSERT");
                cmd.Parameters.AddWithValue("", trinhDo.MMaTrinhDo);
                cmd.Parameters.AddWithValue("", trinhDo.MTenTrinhDo);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public bool xoaTrinhDo()
        {
            return true;
        }
    }
}
