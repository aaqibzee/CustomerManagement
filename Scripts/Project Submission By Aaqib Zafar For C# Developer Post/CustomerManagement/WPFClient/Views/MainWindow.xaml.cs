using System.Windows;

namespace WPFClient.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Initializes MainWindow 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initialize Search Customer Window and makes it visible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchCustomerWindow searchCustomerWindow = new SearchCustomerWindow();
            searchCustomerWindow.ShowDialog();
        }
        /// <summary>
        /// Initialize ListCustomerWindow and make it visible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListCustomersBtn_Click(object sender, RoutedEventArgs e)
        {
            ListCustomersWindow listCustomersWindow = new ListCustomersWindow();
            listCustomersWindow.ShowDialog();
        }
        /// <summary>
        /// Initialize CreateCustomerWindow and make it visible
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateCustomerWindow createCustomersWindow = new CreateCustomerWindow();
            createCustomersWindow.ShowDialog();
        }
    }
}
