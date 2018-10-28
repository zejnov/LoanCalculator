using System.Windows;
using LoanCalculator.Model;
using LoanCalculator.Service;

namespace LoanCalculator_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var inputData = new InputData()
            {
                LoanAmount = decimal.Parse(AmountTxt.Text),
                AnnualInterestRate = double.Parse(PercentageTxt.Text),
                LoanTerm = int.Parse(TermTxt.Text)
            };

            var calculator = new LoanCalculatorService();
            var result = calculator.CalculateData(inputData);

            tableResult.Visibility = Visibility.Visible;

            tableResult.va
        }
    }
}
