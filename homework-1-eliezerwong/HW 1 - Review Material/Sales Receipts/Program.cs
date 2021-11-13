using System;
using System.Collections.Generic;

//MIS 3033-003
//Eliezer E Wong

namespace Sales_Receipts
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = "--- Sales Receipts ---";
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title);

            Dictionary<int, List<Receipt>> receipts = new Dictionary<int, List<Receipt>>();

            //receipts = populateReceipt(); //to test 

            string answer;
            do
            {
                int cogs = validateIntergerInput("Enter number of cogs >> ", "Sorry invalid, please enter a vaild value >> ");
                int gears = validateIntergerInput("Enter number of gears >> ", "Sorry invalid, please enter a vaild value >> ");
                int id = validateIntergerInput("Enter customer id >> ", "Sorry invalid, please enter a vaild value >> ");

                Receipt receipt = new Receipt(id, cogs, gears);

                if (receipts.ContainsKey(id) == false)
                {
                    receipts.Add(id, new List<Receipt>());
                }

                receipts[id].Add(receipt);

                Console.WriteLine("Do you want to enter information for another receipt? Yes or No >>");
                answer = Console.ReadLine().ToLower();
            } while (answer == "yes");

            do
            {
                displayOptions();
                answer = Console.ReadLine();

                int choice = 0;
                while (int.TryParse(answer, out choice) == false || (choice != 1 && choice != 2 && choice != 3))
                {
                    Console.WriteLine($"{answer} is not a vaild choice. Enter a menu number from 1 - 3 >> ");
                    displayOptions();
                    answer = Console.ReadLine();
                }

                switch (choice)
                {
                    case 1: //CustomerID
                        int id = validateIntergerInput("Enter customer id that you want receipts from >>", "Invaild customer id, please try again");
                        displayReceiptsByCustomerID(receipts, id);
                        break;

                    case 2: //All receipts
                        displayReceiptsForToday(receipts);
                        break;

                    case 3: //Highest total
                        displayReceiptWithHighestTotal(receipts);
                        break;
                }

                Console.WriteLine("Do you want display more receipts? Yes or No >>");
                answer = Console.ReadLine().ToLower();
            } while (answer == "yes");


            Console.ReadKey();
        }

        /// <summary>
        /// populate receipts to test app. creates 3 customers for which the 1st customer has 3 receipts
        /// </summary>
        /// <returns></returns>
        //private static Dictionary<int, List<Receipt>> populateReceipt()
        //{
        //    Random random = new Random();
        //    Dictionary<int, List<Receipt>> receipts = new Dictionary<int, List<Receipt>>();

        //    for (int i = 0; i < 3; i++)
        //    {
        //        receipts.Add(i, new List<Receipt>());
        //        Receipt r1 = new Receipt(i, random.Next(), random.Next());
        //        r1.SaleDate = Convert.ToDateTime("1/1/2020 5:00");
        //        receipts[i].Add(r1);
        //        if (i == 0)
        //        {
        //            Receipt r2 = new Receipt(i, 15, 15);
        //            r2.SaleDate = Convert.ToDateTime("1/1/2020 7:00");
        //            receipts[i].Add(r2);
        //            Receipt r3 = new Receipt(i, 5, 5);
        //            r3.SaleDate = Convert.ToDateTime("1/1/2020 5:00");
        //            r3.CogQuantity = int.MaxValue;
        //            r3.GearQuantity = int.MaxValue;
        //            receipts[i].Add(r3);
        //        }
        //    }

        //    return receipts;
        //}

        /// <summary>
        /// Replaces the highest receipt with var highest, prints the receipt of the highest
        /// </summary>
        /// <param name="receipts"></param>
        private static void displayReceiptWithHighestTotal(Dictionary<int, List<Receipt>> receipts)
        {
            double highest = -1;

            foreach (var customer in receipts.Keys)
            {
                foreach (var receipt in receipts[customer])
                {
                    if (receipt.CalculateTotal() > highest)
                    {
                        highest = receipt.CalculateTotal();
                    }
                }
            }

            foreach (var customer in receipts.Keys)
            {
                foreach (var receipt in receipts[customer])
                {
                    if (receipt.CalculateTotal() == highest)
                    {
                        receipt.PrintReceipt();
                    }
                }
            }
        }
        
        /// <summary>
        /// Runs through all the customers in receipt key then runs through all receipts for that customer and prints all receipts with same sale date as today
        /// </summary>
        /// <param name="receipts"></param>
        private static void displayReceiptsForToday(Dictionary<int, List<Receipt>> receipts)
        {
            foreach (var customer in receipts.Keys)
            {
                foreach (var receipt in receipts[customer])
                {
                    if (receipt.SaleDate.Date == DateTime.Now.Date)
                    {
                        receipt.PrintReceipt();
                    }
                }
            }
        }

        /// <summary>
        /// Displays all receipts of the customer
        /// </summary>
        /// <param name="receipts"></param>
        /// <param name="id"></param>
        private static void displayReceiptsByCustomerID(Dictionary<int, List<Receipt>> receipts, int id)
        {
            if (receipts.ContainsKey(id) == false)
            {
                Console.WriteLine($"Sorry customer id {id} has no receipts");
            }
            else
            {
                foreach (var receipt in receipts[id])
                {
                    receipt.PrintReceipt();
                }
            }
        }

        /// <summary>
        /// Displays the receipt options for user
        /// </summary>
        private static void displayOptions()
        {
            string options = "".PadLeft(30, '#') +
                             "\n\tOptions" +
                             "\n1. By customer ID" +
                             "\n2. All of today's receipts" +
                             "\n3. Receipt with highest total\n" +
                             "".PadLeft(30, '#');

            Console.WriteLine(options);
        }

        /// <summary>
        /// Validate user's input as int. Else reprompt invaildMessage until int is entered
        /// </summary>
        /// <param name="initialMessage">First message shown</param>
        /// <param name="invaildMessage">Reprompt message if input is not int</param>
        /// <returns>A vaild int required for the question</returns>
        private static int validateIntergerInput(string initialMessage, string invaildMessage)
        {
            int value;
            Console.WriteLine(initialMessage);
            string input = Console.ReadLine();
            while (int.TryParse(input, out value) == false)
            {
                Console.WriteLine(invaildMessage);
                input = Console.ReadLine();
            }

            return value;
        }
    }
}
