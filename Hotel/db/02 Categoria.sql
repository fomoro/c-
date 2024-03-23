-- Stored procedure to list all categories
CREATE PROCEDURE ListarCategorias
AS
BEGIN
    SELECT IdCategoria, Nombre, Descripcion, Estado
    FROM Categoria;
END;
GO

-- Stored procedure to search for a category by Id
CREATE PROCEDURE BuscarCategoriaPorId
    @IdCategoria INT
AS
BEGIN
    SELECT IdCategoria, Nombre, Descripcion, Estado
    FROM Categoria
    WHERE IdCategoria = @IdCategoria;
END;
GO

CREATE PROCEDURE BuscarCategoriaPorNombre
  @Nombre NVARCHAR(50)
AS
BEGIN
  SELECT IdCategoria AS ID, Nombre, Descripcion, Estado
  FROM Categoria
  WHERE Nombre LIKE '%' + @Nombre + '%'
  ORDER BY Nombre ASC;
END;
GO


CREATE PROCEDURE BuscarCategoriaPorDescripcion
    @valor NVARCHAR(50)
AS
BEGIN
    SELECT IdCategoria AS ID, Nombre, Descripcion, Estado
    FROM Categoria
    WHERE Descripcion LIKE '%' + @valor + '%'
    ORDER BY Descripcion ASC;
END;
GO

-- Stored procedure to insert a new category
CREATE PROCEDURE InsertarCategoria
    @Nombre NVARCHAR(50),
    @Descripcion NVARCHAR(100),
    @Estado BIT
AS
BEGIN
    INSERT INTO Categoria (Nombre, Descripcion, Estado)
    VALUES (@Nombre, @Descripcion, @Estado);
END;
GO

-- Stored procedure to update a category
CREATE PROCEDURE ActualizarCategoria
    @IdCategoria INT,
    @Nombre NVARCHAR(50),
    @Descripcion NVARCHAR(100),
    @Estado BIT
AS
BEGIN
    UPDATE Categoria
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Estado = @Estado
    WHERE IdCategoria = @IdCategoria;
END;
GO

-- Stored procedure to check if a category with this name already exists
CREATE PROCEDURE ExisteCategoriaConEsteNombre
    @Nombre NVARCHAR(50),
    @Existe BIT OUTPUT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Categoria WHERE Nombre = @Nombre)
        SET @Existe = 1;
    ELSE
        SET @Existe = 0;
END;
GO
