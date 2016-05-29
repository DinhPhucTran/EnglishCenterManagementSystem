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
   public class DeThiDAO :DBConnection
    {
       public DeThiDAO() { }

       public List<DeThi> getListDeThi()
       {
           try
           {
               if (connection.State != System.Data.ConnectionState.Open)
               {
                   connection.Open();
               }
               SqlCommand cmd = new SqlCommand("DE_THI_LIST", connection);
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               DataTable dt = new DataTable();
               da.Fill(dt);
               List<DeThi> list = new List<DeThi>();
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   DeThi dthi = new DeThi();
                   dthi.MMaDeThi = dt.Rows[i][0].ToString();
                   dthi.MLoaiDeThi = dt.Rows[i][1].ToString();
                   dthi.MChiTiet = dt.Rows[i][2].ToString();
                   list.Add(dthi);
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

       public bool themDeThi(DeThi dthi)
       {
           try
           {
               if (connection.State != ConnectionState.Open)
               {
                   connection.Open();
               }
               SqlCommand command = new SqlCommand("DE_THI_INSERT", connection);
               command.CommandType = CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@MaDeThi", dthi.MMaDeThi);
               command.Parameters.AddWithValue("@LoaiDeTHi",dthi.MLoaiDeThi);
               command.Parameters.AddWithValue("@ChiTiet", dthi.MChiTiet);
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

       public bool xoaDeThi(String ma)
       {
           try
           {
               if (connection.State != ConnectionState.Open)
               {
                   connection.Open();
               }
               SqlCommand command = new SqlCommand("DE_THI_DELETE", connection);
               command.CommandType = CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@MaDeThi", ma);
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

       public bool suaDeThi(DeThi dthi)
       {
           try
           {
               if (connection.State != ConnectionState.Open)
               {
                   connection.Open();
               }
               SqlCommand command = new SqlCommand("DE_THI_UPDATE", connection);
               command.CommandType = CommandType.StoredProcedure;
               command.Parameters.AddWithValue("@MaDeThi", dthi.MMaDeThi);
               command.Parameters.AddWithValue("@LoaiDeTHi", dthi.MLoaiDeThi);
               command.Parameters.AddWithValue("@ChiTiet", dthi.MChiTiet);
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
