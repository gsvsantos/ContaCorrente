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
        AddTransaction(new AccountMovement(amount, "Débito"));
    }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("O valor para depósito precisa ser positivo.");
        }
        AvailableBalance += amount;
        AddTransaction(new AccountMovement(amount, "Crédito"));
    }
    public void TransferTo(CurrentAccount account, decimal amount)
    {
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
    }
    public void ShowStatement()
    {
        Console.WriteLine("Movimentações:");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        for (int i = 0; i < Transaction.Length; i++)
        {
            if (Transaction[i] != null && Transaction[i].Type == "Débito")
            {
                Console.WriteLine($"{Transaction[i].Type}  de R$ {Transaction[i].Amount:F2}");
            }
            else if (Transaction[i] != null && Transaction[i].Type == "Crédito")
            {
                Console.WriteLine($"{Transaction[i].Type} de R$ {Transaction[i].Amount:F2}");
            }
            if (Transaction[0] == null)
            {
                Console.WriteLine("Ainda não foi feito nenhum movimento nesta conta!");
                break;
            }
        }
        Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
        Console.WriteLine($"Saldo atual: R$ {AvailableBalance}");
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");

    }
}
