using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietLopHoc
    {
        String mMaLopHoc;

        public String MMaLopHoc
        {
            get { return mMaLopHoc; }
            set { mMaLopHoc = value; }
        }
        String mMaHocVien;

     

        public String MMaHocVien
        {
            get { return mMaHocVien; }
            set { mMaHocVien = value; }
        }
        int mTinhTrangDongHocPhi;

        public int MTinhTrangDongHocPhi
        {
            get { return mTinhTrangDongHocPhi; }
            set { mTinhTrangDongHocPhi = value; }
        }
        float mKetQuaThi;

        public float MKetQuaThi
        {
            get { return mKetQuaThi; }
            set { mKetQuaThi = value; }
        }

        double mSoTienNo;

        public double MSoTienNo
        {
            get { return mSoTienNo; }
            set { mSoTienNo = value; }
        }

    }
}
