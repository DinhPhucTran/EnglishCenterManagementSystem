using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChuongTrinhHoc
    {
        String mMaChuongTrinhHoc;

        public String MMaChuongTrinhHoc
        {
            get { return mMaChuongTrinhHoc; }
            set { mMaChuongTrinhHoc = value; }
        }
        String mTenChuongTrinhHoc;

        public String MTenChuongTrinhHoc
        {
            get { return mTenChuongTrinhHoc; }
            set { mTenChuongTrinhHoc = value; }
        }
        String mMaTrinhDo;

        public String MMaTrinhDo
        {
            get { return mMaTrinhDo; }
            set { mMaTrinhDo = value; }
        }
        float mDiemSoToiThieu;

        public float MDiemSoToiThieu
        {
            get { return mDiemSoToiThieu; }
            set { mDiemSoToiThieu = value; }
        }
        float mDiemSoToiDa;

        public float MDiemSoToiDa
        {
            get { return mDiemSoToiDa; }
            set { mDiemSoToiDa = value; }
        }

        public override string ToString()
        {
            return mTenChuongTrinhHoc;
        }
    }
}
