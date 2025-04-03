using ContaCorrente.ConsoleApp.Entities.Utils;

namespace ContaCorrente.ConsoleApp.Entities;

public class CurrentAccount
{
    public int AccountNumber;
    public decimal AvailableBalance;
    public decimal OverdraftLimit;
    public AccountMovement[] Transactions;
    public int actualTransaction = 0;

    public CurrentAccount (int accountNumber, decimal availableBalance, decimal overdraftLimit, int maxTransactions = 10)
    {
        AccountNumber = accountNumber;
        AvailableBalance = availableBalance;
        OverdraftLimit = overdraftLimit;
        Transactions = new AccountMovement[maxTransactions];
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            ViewWriteErrors.ValueToWithdrawNeedsToBePositive();
            return;
        }
        if (amount > AvailableBalance + OverdraftLimit)
        {
            ViewWriteErrors.InsuficientBalanceToWithdraw();
            return;
        }
        AvailableBalance -= amount;
        AddTransaction(new AccountMovement(amount, "Débito"));
    }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            ViewWriteErrors.ValueToDepositNeedsToBePositive();
            return;
        }
        AvailableBalance += amount;
        AddTransaction(new AccountMovement(amount, "Crédito"));
    }
    public void TransferTo(CurrentAccount account, decimal amount)
    {
        if (amount <= 0)
        {
            ViewWriteErrors.ValueToTransferNeedsToBePositive();
            return;
        }
        if (amount > AvailableBalance + OverdraftLimit)
        {
            ViewWriteErrors.InsuficientBalanceToTransfer();
            return;
        }
        Withdraw(amount);
        account.Deposit(amount);
    }
    public void AddTransaction(AccountMovement accountMovement)
    {
        if (actualTransaction < Transactions.Length)
        {
            Transactions[actualTransaction] = accountMovement;
            actualTransaction++;
        }
        else
        {
            ViewWriteErrors.HitMaxTransactionLimit();
        }
    }
    public void ShowExtract()
    {
        ViewWrite.AccountMovementMessage();
        if (actualTransaction == 0)
        {
            ViewWriteErrors.TransactionHistoryIsEmpty();
        }
        else
        {
            for (int i = 0; i < actualTransaction; i++)
            {
                ViewWrite.TransactionsMessage(Transactions[i].Type, Transactions[i].Amount);
            }
        }
        ViewWrite.ActualBalanceHeader(AvailableBalance);
    }
}
