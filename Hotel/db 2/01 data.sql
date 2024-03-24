-- Insertar Roles
INSERT INTO Rol (Nombre, Descripcion) VALUES
('Cliente', 'Rol para clientes del resort'),
('Administrador', 'Rol para administradores del sistema');
PRINT 'Roles insertados correctamente.';

-- Insertar usuarios
INSERT INTO Usuario (IdRol, Nombre, Email, Clave, Estado) VALUES
(1, 'Juan Pérez', 'juan.perez@correo.com', CONVERT(varbinary(max), '123456'), 1),
(1, 'Ana García', 'ana.garcia@correo.com', CONVERT(varbinary(max), '654321'), 1),
(1, 'Pedro López', 'pedro.lopez@correo.com', CONVERT(varbinary(max), 'abcdef'), 1),
(1, 'Maria Rodriguez', 'maria.rodriguez@correo.com', CONVERT(varbinary(max), 'ghijkl'), 1),
(1, 'Luis Martinez', 'luis.martinez@correo.com', CONVERT(varbinary(max), 'mnopqr'), 1),
(1, 'Sofia Gonzalez', 'sofia.gonzalez@correo.com', CONVERT(varbinary(max), 'stuvwxy'), 1),
(2, 'David Hernandez', 'david.hernandez@correo.com', CONVERT(varbinary(max), '12345678'), 1),
(2, 'Laura Fernandez', 'laura.fernandez@correo.com', CONVERT(varbinary(max), '87654321'), 1);

PRINT 'Usuarios insertados correctamente.';

-- Insertar Categorías
INSERT INTO Categoria (Nombre, Descripcion, Estado) VALUES
('Alimentos', 'Productos alimenticios', 1),
('Bebidas', 'Bebidas de todo tipo', 1),
('Aseo personal', 'Productos para el cuidado personal', 1),
('Limpieza', 'Productos para la limpieza del hogar', 1),
('Entretenimiento', 'Juegos, libros y otros productos de entretenimiento', 1),
('Tecnología', 'Productos electrónicos y accesorios', 1),
('Ropa', 'Prendas de vestir y calzado', 1);

PRINT 'Categorías insertados correctamente.';

-- Insertar Artículos
DECLARE @i INT, @j INT
SET @i = 1
WHILE @i <= 7
BEGIN
	SET @j = 1
	WHILE @j <= 15
	BEGIN
		INSERT INTO Articulo (Nombre, Precio, IdCategoria) VALUES
		(CONCAT('Producto ', @i, '-', @j), RAND() * 100, @i)
		SET @j += 1
	END
	SET @i += 1
END

PRINT 'Artículos insertados correctamente.';

-- Insertar Hoteles
INSERT INTO Hotel (Nombre, Direccion, Estado, Telefono) VALUES
('Hotel Sol', 'Calle Mayor, 12', 1, '912345678'),
('Hotel Luna', 'Calle del Sol, 23', 1, '987654321'),
('Hotel Mar', 'Avenida del Mar, 45', 1, '912345678'),
('Hotel Tierra', 'Calle de la Tierra, 67', 1, '987654321'),
('Hotel Aire', 'Avenida del Aire, 89', 1, '912345678');

PRINT 'Hoteles insertados correctamente.';

-- Asignar todos los artículos a todos los hoteles
DECLARE @idHotel INT, @idArticulo INT
SET @idHotel = 1
WHILE @idHotel <= 5
BEGIN
	SET @idArticulo = 1
	WHILE @idArticulo <= 105
	BEGIN
		INSERT INTO ArticuloHotel (FechaAsignacion, IdHotel, IdArticulo) VALUES
		(GETDATE(), @idHotel, @idArticulo)
		SET @idArticulo += 1
	END
	SET @idHotel += 1
END

PRINT 'Se asignan los artículos a los Hoteles';

-- Insertar Clientes
-- Tabla temporal para almacenar nombres posibles
CREATE TABLE #Nombres (Nombre NVARCHAR(100))

-- Insertar nombres en la tabla temporal
INSERT INTO #Nombres (Nombre) VALUES ('Reese'), ('Jesse'), ('Taylor'), ('Ana'), ('Luis'), ('Laura'), ('Carlos'), ('Sofía'), ('Miguel'), ('Isabella')

-- Tabla temporal para almacenar apellidos posibles
CREATE TABLE #Apellidos (Apellido NVARCHAR(100))

-- Insertar apellidos en la tabla temporal
INSERT INTO #Apellidos (Apellido) VALUES
('González'), ('Rodríguez'), ('López'), ('Martínez'), ('Sánchez'), ('Pérez'), ('Gómez'), ('Fernández'), ('Díaz'), ('Ruiz'), ('Jaramillo'), ('Giraldo'), ('Alvarez'), ('Botero'), ('Suarez'), ('Uribe')

-- Insertar clientes
DECLARE @idCliente INT
SET @idCliente = 1
WHILE @idCliente <= 30
BEGIN
    DECLARE @Nombre NVARCHAR(100)
    DECLARE @Apellido1 NVARCHAR(100)
    DECLARE @Apellido2 NVARCHAR(100)

    SELECT TOP 1 @Nombre = Nombre FROM #Nombres ORDER BY NEWID()
    SELECT TOP 1 @Apellido1 = Apellido FROM #Apellidos ORDER BY NEWID()
    SELECT TOP 1 @Apellido2 = Apellido FROM #Apellidos WHERE Apellido <> @Apellido1 ORDER BY NEWID()
    
	INSERT INTO Cliente (Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Genero) VALUES
    (@Nombre, @Apellido1, @Apellido2, DATEADD(dd, CAST(RAND() * 3650 AS INT), '1980-01-01'), CASE WHEN RAND() > 0.5 THEN 'M' ELSE 'F' END)


    SET @idCliente += 1
END

-- Eliminar tablas temporales
DROP TABLE #Nombres
DROP TABLE #Apellidos

PRINT 'Clientes insertados correctamente.';
---------------------------------------------

-- Insertar pedidos
DECLARE @idClientePedido INT, @idArticuloPedido INT
SET @idClientePedido = 1
WHILE @idClientePedido <= 100
BEGIN
	SET @idArticuloPedido = 1
	WHILE @idArticuloPedido <= 105
	BEGIN
		IF (RAND() > 0.5)
		BEGIN
			INSERT INTO Pedido (FechaPedido, IdCliente, IdArticulo) VALUES
			(GETDATE(), @idClientePedido, @idArticuloPedido)
		END
		SET @idArticuloPedido += 1
	END
	SET @idClientePedido += 1
END
PRINT 'Pedidos insertados correctamente.';
