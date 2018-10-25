using System;
using LoanCalculator.Model;

namespace LoanCalculator.Helpers
{
    public class Writer
    {
        public static void  WriteInput(InputData inputData)
        {
            Console.WriteLine($"Amount of the loan: {inputData.LoanAmount}, Annual interest rate: {inputData.AnnualInterestRate}, Loan period: {inputData.LoanTerm} months.");
            Wait();
        }

        public static void WriteResultTable(ResultWrapper result)
        {
            //PrintHeader();

            foreach (var entry in result.LoanPlan)
            {
                Console.WriteLine($" {entry.MonthNumber}  {result.LoanInstallmentAmount:0.##}({entry.LoanPayment.CapitalPart}/{entry.LoanPayment.InterestPart})  " +
                                  $"{entry.LoanOutstanding.Sum}({entry.LoanOutstanding.CapitalPart}/{entry.LoanOutstanding.InterestPart})");
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