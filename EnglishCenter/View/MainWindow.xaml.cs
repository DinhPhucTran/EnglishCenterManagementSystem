﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO;
using BusinessLogicTier;
using System.Text.RegularExpressions;

namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public static List<LopHoc> listLopDangMo;
        public static List<TrinhDo> listTrinhDo;
        public static List<ChuongTrinhHoc> listChuongTrinhHoc;
        public static List<GiangVien> listGiangVien;
        public static List<HocVien> listActiveStudent; // Danh sách học viên đang học
        public static List<HocVien_Lop> listHvDangHocWLop; // Danh sách học viên đang học + lớp
        public static List<HocVien> listNewStudent; // Danh sách học viên chưa xếp lớp
        public static List<HocVien_Lop> listFilterHv;
        public static List<HocVien> listAllStudent;// Danh sách tất cả học viên (đanh học, chưa xếp lớp, không còn học)

        public MainWindow()
        {
            InitializeComponent();
            updateListLopDangMo();
            updateListGiaoVien();
            updateListTrinhDo();
            updateListChuongTrinhHoc();
            updateListHocVien();
            updateLichThi();
            
        }

        private void updateListHocVien()
        {
            listActiveStudent = new List<HocVien>();
            listHvDangHocWLop = new List<HocVien_Lop>();
            foreach (LopHoc lop in listLopDangMo)
            {
                List<String> listMaHV = new HocVienBUS().getMaHVbyMaLop(lop.MMaLop);
                foreach (String ma in listMaHV)
                {
                    listActiveStudent.Add(new HocVienBUS().selectHocVien(ma));
                    HocVien_Lop hv = new HocVien_Lop();
                    hv.HocVien = new HocVienBUS().selectHocVien(ma);
                    hv.Lop = lop;
                    listHvDangHocWLop.Add(hv);
                }
            }

            //Lấy danh sách học viên chưa từng được xếp lớp
            List<LopHoc> listAllLopHoc = new LopHocBUS().getListLopHoc();
            List<HocVien> listHVdaXepLop = new List<HocVien>(); //List học viên đã xếp lớp (cả hv cũ và đang học)
            foreach (LopHoc lop in listAllLopHoc)
            {
                List<String> listMaHV = new HocVienBUS().getMaHVbyMaLop(lop.MMaLop);
                foreach (String ma in listMaHV)
                {
                    listHVdaXepLop.Add(new HocVienBUS().selectHocVien(ma));
                }
            }
            listAllStudent = new HocVienBUS().getListHocVien();
            listNewStudent = listAllStudent.Except(listHVdaXepLop, new MaHvComparer()).ToList<HocVien>();

            lv_dsHocVien.ItemsSource = listHvDangHocWLop.OrderBy(o => o.HocVien.MTenHocVien).ToList();
            tb_numberOfActiveStudent.Text = listActiveStudent.Count.ToString();
            tb_home_NumberOfStudent.Text = listActiveStudent.Count.ToString();
            tb_numberOfNewStudent.Text = listNewStudent.Count.ToString();
        }

        private void updateListLopDangMo()
        {
            listLopDangMo = new LopHocBUS().getListLopHocByTime(DateTime.Now, DateTime.Now);
            tb_home_NumberOfClass.Text = listLopDangMo.Count.ToString();
            cb_filterHV_lop.ItemsSource = listLopDangMo;
        }

        private void updateListChuongTrinhHoc()
        {
            listChuongTrinhHoc = new ChuongTrinhHocBUS().getListChuongTrinhHoc();
            List<ChuongTrinhHoc_SoHV> listHomeChuongTrinhHoc = new List<ChuongTrinhHoc_SoHV>();
            foreach (ChuongTrinhHoc cth in listChuongTrinhHoc)
            {
                int c = 0;
                List<LopHoc> listLop = new List<LopHoc>();
                foreach (LopHoc lop in listLopDangMo)
                {
                    if (lop.MMaCTHoc.Equals(cth.MMaChuongTrinhHoc))
                        listLop.Add(lop);
                }

                foreach (LopHoc lop in listLop)
                {
                    c += new HocVienBUS().countHocVienByMaLop(lop.MMaLop);
                }
                ChuongTrinhHoc_SoHV cthHv = new ChuongTrinhHoc_SoHV();
                cthHv.ChuongTrinhHoc = cth;
                cthHv.SoHocVien = c;
                cthHv.TenCTH = cth.MTenChuongTrinhHoc;
                listHomeChuongTrinhHoc.Add(cthHv);
            }

            lv_home_courses.ItemsSource = listHomeChuongTrinhHoc;
            lvChuongTrinhHoc.ItemsSource = ChuongTrinhHoc_TrinhDo.getList(listHomeChuongTrinhHoc);
            tb_home_NumberOfCourse.Text = listChuongTrinhHoc.Count.ToString();

            //ListView grouping
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvChuongTrinhHoc.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("TrinhDo.MTenTrinhDo");
            view.GroupDescriptions.Add(groupDescription);
            tb_soCTH.Text = listChuongTrinhHoc.Count.ToString();
        }

        public static void updateListTrinhDo()
        {
            listTrinhDo = new TrinhDoBUS().getListTrinhDo();
        }

        private void updateLichThi()
        {
            List<ListItemThiXepLop> listHomeThi = new List<ListItemThiXepLop>();
            List<ThiXepLop> listThiXepLop = new ThiXepLopBUS().getListThiXepLop();
            foreach (ThiXepLop xl in listThiXepLop)
            {
                ListItemThiXepLop item = new ListItemThiXepLop();
                item.day = xl.MNgayThi.Day.ToString() + "-" + xl.MNgayThi.Month.ToString();
                item.year = xl.MNgayThi.Year.ToString();
                item.title = "Thi xếp lớp";
                CaBUS caBus = new CaBUS();
                item.detail = "Phòng " + xl.MMaPhong + ",  "
                    + caBus.selectCa(xl.MCaThi).MThoiGianBatDau.ToShortTimeString() + " - "
                    + caBus.selectCa(xl.MCaThi).MThoiGianKetThuc.ToShortTimeString();
                listHomeThi.Add(item);
            }
            lv_home_schedule.ItemsSource = listHomeThi;
        }

        private void updateListGiaoVien()
        {
            listGiangVien = new GiangVienBUS().getListGiangVien();
            tb_home_NumberOfTeacher.Text = listGiangVien.Count.ToString();
        }

        private void btn_AddStudent_Click(object sender, RoutedEventArgs e)
        {
            NewStudentForm studentForm = new NewStudentForm();
            studentForm.DataChanged += ThemHocVien_DataChanged;
            studentForm.ShowDialog();
        }

        private void btThemCth_click(object sender, RoutedEventArgs e)
        {
            NewCourseForm newCourseForm = new NewCourseForm();
            newCourseForm.ShowDialog();
        }

        #region Extended classes
        internal class MaHvComparer : IEqualityComparer<HocVien>
        {
            public int GetHashCode(HocVien hv)
            {
                if (hv == null)
                {
                    return 0;
                }
                return hv.MMaHocVien.GetHashCode();
            }

            public bool Equals(HocVien x1, HocVien x2)
            {
                if (object.ReferenceEquals(x1, x2))
                {
                    return true;
                }
                if (object.ReferenceEquals(x1, null) ||
                    object.ReferenceEquals(x2, null))
                {
                    return false;
                }
                return x1.MMaHocVien == x2.MMaHocVien;
            }
        }

        public class ChuongTrinhHoc_TrinhDo
        {
            private ChuongTrinhHoc_SoHV mCth;
            private TrinhDo mTd;

            public ChuongTrinhHoc_SoHV CTH
            {
                get { return mCth; }
                set { mCth = value; }
            }

            public TrinhDo TrinhDo
            {
                get { return mTd; }
                set { mTd = value; }
            }
            public String TenTrinhDo
            {
                get { return mTd.MTenTrinhDo; }
            }

            public int SoHV
            {
                get { return mCth.SoHocVien; }
            }

            public static List<ChuongTrinhHoc_TrinhDo> getList(List<ChuongTrinhHoc_SoHV> cths)
            {
                List<ChuongTrinhHoc_TrinhDo> list = new List<ChuongTrinhHoc_TrinhDo>();
                TrinhDoBUS bus = new TrinhDoBUS();
                foreach (ChuongTrinhHoc_SoHV cth in cths)
                {
                    ChuongTrinhHoc_TrinhDo cth_td = new ChuongTrinhHoc_TrinhDo();
                    cth_td.CTH = cth;
                    cth_td.TrinhDo = bus.selectTrinhDo(cth.ChuongTrinhHoc.MMaTrinhDo);
                    list.Add(cth_td);
                }
                return list;

            }
        }
        #endregion

        private void bt_editHvClick(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void bt_viewHvClick(object sender, RoutedEventArgs e)
        {
            popup_detailHV.IsOpen = false;
            Button button = sender as Button;
            HocVien_Lop hocvien = button.DataContext as HocVien_Lop;
           
            tb_popup_tenHV.Text = hocvien.HocVien.MTenHocVien;
            tb_popup_gioiTinh.Text = hocvien.HocVien.MPhai;
            tb_popup_ngaySinh.Text = hocvien.HocVien.MNgaySinh.ToShortDateString();
            tb_popup_email.Text = hocvien.HocVien.MEmail;
            tb_popup_sdt.Text = hocvien.HocVien.MSdt;
            tb_popup_diachi.Text = hocvien.HocVien.MDiaChi;
            if (hocvien.Lop != null)
                tb_popup_lop.Text = hocvien.Lop.MMaLop;
            else
                tb_popup_lop.Text = "";
            popup_detailHV.IsOpen = true;
            
        }

        private void bt_popupClick(object sender, RoutedEventArgs e)
        {
            popup_detailHV.IsOpen = false;
        }

        private void bt_hocPhiHvClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            HocVien_Lop hocvien = button.DataContext as HocVien_Lop;
            if (hocvien.Lop != null)
            {
                PhieuThuHocPhi1HV phieuThu = new PhieuThuHocPhi1HV();
                phieuThu.MaHocVien = hocvien.HocVien.MMaHocVien;
                phieuThu.tb_tenHocVien.Text = hocvien.HocVien.MTenHocVien;
                phieuThu.tb_lop.Text = hocvien.Lop.MMaLop;
                phieuThu.tb_sdt.Text = hocvien.HocVien.MSdt;
                phieuThu.Show();
            }
        }

        private void bt_filterHvClick(object sender, RoutedEventArgs e)
        {
            LopHoc lop = (LopHoc)cb_filterHV_lop.SelectedValue;
            LopHocBUS lopBus = new LopHocBUS();
            if (lop == null)
            {
                listFilterHv = new List<HocVien_Lop>();
                if (tb_filterHV_maHv.Text != "")
                {
                    
                    foreach (HocVien hv in listAllStudent)
                    {
                        if (hv.MMaHocVien.Contains(tb_filterHV_maHv.Text))
                        {
                            listFilterHv.Add(new HocVien_Lop(hv, new LopHocBUS().getLopMoiNhatByMaHV(hv.MMaHocVien)));
                        }
                    }
                    
                    lv_dsHocVien.ItemsSource = listFilterHv;
                }
                else
                {
                    foreach (HocVien hv in listAllStudent)
                    {
                        if ((Regex.IsMatch(ConvertToUnSign(hv.MTenHocVien), ConvertToUnSign(tb_filterHV_ten.Text), RegexOptions.IgnoreCase))
                        && (hv.MSdt.Contains(tb_filterHV_sdt.Text))
                        && (Regex.IsMatch(hv.MEmail, tb_filterHV_email.Text)))
                        {
                            listFilterHv.Add(new HocVien_Lop(hv, lopBus.getLopMoiNhatByMaHV(hv.MMaHocVien)));
                            //MessageBox.Show(lopBus.getLopMoiNhatByMaHV(hv.MMaHocVien).MMaLop);
                        }
                    }

                    if (tb_filterHV_ten.Text != "" || tb_filterHV_sdt.Text != "" || tb_filterHV_email.Text != "")
                        lv_dsHocVien.ItemsSource = listFilterHv;
                    else
                        lv_dsHocVien.ItemsSource = listHvDangHocWLop.OrderBy(o => o.HocVien.MTenHocVien).ToList();
                }

            }
            else
            {
                List<HocVien_Lop> listFilter = new List<HocVien_Lop>();
                if (tb_filterHV_maHv.Text != "")
                {
                    foreach (HocVien_Lop hv in listFilterHv)
                    {
                        if (hv.HocVien.MMaHocVien.Contains(tb_filterHV_maHv.Text))
                            listFilter.Add(hv);
                    }
                    lv_dsHocVien.ItemsSource = listFilter;
                }
                else
                {
                    foreach (HocVien_Lop hv in listFilterHv)
                    {
                        if ((Regex.IsMatch(ConvertToUnSign(hv.HocVien.MTenHocVien), ConvertToUnSign(tb_filterHV_ten.Text), RegexOptions.IgnoreCase))
                            && (hv.HocVien.MSdt.Contains(tb_filterHV_sdt.Text))
                            && (Regex.IsMatch(hv.HocVien.MEmail, tb_filterHV_email.Text)))
                        {
                            listFilter.Add(hv);
                        }

                        if (tb_filterHV_ten.Text != "" || tb_filterHV_sdt.Text != "" || tb_filterHV_email.Text != "")
                            lv_dsHocVien.ItemsSource = listFilter;
                        else
                            lv_dsHocVien.ItemsSource = listFilterHv;
                    }
                }                
            }
        }

        private void tb_filterHv_maHvTextChanged(object sender, RoutedEventArgs e)
        {
            if (tb_filterHV_maHv.Text != "")
            {
                tb_filterHV_ten.IsEnabled = false;
                tb_filterHV_sdt.IsEnabled = false;
                tb_filterHV_email.IsEnabled = false;
            }
            else
            {
                tb_filterHV_ten.IsEnabled = true;
                tb_filterHV_sdt.IsEnabled = true;
                tb_filterHV_email.IsEnabled = true;
            }
        }

        private void cb_filterHV_lopSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LopHoc lop = (LopHoc) cb_filterHV_lop.SelectedValue;
            if (lop != null)
            {
                HocVienBUS bus = new HocVienBUS();
                listFilterHv = new List<HocVien_Lop>();
                List<String> listMaHv = bus.getMaHVbyMaLop(lop.MMaLop);
                List<HocVien> listFilterHvByLop = new List<HocVien>();
                foreach (String ma in listMaHv)
                {
                    HocVien hv = bus.selectHocVien(ma);
                    listFilterHvByLop.Add(hv);
                    listFilterHv.Add(new HocVien_Lop(hv, lop));
                }
                lv_dsHocVien.ItemsSource = listFilterHv;

                tb_filterHV_maHv.ItemsSource = listFilterHvByLop;
                tb_filterHV_maHv.ValueMemberPath = "MMaHocVien";
                tb_filterHV_ten.ItemsSource = listFilterHvByLop;
                tb_filterHV_ten.ValueMemberPath = "MTenHocVien";
                tb_filterHV_email.ItemsSource = listFilterHvByLop;
                tb_filterHV_email.ValueMemberPath = "MEmail";
                tb_filterHV_sdt.ItemsSource = listFilterHvByLop;
                tb_filterHV_sdt.ValueMemberPath = "MSdt";
            }
            else
            {
                tb_filterHV_maHv.ItemsSource = null;
                tb_filterHV_ten.ItemsSource = null;
                tb_filterHV_email.ItemsSource = null;
                tb_filterHV_sdt.ItemsSource = null;

                lv_dsHocVien.ItemsSource = listHvDangHocWLop;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tb_filterHv_maKeyUp(object sender, KeyEventArgs e)
        {
            //Search tự động
            //bt_filterHV.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

            //Search khi ấn Enter
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                bt_filterHV.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                e.Handled = true;
            }
        }

        private void EnterKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                bt_filterHV.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                e.Handled = true;
            }
        }

        public static string ConvertToUnSign(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            //text = text.Replace(" ", "-"); //Comment lại để không đưa khoảng trắng thành ký tự -

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");

            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);

            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        private void bt_hvtnClick(object sender, RoutedEventArgs e)
        {
            List<HocVien_Lop> listHvMoiwLop = new List<HocVien_Lop>();
            LopHocBUS bus = new LopHocBUS();
            foreach (HocVien hv in listNewStudent)
            {
                HocVien_Lop hvl = new HocVien_Lop();
                hvl.HocVien = hv;
                hvl.Lop = bus.getLopMoiNhatByMaHV(hv.MMaHocVien);
                listHvMoiwLop.Add(hvl);
            }
            lv_dsHocVien.ItemsSource = listHvMoiwLop;
        }

        private void bt_hvctClick(object sender, RoutedEventArgs e)
        {
            lv_dsHocVien.ItemsSource = listHvDangHocWLop;
        }

        private void ThemHocVien_DataChanged(object sender, EventArgs e)
        {
            //System.Windows.MessageBox.Show("Updated", "MainWindow");
            updateListHocVien();
        }


    }    
}
