using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;
namespace BusinessLogicTier
{
    public class PhieuThuHocPhiBUS
    {
        private PhieuThuHocPhiDAO mDao;
        public PhieuThuHocPhiBUS() {
            mDao = new PhieuThuHocPhiDAO();        
        }
        public bool themPhieuThu(PhieuThuHocPhi phieu){
            return mDao.insertPhieuThu(phieu);
        }

        public bool suaPhieuThu(PhieuThuHocPhi phieu)
        {
            return mDao.updatePhieuThu(phieu);
        }

        public bool xoaPhieuThu(String maPhieu)
        {
            return mDao.deletePhieuThu(maPhieu);
        }

        public List<PhieuThuHocPhi> getDanhSachPhieu()
        {
            return mDao.getListPhieuThu();
        }
        public bool updateSoTienNo(String maHv, String maLop, double soTien)
        {
            return mDao.updateSoTienNo(maHv, maLop, soTien);
        }
    }
}
