using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessTier;
using DTO;

namespace BusinessLogicTier
{
    public class ThoiGianHocBUS
    {
        public ThoiGianHocBUS() { }
        public bool themThoiGianHoc(ThoiGianHoc tgh){
            return new ThoiGianHocDAO().themThoiGianHoc(tgh);
        }
        public bool xoaThoiGianHoc(String maTgh)
        {
            return new ThoiGianHocDAO().xoaThoiGianHoc(maTgh);
        }

        public bool suaThoiGianHoc(ThoiGianHoc tgh)
        {
            return new ThoiGianHocDAO().suaThoiGianHoc(tgh);
        }
         public bool insertThoiGianHoc(ThoiGianHoc tgHoc)
        {
            return new ThoiGianHocDAO().insertThoiGianHoc(tgHoc);
        }
       
    }
}
