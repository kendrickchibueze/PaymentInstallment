using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentInstallment
{
    public static class SelectionPlan
    {
        //field
        private static int _Input;
        public static void planPayments()
        {
            ColorValidation.PrintColorMessage(ConsoleColor.Cyan, "Please choose your payment plan: 1[Daily plan], 2[weekly], 3[BiWeekly],4[Monthly],5[Quarterly], 6[Yearly]");
            _Input = int.Parse(Console.ReadLine());

            switch (_Input)
            {
                case 1:
                    ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "You have choosen the Daily plan");
                    Payment.DailyPayment();

                    break;
                case 2:
                    ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "You have chosen the weekly plan");
                    Payment.WeeklyPayment();
                    break;
                case 3:
                    ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "You have chosen the Biweekly plan");
                    Payment.BiWeeklyPayment();
                    break;
                case 4:
                    ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "You have chosen the Monthly plan");
                    Payment.MonthlyPayment();
                    break;
                case 5:
                    ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "You have chosen the Quarterly plan");
                    Payment.QuarterlyPayment();
                    break;
                case 6:
                    ColorValidation.PrintColorMessage(ConsoleColor.Yellow, "You have chosen the Yearly Plan");
                    Payment.YearlyPayment();
                    break;
                default:
                    ColorValidation.PrintColorMessage(ConsoleColor.Red, "plan invalid, You better start with the daily plan");
                    break;

            }
        }
    }
}
