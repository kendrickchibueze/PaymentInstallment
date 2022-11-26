using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentInstallment
{
    public class Models
    {
     

       

        //properties

        public string Product { get; set; }
        public DateTime date { get; set; }

        //public double ProductPrice{ get; set; }
        public double DailyPay { get; set; }
        public double WeeklyPay { get; set; }
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
    }
}
