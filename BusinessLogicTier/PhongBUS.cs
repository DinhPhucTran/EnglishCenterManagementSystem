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
        public PhongBUS()
        {

        }
        public List<Phong> getListPhong()
        {
            return new PhongDAO().getListPhong();
        }

        public bool suaPhong(Phong p)
        {
            return new PhongDAO().suaPhong(p);
        }

        public bool themPhong(Phong p)
        {
            return new PhongDAO().themPhong(p);
        }
        public bool xoaPhong(String maPhong){
            return new PhongDAO().xoaPhong(maPhong);
        }
    }
}
