-- Task 01. Find Names of All Employees by First Name

SELECT [FirstName]
       , [LastName]
  FROM [Employees]
 WHERE [FirstName] LIKE 'Sa%';

 -- Task 02. Find Names of All Employees by Last Name

 SELECT [FirstName]
        , [LastName]
   FROM [Employees]
  WHERE [LastName] LIKE '%ei%';
-- Task 03. Find First Names of All Employees

SELECT [FirstName]
  FROM [Employees]
 WHERE [DepartmentID] IN (3, 10)
   AND YEAR(HireDate) BETWEEN 1995 AND 2005;

-- Task 04. Find All Employees Except Engineers

SELECT [FirstName]
       , [LastName]
  FROM Employees
 WHERE [JobTitle] NOT LIKE '%engineer%';

 -- Task 05. Find Towns with Name Length

  SELECT [Name]
    FROM [Towns]
   WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name];

-- Task 06. Find Towns Starting With

  SELECT *
    FROM [Towns]
   WHERE SUBSTRING([Name], 1, 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name];

-- Task 07. Find Towns Not Starting With

  SELECT *
    FROM [Towns]
   WHERE SUBSTRING([Name], 1, 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name];

--Task 08. Create View Employees Hired After 2000 Year

GO

CREATE VIEW V_EmployeesHiredAfter2000
         AS
     SELECT [FirstName]
            , [LastName]
       FROM [Employees]
      WHERE YEAR([HireDate]) > 2000;

GO

SELECT *
  FROM V_EmployeesHiredAfter2000;

-- Task 09. Length of Last Name

SELECT [FirstName]
       , [LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5;

 -- Task 10. Rank Employees by Salary

  SELECT [EmployeeID]
         , [FirstName]
         , [LastName]
         , [Salary]
         , DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC;

--- Task 11. Find All Employees with Rank 2

    WITH RankedEmployees AS (
  SELECT *
         , DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
    FROM [Employees]
   WHERE [Salary] BETWEEN 10000 AND 50000
)
  SELECT [EmployeeID]
         , [FirstName]
         , [LastName]
         , [Salary]
         , [Rank]
    FROM RankedEmployees
   WHERE Rank = 2
ORDER BY Salary DESC;

-- Task 12. Countries Holding 'A' 3 or More Times

  SELECT [CountryName] AS [Country Name]
         , [IsoCode] AS [ISO code]
    FROM [Countries]
   WHERE LEN(CountryName) - LEN(REPLACE(UPPER([CountryName]), 'A', '')) >= 3
ORDER BY [IsoCode];

-- Task 13. Mix of Peak and River Names

  SELECT p.[PeakName]
         , r.[RiverName]
         , LOWER (CONCAT (p.[PeakName], SUBSTRING (r.[RiverName], 2, LEN (r.[RiverName]) - 1))) AS [Mix]
    FROM [Peaks] AS p
    JOIN [Rivers] AS r
      ON LOWER (SUBSTRING(p.[PeakName], LEN (p.[PeakName]), 1)) = LOWER (SUBSTRING([RiverName], 1, 1))
ORDER BY [Mix];
 
-- Task 14. Games From 2011 and 2012 Year

SELECT TOP (50)
           [Name]
           , FORMAT ([Start], 'yyyy-MM-dd', 'en-gb') AS [Start]
      FROM [Games]
     WHERE YEAR ([Start]) BETWEEN 2011 AND 2012
  ORDER BY [Start],
           [Name];

-- Task 15. User Email Providers

  SELECT [Username]
         , SUBSTRING ([Email], CHARINDEX('@', [Email]) + 1, LEN ([Email]) - CHARINDEX('@', [Email])) AS [Email Provider]
    FROM [Users]
ORDER BY [Email Provider]
         , [Username];

-- Task 16. Get Users with IP Address Like Pattern

  SELECT [Username]
         , [IpAddress] AS [IP Address]
    FROM [Users]
   WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY [Username];

-- Task 17. Show All Games with Duration & Part of the Day

  SELECT [Name] AS [Game],
    CASE WHEN DATEPART (HOUR, [Start]) >= 0 AND DATEPART (HOUR, [Start]) < 12 THEN 'Morning'
         WHEN DATEPART (HOUR, [Start]) >= 12 AND DATEPART (HOUR, [Start]) < 18 THEN 'Afternoon'
         WHEN DATEPART (HOUR, [Start]) >= 18 AND DATEPART (HOUR, [Start]) < 24 THEN 'Evening'
     END AS [Part of the day],
    CASE WHEN [Duration] <= 3 THEN 'Extra Short'
         WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
         WHEN [Duration] > 6 THEN 'Long'
         WHEN [Duration] IS NULL THEN 'Extra Long'
     END AS [Duration]
    FROM [Games]
ORDER BY [Game]
         , [Duration];

        
-- Task 18. Orders Table

SELECT [ProductName]
       , [OrderDate]
       , DATEADD(DAY, 3, [OrderDate]) AS [Pay Due]
       , DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
  FROM [Orders]

  --Task 19. People Table

  CREATE TABLE [People] (
    Id INT PRIMARY KEY IDENTITY
    , [Name] VARCHAR (20) NOT NULL
    , [Birthdate] DATETIME2 NOT NULL
    );

    INSERT INTO [People] ([Name], Birthdate)
         VALUES ('Victor', '2000-12-07 00:00:00.000')
                , ('Steven', '1992-09-10 00:00:00.000')
                , ('Stephen', '1910-09-19 00:00:00.000')
                , ('John', '2010-01-06 00:00:00.000');

GO

SELECT [Name]
       , DATEDIFF(YEAR, [Birthdate], GETDATE ()) AS [Age in Years]
       , DATEDIFF(MONTH, [Birthdate], GETDATE ()) AS [Age in Months]
       , DATEDIFF(DAY, [Birthdate], GETDATE ()) AS [Age in Days]
       , DATEDIFF(MINUTE, [Birthdate], GETDATE ()) AS [Age in Minutes]
  FROM [People];