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
    public class CaDAO : DBConnection
    {
        public CaDAO()
            : base()
        {
        }

        //public bool xoaCa(String id)
        //{
        //    try
        //    {
        //        if (connection.State != ConnectionState.Open)
        //        {
        //            connection.Open();
        //        }
        //        SqlCommand command = new SqlCommand("CA_DELETE", connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@MaCa", id);
        //        command.ExecuteNonQuery();
        //        connection.Close();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        connection.Close();
        //    }
        //    return false;
        //}

        //public bool themCa(Ca ca)
        //{
        //    try
        //    {
        //        if (connection.State != ConnectionState.Open)
        //        {
        //            connection.Open();
        //        }
        //        SqlCommand command = new SqlCommand("CA_INSERT", connection);
        //        command.CommandType = CommandType.StoredProcedure;

        //        command.Parameters.AddWithValue("@MaCa", ca.MMaCa);
        //        command.Parameters.AddWithValue("@ThoiGianBD", ca.MThoiGianBatDau.ToString("hh:mm:ss[.nnnnnnn]"));
        //        command.Parameters.AddWithValue("@ThoiGianKT", ca.MThoiGianKetThuc.ToString("hh:mm:ss[.nnnnnnn]"));

        //        command.ExecuteNonQuery();
        //        connection.Close();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        connection.Close();
        //    }
        //    return false;
        //}

        public List<Ca> getAllCa()
        {
            List<Ca> result = new List<Ca>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("CA_LIST", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Ca temp = new Ca(dt.Rows[i]["MaCa"].ToString(),
                                    DateTime.Parse(dt.Rows[i]["ThoiGianBD"].ToString()),
                                    DateTime.Parse(dt.Rows[i]["ThoiGianKT"].ToString()));
                    result.Add(temp);
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            return result;
        }

        public Ca selectCa(String maCa)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("CA_SELECT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaCa", maCa);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Ca ca = new Ca();
                ca.MMaCa = dt.Rows[0]["MaCa"].ToString();
                ca.MThoiGianBatDau = DateTime.Parse(dt.Rows[0]["ThoiGianBD"].ToString());
                ca.MThoiGianKetThuc = DateTime.Parse(dt.Rows[0]["ThoiGianKT"].ToString());
                connection.Close();
                return ca;
            }
            catch (Exception)
            {
                connection.Close();
            }
            return null;
        }
    }
}
