--Task 08--

CREATE TABLE Users (
    Id BIGINT PRIMARY KEY IDENTITY (1,1),
    Username VARCHAR (30) NOT NULL,
    Password VARCHAR (26) NOT NULL,
    ProfilePicture VARBINARY,
    CHECK (ProfilePicture <= 900000),
    LastLoginTime DATETIME2,
    IsDeleted VARCHAR (5),
    CHECK (IsDeleted = 'true' or IsDeleted = 'false')
);

INSERT INTO Users (Username, Password)
    VALUES ('Misho', '12366'),
            ('Pesho', '13665'),
            ('Ivan', 'a666bc'),
            ('Niki', 'l666o'),
            ('Lili', '86669')

SELECT * FROM Users

-- Task 09 --

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07DD158AF2

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Complex
    PRIMARY KEY (Id, Username)

-- Task 10 --


ALTER TABLE Users
    ADD CONSTRAINT CHK_PasswordLength 
    CHECK(LEN(Password) > 5);



-- Task 11 --

ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT CURRENT_TIMESTAMP FOR LastLoginTime;

-- Task 12 --



-- Task 13 --

CREATE DATABASE Movies

CREATE TABLE Directors (
    Id INT IDENTITY PRIMARY KEY,
    DirectorName NVARCHAR(200) NOT NULL,
    Notes NVARCHAR (MAX)
)

CREATE TABLE Genres (
    Id INT IDENTITY PRIMARY KEY,
    GenreName NVARCHAR(200) NOT NULL,
    Notes NVARCHAR (MAX)
)

CREATE TABLE Categories (
    Id INT IDENTITY PRIMARY KEY,
    CategoryName NVARCHAR(200) NOT NULL,
    Notes NVARCHAR (MAX)
)

CREATE TABLE Movies (
    Id INT IDENTITY PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    DirectorId INT NOT NULL,
    CopyrightYear INT,
    Length INT,
    GenreId INT NOT NULL,
    CategoryId INT NOT NULL,
    Rating INT,
    Notes NVARCHAR (MAX)
)

ALTER TABLE Movies
ADD CONSTRAINT FK_Movies_Directors FOREIGN KEY (DirectorId)
REFERENCES Directors (Id);

ALTER TABLE Movies
ADD CONSTRAINT FK_Movies_Genres FOREIGN KEY (GenreId)
REFERENCES Genres (Id);

ALTER TABLE Movies
ADD CONSTRAINT FK_Movies_Categories FOREIGN KEY (CategoryId)
REFERENCES Categories (Id);

INSERT INTO Directors (DirectorName)
VALUES ('Akira Kurosawa'),
        ('Michel Gondry'),
        ('Michael Haneke'),
        ('Pier Paolo Pasolini'),
        ('Robert Bresson')

INSERT INTO Genres (GenreName)
VALUES ('Manga'),
        ('Action'),
        ('Thriller'),
        ('Fantasy'),
        ('Family')

INSERT INTO Categories (CategoryName)
VALUES ('A'),
        ('B'),
        ('C'),
        ('D'),
        ('E')

INSERT INTO Movies (Title, DirectorId, Length, GenreId, CategoryId)
VALUES ('The Green Mile', 1, 3, 3, 2),
        ('Cinderella', 2,2,1,1),
        ('Gladiator',3,2,5,4),
        ('Men in Black',3,2,5,4),
        ('Titanic',3,2,5,4)


SELECT * FROM Movies

--Task 14--
 
CREATE DATABASE CarRental;

CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY (1,1),
    CategoryName VARCHAR (10) NOT NULL,
    DailyRate DECIMAL (4,2),
    WeeklyRate DECIMAL (5,2),
    MonthlyRate DECIMAL (5,2),
    WeekendRate DECIMAL (4,2)
    )

CREATE TABLE Cars (
    Id INT PRIMARY KEY IDENTITY (1,1),
    PlateNumber VARCHAR (8) NOT NULL,
    Manufacturer VARCHAR (10) NOT NULL,
    Model VARCHAR (10) NOT NULL,
    CarYear INT,
    CategoryId INT FOREIGN KEY REFERENCES Categories (Id),
    Doors INT,
    Picture VARBINARY (MAX),
    Condition VARCHAR (10),
    Available VARCHAR (3) NOT NULL,
    CHECK (Available = 'yes' OR Available = 'no')
    )

CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY (1,1),
    FirstName VARCHAR (50) NOT NULL,
    LastName VARCHAR (50) NOT NULL,
    Title VARCHAR (20) NOT NULL,
    Notes  VARCHAR (50)
    )   

CREATE TABLE Customers (
    Id INT PRIMARY KEY IDENTITY (1,1),
    DriverLicenceNumber INT NOT NULL,
    FullName VARCHAR (50) NOT NULL,
    Address VARCHAR (150) NOT NULL,
    City VARCHAR (10) NOT NULL,
    ZIPCode INT NOT NULL,
    Notes VARCHAR (200)
    )

CREATE TABLE RentalOrders (
    Id INT PRIMARY KEY IDENTITY (1,1),
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
    CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
    CarId INT FOREIGN KEY REFERENCES Cars(Id),
    TankLevel INT NOT NULL,
    KilometrageStart INT NOT NULL,
    KilometrageEnd INT NOT NULL,
    TotalKilometrage INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    TotalDays INT NOT NULL,
    RateApplied VARCHAR (10),
    TaxRate DECIMAL (5,2),
    OrderStatus VARCHAR(8),
    Notes VARCHAR (MAX)
    )

INSERT INTO Categories (CategoryName)
VALUES ('1'),
        ('2'),
        ('3')

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CategoryId, Available)
VALUES ('CB7623HB', 'Ford', 'Fiesta', 1, 'yes'),
        ('CB7623HB', 'Ford', 'Fiesta', 2, 'yes'),
        ('CB7623HB', 'Ford', 'Fiesta', 3, 'yes')

INSERT INTO Employees (FirstName, LastName, Title)
VALUES ('Petar', 'Ford', 'Something'),
        ('Petar', 'Ivanov', 'Something'),
        ('Petar', 'Petrov', 'Something')

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode)
VALUES (456892457, 'Petar Ford', 'Somewhere', 'Sofia', 1345),
(456892457, 'Petar Ford', 'Somewhere', 'Sofia', 1345),
(456892457, 'Petar Ford', 'Somewhere', 'Sofia', 1345)

INSERT into RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays)
    VALUES (1, 2, 3, 30, 2135, 2223, 45, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1),
            (1, 2, 3, 30, 2135, 2223, 45, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1),
            (1, 2, 3, 30, 2135, 2223, 45, CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, 1)

-- Task 15 Hotel Database --

CREATE DATABASE Hotel;

CREATE TABLE Employees (
    Id INT IDENTITY PRIMARY KEY ,
    FirstName VARCHAR (50) NOT NULL,
    LastName VARCHAR (50) NOT NULL,
    Title VARCHAR (15),
    Notes VARCHAR (MAX)
)

CREATE TABLE Customers (
    AccountNumber INT IDENTITY PRIMARY KEY,
    FirstName VARCHAR (50) NOT NULL,
    LastName VARCHAR (50) NOT NULL,
    PhoneNumber,
    EmergencyName,
    EmergencyNumber,
    Notes
 )

CREATE TABLE RoomStatus (
    RoomStatus VARCHAR (50) NOT NULL,
    Notes
    )
    
CREATE TABLE RoomTypes (
    RoomType VARCHAR (50) NOT NULL,
    Notes
    )

CREATE TABLE BedTypes (
    BedType VARCHAR (50) NOT NULL,
    Notes
    )
CREATE TABLE Rooms (
    RoomNumber VARCHAR (50) NOT NULL,
    RoomType,
    BedType,
    Rate,
    RoomStatus,
    Notes
    )

CREATE TABLE Payments (
    Id,
    EmployeeId,
    PaymentDate,
    AccountNumber,
    FirstDateOccupied,
    LastDateOccupied,
    TotalDays,
    AmountCharged,
    TaxRate,
    TaxAmount,
    PaymentTotal,
    Notes
    )

CREATE TABLE Occupancies (
    Id,
    EmployeeId,
    DateOccupied,
    AccountNumber,
    RoomNumber,
    RateApplied,
    PhoneCharge,
    Notes
    )

