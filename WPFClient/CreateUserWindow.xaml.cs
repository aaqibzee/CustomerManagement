using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using WPFClient.CustomerCRUDService;

namespace WPFClient
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        private readonly CustomerServiceClient _customerServiceClient = new CustomerServiceClient();
        public CreateUserWindow()
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
            MessageBox.Show(HttpStatusCode.OK == _customerServiceClient.Update(newCostumer)
                ? Constants.RecordCreated
                : Constants.RecordNotCreated);
        }
    }
}
