using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuThuHocPhi
    {
        private String mMaPhieuThu;
        private String mMaLopHoc;
        private String mMaHocVien;
        private DateTime mNgayLap;
        private double mSoTienDong;

        public PhieuThuHocPhi()
        { }

        public PhieuThuHocPhi(String maPT, String maLop, String maHV, DateTime ngayLap, double soTienDong)
        {
            mMaPhieuThu = maPT;
            mMaLopHoc = maLop;
            mMaHocVien = maHV;
            mNgayLap = ngayLap;
            mSoTienDong = soTienDong;
        }

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
