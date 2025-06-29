IF OBJECT_ID('dbo.sp_GetEmployeesByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_GetEmployeesByDepartment;
GO

IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL
    DROP TABLE dbo.Employees;
GO

CREATE TABLE dbo.Employees
(
    EmployeeID INT PRIMARY KEY,
    EmployeeName NVARCHAR(100),
    DepartmentID INT,
    MonthlySalary DECIMAL(18, 2)
);
GO


INSERT INTO dbo.Employees (EmployeeID, EmployeeName, DepartmentID, MonthlySalary)
VALUES 
(1, 'pavi', 10, 160000),
(2, 'swe', 2, 78000),
(3, 'nav', 10, 150000),
(4, 'lak', 1, 165000),
(5, 'ven', 20, 355000);
GO


CREATE PROCEDURE dbo.sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        EmployeeID,
        EmployeeName,
        DepartmentID,
        MonthlySalary
    FROM 
        dbo.Employees
    WHERE 
        DepartmentID = @DepartmentID;
END;
GO


EXEC dbo.sp_GetEmployeesByDepartment @DepartmentID = 10;
GO