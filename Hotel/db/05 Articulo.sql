-- Create or Update Articulo
CREATE PROCEDURE UpsertArticulo
    @IdArticulo INT OUTPUT,
    @Nombre NVARCHAR(100),
    @Precio INT,
    @IdCategoria INT
AS
BEGIN
    -- Check if the Articulo already exists
    IF EXISTS (SELECT 1 FROM Articulo WHERE IdArticulo = @IdArticulo)
    BEGIN
        -- Update the existing Articulo
        UPDATE Articulo
        SET Nombre = @Nombre, Precio = @Precio, IdCategoria = @IdCategoria
        WHERE IdArticulo = @IdArticulo
    END
    ELSE
    BEGIN
        -- Insert a new Articulo
        INSERT INTO Articulo (Nombre, Precio, IdCategoria)
        VALUES (@Nombre, @Precio, @IdCategoria)
        SET @IdArticulo = SCOPE_IDENTITY()
    END
END
GO

-- Read Articulo
CREATE PROCEDURE GetArticuloById
    @IdArticulo INT
AS
BEGIN
    SELECT * FROM Articulo WHERE IdArticulo = @IdArticulo
END
GO

CREATE PROCEDURE GetAllArticulos
AS
BEGIN
    SELECT * FROM Articulo
END
GO

-- Delete Articulo
CREATE PROCEDURE DeleteArticulo
    @IdArticulo INT
AS
BEGIN
    DELETE FROM Articulo WHERE IdArticulo = @IdArticulo
END
GO


-- Create Articulo
CREATE PROCEDURE InsertArticulo
    @Nombre NVARCHAR(100),
    @Precio INT,
    @IdCategoria INT
AS
BEGIN
    INSERT INTO Articulo (Nombre, Precio, IdCategoria)
    VALUES (@Nombre, @Precio, @IdCategoria)
END
GO