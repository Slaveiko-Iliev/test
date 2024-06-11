CREATE DATABASE RailwaysDb;

GO

USE RailwaysDb;

GO

CREATE TABLE Passengers (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE Towns (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE [RailwayStations] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Name] VARCHAR(50) NOT NULL
            ,[TownId] INT FOREIGN KEY REFERENCES [Towns](Id) NOT NULL
)

CREATE TABLE [Trains] (
             [Id] INT  PRIMARY KEY IDENTITY
            ,[HourOfDeparture] VARCHAR(5) NOT NULL
            ,[HourOfArrival] VARCHAR(5) NOT NULL
            ,[DepartureTownId] INT FOREIGN KEY REFERENCES [Towns](Id) NOT NULL
            ,[ArrivalTownId] INT FOREIGN KEY REFERENCES [Towns](Id) NOT NULL
)

CREATE TABLE [TrainsRailwayStations] (
             [TrainId] INT FOREIGN KEY REFERENCES [Trains](Id) NOT NULL
            ,[RailwayStationId] INT FOREIGN KEY REFERENCES [RailwayStations](Id) NOT NULL
            ,PRIMARY KEY ([TrainId], [RailwayStationId])
)

CREATE TABLE [MaintenanceRecords] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[DateOfMaintenance] DATE NOT NULL
            ,[Details] VARCHAR(2000) NOT NULL
            ,[TrainId] INT FOREIGN KEY REFERENCES [Trains](Id) NOT NULL
)

CREATE TABLE [Tickets] (
             [Id] INT PRIMARY KEY IDENTITY
            ,[Price] DECIMAL(18,2) NOT NULL
            ,[DateOfDeparture] DATE NOT NULL
            ,[DateOfArrival] DATE NOT NULL
            ,[TrainId] INT FOREIGN KEY REFERENCES [Trains](Id) NOT NULL
            ,[PassengerId] INT FOREIGN KEY REFERENCES [Passengers](Id) NOT NULL
)



-- Task 02. Insert

INSERT INTO [Trains]
     VALUES ('07:00', '19:00', 1, 3)
           ,('08:30', '20:30', 5, 6)
           ,('09:00', '21:00', 4, 8)
           ,('06:45', '03:55', 27, 7)
           ,('10:15', '12:15', 15, 5);

INSERT INTO [TrainsRailwayStations]
     VALUES (36, 1)
           ,(36, 4)
           ,(36, 31)
           ,(36, 57)
           ,(36, 7)
           ,(37, 13)
           ,(37, 54)
           ,(37, 60)
           ,(37, 16)
           ,(38, 10)
           ,(38, 50)
           ,(38, 52)
           ,(38, 22)
           ,(39, 68)
           ,(39, 3)
           ,(39, 31)
           ,(39, 19)
           ,(40, 41)
           ,(40, 7)
           ,(40, 52)
           ,(40, 13)

INSERT INTO [Tickets]
     VALUES (90.00, '2023-12-01', '2023-12-01', 36, 1)
           ,(115.00, '2023-08-02', '2023-08-02', 37, 2)
           ,(160.00, '2023-08-03', '2023-08-03', 38, 3)
           ,(255.00, '2023-09-01', '2023-09-02', 39, 21)
           ,(95.00, '2023-09-02', '2023-09-03', 40, 22)


-- Task 03. Update

UPDATE [Tickets]
   SET [DateOfDeparture] = DATEADD(d, 7, [DateOfDeparture])
      ,[DateOfArrival] = DATEADD(d, 7, [DateOfArrival])
 WHERE [DateOfDeparture] > '2023-10-31';


-- Task 04. Delete

 DELETE
   FROM [Tickets]
  WHERE [TrainId] IN (
              SELECT t.Id
                FROM [Trains] AS t 
                JOIN [Towns] AS tow ON t.DepartureTownId = tow.Id
               WHERE tow.Name = 'Berlin'
  )

 DELETE
   FROM [MaintenanceRecords]
  WHERE [TrainId] IN (
              SELECT t.Id
                FROM [Trains] AS t 
                JOIN [Towns] AS tow ON t.DepartureTownId = tow.Id
               WHERE tow.Name = 'Berlin'
  )

   DELETE
   FROM [TrainsRailwayStations]
  WHERE [TrainId] IN (
              SELECT t.Id
                FROM [Trains] AS t 
                JOIN [Towns] AS tow ON t.DepartureTownId = tow.Id
               WHERE tow.Name = 'Berlin'
  )

DELETE
  FROM [Trains]
 WHERE [Id] IN (
        SELECT t.Id
          FROM [Trains] AS t 
          JOIN [Towns] AS tow ON t.DepartureTownId = tow.Id
         WHERE tow.Name = 'Berlin'


 )


-- Task 05. Tickets by Price and Date Departure

    SELECT [DateOfDeparture]
          ,[Price] AS [TicketPrice]
      FROM [Tickets]
  ORDER BY [Price], [DateOfDeparture] DESC;


-- Task 06. Passengers with their Tickets

  SELECT p.Name AS [PassengerName]
        ,t.Price AS [TicketPrice]
        ,[DateOfDeparture]
        ,[TrainId]
    FROM [Tickets] AS t 
    JOIN [Passengers] AS p ON t.PassengerId = p.Id
ORDER BY [TicketPrice] DESC, [PassengerName];


-- Task 07. Railway Stations without Passing Trains

  SELECT t.Name AS [Town]
        ,r.Name AS [RailwayStation]
    FROM [RailwayStations] AS r 
    JOIN [Towns] AS t ON r.TownId = t.Id
   WHERE r.Id NOT IN (
              SELECT [RailwayStationId]
                FROM [TrainsRailwayStations]
   )
ORDER BY [Town], [RailwayStation];


-- Task 08. First 3 Trains Between 08:00 and 08:59

  SELECT 
  TOP(3) [TrainId]
        ,[HourOfDeparture]
        ,ti.Price AS [TicketPrice]
        ,tow.Name AS [Destination]
    FROM [Trains] AS tr 
    JOIN [Tickets] AS ti ON tr.Id = ti.TrainId
    JOIN [Towns] AS tow ON tr.ArrivalTownId = tow.Id
   WHERE [HourOfDeparture] LIKE '08:%' AND [Price] > 50
ORDER BY [TicketPrice], [HourOfDeparture];


-- Task 09. Count of Passengers Paid More Than Average

  SELECT tow.Name AS [TownName]
        ,COUNT(ti.Id) AS [PassengersCount]
    FROM [Tickets] as ti 
    JOIN [Trains] AS tr ON ti.TrainId = tr.Id
    JOIN [Towns] AS tow ON tr.ArrivalTownId = tow.Id
   WHERE [Price] > 76.99
GROUP BY tow.Name
ORDER BY tow.Name;