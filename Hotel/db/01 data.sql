-- Insertar roles
INSERT INTO Rol (Nombre, Descripcion, Estado)
VALUES 
    ('Rol1', 'Descripción Rol1', 1),
    ('Rol2', 'Descripción Rol2', 1),
    ('Rol3', 'Descripción Rol3', 1);

-- Insertar usuarios
DECLARE @i INT = 1;
WHILE @i <= 10
BEGIN
    INSERT INTO Usuario (IdRol, Nombre, TipoDocumento, NumDocumento, Direccion, Telefono, Email, Clave, Estado)
    VALUES 
        (1, 'Usuario' + CAST(@i AS NVARCHAR(2)), 'TipoDoc', 'NumDoc', 'Dirección', '123456789', 'usuario' + CAST(@i AS NVARCHAR(2)) + '@example.com', 0x0123456789ABCDEF, 1);
    SET @i = @i + 1;
END;

-- Insertar hoteles
INSERT INTO Hotel (Nombre, Direccion, Estado, Telefono, IdUsuarioResponsable)
VALUES 
    ('Hotel1', 'Dirección Hotel1', 1, '123456789', 1),
    ('Hotel2', 'Dirección Hotel2', 1, '987654321', 2);

-- Insertar categorías de artículos
INSERT INTO Categoria (Nombre, Descripcion, Estado)
VALUES 
    ('Categoría1', 'Se tiene xxx y yyy', 1),
    ('Categoría2', 'Se tiene aaa y ddd', 1),
    ('Categoría3', 'Se tiene ccc y fff', 1);

-- Insertar artículos
DECLARE @j INT = 1;
WHILE @j <= 30
BEGIN
    INSERT INTO Articulo (Nombre, Precio, IdCategoria)
    VALUES 
        ('Artículo' + CAST(@j AS NVARCHAR(2)), @j * 1000, 1);
    SET @j = @j + 1;
END;

-- Insertar clientes
DECLARE @k INT = 1;
WHILE @k <= 30
BEGIN
    INSERT INTO Cliente (Identificacion, Nombre, Apellido1, Apellido2, FechaNacimiento, Genero)
    VALUES 
        ('Identificacion' + CAST(@k AS NVARCHAR(2)), 'ClienteNombre' + CAST(@k AS NVARCHAR(2)), 'Apellido1', 'Apellido2', '2000-01-01', 'M');
    SET @k = @k + 1;
END;

-- Insertar asignaciones de artículos a hoteles
DECLARE @l INT = 1;
WHILE @l <= 30
BEGIN
    INSERT INTO ArticuloHotel (Fecha, IdHotel, IdArticulo)
    VALUES 
        ('2024-02-24', CASE WHEN @l <= 15 THEN 1 ELSE 2 END, @l);
    SET @l = @l + 1;
END;

-- Insertar asignaciones de clientes a hoteles
DECLARE @m INT = 1;
WHILE @m <= 30
BEGIN
    INSERT INTO ClienteHotel (IdentificacionCliente, IdHotel)
    VALUES 
        ('Identificacion' + CAST(@m AS NVARCHAR(2)), CASE WHEN @m <= 15 THEN 1 ELSE 2 END);
    SET @m = @m + 1;
END;
