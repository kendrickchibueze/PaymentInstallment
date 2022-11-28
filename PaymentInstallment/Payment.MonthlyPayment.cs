using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentInstallment
{
    internal partial class Payment
    {
        public static void MonthlyPayment()
        {
            FixedProductPricesForDifferentPlan _productprice;

            _productprice = FixedProductPricesForDifferentPlan.MonthlyPlanProductprice;

            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Choose different products for  Monthly pay as their prices is fixed at " + FormatAmount((decimal)_productprice) + "\n");

            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "But you will pay 35% of the price for the daily pay\n");


            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter how many months you wish to complete your payment. This must not be less or greater than 3 months\n");

            _planInput = int.Parse(Console.ReadLine());
            try
            {
                if (_planInput < _finalLimit)

                    throw new PaymentException( "Your payment months must not be less than 3 months");


                else if (_planInput > _finalLimit)
                {
                    throw new PaymentException("Your payment months must not be greater than 3 months");


                }


                else
                {
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
                        try
                        {
                            pay[i].models.MonthlyPay = Convert.ToDouble(Console.ReadLine());

                            if (pay[i].models.MonthlyPay > (double)_productprice)

                                throw new PaymentException( "You can't pay more than the fixed product price for this installment plan");
                            else if (pay[i].models.MonthlyPay <= 0)
                                throw new PaymentException("You can't pay 0 or a value less than it in this installment plan");


                        }
                        catch(PaymentException e)
                        {
                            Console.WriteLine(e.Message);

                            MonthlyPayment();
                        }




                        pay[i].models.NewMonthlyPay = (double)_productprice - pay[i].models.MonthlyPay * .35;

                        ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "The new monthly pay is  " + pay[i].models.NewMonthlyPay);

                        _planInput -= 1;

                        ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "\nThe months remaining is " + _planInput--);


                    }
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "\nMr Buhari's Record for Monthly Pay");
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "ID\tName\tDateStart\tInitialPay\tNextPay\tEndDate");
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

                    for (int i = 0; i < _planInput; i++)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].models.Product, pay[i].models.date, pay[i].models.MonthlyPay, pay[i].models.NewMonthlyPay, pay[i].models.date.AddMonths(_planInput));

                    }
                    Console.ReadLine();

                }


            }
            catch (PaymentException e)
            {
                Console.WriteLine(e.Message);

                MonthlyPayment();


            }
            catch(OverflowException e)
            {
                Console.WriteLine(e.Message);

                MonthlyPayment();
            }



        }
    }
}
