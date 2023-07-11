//include bank library
using BankLibrary;

//Console.WriteLine("Hello, World!");

//var account = new BankAccount("Aanchal", 1000);

//Console.WriteLine($"Account { account.Number} was created for {account.Owner} with opening bal of {account.Balance}");

//account.MakeWithdrawl(500, DateTime.Now, "withdraw money");
//Console.WriteLine(account.Balance);
//account.MakeDeposit(100, DateTime.Now, "deposit money");
//Console.WriteLine(account.Balance);
//Console.WriteLine(account.GetTransactionHistory());

//Test for -ve balance
//try
//{
//   account.MakeWithdrawl(7500, DateTime.Now, "attemp to withdrawl");
//}
//catch (InvalidOperationException ex)
//{
//   Console.WriteLine("trying to withdraw");
//   Console.WriteLine(ex.ToString());
//   return;
//}


//Test the initial balance must be +ve.
//BankAccount initialAmount;
//try
//{
//   initialAmount = new BankAccount("Invalid", -84);
//}
//catch (ArgumentOutOfRangeException ex)
//{
//   Console.WriteLine("Exception released while creating a new account");
//   Console.WriteLine(ex.ToString());
//   return;
//}

var savings = new InterestBankAccount("saving account", 1000);
savings.MakeDeposit(100, DateTime.Now, "save some money");
savings.MakeDeposit(400, DateTime.Now, "save some more money");

savings.MakeWithdrawl(200, DateTime.Now, "need to pay some bill");
savings.PerformMonthEndTransaction();
Console.WriteLine(savings.GetTransactionHistory());

Console.ReadLine();