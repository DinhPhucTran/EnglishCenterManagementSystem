using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class HocVienBUS
    {
        public const int NUMBER_OF_CHARACTER_YEAR = 4;
        public const int NUMBER_OF_CHARACTER_STT = 5;
        HocVienDAO mHocVienDAO;

        public HocVienBUS()
        {
            mHocVienDAO = new HocVienDAO();
        }

        public List<String> getAllMaHV()
        {
            return mHocVienDAO.getAllMaHV();
        }

        public String getMaHV()
        {
            String result = DateTime.Now.Year.ToString();
            List<String> listMaHV = mHocVienDAO.getAllMaHV();
            int stt;
            if (listMaHV.Count != 0)
            {
                stt = listMaHV.Select(m => int.Parse(m.Substring(NUMBER_OF_CHARACTER_YEAR))).Max() + 1;
            }
            else
            {
                stt = 1;
            }
            for (int i = 0; i < NUMBER_OF_CHARACTER_STT - stt.ToString().Length; i++)
            {
                result += "0";
            }
            result += stt.ToString();
            return result;
        }

        public bool insertHocVien(HocVien hv)
        {
            hv.MMaHocVien = getMaHV();
            return mHocVienDAO.insertHocVien(hv);
        }

        public List<String> getMaHVbyMaLop(String maLop)
        {
            return mHocVienDAO.getMaHVbyMaLop(maLop);
        }

        public List<HocVien> getHocVienByMaLop(String maLop)
        {
            return mHocVienDAO.getHocVienByMaLop(maLop);
        }

        public HocVien selectHocVien(String maHocVien)
        {
            return mHocVienDAO.selectHocVien(maHocVien);
        }

        public int countHocVienByMaLop(String maLop)
        {
            return mHocVienDAO.countHocVienByMaLop(maLop);
        }

        public List<HocVien> getListHocVien()
        {
            return mHocVienDAO.getListHocVien();
        }

        public bool updateHocVien(HocVien hv)
        {
            return mHocVienDAO.updateHocVien(hv);
        }

        public bool insertHocVienNgayTiepNhan(HocVien hv, DateTime ngay)
        {
            return mHocVienDAO.insertHocVienNgayTiepNhan(hv, ngay);
        }

        public List<DateTime> getListNgayTiepNhan()
        {
            return mHocVienDAO.getListNgayTiepNhan();
        }
    }
}
