﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessTier;
namespace BusinessLogicTier
{
    public class KetQuaThiXLBUS 
    {
        public List<KetQuaThi> getKetQuaThi(DateTime from, DateTime to)
        {
            return new KetQuaThiXLDAO().getListKQT(from, to);
        }
    }
}