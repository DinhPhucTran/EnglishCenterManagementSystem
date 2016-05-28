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
    public class ChuongTrinhHocDAO :DBConnection
    {
        public ChuongTrinhHocDAO() :base()
        {

        }

        public bool themChuongTrinhHoc(ChuongTrinhHoc cth)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand command = new SqlCommand("CHUONG_TRINH_HOC_INSERT", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MaCTHoc", cth.MMaChuongTrinhHoc);
                command.Parameters.AddWithValue("@TenCTHoc", cth.MTenChuongTrinhHoc);
                command.Parameters.AddWithValue("@MaTrinhDo", cth.MMaTrinhDo);
                command.Parameters.AddWithValue("@DiemSoToiThieu", cth.MDiemSoToiThieu);
                command.Parameters.AddWithValue("@DiemSoToiDa", cth.MDiemSoToiDa);
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

        public List<ChuongTrinhHoc> getListChuongTrinhHoc()
        {
            try
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("CHUONG_TRINH_HOC_LIST", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<ChuongTrinhHoc> list = new List<ChuongTrinhHoc>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChuongTrinhHoc cth = new ChuongTrinhHoc();
                    cth.MMaChuongTrinhHoc = dt.Rows[i][0].ToString();
                    cth.MTenChuongTrinhHoc = dt.Rows[i][1].ToString();
                    cth.MMaTrinhDo = dt.Rows[i][2].ToString();
                    cth.MDiemSoToiThieu = float.Parse(dt.Rows[i][3].ToString());
                    cth.MDiemSoToiDa = float.Parse(dt.Rows[i][4].ToString());
                    list.Add(cth);
                }
                connection.Close();
                return list;
            }
            catch(Exception)
            {
                connection.Close();
                return null;
            }
            
        }
    }
}
