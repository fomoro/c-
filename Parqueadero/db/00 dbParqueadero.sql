if exists (select * from sysdatabases where name != 'parking')
		CREATE DATABASE parking
		PRINT 'Creada Exitosamente la base de datos parking'
go

USE parking
GO

--Tabla categoría
create table tipovehiculo (
	idtipovehiculo integer primary key identity,
	tipo varchar(50) not null unique,
	descripcion varchar(255) null,
	precio decimal(11,2) not null,
	estado bit default(1)
);
PRINT 'Creada Exitosamente la tabla tipovehiculo'
go


--Tabla artículo
create table vehiculo (
	idvehiculo integer primary key identity,
	idtipovehiculo integer not null,			
	placa varchar(6) not null unique,
	descripcion varchar(255) null,
	imagen varchar(20) null,
	estado bit default(1),
	FOREIGN KEY (idtipovehiculo) REFERENCES tipovehiculo(idtipovehiculo)
);
PRINT 'Creada Exitosamente la tabla vehiculo'
go


--Tabla rol
create table rol (
	idrol integer primary key identity,
	nombre varchar(30) not null,
	descripcion varchar(255) null,
	estado bit default(1)
);
PRINT 'Creada Exitosamente la tabla rol'
go

--Tabla usuario
create table usuario(
	idusuario integer primary key identity,
	idrol integer not null,
	nombre varchar(100) not null,
	tipo_documento varchar(20) null,
	num_documento varchar(20) null,
	direccion varchar(70) null,
	telefono varchar(20) null,
	email varchar(50) not null,
	clave varbinary(MAX) not null,
	estado bit default(1),
	FOREIGN KEY (idrol) REFERENCES rol (idrol)
);
PRINT 'Creada Exitosamente la tabla usuario'
go

--Tabla ticket
create table ticket(
	idticket integer primary key identity,
	idvehiculo integer not null,
	idusuario integer not null,
	nombre varchar(100) not null,
	tipo_documento varchar(20) null,
	telefono varchar(20) null,
	num_comprobante varchar (10) not null,
	fecha datetime not null,	
	estado varchar(20) not null,
	FOREIGN KEY (idvehiculo) REFERENCES vehiculo (idvehiculo),
	FOREIGN KEY (idusuario) REFERENCES usuario (idusuario)
);
PRINT 'Creada Exitosamente la tabla ticket'
go


--Tabla factura
create table factura(
	idfactura integer primary key identity,	
	idvehiculo integer not null,
	idusuario integer not null,
	nombre varchar(100) not null,
	tipo_documento varchar(20) null,
	telefono varchar(20) null,
	fechaEntrada datetime not null,	
	fechaSalida datetime not null,	
	valorMinuto decimal (11,2) not null,
	minutos int not null,
	total decimal (11,2) not null,
	estado varchar(20) not null,
	FOREIGN KEY (idusuario) REFERENCES usuario (idusuario),
	FOREIGN KEY (idvehiculo) REFERENCES vehiculo (idvehiculo)
);
PRINT 'Creada Exitosamente la tabla factura'
go