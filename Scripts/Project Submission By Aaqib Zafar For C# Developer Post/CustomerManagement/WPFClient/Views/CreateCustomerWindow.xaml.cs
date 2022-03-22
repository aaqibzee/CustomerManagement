using System;
using System.Net;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using WPFClient.Constants;
using WPFClient.CustomerService;

namespace WPFClient.Views
{
    /// <summary>
    /// Interaction logic for CreateCustomerWindow.xaml
    /// </summary>
    public partial class CreateCustomerWindow : Window
    {
        private readonly CustomerServiceClient _customerServiceClient = new CustomerServiceClient();
        /// <summary>
        /// Initializes CreateCustomerWindow
        /// </summary>
        public CreateCustomerWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Get data from create customer screen into calls CustomerService to create new customer 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpsertCustomer customer = new UpsertCustomer()
                {
                    Name = NameTextBox.Text.Trim(),
                    Phone = PhoneTextBox.Text.Trim(),
                    Email = EmailTextBox.Text.Trim(),
                };
                if (HttpStatusCode.OK == _customerServiceClient.InsertCustomer(customer))
                {
                    MessageBox.Show(CommonConstants.RecordCreated);
                    NameTextBox.Clear();
                    PhoneTextBox.Clear();
                    EmailTextBox.Clear();
                }
                else
                {
                    MessageBox.Show(CommonConstants.RecordNotCreated);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
