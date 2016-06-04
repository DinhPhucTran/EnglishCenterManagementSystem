using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThiXepLop
    {
        private String mMaThiXL;
        private String mMaPhong;
        private String mCaThi;
        private String mDeThi;
        private DateTime mNgayThi;

        public ThiXepLop()
        {
        }

        public ThiXepLop(String maThiXL, String maPhong, String caThi, String deThi, DateTime ngayThi)
        {
            mMaThiXL = maThiXL;
            mMaPhong = maPhong;
            mCaThi = caThi;
            mDeThi = deThi;
            mNgayThi = ngayThi;
        }

        public String MMaThiXL
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

        public String MMaPhong
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

        public String MCaThi
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

        public String MDeThi
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
