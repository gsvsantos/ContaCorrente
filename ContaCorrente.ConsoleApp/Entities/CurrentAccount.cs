namespace ContaCorrente.ConsoleApp.Entities;

internal class CurrentAccount
{
    public int AccountNumber;
    public decimal AvailableBalance;
    public decimal OverdraftLimit;

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("O valor do saque precisa ser positivo.");
            return;
        }
        if (amount > AvailableBalance)
        {
            Console.WriteLine("Você não tem esse valor disponível em conta.");
            return;
        }
        AvailableBalance -= amount;
    }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("O valor para depósito precisa ser positivo.");
        }
        AvailableBalance += amount;
    }
    public void TransferTo(CurrentAccount account, decimal amount)
    {
        AvailableBalance -= amount;
        account.AvailableBalance += amount;
    }
}
