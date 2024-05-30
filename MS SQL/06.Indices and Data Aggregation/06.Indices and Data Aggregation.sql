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

-----

  SELECT [DepositGroup]
        ,SUM(DepositAmount) AS [TotalSum]
    FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup],[MagicWandCreator]
  HAVING SUM(DepositAmount) < 150000
ORDER BY SUM(DepositAmount) DESC;


-- Task 08.Deposits Charge

  SELECT [DepositGroup]
        ,[MagicWandCreator]
        ,MIN(DepositCharge) AS [MinDepositCharge]
    FROM [WizzardDeposits]
GROUP BY [DepositGroup],[MagicWandCreator]
ORDER BY [MagicWandCreator],[DepositGroup]


-- Task 09.Age Groups 

  SELECT [AgeGroup]
        ,COUNT(*) AS [WizardCount]
    FROM
       (
         SELECT 
           CASE
                WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
                WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
                WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
                WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
                WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
                WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
                WHEN [Age] > 60 THEN '[60+]'
         END AS [AgeGroup]
           FROM [WizzardDeposits]
       ) AS AgeGroupQuery
GROUP BY [AgeGroup];


-- Task 10.First Letter

  SELECT [FirstLetter]
    FROM
       (
         SELECT LEFT([FirstName],1) AS [FirstLetter]
               ,[DepositGroup]
           FROM [WizzardDeposits]
       ) AS UniqueFirstLetterQuery
GROUP BY [DepositGroup], [FirstLetter]
  HAVING [DepositGroup] = 'Troll Chest';

-----

   SELECT DISTINCT LEFT([FirstName],1) AS [FirstLetter]
     FROM [WizzardDeposits]
    WHERE [DepositGroup] = 'Troll Chest'

-- Task 11.Average Interest 

  SELECT [DepositGroup]
        ,[IsDepositExpired]
        ,AVG([DepositInterest]) AS [AverageInterest]
    FROM [WizzardDeposits]
  WHERE [DepositStartDate] > '1985-01-01'
GROUP BY [DepositGroup],[IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired];


-- Task 12. Rich Wizard, Poor Wizard

SELECT SUM([Difference]) AS [SumDifference]
  FROM (
        SELECT [Id]
              ,[DepositAmount]
              ,LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Guest Wizard Deposit]
              ,[DepositAmount] - LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS Difference
          FROM [WizzardDeposits]
  ) AS [DeposirDifferenceQuery]


GO

USE SoftUni

GO

-- Task 13.Departments Total Salaries 

  SELECT [DepartmentID]
        ,SUM(Salary) AS [TotalSalary]
    FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID];


--Task 14. Employees Minimum Salaries

  SELECT [DepartmentID]
        ,MIN([Salary]) AS [MinimumSalary]
    FROM [Employees]
   WHERE [HireDate] > '2000-01-01' AND [DepartmentID] IN (2,5,7)
GROUP BY DepartmentID


-- Task 15. Employees Average Salaries

SELECT *
  INTO [NewEmployees]
  FROM [Employees]
 WHERE [Salary] > 30000;

DELETE 
  FROM [NewEmployees]
 WHERE [ManagerID] = 42;

UPDATE [NewEmployees]
   SET [Salary] = [Salary] + 5000
 WHERE [DepartmentID] = 1;

  SELECT [DepartmentID]
        ,AVG([Salary]) AS [AverageSalary]
    FROM [NewEmployees]
GROUP BY [DepartmentID];


-- Task 16. Employees Maximum Salaries

  SELECT [DepartmentID]
        ,MAX([Salary]) AS [MaxSalary]
    FROM [Employees]
GROUP BY DepartmentID
  HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000;


-- Task 17. Employees Count Salaries

SELECT COUNT(*) AS [Count]
  FROM [Employees]
 WHERE [ManagerID] IS NULL;


 -- Task 18. 3rd Highest Salary

  SELECT [DepartmentID]
        ,[ThirdHighestSalary]
    FROM (
         SELECT [DepartmentID]
               ,[Salary] AS [ThirdHighestSalary]
               ,DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [RankedSalaries]
           FROM [Employees]
    ) AS RankedSalariesQuery
   WHERE [RankedSalaries] = 3
GROUP BY [DepartmentID],[ThirdHighestSalary]


-- Task 19. Salary Challenge

  SELECT 
 TOP(10) e.FirstName
        ,e.LastName
        ,e.DepartmentID
    FROM Employees AS e 
    JOIN (
            SELECT [DepartmentID]
                  ,AVG(Salary) AS AverageSalary
              FROM Employees
          GROUP BY [DepartmentID]
          ) AS avs ON e.DepartmentID = avs.DepartmentID
   WHERE [Salary] > [AverageSalary]
ORDER BY e.[DepartmentID];
