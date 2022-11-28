using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentInstallment
{
    internal partial class Payment
    {

        public static void YearlyPayment()
        {

            FixedProductPricesForDifferentPlan _productprice;

            _productprice = FixedProductPricesForDifferentPlan.YearlyPlanProductprice;

            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Choose different products for  Quarterly pay as their prices is fixed at " + FormatAmount((decimal)_productprice) + "\n");
            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "But you will pay 80% of the price for the Yearly pay\n");


            ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter how many years you wish to complete your payment\n");

            _planInput = int.Parse(Console.ReadLine());

            try
            {
                if (_planInput < _finalLimit)

                    throw new PaymentException("Your payment days must not be less than 3 years");

                else if (_planInput > _finalLimit)

                    throw new PaymentException("Your payment weeks must not be greater than 3 years");
                else
                {
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

                        ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "Enter the Amount you are willing to start paying for the yearly pay:");

                        try
                        {
                            pay[i].models.YearlyPay = Convert.ToDouble(Console.ReadLine());

                            if (pay[i].models.YearlyPay > (double)_productprice)

                                throw new PaymentException("You can't pay more than the fixed product price for this installment plan");

                            else if (pay[i].models.YearlyPay <= 0)

                                throw new PaymentException("You can't pay 0 or a value less than it in this installment plan");

                        }
                        catch (PaymentException e)
                        {
                            Console.WriteLine(e.Message);

                            YearlyPayment();

                        }
                       


                        pay[i].models.NewYearlyPay = (double)_productprice - pay[i].models.YearlyPay * .80;

                        Console.WriteLine("The new daily pay is  " + pay[i].models.NewYearlyPay);

                        _planInput -= 1;

                        Console.WriteLine("\nThe years remaining is " + _planInput--);


                    }
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "\nMr Buhari's Record for Yearly Pay");
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "ID\tName\tDate\tPlandays\tNextPay\tproductprice");
                    ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "-----------------------------------------------------------------------------------------");

                    for (int i = 0; i < _planInput; i++)
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", i + 1, pay[i].models.Product, pay[i].models.date, pay[i].models.QuarterlyPay, pay[i].models.NewYearlyPay, pay[i].models.date.AddYears(_planInput));

                    }
                    Console.ReadLine();

                }



            }
            catch (PaymentException e)
            {
                Console.WriteLine(e.Message);
                YearlyPayment();

            }catch(OverflowException e)
            {
                Console.WriteLine(e.Message);
                YearlyPayment();
            }






        }     

    }
}
