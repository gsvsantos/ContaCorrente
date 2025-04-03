using ContaCorrente.ConsoleApp.Entities;

namespace ContaCorrente.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        CurrentAccount account1 = new CurrentAccount(12, 1000, 0);
        CurrentAccount account2 = new CurrentAccount(13, 300, 0);

        account1.Withdraw(200);
        account1.Deposit(300);
        account1.Deposit(500);
        account1.Withdraw(200);

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
