using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Student_Management_System_2.Models;
using Student_Management_System_2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Student_Management_System_2.VeiwModel
{
    public partial class AdminUserWindowVM : ObservableObject
    {

        public ICommand OpenUserRegistrationCommand { get; }

        private void OpenUserRegistration()
        {
            AdminWindow userRegistrationWindow = new AdminWindow();
            userRegistrationWindow.ShowDialog();
            
            
        }

        public ICommand OpenModuleRegistrationCommand { get; }

        private void OpenModuleRegistration()
        {
            ModuleWindow Window = new ModuleWindow();
            Window.ShowDialog();


        }



        private int _adminID;
        private string _adminFirstName;
        private string _adminLastName;
        private string _adminUsername;
        private string _adminPassword;
        private Admin _selectedAdmin;
        public ObservableCollection<Admin> Admins { get; } = new ObservableCollection<Admin>();


        public int AdminID
        {
            get => _adminID;
            set => SetProperty(ref _adminID, value);
        }

        public string AdminFirstName
        {
            get => _adminFirstName;
            set => SetProperty<string>(ref _adminFirstName, value);
        }

        public string AdminLastName
        {
            get => _adminLastName;
            set => SetProperty(ref _adminLastName, value);
        }

        public string AdminUsername
        {
            get => _adminUsername;
            set => SetProperty(ref _adminUsername, value);
        }

        public string AdminPassword
        {
            get => _adminPassword;
            set => SetProperty(ref _adminPassword, value);
        }

        public Admin SelectedAdmin
        {
            get => _selectedAdmin;
            set
            {
                SetProperty(ref _selectedAdmin,value);
                if (_selectedAdmin != null)
                {
                    AdminID = _selectedAdmin.AdminId;
                    AdminFirstName = _selectedAdmin.AdminFirstName;
                    AdminLastName = _selectedAdmin.AdminLastName;
                    AdminUsername = _selectedAdmin.Username; 
                    AdminPassword = _selectedAdmin.Password;

                }
            }
        }

        public AsyncRelayCommand AddCommand { get; }
        public AsyncRelayCommand UpdateCommand { get; }
        public AsyncRelayCommand RefreshCommand { get; }
        public AsyncRelayCommand DeleteCommand { get; }
        

        public AdminUserWindowVM()
        {
            RefreshAdmins();
            OpenModuleRegistrationCommand = new RelayCommand(OpenModuleRegistration);

            OpenUserRegistrationCommand = new RelayCommand(OpenUserRegistration);

            AddCommand = new AsyncRelayCommand(AddAdmin);
            UpdateCommand = new AsyncRelayCommand(UpdateAdmin);
            RefreshCommand = new AsyncRelayCommand(RefreshAdmins);
            DeleteCommand = new AsyncRelayCommand(DeleteAdmin);
        }

        
        private async Task UpdateAdmin()
        {
            if (SelectedAdmin == null)
            {
                return;
            }

            using (var context = new DataContext())
            {
                var adminToUpdate = await context.Admins.FirstOrDefaultAsync(a => a.AdminId== SelectedAdmin.AdminId);
                if (adminToUpdate != null)
                {
                    
                    adminToUpdate.AdminFirstName = AdminFirstName;
                    adminToUpdate.AdminLastName = AdminLastName;
                    adminToUpdate.Username = AdminUsername;
                    adminToUpdate.Password = AdminPassword;

                    await context.SaveChangesAsync();
                    RefreshAdmins();
                }
            }
        }


        private async Task AddAdmin()
        {
            using (var context = new DataContext())
            {
                var newAdmin = new Admin
                {
                    AdminId = AdminID,
                    AdminFirstName = AdminFirstName,
                    AdminLastName = AdminLastName,
                    Password= AdminPassword,
                    Username= AdminUsername,


                };

                context.Admins.Add(newAdmin);
                await context.SaveChangesAsync();
                RefreshAdmins();
            }
        }

        private async Task RefreshAdmins()
        {
            using (var context = new DataContext())
            {
                var admins = await context.Admins.ToListAsync();
                Admins.Clear();
                foreach (var admin in admins)
                {
                    Admins.Add(admin);
                }

            }
        }


        private async Task DeleteAdmin()
        {
            if (SelectedAdmin == null)
            {
                return;
            }

            using (var context = new DataContext())
            {
                var adminToDelete = await context.Admins.FirstOrDefaultAsync(s => s.AdminId == SelectedAdmin.AdminId);
                if(adminToDelete != null)
                {
                    context.Admins.Remove(adminToDelete);
                    await context.SaveChangesAsync();
                    RefreshAdmins();
                }
            }
        }

    }
}
