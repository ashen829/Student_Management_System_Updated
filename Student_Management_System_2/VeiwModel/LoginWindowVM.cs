using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Student_Management_System_2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Student_Management_System_2.VeiwModel
{
    public class LoginWindowVM : ObservableObject
    {
        private string _username;
        private string _password;
        private int _selectedIndex;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public int SelectedIndex
        {
            get => _selectedIndex;
            set => SetProperty(ref _selectedIndex, value);
        }

        public IAsyncRelayCommand LoginCommand { get; }

        public LoginWindowVM()
        {
            LoginCommand = new AsyncRelayCommand(Login);
        }

        private async Task Login()
        {
            using (var context = new DataContext())
            {
                bool userFound = false;
                bool adminUserFound = false;

                if (SelectedIndex == 1)
                {
                    userFound = context.Users.Any(user => user.Username == Username && user.UserPassword == Password);
                }
                else if (SelectedIndex == 0)
                {
                    adminUserFound = context.Admins.Any(admin => admin.Username == Username && admin.Password == Password);
                }

                if (userFound)
                {
                    GrantAccess();
                    CloseWindow();
                }
                else if (adminUserFound)
                {
                    GrantAccess_2();
                    CloseWindow();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password");
                }
            }
        }

        private void GrantAccess()
        {
            UserWindow window1 = new UserWindow();
            window1.Show();
        }

        private void GrantAccess_2()
        {
            AdminWindow window2 = new AdminWindow();
            window2.Show();
        }

        private void CloseWindow()
        {
            Application.Current.MainWindow.Close();
        }


    }
}
