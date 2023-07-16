using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Management_System_2.Models;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Student_Management_System_2.Views;
using System.Windows.Input;

namespace Student_Management_System_2.VeiwModel
{
    public class ModuleWindowVM : ObservableObject
    {
        public ICommand OpenUserWindowCommand { get; }
        private void OpenUserWindow()
        {

            UserWindow Window = new UserWindow();
            Window.Show();

        }
        public ICommand OpenAdminCommand { get; }
        private void OpenAdmin()
        {

            AdminUserWindow Window = new AdminUserWindow();
            Window.Show();

        }


        private string _moduleID;
        private string _moduleName;
        private int _credits;
        private string _description;
        private string _department;
        private int _semester;
        private Module _selectedModule;
        public ObservableCollection<Module> Modules { get; } = new ObservableCollection<Module>();

        public string ModuleID
        {
            get => _moduleID;
            set => SetProperty<string>(ref _moduleID, value);
        }


        public string ModuleName
        {
            get => _moduleName;
            set => SetProperty(ref _moduleName, value);
        }
        public int Credits
        {
            get => _credits; 
            set => SetProperty(ref _credits, value);
        }
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        public string Department
        {
            get => _department; 
            set => SetProperty(ref _department, value);
        }
        public int Semester
        {
            get => _semester; 
            set => SetProperty(ref _semester, value);
        }


        public Module SelectedModule
        {
            get => _selectedModule;
            set
            {
                SetProperty(ref _selectedModule, value);
                if(_selectedModule != null)
                {
                    ModuleID = _selectedModule.ModuleId;
                    ModuleName= _selectedModule.ModuleName;
                    Semester= _selectedModule.Semester;
                    Description= _selectedModule.Description;
                    Department= _selectedModule.Department;
                    Credits= _selectedModule.Credits;
                }
            }
        }

        public AsyncRelayCommand AddCommand { get; }
        public AsyncRelayCommand DeleteCommand { get; }
        public AsyncRelayCommand RefreshCommand { get; }
        public AsyncRelayCommand UpdateCommand { get; }

        public ModuleWindowVM()
        {
            RefreshListView();

            OpenUserWindowCommand = new RelayCommand(OpenUserWindow);
            OpenAdminCommand = new RelayCommand(OpenAdmin);
            AddCommand = new AsyncRelayCommand(AddModule);
            DeleteCommand = new AsyncRelayCommand(DeleteModule);
            RefreshCommand = new AsyncRelayCommand(RefreshListView);
            UpdateCommand = new AsyncRelayCommand(UpdateModule);
            
        }

        private async Task AddModule()
        {
            using (var context = new DataContext())
            {
                var newModule = new Module()
                {
                    ModuleId= ModuleID,
                    ModuleName= ModuleName,
                    Semester= Semester,
                    Grade = " ",
                    Description= Description,
                    Department= Department,
                    Credits= Credits,

                };

                context.Modules.Add(newModule);
                await context.SaveChangesAsync();
                RefreshListView();
            }
        }

        private async Task DeleteModule()
        {
            if (SelectedModule == null)
            {
                return;
            }
            using (var context = new DataContext())
            {
                var moduleToDelete = await context.Modules.FirstOrDefaultAsync(m => m.ModuleId== SelectedModule.ModuleId);
                if (moduleToDelete != null)
                {
                    context.Modules.Remove(moduleToDelete);
                    await context.SaveChangesAsync();
                    RefreshListView();
                }
            }
        }

        private async Task RefreshListView()
        {
            
            using (var context = new DataContext())
            {
                var modules = await context.Modules.ToListAsync();
                Modules.Clear();
                foreach (var module in modules)
                {
                    Modules.Add(module);
                }
            }
        }

        private async Task UpdateModule()
        {
            if(SelectedModule == null)
            {
                return;
            }

            using(var context = new DataContext())
            {
                var moduleToUpdate = await context.Modules.FirstOrDefaultAsync(m => m.ModuleId == SelectedModule.ModuleId);
                if (moduleToUpdate != null)
                {
                    moduleToUpdate.ModuleId = SelectedModule.ModuleId;
                    moduleToUpdate.ModuleName = SelectedModule.ModuleName;
                    moduleToUpdate.Semester = SelectedModule.Semester;
                    
                    moduleToUpdate.Department = SelectedModule.Department;
                    moduleToUpdate.Description = SelectedModule.Description;
                    moduleToUpdate.Credits = SelectedModule.Credits;

                    await context.SaveChangesAsync();
                    RefreshListView();

                }

            }
        }






    }

}
