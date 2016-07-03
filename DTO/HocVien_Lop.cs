using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HocVien_Lop
    {
        private HocVien hocVien;
        private LopHoc lopHoc;

        public HocVien_Lop() { }
        public HocVien_Lop(HocVien hv, LopHoc lop)
        {
            hocVien = hv;
            lopHoc = lop;
        }
        public HocVien HocVien
        {
            get { return hocVien; }
            set { hocVien = value; }
        }
        public LopHoc Lop
        {
            get { return lopHoc; }
            set { lopHoc = value; }
        }

        public string TenHocVien
        {
            get { return hocVien.MTenHocVien.Split(' ').Last(); }
        }
    }
}
