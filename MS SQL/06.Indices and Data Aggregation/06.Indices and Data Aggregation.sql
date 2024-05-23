USE Gringotts

GO

-- Task 01.

  SELECT COUNT(*) AS [Count]
    FROM [WizzardDeposits];


-- Task 02. Longest Magic Wand

SELECT MAX(MagicWandSize) AS [LongestMagicWand] 
  FROM [WizzardDeposits];


-- Task 03. Longest Magic Wand per Deposit Groups

  SELECT [DepositGroup]
         ,MAX(MagicWandSize) AS [LongestMagicWand] 
    FROM [WizzardDeposits]
GROUP BY [DepositGroup];


--Task 04.Smallest Deposit Group Per Magic Wand Size

  SELECT 
  TOP(2) [DepositGroup]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup]
ORDER BY AVG(MagicWandSize);


-- Task 05.Deposits Sum 

  SELECT [DepositGroup]
        ,SUM(DepositAmount) AS [TotalSum]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup];


-- Task 06.Deposits Sum for Ollivander Family 

  SELECT [DepositGroup]
        ,SUM(DepositAmount) AS [TotalSum]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup],[MagicWandCreator]
  HAVING [MagicWandCreator] = 'Ollivander family';


-- Task 07.Deposits Filter 
  
  SELECT [DepositGroup]
        ,SUM(DepositAmount) AS [TotalSum]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup],[MagicWandCreator]
  HAVING [MagicWandCreator] = 'Ollivander family' AND SUM(DepositAmount) < 150000
ORDER BY SUM(DepositAmount) DESC;


-- Task 08.Deposits Charge

  SELECT [DepositGroup]
        ,[MagicWandCreator]
        ,MIN(DepositCharge) AS [MinDepositCharge]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup],[MagicWandCreator]
ORDER BY [MagicWandCreator],[DepositGroup]


-- Task 09.Age Groups 

















GO

USE SoftUni

GO


-- Task 13.Departments Total Salaries 

  SELECT [DepartmentID]
        ,SUM(Salary) AS [TotalSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID];