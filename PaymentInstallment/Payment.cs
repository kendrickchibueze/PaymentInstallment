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
        private static int _Input;
        private static string _product;

        private static CultureInfo _enculture = new CultureInfo("en-US");





        //properties

        public string Product { get; set; }
        public DateTime date { get; set; }

        //public double ProductPrice{ get; set; }
        public double DailyPay{ get; set; }
        public double  WeeklyPay{ get; set; }
        public double BiWeeklyPay { get; set; }

        public double MonthlyPay { get; set; }

        public double QuarterlyPay { get; set; }

        public double YearlyPay { get; set; }
        public double NewDailyPay { get; set; }
        public double NewWeeklyPay { get; set; }
        public double NewBiWeeklyPay { get; set; }
        public double NewMonthlyPay { get; set; }
        public double NewQuarterlyPay { get; set; }
        public double NewYearlyPay { get; set; }






        public static void Run()
            {
            PrintColorMessage(ConsoleColor.Yellow, "***Welcome to Mr Buhari's Installment App***");
                planPayments();






            }

        public static void planPayments()
        {
            PrintColorMessage(ConsoleColor.Cyan, "Please choose your payment plan: 1[Daily plan], 2[weekly], 3[BiWeekly],4[Monthly],5[Quarterly], 6[Yearly]");
            _Input = int.Parse(Console.ReadLine());
            
            switch (_Input)
            {
                case 1:
                    PrintColorMessage(ConsoleColor.Yellow, "You have choosen the Daily plan");
                    DailyPayment();

                    break;
                case 2:
                    PrintColorMessage(ConsoleColor.Yellow, "You have chosen the weekly plan");
                    WeeklyPayment();
                    break;
                case 3:
                    PrintColorMessage(ConsoleColor.Yellow, "You have chosen the Biweekly plan");
                    BiWeeklyPayment();
                    break;
                case 4:
                    PrintColorMessage(ConsoleColor.Yellow, "You have chosen the Monthly plan");
                    MonthlyPayment();
                    break;
                case 5:
                    PrintColorMessage(ConsoleColor.Yellow, "You have chosen the Quarterly plan");
                    QuarterlyPayment();
                    break;
                case 6:
                    PrintColorMessage(ConsoleColor.Yellow, "You have chosen the Yearly Plan");
                    YearlyPayment();
                    break;
                default:
                    PrintColorMessage(ConsoleColor.Yellow, "You better start with the daily plan");
                    break;

            }
        }




        public  static void DailyPayment()
        {
            _productprice = 5000;
            PrintColorMessage(ConsoleColor.Yellow, "Choose different products for daily pay as their prices is fixed at " + FormatAmount(_productprice) + "\n");
            PrintColorMessage(ConsoleColor.Yellow, "But you will pay 5% of the price for the daily pay\n");


            PrintColorMessage(ConsoleColor.Yellow, "Enter how many days you wish to complete your payment, atleast from 3 days and above \n");

            _planInput = int.Parse(Console.ReadLine());

            Payment[] pay = new Payment[_planInput];

            for(int i = 0; i < _planInput; i++)
            {
                pay[i] = new Payment();

                Console.WriteLine("Product plan ID : {0} ", i+1);

                PrintColorMessage(ConsoleColor.Yellow, "Product Name : ");

                pay[i].Product = Console.ReadLine();

                Console.WriteLine("You have chosen " + pay[i].Product + " and the price is " + FormatAmount(_productprice));

                pay[i].date = DateTime.Today;
                PrintColorMessage(ConsoleColor.Yellow, "Today being " + pay[i].date + " you started your payment");
                PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the daily pay:");
                pay[i].DailyPay = Convert.ToDouble(Console.ReadLine());
                

               pay[i].NewDailyPay = _productprice - pay[i].DailyPay * .05;
                PrintColorMessage(ConsoleColor.Yellow, "The new daily pay is  " + pay[i].NewDailyPay);
                _planInput -= 1;
                PrintColorMessage(ConsoleColor.Yellow, "\nThe days remaining is " + _planInput--);
                

            }
            PrintColorMessage(ConsoleColor.Cyan,"\nMr Buhari's Record for Daily Pay");
            PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");
            PrintColorMessage(ConsoleColor.Cyan, "ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

            for(int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i +1, pay[i].Product, pay[i].date, pay[i].DailyPay, pay[i].NewDailyPay,_productprice);

            }
            Console.ReadLine();

        }

        public static void WeeklyPayment()
        {

            _productprice = 10000;
            PrintColorMessage(ConsoleColor.Yellow,"Choose different products for weekly pay as their prices is fixed at " + FormatAmount(_productprice) + "\n");
            PrintColorMessage(ConsoleColor.Yellow,"But you will pay 15% of the price for the weekly pay\n");


            PrintColorMessage(ConsoleColor.Yellow, "Enter how many weeks you wish to complete your payment\n");

            _planInput = int.Parse(Console.ReadLine());

            Payment[] pay = new Payment[_planInput];

            for (int i = 0; i < _planInput; i++)
            {
                pay[i] = new Payment();

                Console.WriteLine("Product plan ID : {0} ", i + 1);

                PrintColorMessage(ConsoleColor.Yellow,"Product Name : ");

                pay[i].Product = Console.ReadLine();

                PrintColorMessage(ConsoleColor.Yellow,"You have chosen " + pay[i].Product + " and the price is " + FormatAmount(_productprice));

                pay[i].date = DateTime.Today;
                PrintColorMessage(ConsoleColor.Yellow,"Today being " + pay[i].date + " you started your payment");
                PrintColorMessage(ConsoleColor.Yellow,"Enter the Amount you are willing to start paying for the weekly pay:");
                pay[i].WeeklyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].NewWeeklyPay = _productprice - pay[i].WeeklyPay * .15;
                Console.WriteLine("The new daily pay is  " + pay[i].NewWeeklyPay);
                _planInput -= 1;
                PrintColorMessage(ConsoleColor.Yellow,"\nThe days remaining is " + _planInput--);


            }
            PrintColorMessage(ConsoleColor.Cyan,"\nMr Buhari's Record for Weekly Pay");
            PrintColorMessage(ConsoleColor.Cyan,"-----------------------------------------------------------------------------------------");
            PrintColorMessage(ConsoleColor.Cyan,"ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

            for (int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].Product, pay[i].date, pay[i].WeeklyPay, pay[i].NewWeeklyPay, _productprice);

            }
            Console.ReadLine();

        }

        public static void BiWeeklyPayment()
        {

            _productprice = 20000;
            PrintColorMessage(ConsoleColor.Yellow, "Choose different products for  Biweekly pay as their prices is fixed at " + FormatAmount(_productprice) + "\n");
            PrintColorMessage(ConsoleColor.Yellow, "But you will pay 25% of the price for the Bi weekly pay\n");


            PrintColorMessage(ConsoleColor.Yellow, "Enter how many Bi weeks you wish to complete your payment\n");

            _planInput = int.Parse(Console.ReadLine());

            Payment[] pay = new Payment[_planInput];

            for (int i = 0; i < _planInput; i++)
            {
                pay[i] = new Payment();

                Console.WriteLine("Product plan ID : {0} ", i + 1);

                PrintColorMessage(ConsoleColor.Yellow, "Product Name : ");

                pay[i].Product = Console.ReadLine();

                PrintColorMessage(ConsoleColor.Yellow, "You have chosen " + pay[i].Product + " and the price is " + FormatAmount(_productprice));

                pay[i].date = DateTime.Today;
                PrintColorMessage(ConsoleColor.Yellow, "Today being " + pay[i].date + " you started your payment");
                PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the Bi weekly pay:");
                pay[i].BiWeeklyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].NewBiWeeklyPay = _productprice - pay[i].BiWeeklyPay * .25;
                PrintColorMessage(ConsoleColor.Yellow, "The new daily pay is  " + pay[i].NewBiWeeklyPay);
                _planInput -= 1;
                PrintColorMessage(ConsoleColor.Yellow,"\nThe days remaining is " + _planInput--);


            }
            PrintColorMessage(ConsoleColor.Cyan,"\nMr Buhari's Record for Bi Weekly Pay");
            PrintColorMessage(ConsoleColor.Cyan,"-----------------------------------------------------------------------------------------");
            PrintColorMessage(ConsoleColor.Cyan,"ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

            for (int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].Product, pay[i].date, pay[i].BiWeeklyPay, pay[i].NewBiWeeklyPay, _productprice);

            }
            Console.ReadLine();
        }

        public static void MonthlyPayment()
        {
            _productprice = 40000;
            PrintColorMessage(ConsoleColor.Yellow, "Choose different products for  Monthly pay as their prices is fixed at " + FormatAmount(_productprice) + "\n");
            PrintColorMessage(ConsoleColor.Yellow, "But you will pay 35% of the price for the daily pay\n");


            PrintColorMessage(ConsoleColor.Yellow, "Enter how many months you wish to complete your payment\n");

            _planInput = int.Parse(Console.ReadLine());

            Payment[] pay = new Payment[_planInput];

            for (int i = 0; i < _planInput; i++)
            {
                pay[i] = new Payment();

                Console.WriteLine("Product plan ID : {0} ", i + 1);

                Console.WriteLine("Product Name : ");

                pay[i].Product = Console.ReadLine();

                PrintColorMessage(ConsoleColor.Yellow, "You have chosen " + pay[i].Product + " and the price is " + FormatAmount(_productprice));

                pay[i].date = DateTime.Today;
                PrintColorMessage(ConsoleColor.Yellow, "Today being " + pay[i].date + " you started your payment");
                PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the Monthly pay:");
                pay[i].MonthlyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].NewMonthlyPay = _productprice - pay[i].MonthlyPay * .35;
                PrintColorMessage(ConsoleColor.Yellow, "The new daily pay is  " + pay[i].NewMonthlyPay);
                _planInput -= 1;
                PrintColorMessage(ConsoleColor.Yellow, "\nThe days remaining is " + _planInput--);


            }
            PrintColorMessage(ConsoleColor.Cyan, "\nMr Buhari's Record for Monthly Pay");
            PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");
            PrintColorMessage(ConsoleColor.Cyan,"ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

            for (int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].Product, pay[i].date, pay[i].MonthlyPay, pay[i].NewMonthlyPay, _productprice);

            }
            Console.ReadLine();

        }

        public static void QuarterlyPayment()
        {
            _productprice = 40000;
            PrintColorMessage(ConsoleColor.Yellow, "Choose different products for  Quarterly pay as their prices is fixed at " + FormatAmount(_productprice) + "\n");
            PrintColorMessage(ConsoleColor.Yellow, "But you will pay 50% of the price for the Quarterly pay\n");


            PrintColorMessage(ConsoleColor.Yellow, "Enter how many months you wish to complete your payment\n");

            _planInput = int.Parse(Console.ReadLine());

            Payment[] pay = new Payment[_planInput];

            for (int i = 0; i < _planInput; i++)
            {
                pay[i] = new Payment();

                Console.WriteLine("Product plan ID : {0} ", i + 1);

                PrintColorMessage(ConsoleColor.Yellow, "Product Name : ");

                pay[i].Product = Console.ReadLine();

                Console.WriteLine("You have chosen " + pay[i].Product + " and the price is " + FormatAmount(_productprice));

                pay[i].date = DateTime.Today;
                Console.WriteLine("Today being " + pay[i].date + " you started your payment");
                PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the Quarterly pay:");
                pay[i].QuarterlyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].NewQuarterlyPay = _productprice - pay[i].QuarterlyPay * .50;
                PrintColorMessage(ConsoleColor.Yellow, "The new daily pay is  " + pay[i].NewQuarterlyPay);
                _planInput -= 1;
                PrintColorMessage(ConsoleColor.Yellow, "\nThe days remaining is " + _planInput--);


            }
            Console.WriteLine("\nMr Buhari's Record for Quarterly Pay");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            Console.WriteLine("-----------------------------------------------------------------------------------------");

            for (int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].Product, pay[i].date, pay[i].QuarterlyPay, pay[i].NewQuarterlyPay, _productprice);

            }
            Console.ReadLine();

        }
        public static void YearlyPayment()
        {

            _productprice = 60000;
            PrintColorMessage(ConsoleColor.Yellow, "Choose different products for  Quarterly pay as their prices is fixed at " + FormatAmount(_productprice) + "\n");
            PrintColorMessage(ConsoleColor.Yellow, "But you will pay 80% of the price for the Yearly pay\n");


            PrintColorMessage(ConsoleColor.Yellow, "Enter how many years you wish to complete your payment\n");

            _planInput = int.Parse(Console.ReadLine());

            Payment[] pay = new Payment[_planInput];

            for (int i = 0; i < _planInput; i++)
            {
                pay[i] = new Payment();

                Console.WriteLine("Product plan ID : {0} ", i + 1);

                PrintColorMessage(ConsoleColor.Yellow, "Product Name : ");

                pay[i].Product = Console.ReadLine();

                Console.WriteLine("You have chosen " + pay[i].Product + " and the price is " + FormatAmount(_productprice));

                pay[i].date = DateTime.Today;
                PrintColorMessage(ConsoleColor.Yellow,"Today being " + pay[i].date + " you started your payment");
                PrintColorMessage(ConsoleColor.Yellow,"Enter the Amount you are willing to start paying for the yearly pay:");
                pay[i].YearlyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].NewYearlyPay = _productprice - pay[i].YearlyPay * .80;
                Console.WriteLine("The new daily pay is  " + pay[i].NewYearlyPay);
                _planInput -= 1;
                Console.WriteLine("\nThe days remaining is " + _planInput--);


            }
            PrintColorMessage(ConsoleColor.Cyan,"\nMr Buhari's Record for Yearly Pay");
            PrintColorMessage(ConsoleColor.Cyan,"-----------------------------------------------------------------------------------------");
            PrintColorMessage(ConsoleColor.Cyan, "ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

            for (int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].Product, pay[i].date, pay[i].QuarterlyPay, pay[i].NewYearlyPay, _productprice);

            }
            Console.ReadLine();

        }




        public static string FormatAmount(decimal amt)
        {
            return String.Format(_enculture, "{0:C2}", amt);
        }




        // print color message
        public static void PrintColorMessage(ConsoleColor color, string message)
        {

            Console.ForegroundColor = color;

            //tell user its not a number
            Console.WriteLine(message);

            //reset text color
            Console.ResetColor();
        }
    }







  
}
