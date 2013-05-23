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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BankAppEx.ViewModel;
using BankAppEx.Model;

namespace BankAppEx
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : UserControl
    {
        private CustomerViewModel customerViewModel;
        public CreateAccount()
        {
            InitializeComponent();
            customerViewModel = CustomerViewModel.Instance;
            DataContext = customerViewModel;
            //cmbCustomers.ItemsSource = customerViewModel.Customers;
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            Customer c = (Customer)cmbCustomers.SelectedItem;
            customerViewModel.AddAccount(c, Convert.ToInt32(txtAccountNo.Text), Convert.ToDouble(txtBalance.Text), Convert.ToDouble(txtInterestRate.Text));
            txtAccountNo.Text = "";
            txtBalance.Text = "";
            txtInterestRate.Text = "";
        }
    }
}
