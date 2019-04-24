using System;
using BankAccountException;

namespace BankAccountSimulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            BankAccount savingAccount = new SavingBankAccount("Sarvesh", "S12345");
            BankAccount currentAccount = new CurrentBankAccount("Mark", "C12345");

            Deposit(savingAccount, 40000);
            Deposit(savingAccount, -1000);
            Withdraw(savingAccount, 1000);
            Withdraw(savingAccount, 1000);
            Withdraw(savingAccount, 1000);
            Withdraw(savingAccount, 1000);

            // Generate Report
            savingAccount.GenerateAccountReport();

            Console.WriteLine();

            Deposit(currentAccount, 40000);
            Withdraw(currentAccount, 1000);

            Console.ReadLine();
        }

        private static void Deposit(BankAccount bankAccount, decimal number)
        {
            var log = new WriteToConsole();
            try
            {
                bankAccount.Deposit(number);
            }
            catch (NegativeAmountException e)
            {
                log.Write(e.ToString());
            }
            catch (MaxAmountException e)
            {
                log.Write(e.ToString());
            }
            catch (LimitIsReachedException e)
            {
                log.Write(e.ToString());
            }
        }

        private static void Withdraw(BankAccount bankAccount, decimal number)
        {
            var log = new WriteToConsole();
            try
            {
                bankAccount.Withdraw(number);
            }
            catch (NegativeAmountException e)
            {
                log.Write(e.ToString());
            }
            catch (MaxAmountException e)
            {
                log.Write(e.ToString());
            }
            catch (LimitIsReachedException e)
            {
                log.Write(e.ToString());
            }
            catch (ThriceWithdrawException e)
            {
                log.Write(e.ToString());
            }
        }
    }
}
