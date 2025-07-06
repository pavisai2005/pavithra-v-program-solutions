IF OBJECT_ID('dbo.OrderDetails', 'U') IS NOT NULL DROP TABLE dbo.OrderDetails;
IF OBJECT_ID('dbo.Orders', 'U') IS NOT NULL DROP TABLE dbo.Orders;
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL DROP TABLE dbo.Products;
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL DROP TABLE dbo.Customers;
GO

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(100),
    Region VARCHAR(50)
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
GO

INSERT INTO Customers (CustomerID, Name, Region) VALUES
(1, 'Alice', 'North'),
(2, 'Bob', 'South'),
(3, 'Charlie', 'East'),
(4, 'David', 'West');

INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1200.00),
(2, 'Smartphone', 'Electronics', 800.00),
(3, 'Tablet', 'Electronics', 600.00),
(4, 'Headphones', 'Accessories', 150.00);

INSERT INTO Orders (OrderID, CustomerID, OrderDate) VALUES
(1, 1, '2023-01-15'),
(2, 2, '2023-02-20'),
(3, 3, '2023-03-25'),
(4, 4, '2023-04-30');

INSERT INTO OrderDetails (OrderDetailID, OrderID, ProductID, Quantity) VALUES
(1, 1, 1, 1),
(2, 2, 2, 2),
(3, 3, 3, 1),
(4, 4, 4, 3);
GO

--------------------------------------------------------
-- Exercise 1: Non-Clustered Index on ProductName
-- Query before index
SELECT * FROM Products WHERE ProductName = 'Laptop';

-- Create Non-Clustered Index
CREATE NONCLUSTERED INDEX idx_ProductName
ON Products (ProductName);
GO

-- Query after index
SELECT * FROM Products WHERE ProductName = 'Laptop';


-- Exercise 2: Non-Clustered Index on OrderDate (Corrected)


-- Query before index
SELECT * FROM Orders WHERE OrderDate = '2023-01-15';

-- Create Non-Clustered Index (Fixed - No clustered index conflict)
CREATE NONCLUSTERED INDEX idx_OrderDate
ON Orders (OrderDate);
GO

-- Query after index
SELECT * FROM Orders WHERE OrderDate = '2023-01-15';


-- Exercise 3: Composite Non-Clustered Index on CustomerID and OrderDate


-- Query before index
SELECT * FROM Orders WHERE CustomerID = 1 AND OrderDate = '2023-01-15';

-- Create Composite Non-Clustered Index
CREATE NONCLUSTERED INDEX idx_CustomerID_OrderDate
ON Orders (CustomerID, OrderDate);
GO

-- Query after index
SELECT * FROM Orders WHERE CustomerID = 1 AND OrderDate = '2023-01-15';