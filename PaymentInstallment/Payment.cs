using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PaymentInstallment
{
    internal class Payment
    {
        //fields
        private static int _planInput;
        private static int _productprice;
        private static CultureInfo _enculture = new CultureInfo("en-US");

        
        
        
        
        //instance of our model class
        Models models = new Models();




        public  static void DailyPayment()
        {
            _productprice = 5000;
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Choose different products for daily pay as their prices is fixed at " + FormatAmount(_productprice) + "\n");
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "But you will pay 5% of the price for the daily pay\n");


            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter how many days you wish to complete your payment, atleast from 3 days and above \n");

            _planInput = int.Parse(Console.ReadLine());

            Payment[] pay = new Payment[_planInput];

            for(int i = 0; i < _planInput; i++)
            {
                pay[i] = new Payment();

                Console.WriteLine("Product plan ID : {0} ", i+1);

                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Product Name : ");

                pay[i].models.Product = Console.ReadLine();

                Console.WriteLine("You have chosen " + pay[i].models.Product + " and the price is " + FormatAmount(_productprice));

                pay[i].models.date = DateTime.Today;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Today being " + pay[i].models.date + " you started your payment");
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the daily pay:");
                pay[i].models.DailyPay = Convert.ToDouble(Console.ReadLine());
                

               pay[i].models.NewDailyPay = _productprice - pay[i].models.DailyPay * .05;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "The new daily pay is  " + pay[i].models.NewDailyPay);
                _planInput -= 1;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "\nThe days remaining is " + _planInput--);
                

            }
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan,"\nMr Buhari's Record for Daily Pay");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

            for(int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i +1, pay[i].models.Product, pay[i].models.date, pay[i].models.DailyPay, pay[i].models.NewDailyPay,_productprice);

            }
            Console.ReadLine();

        }

        public static void WeeklyPayment()
        {

            _productprice = 10000;
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow,"Choose different products for weekly pay as their prices is fixed at " + FormatAmount(_productprice) + "\n");
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow,"But you will pay 15% of the price for the weekly pay\n");


            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter how many weeks you wish to complete your payment\n");

            _planInput = int.Parse(Console.ReadLine());

            Payment[] pay = new Payment[_planInput];

            for (int i = 0; i < _planInput; i++)
            {
                pay[i] = new Payment();

                Console.WriteLine("Product plan ID : {0} ", i + 1);

                ColorValidation.PrintColorMessage(ConsoleColor.Yellow,"Product Name : ");

                pay[i].models.Product = Console.ReadLine();

                ColorValidation.PrintColorMessage(ConsoleColor.Yellow,"You have chosen " + pay[i].models.Product + " and the price is " + FormatAmount(_productprice));

                pay[i].models.date = DateTime.Today;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow,"Today being " + pay[i].models.date + " you started your payment");
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow,"Enter the Amount you are willing to start paying for the weekly pay:");
                pay[i].models.WeeklyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].models.NewWeeklyPay = _productprice - pay[i].models.WeeklyPay * .15;
                Console.WriteLine("The new daily pay is  " + pay[i].models.NewWeeklyPay);
                _planInput -= 1;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow,"\nThe days remaining is " + _planInput--);


            }
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan,"\nMr Buhari's Record for Weekly Pay");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan,"-----------------------------------------------------------------------------------------");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan,"ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

            for (int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].models.Product, pay[i].models.date, pay[i].models.WeeklyPay, pay[i].models.NewWeeklyPay, _productprice);

            }
            Console.ReadLine();

        }

        public static void BiWeeklyPayment()
        {

            _productprice = 20000;
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Choose different products for  Biweekly pay as their prices is fixed at " + FormatAmount(_productprice) + "\n");
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "But you will pay 25% of the price for the Bi weekly pay\n");


            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter how many Bi weeks you wish to complete your payment\n");

            _planInput = int.Parse(Console.ReadLine());

            Payment[] pay = new Payment[_planInput];

            for (int i = 0; i < _planInput; i++)
            {
                pay[i] = new Payment();

                Console.WriteLine("Product plan ID : {0} ", i + 1);

                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Product Name : ");

                pay[i].models.Product = Console.ReadLine();

                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "You have chosen " + pay[i].models.Product + " and the price is " + FormatAmount(_productprice));

                pay[i].models.date = DateTime.Today;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Today being " + pay[i].models.date + " you started your payment");
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the Bi weekly pay:");
                pay[i].models.BiWeeklyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].models.NewBiWeeklyPay = _productprice - pay[i].models.BiWeeklyPay * .25;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "The new daily pay is  " + pay[i].models.NewBiWeeklyPay);
                _planInput -= 1;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow,"\nThe days remaining is " + _planInput--);


            }
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan,"\nMr Buhari's Record for Bi Weekly Pay");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan,"-----------------------------------------------------------------------------------------");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan,"ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

            for (int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].models.Product, pay[i].models.date, pay[i].models.BiWeeklyPay, pay[i].models.NewBiWeeklyPay, _productprice);

            }
            Console.ReadLine();
        }

        public static void MonthlyPayment()
        {
            _productprice = 40000;
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Choose different products for  Monthly pay as their prices is fixed at " + FormatAmount(_productprice) + "\n");
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "But you will pay 35% of the price for the daily pay\n");


            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter how many months you wish to complete your payment\n");

            _planInput = int.Parse(Console.ReadLine());

            Payment[] pay = new Payment[_planInput];

            for (int i = 0; i < _planInput; i++)
            {
                pay[i] = new Payment();

                Console.WriteLine("Product plan ID : {0} ", i + 1);

                Console.WriteLine("Product Name : ");

                pay[i].models.Product = Console.ReadLine();

                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "You have chosen " + pay[i].models.Product + " and the price is " + FormatAmount(_productprice));

                pay[i].models.date = DateTime.Today;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Today being " + pay[i].models.date + " you started your payment");
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the Monthly pay:");
                pay[i].models.MonthlyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].models.NewMonthlyPay = _productprice - pay[i].models.MonthlyPay * .35;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "The new daily pay is  " + pay[i].models.NewMonthlyPay);
                _planInput -= 1;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "\nThe days remaining is " + _planInput--);


            }
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "\nMr Buhari's Record for Monthly Pay");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan,"ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

            for (int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].models.Product, pay[i].models.date, pay[i].models.MonthlyPay, pay[i].models.NewMonthlyPay, _productprice);

            }
            Console.ReadLine();

        }

        public static void QuarterlyPayment()
        {
            _productprice = 40000;
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Choose different products for  Quarterly pay as their prices is fixed at " + FormatAmount(_productprice) + "\n");
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "But you will pay 50% of the price for the Quarterly pay\n");


            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter how many months you wish to complete your payment\n");

            _planInput = int.Parse(Console.ReadLine());

            Payment[] pay = new Payment[_planInput];

            for (int i = 0; i < _planInput; i++)
            {
                pay[i] = new Payment();

                Console.WriteLine("Product plan ID : {0} ", i + 1);

                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Product Name : ");

                pay[i].models.Product = Console.ReadLine();

                Console.WriteLine("You have chosen " + pay[i].models.Product + " and the price is " + FormatAmount(_productprice));

                pay[i].models.date = DateTime.Today;
                Console.WriteLine("Today being " + pay[i].models.date + " you started your payment");
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the Quarterly pay:");
                pay[i].models.QuarterlyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].models.NewQuarterlyPay = _productprice - pay[i].models.QuarterlyPay * .50;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "The new daily pay is  " + pay[i].models.NewQuarterlyPay);
                _planInput -= 1;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "\nThe days remaining is " + _planInput--);


            }
            Console.WriteLine("\nMr Buhari's Record for Quarterly Pay");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            for (int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].models.Product, pay[i].models.date, pay[i].models.QuarterlyPay, pay[i].models.NewQuarterlyPay, _productprice);

            }
            Console.ReadLine();

        }
        public static void YearlyPayment()
        {

            _productprice = 60000;
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Choose different products for  Quarterly pay as their prices is fixed at " + FormatAmount(_productprice) + "\n");
             ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "But you will pay 80% of the price for the Yearly pay\n");


            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter how many years you wish to complete your payment\n");

            _planInput = int.Parse(Console.ReadLine());

            Payment[] pay = new Payment[_planInput];

            for (int i = 0; i < _planInput; i++)
            {
                pay[i] = new Payment();

                Console.WriteLine("Product plan ID : {0} ", i + 1);

                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Product Name : ");

                pay[i].models.Product = Console.ReadLine();

                Console.WriteLine("You have chosen " + pay[i].models.Product + " and the price is " + FormatAmount(_productprice));

                pay[i].models.date = DateTime.Today;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow,"Today being " + pay[i].models.date + " you started your payment");
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow,"Enter the Amount you are willing to start paying for the yearly pay:");
                pay[i].models.YearlyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].models.NewYearlyPay = _productprice - pay[i].models.YearlyPay * .80;
                Console.WriteLine("The new daily pay is  " + pay[i].models.NewYearlyPay);
                _planInput -= 1;
                Console.WriteLine("\nThe days remaining is " + _planInput--);


            }
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan,"\nMr Buhari's Record for Yearly Pay");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan,"-----------------------------------------------------------------------------------------");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

            for (int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].models.Product, pay[i].models.date, pay[i].models.QuarterlyPay, pay[i].models.NewYearlyPay, _productprice);

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
