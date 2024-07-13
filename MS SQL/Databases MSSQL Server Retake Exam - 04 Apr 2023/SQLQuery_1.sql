CREATE DATABASE Accounting;

GO

USE Accounting;

GO

-- Task 01. DDL

-- CREATE TABLE [Countries] (
--              [Id] INT PRIMARY KEY IDENTITY
--             ,[Name] VARCHAR(10)
-- )

-- CREATE TABLE [Addresses] (
--              [Id] INT PRIMARY KEY IDENTITY
--             ,[StreetName] NVARCHAR(20) NOT NULL
--             ,[StreetNumber] INT NOT NULL
--             ,[PostCode] INT NOT NULL
--             ,[City] VARCHAR(25) NOT NULL
--             ,[CountryId] INT FOREIGN KEY REFERENCES [Countries](Id) NOT NULL
-- )

-- CREATE TABLE [Vendors] (
--              [Id] INT PRIMARY KEY IDENTITY
--             ,[Name] NVARCHAR(25) NOT NULL
--             ,[NumberVAT] NVARCHAR(15) NOT NULL
--             ,[AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id) NOT NULL
-- )

-- CREATE TABLE [Clients] (
--              [Id] INT PRIMARY KEY IDENTITY
--             ,[Name] NVARCHAR(25) NOT NULL
--             ,[NumberVAT] NVARCHAR(25) NOT NULL
--             ,[AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id) NOT NULL
-- )

-- CREATE TABLE [Categories] (
--              [Id] INT PRIMARY KEY IDENTITY
--             ,[Name] VARCHAR(10) NOT NULL
-- )

-- CREATE TABLE [Products] (
--              [Id] INT PRIMARY KEY IDENTITY
--             ,[Name] NVARCHAR(35) NOT NULL
--             ,[Price] DECIMAL(18,2) NOT NULL
--             ,[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL
--             ,[VendorId] INT FOREIGN KEY REFERENCES [Vendors](Id) NOT NULL
-- )

-- CREATE TABLE [Invoices] (
--              [Id] INT PRIMARY KEY IDENTITY
--             ,[Number] INT UNIQUE NOT NULL
--             ,[IssueDate] DATETIME2 NOT NULL
--             ,[DueDate] DATETIME2 NOT NULL
--             ,[Amount] DECIMAL(18,2) NOT NULL
--             ,[Currency] VARCHAR(5) not NULL
--             ,[ClientId] INT FOREIGN KEY REFERENCES [Clients](Id)
-- )

-- CREATE TABLE [ProductsClients] (
--              [ProductId] INT FOREIGN KEY REFERENCES [Products](Id) NOT NULL
--              ,[ClientId] INT FOREIGN KEY REFERENCES [Clients](Id) NOT NULL
--              ,PRIMARY KEY ([ProductId], [ClientId])
-- )


-- Task 02. Insert

INSERT INTO [Products]
     VALUES ('SCANIA Oil Filter XD01', 78.69, 1, 1)
           ,('MAN Air Filter XD01', 97.38, 1, 5)
           ,('DAF Light Bulb 05FG87', 55.00, 2, 13)
           ,('ADR Shoes 47-47.5', 49.85, 3, 5)
           ,('Anti-slip pads S', 5.87, 5, 7);

INSERT INTO [Invoices]
     VALUES ('1219992181', '2023-03-01', '2023-04-30', 180.96, 'BGN', 3)
           ,('1729252340', '2022-11-06', '2023-01-04', 158.18, 'EUR', 13)
           ,('1950101013', '2023-02-17', '2023-04-18', 615.15, 'USD', 19)


-- Task 03. Update

UPDATE [Invoices]
   SET [DueDate] = '2023-04-01'
 WHERE MONTH([IssueDate]) = 11 AND YEAR([IssueDate]) = 2022;

UPDATE [Clients]
   SET [AddressId] = 3
 WHERE [Name] LIKE '%CO%'


-- Task 04. Delete

DELETE 
  FROM [ProductsClients]
 WHERE [ClientId] IN (
              SELECT [Id]
                FROM [Clients]
               WHERE [NumberVAT] LIKE 'IT%'
 )

DELETE 
  FROM [Invoices]
 WHERE [ClientId] IN (
              SELECT [Id]
                FROM [Clients]
               WHERE [NumberVAT] LIKE 'IT%'
 )

 DELETE
   FROM [Clients]
  WHERE [NumberVAT] LIKE 'IT%'


-- Task 05. Invoices by Amount and Date

  SELECT [Number]
        ,[Currency]
    FROM [Invoices]
ORDER BY [Amount] DESC, [DueDate]


-- Task 06. Products by Category

  SELECT p.Id
        ,p.Name
        ,[Price]
        ,c.Name AS 'CategoryName'
    FROM [Products] AS p 
    JOIN [Categories] AS c ON p.CategoryId = c.Id
   WHERE c.Name IN ('ADR', 'Others')
ORDER BY [Price] DESC;


-- Task 07. Clients without Products

   SELECT c.Id
         ,c.Name AS [Client]
         ,CONCAT([StreetName], ' ', [StreetNumber], ', ', a.City, ', ', [PostCode], ', ', co.Name) AS Address
     FROM [Clients] AS c 
     JOIN [Addresses] AS a ON c.AddressId = a.Id
     JOIN [Countries] AS co ON a.CountryId = co.Id
LEFT JOIN [ProductsClients] AS pc ON c.Id = pc.ClientId
    WHERE [ProductId] IS NULL


-- Task 08. First 7 Invoices

  SELECT 
  TOP(7) [Number]
        ,[Amount]
        ,c.Name AS [Client]
    FROM [Invoices] AS i 
    JOIN [Clients] AS c ON i.ClientId = c.Id
   WHERE ([IssueDate] < '2023-01-01' AND [Currency] = 'EUR') OR ([Amount] > 500 AND [NumberVAT] LIKE 'DE%');


-- Task 09. Clients with VAT

  SELECT c.Name AS [Client]
        ,MAX([Price]) AS [Price]
        ,[NumberVAT] AS [VAT Number]
    FROM [Clients] AS c 
    JOIN [ProductsClients] AS pc ON c.Id = pc.ClientId
    JOIN [Products] AS p ON pc.ProductId = p.Id
   WHERE c.Name NOT LIKE '%KG'
GROUP BY c.Name, [NumberVAT]
ORDER BY MAX([Price]) DESC;


--   SELECT [Client]
--         ,[Price]
--         ,[VAT Number]
--     FROM (
--           SELECT c.Name AS [Client]
--                 ,[Price]
--                 ,DENSE_RANK() OVER (PARTITION by c.Name ORDER BY [Price] DESC) AS [RancedClients]
--                 ,[NumberVAT] AS [VAT Number]
--             FROM [Clients] AS c 
--             JOIN [ProductsClients] AS pc ON c.Id = pc.ClientId
--             JOIN [Products] AS p ON pc.ProductId = p.Id
--     ) AS RancClientsQuery
--    WHERE [RancedClients] = 1 AND [Client] NOT LIKE '%KG'
-- ORDER BY [Price] DESC, [Client] DESC;


-- Task 10. Clients by Price

  SELECT c.Name AS [Client]
        ,FLOOR(AVG([Price])) AS [Average Price]
    FROM [Clients] AS c 
    JOIN [ProductsClients] AS pc ON c.Id = pc.ClientId
    JOIN [Products] AS p ON p.Id = pc.ProductId
    JOIN [Vendors] AS v ON v.Id = p.VendorId
   WHERE v.NumberVAT LIKE '%FR%'
GROUP BY c.Name
ORDER BY FLOOR(AVG([Price])), c.Name DESC;

-- Task 11. Product with Clients

GO

  CREATE FUNCTION udf_ProductWithClients(@name NVARCHAR(35))
      RETURNS INT
               AS
            BEGIN
                  DECLARE @countOfProduct INT
                  SELECT @countOfProduct = COUNT([ProductId])
                  FROM [ProductsClients] AS pc
                  JOIN [Products]  as p ON p.Id = pc.ProductId
                  WHERE p.Name = @name
                  RETURN @countOfProduct
              END


-- Task 12. Search for Vendors from a Specific Country

GO

CREATE PROC usp_SearchByCountry(@country VARCHAR(10))
         AS
     SELECT v.Name AS [Vendor]
           ,[NumberVAT]
           ,CONCAT(a.StreetName, ' ', a.StreetNumber) AS [Street Info]
           ,CONCAT([City], ' ', [PostCode]) AS [City Info]
       FROM [Vendors] AS v 
       JOIN [Addresses] AS a ON v.AddressId = a.Id
       JOIN [Countries] AS c ON c.Id = a.CountryId
      WHERE c.Name = @country
   ORDER BY [Vendor], [City Info];

   EXEC usp_SearchByCountry 'France'