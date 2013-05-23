using BankAppEx.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankAppEx.ViewModel
{
    public class CustomerViewModel 
    {
        private static CustomerViewModel instance;
        public ObservableCollection<Customer> Customers { get; set; }

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
