namespace ContaCorrente.ConsoleApp.Entities;

public class AccountMovement
{
    public decimal Amount;
    public string Type;

    public AccountMovement(decimal amount, string type)
    {
        Amount = amount;
        Type = type;
    }
}
