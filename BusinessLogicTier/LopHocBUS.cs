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
            ThoiGianHocDAO tghDAO = new ThoiGianHocDAO();
            bool isDone = tghDAO.xoaThoiGianHoc(maLop);
            LopHocDAO lhDAO = new LopHocDAO();
            if (isDone)
            {
                return lhDAO.xoaLopHoc(maLop);
            }
            return isDone;
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

        public LopHoc selectLopHoc(String maLop)
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
            return thu.DayOfWeek.ToString();
        }

        public List<LopHoc> getAllLopHocByMaChuongTrinhHoc(String maCTHoc)
        {
            return new LopHocDAO().getAllLopHocByMaChuongTrinhHoc(maCTHoc);
        }

        public List<ThoiGianHoc> getAllLopHocByTGRanhVaCTMuonHoc(String maHV)
        {
            return new LopHocDAO().getListLopHocByTGRanhVaCTMuonHoc(maHV);
        }

        public List<LopHoc> getListLopHocByMaGiangVien(String maGv)
        {
            return new LopHocDAO().getListLopHocByMaGiangVien(maGv);
        }
    }
}
