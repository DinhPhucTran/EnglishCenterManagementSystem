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
        private ThoiGianHocDAO mDAO;
        public ThoiGianHocBUS() {
            mDAO = new ThoiGianHocDAO();
        }
        public bool themThoiGianHoc(ThoiGianHoc tgh){
            return mDAO.themThoiGianHoc(tgh);
        }
        public bool xoaThoiGianHocCuaLop(String maLop)
        {
            return mDAO.xoaThoiGianHoc(maLop);
        }

        public bool suaThoiGianHoc(ThoiGianHoc tgh)
        {
            return mDAO.suaThoiGianHoc(tgh);
        }
         public bool insertThoiGianHoc(ThoiGianHoc tgHoc)
        {
            return mDAO.insertThoiGianHoc(tgHoc);
        }
         public List<ThoiGianHoc> getThoiGianHocCuaLop(String maLop)
         {
             return mDAO.getThoiGianHocCuaLop(maLop);
         }
         public int themDanhSachThoiGianHoc(List<ThoiGianHoc> list)
         {
             int result = 0;
             foreach (ThoiGianHoc t in list)
             {
                 bool s = mDAO.themThoiGianHoc(t);
                 if (s == true)
                 {
                     result++;
                 }
             }
             return result;
         }

         
        
    }
}
