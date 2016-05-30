using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class ThuBUS
    {
        ThuDAO mThuDAO;

        public ThuBUS()
        {
            mThuDAO = new ThuDAO();
        }

        public List<Thu> getAllThu()
        {
            return mThuDAO.getAllThu();
        }
    }
}
