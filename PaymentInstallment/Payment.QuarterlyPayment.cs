using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentInstallment
{
    internal partial class Payment
    {
        public static void QuarterlyPayment()
        {
            FixedProductPricesForDifferentPlan _productprice;

            _productprice = FixedProductPricesForDifferentPlan.QuarterlyPlanProductprice;

            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Choose different products for  Quarterly pay as their prices is fixed at " + FormatAmount((decimal)_productprice) + "\n");
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

                Console.WriteLine("You have chosen " + pay[i].models.Product + " and the price is " + FormatAmount((decimal)_productprice));

                pay[i].models.date = DateTime.Today;
                Console.WriteLine("Today being " + pay[i].models.date + " you started your payment");
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the Quarterly pay:");
                pay[i].models.QuarterlyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].models.NewQuarterlyPay = (double)_productprice - pay[i].models.QuarterlyPay * .50;
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
    }
}
