USE SoftUni

GO

-- Task 01. Employees with Salary Above 35000

CREATE OR ALTER PROC usp_GetEmployeesSalaryAbove35000
                  AS
              SELECT [FirstName] AS [First Name]
                    ,[LastName] AS [Last Name]
                FROM [Employees]
               WHERE [Salary] > 35000
         
                EXEC usp_GetEmployeesSalaryAbove35000;
         
                  GO


-- Task 02. Employees with Salary Above Number

CREATE OR ALTER PROC usp_GetEmployeesSalaryAboveNumber (@salary DECIMAL(18,4))
                  AS
              SELECT [FirstName] AS [First Name]
                    ,[LastName] AS [Last Name]
                FROM [Employees]
               WHERE [Salary] >= @salary;
         
                EXEC usp_GetEmployeesSalaryAboveNumber 48100;
         
                  GO


-- Task 03. Town Names Starting With

CREATE OR ALTER PROC usp_GetTownsStartingWith (@townStartName NVARCHAR (10))
                  AS
              SELECT [Name] AS [Town]
                FROM [Towns]
               WHERE [Name] LIKE @townStartName + '%'


               EXEC usp_GetTownsStartingWith 'b'

                 GO


-- Task 04. Employees from Town

CREATE PROC usp_GetEmployeesFromTown (@townName NVARCHAR (10))
                  AS
              SELECT [FirstName] AS [First Name]
                    ,[LastName] AS [Last Name]
                FROM [Employees] AS e 
                JOIN [Addresses] AS a
                  ON e.AddressID = a.AddressID
                JOIN [Towns] AS t 
                  ON a.TownID = t.TownID
               WHERE t.[Name] LIKE @townName;

               EXEC usp_GetEmployeesFromTown 'Sofia';

               GO


-- Task 05. Salary Level Function

CREATE OR ALTER FUNCTION udf_GetSalaryLevel(@salary DECIMAL(18,4))
      RETURNS VARCHAR(7)
                      AS
                   BEGIN
                         DECLARE @salaryLevel VARCHAR(7);
                              IF (@salary < 30000)
                             SET @salaryLevel = 'Low'
                         ELSE IF (@salary <= 50000)
                             SET @salaryLevel = 'Average'
                         ELSE IF (@salary > 50000)
                             SET @salaryLevel = 'High'
                          RETURN @salaryLevel
                   END
      
      GO
 
SELECT [Salary]
      ,dbo.udf_GetSalaryLevel([Salary]) AS [Salary Level]
  FROM [Employees]
    
    GO


-- Task 06. Employees by Salary Level

CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel VARCHAR(10))
         AS
     SELECT [FirstName] AS [First Name]
           ,[LastName] AS [Last Name]
       FROM
          (
            SELECT *
                  ,dbo.udf_GetSalaryLevel([Salary]) AS [Salary Level]
              FROM Employees
          )
         AS SalaryLevelQuery
      WHERE [Salary Level] = @salaryLevel;

       EXEC usp_EmployeesBySalaryLevel 'High';







-- Task 09. Find Full Name

GO

USE Bank

GO

CREATE PROC usp_GetHoldersFullName
         AS
     SELECT CONCAT([FirstName],' ',[LastName]) AS [Full Name]
       FROM [AccountHolders];

       EXEC usp_GetHoldersFullName;

         GO


-- Task 10. People with Balance Higher Than

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@suppliedNumber MONEY)
         AS
     SELECT *
       FROM
          (
              SELECT [FirstName] AS [First Name]
                    ,[LastName] AS [Last Name]
                    ,SUM([Balance]) AS [Total]
                FROM [AccountHolders] AS ah 
                JOIN [Accounts] AS a ON ah.Id = a.AccountHolderId
            GROUP BY [FirstName], [LastName]
          )
         AS TotalBalanceQuery
      WHERE [Total] > @suppliedNumber
   ORDER BY [First Name],[Last Name]

       EXEC usp_GetHoldersWithBalanceHigherThan 100000;
         
         GO


-- Task 11. Future Value Function

CREATE OR ALTER FUNCTION dbo.udf_CalculateFutureValue (@initialSum MONEY, @interest FLOAT, @years INT)
   RETURNS MONEY
                      AS
                   BEGIN
                         DECLARE @futureValue MONEY
                             SET @futureValue = @initialSum * (POWER((1 + @interest), @years))
                          RETURN ROUND(@futureValue, 4)
                     END

GO


-- Task 12. Calculating Interest

CREATE OR ALTER PROC usp_CalculateFutureValueForAccount
         AS
     SELECT ah.[Id]
           ,[FirstName] AS [First Name]
           ,[LastName] AS [Last Name]
           ,[Balance] AS [Current Balance]
           ,dbo.udf_CalculateFutureValue(a.Balance,0.1,5) AS [Balance in 5 years]
       FROM [AccountHolders] AS ah 
       JOIN [Accounts] AS a ON ah.Id = a.AccountHolderId;

       EXEC usp_CalculateFutureValueForAccount

       

      --  select dbo.udf_CalculateFutureValue(dbo.Accounts.[Balance], 0.1, 5)