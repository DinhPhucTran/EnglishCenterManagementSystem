﻿using System;
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

        public String getIndex()
        {
            List<ThiXepLop> ds = mThiXepLop.getListThiXepLop();
            if (ds.Count == 0)
            {
                return "TXL" + DateTime.Now.Year.ToString() + "_1";
            }
            return "TXL" + ds.Select(m => int.Parse(m.MMaThiXL.Substring(m.MMaThiXL.IndexOf('_') + 1))).Max() + 1;
        }

        public List<ThiXepLop> getAllThiXLByThoiGianRanh(String maHV)
        {
            return new ThiXepLopDAO().getAllThiXLByThoiGianRanh(maHV);
        }

        public bool themThiXepLop(ThiXepLop txl){
            List<LopHoc_ThoiGianDTO> ds = mThiXepLop.layThongTinCacLopTaiThoiDiemXepLop(txl);
            LopHoc_ThoiGianDTO temp = ds.Find(m => (m.MMaPhong == txl.MMaPhong && m.MMaCa == txl.MCaThi && m.MMaThu == txl.MNgayThi.DayOfWeek.ToString()));
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

        public List<ThiXepLop> getTXLNow()
        {
            return new ThiXepLopDAO().getTXLNow();
        }
    }
}
