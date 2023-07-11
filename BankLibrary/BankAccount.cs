using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
   public class BankAccount
   {
      //Base Class
      public string Number { get; }
      public string Owner { get; }

      public decimal Balance
      {
         get
         {
            decimal balance = 0;
            foreach (var item in allTransaction)
            {
               balance += item.Amount;
            }
            return balance;
         }
      }

      private static int accountNumberSeed = 1234654765;
      private List<Transaction> allTransaction = new List<Transaction>();

      public BankAccount(string owner, decimal initialBalance)
      {
         Number = accountNumberSeed.ToString();
         accountNumberSeed++;
         Owner = owner;
         MakeDeposit(initialBalance, DateTime.Now, "initial balance");
      }

      public void MakeDeposit(decimal amount, DateTime date, string note)
      {
         if (amount < 0)
         {
            throw new ArgumentOutOfRangeException(nameof(amount), "amount of deposit must be positive");
         }
         var deposit = new Transaction(amount, date, note);
         //Console.WriteLine("deposit amount is "+ amount);
         allTransaction.Add(deposit);
      }

      public void MakeWithdrawl(decimal amount, DateTime date, string note)
      {
         if (amount <= 0)
         {
            throw new ArgumentOutOfRangeException(nameof(amount), "amount of deposit must be positiv");
         }

         if (Balance - amount < 0)
         {
            throw new InvalidOperationException("not sufficient funds");
         }

         var withdrawl = new Transaction(-amount, date, note);
         allTransaction.Add(withdrawl);
      }

      //Get hiostory of transaction
      public string GetTransactionHistory()
      {
         var report = new System.Text.StringBuilder();
         decimal balance = 0;
         report.AppendLine("Date\t\t\tAmount\t\t\tBalance\t\t\tNote");
         foreach (var item in allTransaction)
         {
            balance += item.Amount;
            report.AppendLine($"{item.Date.ToShortDateString()}\t\t{item.Amount}\t\t\t{balance}\t\t\t{item.Note}");
         }
         return report.ToString();

      }

      public virtual void PerformMonthEndTransaction() { }

   }

   //Inheritance
   public class InterestBankAccount : BankAccount
   {
      //private int interestRate = 0;
      public InterestBankAccount(string name, decimal initialBalance) : base(name, initialBalance)
      {
         //this.interestRate = interestRate;
      }
      public override void PerformMonthEndTransaction()
      {
         if (Balance > 500m)
         {
            decimal interest = Balance * 0.05m;
            MakeDeposit(interest, DateTime.Now, "apply monthly interest");
         }
      }
   }

   public class LineOfCreditAccount : BankAccount
   {
      public LineOfCreditAccount(string name, decimal initialBalance) : base(name, initialBalance) { }
   }

   public class GiftCardAccount : BankAccount
   {
      public GiftCardAccount(string name, decimal initialBalance) : base(name, initialBalance) { }
   }
}
