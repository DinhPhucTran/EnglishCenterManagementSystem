using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessTier;
using DTO;

namespace BusinessLogicTier
{
    public class ThoiGianHocBUS
    {
        ThoiGianHocDAO mThoiGianHocDAO;

        public ThoiGianHocBUS()
        {
            mThoiGianHocDAO = new ThoiGianHocDAO();
        }

        public bool insertThoiGianHoc(ThoiGianHoc tgHoc)
        {
            return mThoiGianHocDAO.insertThoiGianHoc(tgHoc);
        }
    }
}
