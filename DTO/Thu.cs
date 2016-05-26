using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Thu
    {
        private String mMaThu;
        private String mTenThu;

        public Thu()
        { }

        public Thu(String maThu, String tenThu)
        {
            mMaThu = maThu;
            mTenThu = tenThu;
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

        public string MTenThu
        {
            get
            {
                return mTenThu;
            }

            set
            {
                mTenThu = value;
            }
        }
    }
}
