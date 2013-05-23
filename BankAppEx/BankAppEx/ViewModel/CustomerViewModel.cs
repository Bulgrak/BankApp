using BankAppEx.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankAppEx.ViewModel
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        private static CustomerViewModel instance;
        private ObservableCollection<Account> accounts;
        public ObservableCollection<Customer> Customers { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                if (selectedCustomer == value)
                    return;
                selectedCustomer = value;
                //cmbAccount.ItemsSource = selectedItem.Accounts;
                // Do logic on selection change.
            }
        }

        private Account selectedAccount;
        public Account SelectedAccount
        {
            get { return selectedAccount; }
            set
            {
                if (selectedAccount == value)
                    return;
                selectedAccount = value;
                //cmbAccount.ItemsSource = selectedItem.Accounts;
                // Do logic on selection change.
            }
        }
        

        public CustomerViewModel()
        {
            Customers = new ObservableCollection<Customer>();
        }

        public static CustomerViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomerViewModel();
                return instance;
            }
        }
        
        public void AddCustomer(string customerNo)
        {
            Customers.Add(new Customer(customerNo));
        }

        public void AddAccount(Customer customer, long accountNo, double balance, double interestRate)
        {
            customer.Accounts.Add(new Account(accountNo, balance, interestRate));
        }

        public void RemoveAccount(Customer customer, Account account)
        {
            customer.Accounts.Remove(account);
        }
    }

}
