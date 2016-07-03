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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO;
using BusinessLogicTier;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Configuration;

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
        public static List<HocVien_Lop> listHVNoHocPhi;
        public static List<HocVien> listNewStudent; // Danh sách học viên chưa xếp lớp
        public static List<HocVien_Lop> listFilterHv;
        public static List<HocVien> listAllStudent;// Danh sách tất cả học viên (đanh học, chưa xếp lớp, không còn học)
        private DateTime mCurrentDate;
        private List<Ca> mListCa;
        private List<Phong> mListPhong;
        //public static List<Lop_GiangVien> mListLopGV;
        public List<Lop_Gv_Cth> mListLopGV;
        private TrinhDoBUS mTrinhDoBus;
        private ChuongTrinhHocBUS mCTHBus;
        private HocVienBUS mHocVienBus;
        private LopHocBUS mLopHocBus;
        private User mUser;
        private DateTime mTabReportCurrentDate;
        private List<ChuongTrinhHoc_SoHV> mListChuongTrinhHoc_soHv;
        private List<HocVien_Lop> mListHvMoiwLop;

        public MainWindow()
        {
            InitializeComponent();
            
            mTrinhDoBus = new TrinhDoBUS();
            mCTHBus = new ChuongTrinhHocBUS();
            mHocVienBus = new HocVienBUS();
            mLopHocBus = new LopHocBUS();

            //Update các danh sách
            updateListUser();
            updateListLopDangMo();
            updateListGiaoVien();
            updateListTrinhDo();
            updateListChuongTrinhHoc();
            updateListHocVien();
            upDateListHvNoHP();
            updateLichThi();            

            //Tab Lớp
            mCurrentDate = DateTime.Today;
            initTKB();
            fillTKB();

            //Tab Thống kê
            mTabReportCurrentDate = DateTime.Today;
            datePicker_tabReport_currentDate.SelectedDate = mTabReportCurrentDate;
            updateThongKeNgay();

            List<int> listThang = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            List<int> listNam = new List<int>();
            for (int i = 2000; i <= 2099; i++)
            {
                listNam.Add(i);
            }
            cb_tabReport_currentMonth.ItemsSource = listThang;
            cb_tabReport_currentMonth.SelectedValue = mTabReportCurrentDate.Month;
            cb_tabReport_currentYear.ItemsSource = listNam;
            cb_tabReport_currentYear.SelectedValue = mTabReportCurrentDate.Year;
            updateThongKeThang();
            updateChartHvThang();
            updateChartThuThang();
            updateChartGioiTinh();
            updateChartCthSoHv();

            //Tab Cài đặt
            try
            {
                tabControl.SelectedIndex = Properties.Settings.Default.DefaultTab;
            }
            catch (Exception)
            {

            }
            List<string> listTabs = new List<string>();
            listTabs.Add("Trang chủ");
            listTabs.Add("Học viên");
            listTabs.Add("Lớp");
            listTabs.Add("Thi");
            listTabs.Add("Học phí");
            listTabs.Add("Chương trình học");
            listTabs.Add("Giáo viên");
            listTabs.Add("Thống kê");
            listTabs.Add("Cài đặt");
            cb_defaultTab.ItemsSource = listTabs;
            try
            {
                cb_defaultTab.SelectedIndex = Properties.Settings.Default.DefaultTab;
            }
            catch (Exception)
            {

            }
        }

        public User User
        {
            get { return mUser; }
            set { mUser = value; }
        }

        //Update danh sách học viên
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

            listHvDangHocWLop = new List<HocVien_Lop>(listHvDangHocWLop.OrderBy(o => o.TenHocVien).ToList()); //Sắp xếp danh sách học viên theo tên

            lv_dsHocVien.ItemsSource = listHvDangHocWLop;
            tb_numberOfActiveStudent.Text = listActiveStudent.Count.ToString();
            tb_home_NumberOfStudent.Text = listActiveStudent.Count.ToString();
            tb_numberOfNewStudent.Text = listNewStudent.Count.ToString();
        }

        //Update danh sách lớp đang mở
        private void updateListLopDangMo()
        {
            listLopDangMo = new LopHocBUS().getListLopHocByTime(DateTime.Now, DateTime.Now);
            tb_home_NumberOfClass.Text = listLopDangMo.Count.ToString();
            cb_filterHV_lop.ItemsSource = listLopDangMo;

            //Tab Lớp
            mListLopGV = new List<Lop_Gv_Cth>();
            GiangVienBUS gvBus = new GiangVienBUS();
            foreach (LopHoc lop in listLopDangMo)
            {
                mListLopGV.Add(new Lop_Gv_Cth(lop, gvBus.selectGiangVien(lop.MMaGiangVien)));
            }
            lv_tabLop_dsLop.ItemsSource = mListLopGV;
            tb_soLopDangMo.Text = listLopDangMo.Count.ToString();            
        }

        //Update danh sách học viên nợ học phí
        private void upDateListHvNoHP()
        {
            listHVNoHocPhi = new List<HocVien_Lop>();
            ChiTietLopHocBUS ctBus = new ChiTietLopHocBUS();
            List<ChiTietLopHoc> listChiTietLop = new List<ChiTietLopHoc>();
            foreach (LopHoc lop in listLopDangMo)
            {
                List<ChiTietLopHoc> ct = ctBus.selectChiTietLopHoc(lop.MMaLop);
                listChiTietLop.AddRange(ct);
            }
            listHVNoHocPhi = new List<HocVien_Lop>();
            foreach (ChiTietLopHoc ctl in listChiTietLop)
            {
                if (ctl.MSoTienNo > 0)
                    listHVNoHocPhi.Add(new HocVien_Lop(mHocVienBus.selectHocVien(ctl.MMaHocVien), mLopHocBus.selectLopHoc(ctl.MMaLopHoc)));
            }
            lv_dsHocVien_HP.ItemsSource = listHVNoHocPhi;
            tb_soHvNoHp.Text = listHVNoHocPhi.Count.ToString();
        }

        //Update danh sách chương trình học
        private void updateListChuongTrinhHoc()
        {
            listChuongTrinhHoc = mCTHBus.getListChuongTrinhHoc();
            mListChuongTrinhHoc_soHv = new List<ChuongTrinhHoc_SoHV>();
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
                    c += mHocVienBus.countHocVienByMaLop(lop.MMaLop);
                }
                ChuongTrinhHoc_SoHV cthHv = new ChuongTrinhHoc_SoHV();
                cthHv.ChuongTrinhHoc = cth;
                cthHv.SoHocVien = c;
                cthHv.TenCTH = cth.MTenChuongTrinhHoc;
                mListChuongTrinhHoc_soHv.Add(cthHv);
            }

            lv_home_courses.ItemsSource = mListChuongTrinhHoc_soHv;
            lvChuongTrinhHoc.ItemsSource = ChuongTrinhHoc_TrinhDo.getList(mListChuongTrinhHoc_soHv);
            tb_home_NumberOfCourse.Text = listChuongTrinhHoc.Count.ToString();

            //Nhóm các chương trình học theo trình độ
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvChuongTrinhHoc.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("TrinhDo.MTenTrinhDo");
            view.GroupDescriptions.Add(groupDescription);
            tb_soCTH.Text = listChuongTrinhHoc.Count.ToString();
        }

        //Update danh sách trình độ
        private void updateListTrinhDo()
        {
            listTrinhDo = mTrinhDoBus.getListTrinhDo();
            tb_soTrinhDo.Text = listTrinhDo.Count.ToString();
        }

        //Update lịch thi xếp lớp
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
            lv_exams_schedule.ItemsSource = listHomeThi;
            tb_soTXL.Text = listHomeThi.Count.ToString();
        }

        //Update danh sách giáo viên
        private void updateListGiaoVien()
        {
            listGiangVien = new GiangVienBUS().getListGiangVien();
            tb_home_NumberOfTeacher.Text = listGiangVien.Count.ToString();
            lv_dsGiangVien.ItemsSource = listGiangVien;
            tb_soGiangVien.Text = listGiangVien.Count.ToString();
        }

        //Thống kê theo ngày trong tab Thống kê
        private void updateThongKeNgay()
        {
            int soHv = 0;
            double tongThu = 0;
            List<DateTime> listHvNgay = mHocVienBus.getListNgayTiepNhan();
            foreach (DateTime date in listHvNgay)
            {
                if (date.Date == mTabReportCurrentDate.Date)
                {
                    soHv++;
                }
            }
            tb_tabReport_soHvNgay.Text = soHv.ToString();
            

            List<DTO.PhieuThuHocPhi> listThuNgay = new PhieuThuHocPhiBUS().getDanhSachPhieu();
            foreach (DTO.PhieuThuHocPhi phieu in listThuNgay)
            {
                if (phieu.MNgayLap.Date == mTabReportCurrentDate)
                {
                    tongThu += phieu.MSoTienDong;
                }
            }
            tb_tabReport_tongThuNgay.Text = tongThu.ToString();
        }

        //Thống kê theo tháng trong tab Thống kê
        private void updateThongKeThang()
        {
            int soHv = 0;
            double tongThu = 0;
            
            if (cb_tabReport_currentYear.SelectedValue != null && cb_tabReport_currentMonth.SelectedValue != null)
            {
                List<DateTime> listHv = mHocVienBus.getListNgayTiepNhan();
                foreach (DateTime date in listHv)
                {
                    if (date.Month == (int)cb_tabReport_currentMonth.SelectedValue && date.Year == (int)cb_tabReport_currentYear.SelectedValue)
                    {
                        soHv++;
                    }
                }
                tb_tabReport_soHvThang.Text = soHv.ToString();


                List<DTO.PhieuThuHocPhi> listThuNgay = new PhieuThuHocPhiBUS().getDanhSachPhieu();
                foreach (DTO.PhieuThuHocPhi phieu in listThuNgay)
                {
                    if (phieu.MNgayLap.Month == (int)cb_tabReport_currentMonth.SelectedValue && phieu.MNgayLap.Year == (int)cb_tabReport_currentYear.SelectedValue)
                    {
                        tongThu += phieu.MSoTienDong;
                    }
                }
                tb_tabReport_tongThuThang.Text = tongThu.ToString();
            }
        }

        //Update biểu đồ học viên theo tháng của từng năm
        private void updateChartHvThang()
        {
            if (cb_tabReport_currentYear.SelectedValue != null)
            {
                tb_tabReport_titleChartHvThang.Text = "Học viên đăng kí mới hàng tháng (" + cb_tabReport_currentYear.SelectedValue.ToString() + ")";
                List<DateTime> listNgayTiepNhan = mHocVienBus.getListNgayTiepNhan();
                List<KeyValuePair<int, int>> valueList = new List<KeyValuePair<int, int>>();
                int[] listHvThang = new int[13];
                for (int i = 1; i <= 12; i++)
                {
                    listHvThang[i] = 0;
                    foreach (DateTime date in listNgayTiepNhan)
                    {
                        if (date.Year == (int)cb_tabReport_currentYear.SelectedValue && date.Month == i)
                            listHvThang[i]++;
                    }
                    valueList.Add(new KeyValuePair<int, int>(i, listHvThang[i]));
                }

                chart_hvThang.DataContext = valueList;
                
            }
        }

        //Update biểu đồ doanh thu theo tháng của từng năm
        private void updateChartThuThang()
        {
            if (cb_tabReport_currentYear.SelectedValue != null)
            {
                tb_tabReport_titleChartThuThang.Text = "Doanh thu hàng tháng (" + cb_tabReport_currentYear.SelectedValue.ToString() + ")";
                List<DTO.PhieuThuHocPhi> listPhieuThu = new PhieuThuHocPhiBUS().getDanhSachPhieu();
                List<KeyValuePair<int, double>> valueList = new List<KeyValuePair<int, double>>();
                double[] listThuThang = new double[13];
                for (int i = 1; i <= 12; i++)
                {
                    listThuThang[i] = 0;
                    foreach (DTO.PhieuThuHocPhi phieu in listPhieuThu)
                    {
                        if (phieu.MNgayLap.Year == (int)cb_tabReport_currentYear.SelectedValue && phieu.MNgayLap.Month == i)
                            listThuThang[i] += phieu.MSoTienDong;
                    }
                    valueList.Add(new KeyValuePair<int, double>(i, listThuThang[i]));
                }

                chart_thuThang.DataContext = valueList;

            }
        }

        //Biểu đồ tỉ lệ giới tính học viên
        private void updateChartGioiTinh()
        {
            List<KeyValuePair<String, int>> valueList = new List<KeyValuePair<String, int>>();
            int soHvNu = 0;
            int soHvNam = 0;
            int khac = 0;
            foreach (HocVien hv in listActiveStudent)
            {
                if (hv.MPhai.Equals("Nữ"))
                    soHvNu++;
                else if (hv.MPhai.Equals("Nam"))
                    soHvNam++;
                else
                    khac++;
            }
            valueList.Add(new KeyValuePair<String, int>("Nam", soHvNam));
            valueList.Add(new KeyValuePair<String, int>("Nữ", soHvNu));            
            valueList.Add(new KeyValuePair<String, int>("Khác", khac));
            chart_gioiTinh.DataContext = valueList;
        }

        //Biểu đồ số lượng học viên của các chương trình học
        private void updateChartCthSoHv()
        {
            List<KeyValuePair<String, int>> valueList = new List<KeyValuePair<String, int>>();
            foreach (ChuongTrinhHoc_SoHV cth in mListChuongTrinhHoc_soHv)
            {
                valueList.Add(new KeyValuePair<string, int>(cth.TenCTH, cth.SoHocVien));
            }
            chart_CthSoHv.DataContext = valueList;
        }

        //Thêm học viên mới
        private void btn_AddStudent_Click(object sender, RoutedEventArgs e)
        {
            NewStudentForm studentForm = new NewStudentForm();
            studentForm.DataChanged += ThemHocVien_DataChanged; //Update danh sách học viên sau khi bấm lưu
            studentForm.ShowDialog();
        }

        //Thêm chương trình học
        private void btThemCth_click(object sender, RoutedEventArgs e)
        {
            NewCourseForm newCourseForm = new NewCourseForm();
            newCourseForm.ShowDialog();
        }


        //Thêm trình độ
        private void btThemTrinhDo_click(object sender, RoutedEventArgs e)
        {
            NewLevelForm levelForm = new NewLevelForm();
            levelForm.ShowDialog();
        }

        //Các clas mở rộng để hiển thị thêm thông tin trong các danh sách
        #region Extended classes
        public class MaHvComparer : IEqualityComparer<HocVien>
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

            public ChuongTrinhHoc CTH
            {
                get { return mCth.ChuongTrinhHoc; }
            }

            public ChuongTrinhHoc_SoHV CTH_SoHV
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
                    cth_td.CTH_SoHV = cth;
                    cth_td.TrinhDo = bus.selectTrinhDo(cth.ChuongTrinhHoc.MMaTrinhDo);
                    list.Add(cth_td);
                }
                return list;

            }
        }

        public class Lop_Gv_Cth
        {
            Lop_GiangVien mLopGv;
            string mTenCth;

            public Lop_Gv_Cth(LopHoc lop, GiangVien gv)
            {
                mLopGv = new Lop_GiangVien(lop, gv);
                mTenCth = new ChuongTrinhHocBUS().getTenChuongTrinhHocByMa(lop.MMaCTHoc);
            }

            public LopHoc Lop
            {
                get { return mLopGv.Lop; }
            }

            public Lop_GiangVien Lop_GiangVien
            {
                get { return mLopGv; }   
            }

            public string TenGiangVien
            {
                get { return mLopGv.TenGiangVien; }
            }

            public string StringNgayBD
            {
                get { return mLopGv.StringNgayBD; }
            }

            public string StringNgayKT
            {
                get { return mLopGv.StringNgayKT; }
            }

            public string StringNgayKhaiGiang
            {
                get { return mLopGv.StringNgayKhaiGiang; }
            }

            public string TenChuongTrinhHoc
            {
                get { return mTenCth; }
            }
        }

        public class User_Permission
        {
            private User mUser;
            private Permission mPer;

            public User_Permission(User user, Permission per)
            {
                mUser = user;
                mPer = per;
            }

            public User_Permission(User user)
            {
                mUser = user;
                mPer = new PermissionBUS().selectPermissionById(mUser.MPermission);
            }

            public User User
            {
                get { return mUser; }
                set { mUser = value; }
            }

            public string UserName
            {
                get { return mUser.MUsername; }
            }

            public string PermissionName
            {
                get { return mPer.MNamePermision; }
            }
        }
        #endregion

        //Sửa thông tin học viên
        private void bt_editHvClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            HocVien_Lop hv = button.DataContext as HocVien_Lop;
            SuaHocVien sua = new SuaHocVien(hv.HocVien);
            sua.DataChanged += ThemHocVien_DataChanged;
            sua.ShowDialog();
        }

        //Hiện popup thông tin chi tiết của học viên
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

        //Đóng popup
        private void bt_popupClick(object sender, RoutedEventArgs e)
        {
            popup_detailHV.IsOpen = false;
        }

        //Thu học phí
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
                phieuThu.tb_soTienNo.Text = new ChiTietLopHocBUS().selectChiTietLopHocByMaHV(hocvien.HocVien.MMaHocVien).MSoTienNo.ToString();
                phieuThu.Show();
            }
        }

        //Lọc danh sách học viên theo các thông tin tìm kiếm
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
                        }
                    }

                    if (tb_filterHV_ten.Text != "" || tb_filterHV_sdt.Text != "" || tb_filterHV_email.Text != "")
                        lv_dsHocVien.ItemsSource = listFilterHv;
                    else
                        lv_dsHocVien.ItemsSource = listHvDangHocWLop;
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
                listFilterHv = new List<HocVien_Lop>();
                List<String> listMaHv = mHocVienBus.getMaHVbyMaLop(lop.MMaLop);
                List<HocVien> listFilterHvByLop = new List<HocVien>();
                foreach (String ma in listMaHv)
                {
                    HocVien hv = mHocVienBus.selectHocVien(ma);
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

        //Chỉ cho phép nhập số trong textbox
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

        //Chuyển string thành không dấu
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

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");

            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);

            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        //Hiện danh sách học viên tiềm năng
        private void bt_hvtnClick(object sender, RoutedEventArgs e)
        {
            if (mListHvMoiwLop == null)
            {
                mListHvMoiwLop = new List<HocVien_Lop>();
                LopHocBUS bus = new LopHocBUS();
                foreach (HocVien hv in listNewStudent)
                {
                    HocVien_Lop hvl = new HocVien_Lop();
                    hvl.HocVien = hv;
                    hvl.Lop = bus.getLopMoiNhatByMaHV(hv.MMaHocVien);
                    mListHvMoiwLop.Add(hvl);
                }
                mListHvMoiwLop = new List<HocVien_Lop>(mListHvMoiwLop.OrderBy(o => o.TenHocVien).ToList());
            }
            lv_dsHocVien.ItemsSource = mListHvMoiwLop;
        }

        //Hiện danh sách học viên chính thức
        private void bt_hvctClick(object sender, RoutedEventArgs e)
        {
            lv_dsHocVien.ItemsSource = listHvDangHocWLop;
        }

        private void ThemHocVien_DataChanged(object sender, EventArgs e)
        {
            updateListHocVien();
            upDateListHvNoHP();
        }

        private void bt_popupLopTGH_Close_Click(object sender, RoutedEventArgs e)
        {
            popup_lopTGH.IsOpen = false;
        }

        //Xem thời gian học của lớp
        private void bt_dsLop_ViewTGH(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Lop_Gv_Cth lopGV = button.DataContext as Lop_Gv_Cth;
            popup_lopTGH.IsOpen = false;
            List<ThoiGianHoc> listTGH = new ThoiGianHocBUS().getThoiGianHocCuaLop(lopGV.Lop.MMaLop);
            if (listTGH != null)
            {
                if (listTGH.Count > 0)
                {
                    tb_popupTGH.Text = "Thời gian học lớp " + lopGV.Lop.MMaLop;
                    lv_popupTGH_ThoiGianHoc.ItemsSource = listTGH;
                    popup_lopTGH.IsOpen = true;
                }                
            }
        }

        //Khởi tạo grid thời khóa biểu
        private void initTKB()
        {
            mListCa = new CaBUS().getAllCa();
            bt_soCa.Content = mListCa.Count.ToString() + " Ca";
            mListPhong = (new PhongBUS().getListPhong()).OrderBy(o => Int32.Parse(o.MMaPhong)).ToList();
            grid_TKB.RowDefinitions.Add(new RowDefinition());
            grid_TKB.ColumnDefinitions.Add(new ColumnDefinition());
            foreach (Phong phong in mListPhong)
            {
                grid_TKB.RowDefinitions.Add(new RowDefinition());
            }
            foreach (Ca ca in mListCa)
            {
                grid_TKB.ColumnDefinitions.Add(new ColumnDefinition());
            }
            tb_soPhong.Text = mListPhong.Count.ToString();
        }

        //Hiện các lớp vào thời khóa biểu theo ngày được chọn
        private void fillTKB()
        {
            grid_TKB.Children.Clear();

            for (int i = 0; i < mListCa.Count; i++)
            {
                TextBlock tbCa = new TextBlock();
                tbCa.Text = "Ca " + (Int32.Parse(mListCa[i].MMaCa) + 1) + "\n" + mListCa[i].toStringTgBD_TgKT();
                tbCa.Foreground = Brushes.Black;
                tbCa.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                tbCa.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                tbCa.FontSize = 15;
                tbCa.TextAlignment = TextAlignment.Center;
                tbCa.Padding = new Thickness(5, 0, 5, 0);
                tbCa.Background = new SolidColorBrush(Color.FromRgb(226, 224, 224));
                Grid.SetColumn(tbCa, i + 1);
                Grid.SetRow(tbCa, 0);
                grid_TKB.Children.Add(tbCa);
            }

            for (int i = 0; i < mListPhong.Count; i++)
            {
                TextBlock tbPhong = new TextBlock();
                tbPhong.Text = mListPhong[i].MTenPhong;
                tbPhong.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                tbPhong.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                tbPhong.Padding = new Thickness(10, 5, 10, 5);
                tbPhong.FontSize = 15;
                tbPhong.Foreground = Brushes.Black;
                tbPhong.Background = new SolidColorBrush(Color.FromRgb(226, 224, 224));
                Grid.SetRow(tbPhong, i + 1);
                Grid.SetColumn(tbPhong, 0);
                grid_TKB.Children.Add(tbPhong);
            }

            String today = mCurrentDate.ToString("dddd", new CultureInfo("en-US"));
            tb_currentDate.Text = today + ", " + mCurrentDate.ToShortDateString();
            List<Lop_ThoiGianHoc> listLopTGH = new List<Lop_ThoiGianHoc>();
            ThoiGianHocBUS thoiGianHocBus = new ThoiGianHocBUS();
            foreach (LopHoc lop in listLopDangMo)
                listLopTGH.Add(new Lop_ThoiGianHoc(lop, thoiGianHocBus.getThoiGianHocCuaLop(lop.MMaLop)));
            foreach (Lop_ThoiGianHoc lop in listLopTGH)
            {
                foreach (ThoiGianHoc tgh in lop.ListThoiGianHoc)
                {
                    if (tgh.MMaThu.Equals(today) && lop.LopHoc.MNgayBatDau < mCurrentDate && lop.LopHoc.MNgayKetThuc > mCurrentDate)
                    {
                        TextBlock tb = new TextBlock();
                        tb.Text = lop.MaLop;
                        tb.Background = Brushes.Blue;
                        tb.Foreground = Brushes.White;
                        tb.TextAlignment = TextAlignment.Center;
                        tb.Padding = new Thickness(0, 7, 0, 5);
                        tb.ToolTip = "Lớp: " + lop.MaLop + 
                            "\nNgày bắt đầu: " + lop.LopHoc.MNgayBatDau.ToShortDateString() +
                            "\nNgày kết thúc: " + lop.LopHoc.MNgayKetThuc.ToShortDateString();
                        Grid.SetColumn(tb, Int32.Parse(tgh.MMaCa) + 1);
                        Grid.SetRow(tb, Int32.Parse(lop.LopHoc.MMaPhong));
                        grid_TKB.Children.Add(tb);
                    }
                }
            }
        }

        //Trở về ngày trước đó trong thời khóa biểu
        private void bt_preDay_click(object sender, RoutedEventArgs e)
        {
            mCurrentDate = mCurrentDate.AddDays(-1);
            fillTKB();
        }

        //Đến ngày tiếp theo trong thời khóa biểu
        private void bt_nextDay_click(object sender, RoutedEventArgs e)
        {
            mCurrentDate = mCurrentDate.AddDays(1);
            fillTKB();
        }

        //Chọn ngày TKB
        private void datePicker_currentDate_selectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            mCurrentDate = (DateTime)datePicker_currentDate.SelectedDate;
            fillTKB();
        }

        private void tb_lopSearch_keyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                bt_lopSearch.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                e.Handled = true;
            }
        }

        //Tìm kiếm lớp mã lớp, tên giảng viên hoặc tên chương trình học
        private void bt_lopSearch_click(object sender, RoutedEventArgs e)
        {
            List<Lop_Gv_Cth> listLopSearch = new List<Lop_Gv_Cth>();
            if(tb_lopSearch.Text == "")
                lv_tabLop_dsLop.ItemsSource = mListLopGV;
            else {
                foreach (Lop_Gv_Cth lop in mListLopGV)
                {
                    if(Regex.IsMatch(lop.Lop.MMaLop, tb_lopSearch.Text, RegexOptions.IgnoreCase)
                        || Regex.IsMatch(ConvertToUnSign(lop.TenGiangVien), ConvertToUnSign(tb_lopSearch.Text), RegexOptions.IgnoreCase)
                        || Regex.IsMatch(ConvertToUnSign(lop.TenChuongTrinhHoc), ConvertToUnSign(tb_lopSearch.Text), RegexOptions.IgnoreCase))
                    {
                        listLopSearch.Add(lop);
                    }
                }
                lv_tabLop_dsLop.ItemsSource = listLopSearch;
            }
        }

        //Thêm lớp mới
        private void bt_themLop_click(object sender, RoutedEventArgs e)
        {
            NewClassForm classForm = new NewClassForm();
            classForm.DataChanged += ThemLop_DataChanged;
            classForm.ShowDialog();
        }

        //Thêm phòng học
        private void bt_themPhong_click(object sender, RoutedEventArgs e)
        {
            NewClassRoom classRoom = new NewClassRoom();
            classRoom.ShowDialog();
        }

        //Thêm lịch thi xếp lớp
        private void bt_themTXL_click(object sender, RoutedEventArgs e)
        {
            ThemLichThi themLichThi = new ThemLichThi();
            themLichThi.ShowDialog();
        }

        //Thêm đề thi (demo)
        private void bt_themDeThi_click(object sender, RoutedEventArgs e)
        {
            ThemDeThi themDeThi = new ThemDeThi();
            themDeThi.ShowDialog();
        }

        //Nhập kết quả thi xếp lớp
        private void bt_nhapKetQuaTXL_click(object sender, RoutedEventArgs e)
        {
            NhapKetQuaThiXL nhapKQ = new NhapKetQuaThiXL();
            nhapKQ.ShowDialog();
        }

        private void ThemLop_DataChanged(object sender, EventArgs e)
        {
            updateListLopDangMo();
            fillTKB();
        }

        //Update danh sách user
        private void updateListUser()
        {
            List<User> userList = new UserBUS().getListUser();
            List<User_Permission> listUser_Per = new List<User_Permission>();
            foreach (User user in userList)
                listUser_Per.Add(new User_Permission(user));
            lv_dsUser.ItemsSource = listUser_Per;
        }

        private void tb_gvSearch_keyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                bt_gvSearch.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                e.Handled = true;
            }
        }

        //Tìm giáo viên theo mã hoặc tên giáo viên
        private void bt_gvSearch_click(object sender, RoutedEventArgs e)
        {
            List<GiangVien> listgvSearch = new List<GiangVien>();
            if (tb_gvSearch.Text == "")
                lv_dsGiangVien.ItemsSource = listGiangVien;
            else
            {
                foreach (GiangVien gv in listGiangVien)
                {
                    if (Regex.IsMatch(gv.MMaGiangVien, tb_gvSearch.Text, RegexOptions.IgnoreCase)
                        || Regex.IsMatch(ConvertToUnSign(gv.MTenGiangVien), ConvertToUnSign(tb_gvSearch.Text), RegexOptions.IgnoreCase))
                    {
                        listgvSearch.Add(gv);
                    }
                }
                lv_dsGiangVien.ItemsSource = listgvSearch;
            }
        }

        //Hiện danh sách các lớp mà giáo viên đang dạy
        private void lv_dsGiangVien_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GiangVien gv = (GiangVien)lv_dsGiangVien.SelectedValue;
            try
            {
                lv_lopByGv.ItemsSource = new LopHocBUS().getListLopHocByMaGiangVien(gv.MMaGiangVien);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }

        private void bt_popupChiTietLop_close(object sender, RoutedEventArgs e)
        {
            popup_chiTietLop.IsOpen = false;
        }

        //Xem chi tiết lớp học
        private void bt_dsLop_viewChiTietLop(object sender, RoutedEventArgs e)
        {
            popup_chiTietLop.IsOpen = false;
            Button button = sender as Button;
           // Lop_GiangVien lop = button.DataContext as Lop_GiangVien;
            Lop_Gv_Cth lop = button.DataContext as Lop_Gv_Cth;
            List<ChiTietLopHoc> listCTL = new ChiTietLopHocBUS().selectChiTietLopHoc(lop.Lop.MMaLop);
            List<ChiTietLopHoc_TenHV> listCTL_Ten = new List<ChiTietLopHoc_TenHV>();
            foreach (ChiTietLopHoc ct in listCTL)
            {
                ChiTietLopHoc_TenHV ten = new ChiTietLopHoc_TenHV();
                ten.ChiTietLop = ct;
                ten.TenHocVien = mHocVienBus.selectHocVien(ct.MMaHocVien).MTenHocVien;
                listCTL_Ten.Add(ten);
            }
            lv_popupChiTietLop.ItemsSource = listCTL_Ten;
            tb_popupChiTietLop.Text = "Chi tiết lớp " + lop.Lop.MMaLop;
            popup_chiTietLop.IsOpen = true;
        }

        //Lập phiếu thu học phí cho học viên được chọn trong tab Học phí
        private void item_dsNoHP_MouseLeftDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                Grid grid = sender as Grid;
                HocVien_Lop hocvien = grid.DataContext as HocVien_Lop;
                if (hocvien.Lop != null)
                {
                    PhieuThuHocPhi1HV phieuThu = new PhieuThuHocPhi1HV();
                    phieuThu.MaHocVien = hocvien.HocVien.MMaHocVien;
                    phieuThu.tb_tenHocVien.Text = hocvien.HocVien.MTenHocVien;
                    phieuThu.tb_lop.Text = hocvien.Lop.MMaLop;
                    phieuThu.tb_sdt.Text = hocvien.HocVien.MSdt;

                    phieuThu.DataChanged += ThuHocPhi_DataChanged;
                    phieuThu.Show();
                }
                e.Handled = true;
            }
        }

        //Lập phiếu thu học phí với học viên được chọn sau
        private void bt_lapPhieuThuHP_click(object sender, RoutedEventArgs e)
        {
            PhieuThuHocPhi phieu = new PhieuThuHocPhi();
            phieu.DataChanged += ThuHocPhi_DataChanged;
            phieu.ShowDialog();
        }

        private void ThuHocPhi_DataChanged(object sender, EventArgs e)
        {
            upDateListHvNoHP();
        }

        private void bt_soCa_click(object sender, RoutedEventArgs e)
        {
            DanhSachCa dsCa = new DanhSachCa();
            dsCa.ShowDialog();
        }

        //Xem chi tiết user (ở góc trên bên phải màn hình)
        private void bt_userInfo_click(object sender, RoutedEventArgs e)
        {
            if (mUser != null)
            {
                tb_popupUserInfo_username.Text = mUser.MUsername;
                tb_popupUserInfo_permission.Text = new UserBUS().selectPermissonById(mUser.MPermission).MNamePermision;
            }
            if(popup_userInfo.IsOpen == true)
                popup_userInfo.IsOpen = false;
            else
                popup_userInfo.IsOpen = true;
        }

        //Thêm giáo viên mới
        private void bt_themGiangVien_click(object sender, RoutedEventArgs e)
        {
            ThemGiangVien them = new ThemGiangVien();
            them.DataChanged += ThemGiangVien_DataChanged;
            them.ShowDialog();
        }

        private void ThemGiangVien_DataChanged(object sender, EventArgs e)
        {
            updateListGiaoVien();
        }

        //Sửa thông tin chương trình học
        private void bt_editCTH_click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ChuongTrinhHoc_TrinhDo cth = button.DataContext as ChuongTrinhHoc_TrinhDo;
            NewCourseForm cthForm = new NewCourseForm(cth.CTH);
            cthForm.ShowDialog();
        }

        //Sửa thông tin giáo viên
        private void bt_editGv_click(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            GiangVien gv = bt.DataContext as GiangVien;
            ThemGiangVien form = new ThemGiangVien(gv);
            form.DataChanged += ThemGiangVien_DataChanged;
            form.ShowDialog();
        }

        //Các nút xem chi tiết trên tab Home
        private void bt_toTabHocVien_click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void bt_toTabCTH_click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void bt_toTabLop_click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }

        private void bt_toTabGV_click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 6;
        }

        //Đăng xuất (trên popup xem chi tiết user ở góc trên bên phải màn hình)
        private void logout_btn_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lg = new LoginWindow();
            this.Close();
            lg.Show();
        }

        //Thêm user (chỉ quyền Admin mới được thêm user)
        private void btn_ThemUser_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow su = new SignUpWindow();
            su.DataChanged += ThemUser_DataChanged;
            su.Show();
        }

        private void ThemUser_DataChanged(object sender, EventArgs e)
        {
            updateListUser();
        }


        private void mainWindow_activated(object sender, EventArgs e)
        {
            if (mUser != null)
                tb_header_username.Text = mUser.MUsername;
        }

        private void datePicker_tabReport_currentDate_selectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            mTabReportCurrentDate = (DateTime)datePicker_tabReport_currentDate.SelectedDate;
            updateThongKeNgay();
        }

        private void cb_tabReport_currentMonth_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateThongKeThang();
        }

        private void cb_tabReport_currentYear_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateThongKeThang();
            updateChartHvThang();
            updateChartThuThang();
        }

        //Đổi mật khẩu ở tab Cài đặt
        private void bt_doiMatKhau_click(object sender, RoutedEventArgs e)
        {
            DoiMatKhau mk = new DoiMatKhau();
            mk.User = mUser;
            mk.ShowDialog();
        }

        private void bt_thi_xepLop_click(object sender, RoutedEventArgs e)
        {
            KetQuaThiXepLop kq = new KetQuaThiXepLop();
            kq.ShowDialog();
        }

        //Đổi tab mặc định khi khởi động
        private void cb_defaultTab_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.DefaultTab = cb_defaultTab.SelectedIndex;
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại sau.", "Thông báo");
                cb_defaultTab.SelectedIndex = -1;
            }
        }
        
    }    
}
