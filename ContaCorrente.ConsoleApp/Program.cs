using ContaCorrente.ConsoleApp.Entities;
using ContaCorrente.ConsoleApp.Entities.Utils;

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

        ViewWrite.ShowExtractHeader(account1);
        account1.ShowExtract();

        ViewWrite.ShowExtractHeader(account2);
        account2.ShowExtract();
    }
}
