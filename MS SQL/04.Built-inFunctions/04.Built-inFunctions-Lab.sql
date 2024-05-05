SELECT [CustomerID] AS [ID]
       ,[FirstName]
       , [LastName]
       , STUFF([LastName], 1, 2, '*')
    AS [StuffName]
       , (SUBSTRING(PaymentNumber, 1, 6) + REPLICATE('*', LEN(PaymentNumber) - 6))
    AS [PaymentNumber]
  FROM Customers;

  -----

  SELECT CEILING (cast([Quantity] AS decimal) / [BoxCapacity] / PalletCapacity)
      AS [Number of pallets]
    FROM [Products];

-----

SELECT RAND(100), RAND(), RAND();


DECLARE @counter SMALLINT;

SET @counter = 1;

WHILE @counter < 5
BEGIN
    SELECT RAND(100) Random_Number
    SET @counter = @counter + 1
END;

-----

SELECT [InvoiceId]
       , [Total]
       , DATEPART(QUARTER, [InvoiceDate]) AS [Quarter]
       , MONTH([InvoiceDate]) AS [Month]
       , YEAR([InvoiceDate]) AS [Year]
       , DAY([InvoiceDate]) AS [Day]
  FROM [Invoices];

  ----

SELECT [InvoiceId]
       , [InvoiceDate]
       , DATEDIFF (QUARTER,[InvoiceDate], GETDATE()) AS [Quarter]
       , DATEDIFF (MONTH,[InvoiceDate], GETDATE()) AS [Month]
       , DATEDIFF (YEAR,[InvoiceDate], GETDATE()) AS [Year]
       , DATEDIFF (DAY,[InvoiceDate], GETDATE()) AS [Day]
FROM   [Invoices];

  ----

SELECT [InvoiceId]
       , [InvoiceDate]
       , DATEADD(DAY, 30, [InvoiceDate]) AS [NewDate]
FROM   [Invoices];