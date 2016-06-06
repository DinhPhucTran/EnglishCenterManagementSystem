using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietThiXepLop
    {
        public ChiTietThiXepLop()
        { }

        public ChiTietThiXepLop(String maThiXepLop, String maHV, float ketQuaThi, String maCT_TrungTamDeNghi, String maCT_HvMongMuon)
        {
            mMaThiXepLop = maThiXepLop;
            mMaHocVien = maHV;
            mKetQuaThi = ketQuaThi;
            mChuongTrinhDeNghi = maCT_TrungTamDeNghi;
            mChuongTrinhMongMuon = maCT_HvMongMuon;
        }

        String mMaThiXepLop;

        public String MMaThiXepLop
        {
            get { return mMaThiXepLop; }
            set { mMaThiXepLop = value; }
        }
        String mMaHocVien;

        public String MMaHocVien
        {
            get { return mMaHocVien; }
            set { mMaHocVien = value; }
        }
        float mKetQuaThi;

        public float MKetQuaThi
        {
            get { return mKetQuaThi; }
            set { mKetQuaThi = value; }
        }
        String mChuongTrinhDeNghi;

        public String MChuongTrinhDeNghi
        {
            get { return mChuongTrinhDeNghi; }
            set { mChuongTrinhDeNghi = value; }
        }
        String mChuongTrinhMongMuon;

        public String MChuongTrinhMongMuon
        {
            get { return mChuongTrinhMongMuon; }
            set { mChuongTrinhMongMuon = value; }
        }


    }
}
