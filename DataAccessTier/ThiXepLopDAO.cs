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
    public class ThiXepLopDAO:DBConnection
    {
        public ThiXepLopDAO() { }

        public List<ThiXepLop> getAllThiXLByThoiGianRanh(String maHV)
        {
            List<ThiXepLop> result = new List<ThiXepLop>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("THI_XEP_LOP_BY_TGRANH", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHV", maHV);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                result = dt.AsEnumerable().Select(m =>
                    new ThiXepLop
                    {
                        MMaThiXL = m.Field<String>("MaThiXL"),
                        MMaPhong = m.Field<String>("MaPhong"),
                        MCaThi = m.Field<String>("CaThi"),
                        MDeThi = m.Field<String>("MaDeThi"),
                        MNgayThi = m.Field<DateTime>("NgayThi")
                    }
                ).ToList();
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public List<ThiXepLop> getListThiXepLopByTime(ThiXepLop txl)
        {
            List<ThiXepLop> ds = new List<ThiXepLop>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("THI_XEP_LOP_LIST_BY_DATE", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaPhong", txl.MMaPhong);
                cmd.Parameters.AddWithValue("@NgayThi", txl.MNgayThi);
                //cmd.Parameters.Add("@NgayThi", SqlDbType.SmallDateTime).Value = txl.MNgayThi;
                cmd.Parameters.AddWithValue("@CaThi", txl.MCaThi);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ThiXepLop temp = new ThiXepLop( dt.Rows[i]["MaThiXL"].ToString(),
                                                    dt.Rows[i]["MaPhong"].ToString(),
                                                    dt.Rows[i]["CaThi"].ToString(), 
                                                    dt.Rows[i]["MaDeThi"].ToString(),
                                                    DateTime.Parse(dt.Rows[i]["NgayThi"].ToString()));
                    ds.Add(temp);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message.ToString());
            }
            return ds;
        }

        public List<ThiXepLop> getListThiXepLop()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("THI_XEP_LOP_LIST", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<ThiXepLop> list = new List<ThiXepLop>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ThiXepLop txl = new ThiXepLop();
                    txl.MMaThiXL = dt.Rows[i][0].ToString();
                    txl.MMaPhong = dt.Rows[i][1].ToString();
                    txl.MCaThi = dt.Rows[i][2].ToString();
                    txl.MDeThi = dt.Rows[i][3].ToString();
                    txl.MNgayThi = DateTime.Parse(dt.Rows[i][4].ToString());
                    list.Add(txl);
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

        public List<ThiXepLop> getAllThiXepLopByDay(DateTime ngayThi)
        {
            List<ThiXepLop> result = new List<ThiXepLop>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("THI_XEP_LOP_LIST_BY_DAY", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NgayThi", ngayThi);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ThiXepLop temp = new ThiXepLop();
                    temp.MMaThiXL = dt.Rows[i]["MaThiXL"].ToString();
                    temp.MMaPhong = dt.Rows[i]["MaPhong"].ToString();
                    temp.MDeThi = dt.Rows[i]["MaDeThi"].ToString();
                    temp.MNgayThi = DateTime.Parse(dt.Rows[i]["NgayThi"].ToString());
                    temp.MCaThi = dt.Rows[i]["CaThi"].ToString();
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

        public bool themThiXepLop(ThiXepLop txl)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("THI_XEP_LOP_INSERT", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaThiXL", txl.MMaThiXL);
                command.Parameters.AddWithValue("@MaPhong", txl.MMaPhong);
                command.Parameters.AddWithValue("@CaThi", txl.MCaThi);
                command.Parameters.AddWithValue("@MaDeThi", txl.MDeThi);
                command.Parameters.AddWithValue("@NgayThi", txl.MNgayThi);
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

        public bool suaThiXepLop(ThiXepLop txl)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("THI_XEP_LOP_UPDATE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaThiXL", txl.MMaThiXL);
                command.Parameters.AddWithValue("@MaPhong", txl.MMaPhong);
                command.Parameters.AddWithValue("@CaThi", txl.MCaThi);
                command.Parameters.AddWithValue("@MaDeThi", txl.MDeThi);
                command.Parameters.AddWithValue("@NgayThi", txl.MNgayThi);
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

        public List<LopHoc_ThoiGianDTO> layThongTinCacLopTaiThoiDiemXepLop(ThiXepLop txl)
        {
            List<LopHoc_ThoiGianDTO> ds = new List<LopHoc_ThoiGianDTO>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("LOP_HOC_LIST_TO_ADD_THIXL", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                cmd.Parameters.AddWithValue("@MaPhong", txl.MMaPhong);
                cmd.Parameters.AddWithValue("@NgayThi", txl.MNgayThi);
                cmd.Parameters.AddWithValue("@MaCa", txl.MCaThi);
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var temp = new LopHoc_ThoiGianDTO();
                    temp.MMaLop = dt.Rows[i]["MaLop"].ToString();
                    temp.MMaPhong = dt.Rows[i]["MaPhong"].ToString();
                    temp.MMaThu = dt.Rows[i]["MaThu"].ToString();
                    temp.MMaCa = dt.Rows[i]["MaCa"].ToString();
                    ds.Add(temp);
                }
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message.ToString());
            }
            return ds;
        }

        public bool xoaThiXepLop(String maTxl)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("THI_XEP_LOP_INSERT", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaThiXL", maTxl);
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

        public List<ThiXepLop> getTXLNow()
        {
            List<ThiXepLop> result = new List<ThiXepLop>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("THI_XEP_LOP_NOW", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                result = dt.AsEnumerable().Select(m =>
                    new ThiXepLop
                    {
                        MMaThiXL = m.Field<String>("MaThiXL"),
                        MMaPhong = m.Field<String>("MaPhong"),
                        MCaThi = m.Field<String>("CaThi"),
                        MDeThi = m.Field<String>("MaDeThi"),
                        MNgayThi = m.Field<DateTime>("NgayThi")
                    }).ToList();
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public ThiXepLop selectThiXLByMaTXL(String maTXL)
        {
            ThiXepLop result = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("THI_XEP_LOP_SELECT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaThiXL", maTXL);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                result = dt.AsEnumerable().Select(m =>
                    new ThiXepLop
                    {
                        MMaThiXL = m.Field<String>("MaThiXL"),
                        MMaPhong = m.Field<String>("MaPhong"),
                        MCaThi = m.Field<String>("CaThi"),
                        MDeThi = m.Field<String>("MaDeThi"),
                        MNgayThi = m.Field<DateTime>("NgayThi")
                    }).First();
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
            }
            return result;
        }

        public List<DateTime> getKhoangThoiGianThiXL(DateTime currentTime){
            List<DateTime> khoangTG = new List<DateTime>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("GET_KHOANG_THOI_GIAN_THI_XL", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CurrentTime", currentTime);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                khoangTG.Add(DateTime.Parse(dt.Rows[0][0].ToString()));
                khoangTG.Add(DateTime.Parse(dt.Rows[0][1].ToString()));
                
            }
            catch (Exception e)
            {
                connection.Close();
                System.Console.WriteLine(e.Message);
                //throw;
            }
            return khoangTG;
        }
    }
}
