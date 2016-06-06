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


    public partial class ThemLichThi : Window
    {
        List<Phong> mListPhong;
        List<Ca> mListCa;
        PhongBUS mPhongBUS;
        CaBUS mCaBUS;
        List<RadioButton> mThoiGianThi;
        List<LopHoc_ThoiGianDTO> mDanhSachLopVaThoiGian;
        LopHocBUS mLopHocBUS;

        public ThemLichThi()
        {
            InitializeComponent();
            mLopHocBUS = new LopHocBUS();
            mPhongBUS = new PhongBUS();
            mCaBUS = new CaBUS();
            mListPhong = mPhongBUS.getListPhong();
            cb_deThi.ItemsSource = new DeThiBUS().getListDeThi();
            cb_deThi.SelectedIndex = 0;
        }

        private void Button_Huy_Click(object sender, RoutedEventArgs e)
        {
            resetComponent();
        }

        private void Button_Luu_Click(object sender, RoutedEventArgs e)
        {
            ThiXepLop txl = new ThiXepLop();
            //txl.MCaThi = new CaBUS().getAllCa()[cb_caThi.SelectedIndex].MMaCa;
            //txl.MDeThi = new DeThiBUS().getListDeThi()[cb_deThi.SelectedIndex].MMaDeThi;
            //txl.MMaPhong = mListPhong[cb_phongThi.SelectedIndex].MMaPhong;
            try
            {
                txl.MNgayThi = (DateTime)dp_ngayThi.SelectedDate;
            }
            catch (Exception)
            {
                MessageBox.Show("Ngày tháng không hợp lệ");
                return;
            }

            bool result = new ThiXepLopBUS().themThiXepLop(txl);
            if (!result)
            {
                MessageBox.Show("Thêm thất bại.");
                return;
            }

            MessageBox.Show("Lịch thi xếp lớp được thêm thành công.");
            resetComponent();
        }
        private void Button_Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void resetComponent()
        {
            dp_ngayThi.Text = "";
            //cb_caThi.Text = "";
            cb_deThi.Text = "";
            //cb_phongThi.Text = "";
        }

        private void dp_ngayThi_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            mDanhSachLopVaThoiGian = mLopHocBUS.getListLopHocByDay(DateTime.Parse(dp_ngayThi.Text));
            //List<Ca> caRanh;
            //List<Phong> phongRanh;
            createThoiGianRanh();
        }

        private void createThoiGianRanh()
        {
            List<Phong> listPhong = mPhongBUS.getListPhong();
            List<Ca> listCa = mCaBUS.getAllCa();
            //ThoiGianRanh_Grid.ShowGridLines = true;
            #region ThoiGianRanh_GUI
            ThoiGianThi_Grid.Children.Clear();
            ThoiGianThi_Grid.ColumnDefinitions.Clear();
            ThoiGianThi_Grid.RowDefinitions.Clear();
            for (int i = 0; i <= listPhong.Count; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(40);
                ThoiGianThi_Grid.RowDefinitions.Add(row);
            }
            for (int i = 0; i <= listCa.Count; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                ThoiGianThi_Grid.ColumnDefinitions.Add(column);
            }
            for (int i = 0; i < listCa.Count; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = listCa[i].MMaCa;
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(tb, 0);
                Grid.SetColumn(tb, i + 1);
                ThoiGianThi_Grid.Children.Add(tb);
            }

            for (int i = 0; i < listPhong.Count; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = listPhong[i].MTenPhong;
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(tb, i + 1);
                Grid.SetColumn(tb, 0);
                ThoiGianThi_Grid.Children.Add(tb);
                Border bd = new Border();
                Grid.SetRow(bd, i + 1);
                Grid.SetColumn(bd, 0);
                Grid.SetColumnSpan(bd, 8);
                bd.VerticalAlignment = VerticalAlignment.Bottom;
                bd.BorderBrush = Brushes.Gray;
                bd.BorderThickness = new Thickness(0.5);
                bd.Margin = new Thickness(10, 0, 10, 0);
                ThoiGianThi_Grid.Children.Add(bd);
            }

            mThoiGianThi = new List<RadioButton>();

            for (int i = 0; i < listPhong.Count; i++)
            {
                for (int j = 0; j < listCa.Count; j++)
                {
                    if (mDanhSachLopVaThoiGian.Find(m => (m.MMaPhong == listPhong[i].MMaPhong && m.MMaCa == listCa[j].MMaCa)) != null)
                    {
                        continue;
                    }
                    RadioButton cb = new RadioButton();
                    cb.Name = "Ca" + listCa[j].MMaCa + "_" + "Phong" + listPhong[i].MMaPhong;
                    cb.VerticalAlignment = VerticalAlignment.Center;
                    cb.HorizontalAlignment = HorizontalAlignment.Center;
                    mThoiGianThi.Add(cb);
                    Grid.SetRow(cb, i + 1);
                    Grid.SetColumn(cb, j + 1);
                    ThoiGianThi_Grid.Children.Add(cb);
                }
            }
            #endregion
        }
    }
}
