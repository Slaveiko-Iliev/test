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