using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ca
    {
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

    }
}
