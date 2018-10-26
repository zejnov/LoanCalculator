using System;
using System.Collections.Generic;
using System.Linq;
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
            //var inputData = CollectData();
            var inputData = new InputData()
            {
                LoanAmount = 3200,
                AnnualInterestRate = 8,
                LoanTerm = 13
            };
            
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
            var resultWrapper = new ResultWrapper()
            {
                InputData = inputData,
            };

            CalculateInstallments(resultWrapper);

            return resultWrapper;
        }

        private void CalculateInstallments(ResultWrapper resultWrapper)
        {
            resultWrapper.LoanPlan = new List<ResultRow>();
            
            var p = resultWrapper.InputData.AnnualInterestRate / (LoanConst.NUMBER_OF_CAMPITALIZATION_PERIODS * 100);
            
            var rataKapitalowa = (resultWrapper.InputData.LoanAmount * (decimal) p) / ((decimal) Math.Pow(1 + p, resultWrapper.InputData.LoanTerm) - 1);
            var rataStala = rataKapitalowa * (decimal) Math.Pow(1 + p, resultWrapper.InputData.LoanTerm);
            var rataProcentowa = rataStala - rataKapitalowa;

            var doSplatyTotal = rataStala * resultWrapper.InputData.LoanTerm;
            var odsetki = doSplatyTotal - resultWrapper.InputData.LoanAmount;
            var tefst = rataProcentowa * resultWrapper.InputData.LoanTerm;
            
            for (var i = 1; i <= resultWrapper.InputData.LoanTerm; i++)
            {
                var resultRow = new ResultRow()
                {
                    MonthNumber = i,
                    LoanPayment = new LoanData()
                    {
                        CapitalPart = rataKapitalowa,
                        InterestPart = rataProcentowa
                    }
                };
                
                var lastCapital = resultWrapper.LoanPlan.LastOrDefault()?.LoanOutstanding.CapitalPart ?? resultWrapper.InputData.LoanAmount;

                var lastInterest = resultWrapper.LoanPlan.LastOrDefault()?.LoanOutstanding.InterestPart ?? odsetki;

                resultRow.LoanOutstanding = new LoanData()
                {
                    CapitalPart =  lastCapital - rataKapitalowa,
                    InterestPart = lastInterest - rataProcentowa
                };


                var test = resultRow.LoanOutstanding.Sum - (lastCapital + lastInterest);
                
                //debugg
                var sth = resultRow.LoanOutstanding.Sum - (resultWrapper.InputData.LoanAmount + resultWrapper.InputData.InterestAmount);
                
                //////

                resultWrapper.LoanPlan.Add(resultRow);
            }
        }

        private void PrintResults(ResultWrapper result)
        {
            //todo Write input params
            Writer.WriteResultTable(result);
            //todo Write some footer
        }
    }
}