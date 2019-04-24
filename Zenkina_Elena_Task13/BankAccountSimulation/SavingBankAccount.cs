using System;

namespace BankAccountSimulation
{
	public class SavingBankAccount : BankAccount
	{
		protected int withdrawCount = 0;

		public SavingBankAccount(string accountOwnerName, string accountNumber)
			: base(accountOwnerName, accountNumber)
		{
			this.MinAccountBalance = 20000m;
			this.MaxDepositAmount = 50000m;
			InteresetRate = 3.5m;
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
                throw new BankAccountException.NegativeAmountException($"При снятии со счета {AccountNumber} клиента {AccountOwnerName}" +
                    $"сумма для снятия не может быть отрицательной.", DateTime.Now, amount);
            }

            if (withdrawCount >= 3)
			{
                throw new BankAccountException.ThriceWithdrawException($"Для счета {AccountNumber} клиента {AccountOwnerName} " +
                    "невозможно снять деньги более трех раз", DateTime.Now);
			}

			if (AccountBalance - amount <= MinAccountBalance)
			{
                throw new BankAccountException.LimitIsReachedException($"Для счета {AccountNumber} клиента {AccountOwnerName} " +
                    $"cумма на счете не может быть меньше {MinAccountBalance}", DateTime.Now, MinAccountBalance);
            }

			AccountBalance = AccountBalance - amount;
			withdrawCount++;

			TransactionSummary = string.Format("{0}\n Withdraw:{1}", TransactionSummary, amount);
		}

		public override void GenerateAccountReport()
		{
			Console.WriteLine("Saving Account Report");
			base.GenerateAccountReport();

			if (AccountBalance < 15000)
			{
				throw new BankAccountException.NotReportException($"Невозможно создать отчет по счету {AccountNumber} клиента {AccountOwnerName} " +
                    $"при балансе ниже 15 000", DateTime.Now);
			}

			Console.WriteLine("Sending Email for Account {0}", AccountNumber);
		}
	}
}
