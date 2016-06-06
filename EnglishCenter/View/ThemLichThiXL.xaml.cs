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
        PhongBUS mPhongBUS;
        CaBUS mCaBUS;
        ThiXepLopBUS mThiXepLopBUS;
        List<RadioButton> mThoiGianThi;
        List<LopHoc_ThoiGianDTO> mDanhSachLopVaThoiGian;
        LopHocBUS mLopHocBUS;
        List<ThiXepLop> mDanhSachThiXepLopTrongNgay;

        public ThemLichThi()
        {
            InitializeComponent();
            mLopHocBUS = new LopHocBUS();
            mThiXepLopBUS = new ThiXepLopBUS();
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
            #region KiemTraNgayThi
            try
            {
                txl.MNgayThi = (DateTime)dp_ngayThi.SelectedDate;
            }
            catch (Exception)
            {
                MessageBox.Show("Ngày tháng không hợp lệ");
                return;
            }
            //ngày thi phải lớn hơn ngày hiện tại.
            if (txl.MNgayThi < DateTime.Today)
            {
                String temp = DateTime.Today.ToString();
                MessageBox.Show("Hôm nay là ngày " + temp.Substring(0, temp.IndexOf(" ")) + ". \nVui lòng chọn ngày thi sau ngày hiện tại.");
                return;
            }

            //ngày thi của 1 thi xếp lớp phải thuộc tất cả các lớp đang mở chưa khai giảng
            List<LopHoc> dsLopDangMo = mLopHocBUS.getListLopHocWithNgayThiXL(txl.MNgayThi);
            if (dsLopDangMo.Count <= 0)
            {
                MessageBox.Show("Ngày thi xếp lớp không phù hợp cho các lớp đang mở hiện tại.");
                return;
            }
            #endregion

            #region KiemTraDeThi
            if (cb_deThi.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đề thi!");
                return;
            }

            txl.MDeThi = ((DeThi)cb_deThi.SelectedItem).MMaDeThi;
            #endregion

            #region KiemTraDiaDiemVaCaThi
            if (mThoiGianThi.Find(m => m.IsChecked == true) == null)
            {
                MessageBox.Show("Vui lòng chọn thời gian thi!");
                return;
            }
            String ca_phong = mThoiGianThi.Find(m => m.IsChecked == true).Name;
            if (ca_phong.IndexOf('C') <= -1 && ca_phong.IndexOf('_') <= -1)
            {
                MessageBox.Show("Không add được học viên!");
                return;
            }
            txl.MCaThi = ca_phong.Substring(ca_phong.IndexOf('C') + 1, ca_phong.IndexOf('_') - (ca_phong.IndexOf('C') + 1));
            txl.MMaPhong = ca_phong.Substring(ca_phong.IndexOf('P') + 1, ca_phong.Length - (ca_phong.IndexOf('P') + 1));
            #endregion

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
            ThoiGianThi_Grid.Children.Clear();
            ThoiGianThi_Grid.ColumnDefinitions.Clear();
            ThoiGianThi_Grid.RowDefinitions.Clear();
        }

        private void dp_ngayThi_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dp_ngayThi.Text == "")
            {
                return;
            }
            DateTime ngayThi = DateTime.Parse(dp_ngayThi.Text);
            mDanhSachLopVaThoiGian = mLopHocBUS.getListLopHocByDay(ngayThi);
            mDanhSachThiXepLopTrongNgay = mThiXepLopBUS.getAllThiXLByDay(ngayThi);
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
                tb.Text = "Ca " + listCa[i].MMaCa;
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
                    if (mDanhSachThiXepLopTrongNgay.Find(m => (m.MMaPhong == listPhong[i].MMaPhong && m.MCaThi == listCa[j].MMaCa)) != null)
                    {
                        continue;
                    }
                    RadioButton cb = new RadioButton();
                    cb.Name = "C" + listCa[j].MMaCa + "_" + "P" + listPhong[i].MMaPhong;
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
