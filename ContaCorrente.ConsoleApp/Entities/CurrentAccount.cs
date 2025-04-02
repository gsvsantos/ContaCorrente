namespace ContaCorrente.ConsoleApp.Entities;

public class CurrentAccount
{
    public int AccountNumber;
    public decimal AvailableBalance;
    public decimal OverdraftLimit;
    public AccountMovement[] Transaction;
    public int actualTransaction = 0;

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
        AddTransaction(new AccountMovement(-amount, "Withdraw"));
    }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("O valor para depósito precisa ser positivo.");
        }
        AvailableBalance += amount;
        AddTransaction(new AccountMovement(amount, "Deposit"));
    }
    public void TransferTo(CurrentAccount account, decimal amount)
    {
        AvailableBalance -= amount;
        account.AvailableBalance += amount;
        AddTransaction(new AccountMovement(amount, "TransferTo", this, account));
    }
    public void AddTransaction(AccountMovement accountMovement)
    {
        if (actualTransaction < Transaction.Length)
        {
            Transaction[actualTransaction] = accountMovement;
            actualTransaction++;
        }
    }
}
