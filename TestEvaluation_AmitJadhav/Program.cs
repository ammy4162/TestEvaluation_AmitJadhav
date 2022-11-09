using System;
using System.Collections.Generic;

namespace ClientTest_AmitJadhav
{
    //Vending Machine Program
    public class Program
    {
        double amount = 0;
        double currentAmount = 0;
        static void Main(string[] args)
        {

            Program program = new Program();
            program.VendingMachineMain(program);
            Console.ReadLine();
        }

        public void VendingMachineMain(Program program)
        {
            Dictionary<int, double> productPrice = new Dictionary<int, double>() {
                {1, 1},
                {2, 0.5},
                {3, 0.65}
            };

            int product = program.ProductSelection();

            if (product != 1 && product != 2 && product != 3)
            {
                Console.WriteLine("Wrong input entered please try again...");
                product = program.ProductSelection();
            }

            Console.WriteLine("Please Insert The Coins....");
            int isInsufficentAmount = program.ProcessMechanism(program, product, productPrice);
            
            while (isInsufficentAmount != 0)
            {
                Console.WriteLine("isInsufficentAmount" + isInsufficentAmount);
                if (amount < productPrice[product])
                {
                    Console.WriteLine("Amount" + amount);
                    isInsufficentAmount = program.ProcessMechanism(program, product, productPrice);
                }
            }
            if (isInsufficentAmount == 0)
            {
                Console.WriteLine("Thank You");
            }
            
        }
        public int ProcessMechanism(Program program, int product, Dictionary<int, double> productPrice)
        {
                                   
            int process = 1;
            while (process != 0)
            {
                amount = program.CoinMechanism(program, amount, currentAmount);
                process = program.CoinProcess(process);
            }

            amount = Math.Round(amount, 2);

            if (amount >= productPrice[product])
            {
                Console.WriteLine("\n Here is your " + ((Products)product).ToString() + "\n\n");
            }
            else
            {
                Console.WriteLine("\n Insuffient amount....Do you want to continue 1.Yes 0.No(Exit The Transaction)");
                int finalData = Convert.ToInt32(Console.ReadLine());
                if(finalData == 1)
                {
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        // To select the product use the numbers
        public int ProductSelection()
        {
            int result = 0; 
            Console.WriteLine("We have " +
                              " 1.Cola($1)" +
                              " 2.Chips($0.5)" +
                              " 3.Candy($0.65) " +
                              "What do you want please select");
            try
            {
                result = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                result = 0;
                Console.WriteLine("Please enter integer value from list");
            }

            return result;
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
