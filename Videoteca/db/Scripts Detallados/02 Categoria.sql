-- Procedimiento para listar todas las categorías
CREATE PROCEDURE Categorias_Listar
AS
BEGIN
    -- Selecciona información de todas las categorías ordenadas por nombre
    SELECT IdCategoria, Nombre, Descripcion, Estado
    FROM Categoria
    ORDER BY Nombre;	
END;
GO

-------------------------------------------------------------------------------------
-- Procedimiento para listar todas las categorías
CREATE PROCEDURE Categorias_Activas
AS
BEGIN
    -- Selecciona información de todas las categorías ordenadas por nombre
    SELECT IdCategoria, Nombre, Descripcion, Estado
    FROM Categoria Where Estado = 1
    ORDER BY Nombre;	
END;
GO

-------------------------------------------------------------------------------------
-- Procedimiento para buscar una categoría por su Id
CREATE PROCEDURE CategoriaBuscarPorId
    @IdCategoria INT
AS
BEGIN
    -- Selecciona información de la categoría con el Id especificado
    SELECT IdCategoria, Nombre, Descripcion, Estado
    FROM Categoria
    WHERE IdCategoria = @IdCategoria;
END;
GO

-------------------------------------------------------------------------------------
-- Procedimiento para buscar categorías por su nombre
CREATE PROCEDURE CategoriaBuscarPorNombre
    @Nombre NVARCHAR(50)
AS
BEGIN
    -- Selecciona información de las categorías que contienen el nombre especificado
    SELECT IdCategoria AS ID, Nombre, Descripcion, Estado
    FROM Categoria
    WHERE Nombre LIKE '%' + @Nombre + '%'
    ORDER BY Nombre ASC;
END;
GO

-------------------------------------------------------------------------------------
-- Procedimiento para insertar una nueva categoría
CREATE PROCEDURE CategoriaInsertar
    @Nombre NVARCHAR(50),
    @Descripcion NVARCHAR(100),
    @Estado BIT
AS
BEGIN
    -- Inserta una nueva fila en la tabla Categoria con los valores especificados
    INSERT INTO Categoria (Nombre, Descripcion, Estado)
    VALUES (@Nombre, @Descripcion, @Estado);
END;
GO

-------------------------------------------------------------------------------------
-- Procedimiento para actualizar información de una categoría existente
CREATE PROCEDURE CategoriaActualizar
    @IdCategoria INT,
    @Nombre NVARCHAR(50),
    @Descripcion NVARCHAR(100)    
AS
BEGIN
    -- Actualiza los campos de una categoría con el Id especificado
    UPDATE Categoria
    SET Nombre = @Nombre,
        Descripcion = @Descripcion        
    WHERE IdCategoria = @IdCategoria;
END;
GO

-------------------------------------------------------------------------------------
-- Procedimiento para verificar si existe una categoría con un nombre dado
CREATE PROCEDURE CategoriaExisteConEsteNombre
    @Nombre NVARCHAR(50),
    @IdCategoria INT,
    @Existe BIT OUTPUT
AS
BEGIN
    -- Verifica si existe alguna categoría con el nombre especificado y diferente ID
    IF EXISTS (SELECT 1 FROM Categoria WHERE Nombre = @Nombre AND IdCategoria != @IdCategoria)
        SET @Existe = 1;
    ELSE
        SET @Existe = 0;
END;
GO

-------------------------------------------------------------------------------------
-- Procedimiento para eliminar una categoría
CREATE PROCEDURE Categoria_eliminar
    @idcategoria INT
AS
BEGIN
    -- Elimina la categoría con el Id especificado
    DELETE FROM categoria
    WHERE idcategoria = @idcategoria;
END;
GO

-------------------------------------------------------------------------------------
-- Procedimiento para desactivar una categoría
CREATE PROCEDURE Categoria_desactivar
    @idcategoria INT
AS
BEGIN
    -- Desactiva la categoría con el Id especificado (cambia el estado a 0)
    UPDATE categoria
    SET estado = 0
    WHERE idcategoria = @idcategoria;
END;
GO

-------------------------------------------------------------------------------------
-- Procedimiento para activar una categoría
CREATE PROCEDURE Categoria_activar
    @idcategoria INT
AS
BEGIN
    -- Activa la categoría con el Id especificado (cambia el estado a 1)
    UPDATE categoria
    SET estado = 1
    WHERE idcategoria = @idcategoria;
END;
GO

