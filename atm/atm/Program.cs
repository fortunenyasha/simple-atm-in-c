using System;
using System.Runtime.InteropServices;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;
    public cardHolder( string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin; 
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;

    }
    public String getCardNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }
    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit ");
            Console.WriteLine("2. Withdraw ");
            Console.WriteLine("3. Show Balance ");
            Console.WriteLine("4. Exit ");
        }
        //user deposit cash
        void deposit (cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit: ");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.balance = currentUser.getBalance() + deposit;
            Console.WriteLine("Thank you for depositing cash. Your current balance is R" + currentUser.getBalance());
        }
        //user withdraw
        void withdraw(cardHolder currentUser)
        {
            
            Console.WriteLine(" How much money would you like to withdraw: ");
            double withdraw = double.Parse(Console.ReadLine());

            //check if user have enough money
            if(currentUser.getBalance() < withdraw ) 
            {
                Console.WriteLine("You have insufficient funds :");
            }
            else
            {
                //currentUser.setBalance(currentUser.getBalance() - withdraw);
                currentUser.balance = currentUser.getBalance() - withdraw;
                Console.WriteLine("your transaction was successful. Your new balance is R" + currentUser.getBalance());
            }
        }
        void balance (cardHolder currentUser)
        {
            Console.WriteLine("Current Balance: "+ currentUser.getBalance());
        }
        //add account holders
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("2434535467890354", 1234, "john", "smith", 340.71));
        cardHolders.Add(new cardHolder("2434535467896743", 4321, "mpho", "dube", 500.00));
        cardHolders.Add(new cardHolder("2434535467897834", 8888, "frida", "Dickerson", 450.89));
        cardHolders.Add(new cardHolder("2434535467890681", 2468, "dawn", "smith", 871.62));

        //prompt user
        Console.WriteLine("Welcome to your ATM Bank ");
        Console.WriteLine("Please insert your debit card number: ");
        String debitCardNum = "";
        cardHolder currentUser;
        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against the list above
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("the card number cannot be recognized. Please tyr again!"); }
            }
            catch (Exception e) { Console.WriteLine("the card number cannot be recognized. Please tyr again!"); }
        }
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() ==userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again!"); }
            }
            catch (Exception e) { Console.WriteLine("Incorrect Pin. Please try again!"); }
        }
        Console.WriteLine(" Welcome " + currentUser.getFirstName() + " " + currentUser.getLastName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            if (option == 2) { withdraw(currentUser); }
            if (option == 3) { balance(currentUser); }
            if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day :)");

    }
}