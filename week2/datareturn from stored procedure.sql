IF OBJECT_ID('dbo.sp_GetEmployeeCountByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_GetEmployeeCountByDepartment;
GO

IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL
    DROP TABLE dbo.Employees;
GO

CREATE TABLE dbo.Employees
(
    EmployeeID INT PRIMARY KEY,
    EmployeeName NVARCHAR(100),
    DepartmentID INT,
    MonthlySalary DECIMAL(18, 5)
);
GO


INSERT INTO dbo.Employees (EmployeeID, EmployeeName, DepartmentID, MonthlySalary)
VALUES 
(1, 'pavi', 10, 160000),
(2, 'swe', 11, 78000),
(3, 'nav', 1, 150000),
(4, 'lak', 37, 165000),
(5, 'ven', 20, 55000),
(6, 'bro', 11, 162000);
GO


CREATE PROCEDURE dbo.sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        COUNT(*) AS TotalEmployees
    FROM 
        dbo.Employees
    WHERE 
        DepartmentID = @DepartmentID;
END;
GO


EXEC dbo.sp_GetEmployeeCountByDepartment @DepartmentID = 11;
GO