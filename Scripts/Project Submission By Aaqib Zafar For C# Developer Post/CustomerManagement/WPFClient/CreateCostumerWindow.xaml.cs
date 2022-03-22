using System.Net;
using System.Windows;
using WPFClient.CustomerCRUDService;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for CreateCustomerWindow.xaml
    /// </summary>
    public partial class CreateCustomerWindow : Window
    {
        private readonly CustomerServiceClient _customerServiceClient = new CustomerServiceClient();
        public CreateCustomerWindow()
        {
            InitializeComponent();
        }

        private void CreateUserBtn_Click(object sender, RoutedEventArgs e)
        {
            UpsertCostumer newCostumer = new UpsertCostumer()
            {
                Name = NameTextBox.Text.Trim(),
                Phone = PhoneTextBox.Text.Trim(),
                Email = EmailTextBox.Text.Trim(),
            };
            if (HttpStatusCode.OK == _customerServiceClient.Insert(newCostumer))
            {
                MessageBox.Show(Constants.RecordCreated);
                NameTextBox.Clear();
                PhoneTextBox.Clear();
                EmailTextBox.Clear();
            }
            else
            {
                MessageBox.Show(Constants.RecordNotCreated);
            }
        }
    }
}
