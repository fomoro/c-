-- Procedimiento almacenado para obtener todos los clientes
CREATE PROCEDURE Clientes
AS
BEGIN
    SELECT * FROM Cliente order by cliente.Nombre;
END;
GO

-- Procedimiento almacenado para obtener clientes por nombre
CREATE PROCEDURE ClientesPorNombre
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Cliente WHERE Nombre LIKE '%' + @Nombre + '%';
END;
GO

-- Procedimiento almacenado para verificar si un cliente existe por su Identificacion
CREATE PROCEDURE Cliente_Existe
    @Identificacion NVARCHAR(20),
    @Existe BIT OUTPUT
AS
BEGIN
    SET @Existe = 0;
    IF EXISTS (SELECT 1 FROM Cliente WHERE Identificacion = @Identificacion)
        SET @Existe = 1;
END;
GO

-- Procedimiento almacenado para insertar un nuevo cliente
CREATE PROCEDURE Cliente_Insertar
    @Identificacion NVARCHAR(20),
    @Nombre NVARCHAR(100),
    @PrimerApellido NVARCHAR(100),
    @SegundoApellido NVARCHAR(100),
    @FechaNacimiento DATE,
    @Genero CHAR(1)
AS
BEGIN
    INSERT INTO Cliente (Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Genero)
    VALUES (@Identificacion, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Genero);
END;
GO

-- Procedimiento almacenado para actualizar la información de un cliente
CREATE PROCEDURE Cliente_Actualizar
    @Identificacion NVARCHAR(20),
    @Nombre NVARCHAR(100),
    @PrimerApellido NVARCHAR(100),
    @SegundoApellido NVARCHAR(100),
    @FechaNacimiento DATE,
    @Genero CHAR(1)
AS
BEGIN
    UPDATE Cliente
    SET Nombre = @Nombre,
        PrimerApellido = @PrimerApellido,
        SegundoApellido = @SegundoApellido,
        FechaNacimiento = @FechaNacimiento,
        Genero = @Genero
    WHERE Identificacion = @Identificacion;
END;
GO

-- Procedimiento almacenado para eliminar un cliente por su Identificacion
CREATE PROCEDURE Cliente_Eliminar
    @Identificacion NVARCHAR(20)
AS
BEGIN
    DELETE FROM Cliente WHERE Identificacion = @Identificacion;
END;
GO
