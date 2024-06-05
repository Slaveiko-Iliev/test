-- Task 01. DDL

CREATE DATABASE TouristAgency;

GO

USE TouristAgency;

GO

CREATE TABLE Countries (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Destinations (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] VARCHAR(50) NOT NULL
            ,[CountryId] INT FOREIGN KEY REFERENCES Countries (Id) NOT NULL
)

CREATE TABLE Rooms (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Type] VARCHAR(40) NOT NULL
            ,[Price] DECIMAL(18,2) NOT NULL
            ,[BedCount] INT CHECK ([BedCount] BETWEEN 1 AND 10) NOT NULL
)

CREATE TABLE Hotels (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] VARCHAR(50) NOT NULL
            ,[DestinationId] INT FOREIGN KEY REFERENCES Destinations (Id) NOT NULL
)

CREATE TABLE Tourists (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] NVARCHAR(80) NOT NULL
            ,[PhoneNumber] VARCHAR(20) NOT NULL
            ,[Email] VARCHAR(80)
            ,[CountryId] INT FOREIGN KEY REFERENCES [Countries] (Id) NOT NULL
)

CREATE TABLE Bookings (
             [Id] INT PRIMARY KEY IDENTITY
            ,[ArrivalDate] DATETIME2 NOT NULL
            ,[DepartureDate] DATETIME2 NOT NULL
            ,[AdultsCount] INT CHECK ([AdultsCount] BETWEEN 1 AND 10) NOT NULL
            ,[ChildrenCount] INT CHECK ([ChildrenCount] BETWEEN 0 AND 9) NOT NULL
            ,[TouristId] INT FOREIGN KEY REFERENCES [Tourists](Id) NOT NULL
            ,[HotelId] INT FOREIGN KEY REFERENCES [Hotels](Id) NOT NULL
            ,[RoomId] INT FOREIGN KEY REFERENCES [Rooms](Id) NOT NULL
)

CREATE TABLE HotelsRooms (
             [HotelId] INT FOREIGN KEY REFERENCES [Hotels](Id) NOT NULL
             ,[RoomId] INT FOREIGN KEY REFERENCES [Rooms](Id) NOT NULL
             ,PRIMARY KEY ([HotelId],[RoomId])
)


-- Task 02.Insert

INSERT INTO [Tourists]
     VALUES ('John Rivers', '653-551-1555 ', 'john.rivers@example.com', 6)
           ,('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2)
           ,('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3)
           ,('Johan Müller', '322-876-9826', 'j.muller@example.com', 7)
           ,('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6)

INSERT INTO [Bookings]
     VALUES ('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5)
           ,('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3)
           ,('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7)
           ,('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4)
           ,('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6)


-- Task 03.Update

UPDATE [Bookings]
   SET [DepartureDate] = DATEADD(d, 1, [DepartureDate])
 WHERE MONTH([DepartureDate]) = 12 AND YEAR([DepartureDate]) = 2023;

 UPDATE [Tourists]
    SET [Email] = NULL
  WHERE [Email] LIKE '%MA%';


-- Task 04. Delete

DELETE 
  FROM [Bookings]
 WHERE [TouristId] IN (
    SELECT [Id]
  FROM [Tourists]
 WHERE [Name] LIKE '%Smith%'
 )

DELETE
  FROM [Tourists]
 WHERE [Name] LIKE '%Smith%';


-- Task 05. Bookings by Price of Room and Arrival Date

  SELECT FORMAT([ArrivalDate], 'yyyy-MM-dd') AS 'ArrivalDate'
        ,[AdultsCount]
        ,[ChildrenCount]
    FROM [Bookings] AS b 
    JOIN [Rooms] AS r ON b.RoomId = r.Id
ORDER BY [Price] DESC, [ArrivalDate];


-- Task 06. Hotels by Count of Bookings

  SELECT h.Id
        ,h.Name
    FROM [Bookings] AS b  
    JOIN [Rooms] AS r ON r.Id = b.RoomId
    JOIN Hotels as h ON h.Id = b.HotelId
   WHERE b.HotelId
      IN (
  SELECT HotelId
    FROM [HotelsRooms]
   WHERE [RoomId] = 8
)
GROUP BY h.Id, h.Name
ORDER BY COUNT(h.[Id]) DESC

    
-- Task 07. Tourists without Bookings

  SELECT [Id]
        ,[Name]
        ,[PhoneNumber]
    FROM [Tourists]
   WHERE [Id] NOT IN (
  SELECT [TouristId]
    FROM [Bookings]
   )
ORDER BY [Name]


-- Task 08. First 10 Bookings

  SELECT
 TOP(10) h.Name AS [HotelName]
        ,d.Name AS [DestinationName]
        ,c.Name AS [CountryName]
    FROM [Bookings] AS b 
    JOIN [Hotels] AS h ON b.HotelId = h.Id
    JOIN [Destinations] AS d ON d.Id = h.DestinationId
    JOIN [Countries] AS c ON d.CountryId = c.Id
   WHERE [ArrivalDate] < '2023-12-31'
     AND h.Id % 2 = 1
ORDER BY [CountryName], [ArrivalDate]


-- Task 09. Tourists booked in Hotels

  SELECT h.Name AS [HotelName]
        ,r.Price AS [RoomPrice]
    FROM [Bookings] AS b 
    JOIN Hotels AS h ON b.HotelId = h.Id
    JOIN [Rooms] AS r ON r.Id = b.RoomId
    JOIN [Tourists] AS t ON t.Id = b.TouristId
   WHERE t.Name NOT LIKE '%EZ'
ORDER BY r.Price DESC;

-- Task 10. Hotels Revenue

  SELECT [HotelName]
        ,SUM([BookingTotal])
    FROM 
         (
  SELECT h.Name AS [HotelName]
        ,DATEDIFF(DD, [ArrivalDate], [DepartureDate]) * r.Price AS [BookingTotal]
    FROM [Bookings] AS b 
    JOIN [Hotels] AS h ON b.HotelId = h.Id
    JOIN [Rooms] AS r ON b.RoomId = r.Id
    )
      AS [BookingTotalQuery]
GROUP BY [HotelName]
ORDER BY SUM([BookingTotal]) DESC;


-- Task 11. Rooms with Tourists

GO

CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR(40))
  RETURNS TABLE
             AS
         RETURN (
                SELECT [Type]
                  FROM [Bookings] AS b
                  JOIN [Rooms] AS r ON b.RoomId = r.Id
              GROUP BY Type
                 WHERE r.TYPE = @name
         )
             
