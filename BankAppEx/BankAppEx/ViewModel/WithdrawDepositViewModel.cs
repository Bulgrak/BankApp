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
    public class WithdrawDepositViewModel : INotifyPropertyChanged
    {
        private static WithdrawDepositViewModel instance;
        private ObservableCollection<Account> accounts;
        public ObservableCollection<Customer> Customers { get; set; }
        private string accountNo;
        private string balance;
        private string interestRate;
        private string customerNo;
        public ICommand WithdrawCommand { get; set; }
        public ICommand DepositCommand { get; set; }
        public ICommand SetInterestRateCommand { get; set; }
        public ICommand AddInterestRateCommand { get; set; }
        public ICommand CreateAccountCommand { get; set; }
        public ICommand CreateCustomerCommand { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        public WithdrawDepositViewModel()
        {
            Customers = new ObservableCollection<Customer>();
            WithdrawCommand = new RelayCommand(new Action<object>(Withdraw));
            DepositCommand = new RelayCommand(new Action<object>(Deposit));
            SetInterestRateCommand = new RelayCommand(new Action<object>(SetInterestRate));
            AddInterestRateCommand = new RelayCommand(new Action<object>(AddInterestRate));
            CreateAccountCommand = new RelayCommand(new Action<object>(CreateAccount));
            CreateCustomerCommand = new RelayCommand(new Action<object>(AddCustomer));
        }

        public string AccountNo
        {
            get { return accountNo; }
            set
            {
                accountNo = value;
                OnPropertyChanged("AccountNo");
            }
        }

        public string Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
            }
        }

        public string InterestRate
        {
            get { return interestRate; }
            set
            {
                interestRate = value;
                OnPropertyChanged("InterestRate");
            }
        }

        public string CustomerNo
        {
            get { return customerNo; }
            set
            {
                customerNo = value;
                OnPropertyChanged("CustomerNo");
            }
        }

        public void CreateAccount(object o)
        {
            CASelectedCustomer.Accounts.Add(new Account(Convert.ToInt32(AccountNo), Convert.ToDouble(Balance), Convert.ToDouble(InterestRate)));
            AccountNo = string.Empty;
            Balance = string.Empty;
            InterestRate = string.Empty;
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

        private Customer caselectedCustomer;
        public Customer CASelectedCustomer
        {
            get { return caselectedCustomer; }
            set
            {
                if (caselectedCustomer == value)
                    return;
                caselectedCustomer = value;
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

        public void Withdraw(object o)
        {
            SelectedAccount.Withdraw(Convert.ToDouble(o));
        }

        public void Deposit(object o)
        {
            SelectedAccount.Deposit(Convert.ToDouble(o));
        }

        public void SetInterestRate(object o)
        {
            SelectedAccount.InterestRate = Convert.ToDouble(o);
        }

        public void AddInterestRate(object o)
        {
            selectedAccount.AddInterestRate(Convert.ToDouble(o));
        }
        


        public static WithdrawDepositViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new WithdrawDepositViewModel();
                return instance;
            }
        }
        
        public void AddCustomer(object o)
        {
            Customers.Add(new Customer(o.ToString()));
            CustomerNo = string.Empty;
        }

        //public void AddAccount(Customer customer, long accountNo, double balance, double interestRate)
        //{
        //    customer.Accounts.Add(new Account(accountNo, balance, interestRate));
        //    AccountNo = string.Empty;
        //    Balance = string.Empty;
        //    InterestRate = string.Empty;
        //}

        public void RemoveAccount(Customer customer, Account account)
        {
            customer.Accounts.Remove(account);
        }


    }

    public class RelayCommand : ICommand
    {
        private Action<object> _action;

        public RelayCommand(Action<object> action)
        {
            _action = action;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        #endregion
    }

}
