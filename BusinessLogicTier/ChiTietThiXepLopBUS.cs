using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class ChiTietThiXepLopBUS
    {
        public ChiTietThiXepLopBUS()
        { }

        public List<ChiTietThiXepLop> getAllChiTietTXL()
        {
            return new ChiTietThiXepLopDAO().getAllChiTietTXL();
        }

        public bool updateKetQuaThi(List<ChiTietThiXepLop> ds)
        {
            return new ChiTietThiXepLopDAO().updateKetQuaThi(ds);
        }

        public List<ChiTietThiXepLop> getChiTietTXLByMaTXL(String maTXL)
        {
            return new ChiTietThiXepLopDAO().getChiTietTXLByMaTXL(maTXL);
        }
    }
}
