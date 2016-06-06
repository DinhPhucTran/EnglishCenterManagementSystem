using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;
namespace BusinessLogicTier
{
    public class LopHocBUS
    {
        public LopHocBUS()
        {

        }

        public List<LopHoc> getListLopHoc()
        {
            return new LopHocDAO().getAllLopHoc();
        }

        public List<LopHoc> getListLopHocByTime(DateTime thoiGianBD, DateTime thoiGianKT)
        {
            return new LopHocDAO().getLopHocByTime(thoiGianBD,thoiGianKT);
        }
        public bool themLopHoc(LopHoc lh)
        {
            //kiem tra logic
            return new LopHocDAO().themLopHoc(lh);
        }

        public bool xoaLopHoc(String maLop)
        {
            LopHocDAO lhDAO = new LopHocDAO();
            return lhDAO.xoaLopHoc(maLop);
        }

        public bool suaLopHoc(LopHoc lh)
        {
            return new LopHocDAO().suaLopHoc(lh);
        }

        public List<LopHoc> getListLopHocByMaHV(String maHv)
        {
            return new LopHocDAO().getListLopHocByMaHV(maHv);
        }

        public LopHoc getLopMoiNhatByMaHV(String maHv)
        {
            return new LopHocDAO().getLopMoiNhatByMaHV(maHv);
        }

        public List<LopHoc> selectLopHoc(String maLop)
        {
            return new LopHocDAO().selectLopHoc(maLop);
        }

        public List<LopHoc> getListLopHocWithNgayThiXL(DateTime ngayThi)
        {
            return new LopHocDAO().getListLopHocWithNgayThiXL(ngayThi);
        }

        public List<LopHoc_ThoiGianDTO> getListLopHocByDay(DateTime ngayThi)
        {
            return new LopHocDAO().getListLopHocByDay(getMaThuFromDay(ngayThi), ngayThi);
        }

        public String getMaThuFromDay(DateTime thu)
        {
            switch (thu.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "CN";
                case DayOfWeek.Monday:
                    return "T2";
                case DayOfWeek.Tuesday:
                    return "T3";
                case DayOfWeek.Wednesday:
                    return "T4";
                case DayOfWeek.Thursday:
                    return "T5";
                case DayOfWeek.Friday:
                    return "T6";
                case DayOfWeek.Saturday:
                    return "T7";
            }
            return "";
        }
    }
}
