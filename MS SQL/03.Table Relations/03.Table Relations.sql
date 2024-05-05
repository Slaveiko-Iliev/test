-- Task 01. One-To-One Relationship

CREATE TABLE [Persons] (
             [PersonID] INT IDENTITY,
             [FirstName] VARCHAR (50) NOT NULL,
             [Salary] DECIMAL (8,0),
             [PassportID] INT NOT NULL
);

ALTER TABLE [Persons] ADD PRIMARY KEY (PersonID);

CREATE TABLE [Passports] (
             [PassportID] INT PRIMARY KEY IDENTITY (101,1),
             [PassportNumber] VARCHAR(10) NOT NULL
);

   ALTER TABLE [Persons]
ADD CONSTRAINT FK_Persons_Passports
   FOREIGN KEY (PassportID) REFERENCES [Passports](PassportID);

INSERT INTO [Passports] (PassportNumber)
     VALUES ('N34FG21B')
            ,('K65LO4R7')
            ,('ZE657QP2');

INSERT INTO [Persons] (FirstName, Salary, PassportID)
     VALUES ('Roberto', 43300, 102)
            ,('Tom', 56100, 103)
            ,('Yana',60200, 101);


-- Task 02. One-To-Many Relationship

CREATE TABLE [Models] (
             [ModelID] INT PRIMARY KEY IDENTITY (101,1)
             , [Name] VARCHAR (20) NOT NULL
             , [ManufacturerID] INT NOT NULL
)

CREATE TABLE [Manufacturers] (
             [ManufacturerID] INT PRIMARY KEY IDENTITY
             , [Name] VARCHAR (20) NOT NULL
             , [EstablishedOn] DATE
)

   ALTER TABLE [Models]
ADD CONSTRAINT FK_Models_Manufacturers
   FOREIGN KEY (ManufacturerID) REFERENCES [Manufacturers](ManufacturerID);

INSERT INTO [Manufacturers] ([Name], EstablishedOn)
     VALUES ('BMW', '1916-03-07')
            ,('Tesla', '2003-01-01')
            ,('Lada', '1966-05-01')

INSERT INTO [Models] ([Name], ManufacturerID)
     VALUES ('X1', 1)
            ,('i6', 1)
            ,('Model S', 2)
            ,('Model X', 2)
            ,('Model 3', 2)
            ,('Nova', 3);


-- Task 03. Many-To-Many Relationship

CREATE TABLE [Students] (
             [StudentID] INT PRIMARY KEY IDENTITY
             , [Name] VARCHAR (50) NOT NULL
);

CREATE TABLE [Exams] (
             [ExamID] INT PRIMARY KEY IDENTITY (101,1)
             , [Name]  VARCHAR (50) NOT NULL
);

  CREATE TABLE [StudentsExams] (
               [StudentID] INT NOT NULL
               , [ExamID] INT NOT NULL
);

    ALTER TABLE [StudentsExams]
 ADD CONSTRAINT PK_StudentId_ExamID
    PRIMARY KEY ([StudentID], [ExamID]);

    ALTER TABLE [StudentsExams]
 ADD CONSTRAINT FK_StudentsExams_Students
    FOREIGN KEY (StudentID) REFERENCES [Students](StudentID);

        ALTER TABLE [StudentsExams]
 ADD CONSTRAINT FK_StudentsExams_Exams
    FOREIGN KEY (ExamID) REFERENCES [Exams](ExamID);

INSERT INTO [Students] ([Name])
     VALUES ('Mila')
            , ('Toni')
            , ('Ron');

INSERT INTO [Exams] ([Name])
     VALUES ('SpringMVC')
            , ('Neo4j')
            , ('Oracle 11g');

INSERT INTO [StudentsExams] ([StudentID], [ExamID])
     VALUES (1, 101)
            , (1, 102)
            , (2, 101);

            
-- Task 04. Self-Referencing

CREATE TABLE [Teachers] (
             [TeacherID] INT PRIMARY KEY IDENTITY (101,1)
             , [Name] VARCHAR (50) NOT NULL
             , [ManagerId] INT FOREIGN KEY REFERENCES [Teachers](TeacherID)
);

INSERT INTO [Teachers] ([Name], [ManagerId])
     VALUES ('John', NULL),
            ('Maya', 106),
            ('Silvia', 106),
            ('Ted', 105),
            ('Mark', 101),
            ('Greta', 101);

SELECT * FROM Teachers;

-------------------- Bullsized 
-- CREATE TABLE Teachers
-- (
-- 	TeacherID INT PRIMARY KEY IDENTITY(101, 1) NOT NULL,
-- 	[Name] VARCHAR(30) NOT NULL,
-- 	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
-- )

-- INSERT INTO Teachers VALUES
-- ('John', NULL),
-- ('Maya', 106),
-- ('Silvia', 106),
-- ('Ted', 105),
-- ('Mark', 101),
-- ('Greta', 101)

-- SELECT * FROM Teachers


-- Task 05. Online Store Database

CREATE TABLE [ItemTypes]
(
             [ItemTypeID] INT PRIMARY KEY IDENTITY
             , [Name] VARCHAR (20)
);

CREATE TABLE [Items]
(
             [ItemID] INT PRIMARY KEY IDENTITY
             , [Name] VARCHAR (30)
             , [ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes](ItemTypeID)
);

CREATE TABLE [Cities]
(
             [CityID] INT PRIMARY KEY IDENTITY
             , [Name] VARCHAR (20)
);

CREATE TABLE [Customers]
(
             [CustomerID] INT PRIMARY KEY IDENTITY
             , [Name] VARCHAR (30)
             , [Birthday] DATE
             , [CityID] INT FOREIGN KEY REFERENCES [Cities](CityID)
);

CREATE TABLE [Orders]
(
             [OrderID] INT PRIMARY KEY IDENTITY
             , [CustomerID] INT NOT NULL FOREIGN KEY REFERENCES [Customers](CustomerID)
);

CREATE TABLE [OrderItems]
(
             [OrderID] INT
             , [ItemID] INT
             , CONSTRAINT PK_OrderItems PRIMARY KEY ([OrderID], [ItemID])
             , CONSTRAINT FK_OrderItems_Orders
             FOREIGN KEY (OrderID) REFERENCES [Orders](OrderID)
             , CONSTRAINT FK_OrderItems_Items
             FOREIGN KEY (ItemID) REFERENCES [Items](ItemID)
);


-- Task 06. University Database

CREATE TABLE [Majors]
(
             [MajorID] INT PRIMARY KEY IDENTITY
             ,[Name] VARCHAR (20)
);

CREATE TABLE [Students2]
(
             [StudentID] INT PRIMARY KEY IDENTITY
             , [StudentNumber] INT NOT NULL
             , [StudenrName] VARCHAR (50)
             , [MajorID] INT FOREIGN KEY REFERENCES [Majors](MajorID)
);

CREATE TABLE [Subjects]
(
             [SubjectID] INT PRIMARY KEY IDENTITY
             , [SubjectName] VARCHAR (20)
);

CREATE TABLE [Agenda]
(
             [StudentID] INT
             , [SubjectID] INT
             , CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID)
             , CONSTRAINT FK_Agenda_Students2
             FOREIGN KEY (StudentID) REFERENCES [Students2](StudentID)
             , CONSTRAINT FK_Agenda_Subjects
             FOREIGN KEY (SubjectID) REFERENCES [Subjects](SubjectID)
);

CREATE TABLE [Payments]
             (
                [PaumentID]  INT PRIMARY KEY IDENTITY
                , [PaymentDate] DATE NOT NULL
                , [PaymentAmount] DECIMAL (5,2) NOT NULL
                , [StudentID] INT NOT NULL
                , CONSTRAINT FK_Payments_Students
                FOREIGN KEY (StudentID) REFERENCES [Students](StudentID)
             );


-- Task 09. *Peaks in Rila

  SELECT (m.MountainRange), (p.PeakName), (p.Elevation)
    FROM [Mountains] AS m
    JOIN [Peaks] AS p ON (p.MountainId) = (m.Id)
   WHERE (m.MountainRange) = 'Rila'
ORDER BY p.Elevation DESC;