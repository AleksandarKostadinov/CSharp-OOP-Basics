using System;
using System.Collections.Generic;
using System.Dynamic;

public class StartUp
{
    public static void Main()
    {
        var accounts = new Dictionary<int, BankAccount>();
        var line = Console.ReadLine();

        while (line != "End")
        {
            var cmdArgs = line.Split();

            var command = cmdArgs[0];

            switch (command)
            {
                case "Create":
                    Create(cmdArgs, accounts);
                    break;
                case "Deposit":
                    Deposit(cmdArgs, accounts);
                    break;
                case "Withdraw":
                    Withdraw(cmdArgs, accounts);
                    break;
                case "Print":
                    Print(cmdArgs, accounts);
                    break;
            }

            line = Console.ReadLine();
        }
    }

    public static void Print(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        if(!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
            return;
        }
        Console.WriteLine(accounts[id].ToString());
    }

    public static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var amount = double.Parse(cmdArgs[2]);

        if (accounts.ContainsKey(id))
        {
            if (accounts[id].Balance < amount)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                accounts[id].Balance -= amount;
            }
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    public static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        var amount = double.Parse(cmdArgs[2]);

        if (accounts.ContainsKey(id))
        {
            accounts[id].Balance += amount;
        }
        else
        {
            Console.WriteLine("Account does not exist");
        }
    }

    public static void Create(string[] cmdArgs, Dictionary<int, BankAccount> accounts)
    {
        var id = int.Parse(cmdArgs[1]);
        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.ID = id;

            accounts.Add(id, acc);
        }
    }
}
