using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using BusinessLogicTier;
using DTO;
namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for KetQuaThiXepLop.xaml
    /// </summary>
    public partial class KetQuaThiXepLop : Window
    {
        private KetQuaThiXLBUS mBUS;
        public KetQuaThiXepLop()
        {
            mBUS =  new KetQuaThiXLBUS();
            InitializeComponent();
            List<DateTime> khoangTG = new ThiXepLopBUS().getKhoangThoiGianLayThiXepLop(DateTime.Now);
            List<KetQuaThi> list =mBUS.getKetQuaThi(khoangTG[0],khoangTG[1]);
            lv_ketQua.ItemsSource = list;
            foreach (KetQuaThi kqt in list)
            {
                List<string> cb_lopDeNghi = new KetQuaThiXLBUS().getMaLopDeNghiVaMongMuon(kqt.MChuongTrinhDeNghi, kqt.MChuongTrinhMuonHoc, kqt.MNgayThi);
                foreach (string s in cb_lopDeNghi)
                {

                }
                kqt.MMaLopDeNghi = cb_lopDeNghi;
                if (cb_lopDeNghi.Count != 0)
                {
                    int a = 1;
                }
            }
            
        }
    }
}
