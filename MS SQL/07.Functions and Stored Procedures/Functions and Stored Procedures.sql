CREATE or ALTER FUNCTION udf_GetSalaryLevel(@salary DECIMAL(18,4))
      RETURNS VARCHAR(7)
                      AS
                   BEGIN
                         DECLARE @salaryLevel VARCHAR(7);
                              IF (@salary < 30000)
                                 BEGIN
                                       SET @salaryLevel = 'Low'
                                   END
                              ELSE IF (@salary <= 50000)
                                 BEGIN
                                    SET @salaryLevel = 'Average'
                                   END
                              ELSE IF (@salary > 50000)
                                 BEGIN
                                       SET @salaryLevel = 'High'
                                   END
                          RETURN @salaryLevel
                   END
      
      GO
 
SELECT [Salary]
      ,dbo.udf_GetSalaryLevel([Salary]) AS [Salary Level]
  FROM [Employees]