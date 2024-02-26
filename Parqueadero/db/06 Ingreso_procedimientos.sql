USE parking
GO

--Procedimiento Listar
create proc ingreso_listar as
	select	i.idingreso as ID,		
			v.idvehiculo,
			v.placa,		
			u.idusuario,	
			u.telefono,
			i.estado as Estado
	from ingreso i
		inner join vehiculo v on v.idvehiculo = i.idvehiculo
		inner join usuario u on u.idusuario = i.idusuario
	order by v.placa desc
go

--Procedimiento Buscar
create proc ingreso_buscar
	@valor varchar(50)
as
	select	i.idingreso as ID,		
			v.idvehiculo,
			v.placa as Placa,		
			u.idusuario,	
			u.telefono as Telefono,
			i.estado as Estado
	from ingreso i
		inner join vehiculo v on v.idvehiculo = i.idvehiculo
		inner join usuario u on u.idusuario = i.idusuario
	where v.placa like '%' +@valor + '%' Or u.telefono like '%' +@valor + '%'
	order by v.placa asc
go

--Procedimiento anular
CREATE PROC Ingreso_anular @idingreso INT
AS
    UPDATE ingreso
    SET    estado = 'Anulado'
    WHERE  idingreso = @idingreso

go



--Procedimiento Insertar
create proc ingreso_insertar
	@idtipoingreso integer,
	@placa varchar(6),
	@descripcion varchar(255)
	

as
	insert into ingreso (idvehiculo, idusuario, num_comprobante, fecha, estado)
	values (@idtipoingreso, @placa, @descripcion)
go



--Procedimiento Actualizar
create proc ingreso_actualizar
	@idingreso integer,
	@idtipoingreso integer,
	@placa varchar(6),
	@descripcion varchar(255)	
as
	update ingreso 
	set idtipoingreso = @idtipoingreso,
		placa = @placa,
		descripcion = @descripcion		
	where idingreso = @idingreso
go

--Procedimiento Eliminar
create proc ingreso_eliminar
	@idingreso integer 
as
	delete from ingreso
	where idingreso = @idingreso
go

--Procedimiento Desactivar
create proc ingreso_desactivar
	@idingreso integer
as
	update ingreso set estado = 0
	where idingreso = @idingreso
go

--Procedimiento Activar
create proc ingreso_activar
	@idingreso integer
as
	update ingreso set estado = 1
	where idingreso = @idingreso
go

-- Procedimiento existe
create proc ingreso_existe
@valor varchar(100),
@existe bit output
as
if exists (select placa from ingreso where placa = ltrim(rtrim(@valor)))
	begin
		set @existe=1
	end
else
	begin
		set @existe=0
	end
go





