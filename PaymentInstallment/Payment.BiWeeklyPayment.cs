using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentInstallment
{
    internal partial  class Payment
    {

        public static void BiWeeklyPayment()
        {

            FixedProductPricesForDifferentPlan _productprice;

            _productprice = FixedProductPricesForDifferentPlan.BiweeklyPlanProductprice;

            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Choose different products for  Biweekly pay as their prices is fixed at " + FormatAmount((decimal)_productprice) + "\n");
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

                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "You have chosen " + pay[i].models.Product + " and the price is " + FormatAmount((decimal)_productprice));

                pay[i].models.date = DateTime.Today;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Today being " + pay[i].models.date + " you started your payment");
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the Bi weekly pay:");
                pay[i].models.BiWeeklyPay = Convert.ToDouble(Console.ReadLine());


                pay[i].models.NewBiWeeklyPay = (double)_productprice - pay[i].models.BiWeeklyPay * .25;

                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "The new daily pay is  " + pay[i].models.NewBiWeeklyPay);
                _planInput -= 1;
                ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "\nThe days remaining is " + _planInput--);


            }
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "\nMr Buhari's Record for Bi Weekly Pay");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "ID\tName\tDate\tPlandays\tNextPay\tproductprice");
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

            for (int i = 0; i < _planInput; i++)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].models.Product, pay[i].models.date, pay[i].models.BiWeeklyPay, pay[i].models.NewBiWeeklyPay, _productprice);

            }
            Console.ReadLine();
        }
    }
}
