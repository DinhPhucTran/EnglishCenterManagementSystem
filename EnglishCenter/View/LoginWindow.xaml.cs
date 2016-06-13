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
using System.Collections;

namespace EnglishCenter.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MainWindow mainWindow;
        public LoginWindow()
        {
            mainWindow = new MainWindow();

            InitializeComponent();
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //App.Current.Shutdown();
            this.Close();
        }

        public static List<T> GetLogicalChildCollection<T>(object parent) where T : DependencyObject
        {
            List<T> logicalCollection = new List<T>();
            GetLogicalChildCollection(parent as DependencyObject, logicalCollection);
            return logicalCollection;
        }

        private static void GetLogicalChildCollection<T>(DependencyObject parent, List<T> logicalCollection) where T : DependencyObject
        {
            IEnumerable children = LogicalTreeHelper.GetChildren(parent);
            foreach (object child in children)
            {
                if (child is DependencyObject)
                {
                    DependencyObject depChild = child as DependencyObject;
                    if (child is T)
                    {
                        logicalCollection.Add(child as T);
                    }
                    GetLogicalChildCollection(depChild, logicalCollection);
                }
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text == "")
            {
                MessageBox.Show("Tên đăng nhập không đúng.");
                return;
            }
            if (tbPass.Password == "")
            {
                MessageBox.Show("Mật khẩu không đúng.");
                return;
            }
            User user = new User(tbUsername.Text, tbPass.Password, "");
            if (new UserBUS().checkUser(user)) {
                //lay permission theo user
                String permission = new UserBUS().getPermissionByUser(user);
                user.MPermission = permission;
                //lay danh sach tab theo permission
                List<String> listNameTab = new DetailPermissionBUS().getListTabByPermission(permission);
                List<Button> listBtn = GetLogicalChildCollection<Button>(mainWindow);
                List<TabItem> listTab = GetLogicalChildCollection<TabItem>(mainWindow);
                for (int i = 0; i < listNameTab.Count; i++)
                {
                    Button btn = listBtn.Find(m => m.Name == listNameTab[i]);
                    if (btn != null)
                    {
                        btn.Visibility = Visibility.Hidden;
                    }
                    TabItem tab = listTab.Find(m =>  m.Name == listNameTab[i]);
                    if (tab != null)
                    {
                        tab.Visibility = Visibility.Collapsed;
                    }
                    //foreach (Button btn in a)
                    {
                        //for (int i = 0; i < listNameTab.Count; i++)
                        //{
                        //    if (btn.Name == listNameTab[i])
                        //    {
                        //        btn.Visibility = Visibility.Hidden;
                        //        if (btn.Name.Contains("tab"))
                        //        {
                        //            btn.Visibility = Visibility.Collapsed;
                        //        }
                        //    }
                        //}

                        //if (btn.Name == listNameTab[i])
                        //{
                        //    btn.Visibility = Visibility.Hidden;
                        //}
                    }
                }
                
                mainWindow.Show();
                this.Close();
            }                
            else
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
            
        }
    }
}
