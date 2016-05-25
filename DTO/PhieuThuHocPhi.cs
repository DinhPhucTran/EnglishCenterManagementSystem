using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class PhieuThuHocPhi
    {
        String mMaPhieuThu;
        String mMaLopHoc;
        String mMaHocVien;
        DateTime mNgayLap;
        double mSoTienDong;

        public string MMaPhieuThu
        {
            get
            {
                return mMaPhieuThu;
            }

            set
            {
                mMaPhieuThu = value;
            }
        }

        public string MMaLopHoc
        {
            get
            {
                return mMaLopHoc;
            }

            set
            {
                mMaLopHoc = value;
            }
        }

        public string MMaHocVien
        {
            get
            {
                return mMaHocVien;
            }

            set
            {
                mMaHocVien = value;
            }
        }

        public DateTime MNgayLap
        {
            get
            {
                return mNgayLap;
            }

            set
            {
                mNgayLap = value;
            }
        }

        public double MSoTienDong
        {
            get
            {
                return mSoTienDong;
            }

            set
            {
                mSoTienDong = value;
            }
        }
    }
}
