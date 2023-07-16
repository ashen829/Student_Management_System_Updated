using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Student_Management_System_2.Models;
using Student_Management_System_2.Views;
using System.Windows;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Student_Management_System_2.VeiwModel
{
    public partial class GpaWindowVM : ObservableObject
    {

        [ObservableProperty]
        public Module selectedModule;

        [ObservableProperty]
        public ObservableCollection<string> grades;


        [ObservableProperty]
        public ObservableCollection<Module> selectedModules;

        public ICommand OpenUserWindowCommand { get; }
        private void OpenUserWindow()
        {
            
            UserWindow Window = new UserWindow();
            Window.Show();

        }



        [ObservableProperty]
        public ObservableCollection<Module> _modules;


        [RelayCommand]
        public void selectModule()
        {

            SelectedModules.Add(SelectedModule);


        }

        public double CalculateGPAForModules(ObservableCollection<Module> studentModules)
        {

            double tqp = 0;
            double tcv = 0;


            foreach (var module in studentModules)
            {

                double gradeValue = 0;
                switch (module.Grade)
                {
                    case "A+":
                        gradeValue = 4.0;
                        break;
                    case "A":
                        gradeValue = 3.7;
                        break;
                    case "A-":
                        gradeValue = 3.3;
                        break;
                    case "B+":
                        gradeValue = 3.0;
                        break;
                    case "B":
                        gradeValue = 2.7;
                        break;
                    case "B-":
                        gradeValue = 2.3;
                        break;
                    case "C+":
                        gradeValue = 2.0;
                        break;
                    case "C":
                        gradeValue = 1.7;
                        break;
                    case "C-":
                        gradeValue = 1.3;
                        break;
                    case "D":
                        gradeValue = 1.0;
                        break;
                    case "F":
                        gradeValue = 0.0;
                        break;
                    default:
                        break;
                }


                double qualityPoints = gradeValue * module.Credits;
                tqp += qualityPoints;
                tcv += module.Credits;
            }

            double sgpa;
            if (tcv == 0)
            {
                sgpa = 0;
            }

            else
            {
                sgpa = tqp / tcv;
            }

            return sgpa;
        }


        [RelayCommand]
        public void CalculateGPA()
        {
            double gpa = CalculateGPAForModules(SelectedModules);
            string gpastr = Math.Round(gpa, 2).ToString();
            MessageBox.Show($"Your GPA is {gpastr}");
        }


        public GpaWindowVM()
        {
            selectedModules = new ObservableCollection<Module>();
            Grades = new ObservableCollection<string> { "A", "B", "C", "A+", "B+", "C+", "A-", "B-", "C-", "D", "F" };
            OpenUserWindowCommand = new RelayCommand(OpenUserWindow);
            var db = new DataContext();
            var list = db.Modules.ToList();
            _modules = new ObservableCollection<Module>(list);

        }


    }
}


