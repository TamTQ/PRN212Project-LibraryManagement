using LibraryManagement.BusinessObject;
using LibraryManagement.Services;
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

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly IBookService bookService;
        private readonly ILendService lendService;
        private readonly IUserService userService;
        private readonly IGenreService genreService;
        public AdminWindow()
        {
            InitializeComponent();
            bookService = new BookService();
            lendService = new LendService();
            userService = new UserService();
            genreService = new GenreService();
            LoadBooks();
            LoadGenre();
            LoadLend();
            LoadUser();
        }
        //Library
        private void LoadBooks()
        {
            lvBooks.ItemsSource = bookService.GetBooks();
        }
        private void LoadGenre()
        {
            cboGenre.ItemsSource = genreService.GetGenres();
            cboGenre.DisplayMemberPath = "Genre1";
            cboGenre.SelectedValuePath = "GenrId";
        }
        private void lvBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvBooks.SelectedItem is Book selectedBook)
            {
                txtTitle.Text = selectedBook.Title;
                txtAuthor.Text = selectedBook.Author;
                cboGenre.SelectedValue = selectedBook.Genre.GenreId;
            }
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            Book newBook = new Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Genre = (Genre)cboGenre.SelectedItem
            };

            bookService.AddBook(newBook);
            LoadBooks();
        }

        private void btnDeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (lvBooks.SelectedItem is Book selectedBook)
            {
                bookService.DeleteBook(selectedBook.BookId);
                LoadBooks();
            }
        }
        //Lend
        private void LoadLend()
        {
            lvLends.ItemsSource = lendService.GetLend();
        }
        private void btnShowOverdueBooks_Click(object sender, RoutedEventArgs e)
        {
            var overdueBooks = lendService.GetLend().Where(l => l.ReturnDate > l.DueDate).ToList();
            lvLends.ItemsSource = overdueBooks;
        }
        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            LoadLend();
        }
        //User
        private void LoadUser()
        {
            lvUser.ItemsSource = userService.GetUsers();
        }
        private void lvUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvUser.SelectedItems is User selectedUser)
            {
                txtFullName.Text = selectedUser.FullName;
                txtEmail.Text = selectedUser.Email;
                txtPassword.Text = selectedUser.Password;
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            User newuser = new User()
            {
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text
            };

            userService.AddUser(newuser);
            LoadUser();
        }
        private void btnDeleteUser_Click(Object sender, RoutedEventArgs e)
        {
            if (lvUser.SelectedItem is User selectedUser)
            {
                userService.DeleteUser(selectedUser.UserId);
                LoadUser();
            }
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
