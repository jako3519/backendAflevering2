use ExperienceDB;
EXEC sp_columns 'Providers'; -- Change 'Providers' to any table name

SELECT * FROM Providers;
SELECT * FROM Experiences;
SELECT * FROM Discounts;
SELECT * FROM SharedExperiences;
SELECT * FROM Guests;
SELECT * FROM Reservations;
SELECT * FROM GuestSharedExperiences;
