using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEx.Model
{
    public class InvalidAmountOrBalanceException : ApplicationException
    {
    }

    public class InvalidIncrementToInterestRate : ApplicationException
    {
    }

    public class Account
    {

        public long AccountNo { get; set; }
        public double Balance { get; set; }
        public double InterestRate { get; set; }



        public Account(long accountNo, double balance, double interestRate)
        {
            AccountNo = accountNo;
            Balance = balance;
            InterestRate = interestRate;
        }

        public void Withdraw(double amount)
        {
            if (Balance >= amount && amount > 0)
            {
                Balance -= amount;
            }
            else
            {
                throw new InvalidAmountOrBalanceException();
            }
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
            else
            {
                throw new InvalidAmountOrBalanceException();
            }
        }

        public void AddInterestRate(double interestRate)
        {
            if (interestRate > 0)
            {
                InterestRate += interestRate;
            }
            else
            {
                throw new InvalidIncrementToInterestRate();            
            }
        }
    }
}
