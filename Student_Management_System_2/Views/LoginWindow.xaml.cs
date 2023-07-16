using Student_Management_System_2.VeiwModel;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            
            InitializeComponent();
            DataContext = new LoginWindowVM();


        }



        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            var Username = txtUsername.Text;
            var Password = txtPassword.Password;

            using (DataContext context = new DataContext())
            {
                int selectedIndex = userType.SelectedIndex;
 
                    bool userfound = context.Users.Any(user => user.Username == Username && user.UserPassword == Password);
                bool adminuserfound = context.Admins.Any(admin => admin.Username == Username && admin.Password == Password);

                    if (userfound && selectedIndex == 1)
                    {
                        GrantAccess();
                        Close();
                    }
                    else if (adminuserfound && selectedIndex == 0)
                    {
                        GrantAccess_2();
                        Close();
                    }

                    else
                    {
                        MessageBox.Show("Incorrect Username or Password");
                        LoginWindow window2 = new LoginWindow();
                        window2.Show();
                        Close();

                    }
                


            }

        }

        public void GrantAccess_2()
        {
            AdminWindow window2 = new AdminWindow();
            window2.Show();
        }
         
        public void GrantAccess()
        {
            UserWindow window1 = new UserWindow();
            window1.Show();
        }
    }
}
