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
    public class HocVienDAO: DBConnection
    {
        public HocVienDAO()
        {
        }

        public bool insertHocVien(HocVien hv)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("HOC_VIEN_INSERT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHocVien", hv.MMaHocVien);
                cmd.Parameters.AddWithValue("@TenHocVien", hv.MTenHocVien);
                //cmd.Parameters.AddWithValue("@NgaySinh", hv.MNgaySinh);
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = hv.MNgaySinh.ToString("yyyy-MM-dd h:m:s");
                cmd.Parameters.AddWithValue("@Phai", hv.MPhai);
                cmd.Parameters.AddWithValue("@DiaChi", hv.MDiaChi);
                cmd.Parameters.AddWithValue("@Email", hv.MEmail);
                cmd.Parameters.AddWithValue("@SoDT", hv.MSdt);
                if (hv.MMaChuongTrinhDaHoc == null)
                {
                    cmd.Parameters.AddWithValue("@MaCTDaHoc", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaCTDaHoc", hv.MMaChuongTrinhDaHoc);
                }
                if (hv.MMaChuongTrinhMuonHoc == null)
                {
                    cmd.Parameters.AddWithValue("@MaCTMuonHoc", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaCTMuonHoc", hv.MMaChuongTrinhMuonHoc);
                }
                if (hv.MMaTrinhDoDaHoc == null)
                {
                    cmd.Parameters.AddWithValue("@MaTDDaHoc", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaTDDaHoc", hv.MMaTrinhDoDaHoc);
                }
                if (hv.MMaTrinhDoMuonHoc == null)
                {
                    cmd.Parameters.AddWithValue("@MaTDMuonHoc", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaTDMuonHoc", hv.MMaTrinhDoMuonHoc);
                }
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public List<String> getAllMaHV()
        {
            List<String> result = new List<string>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("HOC_VIEN_LIST_MAHV", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    result.Add(dt.Rows[i]["MaHocVien"].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return result;
        }

        public List<String> getMaHVbyMaLop(String maLop)
        {
            List<String> result = new List<string>();
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
                    result.Add(dt.Rows[i]["MaHV"].ToString());
                }
                connection.Close();
            } catch(Exception){
                connection.Close();
            }
            return result;
        }

        public List<HocVien> getHocVienByMaLop(String maLop)
        {
            List<HocVien> result = new List<HocVien>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("DANH_SACH_HOC_VIEN", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaLopHoc", maLop);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HocVien hocvien = new HocVien();
                    hocvien.MMaHocVien = dt.Rows[i]["MaHocVien"].ToString();
                    hocvien.MTenHocVien = dt.Rows[i]["TenHocVien"].ToString();
                    hocvien.MNgaySinh = DateTime.Parse(dt.Rows[i]["NgaySinh"].ToString());
                    hocvien.MPhai = dt.Rows[i]["Phai"].ToString();
                    hocvien.MDiaChi = dt.Rows[i]["DiaChi"].ToString();
                    hocvien.MSdt = dt.Rows[i]["SoDT"].ToString();
                    hocvien.MMaChuongTrinhDaHoc = dt.Rows[i]["MaCTDaHoc"].ToString();
                    hocvien.MMaChuongTrinhMuonHoc = dt.Rows[i]["MaCTMuonHoc"].ToString();
                    hocvien.MMaTrinhDoDaHoc = dt.Rows[i]["MaTDDaHoc"].ToString();
                    hocvien.MMaTrinhDoMuonHoc = dt.Rows[i]["MaTDMuonHoc"].ToString();
                    hocvien.MEmail = dt.Rows[i]["Email"].ToString();
                    result.Add(hocvien);
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            return result;
        }

        public HocVien selectHocVien(String maHV)
        {
            HocVien hocvien = new HocVien();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("HOC_VIEN_SELECT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHocVien", maHV);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                hocvien.MMaHocVien = dt.Rows[0]["MaHocVien"].ToString();
                hocvien.MTenHocVien = dt.Rows[0]["TenHocVien"].ToString();
                hocvien.MNgaySinh = DateTime.Parse(dt.Rows[0]["NgaySinh"].ToString());
                hocvien.MPhai = dt.Rows[0]["Phai"].ToString();
                hocvien.MDiaChi = dt.Rows[0]["DiaChi"].ToString();
                hocvien.MSdt = dt.Rows[0]["SoDT"].ToString();
                hocvien.MMaChuongTrinhDaHoc = dt.Rows[0]["MaCTDaHoc"].ToString();
                hocvien.MMaChuongTrinhMuonHoc = dt.Rows[0]["MaCTMuonHoc"].ToString();
                hocvien.MMaTrinhDoDaHoc = dt.Rows[0]["MaTDDaHoc"].ToString();
                hocvien.MMaTrinhDoMuonHoc = dt.Rows[0]["MaTDMuonHoc"].ToString();
                hocvien.MEmail = dt.Rows[0]["Email"].ToString();

                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            return hocvien;
        }

        public int countHocVienByMaLop(String maLop)
        {
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
                connection.Close();
                return dt.Rows.Count;
            }
            catch (Exception)
            {
                connection.Close();
            }
            return 0;
        }

        public List<HocVien> getListHocVien()
        {
            List<HocVien> result = new List<HocVien>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("HOC_VIEN_LIST", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HocVien hocvien = new HocVien();
                    hocvien.MMaHocVien = dt.Rows[i]["MaHocVien"].ToString();
                    hocvien.MTenHocVien = dt.Rows[i]["TenHocVien"].ToString();
                    hocvien.MNgaySinh = DateTime.Parse(dt.Rows[i]["NgaySinh"].ToString());
                    hocvien.MPhai = dt.Rows[i]["Phai"].ToString();
                    hocvien.MDiaChi = dt.Rows[i]["DiaChi"].ToString();
                    hocvien.MSdt = dt.Rows[i]["SoDT"].ToString();
                    hocvien.MMaChuongTrinhDaHoc = dt.Rows[i]["MaCTDaHoc"].ToString();
                    hocvien.MMaChuongTrinhMuonHoc = dt.Rows[i]["MaCTMuonHoc"].ToString();
                    hocvien.MMaTrinhDoDaHoc = dt.Rows[i]["MaTDDaHoc"].ToString();
                    hocvien.MMaTrinhDoMuonHoc = dt.Rows[i]["MaTDMuonHoc"].ToString();
                    hocvien.MEmail = dt.Rows[i]["Email"].ToString();
                    result.Add(hocvien);
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            return result;
        }

        public bool updateHocVien(HocVien hv)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("HOC_VIEN_UPDATE", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHocVien", hv.MMaHocVien);
                cmd.Parameters.AddWithValue("@TenHocVien", hv.MTenHocVien);
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = hv.MNgaySinh.ToString("yyyy-MM-dd h:m:s");
                cmd.Parameters.AddWithValue("@Phai", hv.MPhai);
                cmd.Parameters.AddWithValue("@DiaChi", hv.MDiaChi);
                cmd.Parameters.AddWithValue("@Email", hv.MEmail);
                cmd.Parameters.AddWithValue("@SoDT", hv.MSdt);
                if (hv.MMaChuongTrinhDaHoc == null)
                {
                    cmd.Parameters.AddWithValue("@MaCTDaHoc", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaCTDaHoc", hv.MMaChuongTrinhDaHoc);
                }
                if (hv.MMaChuongTrinhMuonHoc == null)
                {
                    cmd.Parameters.AddWithValue("@MaCTMuonHoc", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaCTMuonHoc", hv.MMaChuongTrinhMuonHoc);
                }
                if (hv.MMaTrinhDoDaHoc == null)
                {
                    cmd.Parameters.AddWithValue("@MaTDDaHoc", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaTDDaHoc", hv.MMaTrinhDoDaHoc);
                }
                if (hv.MMaTrinhDoMuonHoc == null)
                {
                    cmd.Parameters.AddWithValue("@MaTDMuonHoc", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@MaTDMuonHoc", hv.MMaTrinhDoMuonHoc);
                }
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public bool insertHocVienNgayTiepNhan(HocVien hv, DateTime ngay)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("HOCVIEN_NGAYTIEPNHAN_INSERT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHocVien", hv.MMaHocVien);
                cmd.Parameters.Add("@NgayTiepNhan", SqlDbType.Date).Value = ngay.ToString("yyyy-MM-dd h:m:s");
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<DateTime> getListNgayTiepNhan()
        {
            List<DateTime> result = new List<DateTime>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("HOCVIEN_NGAYTIEPNHAN_LIST", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DateTime date = DateTime.Parse(dt.Rows[i]["NgayTiepNhan"].ToString());
                    result.Add(date);
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            return result;
        }

    }
}
