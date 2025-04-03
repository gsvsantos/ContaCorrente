namespace ContaCorrente.ConsoleApp.Entities.Utils;

public class ViewWrite
{
    public static void ShowExtractHeader(CurrentAccount account)
    {
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine($"Extrato da Conta #{account.AccountNumber}");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
    }
    public static void ActualBalanceHeader(decimal actualBalance)
    {
        Console.WriteLine("\n---------------------------------------------");
        Console.WriteLine($"Saldo atual: R$ {actualBalance:F2}");
        Console.WriteLine("---------------------------------------------\n");
    }
    public static void AccountMovementMessage()
    {
        Console.WriteLine("Movimentações:");
        Console.WriteLine("---------------------------------------------");
    }
    public static void TransactionsMessage(string type, decimal amount)
    {
        Console.WriteLine($"{type} de R$ {amount:F2}");
    }
}
