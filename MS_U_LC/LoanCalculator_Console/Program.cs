using LoanCalculator.Model;
using LoanCalculator.Service;
using LoanCalculator_Console.Helpers;

namespace LoanCalculator_Console
{
    class Program
    {
        static void Main() => new Program().Run();

        private void Run()
        {
            var service = new LoanCalculatorService();
            var inputData = CollectData();
            
            var result = service.CalculateData(inputData);
            PrintResults(result);
        }

        private InputData CollectData()
        {
            //TODO add try catch, validation of range
            return new InputData
            {
                LoanAmount = Reader.ReadInput<decimal>("Loan amount"),
                AnnualInterestRate = Reader.ReadInput<int>("Annual interest rate"),
                LoanTerm = Reader.ReadInput<int>("Loan term (months)")
            };
        }

        private void PrintResults(ResultWrapper result)
        {
            Writer.WriteInput(result.InputData);
            Writer.WriteLoanInfo(result);
            Writer.WriteResultTable(result);
            Writer.WriteTrueFooter();
        }
    }
}