if exists (select * from sysdatabases where name != 'ResortsUned')
		CREATE DATABASE ResortsUned
		PRINT 'Creada Exitosamente la base de datos ResortsUned'
go

-- Usar la base de datos creada
USE ResortsUned
GO

-- Crear tabla de relación Rol
create table Rol (
	IdRol integer primary key identity,
	Nombre varchar(30) not null,
	Descripcion varchar(255) null,
	Estado bit default(1)
);
PRINT 'Creada Exitosamente la tabla Rol'
GO

-- Crear tabla de relación Usuario
create table Usuario(
	IdUsuario integer primary key identity,
	IdRol integer not null,
	Nombre varchar(100) not null,
	TipoDocumento varchar(20) null,
	NumDocumento varchar(20) null,
	Direccion varchar(70) null,
	Telefono varchar(20) null,
	Email varchar(50) not null,
	Clave varbinary(MAX) not null,
	Estado bit default(1),	
	FOREIGN KEY (IdRol) REFERENCES Rol (IdRol),		
);
PRINT 'Creada Exitosamente la tabla Usuario'
GO

-- Crear la tabla Hotel
CREATE TABLE Hotel (
    IdHotel INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Direccion NVARCHAR(200),
    Estado BIT,
    Telefono NVARCHAR(15),
	IdUsuarioResponsable INT NULL,
    FOREIGN KEY (IdUsuarioResponsable) REFERENCES Usuario(IdUsuario)
);
PRINT 'Creada Exitosamente la tabla Hotel'
GO

-- Crear la tabla CategoriaArticulo
CREATE TABLE CategoriaArticulo (
    IdCategoria INT PRIMARY KEY,
    Descripcion NVARCHAR(100),
    Estado BIT
);
PRINT 'Creada Exitosamente la tabla CategoriaArticulo'
GO

-- Crear la tabla Articulo
CREATE TABLE Articulo (
    IdArticulo INT PRIMARY KEY,
    Nombre NVARCHAR(100),
    Precio INT,
    IdCategoria INT FOREIGN KEY REFERENCES CategoriaArticulo(IdCategoria)
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

-- Crear la tabla AsignacionArticuloHotel
CREATE TABLE AsignacionArticuloHotel (
    IdAsignacion INT PRIMARY KEY,
    Fecha DATE,
    IdHotel INT FOREIGN KEY REFERENCES Hotel(IdHotel),
    IdArticulo INT FOREIGN KEY REFERENCES Articulo(IdArticulo)
);
PRINT 'Creada Exitosamente la tabla AsignacionArticuloHotel'
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


-- Crear tabla de relación UsuarioHotel
/*CREATE TABLE UsuarioHotel (
    IdUsuario INT,
    IdHotel INT,
    CONSTRAINT PK_UsuarioHotel PRIMARY KEY (IdUsuario, IdHotel),
    CONSTRAINT FK_UsuarioHotel_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(idusuario),
    CONSTRAINT FK_UsuarioHotel_Hotel FOREIGN KEY (IdHotel) REFERENCES Hotel(IdHotel)
);*/
