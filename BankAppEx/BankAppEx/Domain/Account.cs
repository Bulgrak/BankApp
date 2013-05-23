﻿using System;
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

    public class Account : INotifyPropertyChanged
    {

        public long AccountNo { get; set; }
        public double Balance { get; set; }
        private double interestRate;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public Account(long accountNo, double balance, double interestRate)
        {
            AccountNo = accountNo;
            Balance = balance;
            InterestRate = interestRate;
        }

        public double InterestRate
        {
            get { return interestRate; }
            set { interestRate = value;
            OnPropertyChanged("InterestRate");
            }
        }

        public void Withdraw(double amount)
        {
            if (Balance >= amount && amount > 0)
            {
                Balance -= amount;
                OnPropertyChanged("Balance");
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
                OnPropertyChanged("Balance");
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
                OnPropertyChanged("InterestRate");
            }
            else
            {
                throw new InvalidIncrementToInterestRate();            
            }
        }
    }
}
