using System;
using LoanCalculator.Model;

namespace LoanCalculator.Helpers
{
    public class Writer
    {
        public static void  WriteInput(InputData inputData)
        {
            Console.WriteLine($"Amount of the loan: {inputData.LoanAmount}, Annual interest rate: {inputData.AnnualInterestRate}, Loan period: {inputData.LoanTerm} months.");
            //Wait();
        }

        public static void WriteResultTable(ResultWrapper result)
        {
            //PrintHeader();

            foreach (var entry in result.LoanPlan)
            {
                Console.WriteLine($" {entry.MonthNumber}  {entry.LoanPayment.Sum:0.##}({entry.LoanPayment.CapitalPart:0.##}/{entry.LoanPayment.InterestPart:0.##})  " +
                                  $"{entry.LoanOutstanding.Sum:0.##}({entry.LoanOutstanding.CapitalPart:0.##}/{entry.LoanOutstanding.InterestPart:0.##})");
            }
            //PrintFooter
            Wait();
        }

        private static void Wait()
        {
            Console.ReadKey(false);
        }
    }
}