using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThiXepLop_Ca
    {
        private ThiXepLop mThiXL;
        private Ca mCa;

        public ThiXepLop_Ca()
        {

        }

        public ThiXepLop_Ca(ThiXepLop xl, Ca ca)
        {
            mThiXL = xl;
            mCa = ca;
        }

        public ThiXepLop ThiXL
        {
            get { return mThiXL; }
            set { mThiXL = value; }
        }

        public Ca Ca
        {
            get { return mCa; }
            set { mCa = value; }
        }

        public String StringThoiGian
        {
            get { return mCa.MThoiGianBatDau.ToShortTimeString() + " - " + mCa.MThoiGianKetThuc.ToShortTimeString(); }
        }

        public String StringNgayThi
        {
            get { return mThiXL.MNgayThi.ToShortDateString(); }
        }
    }
}
