﻿using System;
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
    }
}