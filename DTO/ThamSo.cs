using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThamSo
    {
        private String mTenThamSo;
        private int mGiaTri;

        public ThamSo()
        {
        }

        public ThamSo(String tenThamSo, int giaTri)
        {
            mTenThamSo = tenThamSo;
            mGiaTri = giaTri;
        }

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
