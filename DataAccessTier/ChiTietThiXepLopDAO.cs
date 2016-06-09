using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DataAccessTier
{
    public class ChiTietThiXepLopDAO: DBConnection
    {
        public ChiTietThiXepLopDAO()
        { }

        public bool addHocVien(HocVien hv, ThiXepLop txl)
        {
            bool result = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("CHI_TIET_THI_XL_INSERT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaThiXepLop", txl.MMaThiXL);
                cmd.Parameters.AddWithValue("@MaHV", hv.MMaHocVien);
                cmd.Parameters.AddWithValue("@KetQuaThi", 0);
                //chuong trinh de nghi dc alter sau khi co ket qua thi xep lop.
                cmd.Parameters.AddWithValue("@ChuongTrinhDeNghi", DBNull.Value);
                if (hv.MMaChuongTrinhMuonHoc == null)
                {
                    cmd.Parameters.AddWithValue("@ChuongTrinhMongMuon", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ChuongTrinhMongMuon", hv.MMaChuongTrinhMuonHoc);
                }
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public List<ChiTietThiXepLop> getAllChiTietTXL()
        {
            List<ChiTietThiXepLop> result = new List<ChiTietThiXepLop>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from CHI_TIET_THI_XL", connection);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChiTietThiXepLop temp = new ChiTietThiXepLop();
                    temp.MMaThiXepLop = dt.Rows[i]["MaThiXepLop"].ToString();
                    temp.MMaHocVien = dt.Rows[i]["MaHV"].ToString();
                    temp.MKetQuaThi = float.Parse(dt.Rows[i]["KetQuaThi"].ToString());
                    temp.MChuongTrinhDeNghi = dt.Rows[i]["ChuongTrinhDeNghi"].ToString();
                    temp.MChuongTrinhMongMuon = dt.Rows[i]["ChuongTrinhMongMuon"].ToString();
                    result.Add(temp);
                }
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public List<ChiTietThiXepLop> getChiTietTXLByMaTXL(String maTXL)
        {
            List<ChiTietThiXepLop> result = new List<ChiTietThiXepLop>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("CHI_TIET_THI_XEP_LOP_BY_MA_TXL", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaTXL", maTXL);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChiTietThiXepLop temp = new ChiTietThiXepLop();
                    temp.MMaThiXepLop = dt.Rows[i]["MaThiXepLop"].ToString();
                    temp.MMaHocVien = dt.Rows[i]["MaHV"].ToString();
                    temp.MKetQuaThi = float.Parse(dt.Rows[i]["KetQuaThi"].ToString());
                    temp.MChuongTrinhDeNghi = dt.Rows[i]["ChuongTrinhDeNghi"].ToString();
                    temp.MChuongTrinhMongMuon = dt.Rows[i]["ChuongTrinhMongMuon"].ToString();
                    result.Add(temp);
                }
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public bool updateKetQuaThi(List<ChiTietThiXepLop> ds)
        {
            bool result = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                foreach(ChiTietThiXepLop i in ds)
                {
                    SqlCommand cmd = new SqlCommand("CHI_TIET_THI_XL_UPDATE", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaThiXepLop", i.MMaThiXepLop);
                    cmd.Parameters.AddWithValue("@MaHV", i.MMaHocVien);
                    cmd.Parameters.AddWithValue("@KetQuaThi", i.MKetQuaThi);
                    if (i.MChuongTrinhDeNghi == "")
                    {
                        cmd.Parameters.AddWithValue("@ChuongTrinhDeNghi", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ChuongTrinhDeNghi", i.MChuongTrinhDeNghi);
                    }
                    if (i.MChuongTrinhMongMuon == "")
                    {
                        cmd.Parameters.AddWithValue("@ChuongTrinhMongMuon", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ChuongTrinhMongMuon", i.MChuongTrinhMongMuon);
                    }
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public bool insertChiTietThiXepLop(ChiTietThiXepLop txl)
        {
            bool result = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("CHI_TIET_THI_XL_INSERT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaThiXepLop", txl.MMaThiXepLop);
                cmd.Parameters.AddWithValue("@MaHV", txl.MMaHocVien);
                cmd.Parameters.AddWithValue("@KetQuaThi", 0);
                //chuong trinh de nghi dc alter sau khi co ket qua thi xep lop.
                cmd.Parameters.AddWithValue("@ChuongTrinhDeNghi", DBNull.Value);
                if (txl.MChuongTrinhMongMuon == null)
                {
                    cmd.Parameters.AddWithValue("@ChuongTrinhMongMuon", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ChuongTrinhMongMuon", txl.MChuongTrinhMongMuon);
                }
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public String getMaCTHocDeNghi(String maTXL, String maHV)
        {
            String result = "";
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("CHUONG_TRINH_HOC_DENGHI", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaChiTietTXL", maTXL);//dat nham ten trong procedure
                cmd.Parameters.AddWithValue("@MaHV", maHV);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                result = dt.Rows[0]["MaCTHoc"].ToString();
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}
