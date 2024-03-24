-- Procedimiento Listar
CREATE PROCEDURE Articulo_listar
AS
BEGIN
    SELECT a.idarticulo AS ID, a.idcategoria, c.nombre AS Categoria,
    a.codigo AS Codigo, a.nombre AS Nombre, a.precio_venta AS Precio_Venta,
    a.stock AS Stock, a.descripcion AS Descripcion, a.imagen AS Imagen,
    a.estado AS Estado
    FROM articulo a
    INNER JOIN categoria c ON a.idcategoria = c.idcategoria
    ORDER BY a.idarticulo DESC;
END
GO

-- Procedimiento Buscar
CREATE PROCEDURE Articulo_buscar
@valor VARCHAR(50)
AS
BEGIN
    SELECT a.idarticulo AS ID, a.idcategoria, c.nombre AS Categoria,
    a.codigo AS Codigo, a.nombre AS Nombre, a.precio_venta AS Precio_Venta,
    a.stock AS Stock, a.descripcion AS Descripcion, a.imagen AS Imagen,
    a.estado AS Estado
    FROM articulo a
    INNER JOIN categoria c ON a.idcategoria = c.idcategoria
    WHERE a.nombre LIKE '%' + @valor + '%' OR a.descripcion LIKE '%' + @valor + '%'
    ORDER BY a.nombre ASC;
END
GO

-- Procedimiento Insertar
CREATE PROCEDURE Articulo_insertar
@idcategoria INTEGER,
@codigo VARCHAR(50),
@nombre VARCHAR(100),
@precio_venta DECIMAL(11,2),
@stock INTEGER,
@descripcion VARCHAR(255),
@imagen VARCHAR(20)
AS
BEGIN
    INSERT INTO Articulo (idcategoria, codigo, nombre, precio_venta, stock, descripcion, imagen)
    VALUES (@idcategoria, @codigo, @nombre, @precio_venta, @stock, @descripcion, @imagen);
END
GO

-- Procedimiento Actualizar
CREATE PROCEDURE Articulo_actualizar
@idarticulo INTEGER,
@idcategoria INTEGER,
@codigo VARCHAR(50),
@nombre VARCHAR(100),
@precio_venta DECIMAL(11,2),
@stock INTEGER,
@descripcion VARCHAR(255),
@imagen VARCHAR(20)
AS
BEGIN
    UPDATE articulo
    SET idcategoria = @idcategoria,
        codigo = @codigo,
        nombre = @nombre,
        precio_venta = @precio_venta,
        stock = @stock,
        descripcion = @descripcion,
        imagen = @imagen
    WHERE idarticulo = @idarticulo;
END
GO

-- Procedimiento Eliminar
CREATE PROCEDURE Articulo_eliminar
@idarticulo INTEGER
AS
BEGIN
    DELETE FROM articulo
    WHERE idarticulo = @idarticulo;
END
GO

-- Procedimiento Desactivar
CREATE PROCEDURE Articulo_desactivar
@idarticulo INTEGER
AS
BEGIN
    UPDATE articulo
    SET estado = 0
    WHERE idarticulo = @idarticulo;
END
GO

-- Procedimiento Activar
CREATE PROCEDURE Articulo_activar
@idarticulo INTEGER
AS
BEGIN
    UPDATE articulo
    SET estado = 1
    WHERE idarticulo = @idarticulo;
END
GO

-- Procedimiento existe
CREATE PROCEDURE Articulo_existe
@valor VARCHAR(100),
@existe BIT OUTPUT
AS
BEGIN
    IF EXISTS (SELECT nombre FROM articulo WHERE nombre = LTRIM(RTRIM(@valor)))
        SET @existe = 1;
    ELSE
        SET @existe = 0;
END
GO
