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
    /// Interaction logic for ThemGiangVien.xaml
    /// </summary>
    public partial class ThemGiangVien : Window
    {
        GiangVienBUS mGiangVienBUS;
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;
        private bool isUpdating = false;
        private String mMaGvUpdate;

        public ThemGiangVien()
        {
            InitializeComponent();
            mGiangVienBUS = new GiangVienBUS();
        }

        public ThemGiangVien(GiangVien gv)
        {
            InitializeComponent();
            mGiangVienBUS = new GiangVienBUS();
            isUpdating = true;
            TenGV_tb.Text = gv.MTenGiangVien;
            DiaChi_tb.Text = gv.MDiaChi;
            SoDT_tb.Text = gv.MSoDienThoai;
            tb_header.Text = "Sửa thông tin giảng viên";
            grid_headerBackground.Background = new SolidColorBrush(Color.FromRgb(239, 163, 0));
            mMaGvUpdate = gv.MMaGiangVien;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TenGV_tb.Text == "" || SoDT_tb.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!", "Thông báo");
                return;
            }
            GiangVien gv = new GiangVien("",TenGV_tb.Text,
                                            DiaChi_tb.Text,
                                            SoDT_tb.Text);
            bool insert;
            if (isUpdating)
            {
                gv.MMaGiangVien = mMaGvUpdate;
                insert = mGiangVienBUS.updateGiangVien(gv);
            }
            else
            {
                insert = mGiangVienBUS.insertGiangVien(gv);
            }

            if (insert == true)
            {
                if (isUpdating)
                    MessageBox.Show("Cập nhật thông tin giáo viên thành công", "New Age English");
                else
                {
                    MessageBox.Show("Thêm giáo viên thành công");
                    TenGV_tb.Text = "";
                    DiaChi_tb.Text = "";
                    SoDT_tb.Text = "";
                }
                    
                //Notify changes
                DataChangedEventHandler handler = DataChanged;
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Failed!");
            }
        }

        private void bt_exit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
