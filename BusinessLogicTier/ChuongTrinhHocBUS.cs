using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class ChuongTrinhHocBUS
    {
        ChuongTrinhHocDAO mChuongTrinhHocDAO;

        public ChuongTrinhHocBUS()
        {
            mChuongTrinhHocDAO = new ChuongTrinhHocDAO();
        }

        public List<ChuongTrinhHoc> getListChuongTrinhHoc()
        {
            return new ChuongTrinhHocDAO().getListChuongTrinhHoc();
        }

        public bool themChuongTrinhHoc(ChuongTrinhHoc cth)
        {
            ChuongTrinhHocDAO cthDao = new ChuongTrinhHocDAO();
            return cthDao.themChuongTrinhHoc(cth);
            
        }

        public bool xoaChuongTrinhHoc(String ma)
        {
            return new ChuongTrinhHocDAO().xoaChuongTrinhHoc(ma);
        }
        public bool suaChuongTrinhHoc(ChuongTrinhHoc cth)
        {
            ChuongTrinhHocDAO cthDao = new ChuongTrinhHocDAO();
            return cthDao.suaChuongTrinhHoc(cth);
        }

        public String getMaCTFromTenCT(String tenCT)
        {
            return mChuongTrinhHocDAO.getMaChuongTrinhHocFromTen(tenCT);
        }
    }
}
