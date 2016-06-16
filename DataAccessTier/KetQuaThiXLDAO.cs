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
    public class KetQuaThiXLDAO: DBConnection
    {
        public List<KetQuaThi> getListKQT(DateTime from, DateTime to)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("KET_QUA_THI_HOC_VIEN", connection);
                cmd.Parameters.AddWithValue("@fromDate", from);
                cmd.Parameters.AddWithValue("@toDate", to);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<KetQuaThi> list = new List<KetQuaThi>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    KetQuaThi kqt = new KetQuaThi();
                    kqt.mMaHV = dt.Rows[i][0].ToString();
                    kqt.MTenHV = dt.Rows[i][1].ToString();
                    kqt.MNgaySinh = DateTime.Parse(dt.Rows[i][2].ToString());
                    kqt.MGioiTinh = dt.Rows[i][3].ToString();
                    kqt.MDiaChi = dt.Rows[i][4].ToString();
                    kqt.MSdt = dt.Rows[i][5].ToString();
                    kqt.MMaCTDaHoc = dt.Rows[i][6].ToString();
                    kqt.MMaCTMuonHoc = dt.Rows[i][7].ToString();
                    kqt.MMaTDDaHoc = dt.Rows[i][8].ToString();
                    kqt.MMaTDMuonHoc = dt.Rows[i][9].ToString();
                    kqt.MEmail = dt.Rows[i][10].ToString();
                    kqt.MMaThiXL = dt.Rows[i][11].ToString();
                    kqt.MKetQua = int.Parse(dt.Rows[i][12].ToString());
                    kqt.MChuongTrinhDeNghi = dt.Rows[i][13].ToString();
                    kqt.MChuongTrinhMuonHoc = dt.Rows[i][14].ToString();
                    kqt.MMaPhong = dt.Rows[i][15].ToString();
                    kqt.MCaThi = dt.Rows[i][16].ToString();
                    kqt.MMaDe = dt.Rows[i][17].ToString();
                    String ngayThi = dt.Rows[i][18].ToString();
                    kqt.MNgayThi = DateTime.Parse(ngayThi);
                    list.Add(kqt);
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

        public List<string> getMaLopDeNghi(string maChuongTrinh, DateTime fromDate)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("DANH_SACH_LOP_SAP_MO_THEO_MA_CHT", connection);
                cmd.Parameters.AddWithValue("@maCT", maChuongTrinh);
                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> list = new List<String>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String maLop = dt.Rows[i][0].ToString();

                    list.Add(maLop);
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

        public List<string> getMaLopDeNghi(string maChuongTrinhDeNghi, string maChuongMongMuon, DateTime fromDate)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("DANH_SACH_LOP_SAP_MO_THEO_2MA_CHT", connection);
                cmd.Parameters.AddWithValue("@maCTDeNghi", maChuongTrinhDeNghi);
                cmd.Parameters.AddWithValue("@maCTMuonHoc", maChuongMongMuon);
                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<String> list = new List<String>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String maLop = dt.Rows[i][0].ToString();

                    list.Add(maLop);
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
    }
}
