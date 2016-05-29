using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class ThiXepLopBUS 
    {
        ThiXepLopDAO mThiXepLop;
        public ThiXepLopBUS() {
            mThiXepLop = new ThiXepLopDAO();
        }
        public List<ThiXepLop> getListThiXepLop()
        {
            return mThiXepLop.getListThiXepLop();
        }

        //return value = 0, da ton tai
        // = 1 succses
        // = 2 failed
        public int themThiXepLop(ThiXepLop txl){
            List<ThiXepLop> list = mThiXepLop.getListThiXepLop();
            int max = 0;
            foreach (ThiXepLop t in list)
            {
                if (max < int.Parse(t.MMaPhong))
                {
                    max = int.Parse(t.MMaPhong);
                }
                if (t.MCaThi.Equals(txl.MCaThi) && t.MDeThi.Equals(txl.MDeThi) && t.MMaPhong.Equals(txl.MMaPhong) && t.MNgayThi.Equals(txl.MNgayThi))
                {
                    return 0;
                }
            }
            txl.MMaThiXL = (max + 1).ToString();
            return mThiXepLop.themThiXepLop(txl)?1:2;
        }
    }
}
