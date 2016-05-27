﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DataAccessTier
{
    public class TrinhDoDAO: DBConnection
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
                SqlCommand cmd = new SqlCommand("TRINH_DO_INSERT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaTrinhDo", trinhDo.MMaTrinhDo);
                cmd.Parameters.AddWithValue("@TenTrinhDo", trinhDo.MTenTrinhDo);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
            return true;
        }

        public List<TrinhDo> getListTrinhDo()
        {
            List<TrinhDo> result = new List<TrinhDo>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("TRINH_DO_LIST", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TrinhDo td = new TrinhDo(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
                    result.Add(td);
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

        public bool xoaTrinhDo()
        {
            return true;
        }
    }
}
