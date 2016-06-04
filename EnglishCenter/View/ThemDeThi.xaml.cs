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
    /// Interaction logic for ThemDeThi.xaml
    /// </summary>
    public partial class ThemDeThi : Window
    {
        DeThiBUS mDeThiBUS;

        public ThemDeThi()
        {
            InitializeComponent();
            mDeThiBUS = new DeThiBUS();
        }

        private void Them_btn_Click(object sender, RoutedEventArgs e)
        {
            String loaiDT = LoaiDeThi_tb.Text;
            if (loaiDT == "")
            {
                MessageBox.Show("Nhập loại đề thi!");
                return;
            }
            DeThi dt = new DeThi("", loaiDT, ChiTiet_tb.Text);
            if (!mDeThiBUS.themDeThi(dt))
            {
                MessageBox.Show("Thêm đề thi không thành công.");
                return;
            }
            else
            {
                MessageBox.Show("Thêm đề thi thành công.");
                resetComponent();
            }
        }

        public void resetComponent()
        {
            LoaiDeThi_tb.Text = "";
            ChiTiet_tb.Text = "";
        }

        private void Thoat_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
