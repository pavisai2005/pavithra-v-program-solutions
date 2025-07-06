CREATE TABLE Products (
    ProductID INT,
    ProductName NVARCHAR(100),
    Category NVARCHAR(100),
    Price DECIMAL(10,2)
);


INSERT INTO Products (ProductID, ProductName, Category, Price) VALUES
(1, 'Laptop', 'Electronics', 1000),
(2, 'TV', 'Electronics', 800),
(3, 'Smartphone', 'Electronics', 800),
(4, 'Sofa', 'Furniture', 700),
(5, 'Table', 'Furniture', 500),
(6, 'Chair', 'Furniture', 500),
(7, 'Lamp', 'Furniture', 300);


WITH RankedProducts AS (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER (PARTITION BY Category ORDER BY Price DESC) AS RowNum,
        RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS RankNum,
        DENSE_RANK() OVER (PARTITION BY Category ORDER BY Price DESC) AS DenseRankNum
    FROM Products
)
SELECT *
FROM RankedProducts
WHERE RowNum <= 3
   OR RankNum <= 3
   OR DenseRankNum <= 3
ORDER BY Category, Price DESC;