using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;

namespace BusinessLogicTier
{
    public class ChiTietLopHocBUS
    {
        public bool insertChiTietLopHoc(ChiTietLopHoc ct)
        {
            return new ChiTietLopHocDAO().insertChiTietLopHoc(ct);
        }
    }
}
