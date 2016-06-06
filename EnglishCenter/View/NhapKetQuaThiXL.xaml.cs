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
    /// Interaction logic for NhapKetQuaThiXL.xaml
    /// </summary>
    public partial class NhapKetQuaThiXL : Window
    {
        public NhapKetQuaThiXL()
        {
            InitializeComponent();
            List<ChiTietThiXepLop> mDanhSachChiTietTXL = new ChiTietThiXepLopBUS().getAllChiTietTXL();
            listHV_lv.ItemsSource = mDanhSachChiTietTXL;
        }
    }
}
