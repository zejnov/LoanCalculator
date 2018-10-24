using LoanCalculator.Helpers;
using LoanCalculator.Model;

namespace LoanCalculator
{
    class Program
    {
        static void Main() => new Program().Run();

        private void Run()
        {
            var inputData = CollectData();
            PrintInputData(inputData);
//            CalculateData();
//            PrintResults();
            
        }

        private void PrintInputData(InputData inputData)
        {
            //test purposes
            Writer.WriteInput(inputData);
        }

        private InputData CollectData()
        {
            return new InputData
            {
                LoanAmount = Reader.ReadInput<decimal>("Loan amount"),
                AnnualInterestRate = Reader.ReadInput<int>("Annual interest rate"),
                LoanTerm = Reader.ReadInput<int>("Loan term (months)")
            };
        }
        
        private void CalculateData()
        {
            throw new System.NotImplementedException();
        }

        private void PrintResults()
        {
            throw new System.NotImplementedException();
        }

        
    }
}