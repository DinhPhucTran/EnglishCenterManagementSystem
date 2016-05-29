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
    /// <summary>
    /// Interaction logic for ThemLichThi.xaml
    /// </summary>
    public partial class ThemLichThi : Window
    {
        public ThemLichThi()
        {
            InitializeComponent();

            cb_phongThi.ItemsSource = new PhongBUS().getListPhong();
            cb_phongThi.SelectedIndex = 0;

            cb_caThi.ItemsSource = new CaBUS().getAllCa();
            cb_caThi.SelectedIndex = 0;

            cb_deThi.ItemsSource = new DeThiBUS().getListDeThi();
            cb_deThi.SelectedIndex = 0;

            
        }
    }
}
