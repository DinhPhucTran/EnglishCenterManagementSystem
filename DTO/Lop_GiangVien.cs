using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Lop_GiangVien
    {
        private LopHoc mLop;
        private GiangVien mGiangVien;

        public Lop_GiangVien() { }
        public Lop_GiangVien(LopHoc lop, GiangVien gv)
        {
            mLop = lop;
            mGiangVien = gv;
        }

        public LopHoc Lop
        {
            get { return mLop; }
            set { mLop = value; }
        }

        public GiangVien GiangVien
        {
            get { return mGiangVien; }
            set { mGiangVien = value; }
        }

        public String TenGiangVien
        {
            get { return mGiangVien.MTenGiangVien; }
        }

        public String StringNgayBD
        {
            get { return mLop.MNgayBatDau.ToShortDateString(); }
        }

        public string StringNgayKT
        {
            get { return mLop.MNgayKetThuc.ToShortDateString(); }
        }

        public string StringNgayKhaiGiang
        {
            get { return mLop.MNgayKhaiGiang.ToShortDateString(); }
        }
    }
}
