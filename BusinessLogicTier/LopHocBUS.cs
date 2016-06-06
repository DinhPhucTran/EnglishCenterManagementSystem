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
    }
}
