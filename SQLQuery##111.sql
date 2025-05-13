-- 1. Event Table
CREATE TABLE Event2 (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Date DATE NOT NULL
);


-- 2. Venue Table
CREATE TABLE Venue2 (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Location NVARCHAR(200),
    Capacity INT
);


-- 3. Booking Table
CREATE TABLE Booking2 (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL,
    BookingDate DATE NOT NULL,
    EventId INT NOT NULL,
    VenueId INT NOT NULL,
    FOREIGN KEY (EventId) REFERENCES Event (Id),
    FOREIGN KEY (VenueId) REFERENCES Venue (Id)
);

-- Insert Events
INSERT INTO Event2 (Name, Description, Date) VALUES
('Tech Conference 2025', 'A conference about modern tech trends.', '2025-06-20'),
('Art Expo', 'Display of modern art and creativity.', '2025-07-05'),
('Music Fest', 'Live music performances.', '2025-08-15');


-- Insert Venues
INSERT INTO Venue2 (Name, Location, Capacity) VALUES
('Main Hall', '123 Downtown Ave', 200),
('Open Grounds', '456 Central Park', 500),
('Auditorium A', '789 Campus Way', 150);


-- Insert Bookings (sample linking above entries)
INSERT INTO Booking2 (UserName, BookingDate, EventId, VenueId) VALUES
('johndoe', '2025-05-10', 1, 1),
('janesmith', '2025-05-11', 2, 2),
('alexbrown', '2025-05-12', 3, 3);


-- View all Events
SELECT * FROM Event2;


-- View all Venues
SELECT * FROM Venue2;


-- View all Bookings
SELECT * FROM Booking2;
