using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Phong
    {
        private String mMaPhong;
        private String mTenPhong;

        public Phong()
        {
        }

        public Phong(String maPhong, String tenPhong)
        {
            mMaPhong = maPhong;
            mTenPhong = tenPhong;
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

        public string MTenPhong
        {
            get
            {
                return mTenPhong;
            }

            set
            {
                mTenPhong = value;
            }
        }
    }
}
