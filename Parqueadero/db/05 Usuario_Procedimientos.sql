USE parking
GO

--Procedimiento Listar
create proc usuario_listar
as
	SELECT u.idusuario      AS ID,
		   u.idrol,
		   r.nombre         AS Rol,
		   u.nombre         AS Nombre,
		   u.tipo_documento AS Tipo_Documento,
		   u.num_documento  AS Num_Documento,
		   u.direccion      AS Direccion,
		   u.telefono       AS Telefono,
		   u.email          AS Email,
		   u.estado         AS Estado
	FROM   usuario u
		   INNER JOIN rol r
				   ON u.idrol = r.idrol
	ORDER  BY u.idusuario DESC 
 go

--Procedimiento Buscar
create proc usuario_buscar
@valor varchar(50)
as
	SELECT u.idusuario      AS ID,
		   u.idrol,
		   r.nombre         AS Rol,
		   u.nombre         AS Nombre,
		   u.tipo_documento AS Tipo_Documento,
		   u.num_documento  AS Num_Documento,
		   u.direccion      AS Direccion,
		   u.telefono       AS Telefono,
		   u.email          AS Email,
		   u.estado         AS Estado
	FROM   usuario u
		   INNER JOIN rol r
				   ON u.idrol = r.idrol
	WHERE  u.nombre LIKE '%' + @valor + '%'
			OR u.email LIKE '%' + @valor + '%'
	ORDER  BY u.nombre ASC 
 go

--Procedimiento Insertar
CREATE PROC Usuario_insertar @idrol          INTEGER,
                             @nombre         VARCHAR(100),
                             @tipo_documento VARCHAR(20),
                             @num_documento  VARCHAR(20),
                             @direccion      VARCHAR(70),
                             @telefono       VARCHAR(20),
                             @email          VARCHAR(50),
                             @clave          VARCHAR(50)
AS
    INSERT INTO usuario
                (idrol, nombre, tipo_documento, num_documento, direccion, telefono, email, clave)
    VALUES      (@idrol, @nombre, @tipo_documento, @num_documento, @direccion, @telefono, @email, Hashbytes('SHA2_256', @clave))
go 

--Procedimiento Actualizar
CREATE PROC Usuario_actualizar @idusuario      INTEGER,
                               @idrol          INTEGER,
                               @nombre         VARCHAR(100),
                               @tipo_documento VARCHAR(20),
                               @num_documento  VARCHAR(20),
                               @direccion      VARCHAR(70),
                               @telefono       VARCHAR(20),
                               @email          VARCHAR(50),
                               @clave          VARCHAR(50)
AS
    IF @clave <> ''
      UPDATE usuario
      SET    idrol = @idrol,
             nombre = @nombre,
             tipo_documento = @tipo_documento,
             num_documento = @num_documento,
             direccion = @direccion,
             telefono = @telefono,
             email = @email,
             clave = Hashbytes('SHA2_256', @clave)
      WHERE  idusuario = @idusuario;
    ELSE
      UPDATE usuario
      SET    idrol = @idrol,
             nombre = @nombre,
             tipo_documento = @tipo_documento,
             num_documento = @num_documento,
             direccion = @direccion,
             telefono = @telefono,
             email = @email
      WHERE  idusuario = @idusuario;

go

--Procedimiento Eliminar
CREATE PROC Usuario_eliminar @idusuario INTEGER
AS
    DELETE FROM usuario
    WHERE  idusuario = @idusuario

go 

--Procedimiento Desactivar
create proc usuario_desactivar
	@idusuario integer
as
	update usuario set estado=0 where idusuario=@idusuario
go

--Procedimiento Activar
create proc usuario_activar
	@idusuario integer
as
	update usuario set estado=1 where idusuario=@idusuario
go

-- Procedimiento existe
create proc usuario_existe
	@valor varchar(100),
	@existe bit output
as
	if exists (select email from usuario where email = ltrim(rtrim(@valor)))
		begin
		 set @existe=1
		end
	else
		begin
		 set @existe=0
		end
go

--Procedimiento Activar
create proc usuario_login
	@email varchar(50),
	@clave varchar(50)
as 
	select u.idusuario, u.idrol, r.nombre as rol, u.nombre, u.estado
	from usuario u inner join rol r on u.idrol = r.idrol
	where u.email = @email and u.clave = Hashbytes('SHA2_256', @clave)