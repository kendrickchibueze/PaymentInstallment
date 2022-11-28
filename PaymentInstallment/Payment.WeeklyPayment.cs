using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentInstallment
{
    internal partial class Payment
    {

        public static void WeeklyPayment()
        {

            FixedProductPricesForDifferentPlan _productprice;

            _productprice = FixedProductPricesForDifferentPlan.WeeklyPlanProductprice;

            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Choose different products for weekly pay as their prices is fixed at " + FormatAmount((decimal)_productprice) + "\n");
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "But you will pay 15% of the price for the weekly pay\n");


            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter how many weeks you wish to complete your payment\n");

            _planInput = int.Parse(Console.ReadLine());
            try
            {
                if (_planInput < _finalLimit)

                    throw new PaymentException("Your payment days must not be less than 3 weeks");

                else if (_planInput > _finalLimit)

                    throw new PaymentException("Your payment weeks must not be greater than 3 weeks");

                else
                {

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
                        ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the weekly pay:");

                        try
                        {
                            pay[i].models.WeeklyPay = Convert.ToDouble(Console.ReadLine());
                            if (pay[i].models.WeeklyPay > (double)_productprice)

                                throw new PaymentException("You can't pay more than the fixed product price for this installment plan");

                        }
                        catch (PaymentException e)
                        {
                            Console.WriteLine(e.Message);
                            WeeklyPayment();

                        }
                        


                        pay[i].models.NewWeeklyPay = (double)_productprice - pay[i].models.WeeklyPay * .15;
                        ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "The new weekly pay is  " + pay[i].models.NewWeeklyPay);
                        _planInput -= 1;
                        ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "\nThe weeks remaining is " + _planInput--);


                    }
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "\nMr Buhari's Record for Weekly Pay");
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "ID\tName\tDateStart\t\tInitialPay\tNextPay\tEndDate");
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

                    for (int i = 0; i < _planInput; i++)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t\t\t{4}\t{5}", i + 1, pay[i].models.Product, pay[i].models.date, pay[i].models.WeeklyPay, pay[i].models.NewWeeklyPay, pay[i].models.date.AddDays(_planInput*7));

                    }
                    Console.ReadLine();


                }
            }
            catch (PaymentException e)
            {
                Console.WriteLine(e.Message);
                WeeklyPayment();

            }catch(OverflowException e)
            {
                Console.WriteLine(e.Message);
                WeeklyPayment();
            }






        }
    }
}
