-- DROP TABLE IF EXISTS Employer
-- DROP TABLE IF EXISTS JobAd
-- DROP TABLE IF EXISTS JobSeeker
-- DROP TABLE IF EXISTS Sector
-- DROP TABLE IF EXISTS License

-- CREATE TABLE Employer (Id INT PRIMARY KEY IDENTITY(1,1), [Name] VARCHAR(50))
-- CREATE TABLE License (Id INT PRIMARY KEY IDENTITY(1,1), License_Type VARCHAR(50))
-- CREATE TABLE Sector (Id INT PRIMARY KEY IDENTITY(1,1), Sector_Type VARCHAR(50))
-- CREATE TABLE JobAd (Id INT PRIMARY KEY IDENTITY(1,1), Location VARCHAR(50), License_Id int, YearsOfExperience int, Sector_Id int, Employer_Id int)
-- CREATE TABLE JobSeeker (Id INT PRIMARY KEY IDENTITY(1,1), FirstName VARCHAR(50), LastName VARCHAR(50), YearBorn Date, StreetAdress VARCHAR(100), PhoneNumber VARCHAR(20),Email VARCHAR(100),Location VARCHAR(50),License_Id int, Sector_Id int, YearsOfExperience int)

-- DML STARTS HERE
-- INSERT INTO LICENSE (License_Type)
-- VALUES('No license'),
-- ('Drivers License B'),
-- ('Drivers License C'),
-- ('Forklift License A'),
-- ('Forklift License B'),
-- ('OSHA Safety Certificate'),
-- ('Certified Welder'),
-- ('Food Saftey')

-- INSERT INTO Employer ([Name]) VALUES 
-- ('Microsoft'),
-- ('Apple'),
-- ('ICA'),
-- ('Welders sanctuary'),
-- ('Blue bird taxi')

-- INSERT INTO Sector (Sector_Type) VALUES
-- ('IT'),
-- ('groceries'),
-- ('Taxi'),
-- ('Welder'),
-- ('Bus driver'),
-- ('Maid')

-- INSERT INTO JobAd ([Location],License_Id, YearsOfExperience, Sector_Id, Employer_Id)
-- VALUES ('Silicon Valley', 1,3,1,1),
-- ('Borås',1,1,1,2),
-- ('Stockholm',6,1,2,3)

-- INSERT INTO JobSeeker (FirstName, LastName, YearBorn, StreetAdress, PhoneNumber, Email, [Location], License_Id, Sector_Id, YearsOfExperience)
-- VALUES
-- ('Carl','Åfalk','1997-07-14', 'Brämhultsvägen 42', '0761155123','carl@mail.com', 'Borås', 1, 1, 1),
-- ('Bill','Gates', '1959-02-20', 'BGroad 9', '084125124', 'billgates@gmail.com','New York', 4,3,1),
-- ('Stefan','Löfven','1954-10-12','Kungsgatan 2', '0714425217', 'steffe@hotmail.se', 'Stockholm',5,3,2),
-- ('Oscar', 'Stensson', '1992-03-10', 'Allegatan 20', '0752528182','StenssonOscar@gmail.com', 'Egmont',1,1,1)

-- CREATE OR ALTER PROCEDURE Create_JobSeeker2
--         @FirstName VARCHAR(50),
--         @LastName VARCHAR(50),
--         @YearBorn DATE,
--         @StreetAdress VARCHAR(100),
--         @PhoneNumber VARCHAR(50),
--         @Email VARCHAR(100),
--         @Location VARCHAR(50),
--         @License_Id INT,
--         @Sector_Id INT,
--         @YearsOfExperience INT
-- AS
-- BEGIN
--     INSERT INTO JobSeeker (FirstName, LastName, YearBorn, StreetAdress, PhoneNumber, Email, [Location], License_Id, Sector_Id, YearsOfExperience)
--     VALUES (@FirstName, @LastName, @YearBorn, @StreetAdress, @PhoneNumber, @Email, @Location, @License_Id, @Sector_Id, @YearsOfExperience)
--     RETURN
-- END
-- GO

-- CREATE OR ALTER PROCEDURE Get_JobSeeker2
-- AS
-- BEGIN
--     SELECT FirstName, LastName, YearBorn, StreetAdress, PhoneNumber, Email,[Location] ,l.License_Type, s.Sector_Type, YearsOfExperience FROM JobSeeker AS j
--     INNER JOIN License AS l ON l.Id=j.License_Id
--     INNER JOIN Sector AS s ON s.Id=j.Sector_Id
--     RETURN
-- END
-- GO



-- CREATE OR ALTER PROCEDURE Create_JobAd2
--         @Location VARCHAR(50),
--         @License_Id INT,
--         @YearsOfExperience INT,
--         @Sector_Id INT,
--         @Employer_Id INT
-- AS
-- BEGIN
--     INSERT INTO JobAd ([Location], License_Id, YearsOfExperience, Sector_Id, Employer_Id) 
--     VALUES(@Location,@License_Id,@YearsOfExperience,@Sector_Id,@Employer_Id)
--     RETURN
-- END
-- GO

-- CREATE OR ALTER PROCEDURE Get_JobAd2
-- AS
-- BEGIN
--     SELECT  e.Name,j.Location, l.License_Type, j.YearsOfExperience, s.Sector_Type FROM JobAd AS j
--     INNER JOIN License AS l ON l.Id=j.License_Id
--     INNER JOIN Sector AS s ON s.Id=j.Sector_Id
--     INNER JOIN Employer AS e ON e.Id=j.Employer_Id
--     RETURN
-- END
-- GO

-- EXEC Create_JobAd2 'borås',1,3,1,2
-- SELECT * FROM JobAdä


