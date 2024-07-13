CREATE DATABASE [LibraryDb];

GO

USE [LibraryDb];

GO

--Task 01.DDL

CREATE TABLE [Genres] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE [Contacts] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Email] NVARCHAR(100)
            ,[PhoneNumber] NVARCHAR(20)
            ,[PostAddress] NVARCHAR(200)
            ,[Website] NVARCHAR(50)
            
)

CREATE TABLE [Authors](
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] NVARCHAR(100) NOT NULL
            ,[ContactId] INT FOREIGN KEY REFERENCES [Contacts](Id) NOT NULL

)

CREATE TABLE [Books] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Title] NVARCHAR(100) not NULL
            ,[YearPublished] int NOT NULL
            ,[ISBN] NVARCHAR(13) UNIQUE NOT NULL
            ,[AuthorId] INT FOREIGN KEY REFERENCES [Authors](Id) NOT NULL
            ,[GenreId] INT FOREIGN KEY REFERENCES [Genres](Id) NOT NULL

)

CREATE TABLE [Libraries] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] NVARCHAR(50) NOT NULL
            ,[ContactId] INT FOREIGN KEY REFERENCES [Contacts](Id) NOT NULL
)

CREATE TABLE [LibrariesBooks] (
             [LibraryId] INT FOREIGN KEY REFERENCES [Libraries](Id) NOT NULL
            ,[BookId] INT FOREIGN KEY REFERENCES [Books](Id) NOT NULL
            ,PRIMARY KEY ([LibraryId], [BookId])
)


-- Task 02. Insert

INSERT INTO [Contacts]
     VALUES (NULL, NULL, NULL, NULL)
           ,(NULL, NULL, NULL, NULL)
           ,('stephen.king@example.com', '+4445556666',	'15 Fiction Ave, Bangor, ME',	'www.stephenking.com')
           ,('suzanne.collins@example.com',	'+7778889999',	'10 Mockingbird Ln, NY, NY',	'www.suzannecollins.com')

INSERT INTO [Authors]
     VALUES ('George Orwell',	21)
        ,('Aldous Huxley',	22)
        ,('Stephen King',	23)
        ,('Suzanne Collins',	24)

INSERT INTO [Books]
      VALUES ('1984',	1949,	'9780451524935',	16,	2)
        ,('Animal Farm',	1945,	'9780451526342',		16,	2)
        ,('Brave New World',	1932,	'9780060850524',	17,	2)
        ,('The Doors of Perception',	1954,	'9780060850531',	17,	2)
        ,('The Shining',	1977,	'9780307743657',	18,	9)
        ,('It',	1986	,'9781501142970',	18,	9)
        ,('The Hunger Games',	2008,	'9780439023481'	,19	,7)
        ,('Catching Fire',	2009,	'9780439023498',	19	,7)
        ,('Mockingjay',	2010	,'9780439023511',	19	,7)

INSERT INTO [LibrariesBooks] 
      VALUES (1,36)
     ,(1,37)
     ,(2,38)
     ,(2,39)
     ,(3,40)
     ,(3,41)
     ,(4,42)
     ,(4,43)
     ,(5,44)


-- Task 03. Update

update c
   set c.Email = CONCAT('www.', LOWER(a.Name), '.com')
  from [Contacts] AS c
  join [Authors] as a ON c.Id = a.ContactId
 WHERE c.Email IS NULL

 select *
 from Contacts

 -- Task 04. Delete




delete
  FROM LibrariesBooks
 WHERE [BookId] IN (
     SELECT [Id]
   FROM [Books]
WHERE [AuthorId] IN (
             SELECT [Id]
               FROM Authors
              WHERE [Name] = 'Alex Michaelides' 
)
 )

DELETE
   FROM [Books]
WHERE [AuthorId] IN (
             SELECT [Id]
               FROM Authors
              WHERE [Name] = 'Alex Michaelides' 
)

DELETE
   FROM Authors
 WHERE [Name] = 'Alex Michaelides' 


-- Task 05. Chronological Order

  SELECT [Title] AS [Book Title]
        ,[ISBN]
        ,[YearPublished] AS [YearReleased]
    FROM [Books]
ORDER BY YearPublished DESC, [Title]


-- Task 06. Books by Genre

  SELECT b.Id
        ,b.Title
        ,b.ISBN
        ,g.Name AS [Genre]
    FROM [Books] as b 
    JOIN [Genres] as g ON b.GenreId = g.Id
   WHERE g.Name IN ('Historical Fiction', 'Biography')
ORDER BY [Genre], [Title]


-- Task 07. Missing Genre

  SELECT DISTINCT l.Name AS Library 
        ,Email
    FROM [Libraries] as l 
    JOIN [Contacts] as c ON c.Id = l.ContactId
   WHERE l.Id not in (
      SELECT l.Id
    FROM [Libraries] as l 
    JOIN [Contacts] as c ON c.Id = l.ContactId
    JOIN [LibrariesBooks] AS lb ON lb.LibraryId = l.Id
    JOIN [Books] as b on b.Id = lb.BookId
    JOIN [Genres] as g on g.Id = b.GenreId
   WHERE g.Name = ('Mystery')
   )
ORDER BY l.Name


  SELECT l.Id
    FROM [Libraries] as l 
    JOIN [Contacts] as c ON c.Id = l.ContactId
    JOIN [LibrariesBooks] AS lb ON lb.LibraryId = l.Id
    JOIN [Books] as b on b.Id = lb.BookId
    JOIN [Genres] as g on g.Id = b.GenreId
   WHERE g.Name = ('Mystery')
ORDER BY l.Name


-- Task 08. First 3 Books

  SELECT
  TOP(3) [Title]
        ,b.YearPublished as [Year]
        ,g.Name as [Genre]
    FROM [Books] as b 
    JOIN [Genres] as g on g.Id = b.GenreId
   WHERE b.YearPublished > 2000 AND b.Title LIKE '%a%' OR b.YearPublished < 1950 AND g.Name LIKE '%Fantasy%'
ORDER BY Title, [Year] DESC


-- Task 09. Authors from UK

  SELECT a.Name as [Author]
        ,[Email]
        ,[PostAddress] as [Address]
    FROM [Authors] as a 
    JOIN [Contacts] as c on c.Id = a.ContactId
   WHERE [PostAddress] LIKE '%UK%'
ORDER BY [Author]


-- Task 10. Fictions in Denver

  SELECT a.Name as [Author]
        ,b.Title
        ,l.Name as [Library]
        ,PostAddress AS [Library Address]
    FROM [Books] as b 
    JOIN [LibrariesBooks] as lb on lb.BookId = b.Id
    JOIN [Libraries] as l on l.Id = lb.LibraryId
    JOIN [Contacts] as c on c.Id = l.ContactId
    JOIN [Authors] as a on a.Id = b.AuthorId
    JOIN [Genres] as g on g.Id = b.GenreId
   WHERE g.Name = 'Fiction' AND [PostAddress] LIKE '%Denver%'
ORDER BY [Title]

-- Task 11. Authors with Books

SELECT COUNT(b.Id)
  FROM [Books] as b 
  JOIN [Authors] as a on a.Id = b.AuthorId
 WHERE b.Id IN (
        SELECT [BookId]
          FROM [LibrariesBooks]
 ) AND a.Name = 'J.K. Rowling'

GO

 CREATE FUNCTION udf_AuthorsWithBooks(@name NVARCHAR(100))
         RETURNS INT
              AS
           BEGIN
         DECLARE @numberOfBooks INT
                     
            SELECT @numberOfBooks =  COUNT(b.Id)
  FROM [Books] as b 
  JOIN [Authors] as a on a.Id = b.AuthorId
 WHERE b.Id IN (
        SELECT [BookId]
          FROM [LibrariesBooks]
 ) AND a.Name = @name

          RETURN @numberOfBooks
            END



-- Task 12. Search by Genre

GO

CREATE PROC usp_SearchByGenre(@genreName NVARCHAR(30)) 
         AS
     SELECT b.Title
           ,[YearPublished] as [Year]
           ,[ISBN]
           ,a.Name as [Author]
           ,g.Name as[Genre]
       FROM [Books] as b 
       JOIN [Authors] as a ON a.Id = b.AuthorId
       JOIN [Genres] as g on g.Id = b.GenreId
      WHERE g.Name = @genreName
   ORDER BY [Title]


   ------


   update c
   set c.Website = CONCAT('www.', REPLACE(LOWER(a.Name), ' ', ''), '.com')
  from [Contacts] AS c
  join [Authors] as a ON c.Id = a.ContactId
 WHERE c.Website IS NULL

 select *
 from Contacts

 UPDATE [Contacts]
    SET [Email] = null 
WHERE Id BETWEEN 9 and 15