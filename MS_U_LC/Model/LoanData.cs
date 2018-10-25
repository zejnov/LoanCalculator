namespace LoanCalculator.Model
{
    public class LoanData
    {
        public decimal CapitalPart { get; set; }
        public decimal InterestPart { get; set; }
        public decimal Sum => CapitalPart + InterestPart;
    }
}