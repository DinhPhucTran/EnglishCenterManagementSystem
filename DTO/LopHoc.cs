using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LopHoc
    {
        private String mMaLop;
        private DateTime mNgayKhaiGiang;
        private DateTime mNgayBatDau;
        private DateTime mNgayKetThuc;
        private double mSoTien;
        private String mMaGiangVien;
        private String mMaCTHoc;
        private String mMaPhong;

        public LopHoc()
        {
        }

        public LopHoc(String maLop, DateTime ngayKhaiGiang, DateTime ngayBD, DateTime ngayKT,
            double soTien, String maGiangVien, String maCTHoc, String maPhong)
        {
            mMaLop = maLop;
            mNgayKhaiGiang = ngayKhaiGiang;
            mNgayBatDau = ngayBD;
            mNgayKetThuc = ngayKT;
            mSoTien = soTien;
            mMaGiangVien = maGiangVien;
            mMaCTHoc = maCTHoc;
            mMaPhong = maPhong;
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

        public string MMaCTHoc
        {
            get
            {
                return mMaCTHoc;
            }

            set
            {
                mMaCTHoc = value;
            }
        }

        public string MMaGiangVien
        {
            get
            {
                return mMaGiangVien;
            }

            set
            {
                mMaGiangVien = value;
            }
        }

        public double MSoTien
        {
            get
            {
                return mSoTien;
            }

            set
            {
                mSoTien = value;
            }
        }

        public DateTime MNgayKetThuc
        {
            get
            {
                return mNgayKetThuc;
            }

            set
            {
                mNgayKetThuc = value;
            }
        }

        public DateTime MNgayBatDau
        {
            get
            {
                return mNgayBatDau;
            }

            set
            {
                mNgayBatDau = value;
            }
        }

        public DateTime MNgayKhaiGiang
        {
            get
            {
                return mNgayKhaiGiang;
            }

            set
            {
                mNgayKhaiGiang = value;
            }
        }

        public string MMaLop
        {
            get
            {
                return mMaLop;
            }

            set
            {
                mMaLop = value;
            }
        }
    }
}
