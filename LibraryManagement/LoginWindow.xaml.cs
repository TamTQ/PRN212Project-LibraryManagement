using LibraryManagement.BusinessObject;
using LibraryManagement.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserService userService;
        public LoginWindow()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmail.Text) && !String.IsNullOrEmpty(txtPassword.Password))
            {
                if (IsAdmin(txtEmail.Text, txtPassword.Password))
                {
                    MessageBox.Show("Login Successful !! \nYou are Admin");

                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();

                    Close();
                }
                else
                {
                    User user = userService.Authenticate(txtEmail.Text, txtPassword.Password);

                    if (user != null)
                    {
                        MainWindow mainWindow = new MainWindow(user);
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong email or password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid email or password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool IsAdmin(string email, string password)
        {
            IConfiguration config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .Build();

            return email.Equals(config["AdminAccount:Email"])
                && password.Equals(config["AdminAccount:Password"]);
        }
    }
}
