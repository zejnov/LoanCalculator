using System;
using LoanCalculator.Const;
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
            CalculateData(inputData);
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
        
        private ResultWrapper CalculateData(InputData inputData)
        {
            var q = 1 + inputData.AnnualInterestRate / (LoanConst.NUMBER_OF_CAMPITALIZATION_PERIODS * 100);

            double sum = 0;
            
            for (var i = 1; i <= inputData.LoanTerm; i++)
            {
                sum += Math.Pow(1 + inputData.AnnualInterestRateValue / LoanConst.NUMBER_OF_CAMPITALIZATION_PERIODS, i);
            }

            var singleInstallment = inputData.LoanAmount / (decimal)sum;

            //var installment = inputData.LoanAmount / 
            
            var calculatedResult = new ResultWrapper()
            {
                InputData = inputData,
                LoanInstallmentAmount = singleInstallment
            };

            CalclulateParts(calculatedResult);

            return calculatedResult;
        }

        private void CalclulateParts(ResultWrapper calculatedResult)
        {
            throw new NotImplementedException();
        }

        private void PrintResults()
        {
            throw new System.NotImplementedException();
        }

        
    }
}