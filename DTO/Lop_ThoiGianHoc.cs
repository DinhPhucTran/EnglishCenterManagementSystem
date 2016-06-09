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
        private int mSoCaDungYeuCau; //số ca phù trùng với thời gian rảnh của học viên

        public Lop_ThoiGianHoc() { }

        public Lop_ThoiGianHoc(LopHoc lop, List<ThoiGianHoc> list)
        {
            mLop = lop;
            mListTGH = list;
            mSoCaDungYeuCau = 0;
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

        public int SoCaDungYeuCau
        {
            get { return mSoCaDungYeuCau; }
            set { mSoCaDungYeuCau = value; }
        }

        public String StringThoiGianHoc
        {
            get
            {
                String result = "";
                List<ThoiGianHoc> tempList = new List<ThoiGianHoc>(mListTGH);
                //for (int i = 0; i < tempList.Count; i++)
                //{
                //    result += (mListTGH[i].MMaThu + ". Ca " + (mListTGH[i].MMaCa));
                //    for (int j = i + 1; j < tempList.Count; j++)
                //    {
                //        if (tempList[i].MMaThu.Equals(tempList[j].MMaThu))
                //        {
                //            result += (", " + (tempList[j].MMaCa));
                //            tempList.RemoveAt(j);
                //        }
                //    }
                //    result += " | ";
                //}

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
