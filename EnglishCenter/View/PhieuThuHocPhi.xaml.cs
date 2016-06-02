using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DTO;
using BusinessLogicTier;

namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for PhieuThuHocPhi.xaml
    /// </summary>
    public partial class PhieuThuHocPhi : Window
    {
        List<LopHoc> mListLop;
        List<HocVien> mListHocVien;
        public PhieuThuHocPhi()
        {
            InitializeComponent();
            mListLop = new LopHocBUS().getListLopHoc();
            cb_lop.ItemsSource = mListLop;
            cb_lop.SelectedIndex = 0;

            mListHocVien = new List<HocVien>();
            cb_tenHocVien.ItemsSource = mListHocVien;
            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+,");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)//luu
        {
            PhieuThuHocPhiBUS bus = new PhieuThuHocPhiBUS();
            DTO.PhieuThuHocPhi phieu = new DTO.PhieuThuHocPhi();
            List<DTO.PhieuThuHocPhi> list = bus.getDanhSachPhieu();
            long max = 0;
            foreach (DTO.PhieuThuHocPhi p in list)
            {
                if (long.Parse(p.MMaPhieuThu.Substring(6)) > max)
                {
                    max = long.Parse(p.MMaPhieuThu.Substring(6));
                }
            }
            max++;
            phieu.MMaPhieuThu = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + max;

            phieu.MMaLopHoc = mListLop[cb_lop.SelectedIndex].MMaLop;
            phieu.MMaHocVien = mListHocVien[cb_tenHocVien.SelectedIndex].MMaHocVien;
            phieu.MNgayLap = DateTime.Now;
            try
            {
                phieu.MSoTienDong = double.Parse(tb_soTien.Text.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Kiểm tra lại số tiền");
                return;
            }
            bool result = bus.themPhieuThu(phieu);
            if (result == true)
            {
                MessageBox.Show("Thành Công!!");
            }
            else
            {
                MessageBox.Show("Thất bại!!!\nVui lòng kiểm tra lại dử liệu và thử lại");
            }
            
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//in
        {
            MessageBox.Show("Printing...");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//thoat
        {
            this.Close();
        }

        

        private void cb_lop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mListHocVien = new HocVienBUS().getHocVienByMaLop(mListLop[cb_lop.SelectedIndex].MMaLop.ToString());
            cb_tenHocVien.ItemsSource = mListHocVien;
            if (mListHocVien.Count != 0)
            {
                cb_tenHocVien.SelectedIndex = 0;
            }
        }



    }
}
