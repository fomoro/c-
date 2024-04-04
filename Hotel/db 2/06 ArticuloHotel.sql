-- InsertArticuloHotel
CREATE PROCEDURE ArticuloHotel_Insertar
    @Fecha DATE,
    @IdHotel INT,
    @IdArticulo INT
AS
BEGIN
    INSERT INTO ArticuloHotel (Fecha, IdHotel, IdArticulo)
    VALUES (@Fecha, @IdHotel, @IdArticulo);
END;
GO

-- UpdateArticuloHotel
CREATE PROCEDURE ArticuloHotel_Actualizar
    @IdAsignacion INT,
    @Fecha DATE,
    @IdHotel INT,
    @IdArticulo INT
AS
BEGIN
    UPDATE ArticuloHotel
    SET Fecha = @Fecha,
        IdHotel = @IdHotel,
        IdArticulo = @IdArticulo
    WHERE IdAsignacion = @IdAsignacion;
END;
GO

-- DeleteArticuloHotel
CREATE PROCEDURE ArticuloHotel_Eliminar
    @IdAsignacion INT
AS
BEGIN
    DELETE FROM ArticuloHotel
    WHERE IdAsignacion = @IdAsignacion;
END;
GO

-- GetArticuloHotelById
CREATE PROCEDURE ArticuloHotel_ObtenerPorId
    @IdAsignacion INT
AS
BEGIN
    SELECT *
    FROM ArticuloHotel
    WHERE IdAsignacion = @IdAsignacion;
END;
GO

-- GetArticuloHotelByHotelId
CREATE PROCEDURE ArticuloHotel_ObtenerPorIdDeHotel
    @IdHotel INT
AS
BEGIN
    SELECT *
    FROM ArticuloHotel
    WHERE IdHotel = @IdHotel;
END;
GO
