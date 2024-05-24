USE SoftUni

-- Task 01. Employee Address

SELECT TOP (5) e.[EmployeeID]
           , e.[JobTitle]
           , a.[AddressID]
           , a.[AddressText]
      FROM [Employees] AS e
      JOIN [Addresses] AS a ON e.AddressID = a.AddressID
  ORDER BY a.[AddressID];


-- Task 02. Addresses with Towns

SELECT TOP (50) e.[FirstName]
           , e.[LastName]
           , t.[Name] AS [Town]
           , a.[AddressText]
      FROM [Employees] AS e
      JOIN [Addresses] AS a ON e.AddressID = a.AddressID
      JOIN [Towns] AS t ON a.TownID = t.TownID
  ORDER BY e.[FirstName], e.[LastName];


-- Task 03. Sales Employees

  SELECT e.[EmployeeID]
         , e.[FirstName]
         , e.[LastName]
         , d.[Name] AS [DepartmentName]
    FROM [Departments] AS d
    JOIN [Employees] AS e ON d.[DepartmentID] = e.[DepartmentID]
   WHERE d.[Name] = 'Sales'
ORDER BY e.[EmployeeID];


-- Task 04. Employee Departments

  SELECT TOP (5)
         e.[EmployeeID]
         , e.[FirstName]
         , e.[Salary]
         , d.[Name] AS [DepartmentName]
    FROM [Employees] AS e 
    JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE e.[Salary] > 15000
ORDER BY d.[DepartmentID];


-- Task 05. Employees Without Projects

  SELECT TOP (3)
         [EmployeeID]
         , [FirstName]
    FROM [Employees]
   WHERE [EmployeeID] NOT IN (
  SELECT [EmployeeID]
    FROM [EmployeesProjects]
   )
ORDER BY [EmployeeID];


-- Task 06. Employees Hired After

  SELECT e.[FirstName]
         , e.[LastName]
         , e.[HireDate]
         , d.[Name] AS [DeptName]
    FROM [Employees] AS e 
    JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
   WHERE d.[Name] IN ('Finance','Sales') AND e.[HireDate] > 1999-01-01
ORDER BY e.[HireDate];


-- Task 07. Employees With Project

  SELECT TOP (5)
         e.[EmployeeID]
         , e.[FirstName]
         , p.[Name] AS [ProjectName]
    FROM [Employees] AS e 
    JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
    JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
   WHERE p.[StartDate] > 2002-08-13 AND p.[EndDate] IS NULL
ORDER BY e.[EmployeeID];


-- Task 08. Employee 24

  SELECT e.[EmployeeID]
         , e.[FirstName]
         , CASE
             WHEN YEAR(p.[StartDate]) >= 2005 THEN NULL
             ELSE p.[Name]
         END AS [ProjectName]
    FROM [Employees] AS e 
    JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
    JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
   WHERE e.[EmployeeID] = 24;


-- Task 09. Employee Manager

  SELECT e.[EmployeeID]
         , e.[FirstName]
         , e.[ManagerID]
         , m.[FirstName] AS [ManagerName]
    FROM [Employees] AS e 
    JOIN [Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
   WHERE e.[ManagerID] IN (3,7)
ORDER BY e.[EmployeeID];


-- Task 10. Employees Summary

  SELECT TOP (50)
         e.[EmployeeID]
         , CONCAT(e.[FirstName], ' ', e.[LastName]) AS [EmployeeName]
         , CONCAT(m.[FirstName], ' ', m.[LastName]) AS [ManagerName]
         , d.[Name] AS [DepartmentName]
    FROM [Employees] AS e 
    JOIN [Employees] AS m ON e.[ManagerID] = m.[EmployeeID]
    JOIN [Departments] AS d ON e.[DepartmentID] = d.[DepartmentID]
ORDER BY e.[EmployeeID];


-- Task 11.Min Average Salary

    WITH [AverageSalaries]
      AS
         (
  SELECT AVG(Salary) AS s 
    FROM [Employees]
GROUP BY [DepartmentID]
)
  SELECT MIN([s]) AS [MinAverageSalry]
    FROM [AverageSalaries];


GO

USE [Geography]

GO


-- Task 12. Highest Peaks in Bulgaria

SELECT mc.[CountryCode]
         , m.[MountainRange]
         , p.[PeakName]
         , p.[Elevation]
    FROM [Peaks] AS p 
    JOIN [Mountains] AS m ON p.[MountainId] = m.[Id]
    JOIN [MountainsCountries] AS mc ON p.[MountainId] = mc.[MountainId]
   WHERE mc.[CountryCode] = 'BG' AND p.[Elevation] > 2835
ORDER BY p.Elevation DESC;


-- Task 13. Count Mountain Ranges

SELECT c.CountryCode
       , COUNT(mc.MountainId)
  FROM [Countries] AS c 
  JOIN [MountainsCountries] AS mc ON c.CountryCode = mc.CountryCode
 WHERE mc.CountryCode IN ('BG','RU','US')
GROUP BY c.[CountryCode];


-- Task 14. Countries With or Without Rivers

  SELECT TOP (5)
         c.CountryName
         , r.RiverName
    FROM [Countries] AS c 
    LEFT JOIN [CountriesRivers] AS cr ON c.CountryCode = cr.CountryCode
    LEFT JOIN [Rivers] AS r ON cr.RiverId = r.Id
   WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName;


-- Task 15. Continents and Currencies

SELECT [ContinentCode]
       , [CurrencyCode]
       , [CurrencyUsage]
  FROM
      ( SELECT *
              , DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC) AS [RankedCurrencyUsage]
         FROM
              (
              SELECT
                     [ContinentCode],
                     [CurrencyCode],
                     COUNT([CurrencyCode]) AS [CurrencyUsage]
                FROM
                     [Countries]
             
            GROUP BY
                     [ContinentCode],
                     [CurrencyCode]
              HAVING
                     COUNT(DISTINCT [CountryCode]) > 1
             
              )
          AS FirstQuery
        )
        AS SecondQuery
     WHERE [RankedCurrencyUsage] = 1;


-- Task 16. Countries Without any Mountains

   SELECT COUNT(*)
     FROM [Countries] AS c 
LEFT JOIN [MountainsCountries] AS mc ON c.CountryCode = mc.CountryCode
    WHERE [MountainId] IS NULL;


-- Task 17. Highest Peak and Longest River by Country

   SELECT  TOP (5)
           CountryName
          ,[HighestPeakElevation]
          ,[LongestRiverLength ]
     FROM
          (   SELECT c.CountryName
                   ,p.Elevation AS [HighestPeakElevation]
                   ,r.Length AS [LongestRiverLength ]
                   ,DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS [DensedElevation]
                   ,DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY r.Length DESC) AS [DensedLength]
               FROM [Countries] AS c 
          LEFT JOIN [MountainsCountries] AS mc ON c.CountryCode = mc.CountryCode
          LEFT JOIN [CountriesRivers] AS cr ON c.CountryCode = cr.CountryCode
          LEFT JOIN [Peaks] AS p ON mc.MountainId = p.MountainId
          LEFT JOIN [Rivers] AS r ON cr.RiverId = r.Id
          )      AS [Query]
   WHERE DensedElevation = 1 AND DensedLength = 1
ORDER BY Query.HighestPeakElevation DESC, Query.[LongestRiverLength ] DESC, Query.CountryName


-- Task 18. Highest Peak Name and Elevation by Country

  SELECT TOP(5)
        [CountryName]
        ,CASE 
         WHEN [PeakName] IS NULL THEN '(no highest peak)'
         ELSE [PeakName]
         END AS [Highest Peak Name]
         ,CASE 
         WHEN [Elevation] IS NULL THEN '0'
         ELSE [Elevation]
         END AS [Highest Peak Elevation]
         ,CASE 
         WHEN [MountainRange] IS NULL THEN '(no mountain)'
         ELSE [MountainRange]
         END AS [Mountain]
    FROM
         (
            SELECT c.CountryName
                  ,p.PeakName
                  ,p.Elevation
                  ,m.MountainRange
                  ,RANK() OVER (PARTITION BY c.[CountryCode] ORDER BY p.[Elevation] DESC) AS [RankedPeaks]
              FROM [Countries] AS c 
         LEFT JOIN [MountainsCountries] AS mc ON c.CountryCode = mc.CountryCode
         LEFT JOIN [Mountains] AS m ON mc.MountainId = m.Id
         LEFT JOIN [Peaks] AS p ON mc.MountainId = p.MountainId
         ) AS [JoinedCountries]
   WHERE JoinedCountries.RankedPeaks = 1
ORDER BY JoinedCountries.CountryName, JoinedCountries.PeakName