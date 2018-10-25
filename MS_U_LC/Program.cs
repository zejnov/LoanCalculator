using System;
using System.Collections.Generic;
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
            var result = CalculateData(inputData);
            PrintResults(result);
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

            CalculateParts(calculatedResult);

            return calculatedResult;
        }

        private void CalculateParts(ResultWrapper calculatedResult)
        {
            calculatedResult.LoanPlan = new List<ResultRow>()
            {
                new ResultRow()
                {
                    MonthNumber = 1,
                    LoanPayment = new LoanData()
                    {
                        CapitalPart = 123,
                        InterestPart = 23
                    },
                    LoanOutstanding = new LoanData()
                    {
                        CapitalPart = 20000,
                        InterestPart = 12456
                    }
                }
            };
        }

        private void PrintResults(ResultWrapper result)
        {
            //todo Write input params
            Writer.WriteResultTable(result);
            //todo Write some footer
        }
    }
}