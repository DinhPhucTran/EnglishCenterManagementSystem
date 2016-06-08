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
    /// Interaction logic for KetQuaThiXepLop.xaml
    /// </summary>
    public partial class KetQuaThiXepLop : Window
    {
        public KetQuaThiXepLop()
        {
            InitializeComponent();
            List<KetQuaThi> list = new KetQuaThiXLBUS().getKetQuaThi(new DateTime(2016, 1, 1), new DateTime(2016, 8, 1));
            lv_ketQua.ItemsSource = list;
            
        }
    }
}
