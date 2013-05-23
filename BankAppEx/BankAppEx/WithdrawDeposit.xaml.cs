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
    /// Interaction logic for WithdrawDeposit.xaml
    /// </summary>
    public partial class WithdrawDeposit : UserControl
    {
        private CustomerViewModel customerViewModel;

        public WithdrawDeposit()
        {
            InitializeComponent();
            customerViewModel = CustomerViewModel.Instance;
            cmbCustomerNo.ItemsSource = customerViewModel.Customers;
        }

        private void cmbCustomerNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer c = (Customer)cmbCustomerNo.SelectedItem;
            cmbAccount.ItemsSource = c.Accounts;
            cmbAccount.SelectedIndex = -1;
            txtbCurrentBalance.Text = "";
            txtbInterestRate.Text = "";
        }

        private void cmbAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Account a = (Account)cmbAccount.SelectedItem;
            if (a != null)
            {
                txtbCurrentBalance.Text = Convert.ToString(a.Balance);
                txtbInterestRate.Text = Convert.ToString(a.InterestRate);
            }
            else{
                cmbAccount.SelectedIndex = -1;
            }
        }
    }
}
