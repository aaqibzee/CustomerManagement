using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using WPFClient.Constants;
using WPFClient.CustomerService;

namespace WPFClient.Views
{
    /// <summary>
    /// Interaction logic for SearchCustomerWindow.xaml
    /// </summary>
    public partial class SearchCustomerWindow : Window
    {
        private readonly CustomerServiceClient _customerServiceClient = new CustomerServiceClient();
        /// <summary>
        /// Initialize SearchCustomerWindow
        /// </summary>
        public SearchCustomerWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Send customer name to CustomerService and shows the received results
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var customers = _customerServiceClient.SearchCustomer(CustomerNameTextBox.Text.Trim());
                if (customers.Customers.Rows.Count > 0)
                    ListCustomersDataGrid.ItemsSource = customers.Customers.DefaultView;
                else MessageBox.Show(CommonConstants.RecordNotFound);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        /// Clear the contents of text box when it gets focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerNameTextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            CustomerNameTextBox.Clear();
        }
    }
}
