USE [master]
GO
/****** Object:  Database [ResortsUned]    Script Date: 6/04/2024 6:12:15 p. m. ******/
CREATE DATABASE [ResortsUned]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ResortsUned', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ResortsUned.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ResortsUned_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\ResortsUned_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ResortsUned] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ResortsUned].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ResortsUned] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ResortsUned] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ResortsUned] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ResortsUned] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ResortsUned] SET ARITHABORT OFF 
GO
ALTER DATABASE [ResortsUned] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ResortsUned] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ResortsUned] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ResortsUned] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ResortsUned] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ResortsUned] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ResortsUned] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ResortsUned] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ResortsUned] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ResortsUned] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ResortsUned] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ResortsUned] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ResortsUned] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ResortsUned] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ResortsUned] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ResortsUned] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ResortsUned] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ResortsUned] SET RECOVERY FULL 
GO
ALTER DATABASE [ResortsUned] SET  MULTI_USER 
GO
ALTER DATABASE [ResortsUned] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ResortsUned] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ResortsUned] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ResortsUned] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ResortsUned] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ResortsUned] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ResortsUned', N'ON'
GO
ALTER DATABASE [ResortsUned] SET QUERY_STORE = ON
GO
ALTER DATABASE [ResortsUned] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ResortsUned]
GO
/****** Object:  Table [dbo].[Articulo]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulo](
	[IdArticulo] [int] IDENTITY(1,1) NOT NULL,
	[IdCategoria] [int] NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Precio_Venta] [decimal](11, 2) NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
	[Imagen] [nvarchar](20) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ArticuloHotel]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticuloHotel](
	[IdAsignacion] [int] IDENTITY(1,1) NOT NULL,
	[IdHotel] [int] NULL,
	[IdArticulo] [int] NULL,
	[FechaAsignacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAsignacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Identificacion] [nvarchar](20) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[PrimerApellido] [nvarchar](100) NULL,
	[SegundoApellido] [nvarchar](100) NULL,
	[FechaNacimiento] [date] NULL,
	[Genero] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[Identificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[IdHotel] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NULL,
	[Direccion] [nvarchar](200) NULL,
	[Estado] [bit] NULL,
	[Telefono] [nvarchar](15) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdHotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [nvarchar](20) NULL,
	[IdArticulo] [int] NULL,
	[FechaPedido] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Articulo] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Categoria] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Articulo]  WITH CHECK ADD FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[ArticuloHotel]  WITH CHECK ADD FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[Articulo] ([IdArticulo])
GO
ALTER TABLE [dbo].[ArticuloHotel]  WITH CHECK ADD FOREIGN KEY([IdHotel])
REFERENCES [dbo].[Hotel] ([IdHotel])
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD FOREIGN KEY([IdArticulo])
REFERENCES [dbo].[Articulo] ([IdArticulo])
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([Identificacion])
GO
/****** Object:  StoredProcedure [dbo].[Articulo_activar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento Activar
CREATE PROCEDURE [dbo].[Articulo_activar]
@idarticulo INTEGER
AS
BEGIN
    UPDATE articulo
    SET estado = 1
    WHERE idarticulo = @idarticulo;
END
GO
/****** Object:  StoredProcedure [dbo].[Articulo_actualizar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento Actualizar
CREATE PROCEDURE [dbo].[Articulo_actualizar]
@idarticulo INTEGER,
@idcategoria INTEGER,
@nombre VARCHAR(100),
@precio_venta DECIMAL(11,2),
@descripcion VARCHAR(255),
@imagen VARCHAR(20)
AS
BEGIN
    UPDATE articulo
    SET idcategoria = @idcategoria,
        nombre = @nombre,
        precio_venta = @precio_venta,        
        descripcion = @descripcion,
        imagen = @imagen
    WHERE idarticulo = @idarticulo;
END
GO
/****** Object:  StoredProcedure [dbo].[Articulo_buscar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento Buscar
CREATE PROCEDURE [dbo].[Articulo_buscar]
@valor VARCHAR(50)
AS
BEGIN
    SELECT a.idarticulo AS ID, a.idcategoria, c.nombre AS Categoria,
    a.nombre AS Nombre, a.precio_venta AS Precio_Venta, a.descripcion AS Descripcion, a.imagen AS Imagen,
    a.estado AS Estado
    FROM articulo a
    INNER JOIN categoria c ON a.idcategoria = c.idcategoria
    WHERE a.nombre LIKE '%' + @valor + '%' OR a.descripcion LIKE '%' + @valor + '%'
    ORDER BY a.nombre ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[Articulo_BuscarConCategoria]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento Articulo_BuscarConCategoria
CREATE PROCEDURE [dbo].[Articulo_BuscarConCategoria]
@valor VARCHAR(50)
AS
BEGIN
    SELECT a.IdArticulo AS Id, c.Nombre AS Categoria,
           a.Nombre AS Nombre,
           a.Precio_Venta AS 'Precio Unidad'
    FROM Categoria c
    INNER JOIN Articulo a ON c.IdCategoria = a.IdCategoria
    WHERE a.nombre LIKE '%' + @valor + '%' OR a.descripcion LIKE '%' + @valor + '%'
    ORDER BY a.nombre ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[Articulo_desactivar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento Desactivar
CREATE PROCEDURE [dbo].[Articulo_desactivar]
@idarticulo INTEGER
AS
BEGIN
    UPDATE articulo
    SET estado = 0
    WHERE idarticulo = @idarticulo;
END
GO
/****** Object:  StoredProcedure [dbo].[Articulo_eliminar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento Eliminar
CREATE PROCEDURE [dbo].[Articulo_eliminar]
@idarticulo INTEGER
AS
BEGIN
    DELETE FROM articulo
    WHERE idarticulo = @idarticulo;
END
GO
/****** Object:  StoredProcedure [dbo].[Articulo_existe]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento existe
CREATE PROCEDURE [dbo].[Articulo_existe]
@valor VARCHAR(100),
@existe BIT OUTPUT
AS
BEGIN
    IF EXISTS (SELECT nombre FROM articulo WHERE nombre = LTRIM(RTRIM(@valor)))
        SET @existe = 1;
    ELSE
        SET @existe = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[Articulo_insertar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento Insertar
CREATE PROCEDURE [dbo].[Articulo_insertar]
@idcategoria INTEGER,
@nombre VARCHAR(100),
@precio_venta DECIMAL(11,2),
@descripcion VARCHAR(255),
@imagen VARCHAR(20)
AS
BEGIN
    INSERT INTO Articulo (idcategoria, nombre, precio_venta, descripcion, imagen)
    VALUES (@idcategoria, @nombre, @precio_venta, @descripcion, @imagen);
END
GO
/****** Object:  StoredProcedure [dbo].[Articulo_listar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento Listar
CREATE PROCEDURE [dbo].[Articulo_listar]
AS
BEGIN
    SELECT a.idarticulo AS ID, a.idcategoria, c.nombre AS Categoria,
    a.nombre AS Nombre, a.precio_venta AS Precio_Venta, a.descripcion AS Descripcion, a.imagen AS Imagen,
    a.estado AS Estado
    FROM articulo a
    INNER JOIN categoria c ON a.idcategoria = c.idcategoria
    ORDER BY a.idarticulo DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[ArticuloExisteConEsteNombre]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- Procedimiento para verificar si existe una articulo con un nombre dado
CREATE PROCEDURE [dbo].[ArticuloExisteConEsteNombre]
    @Nombre NVARCHAR(50),
    @IdArticulo INT,
    @Existe BIT OUTPUT
AS
BEGIN
    -- Verifica si existe alguna articulo con el nombre especificado y diferente ID
    IF EXISTS (SELECT 1 FROM Articulo WHERE Nombre = @Nombre AND IdArticulo != @IdArticulo)
        SET @Existe = 1;
    ELSE
        SET @Existe = 0;
END;

GO
/****** Object:  StoredProcedure [dbo].[Articulos_ObtenerConCategoria]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento ArticulosObtenerConCategoria
CREATE PROCEDURE [dbo].[Articulos_ObtenerConCategoria]
AS
BEGIN
    DECLARE @valor VARCHAR(50); -- Declare @valor variable
    SELECT a.IdArticulo AS Id, c.Nombre AS Categoria,
           a.Nombre AS Nombre,
           a.Precio_Venta AS 'Precio Unidad'
    FROM Categoria c
    INNER JOIN Articulo a ON c.IdCategoria = a.IdCategoria;
END;
GO
/****** Object:  StoredProcedure [dbo].[Articulos_ObtenerPorHotel]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento Articulos_ObtenerPorHotel
CREATE PROCEDURE [dbo].[Articulos_ObtenerPorHotel]
@valor VARCHAR(50)
AS
BEGIN
    SELECT a.IdArticulo AS Id, c.Nombre AS Categoria,
           a.Nombre AS Nombre,
           a.Precio_Venta AS 'Precio Unidad',
		   ah.IdAsignacion, 
		   ah.FechaAsignacion
    FROM Categoria c
    INNER JOIN Articulo a ON c.IdCategoria = a.IdCategoria
	INNER JOIN ArticuloHotel ah ON a.IdArticulo = ah.IdArticulo
    WHERE ah.IdHotel = @valor 
    ORDER BY a.nombre ASC;
END
GO
/****** Object:  StoredProcedure [dbo].[Categoria_activar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- Procedimiento para activar una categoría
CREATE PROCEDURE [dbo].[Categoria_activar]
    @idcategoria INT
AS
BEGIN
    -- Activa la categoría con el Id especificado (cambia el estado a 1)
    UPDATE categoria
    SET estado = 1
    WHERE idcategoria = @idcategoria;
END;

GO
/****** Object:  StoredProcedure [dbo].[Categoria_desactivar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- Procedimiento para desactivar una categoría
CREATE PROCEDURE [dbo].[Categoria_desactivar]
    @idcategoria INT
AS
BEGIN
    -- Desactiva la categoría con el Id especificado (cambia el estado a 0)
    UPDATE categoria
    SET estado = 0
    WHERE idcategoria = @idcategoria;
END;

GO
/****** Object:  StoredProcedure [dbo].[Categoria_eliminar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- Procedimiento para eliminar una categoría
CREATE PROCEDURE [dbo].[Categoria_eliminar]
    @idcategoria INT
AS
BEGIN
    -- Elimina la categoría con el Id especificado
    DELETE FROM categoria
    WHERE idcategoria = @idcategoria;
END;

GO
/****** Object:  StoredProcedure [dbo].[CategoriaActualizar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- Procedimiento para actualizar información de una categoría existente
CREATE PROCEDURE [dbo].[CategoriaActualizar]
    @IdCategoria INT,
    @Nombre NVARCHAR(50),
    @Descripcion NVARCHAR(100)    
AS
BEGIN
    -- Actualiza los campos de una categoría con el Id especificado
    UPDATE Categoria
    SET Nombre = @Nombre,
        Descripcion = @Descripcion        
    WHERE IdCategoria = @IdCategoria;
END;

GO
/****** Object:  StoredProcedure [dbo].[CategoriaBuscarPorId]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- Procedimiento para buscar una categoría por su Id
CREATE PROCEDURE [dbo].[CategoriaBuscarPorId]
    @IdCategoria INT
AS
BEGIN
    -- Selecciona información de la categoría con el Id especificado
    SELECT IdCategoria, Nombre, Descripcion, Estado
    FROM Categoria
    WHERE IdCategoria = @IdCategoria;
END;

GO
/****** Object:  StoredProcedure [dbo].[CategoriaBuscarPorNombre]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- Procedimiento para buscar categorías por su nombre
CREATE PROCEDURE [dbo].[CategoriaBuscarPorNombre]
    @Nombre NVARCHAR(50)
AS
BEGIN
    -- Selecciona información de las categorías que contienen el nombre especificado
    SELECT IdCategoria AS ID, Nombre, Descripcion, Estado
    FROM Categoria
    WHERE Nombre LIKE '%' + @Nombre + '%'
    ORDER BY Nombre ASC;
END;

GO
/****** Object:  StoredProcedure [dbo].[CategoriaExisteConEsteNombre]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- Procedimiento para verificar si existe una categoría con un nombre dado
CREATE PROCEDURE [dbo].[CategoriaExisteConEsteNombre]
    @Nombre NVARCHAR(50),
    @IdCategoria INT,
    @Existe BIT OUTPUT
AS
BEGIN
    -- Verifica si existe alguna categoría con el nombre especificado y diferente ID
    IF EXISTS (SELECT 1 FROM Categoria WHERE Nombre = @Nombre AND IdCategoria != @IdCategoria)
        SET @Existe = 1;
    ELSE
        SET @Existe = 0;
END;

GO
/****** Object:  StoredProcedure [dbo].[CategoriaInsertar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- Procedimiento para insertar una nueva categoría
CREATE PROCEDURE [dbo].[CategoriaInsertar]
    @Nombre NVARCHAR(50),
    @Descripcion NVARCHAR(100),
    @Estado BIT
AS
BEGIN
    -- Inserta una nueva fila en la tabla Categoria con los valores especificados
    INSERT INTO Categoria (Nombre, Descripcion, Estado)
    VALUES (@Nombre, @Descripcion, @Estado);
END;

GO
/****** Object:  StoredProcedure [dbo].[Categorias_Activas]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-------------------------------------------------------------------------------------
-- Procedimiento para listar todas las categorías
CREATE PROCEDURE [dbo].[Categorias_Activas]
AS
BEGIN
    -- Selecciona información de todas las categorías ordenadas por nombre
    SELECT IdCategoria, Nombre, Descripcion, Estado
    FROM Categoria Where Estado = 1
    ORDER BY Nombre;	
END;

GO
/****** Object:  StoredProcedure [dbo].[Categorias_Listar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento para listar todas las categorías
CREATE PROCEDURE [dbo].[Categorias_Listar]
AS
BEGIN
    -- Selecciona información de todas las categorías ordenadas por nombre
    SELECT IdCategoria, Nombre, Descripcion, Estado
    FROM Categoria
    ORDER BY Nombre;	
END;

GO
/****** Object:  StoredProcedure [dbo].[Cliente_Actualizar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para actualizar la información de un cliente
CREATE PROCEDURE [dbo].[Cliente_Actualizar]
    @Identificacion NVARCHAR(20),
    @Nombre NVARCHAR(100),
    @PrimerApellido NVARCHAR(100),
    @SegundoApellido NVARCHAR(100),
    @FechaNacimiento DATE,
    @Genero CHAR(1)
AS
BEGIN
    UPDATE Cliente
    SET Nombre = @Nombre,
        PrimerApellido = @PrimerApellido,
        SegundoApellido = @SegundoApellido,
        FechaNacimiento = @FechaNacimiento,
        Genero = @Genero
    WHERE Identificacion = @Identificacion;
END;

GO
/****** Object:  StoredProcedure [dbo].[Cliente_ConEsteNombre]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Procedimiento para verificar si existe una categoría con un nombre dado
Create PROCEDURE [dbo].[Cliente_ConEsteNombre]    
    @Id NVARCHAR(50), 
	@Nombre NVARCHAR(50),
    @Existe BIT OUTPUT
AS
BEGIN
    -- Verifica si existe alguna categoría con el nombre especificado y diferente ID
    IF EXISTS (SELECT 1 FROM Cliente WHERE Nombre = @Nombre AND Identificacion != @Id)
        SET @Existe = 1;
    ELSE
        SET @Existe = 0;
END;

GO
/****** Object:  StoredProcedure [dbo].[Cliente_Eliminar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para eliminar un cliente por su Identificacion
CREATE PROCEDURE [dbo].[Cliente_Eliminar]
    @Identificacion NVARCHAR(20)
AS
BEGIN
    DELETE FROM Cliente WHERE Identificacion = @Identificacion;
END;

GO
/****** Object:  StoredProcedure [dbo].[Cliente_Existe]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para verificar si un cliente existe por su Identificacion
CREATE PROCEDURE [dbo].[Cliente_Existe]
    @Identificacion NVARCHAR(20),
    @Existe BIT OUTPUT
AS
BEGIN
    SET @Existe = 0;
    IF EXISTS (SELECT 1 FROM Cliente WHERE Identificacion = @Identificacion)
        SET @Existe = 1;
END;

GO
/****** Object:  StoredProcedure [dbo].[Cliente_Insertar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para insertar un nuevo cliente
CREATE PROCEDURE [dbo].[Cliente_Insertar]
    @Identificacion NVARCHAR(20),
    @Nombre NVARCHAR(100),
    @PrimerApellido NVARCHAR(100),
    @SegundoApellido NVARCHAR(100),
    @FechaNacimiento DATE,
    @Genero CHAR(1)
AS
BEGIN
    INSERT INTO Cliente (Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Genero)
    VALUES (@Identificacion, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Genero);
END;

GO
/****** Object:  StoredProcedure [dbo].[Cliente_PorId]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Cliente_PorId]
    @IdCliente NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT Identificacion, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, Genero
    FROM Cliente
    WHERE Identificacion = @IdCliente;
END;
GO
/****** Object:  StoredProcedure [dbo].[Clientes]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento almacenado para obtener todos los clientes
CREATE PROCEDURE [dbo].[Clientes]
AS
BEGIN
    SELECT * FROM Cliente order by cliente.Nombre;
END;

GO
/****** Object:  StoredProcedure [dbo].[ClientesPorNombre]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para obtener clientes por nombre
CREATE PROCEDURE [dbo].[ClientesPorNombre]
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Cliente WHERE Nombre LIKE '%' + @Nombre + '%';
END;

GO
/****** Object:  StoredProcedure [dbo].[DeleteArticuloHotel]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteArticuloHotel]
    @IdAsignacion INT
AS
BEGIN
    DELETE FROM ArticuloHotel WHERE IdAsignacion = @IdAsignacion
END;

GO
/****** Object:  StoredProcedure [dbo].[Hotel_Activar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento almacenado para activar un hotel (cambiar su Estado a 1)
CREATE PROCEDURE [dbo].[Hotel_Activar]
    @IdHotel INT
AS
BEGIN
    UPDATE Hotel
    SET Estado = 1
    WHERE IdHotel = @IdHotel;
END;
GO
/****** Object:  StoredProcedure [dbo].[Hotel_Actualizar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para actualizar la información de un hotel
CREATE PROCEDURE [dbo].[Hotel_Actualizar]
    @IdHotel INT,
    @Nombre NVARCHAR(100),
    @Direccion NVARCHAR(200),
    @Estado BIT,
    @Telefono NVARCHAR(15)
AS
BEGIN
    UPDATE Hotel
    SET Nombre = @Nombre,
        Direccion = @Direccion,
        Estado = @Estado,
        Telefono = @Telefono
    WHERE IdHotel = @IdHotel;
END;

GO
/****** Object:  StoredProcedure [dbo].[Hotel_ConEsteNombre]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Procedimiento para verificar si existe un Hotel con un nombre dado
Create PROCEDURE [dbo].[Hotel_ConEsteNombre]    
    @Id NVARCHAR(50), 
	@Nombre NVARCHAR(50),
    @Existe BIT OUTPUT
AS
BEGIN
    -- Verifica si existe alguna categoría con el nombre especificado y diferente ID
    IF EXISTS (SELECT 1 FROM Hotel WHERE Nombre = @Nombre AND IdHotel != @Id)
        SET @Existe = 1;
    ELSE
        SET @Existe = 0;
END;
GO
/****** Object:  StoredProcedure [dbo].[Hotel_Desactivar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para desactivar un hotel (cambiar su Estado a 0)
CREATE PROCEDURE [dbo].[Hotel_Desactivar]
    @IdHotel INT
AS
BEGIN
    UPDATE Hotel
    SET Estado = 0
    WHERE IdHotel = @IdHotel;
END;

GO
/****** Object:  StoredProcedure [dbo].[Hotel_Eliminar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para eliminar un hotel por su IdHotel
CREATE PROCEDURE [dbo].[Hotel_Eliminar]
    @IdHotel INT
AS
BEGIN
    DELETE FROM Hotel WHERE IdHotel = @IdHotel;
END;

GO
/****** Object:  StoredProcedure [dbo].[Hotel_Existe]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para verificar si un hotel existe por su Nombre
CREATE PROCEDURE [dbo].[Hotel_Existe]
    @Nombre NVARCHAR(100),
    @Existe BIT OUTPUT
AS
BEGIN
    SET @Existe = 0;
    IF EXISTS (SELECT 1 FROM Hotel WHERE Nombre = @Nombre)
        SET @Existe = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[Hotel_Insertar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Procedimiento almacenado para insertar un nuevo hotel
CREATE PROCEDURE [dbo].[Hotel_Insertar]
    @Nombre NVARCHAR(100),
    @Direccion NVARCHAR(200),
    @Estado BIT,
    @Telefono NVARCHAR(15)
AS
BEGIN
    INSERT INTO Hotel (Nombre, Direccion, Estado, Telefono)
    VALUES (@Nombre, @Direccion, @Estado, @Telefono);
END;

GO
/****** Object:  StoredProcedure [dbo].[Hoteles]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para obtener todos los hoteles
CREATE PROCEDURE [dbo].[Hoteles]
AS
BEGIN
    SELECT * FROM Hotel;
END;

GO
/****** Object:  StoredProcedure [dbo].[Hoteles_PorNombre]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento almacenado para obtener hoteles por nombre
CREATE PROCEDURE [dbo].[Hoteles_PorNombre]
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Hotel WHERE Nombre LIKE '%' + @Nombre + '%';
END;

GO
/****** Object:  StoredProcedure [dbo].[InsertArticuloHotel]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertArticuloHotel]
    @IdHotel INT,
    @IdArticulo INT,
    @Fecha AS DATETIME
AS
BEGIN
    INSERT INTO ArticuloHotel (IdHotel, IdArticulo, FechaAsignacion)
    VALUES (@IdHotel, @IdArticulo, @Fecha)
END;

GO
/****** Object:  StoredProcedure [dbo].[Pedido_Insertar]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Pedido_Insertar]
    @IdCliente NVARCHAR(20),
    @IdArticulo INT,
    @FechaPedido DATE
AS
BEGIN
    INSERT INTO Pedido (IdCliente, IdArticulo, FechaPedido)
    VALUES (@IdCliente, @IdArticulo, @FechaPedido);
END;

GO
/****** Object:  StoredProcedure [dbo].[Pedidos_BorrarPorIdCliente]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Pedidos_BorrarPorIdCliente]
    @IdCliente NVARCHAR(20)
AS
BEGIN
    DELETE FROM Pedido WHERE IdCliente = @IdCliente;
END;

GO
/****** Object:  StoredProcedure [dbo].[Pedidos_PorCliente]    Script Date: 6/04/2024 6:12:16 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento Pedidos_PorCliente
CREATE PROCEDURE [dbo].[Pedidos_PorCliente]
@valor VARCHAR(50)
AS
BEGIN
	SELECT a.IdArticulo AS IdArticulo, c.IdCategoria, c.Nombre AS Categoria,
           a.Nombre AS Nombre, p.IdCliente,
           a.Precio_Venta AS 'Precio_Unidad',
		   p.IdPedido, p.FechaPedido, p.IdArticulo
    FROM Categoria c
    INNER JOIN Articulo a ON c.IdCategoria = a.IdCategoria
	INNER JOIN Pedido p ON a.IdArticulo = p.IdArticulo
    WHERE p.IdCliente = @valor  
    ORDER BY a.nombre ASC;
END

GO
USE [master]
GO
ALTER DATABASE [ResortsUned] SET  READ_WRITE 
GO
