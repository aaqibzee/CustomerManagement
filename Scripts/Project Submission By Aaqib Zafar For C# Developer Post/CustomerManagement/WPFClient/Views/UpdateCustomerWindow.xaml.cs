using System;
using System.Net;
using System.Windows;
using WPFClient.Constants;
using WPFClient.CustomerService;

namespace WPFClient.Views
{
    /// <summary>
    /// Interaction logic for UpdateCustomerWindow.xaml
    /// </summary>
    public partial class UpdateCustomerWindow : Window
    {
        private readonly CustomerServiceClient _customerServiceClient = new CustomerServiceClient();
        private readonly GetCustomer _customerToUpdate;
        /// <summary>
        /// Initializes Update Customer Window
        /// </summary>
        public UpdateCustomerWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Initializes UpdateCustomerWindow with customer data for a given Id
        /// </summary>
        /// <param name="id"></param>
        public UpdateCustomerWindow(int id)
        {
            InitializeComponent();
            _customerToUpdate = _customerServiceClient.GetCustomer(id);
            NameTextBox.Text = _customerToUpdate.Name;
            PhoneTextBox.Text = _customerToUpdate.Phone;
            EmailTextBox.Text = _customerToUpdate.Email;
        }
        /// <summary>
        /// Get data from UpdateCustomerScreen and update using CustomerService
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpsertCustomer customer = new UpsertCustomer()
                {
                    Name = NameTextBox.Text.Trim(),
                    Phone = PhoneTextBox.Text.Trim(),
                    Email = EmailTextBox.Text.Trim(),
                    Id = this._customerToUpdate.Id
                };
                MessageBox.Show(HttpStatusCode.OK == _customerServiceClient.UpdateCustomer(customer)
                    ? CommonConstants.RecordUpdated
                    : CommonConstants.RecordNotUpdated);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}