using BankAppEx.ViewModel;
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

namespace BankAppEx
{
    /// <summary>
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : UserControl
    {
        private WithdrawDepositViewModel withdrawDepositViewModel;
        public CreateCustomer()
        {
            InitializeComponent();
            withdrawDepositViewModel = WithdrawDepositViewModel.Instance;
            DataContext = withdrawDepositViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                withdrawDepositViewModel.AddCustomer(txtCustomerNo.Text);
                txtCustomerNo.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
