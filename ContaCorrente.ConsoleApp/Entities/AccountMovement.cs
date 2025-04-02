namespace ContaCorrente.ConsoleApp.Entities;

public class AccountMovement
{
    public decimal Amount;
    public string Type;
    public CurrentAccount SourceAccount;
    public CurrentAccount DestinationAccount;

    public AccountMovement(decimal amount, string type)
    {
        Amount = amount;
        Type = type;
    }
    public AccountMovement(decimal amount, string type, CurrentAccount sourceAccount, CurrentAccount destinationAccount) : this(amount, type)
    {
        SourceAccount = sourceAccount;
        DestinationAccount = destinationAccount;
    }
}
