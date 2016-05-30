using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TrinhDo
    {
        String mMaTrinhDo;

        public TrinhDo()
        { }

        public TrinhDo(String maTrinhDo, String tenTrinhDo)
        {
            mMaTrinhDo = maTrinhDo;
            mTenTrinhDo = tenTrinhDo;
        }

        public String MMaTrinhDo
        {
            get { return mMaTrinhDo; }
            set { mMaTrinhDo = value; }
        }
        String mTenTrinhDo;

        public String MTenTrinhDo
        {
            get { return mTenTrinhDo; }
            set { mTenTrinhDo = value; }
        }

        public override string ToString()
        {
            return mTenTrinhDo;
        }
    }
}
