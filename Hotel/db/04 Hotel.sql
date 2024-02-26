-- Procedure to insert a new hotel
CREATE PROCEDURE InsertHotel
    @Nombre NVARCHAR(100),
    @Direccion NVARCHAR(200),
    @Estado BIT,
    @Telefono NVARCHAR(15),
    @IdUsuarioResponsable INT
AS
BEGIN
    INSERT INTO Hotel (Nombre, Direccion, Estado, Telefono, IdUsuarioResponsable)
    VALUES (@Nombre, @Direccion, @Estado, @Telefono, @IdUsuarioResponsable)
END
GO

-- Procedure to update an existing hotel
CREATE PROCEDURE UpdateHotel
    @IdHotel INT,
    @Nombre NVARCHAR(100),
    @Direccion NVARCHAR(200),
    @Estado BIT,
    @Telefono NVARCHAR(15),
    @IdUsuarioResponsable INT
AS
BEGIN
    UPDATE Hotel
    SET Nombre = @Nombre,
        Direccion = @Direccion,
        Estado = @Estado,
        Telefono = @Telefono,
        IdUsuarioResponsable = @IdUsuarioResponsable
    WHERE IdHotel = @IdHotel
END
GO

-- Procedure to delete a hotel by its ID
CREATE PROCEDURE DeleteHotel
    @IdHotel INT
AS
BEGIN
    DELETE FROM Hotel
    WHERE IdHotel = @IdHotel
END
GO

-- Procedure to get all hotels
CREATE PROCEDURE GetAllHotels
AS
BEGIN
    SELECT * FROM Hotel
END
GO

-- Procedure to get a hotel by its ID
CREATE PROCEDURE GetHotelById
    @IdHotel INT
AS
BEGIN
    SELECT * FROM Hotel
    WHERE IdHotel = @IdHotel
END
GO
