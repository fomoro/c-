-- InsertAsignacionArticuloHotel
CREATE PROCEDURE InsertAsignacionArticuloHotel
    @Fecha DATE,
    @IdHotel INT,
    @IdArticulo INT
AS
BEGIN
    INSERT INTO AsignacionArticuloHotel (Fecha, IdHotel, IdArticulo)
    VALUES (@Fecha, @IdHotel, @IdArticulo);
END;
GO

-- UpdateAsignacionArticuloHotel
CREATE PROCEDURE UpdateAsignacionArticuloHotel
    @IdAsignacion INT,
    @Fecha DATE,
    @IdHotel INT,
    @IdArticulo INT
AS
BEGIN
    UPDATE AsignacionArticuloHotel
    SET Fecha = @Fecha,
        IdHotel = @IdHotel,
        IdArticulo = @IdArticulo
    WHERE IdAsignacion = @IdAsignacion;
END;
GO

-- DeleteAsignacionArticuloHotel
CREATE PROCEDURE DeleteAsignacionArticuloHotel
    @IdAsignacion INT
AS
BEGIN
    DELETE FROM AsignacionArticuloHotel
    WHERE IdAsignacion = @IdAsignacion;
END;
GO

-- GetAsignacionArticuloHotelById
CREATE PROCEDURE GetAsignacionArticuloHotelById
    @IdAsignacion INT
AS
BEGIN
    SELECT *
    FROM AsignacionArticuloHotel
    WHERE IdAsignacion = @IdAsignacion;
END;
GO

-- GetAsignacionArticuloHotelByHotelId
CREATE PROCEDURE GetAsignacionArticuloHotelByHotelId
    @IdHotel INT
AS
BEGIN
    SELECT *
    FROM AsignacionArticuloHotel
    WHERE IdHotel = @IdHotel;
END;
GO
