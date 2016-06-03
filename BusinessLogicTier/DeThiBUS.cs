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
        DeThiDAO mDeThiDAO;

        public DeThiBUS() {
            mDeThiDAO = new DeThiDAO();
        }

        public List<DeThi> getListDeThi()
        {
            return new DeThiDAO().getListDeThi();
        }

        public int getIndex()
        {
            List<DeThi> ds = mDeThiDAO.getListDeThi();
            if (ds.Count > 0)
            {
                return ds.Select(m => int.Parse(m.MMaDeThi)).Max() + 1;
            }
            return 1;
        }

        public bool themDeThi(DeThi dth)
        {
            dth.MMaDeThi = getIndex().ToString();
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
