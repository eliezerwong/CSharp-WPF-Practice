using System;
using System.Collections.Generic;
using System.Text;

namespace Sales_Receipts
{
    public class Receipt
    {
        public int CustomerID { get; set; }
        public int CogQuantity { get; set; }
        public int GearQuantity { get; set; }
        public DateTime SaleDate { get; set; }

        private double SalesTaxPercent;
        private double CogPrice;
        private double GearPrice;

        public Receipt()
        {
            CustomerID = 0;
            CogQuantity = 0;
            GearQuantity = 0;
            SaleDate = DateTime.Now;
            SalesTaxPercent = 0.089;
            CogPrice = 79.99;
            GearPrice = 250.00;
        }
        public Receipt(int id, int cog, int gear)
        {
            CustomerID = id;
            CogQuantity = cog;
            GearQuantity = gear;
            SaleDate = DateTime.Now;
            SalesTaxPercent = 0.089;
            CogPrice = 79.99;
            GearPrice = 250.00;
        }

        public double CalculateTotal()
        {
            double netAmount = CalculateNetAmount();
            double taxAmount = CalculateTaxAmount();

            return netAmount + taxAmount;
        }

        public void PrintReceipt()
        {
            string receipt = $"\t{string.Empty.PadLeft(40, '#')}\n" +
                             $"\t{string.Empty.PadLeft(5, ' ')} Customer: {CustomerID}\n" +
                             $"\t{string.Empty.PadLeft(40, '-')}\n" +
                             $"\t{"# of Cogs:".PadRight(20, ' ')}{CogQuantity.ToString("N0")}\n" +
                             $"\t{"# of Gears:".PadRight(20, ' ')}{GearQuantity.ToString("N0")}\n" +
                             $"\t{"Subtotal:".PadRight(20, ' ')}{CalculateNetAmount().ToString("C")}\n" +
                             $"\t{"Sales Tax:".PadRight(20, ' ')}{CalculateTaxAmount().ToString("C")}\n" +
                             $"\t{"Total:".PadRight(20, ' ')}{CalculateTotal().ToString("C")}\n" +
                             $"\t{"".PadLeft(40, '#')}";

            Console.WriteLine(receipt);
        }

        private double CalculateTaxAmount()
        {
            return CalculateNetAmount() * SalesTaxPercent;
        }
        private double CalculateNetAmount()
        {
            double netAmt, cogPriceWithMarkup, gearPriceWithMarkeup;

            if (CogQuantity > 10 || GearQuantity > 10 || (CogQuantity + GearQuantity) > 16)
            {
                cogPriceWithMarkup = CogPrice + CogPrice * 0.125;
                gearPriceWithMarkeup = GearPrice + GearPrice * 0.125;
            }
            else
            {
                cogPriceWithMarkup = CogPrice + CogPrice * 0.15;
                gearPriceWithMarkeup = GearPrice + GearPrice * 0.15;
            }

            netAmt = CogQuantity * cogPriceWithMarkup + GearQuantity * gearPriceWithMarkeup;

            return netAmt;
        }
    }
}
