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
using System.Text.RegularExpressions;

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
            List<ThiXepLop> mDanhSachTXL = new ThiXepLopBUS().getTXLNow();
            dsTXL_cb.ItemsSource = mDanhSachTXL;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void dsTXL_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dsTXL_cb.Text == "")
            {
                return;
            }
            List<ChiTietThiXepLop> mDanhSachChiTietTXL = new ChiTietThiXepLopBUS().getChiTietTXLByMaTXL(dsTXL_cb.Text);
            listHV_lv.ItemsSource = mDanhSachChiTietTXL;
        }
    }
}
