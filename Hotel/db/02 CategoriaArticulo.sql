-- Stored procedure to list all categories
CREATE PROCEDURE ListarCategoriasArticulo
AS
BEGIN
    SELECT IdCategoria, Descripcion, Estado
    FROM CategoriaArticulo;
END;
GO

-- Stored procedure to search for a category by Id
CREATE PROCEDURE BuscarCategoriaArticuloPorId
    @IdCategoria INT
AS
BEGIN
    SELECT IdCategoria, Descripcion, Estado
    FROM CategoriaArticulo
    WHERE IdCategoria = @IdCategoria;
END;
GO

CREATE PROCEDURE BuscarCategoriaArticuloPorDescripcion
    @valor NVARCHAR(50)
AS
BEGIN
    SELECT IdCategoria AS ID, Descripcion AS Nombre, Estado
    FROM CategoriaArticulo
    WHERE Descripcion LIKE '%' + @valor + '%'
    ORDER BY Descripcion ASC;
END;
GO


-- Stored procedure to insert a new category
CREATE PROCEDURE InsertarCategoriaArticulo
    @Descripcion NVARCHAR(100),
    @Estado BIT
AS
BEGIN
    INSERT INTO CategoriaArticulo (Descripcion, Estado)
    VALUES (@Descripcion, @Estado);
END;
GO

-- Stored procedure to update a category
CREATE PROCEDURE ActualizarCategoriaArticulo
    @IdCategoria INT,
    @Descripcion NVARCHAR(100),
    @Estado BIT
AS
BEGIN
    UPDATE CategoriaArticulo
    SET Descripcion = @Descripcion,
        Estado = @Estado
    WHERE IdCategoria = @IdCategoria;
END;
GO

-- Stored procedure to delete a category
CREATE PROCEDURE EliminarCategoriaArticulo
    @IdCategoria INT
AS
BEGIN
    DELETE FROM CategoriaArticulo
    WHERE IdCategoria = @IdCategoria;
END;
GO

-- Stored procedure to deactivate a category
CREATE PROCEDURE DesactivarCategoriaArticulo
    @IdCategoria INT
AS
BEGIN
    UPDATE CategoriaArticulo
    SET Estado = 0
    WHERE IdCategoria = @IdCategoria;
END;
GO

-- Stored procedure to activate a category
CREATE PROCEDURE ActivarCategoriaArticulo
    @IdCategoria INT
AS
BEGIN
    UPDATE CategoriaArticulo
    SET Estado = 1
    WHERE IdCategoria = @IdCategoria;
END;
GO

-- Stored procedure to check if a category exists
CREATE PROCEDURE ExisteCategoriaArticulo
    @IdCategoria INT,
    @Existe BIT OUTPUT
AS
BEGIN
    SET @Existe = 0; -- Default value assuming category doesn't exist

    IF EXISTS (SELECT 1 FROM CategoriaArticulo WHERE IdCategoria = @IdCategoria)
    BEGIN
        SET @Existe = 1; -- Category exists
    END;
END;
GO
