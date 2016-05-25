using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ThamSo
    {
        String mTenThamSo;
        int mGiaTri;

        public string MTenThamSo
        {
            get
            {
                return mTenThamSo;
            }

            set
            {
                mTenThamSo = value;
            }
        }

        public int MGiaTri
        {
            get
            {
                return mGiaTri;
            }

            set
            {
                mGiaTri = value;
            }
        }
    }
}
