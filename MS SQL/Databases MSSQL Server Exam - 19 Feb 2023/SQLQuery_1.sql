CREATE DATABASE [Boardgames];

GO

USE [Boardgames];


-- Task 01. DDL

CREATE TABLE [Categories] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Addresses] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[StreetName] NVARCHAR(100) NOT NULL
            ,[StreetNumber] INT NOT NULL
            ,[Town] VARCHAR(30) NOT NULL
            ,[Country] VARCHAR(50) NOT NULL
            ,[ZIP] INT NOT NULL
)

CREATE TABLE [Publishers](
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] VARCHAR(30) UNIQUE NOT NULL
            ,[AddressId] INT FOREIGN KEY REFERENCES [Addresses](Id) NOT NULL
            ,[Website] NVARCHAR(40) NOT NULL
            ,[Phone] NVARCHAR(20) NOT NULL
)

CREATE TABLE [PlayersRanges] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[PlayersMin] INT NOT NULL
            ,[PlayersMax] INT NOT NULL
)

CREATE TABLE [Boardgames] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] NVARCHAR(30) NOT NULL
            ,[YearPublished] INT NOT NULL
            ,[Rating] DECIMAL(18,2) NOT NULL
            ,[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL
            ,[PublisherId] INT FOREIGN KEY REFERENCES [Publishers](Id) NOT NULL
            ,[PlayersRangeId] INT FOREIGN KEY REFERENCES [PlayersRanges](Id) NOT NULL
)

CREATE TABLE [Creators] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[FirstName] NVARCHAR(30) NOT NULL
            ,[LastName] NVARCHAR(30) NOT NULL
            ,[Email] NVARCHAR(30) NOT NULL
)

CREATE TABLE [CreatorsBoardgames] (
             [CreatorId] INT FOREIGN KEY REFERENCES [Creators](Id)
            ,[BoardgameId] INT FOREIGN KEY REFERENCES [Boardgames](Id)
            ,PRIMARY KEY ([CreatorId], [BoardgameId])
)

-- Task 02. Insert

INSERT INTO [Boardgames]
     VALUES ('Deep Blue', 2019, 5.67, 1, 15, 7)
           ,('Paris', 2016, 9.78, 7, 1, 5)
           ,('Catan: Starfarers', 2021, 9.87, 7, 13, 6)
           ,('Bleeding Kansas', 2020, 3.25, 3, 7, 4)
           ,('One Small Step', 2019, 5.75, 5, 9, 2);

INSERT INTO [Publishers]
     VALUES ('Agman Games', 5, 'www.agmangames.com', '+16546135542')
           ,('Amethyst Games', 7, 'www.amethystgames.com','+15558889992' )
           ,('BattleBooks', 13, 'www.battlebooks.com', '+12345678907');


-- Task 03. Update

UPDATE [PlayersRanges]
   SET [PlayersMax] = [PlayersMax] + 1
 WHERE [PlayersMax] = 2 AND [PlayersMin] = 2

UPDATE [Boardgames]
   SET [NAme] = CONCAT([NAme],'V2')
 WHERE [YearPublished] >= 2020;


-- Task 04. Delete

DELETE
   FROM [CreatorsBoardgames]
  WHERE [BoardgameId] IN (
                  SELECT [Id]
                    FROM [Boardgames]
                   WHERE [PublisherId] IN (
                                   SELECT [Id]
                                     FROM [Publishers]
                                    WHERE [AddressId] IN (
                                                  SELECT [Id]
                                                    FROM [Addresses]
                                                   WHERE [Town] LIKE 'L%'
                                    )
                   )
  )

GO

DELETE
  FROM [Boardgames]
 WHERE [PublisherId] IN (
                 SELECT [Id]
                   FROM [Publishers]
                  WHERE [AddressId] IN (
                                SELECT [Id]
                                  FROM [Addresses]
                                 WHERE [Town] LIKE 'L%'
                  )
 )

 GO

 DELETE
   FROM [Publishers]
  WHERE [AddressId] IN (
                SELECT [Id]
                  FROM [Addresses]
                 WHERE [Town] LIKE 'L%'
  )

GO

DELETE
  FROM [Addresses]
 WHERE [Town] LIKE 'L%'


-- Task 05. Boardgames by Year of Publication

  SELECT [Name]
        ,[Rating]
    FROM [Boardgames]
ORDER BY [YearPublished], [Name] DESC;


-- Task 06. Boardgames by Category

  SELECT b.Id
        ,b.Name
        ,[YearPublished]
        ,c.Name AS [CategoryName]
    FROM [Boardgames] AS b
    JOIN [Categories] AS c ON b.CategoryId = c.Id
   WHERE c.Name IN ('Strategy Games', 'Wargames')
ORDER BY [YearPublished] DESC;


-- Task 07. Creators without Boardgames

  SELECT [Id]
        ,CONCAT([FirstName], ' ', [LastName]) AS [CreatorName]
        ,[Email]
    FROM [Creators]
   WHERE [Id] NOT IN (
              SELECT [CreatorId]
                FROM [CreatorsBoardgames]
   )
ORDER BY [CreatorName];


-- Task 08. First 5 Boardgames

  SELECT 
  TOP(5) b.Name
        ,b.Rating
        ,c.Name AS [CategoryName]
    FROM [Boardgames] AS b 
    JOIN [PlayersRanges] AS p ON b.PlayersRangeId = p.Id
    JOIN [Categories] AS c ON c.Id = b.CategoryId
   WHERE [Rating] > 7 AND b.Name LIKE '%a%' OR [Rating] > 7.5 AND [PlayersMin] >= 2 AND [PlayersMax] <= 5
ORDER BY b.Name, b.Rating DESC;


-- Task 09. Creators with Emails

  SELECT CONCAT([FirstName], ' ', [LastName]) AS [FullName]
        ,[Email]
        ,MAX([Rating]) AS [Rating]
    FROM [Creators] AS c 
    JOIN [CreatorsBoardgames] AS cb ON c.Id = cb.CreatorId
    JOIN [Boardgames] AS b ON b.Id = cb.BoardgameId
   WHERE [Email] LIKE '%.com'
GROUP BY CONCAT([FirstName], ' ', [LastName]), [Email]
ORDER BY CONCAT([FirstName], ' ', [LastName]);


-- Task 10. Creators by Rating

  SELECT c.LastName
        ,CEILING(AVG([Rating])) AS [AverageRating]
        ,p.Name AS [PublisherName]
    FROM [Creators] AS c 
    JOIN [CreatorsBoardgames] AS cb ON c.Id = cb.CreatorId
    JOIN [Boardgames] AS b ON cb.BoardgameId = b.Id
    JOIN [Publishers] AS p ON b.PublisherId = p.Id
   WHERE p.Name = 'Stonemaier Games'
GROUP BY c.LastName, p.Name
ORDER BY AVG([Rating]) DESC

-- Task 11. Creator with Boardgames

GO

CREATE OR ALTER FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
        RETURNS INT
             AS
          BEGIN
                DECLARE @countOfBoardgames INT
                 SELECT @countOfBoardgames = COUNT(c.Id)
                                             FROM [Creators] AS c 
                                             JOIN [CreatorsBoardgames] AS cb ON c.Id = cb.CreatorId
                                            WHERE c.FirstName = @name
                RETURN @countOfBoardgames

            END

GO

SELECT dbo.udf_CreatorWithBoardgames('Bruno')


-- Task 12. Search for Boardgame with Specific Category


GO

CREATE OR ALTER PROC usp_SearchByCategory(@category VARCHAR(50))
         AS
     SELECT b.Name
           ,b.YearPublished
           ,Rating
           ,c.Name AS [CategoryName]
           ,p.Name AS [PublisherName]
           ,CONCAT(pr.PlayersMin, ' ', 'people')  AS [MinPlayers]
           ,CONCAT(pr.PlayersMax, ' ', 'people')  AS [MaxPlayers]
       FROM [Boardgames] AS b 
       JOIN [Publishers] AS p ON b.PublisherId = p.Id
       JOIN [PlayersRanges] AS pr ON pr.Id = b.PlayersRangeId
       JOIN [Categories] AS c ON c.Id = b.CategoryId
      WHERE c.Name = @category
   ORDER BY [PublisherName], [YearPublished] DESC


-- Task Databases MSSQL Server Retake Exam - 10 Aug 2022

