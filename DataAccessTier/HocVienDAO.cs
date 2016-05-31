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
                cmd.Parameters.AddWithValue("@MaCTDaHoc", hv.MMaChuongTrinhDaHoc);
                cmd.Parameters.AddWithValue("@MaCTMuonHoc", hv.MMaChuongTrinhMuonHoc);
                cmd.Parameters.AddWithValue("@MaTDDaHoc", hv.MMaTrinhDoDaHoc);
                cmd.Parameters.AddWithValue("@MaTDMuonHoc", hv.MMaTrinhDoMuonHoc);
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
    }
}
