using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Student_Management_System_2.Models;
using Student_Management_System_2.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Student_Management_System_2.VeiwModel;

public class AdminWindowVM : ObservableObject
{
    
    public ICommand OpenAdminRegistrationCommand { get; }
    public ICommand OpenModuleRegistrationCommand { get; }



    private void OpenModuleRegistration()
    {

        ModuleWindow moduleRegistrationWindow = new ModuleWindow();
        moduleRegistrationWindow.ShowDialog();
    }



    private void OpenAdminRegistration()
    {

        AdminUserWindow adminRegistrationWindow = new AdminUserWindow();
        adminRegistrationWindow.Show();
    }




    private int _userID;
    private string _userFirstName;
    private string _userLastName;
    private string _userDepartment;
    private string _username;
    private string _password;
    private User _selectedUser;

    public ObservableCollection<User> Users { get;} = new ObservableCollection<User>();


    public int UserID
    {
        get => _userID;
        set => SetProperty(ref _userID, value);
    }

    public string UserFirstName
    {
        get => _userFirstName;
        set => SetProperty<string>(ref _userFirstName, value);
    }

    public string UserLastName
    {
        get => _userLastName;
        set => SetProperty<string>(ref _userLastName, value);
    }

    public string UserDepartment
    {
        get => _userDepartment;
        set => SetProperty<string>(ref _userDepartment, value);
    }

    public string Username
    {
        get => _username;
        set => SetProperty<string>(ref _username, value);

    }

    public string Password
    {
        get => _password;
        set => SetProperty<string>(ref _password, value);
    }


    public User SelectedUser
    {
        get => _selectedUser;
        set
        {
            SetProperty(ref _selectedUser, value);
            if (_selectedUser != null)
            {
                UserID = _selectedUser.UserId;
                UserFirstName = _selectedUser.UserFirstName;
                UserLastName = _selectedUser.UserLastName;
                UserDepartment = _selectedUser.UserDepartment;
                Username = _selectedUser.Username;
                Password = _selectedUser.UserPassword;
            }
        }
    }

    public AsyncRelayCommand AddCommand { get; }
    public AsyncRelayCommand UpdateCommand { get; }
    public AsyncRelayCommand DeleteCommand { get; }
    public AsyncRelayCommand RefreshCommand { get; }

    public AdminWindowVM()
    {
        RefreshListView();
        OpenAdminRegistrationCommand = new RelayCommand(OpenAdminRegistration);
        OpenModuleRegistrationCommand = new RelayCommand(OpenModuleRegistration);

        AddCommand = new AsyncRelayCommand(AddUser);
        UpdateCommand = new AsyncRelayCommand(UpdateUser);
        DeleteCommand = new AsyncRelayCommand(DeleteUser);
        RefreshCommand = new AsyncRelayCommand(RefreshListView);
    }

    private async Task RefreshListView()
    {
        using (var context = new DataContext())
        {
            var users = await context.Users.ToListAsync();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
    }

    private async Task UpdateUser()
    {
        if (SelectedUser == null)
        {
            return;
        }

        using (var context = new DataContext())
        {
            var userToUpdate = await context.Users.FirstOrDefaultAsync(s => s.UserId == SelectedUser.UserId);
            if (userToUpdate != null)
            {
                userToUpdate.UserFirstName = UserFirstName;
                userToUpdate.UserLastName = UserLastName;
                userToUpdate.UserDepartment = UserDepartment;
                userToUpdate.Username = Username;
                userToUpdate.UserPassword = Password;

                await context.SaveChangesAsync();
                RefreshListView();
            }
        }
    }

    private async Task AddUser()
    {
        using (var context = new DataContext())
        {
            var newUser = new User
            {
                UserId = UserID,
                UserFirstName = UserFirstName,
                UserLastName = UserLastName,
                UserDepartment = UserDepartment,
                Username = Username,
                UserPassword = Password,

            };

            context.Users.Add(newUser);
            await context.SaveChangesAsync();
            RefreshListView();

        }
    }

    private async Task DeleteUser()
    {
        if (SelectedUser == null)
        {
            return;
        }

        using (var context = new DataContext())
        {
            var userToDelete = await context.Users.FirstOrDefaultAsync(u => u.UserId == SelectedUser.UserId);
            if (userToDelete != null)
            {
                context.Users.Remove(userToDelete);
                await context.SaveChangesAsync();
                RefreshListView();
            }
        }

    }

}
