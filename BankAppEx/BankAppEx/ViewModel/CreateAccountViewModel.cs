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
    public class CreateAccountViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Customer> Customers { get; set; }
        private static CreateAccountViewModel instance;
        private string accountNo;
        private string balance;
        private string interestRate;
        public ICommand CreateAccountCommand { get; set; }

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

        public CreateAccountViewModel()
        {
            this.CreateAccountCommand = new RelayCommand(new Action<object>(CreateAccount));
        }

        public static CreateAccountViewModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new CreateAccountViewModel();
                return instance;
            }
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

        public void CreateAccount(object o)
        {
            SelectedCustomer.Accounts.Add(new Account(Convert.ToInt32(AccountNo), Convert.ToDouble(Balance), Convert.ToDouble(InterestRate)));
        }
    }
}
