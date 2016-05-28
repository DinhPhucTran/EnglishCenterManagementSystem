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
        public List<ChuongTrinhHoc> getListChuongTrinhHoc()
        {
            return new ChuongTrinhHocDAO().getListChuongTrinhHoc();
        }

        public bool themChuongTrinhHoc(ChuongTrinhHoc cth)
        {
            ChuongTrinhHocDAO cthDao = new ChuongTrinhHocDAO();
            return cthDao.themChuongTrinhHoc(cth);
            
        }
    }
}
