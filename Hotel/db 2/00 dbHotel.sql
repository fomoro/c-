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

-- Crear la tabla Hotel
CREATE TABLE Hotel (
    IdHotel INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100),
    Direccion NVARCHAR(200),
    Estado BIT,
    Telefono NVARCHAR(15),
);
PRINT 'Creada Exitosamente la tabla Hotel'
GO

-- Crear la tabla Categoria
CREATE TABLE Categoria (
    IdCategoria INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50) not null unique,
    Descripcion NVARCHAR(100) null, 
    Estado BIT default(1)
);
PRINT 'Creada Exitosamente la tabla Categoria'
GO

-- Crear la tabla Articulo
CREATE TABLE Articulo (
    IdArticulo INT PRIMARY KEY IDENTITY,
    IdCategoria INT,
    Nombre NVARCHAR(100) not null unique,
    Precio_Venta DECIMAL(11,2) not null,    
    Descripcion NVARCHAR(255) null,
    Imagen NVARCHAR(20) null,
    Estado BIT default(1),
    FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria)
);
PRINT 'Creada Exitosamente la tabla Articulo'
GO

-- Crear la tabla ArticuloHotel
CREATE TABLE ArticuloHotel (
    IdAsignacion INT PRIMARY KEY IDENTITY,    
    IdHotel INT,
    IdArticulo INT,		
	FechaAsignacion DATE,
    FOREIGN KEY (IdHotel) REFERENCES Hotel(IdHotel),
    FOREIGN KEY (IdArticulo) REFERENCES Articulo(IdArticulo)
);
PRINT 'Creada Exitosamente la tabla ArticuloHotel'
GO

-- Crear la tabla Cliente
CREATE TABLE Cliente (
    Identificacion NVARCHAR(20) PRIMARY KEY,
    Nombre NVARCHAR(100),
    PrimerApellido NVARCHAR(100),
    SegundoApellido NVARCHAR(100),
    FechaNacimiento DATE,
    Genero CHAR(1)
);
PRINT 'Creada Exitosamente la tabla Cliente'
GO

-- Crear la tabla Pedido
CREATE TABLE Pedido (
    IdPedido INT PRIMARY KEY IDENTITY,
	IdCliente NVARCHAR(20),
	IdArticulo INT,
    FechaPedido DATE,        
    FOREIGN KEY (IdCliente) REFERENCES Cliente(Identificacion), 
    FOREIGN KEY (IdArticulo) REFERENCES Articulo(IdArticulo),    
);
PRINT 'Creada Exitosamente la tabla Pedido'
GO
