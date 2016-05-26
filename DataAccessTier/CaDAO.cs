using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DataAccessTier
{
    class CaDAO : DBConnection
    {
        public CaDAO()
            : base()
        {

        }

        public bool xoaCa(String id)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("CA_DELETE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaCa", id);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
            }
            return false;
        }

        public bool themCa(Ca ca)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("CA_INSERT", connection);
                command.CommandType = CommandType.StoredProcedure;
               
                command.Parameters.AddWithValue("@MaCa", ca.MMaCa);
                command.Parameters.AddWithValue("@ThoiGianBD", ca.MThoiGianBatDau.ToString("hh:mm:ss[.nnnnnnn]"));
                command.Parameters.AddWithValue("@ThoiGianKT", ca.MThoiGianKetThuc.ToString("hh:mm:ss[.nnnnnnn]"));

                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
            }
            return false;
        }
    }
}
