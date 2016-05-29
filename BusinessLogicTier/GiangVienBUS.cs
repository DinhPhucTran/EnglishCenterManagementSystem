using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class GiangVienBUS
    {
        GiangVienDAO mGiangVienDAO;

        public GiangVienBUS()
        {
            mGiangVienDAO = new GiangVienDAO();
        }

        public List<GiangVien> getListGiangVien()
        {
            return mGiangVienDAO.getListGiangVien();
        }

        public bool insertGiangVien(GiangVien gv)
        {
            return mGiangVienDAO.insertGiangVien(gv);
        }

        public bool deleteGiangVien(String maGV)
        {
            return mGiangVienDAO.deleteGiangVien(maGV);
        }

        public int getMaGiangVienMax()
        {
            return int.Parse(mGiangVienDAO.getMaxIdGiangVien());
        }
    }
}
