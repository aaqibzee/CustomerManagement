using System.Windows;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ListUsersWindow _listUsersWindow = new ListUsersWindow();
        private readonly SearchUserWindow _searchUsersWindow = new SearchUserWindow();
        private readonly CreateUserWindow _createUsersWindow = new CreateUserWindow();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchUserBtn_Click(object sender, RoutedEventArgs e)
        {
            _searchUsersWindow.ShowDialog();
        }

        private void ListAllUsersBtn_Click(object sender, RoutedEventArgs e)
        {
            _listUsersWindow.ShowDialog();
        }

        private void CreateUserBtn_Click(object sender, RoutedEventArgs e)
        {
            _createUsersWindow.ShowDialog();
        }
    }
}
