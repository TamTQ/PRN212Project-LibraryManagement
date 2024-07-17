using LibraryManagement.Services;
using LibraryManagement.BusinessObject;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryManagement.DataAccessObject;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBookService bookService;
        private readonly ILendService lendService;
        private readonly IUserService userService;
        private User loggedInUser;
        public MainWindow(User loggedInUser)
        {
            InitializeComponent();
            this.loggedInUser = loggedInUser;
            bookService = new BookService();
            lendService = new LendService();
            userService = new UserService();
            LoadBooks();
            LoadLend();
            LoadUserData();
        }
        //Library
        private void LoadBooks()
        {
            lvBooks.ItemsSource = bookService.GetBooks();
        }

        private void btnLend_Click(object sender, RoutedEventArgs e)
        {
            if (lvBooks.SelectedItem is Book selectedBook && loggedInUser != null)
            {
                var lendDate = DateOnly.FromDateTime(DateTime.Today);
                var dueDate = lendDate.AddDays(14);

                var lend = new Lend
                {
                    BookId = selectedBook.BookId,
                    UserId = loggedInUser.UserId,
                    LendDate = lendDate,
                    DueDate = dueDate
                };

                try
                {
                    lendService.AddLend(lend);
                    MessageBox.Show("Lend added successfully.");
                    LoadLend();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding lend: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a book to lend.");
            }
        }
        //Lend Details
        private void LoadLend()
        {
            lvLends.ItemsSource = lendService.GetLendByUserId(loggedInUser.UserId);
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            if (lvLends.SelectedItem != null)
            {
                Lend selectedLend = (Lend)lvLends.SelectedItem;
                try
                {
                    LendDAO.UpdateLendReturnDate(selectedLend.LendId, DateOnly.FromDateTime(DateTime.Today));
                    MessageBox.Show("Return date updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadLend();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to update return date: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a lend item to return.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //Profile
        private void LoadUserData()
        {
            loggedInUser = userService.GetUserById(loggedInUser.UserId);
            if (loggedInUser != null)
            {
                txtFullName.Text = loggedInUser.FullName;
                txtEmail.Text = loggedInUser.Email;
                pwdPassword.Password = loggedInUser.Password;
            }
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (loggedInUser != null)
            {
                loggedInUser.FullName = txtFullName.Text;
                loggedInUser.Email = txtEmail.Text;
                loggedInUser.Password = pwdPassword.Password;

                userService.EditUser(loggedInUser);

                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No user is logged in.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            pwdPassword.Visibility = Visibility.Collapsed;
            txtPassword.Visibility = Visibility.Visible;
            txtPassword.Text = pwdPassword.Password;
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            pwdPassword.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Collapsed;
            pwdPassword.Password = txtPassword.Text;
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
            }
        }
    }
}