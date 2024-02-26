USE parking
GO

--Procedimiento Listar
create proc vehiculo_listar as
select	v.idvehiculo as ID,
		tv.idtipovehiculo,
		tv.tipo as TipoVehiculo,
		v.placa as Placa, 
		v.descripcion as Descripcion, 
		v.imagen as Imagen,
		v.estado as Estado
		from vehiculo v 
			inner join tipovehiculo tv on v.idtipovehiculo = tv.idtipovehiculo
		order by v.placa desc
go

--Procedimiento Buscar
create proc vehiculo_buscar
	@valor varchar(50)
as
	select	v.idvehiculo as ID,
			tv.idtipovehiculo,
			tv.tipo as TipoVehiculo,
			v.placa as Placa, 
			v.descripcion as Descripcion, 
			v.imagen as Imagen,
			v.estado as Estado
	from vehiculo v 
		inner join tipovehiculo tv on v.idtipovehiculo = tv.idtipovehiculo
	where v.placa like '%' +@valor + '%' Or tv.tipo like '%' +@valor + '%'
	order by v.placa asc
go

--Procedimiento Insertar
create proc vehiculo_insertar
	@idtipovehiculo integer,
	@placa varchar(6),
	@descripcion varchar(255)	
as
	insert into vehiculo (idtipovehiculo, placa, descripcion)
	values (@idtipovehiculo, @placa, @descripcion)
go

--Procedimiento Actualizar
create proc vehiculo_actualizar
	@idvehiculo integer,
	@idtipovehiculo integer,
	@placa varchar(6),
	@descripcion varchar(255)	
as
	update vehiculo 
	set idtipovehiculo = @idtipovehiculo,
		placa = @placa,
		descripcion = @descripcion		
	where idvehiculo = @idvehiculo
go

--Procedimiento Eliminar
create proc vehiculo_eliminar
	@idvehiculo integer 
as
	delete from vehiculo
	where idvehiculo = @idvehiculo
go

--Procedimiento Desactivar
create proc vehiculo_desactivar
	@idvehiculo integer
as
	update vehiculo set estado = 0
	where idvehiculo = @idvehiculo
go

--Procedimiento Activar
create proc vehiculo_activar
	@idvehiculo integer
as
	update vehiculo set estado = 1
	where idvehiculo = @idvehiculo
go

-- Procedimiento existe
create proc vehiculo_existe
@valor varchar(100),
@existe bit output
as
if exists (select placa from vehiculo where placa = ltrim(rtrim(@valor)))
	begin
		set @existe=1
	end
else
	begin
		set @existe=0
	end
go





