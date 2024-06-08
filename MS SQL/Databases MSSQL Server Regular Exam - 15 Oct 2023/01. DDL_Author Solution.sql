---Task 1: DDL
CREATE TABLE Countries(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
);

CREATE TABLE Destinations(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
);

CREATE TABLE Rooms(
Id INT PRIMARY KEY IDENTITY,
[Type] VARCHAR(40) NOT NULL,
Price DECIMAL(18,2) NOT NULL,
BedCount INT NOT NULL
	CHECK(BedCount >0 AND BedCount <=10)
);

CREATE TABLE Hotels(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
DestinationId INT NOT NULL FOREIGN KEY REFERENCES Destinations(Id)
);

CREATE TABLE Tourists(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(80) NOT NULL,
PhoneNumber VARCHAR(20) NOT NULL,
Email VARCHAR(80),
CountryId INT NOT NULL FOREIGN KEY REFERENCES Countries(Id)
);

CREATE TABLE Bookings(
Id INT PRIMARY KEY IDENTITY,
ArrivalDate DATETIME2 NOT NULL,
DepartureDate DATETIME2 NOT NULL,
AdultsCount INT NOT NULL
	CHECK(AdultsCount >= 1 AND AdultsCount <= 10),
ChildrenCount INT NOT NULL
	CHECK(ChildrenCount >=0 AND ChildrenCount <= 9),
TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id),
HotelId INT NOT NULL FOREIGN KEY REFERENCES Hotels(Id),
RoomId INT NOT NULL FOREIGN KEY REFERENCES Rooms(Id)
);

CREATE TABLE HotelsRooms(
HotelId INT NOT NULL,
RoomId INT NOT NULL,
CONSTRAINT PK_HotelsRooms PRIMARY KEY (HotelId, RoomId),
CONSTRAINT FK_HotelsRooms_Hotels FOREIGN KEY (HotelId) REFERENCES Hotels(Id),
CONSTRAINT FK_HotelsRooms_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
);

---Task 2: Insert

INSERT INTO Tourists ([Name], PhoneNumber, Email, CountryId)
VALUES
    ('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
    ('Adeline Aglaé', '122-654-8726', 'adeline.algae@example.com', 2),
    ('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
    ('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
    ('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6);

INSERT INTO Bookings (ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
VALUES
    ('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
    ('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
    ('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
    ('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
    ('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6);

---Task 3: Update

UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
WHERE ArrivalDate >= '2023-12-01' AND ArrivalDate <= '2023-12-31';

UPDATE Tourists
SET Email = NULL
WHERE Name LIKE '%MA%';


---Task 4: Delete
BEGIN TRANSACTION

DECLARE @TouristIdsToDelete TABLE (Id INT);

INSERT INTO @TouristIdsToDelete (Id)
SELECT Id
FROM Tourists
WHERE [Name] LIKE '%Smith%';

DELETE FROM Bookings
WHERE TouristId IN(SELECT Id FROM @TouristIdsToDelete);

DELETE FROM Tourists
WHERE Id IN (SELECT Id FROM @TouristIdsToDelete);

COMMIT;

---Task 5: Bookings by Price of Room and Arrival Date

---Variant 1:
SELECT CONVERT(VARCHAR(10), ArrivalDate, 120) AS FormattedArrivalDate, AdultsCount, ChildrenCount
FROM Bookings b
JOIN Rooms r ON b.RoomId = r.Id
ORDER BY r.Price DESC, b.ArrivalDate ASC;

---Variant 2:

SELECT FORMAT(ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate, AdultsCount, ChildrenCount
FROM Bookings AS b
JOIN Rooms AS r ON r.Id = b.RoomId
ORDER BY r.Price DESC, b.ArrivalDate

---Task 6: Hotels by Count of Bookings
SELECT H.Id, H.Name
FROM Hotels H
INNER JOIN HotelsRooms HR ON H.Id = HR.HotelId
INNER JOIN Rooms R ON HR.RoomId = R.Id
INNER JOIN Bookings B ON H.Id = B.HotelId AND R.[Type] = 'VIP Apartment'
GROUP BY H.Id, H.Name
ORDER BY COUNT(*) DESC;

---Task 7: Tourists without Bookings
SELECT T.Id, T.Name, T.PhoneNumber
FROM Tourists T
LEFT JOIN Bookings B ON T.Id = B.TouristId
WHERE B.TouristId IS NULL
ORDER BY T.Name ASC;

---Task 8: First 10 Bookings
SELECT TOP 10
    H.Name AS HotelName,
    Dst.Name AS DestinationName,
    HC.Name AS HotelCountryName
FROM
    Bookings AS B
JOIN
    Tourists AS T ON B.TouristId = T.Id
JOIN
    Hotels AS H ON B.HotelId = H.Id
JOIN
    Destinations AS Dst ON H.DestinationId = Dst.Id
JOIN
    Countries AS HC ON Dst.CountryId = HC.Id
WHERE
    B.ArrivalDate < '2023-12-31'
    AND
    B.HotelId % 2 <> 0  -- Select hotels with odd IDs
ORDER BY
    HC.Name ASC,
    B.ArrivalDate ASC;

---Task 9: Tourists booked in Hotels
SELECT
    H.Name AS HotelName,
    R.Price AS RoomPrice
FROM
    Tourists AS T
JOIN
    Bookings AS B ON T.Id = B.TouristId
JOIN
    Hotels AS H ON B.HotelId = H.Id
JOIN
    Rooms AS R ON B.RoomId = R.Id
WHERE
    RIGHT(T.Name, 2) != 'EZ'  -- Select tourists whose names do not end in "EZ"
ORDER BY
    R.Price DESC;

---Task 10: Hotels by Turover

SELECT H.Name AS HotelName, SUM(R.Price * DATEDIFF(day, B.ArrivalDate, B.DepartureDate)) AS TotalBookingPrice
FROM Bookings AS B
JOIN Hotels AS H ON B.HotelId = H.Id
JOIN Rooms AS R ON B.RoomId = R.Id
GROUP BY H.[Name]
ORDER BY TotalBookingPrice DESC;


---Task 11: Rooms with Tourists
-- Create the function
CREATE FUNCTION udf_RoomsWithTourists (@roomType NVARCHAR(30))
RETURNS INT
AS
BEGIN
    DECLARE @TotalTourists INT;

    -- Calculate the total number of tourists for the specified room type
    SELECT @TotalTourists = SUM(AdultsCount + ChildrenCount)
    FROM Bookings AS B
    JOIN Rooms AS R ON B.RoomId = R.Id
    WHERE R.[Type] = @roomType;

    -- Return the total number of tourists
    RETURN @TotalTourists;
END;

SELECT dbo.udf_RoomsWithTourists ('VIP Apartment');

select * from Bookings


---Task 12:

-- Create the stored procedure
CREATE PROCEDURE usp_SearchByCountry
    @country NVARCHAR(50)
AS
BEGIN
    -- Declare variables
    DECLARE @CountryId INT;

    -- Get the CountryId for the specified country name
    SELECT @CountryId = Id
    FROM Countries
    WHERE [Name] = @country;

    -- Print the header
    PRINT 'Name | PhoneNumber | Email | CountOfBookings';

    -- Select and print tourist information for the specified country
    SELECT
        T.Name,
        T.PhoneNumber,
        T.Email,
        COUNT(B.Id) AS CountOfBookings
    FROM
        Tourists AS T
    INNER JOIN
        Bookings AS B ON T.Id = B.TouristId
    WHERE
        T.CountryId = @CountryId
    GROUP BY
        T.Name,
        T.PhoneNumber,
        T.Email
    ORDER BY
        T.Name ASC,
        CountOfBookings DESC;
END;

EXEC usp_SearchByCountry 'Greece';
