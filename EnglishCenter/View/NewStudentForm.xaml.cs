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
using DTO;
using BusinessLogicTier;
using System.Text.RegularExpressions;
using System.Globalization;

namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for NewStudentForm.xaml
    /// </summary>
    public partial class NewStudentForm : Window
    {
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;
        HocVienBUS mHocVienBUS;
        ThoiGianRanhBUS mThoiGianRanhBUS;
        CaBUS mCaBUS;
        ThuBUS mThuBUS;
        List<CheckBox> mListThoiGianRanh;
        RadioButton mPhaiRadioButton;
        TrinhDoBUS mTrinhDoBUS;
        ChuongTrinhHocBUS mChuongTrinhBUS;
        List<TrinhDo> mListTrinhDo;
        List<ChuongTrinhHoc> mListChuongTrinhHoc;
        List<ThiXepLop_Ca> mListThiXLCa;
        List<Lop_ThoiGianHoc> mListLopThoiGian;
        ChiTietLopHoc mChiTietLop;
        ChiTietThiXepLop mChiTietThiXL;
        List<ThiXepLop> mListAllThiXL;
        //List<ThiXepLop> mListThiXLDeNghi;
        ThiXepLop_Ca mSelectedTXL;
        Lop_ThoiGianHoc mSelectedLop;
        int lv_thiXL_selectedIndex = -1;
        int lv_xepLop_selectedIndex = -1;
        List<Lop_ThoiGianHoc> mListLopDangMo;

        public NewStudentForm()
        {
            InitializeComponent();
            mHocVienBUS = new HocVienBUS();
            mThoiGianRanhBUS = new ThoiGianRanhBUS();
            mCaBUS = new CaBUS();
            mThuBUS = new ThuBUS();
            mTrinhDoBUS = new TrinhDoBUS();
            mChuongTrinhBUS = new ChuongTrinhHocBUS();
            mListTrinhDo = mTrinhDoBUS.getListTrinhDo();
            mListChuongTrinhHoc = mChuongTrinhBUS.getListChuongTrinhHoc();
            TDoDaHoc_cb.ItemsSource = mListTrinhDo;
            TDoMuonHoc_cb.ItemsSource = mListTrinhDo;
            CTDaHoc_cb.ItemsSource = mListChuongTrinhHoc;
            CTMuonHoc_cb.ItemsSource = mListChuongTrinhHoc;
            createThoiGianRanh();
            tb_date.Text = DateTime.Today.ToShortDateString();
            NgaySinhHV_dp.DisplayDateStart = new DateTime(1900, 1, 1);
            NgaySinhHV_dp.DisplayDateEnd = DateTime.Today.AddYears(-2);
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void createThoiGianRanh()
        {
            //List<Thu> listThu = mThuBUS.getAllThu();
            List<Thu> listThu = new List<Thu>();
            listThu.Add(new Thu("Monday", "Thứ Hai"));
            listThu.Add(new Thu("Tuesday", "Thứ Ba"));
            listThu.Add(new Thu("Wednesday", "Thứ Tư"));
            listThu.Add(new Thu("Thursday", "Thứ Năm"));
            listThu.Add(new Thu("Friday", "Thứ Sáu"));
            listThu.Add(new Thu("Saturday", "Thứ Bảy"));
            listThu.Add(new Thu("Sunday", "Chủ Nhật"));

            List<Ca> listCa = mCaBUS.getAllCa();
            //ThoiGianRanh_Grid.ShowGridLines = true;
            #region ThoiGianRanh_GUI
            for (int i = 0; i <= listCa.Count; i++)
            {
                RowDefinition row = new RowDefinition();
                ThoiGianRanh_Grid.RowDefinitions.Add(row);
            }
            for (int i = 0; i <= listThu.Count; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                ThoiGianRanh_Grid.ColumnDefinitions.Add(column);
            }
            for (int i = 0; i < listThu.Count; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = listThu[i].MTenThu;
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(tb, 0);
                Grid.SetColumn(tb, i + 1);
                ThoiGianRanh_Grid.Children.Add(tb);
            }

            for (int i = 0; i < listCa.Count; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = listCa[i].toStringTgBD_TgKT();
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetRow(tb, i + 1);
                Grid.SetColumn(tb, 0);
                ThoiGianRanh_Grid.Children.Add(tb);
                Border bd = new Border();
                Grid.SetRow(bd, i + 1);
                Grid.SetColumn(bd, 0);
                Grid.SetColumnSpan(bd, 8);
                bd.VerticalAlignment = VerticalAlignment.Bottom;
                bd.BorderBrush = Brushes.Gray;
                bd.BorderThickness = new Thickness(0.5);
                bd.Margin = new Thickness(10, 0, 10, 0);
                ThoiGianRanh_Grid.Children.Add(bd);
            }

            mListThoiGianRanh = new List<CheckBox>();

            for (int i = 0; i < listCa.Count; i++)
            {
                for (int j = 0; j < listThu.Count; j++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Name = listThu[j].MMaThu + "_" + listCa[i].MMaCa;
                    cb.VerticalAlignment = VerticalAlignment.Center;
                    cb.HorizontalAlignment = HorizontalAlignment.Center;
                    mListThoiGianRanh.Add(cb);
                    Grid.SetRow(cb, i + 1);
                    Grid.SetColumn(cb, j + 1);
                    ThoiGianRanh_Grid.Children.Add(cb);
                }
            } 
            #endregion
        }
        
        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            #region SaveHocVien
            String ten = TenHocVien_tb.Text;
            if (ten == "")
            {
                MessageBox.Show("Vui lòng nhập tên học viên.");
                return;
            }
            DateTime? ngaySinh = NgaySinhHV_dp.SelectedDate;
            if (ngaySinh == null)
            {
                MessageBox.Show("Vui lòng nhập ngày sinh.");
                return;
            }
            if (mPhaiRadioButton == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return;
            }
            String phai = mPhaiRadioButton.Content.ToString();
            String diaChi = DiaChi_tb.Text;
            if (diaChi == "")
            {
                MessageBox.Show("Vui lòng điền địa chỉ");
                return;
            }

            String soDT = SoDT_tb.Text;
            //if (!Regex.Match(soDT, @"^(\d[0-9]{9,11})$").Success)
            if(soDT == "")
            {
                MessageBox.Show("Vui lòng điền số điện thoại", "Thông báo");
                return;
            }

            String maTDDaHoc = null;
            if (TDoDaHoc_cb.Text != "")
            {
                maTDDaHoc = mTrinhDoBUS.getMaTDFromTen(TDoDaHoc_cb.Text);
            }
            String maTDMuonHoc = null;
            if (TDoMuonHoc_cb.Text != "")
            {
                maTDMuonHoc = mTrinhDoBUS.getMaTDFromTen(TDoMuonHoc_cb.Text);
            }
            String maCTDaHoc = null;
            if (CTDaHoc_cb.Text != "")
            {
                maCTDaHoc = mChuongTrinhBUS.getMaCTFromTenCT(CTDaHoc_cb.Text);
            }
            String maCTMuonHoc = null;
            if (CTMuonHoc_cb.Text != "")
            {
                maCTMuonHoc = mChuongTrinhBUS.getMaCTFromTenCT(CTMuonHoc_cb.Text);
            }

            HocVien hv = new HocVien("", ten, (DateTime)ngaySinh, phai, diaChi, Email_tb.Text, soDT, maTDDaHoc, maTDMuonHoc, maCTDaHoc, maCTMuonHoc);

            if (!mHocVienBUS.insertHocVien(hv))
            {
                MessageBox.Show("Thêm học viên thất bại!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            #endregion

            #region SaveThoiGianRanh
            List<CheckBox> listChecked = mListThoiGianRanh.FindAll(i => i.IsChecked == true);

            for (int i = 0; i < listChecked.Count; i++)
            {
                String thuCa = listChecked[i].Name;
                ThoiGianRanh temp = new ThoiGianRanh(hv.MMaHocVien, thuCa.Substring(0, thuCa.IndexOf('_')), thuCa.Substring(thuCa.IndexOf('_') + 1));
                if (!mThoiGianRanhBUS.insertThoiGianRanh(temp))
                {
                    MessageBox.Show("Insert Thoi Gian Ranh Failed.");
                }
            } 
            #endregion

            MessageBox.Show("Tiếp nhận học viên thành công", "New Age English");

            #region Save ChiTietThiXepLop
            if (mChiTietThiXL != null)
            {
                mChiTietThiXL.MMaHocVien = hv.MMaHocVien;
                mChiTietThiXL.MChuongTrinhMongMuon = hv.MMaChuongTrinhMuonHoc;
                if (!(new ChiTietThiXepLopBUS().insertChiTietThiXepLop(mChiTietThiXL)))
                    MessageBox.Show("Xếp lịch thi không thành công!", "Thông báo");
                else
                    MessageBox.Show("Xếp lịch thi thành công", "Thông báo");
            }
            #endregion

            #region Save ChiTietLopHoc
            if (mChiTietLop != null)
            {
                mChiTietLop.MMaHocVien = hv.MMaHocVien;
                mChiTietLop.MTinhTrangDongHocPhi = 0;
                mChiTietLop.MSoTienNo = new LopHocBUS().selectLopHoc(mChiTietLop.MMaLopHoc).MSoTien;
                if (!(new ChiTietLopHocBUS().insertChiTietLopHoc(mChiTietLop)))
                    MessageBox.Show("Xếp lớp không thành công!", "Thông báo");
                else
                    MessageBox.Show("Đã thêm học viên vào lớp " + mChiTietLop.MMaLopHoc, "Thông báo");
            }
            #endregion

            if (!mHocVienBUS.insertHocVienNgayTiepNhan(hv, DateTime.Now))
                MessageBox.Show("Ghi nhận ngày lập phiếu thất bại!", "Thông báo");

            resetComponent();

            //Notify changes
            DataChangedEventHandler handler = DataChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }

        }

        public void resetComponent()
        {
            TenHocVien_tb.Text = "";
            NgaySinhHV_dp.SelectedDate = null;
            mPhaiRadioButton = null;
            DiaChi_tb.Text = "";
            SoDT_tb.Text = "";
            Email_tb.Text = "";
            CTDaHoc_cb.SelectedIndex = -1;
            CTMuonHoc_cb.SelectedIndex = -1;
            TDoDaHoc_cb.SelectedIndex = -1;
            TDoMuonHoc_cb.SelectedIndex = -1;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            mPhaiRadioButton = (RadioButton)sender;
        }

        private void In_btn_Click(object sender, RoutedEventArgs e)
        {
            //in
        }

        private void bt_xepLichThiClick(object sender, RoutedEventArgs e)
        {
            popup_xepLop.IsOpen = false;
            popup_xepLichThi.IsOpen = true;

            //Khởi tạo popup Thi xếp lớp
            if(mListAllThiXL == null)
                mListAllThiXL = new ThiXepLopBUS().getListThiXepLop();
            mListThiXLCa = new List<ThiXepLop_Ca>();
            //mListThiXLDeNghi = new List<ThiXepLop>();
            List<CheckBox> listChecked = mListThoiGianRanh.FindAll(i => i.IsChecked == true);
            foreach (ThiXepLop xl in mListAllThiXL)
            {
                String thuCa;
                String thu;
                String ca;
                for (int i = 0; i < listChecked.Count; i++)
                {
                    thuCa = listChecked[i].Name;
                    thu = thuCa.Substring(0, thuCa.IndexOf('_'));
                    ca = thuCa.Substring(thuCa.IndexOf('_') + 1);
                    if (xl.MNgayThi.ToString("dddd", new CultureInfo("en-US")).Equals(thu) && xl.MCaThi.Equals(ca) && xl.MNgayThi > DateTime.Today)
                    {
                        //mListThiXLDeNghi.Add(xl);
                        mListThiXLCa.Add(new ThiXepLop_Ca(xl, mCaBUS.selectCa(xl.MCaThi)));
                        break;
                        
                    }
                } 
                
            }
            if (mListThiXLCa.Count == 0)
            {
                foreach (ThiXepLop xl in mListAllThiXL)
                {
                    if(xl.MNgayThi > DateTime.Today)
                        mListThiXLCa.Add(new ThiXepLop_Ca(xl, mCaBUS.selectCa(xl.MCaThi)));
                }
            }
            lv_popup_thiXL.ItemsSource = mListThiXLCa;
            lv_popup_thiXL.SelectedIndex = lv_thiXL_selectedIndex;
            lv_popup_thiXL.Focus();
        }

        private void bt_popupThiXLCloseClick(object sender, RoutedEventArgs e)
        {
            popup_xepLichThi.IsOpen = false;
        }

        private void bt_popupThiXL_OK_Click(object sender, RoutedEventArgs e)
        {
            popup_xepLichThi.IsOpen = false;
            mSelectedTXL = (ThiXepLop_Ca)lv_popup_thiXL.SelectedValue;
           
            if (mSelectedTXL != null)
            {
                mChiTietThiXL = new ChiTietThiXepLop();
                mChiTietThiXL.MMaThiXepLop = mSelectedTXL.ThiXL.MMaThiXL;
                //if (CTMuonHoc_cb.Text != "")
                //{
                //    mChiTietThiXL.MChuongTrinhMongMuon = mChuongTrinhBUS.getMaCTFromTenCT(CTMuonHoc_cb.Text);
                //}
                lv_thiXL_selectedIndex = lv_popup_thiXL.SelectedIndex;
                mSelectedLop = null;
            }
        }

        private void bt_popupThiXL_Clear_Click(object sender, RoutedEventArgs e)
        {
            mSelectedTXL = null;
            lv_thiXL_selectedIndex = -1;
            lv_popup_thiXL.SelectedIndex = -1;
        }


        private void bt_xepLopCloseClick(object sender, RoutedEventArgs e)
        {
            popup_xepLop.IsOpen = false;
        }

        private void bt_xepLopClick(object sender, RoutedEventArgs e)
        {
            popup_xepLichThi.IsOpen = false;
            popup_xepLop.IsOpen = true;

            ThoiGianHocBUS thoiGianHocBus = new ThoiGianHocBUS();
            if (mListLopDangMo == null)
            {
                mListLopDangMo = new List<Lop_ThoiGianHoc>();
                foreach (LopHoc lop in MainWindow.listLopDangMo)
                {
                    mListLopDangMo.Add(new Lop_ThoiGianHoc(lop, thoiGianHocBus.getThoiGianHocCuaLop(lop.MMaLop)));
                }
            }            
            
            mListLopThoiGian = new List<Lop_ThoiGianHoc>();
            List<CheckBox> listChecked = mListThoiGianRanh.FindAll(i => i.IsChecked == true);
            List<Lop_ThoiGianHoc> listLopDungCTH = new List<Lop_ThoiGianHoc>();
            foreach (Lop_ThoiGianHoc lop in mListLopDangMo)
            {
                if (CTMuonHoc_cb.Text != "")
                {
                    String maCTMuonHoc = mChuongTrinhBUS.getMaCTFromTenCT(CTMuonHoc_cb.SelectedValue.ToString());
                    if (lop.LopHoc.MMaCTHoc.Equals(maCTMuonHoc))
                    {
                        listLopDungCTH.Add(lop);
                        String thuCa;
                        String thu;
                        String ca;
                        for (int i = 0; i < listChecked.Count; i++)
                        {
                            thuCa = listChecked[i].Name;
                            thu = thuCa.Substring(0, thuCa.IndexOf('_'));
                            ca = thuCa.Substring(thuCa.IndexOf('_') + 1);
                            foreach (ThoiGianHoc tgh in lop.ListThoiGianHoc)
                            {
                                if (tgh.MMaCa.Equals(ca) && tgh.MMaThu.Equals(thu))
                                    lop.SoCaDungYeuCau++;
                            }
                        }
                        if (lop.SoCaDungYeuCau > 0)
                            mListLopThoiGian.Add(lop);
                    }
                }
                else
                {
                    String thuCa;
                    String thu;
                    String ca;
                    for (int i = 0; i < listChecked.Count; i++)
                    {
                        thuCa = listChecked[i].Name;
                        thu = thuCa.Substring(0, thuCa.IndexOf('_'));
                        ca = thuCa.Substring(thuCa.IndexOf('_') + 1);
                        foreach (ThoiGianHoc tgh in lop.ListThoiGianHoc)
                        {
                            if (tgh.MMaCa.Equals(ca) && tgh.MMaThu.Equals(thu))
                                lop.SoCaDungYeuCau++;
                        }
                    }
                    if (lop.SoCaDungYeuCau > 0)
                        mListLopThoiGian.Add(lop);
                }                
            }
            if (mListLopThoiGian.Count > 0)
                lv_popup_xepLop.ItemsSource = mListLopThoiGian;
            else if (listLopDungCTH.Count > 0)
                lv_popup_xepLop.ItemsSource = listLopDungCTH;
            else
                lv_popup_xepLop.ItemsSource = mListLopDangMo;
            lv_popup_xepLop.SelectedIndex = lv_xepLop_selectedIndex;
            lv_popup_xepLop.Focus();
        }

        private void bt_popupXepLop_OK_Click(object sender, RoutedEventArgs e)
        {
            popup_xepLop.IsOpen = false;
            mChiTietLop = new ChiTietLopHoc();
            Lop_ThoiGianHoc lop = (Lop_ThoiGianHoc)lv_popup_xepLop.SelectedValue;
            if (lop != null)
            {
                mChiTietLop.MMaLopHoc = lop.MaLop;
                lv_xepLop_selectedIndex = lv_popup_xepLop.SelectedIndex;
                mSelectedTXL = null;
            }
        }

        private void bt_popupXepLop_Clear_Click(object sender, RoutedEventArgs e)
        {
            lv_xepLop_selectedIndex = -1;
            lv_popup_xepLop.SelectedIndex = -1;
            mSelectedLop = null;
        }

        private void bt_popupXepLop_ShowAll_Click(object sender, RoutedEventArgs e)
        {
            lv_popup_xepLop.ItemsSource = mListLopDangMo;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
