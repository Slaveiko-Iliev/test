--- Problem 01: DDL
CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(50) NOT NULL
	);

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY
	,StreetName NVARCHAR(100) NOT NULL
	,StreetNumber INT NOT NULL
	,Town VARCHAR(30) NOT NULL
	,Country VARCHAR(50) NOT NULL
	,ZIP INT NOT NULL
	);

CREATE TABLE Publishers(
	Id INT PRIMARY KEY IDENTITY
	,[Name] VARCHAR(30) UNIQUE NOT NULL
	,AddressId INT NOT NULL
	,Website NVARCHAR(50)
	,Phone NVARCHAR(20)
	,CONSTRAINT FK_Publishers_Addresses FOREIGN KEY (AddressId) REFERENCES Addresses(Id)
);

CREATE TABLE PlayersRanges(
	Id INT PRIMARY KEY IDENTITY
	,PlayersMin INT NOT NULL
	,PlayersMax INT NOT NULL
);

CREATE TABLE Boardgames(
	Id INT PRIMARY KEY IDENTITY
	,[Name] NVARCHAR(30) NOT NULL
	,YearPublished INT NOT NULL
	,Rating DECIMAL(3,2) NOT NULL
	,CategoryId INT NOT NULL
	,PublisherId INT NOT NULL
	,PlayersRangeId INT NOT NULL
	,CONSTRAINT FK_Boardgames_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
	,CONSTRAINT FK_Boardgames_Publishers FOREIGN KEY (PublisherId) REFERENCES Publishers(Id)
	,CONSTRAINT FK_Boardgames_PlayersRanges FOREIGN KEY (PlayersRangeId) REFERENCES PlayersRanges(Id)
);

CREATE TABLE Creators(
	Id INT PRIMARY KEY IDENTITY
	,FirstName NVARCHAR(30) NOT NULL
	,LastName NVARCHAR(30) NOT NULL
	,Email NVARCHAR(30) NOT NULL
);

CREATE TABLE CreatorsBoardgames(
	CreatorId INT NOT NULL
	,BoardgameId INT NOT NULL
	,CONSTRAINT PK_CreatorsBoardgames PRIMARY KEY (CreatorId,BoardgameID)
	,CONSTRAINT FK_CreatorsBoardgames_Creators  FOREIGN KEY (CreatorId) REFERENCES Creators(Id)
	,CONSTRAINT FK_CreatorsBoardgames_Cigars  FOREIGN KEY (BoardgameId) REFERENCES Boardgames(Id)
);


--- Problem 02: Insert
INSERT INTO Boardgames ([Name], YearPublished, Rating, CategoryId, PublisherId, PlayersRangeId) VALUES
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO Publishers ([Name], AddressId, Website, Phone) VALUES
('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')


--- Problem 03: Update
UPDATE PlayersRanges 
SET PlayersMax +=1 
WHERE Id=1 
UPDATE Boardgames 
SET [Name]=[Name] + 'V2'
WHERE YearPublished>=2020


--- Problem 04: Delete
DELETE FROM CreatorsBoardgames WHERE BoardgameId IN (1,16,31,47)
DELETE FROM Boardgames WHERE PublisherId IN (1,16)
DELETE FROM Publishers WHERE AddressId IN (5)
DELETE FROM Addresses WHERE SUBSTRING(Town, 1, 1) = 'L'


--- Problem 05: Boardgames by Year of Publication 
SELECT 
	[Name]
	,Rating
FROM Boardgames
ORDER BY YearPublished, [Name] DESC


--- Problem 06: Boardgames by Category 
SELECT
	b.Id
	,b.[Name]
	,b.YearPublished
	,c.Name
FROM Boardgames AS b
JOIN Categories AS c
ON b.CategoryId=c.Id
WHERE c.[Name]='Strategy Games' OR c.[Name]='Wargames'
ORDER BY YearPublished DESC

--- Problem 07: Creators without Boardgames
SELECT 
	c.Id
	,CONCAT(c.FirstName, ' ', LastName) AS CreatorName
	,c.Email
FROM  Creators AS c
LEFT JOIN CreatorsBoardgames AS cb
ON c.Id=cb.CreatorId
WHERE cb.CreatorId IS NULL
ORDER BY CreatorName 

--- Problem 08: First 5 Boardgames
SELECT TOP(5)
	c.[Name]
	,Rating
	,cat.[Name] AS CategoryName
FROM Boardgames AS c
LEFT JOIN Categories AS cat
ON c.CategoryId = cat.Id
LEFT JOIN PlayersRanges as r
ON c.PlayersRangeId = r.Id
WHERE Rating > 7
AND (c.[Name] LIKE '%a%'
OR Rating > 7.50)
AND PlayersMin >= 2
AND PlayersMax <= 5
ORDER BY [Name], CategoryName DESC

--- Problem 09: Creators with Emails
SELECT 
	CONCAT(c.FirstName, ' ', c.LastName) AS FullName
	,c.Email
	,MAX(b.Rating) AS Rating 
FROM CreatorsBoardgames AS cb
JOIN Creators AS c
ON cb.CreatorId=c.Id
JOIN Boardgames AS b
ON cb.BoardgameId=b.Id
WHERE Email NOT LIKE '%.net%'
GROUP BY CONCAT(c.FirstName, ' ', c.LastName), Email
ORDER BY CONCAT(c.FirstName, ' ', c.LastName)

--- Problem 10: Creators by Rating
SELECT 
	c.LastName
	,CEILING(AVG(b.Rating)) AS AverageRating
	,p.[Name]
FROM  Creators AS c
JOIN CreatorsBoardgames AS cb
ON c.Id=cb.CreatorId
JOIN Boardgames AS b
ON cb.BoardgameId=b.Id
JOIN Publishers AS p
ON b.PublisherId=p.Id
WHERE cb.CreatorId IS NOT NULL 
and p.[Name]='Stonemaier Games'
GROUP BY c.LastName,p.[Name]
ORDER BY AVG(b.Rating) DESC

--- Problem 11: Creator with Boardgames
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @totalBoardgamesCreator INT = 
	(
		SELECT
			COUNT(cb.BoardgameId)
		FROM Creators AS c
		INNER JOIN CreatorsBoardgames as cb
		ON c.Id = cb.CreatorId
		WHERE c.FirstName = @name
	)
	RETURN @totalBoardgamesCreator
END


--- Problem 12: Search for Boardgame with Specific Category
CREATE PROC usp_SearchByCategory(@category VARCHAR(50))
AS
	SELECT 
	    b.[Name]
		,b.YearPublished
		,b.Rating
		,cat.[Name] AS CategoryName
		,p.[Name] AS PublisherName
		,CONCAT(pr.PlayersMin, ' people') AS MinPlayers
		,CONCAT(pr.PlayersMax, ' people') AS MaxPlayers
	FROM Boardgames AS b
	JOIN Publishers AS p
	ON p.Id=b.PublisherId
	JOIN Categories AS cat
	ON cat.Id=b.CategoryId
	JOIN PlayersRanges AS pr
	ON b.Id=pr.Id
	WHERE cat.Name = @category
	ORDER BY PublisherName, YearPublished DESC





