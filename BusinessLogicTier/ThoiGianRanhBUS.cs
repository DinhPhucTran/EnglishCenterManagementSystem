using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessTier;
using DTO;

namespace BusinessLogicTier
{
    public class ThoiGianRanhBUS
    {
        ThoiGianRanhDAO mThoiGianRanhDAO;

        public ThoiGianRanhBUS()
        {
            mThoiGianRanhDAO = new ThoiGianRanhDAO();
        }

        public bool insertThoiGianRanh(ThoiGianRanh tgRanh)
        {
            return mThoiGianRanhDAO.insertThoiGianRanh(tgRanh);
        }
    }
}