using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class DeThiBUS
    {
        public DeThiBUS() { }

        public List<DeThi> getListDeThi()
        {
            return new DeThiDAO().getListDeThi();
        }

        public bool themDeThi(DeThi dth)
        {
            return new DeThiDAO().themDeThi(dth);
        }

        public bool xoaDeThi(String ma)
        {
            return new DeThiDAO().xoaDeThi(ma);
        }

        public bool suaDeThi(DeThi dethi)
        {
            return new DeThiDAO().suaDeThi(dethi);
        }
    }
}
