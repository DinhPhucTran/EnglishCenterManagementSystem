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

namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for NewLevelForm.xaml
    /// </summary>
    public partial class NewLevelForm : Window
    {
        public NewLevelForm()
        {
            InitializeComponent();
        }

        private void Button_Luu_Click(object sender, RoutedEventArgs e)
        {
            TrinhDo trinhDo = new TrinhDo();
            trinhDo.MMaTrinhDo = tb_maTrinhDo.Text.ToString();
            trinhDo.MTenTrinhDo = tb_tenTrinhDo.Text.ToString();
            bool result = new TrinhDoBUS().themTrinhDo(trinhDo);
            if (result == true)
            {
                MessageBox.Show("Thêm trình độ mới thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại! trình độ đả tồn tại");
            }
        }
        private void Button_Thoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Huy_Click(object sender, RoutedEventArgs e)
        {
            tb_maTrinhDo.Text = "";
            tb_tenTrinhDo.Text = "";
        }

    }
}
