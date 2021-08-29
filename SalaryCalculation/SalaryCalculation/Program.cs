using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculaterLib;

namespace SalaryCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            int basicPercent = Convert.ToInt32(ConfigurationManager.AppSettings["BasicPercent"]);
            int hraPercent = Convert.ToInt32(ConfigurationManager.AppSettings["HraPercent"]);
            int convAmount = Convert.ToInt32(ConfigurationManager.AppSettings["ConvAmount"]);
            int mediAmount = Convert.ToInt32(ConfigurationManager.AppSettings["MediAmount"]);
            int pfPercent = Convert.ToInt32(ConfigurationManager.AppSettings["PfPercent"]);
            int pfLimit = Convert.ToInt32(ConfigurationManager.AppSettings["PfLimit"]);
            int pfAmount = Convert.ToInt32(ConfigurationManager.AppSettings["PfAmount"]);
            int esicLimit = Convert.ToInt32(ConfigurationManager.AppSettings["EsicLimit"]);
            decimal esicPercent = Convert.ToDecimal(ConfigurationManager.AppSettings["EsicPercent"]);

            Console.WriteLine("Enter annual ctc");
            int annualCtc = Convert.ToInt32(Console.ReadLine());

            CtcCalculator ctcCalculator = new CtcCalculator(annualCtc, basicPercent, hraPercent, convAmount, mediAmount, pfPercent, pfLimit, pfAmount, esicLimit, esicPercent);
            ctcCalculator.CalculateCtcBreakup();
            Console.WriteLine(ctcCalculator);


            Console.ReadLine();
        }
    }
}
