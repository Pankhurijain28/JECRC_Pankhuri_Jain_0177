using System;

class BankAccount
{
    public string AccountNumber { get; }
    protected double balance { get; private set; }

    public BankAccount(string accountNumber, double initialDeposit)
    {
        AccountNumber = accountNumber;
        balance = initialDeposit;
    }

    public virtual bool Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            return true;
        }
        return false;
    }

    public virtual bool Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            return true;
        }
        return false;
    }

    public double GetBalance()
    {
        return balance;
    }

    protected void UpdateBalance(double amount)
    {
        balance = amount;
    }
}

class SavingsAccount : BankAccount
{
    private double interestRate;
    private double minimumBalance = 1000;

    public SavingsAccount(string accountNumber, double initialDeposit)
        : base(accountNumber, initialDeposit)
    {
    }

    public override bool Withdraw(double amount)
    {
        if (GetBalance() - amount < minimumBalance)
        {
            Console.WriteLine($"Withdrawal Failed: Minimum balance requirement {minimumBalance}");
            return false;
        }

        return base.Withdraw(amount);
    }

    public void ApplyInterest(double rate)
    {
        interestRate = rate;

        double newBalance = GetBalance() + (GetBalance() * interestRate / 100);

        UpdateBalance(newBalance);

        Console.WriteLine($"Interest Applied,Rate:{interestRate},New Balance:{GetBalance()}");
    }
}

class CurrentAccount : BankAccount
{
    private double overdraftLimit = 2000;
    private double transactionFee = 50;

    public CurrentAccount(string accountNumber, double initialDeposit)
        : base(accountNumber, initialDeposit)
    {
    }

    public override bool Withdraw(double amount)
    {
        if (GetBalance() + overdraftLimit >= amount)
        {
            UpdateBalance(GetBalance() - amount);
            return true;
        }

        Console.WriteLine("Withdrawal Failed: Overdraft limit exceeded");
        return false;
    }

    public void DeductTransactionFee()
    {
        UpdateBalance(GetBalance() - transactionFee);

        Console.WriteLine($"Fee Deducted,Amount:{transactionFee},Remaining:{GetBalance()}");
    }
}

class Program
{
    static void Main()
    {
        string accountType = Console.ReadLine().Trim();

        string accountNumber = Console.ReadLine().Trim();

        double initialDeposit = double.Parse(Console.ReadLine());

        BankAccount account;

        if (accountType == "Savings")
        {
            account = new SavingsAccount(accountNumber, initialDeposit);
        }
        else
        {
            account = new CurrentAccount(accountNumber, initialDeposit);
        }

        while (true)
        {
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
                break;

            string[] parts = input.Split(' ');

            string operation = parts[0];

            if (operation == "Withdraw")
            {
                double amount = double.Parse(parts[1]);
                account.Withdraw(amount);
            }
            else if (operation == "Deposit")
            {
                double amount = double.Parse(parts[1]);
                account.Deposit(amount);
            }
            else if (operation == "GetBalance")
            {
                Console.WriteLine($"Current Balance: {account.GetBalance()}");
            }
            else if (operation == "ApplyInterest" && account is SavingsAccount sa)
            {
                double rate = double.Parse(parts[1]);
                sa.ApplyInterest(rate);
            }
            else if (operation == "DeductTransactionFee" && account is CurrentAccount ca)
            {
                ca.DeductTransactionFee();
            }
        }
    }
}