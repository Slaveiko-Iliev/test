CREATE DATABASE Accounting;

GO

USE Accounting;

GO

-- Task 01. DDL

CREATE TABLE [Countries] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] VARCHAR(10)
)

CREATE TABLE [Addresses] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[StreetName] NVARCHAR(20) NOT NULL
            ,[StreetNumber] INT NOT NULL
            ,[PostCode] INT NOT NULL
            ,[City] VARCHAR(25) NOT NULL
            ,[CountryId] INT FOREIGN KEY REFERENCES [Countries](Id) NOT NULL
)

CREATE TABLE [Vendors] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] NVARCHAR(25) NOT NULL
            ,[NumberVAT] NVARCHAR(15) NOT NULL
            ,[AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id) NOT NULL
)

CREATE TABLE [Clients] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] NVARCHAR(25) NOT NULL
            ,[NumberVAT] NVARCHAR(25) NOT NULL
            ,[AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id) NOT NULL
)

CREATE TABLE [Categories] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE [Products] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] NVARCHAR(35) NOT NULL
            ,[Price] DECIMAL(18,2) NOT NULL
            ,[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL
            ,[VendorId] INT FOREIGN KEY REFERENCES [Vendors](Id) NOT NULL
)

CREATE TABLE [Invoices] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Number] INT UNIQUE NOT NULL
            ,[IssueDate] DATETIME2 NOT NULL
            ,[DueDate] DATETIME2 NOT NULL
            ,[Amount] DECIMAL(18,2) NOT NULL
            ,[Currency] VARCHAR(5) not NULL
            ,[ClientId] INT FOREIGN KEY REFERENCES [Clients](Id)
)

CREATE TABLE [ProductsClients] (
             [ProductId] INT FOREIGN KEY REFERENCES [Products](Id) NOT NULL
             ,[ClientId] INT FOREIGN KEY REFERENCES [Clients](Id) NOT NULL
             ,PRIMARY KEY ([ProductId], [ClientId])
)


-- Task 02. Insert

INSERT INTO [Products]
     VALUES ('SCANIA Oil Filter XD01', 78.69, 1, 1)
           ,('MAN Air Filter XD01', 97.38, 1, 5)
           ,('DAF Light Bulb 05FG87', 55.00, 2, 13)
           ,('ADR Shoes 47-47.5', 49.85, 3, 5)
           ,('Anti-slip pads S', 5.87, 5, 7);

INSERT INTO [Invoices]
     VALUES ('1219992181', '', '', 180.96, 'BGN', 3)
           ,('1729252340', '', '', 158.18, 'EUR', 13)
           ,('1950101013', '', '', 615.15, 'USD', 19)