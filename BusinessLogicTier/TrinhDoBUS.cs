using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessTier;
using DTO;

namespace BusinessLogicTier
{
    public class TrinhDoBUS
    {
        TrinhDoDAO mTrinhDoDAO;
        public TrinhDoBUS()
        {
            mTrinhDoDAO = new TrinhDoDAO();
        }

        public List<TrinhDo> getListTrinhDo()
        {
            return mTrinhDoDAO.getListTrinhDo();
        }

        public String getMaTDFromTen(String tenTrinhDo)
        {
            return mTrinhDoDAO.getMaTrinhDoFromTen(tenTrinhDo);
        }

        public bool themTrinhDo(TrinhDo t)
        {
            return mTrinhDoDAO.themTrinhDo(t);
        }

        public TrinhDo selectTrinhDo(String maTD)
        {
            return mTrinhDoDAO.selectTrinhDo(maTD);
        }
    }
}
