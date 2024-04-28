-- Task 02. Find All Information About Departments

SELECT * from Departments;

-- Task 03. Find all Department Names

SELECT Name  FROM Departments;

-- Task 04. Find Salary of Each Employee

SELECT FirstName, LastName, Salary FROM Employees;

-- Task 05. Find Full Name of Each Employee

SELECT FirstName, MiddleName, LastName FROM Employees;

-- Task 06. Find Email Address of Each Employee

SELECT CONCAT ([FirstName], '.', [LastName], '@softuni.bg') AS 'Full Email Address' FROM Employees;
-- SELECT [FirstName] + '.' + [LastName] + '@softuni.bg' AS 'Full Email Address' FROM Employees;

-- Task 07. Find All Different Employee’s Salaries

SELECT DISTINCT Salary from Employees;

-- Task 08. Find all Information About Employees

SELECT * FROM Employees
WHERE [JobTitle] = 'Sales Representative';

-- Task 09. Find Names of All Employees by Salary in Range

SELECT FirstName, LastName, JobTitle from Employees
WHERE Salary BETWEEN 20000 AND 30000;

-- Task 10. Find Names of All Employees

SELECT
    CONCAT_WS(' ', FirstName, MiddleName, LastName) AS [Full Name]
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600);

-- Task 11. Find All Employees Without Manager

SELECT FirstName, LastName FROM Employees
WHERE ManagerID IS NULL;

-- Task 12. Find All Employees with Salary More Than

SELECT FirstName, LastName, Salary FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC;

--Task 13. Find 5 Best Paid Employees

SELECT TOP (5) FirstName, LastName FROM Employees
ORDER BY Salary DESC;

--Task 14. Find All Employees Except Marketing

SELECT FirstName, LastName FROM Employees
WHERE NOT (DepartmentID = 4);

-- Task 15. Sort Employees Table

SELECT * from Employees
ORDER BY Salary DESC
        ,FirstName
        ,LastName DESC
        ,MiddleName

-- Task 16. Create View Employees with Salaries
GO

CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary
FROM Employees;

GO

SELECT * from V_EmployeesSalaries;

-- Task 17. Create View Employees with Job Titles

GO

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full name]
        , JobTitle
FROM Employees

GO

SELECT * FROM V_EmployeeNameJobTitle;

-- 18. Distinct Job Titles

SELECT DISTINCT JobTitle from Employees;

-- Task 19. Find First 10 Started Projects

SELECT TOP (10) * FROM Projects
ORDER BY StartDate
        , Name;

-- Task 20. Last 7 Hired Employees

SELECT TOP (7) FirstName, LastName, HireDate FROM Employees
ORDER BY HireDate DESC;

-- Task 21. Increase Salaries

GO

BEGIN TRANSACTION;

UPDATE Employees
SET Salary = Salary * 1.12
WHERE DepartmentID in (1, 2, 4, 11);
SELECT Salary FROM Employees
WHERE DepartmentID in (1, 2, 4, 11);

ROLLBACK;

SELECT Salary FROM Employees
WHERE DepartmentID in (1, 2, 4, 11);

-- Part II – Queries for Geography Database

-- Task 22. All Mountain Peaks

SELECT PeakName FROM Peaks
ORDER BY PeakName;

-- Task 23. Biggest Countries by Population

SELECT TOP (30) CountryName, [Population] FROM Countries
WHERE ContinentCode = 'EU'
ORDER BY [Population] DESC
        , CountryName;

-- Task 24. Countries and Currency (Euro / Not Euro)

SELECT CountryName, CountryCode, Currency = CASE CurrencyCode
     WHEN 'EUR' THEN 'Euro'
     ELSE 'Not Euro' 
END from Countries
ORDER BY CountryName;


-- Part III – Queries for Diablo Database

-- Task 25. All Diablo Characters

SELECT [Name] from Characters
ORDER BY [Name];