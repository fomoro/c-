-- Procedure to create a new Cliente
CREATE PROCEDURE CreateCliente
    @Identificacion NVARCHAR(20),
    @Nombre NVARCHAR(100),
    @Apellido1 NVARCHAR(100),
    @Apellido2 NVARCHAR(100),
    @FechaNacimiento DATE,
    @Genero CHAR(1)
AS
BEGIN
    INSERT INTO Cliente (Identificacion, Nombre, Apellido1, Apellido2, FechaNacimiento, Genero)
    VALUES (@Identificacion, @Nombre, @Apellido1, @Apellido2, @FechaNacimiento, @Genero)
END
GO

-- Procedure to read all Cliente records
CREATE PROCEDURE ReadAllClientes
AS
BEGIN
    SELECT * FROM Cliente
END
GO

-- Procedure to read a Cliente by its Identificacion
CREATE PROCEDURE ReadClienteByIdentificacion
    @Identificacion NVARCHAR(20)
AS
BEGIN
    SELECT * FROM Cliente WHERE Identificacion = @Identificacion
END
GO

-- Procedure to update a Cliente
CREATE PROCEDURE UpdateCliente
    @Identificacion NVARCHAR(20),
    @Nombre NVARCHAR(100),
    @Apellido1 NVARCHAR(100),
    @Apellido2 NVARCHAR(100),
    @FechaNacimiento DATE,
    @Genero CHAR(1)
AS
BEGIN
    UPDATE Cliente
    SET Nombre = @Nombre,
        Apellido1 = @Apellido1,
        Apellido2 = @Apellido2,
        FechaNacimiento = @FechaNacimiento,
        Genero = @Genero
    WHERE Identificacion = @Identificacion
END
GO

-- Procedure to delete a Cliente
CREATE PROCEDURE DeleteCliente
    @Identificacion NVARCHAR(20)
AS
BEGIN
    DELETE FROM Cliente WHERE Identificacion = @Identificacion
END
GO
