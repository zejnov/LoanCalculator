using System;
using System.Collections.Generic;
using System.Linq;
using LoanCalculator.Const;
using LoanCalculator.Model;

namespace LoanCalculator.Service
{
    public class LoanCalculatorService
    {
        public ResultWrapper CalculateData(InputData inputData)
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
            var p = resultWrapper.InputData.AnnualInterestRate / (LoanConst.NUMBER_OF_CAMPITALIZATION_PERIODS * 100);
            var toPower = resultWrapper.InputData.LoanTerm;
            
            var interest = resultWrapper.InputData.LoanAmount * (decimal) p * (decimal) Math.Pow(1 + p, toPower) / ((decimal) Math.Pow(1 + p, toPower) - 1) ;
            var interestTotal = interest * resultWrapper.InputData.LoanTerm - resultWrapper.InputData.LoanAmount;
            
            resultWrapper.LoanPlan = new List<ResultRow>();

            for (var i = 1; i <= resultWrapper.InputData.LoanTerm; i++)
            {
                var capitalPart = interest / ((decimal) Math.Pow(1 + p, i));
                var interestPart = interest - capitalPart;
                
                resultWrapper.LoanPlan.Add(new ResultRow()
                {
                    MonthNumber = i,
                    LoanPayment = new LoanData()
                    {
                        CapitalPart = capitalPart,
                        InterestPart = interestPart
                    },
                    LoanOutstanding = new LoanData()
                    {
                        CapitalPart = (resultWrapper.LoanPlan.LastOrDefault()?.LoanOutstanding.CapitalPart ?? resultWrapper.InputData.LoanAmount) - capitalPart,
                        InterestPart = (resultWrapper.LoanPlan.LastOrDefault()?.LoanOutstanding.InterestPart ?? interestTotal) - interestPart
                    }
                });
            }
        }
    }
}