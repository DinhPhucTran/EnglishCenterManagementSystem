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


namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for NewCourseForm.xaml
    /// </summary>
    public partial class NewCourseForm : Window
    {
        private List<TrinhDo> mListTD;
        public bool IsUpdating;
        public NewCourseForm()
        {
            InitializeComponent();
            
            mListTD = new TrinhDoBUS().getListTrinhDo();
            cbLevel.ItemsSource = mListTD;
        }

        public NewCourseForm(ChuongTrinhHoc cth)
        {
            IsUpdating = true;
            InitializeComponent();
            mListTD = new TrinhDoBUS().getListTrinhDo();
            cbLevel.ItemsSource = mListTD;
            grid_headerBackground.Background = new SolidColorBrush(Color.FromRgb(239, 163, 0));
            tb_Header.Text = "Sửa thông tin chương trình học";
            initBoxes(cth);
                    
        }

        private void initBoxes(ChuongTrinhHoc cth)
        {
            tb_CTH.Text = cth.MTenChuongTrinhHoc;
            tb_minDiem.Text = cth.MDiemSoToiThieu.ToString();
            tb_maxDiem.Text = cth.MDiemSoToiDa.ToString();
            int index = 0;
            for (int i = 0; i < mListTD.Count; i++)
            {
                if (mListTD[i].MMaTrinhDo.Equals(cth.MMaTrinhDo))
                {
                    index = i;
                    break;
                }
            }
            cbLevel.SelectedIndex = index;
        }

        void onLuuBtnClick(object sender, RoutedEventArgs e)
        {
            if (tb_CTH.Text.ToString().Equals(""))
            {
                MessageBox.Show("Tên chương trình không được rỗng");
                return;
            }
          
            
            List<ChuongTrinhHoc> list = new ChuongTrinhHocBUS().getListChuongTrinhHoc();
            for (int i = 0; i < list.Count; ++i)
            {

                if (string.Equals(tb_CTH.Text.ToString(),list[i].MTenChuongTrinhHoc,StringComparison.CurrentCultureIgnoreCase))
                {
                    MessageBox.Show("Tên Chương Trình Học Đã Tồn Tại");
                    return;
                }
            }
            ChuongTrinhHoc cth = new ChuongTrinhHoc();
            cth.MMaChuongTrinhHoc = mListTD[cbLevel.SelectedIndex].MMaTrinhDo.ToString().Substring(0,3) + tb_minDiem.Text.ToString();

            cth.MMaTrinhDo = mListTD[cbLevel.SelectedIndex].MMaTrinhDo;
            try
            {
                cth.MDiemSoToiThieu = float.Parse(tb_minDiem.Text.ToString());
                cth.MDiemSoToiDa = float.Parse(tb_maxDiem.Text.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng kiểm tra lại Điểm số tối đa và điểm số tối thiểu");
                return;
            }
            cth.MTenChuongTrinhHoc = tb_CTH.Text.ToString();

            bool result;
            if (IsUpdating)
            {
                result = new ChuongTrinhHocBUS().suaChuongTrinhHoc(cth);
            }
            else
            {
                result = new ChuongTrinhHocBUS().themChuongTrinhHoc(cth);
            }

            if (result)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm chương trình học thất bại");
            }
        }


        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void onExitBtnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void onClearBtnClick(object sender, RoutedEventArgs e)
        {
            tb_CTH.Clear();
            tb_minDiem.Clear();
            tb_maxDiem.Clear();
        }

     
        
    }
}
