namespace ContaCorrente.ConsoleApp.Entities.Utils;

public class ViewWriteErrors
{
    public static void HitMaxTransactionLimit()
    {
        Console.WriteLine("Você atingiu o limite de transações!");
    }
    public static void InsuficientBalanceToTransfer()
    {
        Console.WriteLine("Seu saldo é insuficiente para essa transferência!");
    }
    public static void ValueToTransferNeedsToBePositive()
    {
        Console.WriteLine("O valor de transferência precisa ser positivo.");
    }
    public static void ValueToDepositNeedsToBePositive()
    {
        Console.WriteLine("O valor para depósito precisa ser positivo.");
    }
    public static void InsuficientBalanceToWithdraw()
    {
        Console.WriteLine("Hello, World!");
    }
    public static void ValueToWithdrawNeedsToBePositive()
    {
        Console.WriteLine("O valor do saque precisa ser positivo.");
    }
    public static void TransactionHistoryIsEmpty()
    {
        Console.WriteLine("Ainda não foi feito nenhum movimento nesta conta!");
    }
}
