using System.Net;
using System.Windows;
using WPFClient.CustomerCRUDService;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for UpdateUserWindow.xaml
    /// </summary>
    public partial class UpdateUserWindow : Window
    {
        private readonly CustomerServiceClient _customerServiceClient = new CustomerServiceClient();
        public UpdateUserWindow()
        {
            InitializeComponent();
        }

        private void UpdateUserBtn_Click(object sender, RoutedEventArgs e)
        {
            UpsertCostumer newCostumer = new UpsertCostumer()
            {
                Name = NameTextBox.Text.Trim(),
                Phone = PhoneTextBox.Text.Trim(),
                Email = EmailTextBox.Text.Trim(),
            };
            MessageBox.Show(HttpStatusCode.OK == _customerServiceClient.Update(newCostumer)
                ? Constants.RecordUpdated
                : Constants.RecordNotUpdated);
        }
    }
}
