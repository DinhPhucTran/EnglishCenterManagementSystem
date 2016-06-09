﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessTier
{
    public class ChiTietLopHocDAO : DBConnection
    {
        public ChiTietLopHocDAO() { }

        public bool insertChiTietLopHoc(ChiTietLopHoc ct)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("CHI_TIET_LOP_HOC_INSERT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaLopHoc", ct.MMaLopHoc);
                cmd.Parameters.AddWithValue("@MaHV", ct.MMaHocVien);
                cmd.Parameters.AddWithValue("@TinhTrangDongHP", ct.MTinhTrangDongHocPhi);
                cmd.Parameters.AddWithValue("@KetQuaThi", ct.MKetQuaThi);
                cmd.Parameters.AddWithValue("@SoTienNo", ct.MSoTienNo);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}