using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ThoiGianHoc
    {
        String mMaLop;
        String mMaThu;
        String mMaCa;

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
    }
}
