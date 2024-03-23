-- Crear la base de datos si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ResortsUned')
BEGIN
    CREATE DATABASE ResortsUned
    PRINT 'Creada Exitosamente la base de datos ResortsUned'
END
GO

-- Usar la base de datos creada
USE ResortsUned
GO

-- Crear tabla de relación Rol
CREATE TABLE Rol (
    IdRol INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(30) NOT NULL,
    Descripcion VARCHAR(255) NULL,
    Estado BIT DEFAULT(1)
);
PRINT 'Creada Exitosamente la tabla Rol'
GO

-- Crear tabla de relación Usuario
CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY,
    IdRol INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    TipoDocumento VARCHAR(20) NULL,
    NumDocumento VARCHAR(20) NULL,
    Direccion VARCHAR(70) NULL,
    Telefono VARCHAR(20) NULL,
    Email VARCHAR(50) NOT NULL,
    Clave VARBINARY(MAX) NOT NULL,
    Estado BIT DEFAULT(1),    
    FOREIGN KEY (IdRol) REFERENCES Rol (IdRol)
);
PRINT 'Creada Exitosamente la tabla Usuario'
GO

-- Crear la tabla Hotel
CREATE TABLE Hotel (
    IdHotel INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Direccion NVARCHAR(200),
    Estado BIT,
    Telefono NVARCHAR(15),
    IdUsuarioResponsable INT NULL,
    FOREIGN KEY (IdUsuarioResponsable) REFERENCES Usuario(IdUsuario)
);
PRINT 'Creada Exitosamente la tabla Hotel'
GO

-- Crear la tabla Categoria
CREATE TABLE Categoria (
    IdCategoria INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50), -- Nombre de la categoría
    Descripcion NVARCHAR(100), -- Descripción de la categoría
    Estado BIT
);
PRINT 'Creada Exitosamente la tabla Categoria'
GO

-- Crear la tabla Articulo
CREATE TABLE Articulo (
    IdArticulo INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Precio INT,
    IdCategoria INT,
    FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria)
);
PRINT 'Creada Exitosamente la tabla Articulo'
GO

-- Crear la tabla Cliente
CREATE TABLE Cliente (
    Identificacion NVARCHAR(20) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Apellido1 NVARCHAR(100),
    Apellido2 NVARCHAR(100),
    FechaNacimiento DATE,
    Genero CHAR(1)
);
PRINT 'Creada Exitosamente la tabla Cliente'
GO

-- Crear la tabla ArticuloHotel
CREATE TABLE ArticuloHotel (
    IdAsignacion INT PRIMARY KEY IDENTITY,
    Fecha DATE,
    IdHotel INT,
    IdArticulo INT,
    FOREIGN KEY (IdHotel) REFERENCES Hotel(IdHotel),
    FOREIGN KEY (IdArticulo) REFERENCES Articulo(IdArticulo)
);
PRINT 'Creada Exitosamente la tabla ArticuloHotel'
GO

-- Crear tabla de relación Cliente-Hotel
CREATE TABLE ClienteHotel (
    IdentificacionCliente NVARCHAR(20),
    IdHotel INT,
    CONSTRAINT PK_ClienteHotel PRIMARY KEY (IdentificacionCliente, IdHotel),
    CONSTRAINT FK_ClienteHotel_Cliente FOREIGN KEY (IdentificacionCliente) REFERENCES Cliente(Identificacion),
    CONSTRAINT FK_ClienteHotel_Hotel FOREIGN KEY (IdHotel) REFERENCES Hotel(IdHotel)
);
PRINT 'Creada Exitosamente la tabla ClienteHotel'
GO
