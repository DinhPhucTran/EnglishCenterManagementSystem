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
    }
}
