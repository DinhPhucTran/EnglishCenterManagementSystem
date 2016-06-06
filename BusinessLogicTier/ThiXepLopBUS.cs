using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class ThiXepLopBUS 
    {
        ThiXepLopDAO mThiXepLop;
        public ThiXepLopBUS() {
            mThiXepLop = new ThiXepLopDAO();
        }

        public List<ThiXepLop> getListThiXepLop()
        {
            return mThiXepLop.getListThiXepLop();
        }

        public int getIndex()
        {
            List<ThiXepLop> ds = mThiXepLop.getListThiXepLop();
            if (ds.Count == 0)
            {
                return 1;
            }
            return ds.Select(m => int.Parse(m.MMaThiXL)).Max() + 1;
        }
        
        public bool themThiXepLop(ThiXepLop txl){
            List<LopHoc_ThoiGianDTO> ds = mThiXepLop.layThongTinCacLopTaiThoiDiemXepLop(txl);
            String maThuCuaNgayThi = "";
            switch (txl.MNgayThi.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    maThuCuaNgayThi = "CN";
                    break;
                case DayOfWeek.Monday:
                    maThuCuaNgayThi = "T2";
                    break;
                case DayOfWeek.Tuesday:
                    maThuCuaNgayThi = "T3";
                    break;
                case DayOfWeek.Wednesday:
                    maThuCuaNgayThi = "T4";
                    break;
                case DayOfWeek.Thursday:
                    maThuCuaNgayThi = "T5";
                    break;
                case DayOfWeek.Friday:
                    maThuCuaNgayThi = "T6";
                    break;
                case DayOfWeek.Saturday:
                    maThuCuaNgayThi = "T7";
                    break;
            }
            LopHoc_ThoiGianDTO temp = ds.Find(m => (m.MMaPhong == txl.MMaPhong && m.MMaCa == txl.MCaThi && m.MMaThu == maThuCuaNgayThi));
            if (temp != null)
            {
                return false;
            }
            List<ThiXepLop> same = mThiXepLop.getListThiXepLopByTime(txl);
            if (same.Count != 0)
            {
                return false;
            }
            txl.MMaThiXL = getIndex().ToString();
            if (!mThiXepLop.themThiXepLop(txl))
            {
                return false;
            }
            return true;
        }

        public List<ThiXepLop> getAllThiXLByDay(DateTime ngayThi)
        {
            return mThiXepLop.getAllThiXepLopByDay(ngayThi);
        }
    }
}
