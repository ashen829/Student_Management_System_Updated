using Microsoft.EntityFrameworkCore.Infrastructure;
using Student_Management_System_2.VeiwModel;
using Student_Management_System_2.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace Student_Management_System_2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DatabaseFacade facade = new DatabaseFacade(new DataContext());
            facade.EnsureCreated();

            //base.OnStartup(e);
            //DataContext dbContext = new DataContext();
            //AdminWindowVM userViewModel = new AdminWindowVM();
            //AdminWindow userWindow = new AdminWindow();
            //userWindow.DataContext = userViewModel;
            //userWindow.Show();
        }
    }
}
