using System.Collections.Generic;

namespace LoanCalculator.Model
{
    public class ResultWrapper
    {
        public InputData InputData { get; set; }
        public decimal LoanInstallmentAmount { get; set; }
        public List<ResultRow> LoanPlan { get; set; }
    }
}