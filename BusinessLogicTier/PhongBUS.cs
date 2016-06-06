using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class PhongBUS
    {
        PhongDAO mPhongDAO;

        public PhongBUS()
        {
            mPhongDAO = new PhongDAO();
        }
        public List<Phong> getListPhong()
        {
            return new PhongDAO().getListPhong();
        }

        public bool suaPhong(Phong p)
        {
            return new PhongDAO().suaPhong(p);
        }

        public int getIndexPhong()
        {
            List<Phong> temp = mPhongDAO.getListPhong();
            if (temp.Count == 0)
            {
                return 1;
            }
            return temp.Select(m => int.Parse(m.MMaPhong)).Max() + 1;
        }

        public bool themPhong(Phong p)
        {
            p.MMaPhong = getIndexPhong().ToString();
            return new PhongDAO().themPhong(p);
        }
        public bool xoaPhong(String maPhong){
            return new PhongDAO().xoaPhong(maPhong);
        }
    }
}
