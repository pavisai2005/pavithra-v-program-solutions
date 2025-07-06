CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10,2),
    JoinDate DATE
);
GO

DROP PROCEDURE IF EXISTS sp_InsertEmployee;
GO

CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;
GO

DROP PROCEDURE IF EXISTS sp_GetEmployeesByDepartment;
GO


CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        EmployeeID,
        FirstName,
        LastName,
        DepartmentID,
        Salary,
        JoinDate
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

EXEC sp_InsertEmployee 
    @FirstName = 'PAVI',
    @LastName = 'VENKI',
    @DepartmentID = 1,
    @Salary = 150000,
    @JoinDate = '2025-05-03';
GO

EXEC sp_InsertEmployee 
    @FirstName = 'SWE',
    @LastName = 'JACK',
    @DepartmentID = 2,
    @Salary = 160000,
    @JoinDate = '2023-06-15';
GO

EXEC sp_InsertEmployee 
    @FirstName = 'NAV',
    @LastName = 'John',
    @DepartmentID = 1,
    @Salary = 55000,
    @JoinDate = '2025-01-18';
GO

EXEC sp_InsertEmployee 
    @FirstName = 'lak',
    @LastName = 'sar',
    @DepartmentID = 2,
    @Salary = 62000,
    @JoinDate = '2024-11-20';
GO

EXEC sp_GetEmployeesByDepartment @DepartmentID = 1;
GO


EXEC sp_GetEmployeesByDepartment @DepartmentID = 2;
GO