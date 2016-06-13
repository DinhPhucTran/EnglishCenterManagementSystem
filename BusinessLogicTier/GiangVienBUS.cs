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
            int maxIdGV = this.getMaGiangVienMax();
            if (maxIdGV <= 0)
            {
                return false;
            }
            gv.MMaGiangVien = (maxIdGV + 1).ToString();
            return mGiangVienDAO.insertGiangVien(gv);
        }

        public bool deleteGiangVien(String maGV)
        {
            return mGiangVienDAO.deleteGiangVien(maGV);
        }

        public int getMaGiangVienMax()
        {
            int result = 0;
            try
            {
                int.TryParse(mGiangVienDAO.getMaxIdGiangVien(), out result);
            }
            catch (Exception)
            {
                //throw;
            }
            return result;
        }

        public GiangVien selectGiangVien(String maGV)
        {
            return mGiangVienDAO.selectGiangVien(maGV);
        }

        public bool updateGiangVien(GiangVien gv)
        {
            return mGiangVienDAO.updateGiangVien(gv);
        }
    }
}
