using ContaCorrente.ConsoleApp.Entities;

namespace ContaCorrente.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        CurrentAccount account1 = new CurrentAccount();

        account1.AvailableBalance = 1000;
        account1.AccountNumber = 12;
        account1.OverdraftLimit = 0;
        account1.Transaction = new AccountMovement[10];

        account1.Withdraw(200);
        account1.Deposit(300);
        account1.Deposit(500);
        account1.Withdraw(200);

        CurrentAccount account2 = new CurrentAccount();

        account2.AvailableBalance = 300;
        account2.AccountNumber = 13;
        account2.OverdraftLimit = 0;
        account2.Transaction = new AccountMovement[10];

        account1.TransferTo(account2, 400);
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine($"Extrato da Conta #{account1.AccountNumber}");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        account1.ShowStatement();
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine($"Extrato da Conta #{account2.AccountNumber}");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        account2.ShowStatement();
    }
}
