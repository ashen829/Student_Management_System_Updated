using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Student_Management_System_2.Models;
using Student_Management_System_2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Student_Management_System_2.VeiwModel
{
    public partial class UserWindowVM : ObservableObject
    {
        public ICommand OpenGpaWindowCommand { get; }
        private void OpenGpaWindow()
        {

            GpaWindow Window = new GpaWindow();
            Window.Show();
            
        }


        [ObservableProperty]
        public ObservableCollection<Module> modules;


        private int _studentID;
        private string _studentFirstName;
        private string _studentLastName;
        private string _studentDistrict;
        private string _studentDepartment;
        private Student _selectedStudent;
        
        public ObservableCollection<Student> Students { get; } = new ObservableCollection<Student>();



        public int StudentID
        {
            get => _studentID;
            set => SetProperty(ref _studentID, value);
        }

        public string StudentFirstName
        {
            get => _studentFirstName;
            set => SetProperty<string>(ref _studentFirstName, value);
        }

        public string StudentLastName
        {
            get => _studentLastName;
            set => SetProperty<string>(ref _studentLastName, value);    
        }

        public string StudentDistrict
        {
            get => _studentDistrict;
            set => SetProperty<string>(ref _studentDistrict, value);
        }

        public string StudentDepartment
        {
            get => _studentDepartment; 
            set => SetProperty<string>(ref _studentDepartment, value);
        }



        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                SetProperty(ref _selectedStudent, value);
                if(_selectedStudent != null)
                {
                    StudentID = _selectedStudent.StudentId;
                    StudentFirstName = _selectedStudent.StudentFirstName;
                    StudentLastName = _selectedStudent.StudentLastName;
                    StudentDistrict = _selectedStudent.StudentDistrict;
                    StudentDepartment = _selectedStudent.StudentDepartment;
                }
            }
        }

        public AsyncRelayCommand AddCommand { get; }
        public AsyncRelayCommand DeleteCommand { get; }
        public AsyncRelayCommand RefreshCommand { get; }
        public AsyncRelayCommand UpdateCommand { get; }
        public UserWindowVM()
        {
            OpenGpaWindowCommand = new RelayCommand(OpenGpaWindow);

            RefreshListView();
            var db=new DataContext();
            AddCommand = new AsyncRelayCommand(AddStudent);
            DeleteCommand = new AsyncRelayCommand(DeleteStudent);
            RefreshCommand = new AsyncRelayCommand(RefreshListView);
            UpdateCommand = new AsyncRelayCommand(UpdateStudent);
            var list = db.Modules.ToList();
            modules=new ObservableCollection<Module>(list);
        }

        private async Task AddStudent()
        {




            using (var context = new DataContext())
            {
                var newStudent = new Student
                {
                    StudentId = StudentID,
                    StudentFirstName = StudentFirstName,
                    StudentLastName = StudentLastName,
                    StudentDistrict = StudentDistrict,
                    StudentDepartment = StudentDepartment

                };

                

                context.Students.Add(newStudent);
                await context.SaveChangesAsync();
                RefreshListView();




            }
        }

        private async Task DeleteStudent()
        {
            if(SelectedStudent == null)
            {
                return;
            }
            using (var context = new DataContext())
            {
                var studentToDelete = await context.Students.FirstOrDefaultAsync(s => s.StudentId == SelectedStudent.StudentId);
                if (studentToDelete != null)
                {
                    context.Students.Remove(studentToDelete);
                    await context.SaveChangesAsync();
                    RefreshListView();
                }
            }
        }

        private async Task UpdateStudent()
        {
            
            if (SelectedStudent == null)
            {
                return;
            }

            using (var context = new DataContext())
            {
                var studentToUpdate = await context.Students.FirstOrDefaultAsync(s => s.StudentId == SelectedStudent.StudentId);
                if (studentToUpdate != null)
                {
                    studentToUpdate.StudentFirstName = StudentFirstName;
                    studentToUpdate.StudentLastName = StudentLastName;
                    studentToUpdate.StudentDistrict = StudentDistrict;
                    studentToUpdate.StudentDepartment = StudentDepartment;

                    await context.SaveChangesAsync();
                    RefreshListView();
                }
            }
        }

        private async Task RefreshListView()
        {
            
            using (var context = new DataContext())
            {
                var students = await context.Students.ToListAsync();
                Students.Clear();
                foreach (var student in students)
                {
                    Students.Add(student);
                }
            }
        }


    }

}

















