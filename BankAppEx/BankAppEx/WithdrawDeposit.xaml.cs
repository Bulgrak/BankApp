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
            DataContext = customerViewModel;
            //cmbCustomerNo.ItemsSource = customerViewModel.Customers;
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

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Account a = (Account)cmbAccount.SelectedItem;
                a.Withdraw(Convert.ToDouble(txtWithdraw.Text));
                //customerViewModel.Withdraw(a, Convert.ToDouble(txtWithdraw.Text));
                //txtbCurrentBalance.Text = Convert.ToString(a.Balance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account a = (Account)cmbAccount.SelectedItem;
                a.Deposit(Convert.ToDouble(txtDeposit.Text));
                txtbCurrentBalance.Text = Convert.ToString(a.Balance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSetInterestRate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account a = (Account)cmbAccount.SelectedItem;
                a.InterestRate = Convert.ToDouble(txtSetInterestRate.Text);
                //txtbInterestRate.Text = Convert.ToString(a.InterestRate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddInterestRate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Account a = (Account)cmbAccount.SelectedItem;
                a.AddInterestRate(Convert.ToDouble(txtAddInterestRate.Text));
                //txtbInterestRate.Text = Convert.ToString(a.InterestRate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
