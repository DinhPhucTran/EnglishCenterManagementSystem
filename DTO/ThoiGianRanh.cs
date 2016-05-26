using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThoiGianRanh
    {
        private String mMaHV;
        private String mMaThu;
        private String mMaCa;

        public ThoiGianRanh()
        {
        }

        public ThoiGianRanh(String maHV, String maThu, String maCa)
        {
            mMaHV = maHV;
            mMaThu = maThu;
            mMaCa = maCa;
        }

        public string MMaHV
        {
            get
            {
                return mMaHV;
            }

            set
            {
                mMaHV = value;
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
    }
}
