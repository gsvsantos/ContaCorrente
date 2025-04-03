namespace ContaCorrente.ConsoleApp.Entities;

public class CurrentAccount
{
    public int AccountNumber;
    public decimal AvailableBalance;
    public decimal OverdraftLimit;
    public AccountMovement[] Transaction;
    public int actualTransaction = 0;

    public CurrentAccount (int accountNumber, decimal availableBalance, decimal overdraftLimit, int maxTransactions = 10)
    {
        AccountNumber = accountNumber;
        AvailableBalance = availableBalance;
        OverdraftLimit = overdraftLimit;
        Transaction = new AccountMovement[maxTransactions];
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("O valor do saque precisa ser positivo.");
            return;
        }
        if (amount > AvailableBalance + OverdraftLimit)
        {
            Console.WriteLine("Hello, World!");
            return;
        }
        AvailableBalance -= amount;
        AddTransaction(new AccountMovement(amount, "Débito"));
    }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("O valor para depósito precisa ser positivo.");
            return;
        }
        AvailableBalance += amount;
        AddTransaction(new AccountMovement(amount, "Crédito"));
    }
    public void TransferTo(CurrentAccount account, decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("O valor de transferência precisa ser positivo.");
            return;
        }
        if (amount > AvailableBalance + OverdraftLimit)
        {
            Console.WriteLine("Seu saldo é insuficiente para essa transferência!");
            return;
        }
        Withdraw(amount);
        account.Deposit(amount);
    }
    public void AddTransaction(AccountMovement accountMovement)
    {
        if (actualTransaction < Transaction.Length)
        {
            Transaction[actualTransaction] = accountMovement;
            actualTransaction++;
        }
        else
        {
            Console.WriteLine("Você atingou o limite de transações!");
        }
    }
    public void ShowStatement()
    {
        Console.WriteLine("Movimentações:");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        if (actualTransaction == 0)
        {
            Console.WriteLine("Ainda não foi feito nenhum movimento nesta conta!");
        }
        else
        {
            for (int i = 0; i < actualTransaction; i++)
            {
                Console.WriteLine($"{Transaction[i].Type} de R$ {Transaction[i].Amount:F2}");
            }
        }
        Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine($"Saldo atual: R$ {AvailableBalance:F2}");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");

    }
}
