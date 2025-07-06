IF OBJECT_ID('dbo.fn_CalculateAnnualSalary', 'FN') IS NOT NULL
    DROP FUNCTION dbo.fn_CalculateAnnualSalary;
GO

IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL
    DROP TABLE dbo.Employees;
GO

-- Create the Employees table
CREATE TABLE dbo.Employees
(
    EmployeeID INT PRIMARY KEY,
    EmployeeName NVARCHAR(100),
    MonthlySalary DECIMAL(18, 2)
);
GO


INSERT INTO dbo.Employees (EmployeeID, EmployeeName, MonthlySalary)
VALUES 
(1, 'pavi', 160000),
(2, 'swe', 77000),
(3, 'nav', 150000);
GO

CREATE FUNCTION dbo.fn_CalculateAnnualSalary
(
    @EmployeeID INT
)
RETURNS DECIMAL(18, 5)
AS
BEGIN
    DECLARE @AnnualSalary DECIMAL(18, 5);

    SELECT @AnnualSalary = MonthlySalary * 12
    FROM dbo.Employees
    WHERE EmployeeID = @EmployeeID;

   
    RETURN ISNULL(@AnnualSalary, 0);
END;
GO

SELECT dbo.fn_CalculateAnnualSalary(1) AS AnnualSalary;
GO