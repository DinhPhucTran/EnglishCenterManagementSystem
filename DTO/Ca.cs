using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ca
    {
        public Ca()
        {
        }

        public Ca(String maCa, DateTime thoiGianBD, DateTime thoiGianKT)
        {
            mMaCa = maCa;
            mThoiGianBatDau = thoiGianBD;
            mThoiGianKetThuc = thoiGianKT;
        }

        String mMaCa;

        public String MMaCa
        {
            get { return mMaCa; }
            set { mMaCa = value; }
        }
        DateTime mThoiGianBatDau;

        public DateTime MThoiGianBatDau
        {
            get { return mThoiGianBatDau; }
            set { mThoiGianBatDau = value; }
        }
        DateTime mThoiGianKetThuc;

        public DateTime MThoiGianKetThuc
        {
            get { return mThoiGianKetThuc; }
            set { mThoiGianKetThuc = value; }
        }

        public String toStringTgBD_TgKT()
        {
            return mThoiGianBatDau.Hour + ":" + mThoiGianBatDau.Minute + " - " +
                   mThoiGianKetThuc.Hour + ":" + mThoiGianKetThuc.Minute;
        }

    }
}
