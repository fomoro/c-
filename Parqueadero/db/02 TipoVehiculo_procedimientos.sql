USE parking
GO

--Procedimiento Listar exec tipovehiculo_listar
create proc tipovehiculo_listar as
	select		idtipovehiculo as ID, 
				tipo as Tipo, 
				descripcion as Descripcion,
				estado as Estado,
				precio as Precio
	from		tipovehiculo
	order by	idtipovehiculo desc
go

--Procedimiento Buscar
create proc tipovehiculo_buscar
	@valor varchar(50)
as
	select		idtipovehiculo as ID,
				tipo as Tipo,	
				descripcion as Descripcion,
				estado as Estado,
				precio as Precio
	from		tipovehiculo
	where		tipo like '%' + @valor + '%' Or descripcion like '%' + @valor + '%'
	order by	tipo asc
go

--Procedimiento Insertar
create proc tipovehiculo_insertar
	@tipo varchar(50),
	@descripcion varchar(255),
	@precio decimal(11,2)
as
	insert into tipovehiculo (tipo, descripcion, precio) values (@tipo, @descripcion, @precio)
go

--Procedimiento Actualizar
create proc tipovehiculo_actualizar
	@idtipovehiculo int,
	@tipo varchar(50),
	@precio decimal(11,2),
	@descripcion varchar(255)
as
	update tipovehiculo set tipo = @tipo, descripcion = @descripcion, precio = @precio
	where  idtipovehiculo = @idtipovehiculo
go

--Procedimiento Eliminar
create proc tipovehiculo_eliminar
	@idtipovehiculo int
as
	delete from tipovehiculo where idtipovehiculo = @idtipovehiculo
go

--Procedimiento Desactivar
create proc tipovehiculo_desactivar
	@idtipovehiculo int
as
	update tipovehiculo set estado = 0
	where idtipovehiculo = @idtipovehiculo
go

--Procedimiento Activar
create proc tipovehiculo_activar
	@idtipovehiculo int
as
	update tipovehiculo set estado = 1
	where idtipovehiculo = @idtipovehiculo
go

--Procedimiento Existe
create proc tipovehiculo_existe
	@valor varchar(100),
	@existe bit output
as
	if exists (select tipo from tipovehiculo where tipo = ltrim(rtrim(@valor)))
		begin
		 set @existe=1
		end
	else
		begin
		 set @existe=0
		end
go
		
--Procedimiento Selecionar
create proc tipovehiculo_seleccionar
as
	select		idtipovehiculo as ID,
				tipo as Tipo,	
				descripcion as Descripcion,
				estado as Estado,
				precio as Precio
	from		tipovehiculo
	where		estado = 1
	order by	tipo asc
go