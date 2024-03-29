-- Procedimiento almacenado para activar un hotel (cambiar su Estado a 1)
CREATE PROCEDURE Hotel_Activar
    @IdHotel INT
AS
BEGIN
    UPDATE Hotel
    SET Estado = 1
    WHERE IdHotel = @IdHotel;
END;
GO


-- Procedimiento almacenado para insertar un nuevo hotel
CREATE PROCEDURE Hotel_Insertar
    @Nombre NVARCHAR(100),
    @Direccion NVARCHAR(200),
    @Estado BIT,
    @Telefono NVARCHAR(15)
AS
BEGIN
    INSERT INTO Hotel (Nombre, Direccion, Estado, Telefono)
    VALUES (@Nombre, @Direccion, @Estado, @Telefono);
END;
GO

-- Procedimiento almacenado para obtener todos los hoteles
CREATE PROCEDURE Hoteles
AS
BEGIN
    SELECT * FROM Hotel;
END;
GO

-- Procedimiento almacenado para obtener hoteles por nombre
CREATE PROCEDURE Hoteles_PorNombre
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Hotel WHERE Nombre LIKE '%' + @Nombre + '%';
END;
GO

-- Procedimiento almacenado para eliminar un hotel por su IdHotel
CREATE PROCEDURE Hotel_Eliminar
    @IdHotel INT
AS
BEGIN
    DELETE FROM Hotel WHERE IdHotel = @IdHotel;
END;
GO

-- Procedimiento almacenado para actualizar la información de un hotel
CREATE PROCEDURE Hotel_Actualizar
    @IdHotel INT,
    @Nombre NVARCHAR(100),
    @Direccion NVARCHAR(200),
    @Estado BIT,
    @Telefono NVARCHAR(15)
AS
BEGIN
    UPDATE Hotel
    SET Nombre = @Nombre,
        Direccion = @Direccion,
        Estado = @Estado,
        Telefono = @Telefono
    WHERE IdHotel = @IdHotel;
END;
GO

-- Procedimiento almacenado para desactivar un hotel (cambiar su Estado a 0)
CREATE PROCEDURE Hotel_Desactivar
    @IdHotel INT
AS
BEGIN
    UPDATE Hotel
    SET Estado = 0
    WHERE IdHotel = @IdHotel;
END;
GO

-- Procedimiento almacenado para verificar si un hotel existe por su Nombre
CREATE PROCEDURE Hotel_Existe
    @Nombre NVARCHAR(100),
    @Existe BIT OUTPUT
AS
BEGIN
    SET @Existe = 0;
    IF EXISTS (SELECT 1 FROM Hotel WHERE Nombre = @Nombre)
        SET @Existe = 1;
END;
GO


