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

namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<TrinhDo> listTrinhDo = new TrinhDoBUS().getListTrinhDo();
            List<LopHoc> listLopDangMo = new LopHocBUS().getListLopHocByTime(DateTime.Now, DateTime.Now);
            List<ChuongTrinhHoc> listChuongTrinhHoc = new ChuongTrinhHocBUS().getListChuongTrinhHoc();
            List<GiangVien> listGiangVien = new GiangVienBUS().getListGiangVien();

            List<HocVien> listActiveStudent = new List<HocVien>();
            foreach (LopHoc lop in listLopDangMo)
            {
                List<String> listMaHV = new HocVienBUS().getMaHVbyMaLop(lop.MMaLop);
                foreach (String ma in listMaHV)
                {
                    listActiveStudent.Add(new HocVienBUS().selectHocVien(ma));
                }
            }

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
                cthHv.NumberOfStudent = c.ToString();
                cthHv.TenCTH = cth.MTenChuongTrinhHoc;
                listHomeChuongTrinhHoc.Add(cthHv);
            }
            lv_home_courses.ItemsSource = listHomeChuongTrinhHoc;

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

            lv_dsHocVien.ItemsSource = listActiveStudent;
            lvChuongTrinhHoc.ItemsSource = listTrinhDo;
            tb_numberOfActiveStudent.Text = listActiveStudent.Count.ToString();
            tb_home_NumberOfStudent.Text = listActiveStudent.Count.ToString();
            tb_home_NumberOfCourse.Text = listChuongTrinhHoc.Count.ToString();
            tb_home_NumberOfTeacher.Text = listGiangVien.Count.ToString();
            tb_home_NumberOfClass.Text = listLopDangMo.Count.ToString();

        }

        private void btn_AddStudent_Click(object sender, RoutedEventArgs e)
        {
            NewStudentForm studentForm = new NewStudentForm();
            studentForm.Show();
        }

        private void btThemCth_click(object sender, RoutedEventArgs e)
        {
            NewCourseForm newCourseForm = new NewCourseForm();
            newCourseForm.Show();
        }

        internal class ChuongTrinhHoc_SoHV
        {
            public ChuongTrinhHoc ChuongTrinhHoc { get; set; }
            public String NumberOfStudent { get; set; }
            public String TenCTH { get; set; }
        }

        internal class ListItemThiXepLop
        {
            public String day { get; set; }
            public String year { get; set; }
            public String title { get; set; }
            public String detail { get; set; }
        }
    }

    
}
