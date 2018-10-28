using System.Windows;
using LoanCalculator.Model;

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
        }
    }
}
