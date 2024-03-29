
-- Insertar Hoteles
INSERT INTO Hotel (Nombre, Direccion, Estado, Telefono) VALUES
('Hotel Sol', 'Calle Mayor, 12', 1, '912345678'),
('Hotel Luna', 'Calle del Sol, 23', 1, '987654321'),
('Hotel Mar', 'Avenida del Mar, 45', 1, '912345678'),
('Hotel Tierra', 'Calle de la Tierra, 67', 1, '987654321'),
('Hotel Aire', 'Avenida del Aire, 89', 1, '912345678');

PRINT 'Hoteles insertados correctamente.';

----------------------------------------------------------------------------------------------------
-- Insertar Categorías
INSERT INTO Categoria (Nombre, Descripcion, Estado) VALUES
('Alimentos', 'Productos alimenticios', 1),
('Bebidas', 'Bebidas de todo tipo', 1),
('Aseo personal', 'Productos para el cuidado personal', 1),
('Limpieza', 'Productos para la limpieza del hogar', 1),
('Entretenimiento', 'Juegos, libros y otros productos de entretenimiento', 1),
('Tecnología', 'Productos electrónicos y accesorios', 1),
('Ropa', 'Prendas de vestir y calzado', 1);

PRINT 'Categorías insertadas correctamente.';

----------------------------------------------------------------------------------------------------
-- Insertar Artículos
DECLARE @i INT, @j INT
SET @i = 1
WHILE @i <= 7
BEGIN
	SET @j = 1
	WHILE @j <= 10
	BEGIN
		INSERT INTO Articulo (Nombre, Precio_Venta, IdCategoria, Stock, Estado) VALUES
		(CONCAT('Producto ', @i, '-', @j), RAND() * 100, @i, 100, 1) 
		SET @j += 1
	END
	SET @i += 1
END
PRINT 'Artículos insertados correctamente.';

----------------------------------------------------------------------------------------------------
-- Asignar todos los artículos a todos los hoteles
DECLARE @i INT, @j INT, @idHotel INT

SET @i = 1

WHILE @i <= 5
BEGIN
	SET @idHotel = @i

	SET @j = 1

	WHILE @j <= 70
	BEGIN
		INSERT INTO ArticuloHotel (FechaAsignacion, IdHotel, IdArticulo) VALUES
		(GETDATE(), @idHotel, @j)

		SET @j += 1
	END

	SET @i += 1
END

PRINT 'Artículos asignados a los hoteles correctamente.'


----------------------------------------------------------------------------------------------------

-- Insertar Clientes
DECLARE @idCliente INT
SET @idCliente = 1

WHILE @idCliente <= 20
BEGIN
    DECLARE @Nombre NVARCHAR(100)
    DECLARE @Apellido1 NVARCHAR(100)
    DECLARE @Apellido2 NVARCHAR(100)

    SET @Nombre = 'Nombre' + CAST(@idCliente AS NVARCHAR(5))
    SET @Apellido1 = 'Apellido1_' + CAST(@idCliente AS NVARCHAR(5))
    SET @Apellido2 = 'Apellido2_' + CAST(@idCliente AS NVARCHAR(5))
    
    -- Insertar cliente
    INSERT INTO Cliente (Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Genero) VALUES
    ('ID' + CONVERT(NVARCHAR(10), @idCliente), @Nombre, @Apellido1, @Apellido2, DATEADD(dd, CAST(RAND() * 3650 AS INT), '1980-01-01'), CASE WHEN RAND() > 0.5 THEN 'M' ELSE 'F' END)

    SET @idCliente += 1
END

PRINT 'Clientes insertados correctamente.';

------------------------------------------------------------------------------------------

-- Insertar pedidos

DECLARE @idClientePedido INT, @idArticuloPedido INT
SET @idClientePedido = 1
WHILE @idClientePedido <= 20 -- Cambiado de 100 a 20 para coincidir con la cantidad de clientes insertados
BEGIN
	SET @idArticuloPedido = 1
	WHILE @idArticuloPedido <= 105
	BEGIN
		DECLARE @randomArticulo INT
		SET @randomArticulo = (SELECT TOP 1 IdArticulo FROM Articulo ORDER BY NEWID())
		INSERT INTO Pedido (FechaPedido, IdCliente, IdArticulo) VALUES
		(GETDATE(), 'ID' + CAST(@idClientePedido AS NVARCHAR(10)), @randomArticulo)
		SET @idArticuloPedido += 1
	END
	SET @idClientePedido += 1
END
PRINT 'Pedidos insertados correctamente.';
