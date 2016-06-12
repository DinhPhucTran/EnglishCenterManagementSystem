using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocVien
    {

        public HocVien()
        {
        }

        public HocVien(String maHV, String tenHV, DateTime ngaySinh, String phai, String diaChi, String email, String soDT, String maTDDaHoc, String maTDMuonHoc, String maCTDaHoc, String maCTMuonHoc)
        {
            mMaHocVien = maHV;
            mTenHocVien = tenHV;
            mNgaySinh = ngaySinh;
            mPhai = phai;
            mDiaChi = diaChi;
            mEmail = email;
            mSdt = soDT;
            mMaTrinhDoDaHoc = maTDDaHoc;
            mMaTrinhDoMuonHoc = maTDMuonHoc;
            mMaChuongTrinhDaHoc = maCTDaHoc;
            mMaChuongTrinhMuonHoc = maCTMuonHoc;
        }
        String mEmail;
        String mMaHocVien;

        public String MMaHocVien
        {
            get { return mMaHocVien; }
            set { mMaHocVien = value; }
        }
        String mTenHocVien;

        public String MTenHocVien
        {
            get { return mTenHocVien; }
            set { mTenHocVien = value; }
        }
        DateTime mNgaySinh;

        public DateTime MNgaySinh
        {
            get { return mNgaySinh; }
            set { mNgaySinh = value; }
        }
        String mPhai;

        public String MPhai
        {
            get { return mPhai; }
            set { mPhai = value; }
        }
        String mDiaChi;

        public String MDiaChi
        {
            get { return mDiaChi; }
            set { mDiaChi = value; }
        }
        String mSdt;

        public String MSdt
        {
            get { return mSdt; }
            set { mSdt = value; }
        }
        String mMaChuongTrinhDaHoc;

        public String MMaChuongTrinhDaHoc
        {
            get { return mMaChuongTrinhDaHoc; }
            set { mMaChuongTrinhDaHoc = value; }
        }
        String mMaChuongTrinhMuonHoc;

        public String MMaChuongTrinhMuonHoc
        {
            get { return mMaChuongTrinhMuonHoc; }
            set { mMaChuongTrinhMuonHoc = value; }
        }
        String mMaTrinhDoDaHoc;

        public String MMaTrinhDoDaHoc
        {
            get { return mMaTrinhDoDaHoc; }
            set { mMaTrinhDoDaHoc = value; }
        }
        String mMaTrinhDoMuonHoc;

        public String MMaTrinhDoMuonHoc
        {
            get { return mMaTrinhDoMuonHoc; }
            set { mMaTrinhDoMuonHoc = value; }
        }

        public string MEmail
        {
            get
            {
                return mEmail;
            }

            set
            {
                mEmail = value;
            }
        }

        public HocVien(String maHV, String tenHV, DateTime ngaySinh, String phai, String diaChi, String email, String soDT)
        {
            mMaHocVien = maHV;
            mTenHocVien = tenHV;
            mNgaySinh = ngaySinh;
            mPhai = phai;
            mDiaChi = diaChi;
            mEmail = email;
            mSdt = soDT;
        }
    }
}
