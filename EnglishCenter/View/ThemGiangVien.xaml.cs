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
    /// Interaction logic for ThemGiangVien.xaml
    /// </summary>
    public partial class ThemGiangVien : Window
    {
        GiangVienBUS mGiangVienBUS;

        public ThemGiangVien()
        {
            InitializeComponent();
            mGiangVienBUS = new GiangVienBUS();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TenGV_tb.Text == "" )
            {

            }
            int maxIdGV = mGiangVienBUS.getMaGiangVienMax();
            GiangVien gv = new GiangVien((maxIdGV + 1).ToString(),
                                            TenGV_tb.Text,
                                            DiaChi_tb.Text,
                                            SoDT_tb.Text);
        }
    }
}
