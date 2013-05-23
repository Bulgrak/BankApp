using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAppEx.Model;

namespace BankAppExTestProject
{
    [TestClass]
    public class UnitTest1
    {
        //White box tests
        #region White box tests
        [TestMethod]
        public void TestWithdrawW1()
        {
            long accountNo = 123;
            double balance = 1000.00;
            double interestRate = 0.5;
            Account a = new Account(accountNo, balance, interestRate);
            a.Withdraw(1);
            double expected = 999;
            double actual = a.Balance;
            Assert.AreEqual(expected, actual, 0);
        }

        [TestMethod]
        public void TestWithdrawW2()
        {
            long accountNo = 123;
            double balance = 1000.00;
            double interestRate = 0.5;
            Account a = new Account(accountNo, balance, interestRate);
            a.Withdraw(1000);
            double expected = 0;
            double actual = a.Balance;
            Assert.AreEqual(expected, actual, 0);
        }

        [TestMethod]
        public void TestWithdrawW3()
        {
            long accountNo = 123;
            double balance = 1000.00;
            double interestRate = 0.5;
            Account a = new Account(accountNo, balance, interestRate);
            try
            {
                a.Withdraw(1001);
                Assert.Fail("Should throw an exception");
            }
            catch (InvalidAmountOrBalanceException)
            {
            }
        }

        [TestMethod]
        public void TestWithdrawW4()
        {
            long accountNo = 123;
            double balance = 1000.00;
            double interestRate = 0.5;
            Account a = new Account(accountNo, balance, interestRate);
            try
            {
                a.Withdraw(0);
                Assert.Fail("Should throw an exception");
            }
            catch (InvalidAmountOrBalanceException)
            {
            }
        }

        [TestMethod]
        public void TestDepositW1()
        {
            long accountNo = 123;
            double balance = 1000.00;
            double interestRate = 0.5;
            Account a = new Account(accountNo, balance, interestRate);
            try
            {
                a.Deposit(0);
                Assert.Fail("Should throw an exception");
            }
            catch (InvalidAmountOrBalanceException)
            {
            }
        }

        [TestMethod]
        public void TestDepositW2()
        {
            long accountNo = 123;
            double balance = 1000.00;
            double interestRate = 0.5;
            Account a = new Account(accountNo, balance, interestRate);
            a.Deposit(1000);
            double expected = 2000;
            double actual = a.Balance;
            Assert.AreEqual(expected, actual, 0);
        }
        #endregion

        //Black box tests
        #region Black box Tests
        [TestMethod]
        public void TestDepositdrawB1()
        {
            long accountNo = 123;
            double balance = 1000.00;
            double interestRate = 0.5;
            Account a = new Account(accountNo, balance, interestRate);
            a.Deposit(3520);
            double expected = 4520;
            double actual = a.Balance;
            Assert.AreEqual(expected, actual, 0);
        }

        [TestMethod]
        public void TestDepositB2()
        {
            long accountNo = 123;
            double balance = 1000.00;
            double interestRate = 0.5;
            Account a = new Account(accountNo, balance, interestRate);
            a.Deposit(5520);
            double expected = 6520;
            double actual = a.Balance;
            Assert.AreEqual(expected, actual, 0);
        }

        [TestMethod]
        public void TestWithdrawB3()
        {
            long accountNo = 123;
            double balance = 1000.00;
            double interestRate = 0.5;
            Account a = new Account(accountNo, balance, interestRate);
            a.Withdraw(250);
            double expected = 750;
            double actual = a.Balance;
            Assert.AreEqual(expected, actual, 0);
        }

        [TestMethod]
        public void TestWithdrawB4()
        {
            long accountNo = 123;
            double balance = 1000.00;
            double interestRate = 0.5;
            Account a = new Account(accountNo, balance, interestRate);
            a.Withdraw(102);
            double expected = 898;
            double actual = a.Balance;
            Assert.AreEqual(expected, actual, 0);
        }

        [TestMethod]
        public void TestSetInterestRateB5()
        {
            long accountNo = 123;
            double balance = 1000.00;
            double interestRate = 0.5;
            Account a = new Account(accountNo, balance, interestRate);
            a.AddInterestRate(0.5);
            double expected = 1;
            double actual = a.InterestRate;
            Assert.AreEqual(expected, actual, 0);
        }
        #endregion
    }
}
