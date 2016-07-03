using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietThiXepLop_HocVien
    {
        private ChiTietThiXepLop mCt;
        private HocVien mHv;

        public ChiTietThiXepLop_HocVien(ChiTietThiXepLop ct, HocVien hv)
        {
            mCt = ct;
            mHv = hv;
        }

        public ChiTietThiXepLop ChiTietThiXepLop
        {
            get { return mCt; }
            set { mCt = value; }
        }

        public HocVien HocVien
        {
            get { return mHv; }
            set { mHv = value; }
        }


    }
}
