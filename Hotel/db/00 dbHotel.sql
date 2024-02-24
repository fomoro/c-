if exists (select * from sysdatabases where name != 'hotel')
		CREATE DATABASE hotel
		PRINT 'Creada Exitosamente la base de datos hotel'
go

USE hotel
GO

--Tabla categoría
