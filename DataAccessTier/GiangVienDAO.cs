using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using System.Data.SqlClient;


namespace DataAccessTier
{
    public class GiangVienDAO : DBConnection
    {
        public GiangVienDAO()
        {
        }

        public List<GiangVien> getListGiangVien()
        {
            List<GiangVien> result = new List<GiangVien>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("GIANG_VIEN_LIST", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GiangVien temp = new GiangVien(dt.Rows[i]["MaGiangVien"].ToString(),
                                                    dt.Rows[i]["TenGiangVien"].ToString(),
                                                    dt.Rows[i]["DiaChi"].ToString(),
                                                    dt.Rows[i]["SoDT"].ToString());
                    result.Add(temp);
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            return result;
        }

        public bool insertGiangVien(GiangVien gv)
        {
            bool result = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("GIANG_VIEN_INSERT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGiangVien", gv.MMaGiangVien);
                cmd.Parameters.AddWithValue("@TenGiangVien", gv.MTenGiangVien);
                cmd.Parameters.AddWithValue("@DiaChi", gv.MDiaChi);
                cmd.Parameters.AddWithValue("@SoDT", gv.MSoDienThoai);
                cmd.ExecuteNonQuery();
                result = true;
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            return result;
        }

        public bool deleteGiangVien(String maGV)
        {
            bool result = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("GIANG_VIEN_DELETE", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGiangVien", maGV);
                cmd.ExecuteNonQuery();
                result = true;
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            return result;
        }

        public String getMaxIdGiangVien()
        {
            String result = "0";
            List<String> listMaGV = new List<string>();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("GIANG_VIEN_LIST_MAGV", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listMaGV.Add(dt.Rows[i]["MaGiangVien"].ToString());
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            if (listMaGV.Count != 0)
            {
                return listMaGV.Select(v => int.Parse(v)).Max().ToString();
            }
            return result;
        }

        public GiangVien selectGiangVien(String maGV)
        {
            GiangVien gv = new GiangVien();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                SqlCommand cmd = new SqlCommand("GIANG_VIEN_SELECT", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGiangVien", maGV);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gv.MMaGiangVien = maGV;
                gv.MTenGiangVien = dt.Rows[0]["TenGiangVien"].ToString();
                gv.MDiaChi = dt.Rows[0]["DiaChi"].ToString();
                gv.MSoDienThoai = dt.Rows[0]["SoDT"].ToString();
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
            }
            return gv;
        }

        public bool updateGiangVien(GiangVien gv)
        {
            bool result = false;
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("GIANG_VIEN_UPDATE", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGiangVien", gv.MMaGiangVien);
                cmd.Parameters.AddWithValue("@TenGiangVien", gv.MTenGiangVien);
                cmd.Parameters.AddWithValue("@DiaChi", gv.MDiaChi);
                cmd.Parameters.AddWithValue("@SoDT", gv.MSoDienThoai);
                cmd.ExecuteNonQuery();
                result = true;
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            return result;
        }
    }
}
