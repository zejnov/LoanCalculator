namespace LoanCalculator.Model
{
    public class InputData
    {
        public decimal LoanAmount { get; set; }
        public double AnnualInterestRate { get; set; }
        public int LoanTerm { get; set; }

        public double AnnualInterestRateValue => AnnualInterestRate / 100;
    }
}