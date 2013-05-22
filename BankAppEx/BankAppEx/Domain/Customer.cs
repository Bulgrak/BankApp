using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEx.Model
{
    class Customer
    {
        public string CustomerNo { get; set; }
        public List<Account> Accounts { get; set; }

        public Customer(string customerNo)
        {
            CustomerNo = customerNo;
            Accounts = new List<Account>();
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
