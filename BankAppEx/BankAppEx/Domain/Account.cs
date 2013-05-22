using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEx.Model
{
    class Account
    {
        public long AccountNo { get; set; }
        public double Balance { get; set; }
        public double InterestRate { get; set; }

        public Account(double balance, double interest)
        {
        }

        public bool WithDraw(double amount)
        {
            bool ok = false;
            if (Balance >= amount)
            {
                Balance -= amount;
                ok = true;
            }
            return ok;
        }

        public bool Deposit(double amount)
        {
            bool ok = false;
            if (amount > 0)
            {
                Balance += amount;
                ok = true;
            }
            return ok;
        }

        public void AddInterestRate(double interestRate)
        {
            InterestRate += interestRate;
        }
    }
}
