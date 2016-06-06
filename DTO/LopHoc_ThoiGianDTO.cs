using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LopHoc_ThoiGianDTO
    {
        String mMaLop;
        String mMaPhong;
        String mMaThu;
        String mMaCa;

        public string MMaLop
        {
            get
            {
                return mMaLop;
            }

            set
            {
                mMaLop = value;
            }
        }

        public string MMaPhong
        {
            get
            {
                return mMaPhong;
            }

            set
            {
                mMaPhong = value;
            }
        }

        public string MMaThu
        {
            get
            {
                return mMaThu;
            }

            set
            {
                mMaThu = value;
            }
        }

        public string MMaCa
        {
            get
            {
                return mMaCa;
            }

            set
            {
                mMaCa = value;
            }
        }

        public LopHoc_ThoiGianDTO()
        { }

        public LopHoc_ThoiGianDTO(String maLop, String maPhong, String maThu, String maCa)
        {
            MMaLop = maLop;
            MMaPhong = maPhong;
            MMaThu = maThu;
            MMaCa = maCa;
        }
    }
}
