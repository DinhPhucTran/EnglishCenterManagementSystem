using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessTier
{
    public class PhieuThuHocPhiDAO:DBConnection
    {
        public PhieuThuHocPhiDAO() { }
        public List<PhieuThuHocPhi> getListPhieuThu()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("PHIEU_THU_HOP_PHI_LIST", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<PhieuThuHocPhi> list = new List<PhieuThuHocPhi>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PhieuThuHocPhi phieuThu = new PhieuThuHocPhi();
                    phieuThu.MMaPhieuThu = dt.Rows[i][0].ToString();
                    phieuThu.MMaLopHoc = dt.Rows[i][1].ToString();
                    phieuThu.MMaHocVien = dt.Rows[i][2].ToString();
                    phieuThu.MNgayLap = DateTime.Parse(dt.Rows[i][3].ToString());
                    phieuThu.MSoTienDong = double.Parse(dt.Rows[i][4].ToString());
                    list.Add(phieuThu);
                }
                connection.Close();
                return list;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex);
                return null;
            }
        }

        public bool insertPhieuThu(PhieuThuHocPhi phieu)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("PHIEU_THU_HOP_PHI_INSERT", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaPhieuThu", phieu.MMaPhieuThu);
                command.Parameters.AddWithValue("@MaLopHoc", phieu.MMaLopHoc);
                command.Parameters.AddWithValue("@MaHocVien", phieu.MMaHocVien);
                //command.Parameters.AddWithValue("@NgayLap", phieu.MNgayLap.ToString());
                command.Parameters.Add("@NgayLap", SqlDbType.Date).Value = phieu.MNgayLap.ToString("yyyy-MM-dd h:m:s");
                command.Parameters.AddWithValue("@SoTienDong", phieu.MSoTienDong);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine(ex);
                //throw;
            }
            return false;
        }

        public bool updatePhieuThu(PhieuThuHocPhi phieu)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("PHIEU_THU_HOP_PHI_UPDATE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaPhieuThu", phieu.MMaPhieuThu);
                command.Parameters.AddWithValue("@MaLopHoc", phieu.MMaLopHoc);
                command.Parameters.AddWithValue("@MaHocVien", phieu.MMaHocVien);
                command.Parameters.AddWithValue("@NgayLap", phieu.MNgayLap.ToString());
                command.Parameters.AddWithValue("@SoTienDong", phieu.MSoTienDong.ToString());
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

        public bool deletePhieuThu(String maPhieu)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("PHIEU_THU_HOP_PHI_DELETE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaPhieuThu", maPhieu);
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

        public bool updateSoTienNo(string maHv, string maLop, double soTien)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("update_so_tien_no", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@maLop", maLop);
                command.Parameters.AddWithValue("@maHV", maHv);
                command.Parameters.AddWithValue("@soTien", soTien);
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
