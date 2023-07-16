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
using Student_Management_System_2.VeiwModel;

namespace Student_Management_System_2.Views
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            DataContext = new AdminWindowVM();
        }


        //public List<User> DataBaseUsers { get; private set; }

        //public void Create()
        //{


        //    using (DataContext context = new DataContext())
        //    {

        //        var userfirstname = UserFirstNameTextBox.Text;
        //        var userlastname = UserLastNameTextBox.Text;
        //        var userdepartment = UserDepartment.Text;
        //        var username = UsernameTextBox.Text;
        //        var userpassword = PasswordTextBox.Text;




        //        if (userfirstname != null && userlastname != null && userdepartment != null && userpassword != null)
        //        {


        //            context.Users.Add(new User() { UserFirstName = userfirstname, UserLastName = userlastname, UserDepartment = userdepartment, Username = username , UserPassword = userpassword });
        //            context.SaveChanges();
        //            //StudentFirstNameTextBox.Clear();



        //        }
        //        else
        //        {
        //            MessageBox.Show("Fill all the Fields");
        //        }

        //    }

        //}

        //public void Update()
        //{
        //    using (DataContext context = new DataContext())
        //    {
        //        User selectedUser = UserList.SelectedItem as User;

        //        var userfirstname = UserFirstNameTextBox.Text;
        //        var userlastname = UserLastNameTextBox.Text;
        //        var userdepartment = UserDepartment.Text;
        //        var username = UsernameTextBox.Text;
        //        var userpassword = PasswordTextBox.Text;

        //        if (userfirstname != null && userlastname != null && userdepartment != null && userpassword != null)
        //        {


        //            User user = context.Users.Find(selectedUser.UserId);
        //            user.UserFirstName = userfirstname;
        //            user.UserLastName = userlastname;
        //            user.UserDepartment = userdepartment;
        //            user.Username = username;
        //            user.UserPassword = userpassword;

        //            context.SaveChanges();



        //        }

        //    }



        //}

        //public void Delete()
        //{
        //    using (DataContext context = new DataContext())
        //    {

        //        User selectedUser = UserList.SelectedItem as User;
        //        if (selectedUser != null)
        //        {
        //            User user = context.Users.Single(x => x.UserId == selectedUser.UserId);
        //            context.Remove(user);
        //            context.SaveChanges();
        //        }



        //    }
        //}



        //public void Read()
        //{
        //    using (DataContext context = new DataContext())
        //    {
        //        DataBaseUsers = context.Users.ToList();
        //        UserList.ItemsSource = DataBaseUsers;

        //    }



        //}

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            window.Show();
            Close();
        }

        //private void CreateButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Create();
        //}

        //private void ReadButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Read();

        //}

        //private void UpdateButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void DeleteButton_Click(object sender, RoutedEventArgs e)
        //{

        //}
    }
}
