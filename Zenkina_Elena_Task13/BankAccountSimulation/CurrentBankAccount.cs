using System;

namespace BankAccountSimulation
{
    public class CurrentBankAccount : BankAccount
    {
        public CurrentBankAccount(string accountOwnerName, string accountNumber)
            : base(accountOwnerName, accountNumber)
        {
            this.MinAccountBalance = 0m;
            this.MaxDepositAmount = 100000000m;
            InteresetRate = .25m;
        }

        public override void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new BankAccountException.NegativeAmountException($"При пополнении счета {AccountNumber} клиента {AccountOwnerName} " +
                    $"сумма вклада не может быть отрицательной.", DateTime.Now, amount);
            }

            if (amount >= MaxDepositAmount)
            {
                throw new BankAccountException.MaxAmountException($"На счете {AccountNumber} у клиента {AccountOwnerName} " +
                    $"сумма вклада не может быть больше {MaxDepositAmount}.", DateTime.Now, amount, MaxDepositAmount);
            }

            AccountBalance = AccountBalance + amount;
            TransactionSummary = string.Format("{0}\n Deposit:{1}", TransactionSummary, amount);
        }

        public override void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new BankAccountException.NegativeAmountException($"При снятии со счета {AccountNumber} клиента {AccountOwnerName} " +
                    $"сумма для снятия не может быть отрицательной.", DateTime.Now, amount);
            }

            if (AccountBalance - amount <= MinAccountBalance)
            {
                throw new BankAccountException.LimitIsReachedException($"При снятии со счета {AccountNumber} клиента {AccountOwnerName} " +
                    $"сумма на счете не может быть меньше {MinAccountBalance}", DateTime.Now, MinAccountBalance);
            }

            AccountBalance = AccountBalance - amount;
            TransactionSummary = string.Format("{0}\n Withdraw:{1}", TransactionSummary, amount);
        }

        public override void GenerateAccountReport()
        {
            Console.WriteLine("Current Account Report");
            base.GenerateAccountReport();
        }
    }
}
