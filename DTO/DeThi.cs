using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DeThi
    {
        String mMaDeThi;

        public DeThi()
        {
        }

        public DeThi(String maDeThi, String loaiDT, String chiTiet)
        {
            mMaDeThi = maDeThi;
            mLoaiDeThi = loaiDT;
            mChiTiet = chiTiet;
        }

        public String MMaDeThi
        {
            get { return mMaDeThi; }
            set { mMaDeThi = value; }
        }
        String mLoaiDeThi;

        public String MLoaiDeThi
        {
            get { return mLoaiDeThi; }
            set { mLoaiDeThi = value; }
        }
        String mChiTiet;

        public String MChiTiet
        {
            get { return mChiTiet; }
            set { mChiTiet = value; }
        }

    }
}
