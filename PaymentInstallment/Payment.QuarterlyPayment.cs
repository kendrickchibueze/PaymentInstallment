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


            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter how many Quarters you wish to complete your payment. This must not be less or greater than 3 quarters\n");

            _planInput = int.Parse(Console.ReadLine());

            try
            {
                if (_planInput < _finalLimit)

                    throw new PaymentException("Your payment quarters must not be less than 3 quarter years");

                else if (_planInput > _finalLimit)

                    throw new PaymentException("Your payment days  must not be greater than 3 quarter years");
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

                        ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "Today being " + pay[i].models.date + " you started your payment");

                        ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the Quarterly pay:");

                        try
                        {
                            pay[i].models.QuarterlyPay = Convert.ToDouble(Console.ReadLine());

                            if (pay[i].models.QuarterlyPay > (double)_productprice)

                                throw new PaymentException("Your initial payment cannot be greater than the fixed product price for quarterly pay");

                            else if (pay[i].models.QuarterlyPay <= 0)

                                throw new PaymentException("You can't pay 0 or a value less than it in this installment plan");

                        }
                        catch (PaymentException e)
                        {
                            Console.WriteLine(e.Message);

                            QuarterlyPayment();

                        }



                        pay[i].models.NewQuarterlyPay = (double)_productprice - pay[i].models.QuarterlyPay * .50;
                        ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "The new quarterly pay is  " + pay[i].models.NewQuarterlyPay);
                        _planInput -= 1;
                        ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "\nThe quarters remaining is " + _planInput--);


                    }
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "\nMr Buhari's Record for Qurterly Pay");
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "ID\tName\tDateStart\t\tInitialPay\tNextPay\tEndDate");
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");


                    for (int i = 0; i < _planInput; i++)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t\t{4}\t{5}", i + 1, pay[i].models.Product, pay[i].models.date, pay[i].models.QuarterlyPay, pay[i].models.NewQuarterlyPay, pay[i].models.date.AddMonths(6));

                    }
                    Console.ReadLine();

                }


            }
            catch (PaymentException e)
            {
                Console.WriteLine(e.Message);

                QuarterlyPayment();

            }catch(OverflowException e)
            {
                Console.WriteLine(e.Message);

                QuarterlyPayment();
            }







        }
    }
}
