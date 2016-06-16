using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KetQuaThi
    {
        public KetQuaThi() {
            MSelectedMaLop = 0;
        }
        public String mMaHV;
        private String mTenHV;

        public String MTenHV
        {
            get { return mTenHV; }
            set { mTenHV = value; }
        }
        private DateTime mNgaySinh;

        public DateTime MNgaySinh
        {
            get { return mNgaySinh; }
            set { mNgaySinh = value; }
        }
        private String mGioiTinh;

        public String MGioiTinh
        {
            get { return mGioiTinh; }
            set { mGioiTinh = value; }
        }
        private String mDiaChi;

        public String MDiaChi
        {
            get { return mDiaChi; }
            set { mDiaChi = value; }
        }
        private String mSdt;

        public String MSdt
        {
            get { return mSdt; }
            set { mSdt = value; }
        }
        private String mMaCTDaHoc;

        public String MMaCTDaHoc
        {
            get { return mMaCTDaHoc; }
            set { mMaCTDaHoc = value; }
        }
        private String mMaCTMuonHoc;

        public String MMaCTMuonHoc
        {
            get { return mMaCTMuonHoc; }
            set { mMaCTMuonHoc = value; }
        }
        private String mMaTDDaHoc;

        public String MMaTDDaHoc
        {
            get { return mMaTDDaHoc; }
            set { mMaTDDaHoc = value; }
        }
        private String mMaTDMuonHoc;

        public String MMaTDMuonHoc
        {
            get { return mMaTDMuonHoc; }
            set { mMaTDMuonHoc = value; }
        }
        private String mEmail;

        public String MEmail
        {
            get { return mEmail; }
            set { mEmail = value; }
        }
        private String mMaThiXL;

        public String MMaThiXL
        {
            get { return mMaThiXL; }
            set { mMaThiXL = value; }
        }
        private float mKetQua;

        public float MKetQua
        {
            get { return mKetQua; }
            set { mKetQua = value; }
        }
        private String mChuongTrinhDeNghi;

        public String MChuongTrinhDeNghi
        {
            get { return mChuongTrinhDeNghi; }
            set { mChuongTrinhDeNghi = value; }
        }
        private String mChuongTrinhMuonHoc;

        public String MChuongTrinhMuonHoc
        {
            get { return mChuongTrinhMuonHoc; }
            set { mChuongTrinhMuonHoc = value; }
        }
        private String mMaPhong;

        public String MMaPhong
        {
            get { return mMaPhong; }
            set { mMaPhong = value; }
        }
        private String mCaThi;

        public String MCaThi
        {
            get { return mCaThi; }
            set { mCaThi = value; }
        }
        private String mMaDe;

        public String MMaDe
        {
            get { return mMaDe; }
            set { mMaDe = value; }
        }
        private DateTime mNgayThi;

        public DateTime MNgayThi
        {
            get { return mNgayThi; }
            set { mNgayThi = value; }
        }
        private List<String> mMaLopDeNghi;

        public List<String> MMaLopDeNghi
        {
            get { return mMaLopDeNghi; }
            set { mMaLopDeNghi = value; }
        }
        private int mSelectedMaLop;

        public int MSelectedMaLop
        {
            get { return mSelectedMaLop; }
            set { mSelectedMaLop = value; }
        }

    }
}
