SELECT TOP (50) e.[FirstName]
           , e.[LastName]
           , t.[Name] AS [Town]
           , a.[AddressText]
      FROM [Employees] AS e
      JOIN [Addresses] AS a ON e.AddressID = a.AddressID
      JOIN [Towns] AS t ON a.TownID = t.TownID
  ORDER BY e.[FirstName], e.[LastName];


  ------------------------------


  SELECT e.[EmployeeID]
         , e.[FirstName]
         , e.[LastName]
         , d.[Name] AS [DepartmentName]
    FROM [Departments] AS d
    JOIN [Employees] AS e ON d.[DepartmentID] = e.[DepartmentID]
   WHERE d.[Name] = 'Sales'
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