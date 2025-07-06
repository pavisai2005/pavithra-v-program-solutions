using System;
using System.Collections.Generic;
using System.Linq;

public class FinancialForecasting
{
    // Represents a forecasted period's data
    public class ForecastPeriod
    {
        public string PeriodName { get; set; }
        public decimal ProjectedRevenue { get; set; }
        public decimal GrowthRate { get; set; } // Storing for clarity, might not be used directly in output

        public ForecastPeriod(string periodName, decimal projectedRevenue, decimal growthRate)
        {
            PeriodName = periodName;
            ProjectedRevenue = projectedRevenue;
            GrowthRate = growthRate;
        }

        public void Display()
        {
            Console.WriteLine($"Period: {PeriodName,-15} | Projected Revenue: {ProjectedRevenue:C} | Growth Rate: {GrowthRate:P}");
        }
    }

    /// <summary>
    /// Projects future revenue based on a starting revenue and a constant growth rate over a number of periods.
    /// </summary>
    /// <param name="startingRevenue">The revenue for the initial period.</param>
    /// <param name="annualGrowthRate">The annual growth rate (e.g., 0.05 for 5%).</param>
    /// <param name="numberOfPeriods">The number of periods to forecast.</param>
    /// <param name="periodType">Type of period (e.g., "Year", "Quarter", "Month").</param>
    /// <returns>A list of ForecastPeriod objects containing the projected revenue for each period.</returns>
    public static List<ForecastPeriod> ProjectRevenue(
        decimal startingRevenue,
        decimal annualGrowthRate,
        int numberOfPeriods,
        string periodType = "Year")
    {
        if (startingRevenue < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(startingRevenue), "Starting revenue cannot be negative.");
        }
        if (annualGrowthRate < -1) // Cannot shrink by more than 100%
        {
            throw new ArgumentOutOfRangeException(nameof(annualGrowthRate), "Growth rate cannot be less than -100%.");
        }
        if (numberOfPeriods <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfPeriods), "Number of periods must be positive.");
        }

        List<ForecastPeriod> forecasts = new List<ForecastPeriod>();
        decimal currentRevenue = startingRevenue;

        // Add the initial period (Year 0 / Current Year)
        forecasts.Add(new ForecastPeriod($"{periodType} 0 (Current)", startingRevenue, 0m));

        for (int i = 1; i <= numberOfPeriods; i++)
        {
            currentRevenue *= (1 + annualGrowthRate);
            string periodName = $"{periodType} {i}";
            forecasts.Add(new ForecastPeriod(periodName, currentRevenue, annualGrowthRate));
        }

        return forecasts;
    }

    // --- Example with more complex scenario: Forecasting with varying growth rates and expenses ---

    public class FinancialModel
    {
        public decimal InitialRevenue { get; set; }
        public decimal InitialExpenses { get; set; }
        public decimal RevenueGrowthRate { get; set; } // Per period
        public decimal ExpenseGrowthRate { get; set; } // Per period
        public int NumberOfPeriods { get; set; }
        public string PeriodLabel { get; set; }

        public FinancialModel(decimal initialRevenue, decimal initialExpenses,
                              decimal revenueGrowthRate, decimal expenseGrowthRate,
                              int numberOfPeriods, string periodLabel = "Year")
        {
            InitialRevenue = initialRevenue;
            InitialExpenses = initialExpenses;
            RevenueGrowthRate = revenueGrowthRate;
            ExpenseGrowthRate = expenseGrowthRate;
            NumberOfPeriods = numberOfPeriods;
            PeriodLabel = periodLabel;
        }

        public void RunForecast()
        {
            Console.WriteLine($"\n--- Financial Forecast ({PeriodLabel}s) ---");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"{"Period",-10} | {"Revenue",-15} | {"Expenses",-15} | {"Net Income",-15}");
            Console.WriteLine("------------------------------------------");

            decimal currentRevenue = InitialRevenue;
            decimal currentExpenses = InitialExpenses;

            // Display initial values (Period 0)
            Console.WriteLine($"{"Current",-10} | {currentRevenue,-15:C} | {currentExpenses,-15:C} | {currentRevenue - currentExpenses,-15:C}");

            for (int i = 1; i <= NumberOfPeriods; i++)
            {
                currentRevenue *= (1 + RevenueGrowthRate);
                currentExpenses *= (1 + ExpenseGrowthRate);
                decimal netIncome = currentRevenue - currentExpenses;

                Console.WriteLine($"{PeriodLabel} {i,-5} | {currentRevenue,-15:C} | {currentExpenses,-15:C} | {netIncome,-15:C}");
            }
            Console.WriteLine("------------------------------------------");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Exercise 7: Financial Forecasting ---");

        // Scenario 1: Simple Revenue Forecast
        Console.WriteLine("\nScenario 1: Simple Annual Revenue Forecast");
        List<FinancialForecasting.ForecastPeriod> annualRevenueForecast =
            FinancialForecasting.ProjectRevenue(
                startingRevenue: 1_000_000m,   // $1,000,000
                annualGrowthRate: 0.08m,      // 8% annual growth
                numberOfPeriods: 5,           // Forecast for 5 years
                periodType: "Year");

        foreach (var period in annualRevenueForecast)
        {
            period.Display();
        }

        // Scenario 2: Monthly Expense Forecast (Negative Growth/Reduction)
        Console.WriteLine("\nScenario 2: Monthly Expense Forecast (with reduction)");
        List<FinancialForecasting.ForecastPeriod> monthlyExpenseForecast =
            FinancialForecasting.ProjectRevenue(
                startingRevenue: 50_000m,    // $50,000 initial monthly expenses
                annualGrowthRate: -0.02m,    // -2% monthly reduction
                numberOfPeriods: 12,         // Forecast for 12 months
                periodType: "Month");

        foreach (var period in monthlyExpenseForecast)
        {
            // Note: For expenses, "Projected Revenue" actually means "Projected Expense" in this generic model
            Console.WriteLine($"Period: {period.PeriodName,-15} | Projected Expense: {period.ProjectedRevenue:C} | Growth Rate: {period.GrowthRate:P}");
        }


        // Scenario 3: Integrated Revenue and Expense Forecast
        Console.WriteLine("\nScenario 3: Integrated Revenue and Expense Forecast");
        FinancialForecasting.FinancialModel companyForecast = new FinancialForecasting.FinancialModel(
            initialRevenue: 500_000m,
            initialExpenses: 300_000m,
            revenueGrowthRate: 0.07m,   // 7% revenue growth per quarter
            expenseGrowthRate: 0.03m,   // 3% expense growth per quarter
            numberOfPeriods: 8,         // Forecast for 8 quarters (2 years)
            periodLabel: "Quarter"
        );
        companyForecast.RunForecast();

        // Example of handling invalid input
        try
        {
            Console.WriteLine("\n--- Invalid Input Test ---");
            FinancialForecasting.ProjectRevenue(-100m, 0.05m, 3);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}