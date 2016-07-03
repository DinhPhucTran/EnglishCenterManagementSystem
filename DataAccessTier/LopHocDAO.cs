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
    public class LopHocDAO : DBConnection
    {
        public LopHocDAO()
        {
        }

        public List<LopHoc> getAllLopHocByMaChuongTrinhHoc(String maCTHoc)
        {
            List<LopHoc> result = new List<LopHoc>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("LOP_HOC_BY_MA_CHUONG_TRINH_HOC", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaChuongTrinh", maCTHoc);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                result = dt.AsEnumerable().Select(m =>
                    new LopHoc
                    {
                        MMaLop = m.Field<String>("MaLop"),
                        MNgayKhaiGiang = m.Field<DateTime>("NgayKhaiGiang"),
                        MNgayBatDau = m.Field<DateTime>("ThoiGianBD"),
                        MNgayKetThuc = m.Field<DateTime>("ThoiGianKT"),
                        MSoTien = double.Parse(m.Field<decimal>("SoTien").ToString()),
                        MMaGiangVien = m.Field<String>("MaGV"),
                        MMaCTHoc = m.Field<String>("MaCTHoc"),
                        MMaPhong = m.Field<String>("MaPhong")
                    }).ToList();
            }
            catch (Exception e)
           {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public List<LopHoc> getAllLopHoc()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("LOP_HOC_LIST", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<LopHoc> list = new List<LopHoc>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LopHoc lop = new LopHoc();
                    lop.MMaLop = dt.Rows[i][0].ToString();
                    lop.MNgayKhaiGiang = DateTime.Parse(dt.Rows[i][1].ToString());
                    lop.MNgayBatDau = DateTime.Parse(dt.Rows[i][2].ToString());
                    lop.MNgayKetThuc = DateTime.Parse(dt.Rows[i][3].ToString());
                    lop.MSoTien = double.Parse(dt.Rows[i][4].ToString());
                    lop.MMaGiangVien = dt.Rows[i][5].ToString();
                    lop.MMaCTHoc = dt.Rows[i][6].ToString();
                    lop.MMaPhong = dt.Rows[i][7].ToString();
                    list.Add(lop);
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

        public bool themLopHoc(LopHoc lop)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("LOP_HOC_INSERT", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Malop", lop.MMaLop);
                command.Parameters.AddWithValue("@NgayKhaiGiang", lop.MNgayKhaiGiang);
                command.Parameters.AddWithValue("@ThoiGianBD", lop.MNgayBatDau);
                command.Parameters.AddWithValue("@ThoiGianKT", lop.MNgayKetThuc);
                command.Parameters.AddWithValue("@SoTien", lop.MSoTien);
                command.Parameters.AddWithValue("@MaGV", lop.MMaGiangVien);
                command.Parameters.AddWithValue("@MaCTHoc", lop.MMaCTHoc);
                command.Parameters.AddWithValue("@MaPhong", lop.MMaPhong);
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

        public bool suaLopHoc(LopHoc lop)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("LOP_HOC_UPDATE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Malop", lop.MMaLop);
                command.Parameters.AddWithValue("@NgayKhaiGiang", lop.MNgayKhaiGiang);
                command.Parameters.AddWithValue("@ThoiGianBD", lop.MNgayBatDau);
                command.Parameters.AddWithValue("@ThoiGianKT", lop.MNgayKetThuc);
                command.Parameters.AddWithValue("@SoTien", lop.MSoTien);
                command.Parameters.AddWithValue("@MaGV", lop.MMaGiangVien);
                command.Parameters.AddWithValue("@MaCTHoc", lop.MMaCTHoc);
                command.Parameters.AddWithValue("@MaPhong", lop.MMaPhong);
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

        public bool xoaLopHoc(String maLop)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("LOP_HOC_DELETE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Malop", maLop);
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

        public List<LopHoc> getLopHocByTime(DateTime thoiGianBD, DateTime thoiGianKT)
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("LOP_HOC_BY_TIME", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ThoiGianBD", thoiGianBD);
                cmd.Parameters.AddWithValue("@ThoiGianKT", thoiGianKT);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<LopHoc> list = new List<LopHoc>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LopHoc lop = new LopHoc();
                    lop.MMaLop = dt.Rows[i][0].ToString();
                    lop.MNgayKhaiGiang = DateTime.Parse(dt.Rows[i][1].ToString());
                    lop.MNgayBatDau = DateTime.Parse(dt.Rows[i][2].ToString());
                    lop.MNgayKetThuc = DateTime.Parse(dt.Rows[i][3].ToString());
                    lop.MSoTien = double.Parse(dt.Rows[i][4].ToString());
                    lop.MMaGiangVien = dt.Rows[i][5].ToString();
                    lop.MMaCTHoc = dt.Rows[i][6].ToString();
                    lop.MMaPhong = dt.Rows[i][7].ToString();
                    list.Add(lop);
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

        public List<LopHoc> getListLopHocByMaHV(String maHv)
        {
            List<LopHoc> result = new List<LopHoc>();
            List<String> listMaLop = new List<string>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("CHI_TIET_LOP_HOC_SELECT_BY_MAHV", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHV", maHv);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                    listMaLop.Add(dt.Rows[i]["MaLopHoc"].ToString());

                foreach (String ma in listMaLop)
                {
                    SqlCommand command = new SqlCommand("LOP_HOC_SELECT", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaLop", ma);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        LopHoc lop = new LopHoc();
                        lop.MMaLop = ma;
                        lop.MMaCTHoc = table.Rows[i]["MaCTHoc"].ToString();
                        lop.MMaGiangVien = table.Rows[i]["MaGV"].ToString();
                        lop.MMaPhong = table.Rows[i]["MaPhong"].ToString();
                        lop.MNgayBatDau = DateTime.Parse(table.Rows[i]["ThoiGianBD"].ToString());
                        lop.MNgayKetThuc = DateTime.Parse(table.Rows[i]["ThoiGianKT"].ToString());
                        lop.MNgayKhaiGiang = DateTime.Parse(table.Rows[i]["NgayKhaiGiang"].ToString());
                        lop.MSoTien = Int32.Parse(table.Rows[i]["SoTien"].ToString());
                        result.Add(lop);
                    }
                }
                connection.Close();

            }
            catch (Exception)
            {
                connection.Close();
            }

            return result;
        }

        public LopHoc getLopMoiNhatByMaHV(String maHv)
        {
            List<LopHoc> listLop = new List<LopHoc>();
            List<String> listMaLop = new List<string>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("CHI_TIET_LOP_HOC_SELECT_BY_MAHV", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHV", maHv);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                    listMaLop.Add(dt.Rows[i]["MaLopHoc"].ToString());

                foreach (String ma in listMaLop)
                {
                    SqlCommand command = new SqlCommand("LOP_HOC_SELECT", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaLop", ma);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        LopHoc lop = new LopHoc();
                        lop.MMaLop = ma;
                        lop.MMaCTHoc = table.Rows[i]["MaCTHoc"].ToString();
                        lop.MMaGiangVien = table.Rows[i]["MaGV"].ToString();
                        lop.MMaPhong = table.Rows[i]["MaPhong"].ToString();
                        lop.MNgayBatDau = DateTime.Parse(table.Rows[i]["ThoiGianBD"].ToString());
                        lop.MNgayKetThuc = DateTime.Parse(table.Rows[i]["ThoiGianKT"].ToString());
                        lop.MNgayKhaiGiang = DateTime.Parse(table.Rows[i]["NgayKhaiGiang"].ToString());
                        lop.MSoTien = Double.Parse(table.Rows[i]["SoTien"].ToString());
                        listLop.Add(lop);
                    }
                }

                if (listLop.Count > 0)
                {
                    return listLop.OrderByDescending(item => item.MNgayBatDau).First();
                }

                connection.Close();

            }
            catch (Exception)
            {
                connection.Close();
            }

            return null;
        }

        public LopHoc selectLopHoc(String maLop)
        {
            //List<LopHoc> listLop = new List<LopHoc>();
            LopHoc lop = new LopHoc();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("LOP_HOC_SELECT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaLop", maLop);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    LopHoc lop = new LopHoc();
                //    lop.MMaLop = maLop;
                //    lop.MMaCTHoc = dt.Rows[i]["MaCTHoc"].ToString();
                //    lop.MMaGiangVien = dt.Rows[i]["MaGV"].ToString();
                //    lop.MMaPhong = dt.Rows[i]["MaPhong"].ToString();
                //    lop.MNgayBatDau = DateTime.Parse(dt.Rows[i]["ThoiGianBD"].ToString());
                //    lop.MNgayKetThuc = DateTime.Parse(dt.Rows[i]["ThoiGianKT"].ToString());
                //    lop.MNgayKhaiGiang = DateTime.Parse(dt.Rows[i]["NgayKhaiGiang"].ToString());
                //    lop.MSoTien = double.Parse(dt.Rows[i]["SoTien"].ToString());
                //    listLop.Add(lop);
                //}
                lop.MMaLop = maLop;
                lop.MMaCTHoc = dt.Rows[0]["MaCTHoc"].ToString();
                lop.MMaGiangVien = dt.Rows[0]["MaGV"].ToString();
                lop.MMaPhong = dt.Rows[0]["MaPhong"].ToString();
                lop.MNgayBatDau = DateTime.Parse(dt.Rows[0]["ThoiGianBD"].ToString());
                lop.MNgayKetThuc = DateTime.Parse(dt.Rows[0]["ThoiGianKT"].ToString());
                lop.MNgayKhaiGiang = DateTime.Parse(dt.Rows[0]["NgayKhaiGiang"].ToString());
                lop.MSoTien = double.Parse(dt.Rows[0]["SoTien"].ToString());
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            //return listLop[0];
            return lop;
        }

        public List<LopHoc_ThoiGianDTO> getListLopHocByDay(String maThu, DateTime ngayThi)
        {
            List<LopHoc_ThoiGianDTO> result = new List<LopHoc_ThoiGianDTO>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("Lop_Hoc_LIST_BY_DAY", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NgayThi", ngayThi);
                cmd.Parameters.AddWithValue("@MaThu", maThu);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LopHoc_ThoiGianDTO temp = new LopHoc_ThoiGianDTO();
                    temp.MMaLop = dt.Rows[i]["MaLop"].ToString();
                    temp.MMaPhong = dt.Rows[i]["MaPhong"].ToString();
                    temp.MMaThu = dt.Rows[i]["MaThu"].ToString();
                    temp.MMaCa = dt.Rows[i]["MaCa"].ToString();
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

        public List<LopHoc> getListLopHocWithNgayThiXL(DateTime ngayThi)
        {
            List<LopHoc> result = new List<LopHoc>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("LOP_HOC_LIST_WITH_NGAY_THI_XEP_LOP", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NgayThi", ngayThi);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LopHoc lop = new LopHoc();
                    lop.MMaLop = dt.Rows[i]["MaLop"].ToString();
                    lop.MNgayKhaiGiang = DateTime.Parse(dt.Rows[i]["NgayKhaiGiang"].ToString());
                    lop.MNgayBatDau = DateTime.Parse(dt.Rows[i]["ThoiGianBD"].ToString());
                    lop.MNgayKetThuc = DateTime.Parse(dt.Rows[i]["ThoiGianKT"].ToString());
                    lop.MSoTien = double.Parse(dt.Rows[i]["SoTien"].ToString());
                    lop.MMaGiangVien = dt.Rows[i]["MaGV"].ToString();
                    lop.MMaCTHoc = dt.Rows[i]["MaCTHoc"].ToString();
                    lop.MMaPhong = dt.Rows[i]["MaPhong"].ToString();
                    result.Add(lop);
                }
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public List<LopHoc> getListLopHocDangMo()
        {
            List<LopHoc> result = new List<LopHoc>();

            return result;
        }

        public List<ThoiGianHoc> getListLopHocByTGRanhVaCTMuonHoc(String maHV)
        {
            List<ThoiGianHoc> result = new List<ThoiGianHoc>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("LOP_HOC_LIST_BY_TGRANH_CTHOCMONGMUON", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHV", maHV);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                result = dt.AsEnumerable().Select(m =>
                    new ThoiGianHoc
                    {
                        MMaLop = m.Field<String>("MaLop"),
                        MMaThu = m.Field<String>("MaThu"),
                        MMaCa = m.Field<String>("MaCa")
                    }).ToList();
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public List<LopHoc> getListLopHocByMaGiangVien(String maGv)
        {
            List<LopHoc> list = new List<LopHoc>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("LOP_HOC_LIST_BY_MAGV", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGV", maGv);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LopHoc lop = new LopHoc();
                    lop.MMaLop = dt.Rows[i]["MaLop"].ToString();
                    lop.MNgayKhaiGiang = DateTime.Parse(dt.Rows[i]["NgayKhaiGiang"].ToString());
                    lop.MNgayBatDau = DateTime.Parse(dt.Rows[i]["ThoiGianBD"].ToString());
                    lop.MNgayKetThuc = DateTime.Parse(dt.Rows[i]["ThoiGianKT"].ToString());
                    lop.MSoTien = double.Parse(dt.Rows[i]["SoTien"].ToString());
                    lop.MMaGiangVien = dt.Rows[i]["MaGV"].ToString();
                    lop.MMaCTHoc = dt.Rows[i]["MaCTHoc"].ToString();
                    lop.MMaPhong = dt.Rows[i]["MaPhong"].ToString();
                    list.Add(lop);
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            return list;
        }
    }
}
