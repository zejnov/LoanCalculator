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

        private static void Wait()
        {
            Console.ReadKey(false);
        }
    }
}