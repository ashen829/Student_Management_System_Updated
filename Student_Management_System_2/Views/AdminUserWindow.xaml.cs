using Student_Management_System_2.Models;
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

namespace Student_Management_System_2.Views
{
    /// <summary>
    /// Interaction logic for AdminUserWindow.xaml
    /// </summary>
    public partial class AdminUserWindow : Window
    {
        public AdminUserWindow()
        {
            InitializeComponent();
        }


        //public List<Admin> DataBaseAdmins { get; private set; }

        //public void Read()
        //{
        //    using (DataContext context = new DataContext())
        //    {
        //        DataBaseAdmins = context.Admins.ToList();
        //        AdminList.ItemsSource = DataBaseAdmins;

        //    }

        //}

        //private void ReadButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Read();
        //}

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow window= new AdminWindow();
            window.Show();
            Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState= WindowState.Minimized; 
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }


}
