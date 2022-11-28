using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentInstallment
{
    internal  partial class Payment
    {
        //fields
        private static int _planInput;
        private static int _productprice;
        private static CultureInfo _enculture = new CultureInfo("en-US");



        //instance of our model class
        Models models = new Models();


        public static void DailyPayment()
        {
            FixedProductPricesForDifferentPlan _productprice;

            _productprice = FixedProductPricesForDifferentPlan.DailyPlanProductprice;

            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Choose different products for daily pay as their prices is fixed at " + FormatAmount((decimal)_productprice) + "\n");
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "But you will pay 5% of the price for the daily pay\n");


            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter how many days you wish to complete your payment, atleast from 3 days and above \n");

            _planInput = int.Parse(Console.ReadLine());

            Payment[] pay = new Payment[_planInput];

            for (int i = 0; i < _planInput; i++)
            {
                pay[i] = new Payment();

                Console.WriteLine("Product plan ID : {0} ", i + 1);

                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Product Name : ");

                pay[i].models.Product = Console.ReadLine();

                Console.WriteLine("You have chosen " + pay[i].models.Product + " and the price is " + FormatAmount((decimal)_productprice));

                pay[i].models.date = DateTime.Today;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Today being " + pay[i].models.date + " you started your payment");
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the daily pay:");
                pay[i].models.DailyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].models.NewDailyPay = (double)_productprice - pay[i].models.DailyPay * .05;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "The new daily pay is  " + pay[i].models.NewDailyPay);
                _planInput -= 1;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "\nThe days remaining is " + _planInput--);


            }
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "\nMr Buhari's Record for Daily Pay");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "ID\tName\tDateStart\t\tNextPay\tproductprice\tEndDate");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

            for (int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].models.Product, pay[i].models.date, pay[i].models.DailyPay, pay[i].models.NewDailyPay, _productprice);

            }
            Console.ReadLine();

        }

     


        public static string FormatAmount(decimal amt)
        {
            return String.Format(_enculture, "{0:C2}", amt);
        }



        public static void Run()
        {
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "***Welcome to Mr Buhari's Installment App***");
            SelectionPlan.planPayments();


        }
    }
}
