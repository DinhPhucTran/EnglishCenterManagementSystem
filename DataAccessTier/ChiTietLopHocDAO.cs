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

        public List<ChiTietLopHoc> selectChiTietLopHoc(String maLop)
        {
            List<ChiTietLopHoc> result = new List<ChiTietLopHoc>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("CHI_TIET_LOP_HOC_SELECT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaLopHoc", maLop);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChiTietLopHoc ct = new ChiTietLopHoc();
                    ct.MMaLopHoc = maLop;
                    ct.MMaHocVien = dt.Rows[i]["MaHV"].ToString();
                    ct.MTinhTrangDongHocPhi = Int32.Parse(dt.Rows[i]["TinhTrangDongHP"].ToString());
                    ct.MKetQuaThi = float.Parse(dt.Rows[i]["KetQuaThi"].ToString());
                    ct.MSoTienNo = Double.Parse(dt.Rows[i]["SoTienNo"].ToString());
                    result.Add(ct);
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            return result;
        }

        public ChiTietLopHoc selectChiTietLopHocByMaHV(String maHV)
        {
            ChiTietLopHoc ctl = new ChiTietLopHoc();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("CHI_TIET_LOP_HOC_SELECT_BY_MAHV", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHV", maHV);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                ctl.MMaLopHoc = maHV;
                ctl.MMaHocVien = dt.Rows[0]["MaHV"].ToString();
                ctl.MTinhTrangDongHocPhi = Int32.Parse(dt.Rows[0]["TinhTrangDongHP"].ToString());
                ctl.MKetQuaThi = float.Parse(dt.Rows[0]["KetQuaThi"].ToString());
                ctl.MSoTienNo = Double.Parse(dt.Rows[0]["SoTienNo"].ToString());
                    
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            return ctl;
        }
    }
}
