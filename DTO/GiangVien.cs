using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GiangVien
    {
        public GiangVien()
        {
        }

        public GiangVien(String maGV, String tenGV, String diaChi, String soDT)
        {
            mMaGiangVien = maGV;
            mTenGiangVien = tenGV;
            mDiaChi = diaChi;
            mSoDienThoai = soDT;
        }

        String mMaGiangVien;

        public String MMaGiangVien
        {
            get { return mMaGiangVien; }
            set { mMaGiangVien = value; }
        }
        String mTenGiangVien;

        public String MTenGiangVien
        {
            get { return mTenGiangVien; }
            set { mTenGiangVien = value; }
        }
        String mDiaChi;

        public String MDiaChi
        {
            get { return mDiaChi; }
            set { mDiaChi = value; }
        }
        String mSoDienThoai;

        public String MSoDienThoai
        {
            get { return mSoDienThoai; }
            set { mSoDienThoai = value; }
        }

    }
}
