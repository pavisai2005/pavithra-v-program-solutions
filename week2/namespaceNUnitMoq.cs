namespace Assignment_05_NUnitMoq
{
    public interface ICalculatorService
    {
        int Multiply(int a, int b);
    }

    public class TaxCalculator
    {
        private readonly ICalculatorService _calculator;

        public TaxCalculator(ICalculatorService calculator)
        {
            _calculator = calculator;
        }

        public int CalculateTax(int amount)
        {
            return _calculator.Multiply(amount, 10); // 10% tax
        }
    }
}