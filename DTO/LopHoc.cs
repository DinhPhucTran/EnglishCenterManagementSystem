using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LopHoc
    {
        String mMaLop;
        DateTime mNgayKhaiGiang;
        DateTime mNgayBatDau;
        DateTime mNgayKetThuc;
        double mSoTien;
        String mMaGiangVien;
        String mMaCTHoc;
        String mMaPhong;

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
