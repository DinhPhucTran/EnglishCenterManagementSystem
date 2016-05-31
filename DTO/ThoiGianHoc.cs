using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThoiGianHoc
    {
        private String mMaLop;
        private String mMaThu;
        private String mMaCa;

        public ThoiGianHoc()
        {
        }

        public ThoiGianHoc(String maLop, String maThu, String maCa)
        {
            mMaLop = maLop;
            mMaThu = maThu;
            mMaCa = maCa;
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

        public string MMaThu
        {
            get
            {
                return mMaThu;
            }

            set
            {
                mMaThu = value;
            }
        }

        public string MMaCa
        {
            get
            {
                return mMaCa;
            }

            set
            {
                mMaCa = value;
            }
        }

        public bool kiemTraTrungThoiGian(ThoiGianHoc tgh)
        {
            return (mMaThu.Equals(tgh.MMaThu) && mMaCa.Equals(tgh.MMaCa));
        }
    }
}
