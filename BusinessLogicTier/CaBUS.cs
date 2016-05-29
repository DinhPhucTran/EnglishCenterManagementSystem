using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessTier;
using DTO;

namespace BusinessLogicTier
{
    public class CaBUS
    {
        CaDAO mCaDAO;

        public CaBUS()
        {
            mCaDAO = new CaDAO();
        }

        public List<Ca> getAllCa()
        {
            return mCaDAO.getAllCa();
        }
    }
}
