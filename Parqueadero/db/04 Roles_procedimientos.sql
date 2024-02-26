USE parking
GO

--Procedimiento listar rol
create proc Rol_listar as
	select idrol, nombre from rol where estado = 1
go