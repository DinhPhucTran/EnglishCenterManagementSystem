using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThiXepLop
    {
        String mMaThiXL;
        String mMaPhong;
        String mCaThi;
        String mDeThi;
        DateTime mNgayThi;

        public string MMaThiXL
        {
            get
            {
                return mMaThiXL;
            }

            set
            {
                mMaThiXL = value;
            }
        }

        public string MMaPhong
        {
            get
            {
                return mMaPhong;
            }

            set
            {
                mMaPhong = value;
            }
        }

        public string MCaThi
        {
            get
            {
                return mCaThi;
            }

            set
            {
                mCaThi = value;
            }
        }

        public string MDeThi
        {
            get
            {
                return mDeThi;
            }

            set
            {
                mDeThi = value;
            }
        }

        public DateTime MNgayThi
        {
            get
            {
                return mNgayThi;
            }

            set
            {
                mNgayThi = value;
            }
        }
    }
}
