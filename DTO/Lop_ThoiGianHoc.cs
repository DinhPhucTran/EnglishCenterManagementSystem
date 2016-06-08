using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Lop_ThoiGianHoc
    {
        private LopHoc mLop;
        private List<ThoiGianHoc> mListTGH;

        public Lop_ThoiGianHoc() { }

        public Lop_ThoiGianHoc(LopHoc lop, List<ThoiGianHoc> list)
        {
            mLop = lop;
            mListTGH = list;
        }

        public LopHoc LopHoc 
        {
            get { return mLop; }
            set { mLop = value; }
        }

        public List<ThoiGianHoc> ListThoiGianHoc
        {
            get { return mListTGH; }
            set { mListTGH = value; }
        }

        public String StringThoiGianHoc
        {
            get
            {
                String result = "";
                foreach (ThoiGianHoc tg in mListTGH)
                {
                    result += tg.MMaThu + ", Ca " + tg.MMaCa + "  |  ";
                }
                return result;
            }
        }

        public String MaLop
        {
            get { return mLop.MMaLop; }
        }
    }
}
