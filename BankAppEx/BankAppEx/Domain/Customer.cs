using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEx.Model
{
    class Customer
    {
        public string CustomerNo { get; set; }
        public ObservableCollection<Account> Accounts { get; set; }

        public Customer(string customerNo)
        {
            CustomerNo = customerNo;
            Accounts = new ObservableCollection<Account>();
        }

        public double GetTotalBalance()
        {
            double sum = 0;
            for (int i = 0; i < Accounts.Count; i++)
            {
                sum = sum + Accounts[i].Balance;
            }
            return sum;
        }
    }
}
