namespace LoanCalculator.Model
{
    public class ResultRow
    {
        public int MonthNumber { get; set; }
        public LoanData LoanPayment { get; set; }
        public LoanData LoanOutstanding { get; set; }
    }
}