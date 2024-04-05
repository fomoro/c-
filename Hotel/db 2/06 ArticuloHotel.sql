CREATE PROCEDURE InsertArticuloHotel
    @IdHotel INT,
    @IdArticulo INT,
    @Fecha AS DATETIME
AS
BEGIN
    INSERT INTO ArticuloHotel (IdHotel, IdArticulo, FechaAsignacion)
    VALUES (@IdHotel, @IdArticulo, @Fecha)
END;
go

CREATE PROCEDURE DeleteArticuloHotel
    @IdAsignacion INT
AS
BEGIN
    DELETE FROM ArticuloHotel WHERE IdAsignacion = @IdAsignacion
END;
go