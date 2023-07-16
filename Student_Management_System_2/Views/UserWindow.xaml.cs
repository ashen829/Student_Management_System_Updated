using Microsoft.Win32;
using Student_Management_System_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Xml.Linq;

namespace Student_Management_System_2.Views
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window

    {
       // public List<Student> DataBaseUsers { get; private set; }

        public UserWindow()
        {
            InitializeComponent();
        }



        //public void Create() 
        //{


        //    using (DataContext context = new DataContext())
        //    {

        //        var studentfirstname = StudentFirstNameTextBox.Text;
        //        var studentlastname = StudentLastNameTextBox.Text;
        //        var studentdistrict = StudentDistrictTextBox.Text;
        //        var studentdepartment = StudentDepartment.Text;




        //        if ( studentfirstname != null && studentlastname != null && studentdistrict != null && StudentDepartment != null)
        //        {


        //            context.Students.Add(new Student() {StudentFirstName = studentfirstname, StudentLastName = studentlastname, StudentDistrict = studentdistrict, StudentDepartment = studentdepartment });                   
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
        //        Student selectedStudent = StudentList.SelectedItem as Student;

        //        var studentfirstname = StudentFirstNameTextBox.Text;
        //        var studentlastname = StudentLastNameTextBox.Text;
        //        var studentdistrict = StudentDistrictTextBox.Text;
        //        var studentdepartment = StudentDepartment.Text;

        //        if (studentfirstname != null && studentlastname != null && studentdistrict != null && studentdepartment != null)
        //        {
        //            Student student = context.Students.Find(selectedStudent.StudentId);
        //            student.StudentFirstName = studentfirstname;
        //            student.StudentDistrict = studentdistrict;
        //            student.StudentDepartment = studentdepartment;
        //            student.StudentLastName = studentlastname;

        //            context.SaveChanges();
        //        }
        //    }



        //}

        //public void Delete()
        //{
        //    using (DataContext context = new DataContext())
        //    {
        //        Student selectedStudent = StudentList.SelectedItem as Student;

        //        if (selectedStudent != null)
        //        {
        //            Student student = context.Students.Single(x => x.StudentId == selectedStudent.StudentId);
        //            context.Remove(student);
        //            context.SaveChanges();
        //        }



        //    }
        //}



        //public void Read()
        //{
        //    using (DataContext context = new DataContext())
        //    {
        //        DataBaseUsers = context.Students.ToList();
        //        StudentList.ItemsSource = DataBaseUsers;

        //    }



        //}



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
        //    Update();

        //}

        //private void DeleteButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Delete();
        //}

        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{

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


    }
}
