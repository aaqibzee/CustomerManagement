using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using WPFClient.CustomerService;

namespace WPFClient.Views
{
    /// <summary>
    /// Interaction logic for ListCustomersWindow.xaml
    /// </summary>
    public partial class ListCustomersWindow : Window
    {
        private readonly CustomerServiceClient _customerServiceClient = new CustomerServiceClient();
        /// <summary>
        /// Initializes ListCustomersWindow
        /// </summary>
        public ListCustomersWindow()
        {
            InitializeComponent();
            UpdateDataGrid();

        }
        /// <summary>
        /// Get customer Id selected by user to be updated and send it to UpdateCustomerWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UpdateCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
                int Id = (int)dataRowView["Id"];
                UpdateCustomerWindow updateCustomerWindow = new UpdateCustomerWindow(Id);
                updateCustomerWindow.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Refreshes Customer Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RefreshCustomerDataBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
        }
        /// <summary>
        /// Updates data grid with latest data
        /// </summary>
        void UpdateDataGrid()
        {
            try
            {
                GetCustomers customers = _customerServiceClient.GetAllCustomers();
                ListCustomersDataGrid.ItemsSource = customers.Customers.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
