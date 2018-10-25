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

            CalculateInstallments(calculatedResult, q);

            return calculatedResult;
        }

        private void CalculateInstallments(ResultWrapper resultWrapper, double q)
        {
            resultWrapper.LoanPlan = new List<ResultRow>();
            resultWrapper.CurrentLoanAmount = resultWrapper.InputData.LoanAmount; //todo dodać tu odsetki
            
            
            for (var i = 1; i <= resultWrapper.InputData.LoanTerm; i++)
            {
                var resultRow = new ResultRow()
                {
                    MonthNumber = i
                };
                
                var rataKapitalowa = resultWrapper.InputData.LoanAmount * (decimal) q / ((decimal) Math.Pow(1 + q, i) - 1);
                var rataProcentowa = resultWrapper.LoanInstallmentAmount - rataKapitalowa;

                resultRow.LoanPayment = new LoanData()
                {
                    CapitalPart = rataKapitalowa,
                    InterestPart = rataProcentowa
                };

                resultWrapper.CurrentLoanAmount -= resultRow.LoanPayment.Sum; //todo remove

                var capitalTotal = resultWrapper.InputData.LoanAmount;
                var interestTotal = resultWrapper.InputData.InterestAmount;

                var lastCapital = resultWrapper.LoanPlan.LastOrDefault()?.LoanOutstanding.CapitalPart;
                if (lastCapital == null)
                {
                    lastCapital = resultWrapper.InputData.LoanAmount;
                }
                
                var lastInterest = resultWrapper.LoanPlan.LastOrDefault()?.LoanOutstanding.InterestPart;
                if (lastInterest == null)
                {
                    lastInterest = resultWrapper.InputData.InterestAmount;
                }
                
                resultRow.LoanOutstanding = new LoanData()
                {
                    CapitalPart =  lastCapital.Value - rataKapitalowa,
                    InterestPart = lastCapital.Value - rataProcentowa
                        
                };
                
                //debugg
                var sth = resultRow.LoanOutstanding.Sum - (resultWrapper.InputData.LoanAmount + resultWrapper.InputData.InterestAmount);
                
                //////

                resultWrapper.LoanPlan.Add(resultRow);
            }
            
            
            //todo remove
            resultWrapper.LoanPlan = new List<ResultRow>()
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