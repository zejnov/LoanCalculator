using System;
using System.Linq;
using LoanCalculator.Model;

namespace LoanCalculator.Helpers
{
    public class Writer
    {
        public static void WriteInput(InputData inputData) =>
            Console.WriteLine(
                $"Amount of the loan: {inputData.LoanAmount}, Annual interest rate: {inputData.AnnualInterestRate}, Loan period: {inputData.LoanTerm} months.");

        public static void WriteLoanInfo(ResultWrapper result) =>
            Console.WriteLine($"You will pay {result.LoanPlan.Select(lp => lp.LoanPayment).Sum(p => p.Sum):0.00} total.");

        public static void WriteResultTable(ResultWrapper result)
        {
            PrintHeader();

            foreach (var entry in result.LoanPlan)
            {
                Console.WriteLine($" {entry.MonthNumber:00}  {entry.LoanPayment.Sum:0.00}({entry.LoanPayment.CapitalPart:0.00}/{entry.LoanPayment.InterestPart:0.00})  " +
                                  $"{entry.LoanOutstanding.Sum:0.00}({entry.LoanOutstanding.CapitalPart:0.00}/{entry.LoanOutstanding.InterestPart:0.00})");
            }
            
            PrintFooter();
            Wait();
        }

        private static void PrintFooter() => Console.WriteLine("\n* TOTAL_AMOUNT(CAPITAL_PART/INTEREST_PART)");
        private static void PrintHeader() => Console.WriteLine($"\n No. Interest rate         Left to pay");
        private static void Wait() => Console.ReadKey(false);
    }
}