using System;

namespace BankAccountException
{
    [Serializable]
    public abstract class BankException : ApplicationException
    {
        public DateTime ErrorTime { get; set; }

        public BankException() { }

        public BankException(string message, Exception inner) : base(message, inner) { }

        protected BankException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public BankException(string message, DateTime time) : base(message)
        {
            ErrorTime = time;
        }

        public override string ToString()
        {
            return "Время возникновения ошибки: " + ErrorTime  + "\n" + "Ошибка: " + Message + "\n";
        }
    }

    [Serializable]
    public class NegativeAmountException : BankException
    {
        public decimal Amount { get; set; }

        public NegativeAmountException(string message, DateTime time, decimal amount): base (message, time)
        {
            Amount = amount;
        }

        public override string ToString()
        {
            return base.ToString() + "Текущее значение: " + Amount + "\n";
        }
    }

    [Serializable]
    public class MaxAmountException : BankException
    {
        public decimal Amount { get; set; }
        public decimal MaxAmount { get; set; }

        public MaxAmountException(string message, DateTime time, decimal amount, decimal maxAmount) : base(message, time)
        {
            Amount = amount;
            MaxAmount = maxAmount;
        }

        public override string ToString()
        {
            return base.ToString() + "Текущее значение: " + Amount + " не может быть больше " + MaxAmount + "\n";
        }

    }

    [Serializable]
    public class LimitIsReachedException : BankException
    {
        public decimal MinAccountBalance { get; set; }
        public LimitIsReachedException(string message, DateTime time, decimal minAccountBalance) : base(message, time)
        {
            MinAccountBalance = minAccountBalance;
        }

        public override string ToString()
        {
            return base.ToString() + "Текущее значение не может быть меньше " + MinAccountBalance + "\n";
        }
    }

    [Serializable]
    public class ThriceWithdrawException : BankException
    {
        public ThriceWithdrawException(string message, DateTime time) : base(message, time)
        {
        }
    }

    [Serializable]
    public class NotReportException : BankException
    {
        public NotReportException(string message, DateTime time) : base(message, time)
        {
        }

    }
}
