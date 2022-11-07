using System;
using System.Collections.Generic;

namespace ClientTest_AmitJadhav
{
    //Vending Machine Program
    public class Program
    {
        static void Main(string[] args)
        {
            double amount = 0;
            double currentAmount = 0;
            int process = 1;
            Dictionary<int, double> productPrice = new Dictionary<int, double>() {
                {1, 1},
                {2, 0.5},
                {3, 0.65}
            };

            Program program = new Program();

            int product = program.ProductSelection();

            if (product != 1 && product != 2 && product != 3)
            {
                Console.WriteLine("Wrong input entered please try again...");
            }

            Console.WriteLine("Please Insert The Coins....");

            while (process != 0)
            {
                amount = program.CoinMechanism(program, amount, currentAmount);
                process = program.CoinProcess(process);
            }

            amount = Math.Round(amount, 2);

            if (amount >= productPrice[product])
            {
                Console.WriteLine("\n Here is your " + ((Products)product).ToString() + "\n\n Thank You");
            }
            else
            {
                Console.WriteLine("\n Insuffient amount....");
            }

            Console.ReadLine();
        }

        // To select the product use the numbers
        public int ProductSelection()
        {
            Console.WriteLine("We have " +
                              " 1.Cola($1)" +
                              " 2.Chips($0.5)" +
                              " 3.Candy($0.65) " +
                              "What do you want please select");
            return Convert.ToInt32(Console.ReadLine());
        }

        // To accept the coins multiple times
        public int CoinProcess(int process)
        {

            Console.WriteLine("\n Do you want to continue the coin insertion? If yes press 1 if no press 0");
            int processInput = Convert.ToInt32(Console.ReadLine());
            if (processInput == 0)
            {
                process = 0;
            }
            else if (processInput != 1)
            {
                Console.WriteLine("Invalid Input....");
            }
            return process;
        }

        // To do the addition of coins that is inserted by user in single time
        public double CoinMechanism(Program program, double amount, double currentAmount)
        {
            Dictionary<int, double> coinData = new Dictionary<int, double>() {
                {1, 0.05},
                {2, 0.1},
                {3, 0.25}
            };
            Console.WriteLine("Enter your coin \n 1.nickel ($0.05) \n 2.dimes ($0.1) \n 3.quarters ($0.25)");
            int coin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number of coin inserted....");
            int numberOfCoins = Convert.ToInt32(Console.ReadLine());
            if (coin > 3 || coin == 0)
            {
                Console.WriteLine("Enter Valid Coins.....");
            }
            else
            {
                double money = program.AmountCalculation(coinData[coin], numberOfCoins, currentAmount);
                amount += money;
            }

            return amount;
        }

        // Final amount calculation
        public double AmountCalculation(double coinAmount, int numberOfCoins, double currentAmount)
        {
            if (currentAmount == 0)
            {
                currentAmount = coinAmount * numberOfCoins;
            }
            else
            {
                currentAmount += (coinAmount * numberOfCoins);
            }
            return currentAmount;
        }

        // Enum of product used as constants
        public enum Products
        {
            Cola = 1,
            Chips = 2,
            Candy = 3
        }
    }
}
