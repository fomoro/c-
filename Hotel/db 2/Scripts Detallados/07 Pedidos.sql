-- Procedimiento Pedidos_PorCliente
CREATE PROCEDURE Pedidos_PorCliente
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

CREATE PROCEDURE dbo.Pedidos_BorrarPorIdCliente
    @IdCliente NVARCHAR(20)
AS
BEGIN
    DELETE FROM Pedido WHERE IdCliente = @IdCliente;
END;
GO

CREATE PROCEDURE dbo.Pedido_Insertar
    @IdCliente NVARCHAR(20),
    @IdArticulo INT,
    @FechaPedido DATE
AS
BEGIN
    INSERT INTO Pedido (IdCliente, IdArticulo, FechaPedido)
    VALUES (@IdCliente, @IdArticulo, @FechaPedido);
END;
GO
