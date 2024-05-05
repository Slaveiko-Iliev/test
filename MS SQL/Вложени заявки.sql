-- За да решите тази задача, не е необходимо да използвате вложени заявки. Можете да използвате DENSE_RANK функцията за 
-- рангиране на служителите според заплатата им.

-- Ето как бихте могли да напишете заявката:

-- SQL

SELECT EmployeeID, Salary,
       DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS EmployeeRank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC;


-- AI-generated code. Review and use carefully. More info on FAQ.
-- В тази заявка:

-- Използваме DENSE_RANK() функцията, която ще рангира служителите според заплатата им.
-- PARTITION BY Salary разделя данните на групи според заплатата.
-- ORDER BY EmployeeID подрежда служителите вътре във всяка група по EmployeeID.
-- WHERE Salary BETWEEN 10000 AND 50000 филтрира само служителите с заплата между 10000 и 50000.
-- ORDER BY Salary DESC подрежда резултатите по заплата в намаляващ ред.
-- Така ще получите резултат, който включва EmployeeID, Salary и EmployeeRank за всички подходящи служители. Успех! 🚀

-------------------

-- За да извлечете само тези служители, които при DENSE_RANK получават стойност 2, можете да добавите още един филтър към 
-- вашия заявка. В този случай, след като сте рангирали служителите, ще изберете само тези с ранг 2.

-- Ето как бихте могли да напишете заявката:

-- SQL

WITH RankedEmployees AS (
    SELECT EmployeeID, Salary,
           DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS EmployeeRank
    FROM Employees
    WHERE Salary BETWEEN 10000 AND 50000
)
SELECT EmployeeID, Salary
FROM RankedEmployees
WHERE EmployeeRank = 2
ORDER BY Salary DESC;


-- AI-generated code. Review and use carefully. More info on FAQ.
-- В тази заявка:

-- Създаваме обща таблица с име RankedEmployees, която съдържа EmployeeID, Salary и EmployeeRank.
-- След това избираме само редовете, където EmployeeRank е равен на 2.
-- Това ще ви даде резултат, който включва EmployeeID и Salary само за служителите с ранг 2. Успех!

-----------------------------

-- Общата таблица (WITH), известна още като Common Table Expression (CTE), е инструмент в SQL, който позволява
--  на програмистите да дефинират временни резултатни набори,които могат да бъдат използвани в рамките на една заявка.
--  Важно е да се отбележи, че CTE не създава физическа таблица в базата данни, а предоставя временен изглед, който може да бъде
--  използван в последващите заявки.

-- Ето някои ключови характеристики на общите таблиците (CTE):

-- Дефиниране: CTE се дефинира чрез ключовата дума WITH, последвана от името на CTE и определението му.
-- Използване: CTE може да бъде използвана в SELECT, INSERT, UPDATE или DELETE заявки.
-- Рекурсивност: CTE може да бъде рекурсивна, което позволява обработка на йерархични данни.
-- Четливост: CTE подобрява четливостта на заявките, като разделя сложни операции на по-малки части.
-- Пример за използване на CTE:

-- SQL

WITH EmployeeCTE AS (
    SELECT EmployeeID, FirstName, LastName
    FROM Employees
    WHERE Department = 'IT'
)
SELECT * FROM EmployeeCTE;


-- AI-generated code. Review and use carefully. More info on FAQ.
-- В този пример създаваме CTE с име EmployeeCTE, който съдържа служители от отдела за информационни технологии.
-- След това използваме CTE в SELECT заявката, за да изберем всички редове от него.