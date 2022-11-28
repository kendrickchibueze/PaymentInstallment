using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentInstallment
{
    internal partial  class Payment
    {
        public static void MonthlyPayment()
        {
            FixedProductPricesForDifferentPlan _productprice;

            _productprice = FixedProductPricesForDifferentPlan.MonthlyPlanProductprice;

            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Choose different products for  Monthly pay as their prices is fixed at " + FormatAmount((decimal)_productprice) + "\n");
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

                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "You have chosen " + pay[i].models.Product + " and the price is " + FormatAmount((decimal)_productprice));

                pay[i].models.date = DateTime.Today;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Today being " + pay[i].models.date + " you started your payment");
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the Monthly pay:");
                pay[i].models.MonthlyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].models.NewMonthlyPay = (double)_productprice - pay[i].models.MonthlyPay * .35;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "The new daily pay is  " + pay[i].models.NewMonthlyPay);
                _planInput -= 1;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "\nThe days remaining is " + _planInput--);


            }
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "\nMr Buhari's Record for Monthly Pay");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

            for (int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].models.Product, pay[i].models.date, pay[i].models.MonthlyPay, pay[i].models.NewMonthlyPay, _productprice);

            }
            Console.ReadLine();

        }

    }
}
