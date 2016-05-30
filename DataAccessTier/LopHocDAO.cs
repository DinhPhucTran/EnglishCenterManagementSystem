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
    }
}
