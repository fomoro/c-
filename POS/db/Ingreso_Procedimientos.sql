-- Procedimiento listar
CREATE PROC ingreso_listar
AS
SELECT
    i.idingreso AS ID,
    i.idusuario,
    u.nombre AS Usuario,
    p.nombre AS Proveedor,
    i.tipo_comprobante AS Tipo_Comprobante,
    i.serie_comprobante AS Serie,
    i.num_comprobante AS Numero,
    i.fecha AS Fecha,
    i.impuesto AS Impuesto,
    i.total AS Total,
    i.estado AS Estado
FROM
    ingreso i
INNER JOIN
    usuario u ON i.idusuario = u.idusuario
INNER JOIN
    persona p ON i.idproveedor = p.idpersona
ORDER BY
    i.idingreso DESC;
GO

-- Procedimiento buscar
CREATE PROC ingreso_buscar
    @valor VARCHAR(50)
AS
SELECT
    i.idingreso AS ID,
    i.idusuario,
    u.nombre AS Usuario,
    p.nombre AS Proveedor,
    i.tipo_comprobante AS Tipo_Comprobante,
    i.serie_comprobante AS Serie,
    i.num_comprobante AS Numero,
    i.fecha AS Fecha,
    i.impuesto AS Impuesto,
    i.total AS Total,
    i.estado AS Estado
FROM
    ingreso i
INNER JOIN
    usuario u ON i.idusuario = u.idusuario
INNER JOIN
    persona p ON i.idproveedor = p.idpersona
WHERE
    i.num_comprobante LIKE '%' + @valor + '%'
    OR p.nombre LIKE '%' + @valor + '%'
ORDER BY
    i.fecha ASC;
GO

-- Procedimiento anular
CREATE PROC ingreso_anular
    @idingreso INT
AS
UPDATE
    ingreso
SET
    estado = 'Anulado'
WHERE
    idingreso = @idingreso;
GO

CREATE TYPE type_detalle_ingreso AS TABLE
(
    idarticulo INT,
    codigo VARCHAR(50),
    articulo VARCHAR(100),
    cantidad INT,
    precio DECIMAL(11, 2),
    importe DECIMAL(11, 2)
);
GO

-- Procedimiento insertar
CREATE PROC ingreso_insertar
    @idusuario INT,
    @idproveedor INT,
    @tipo_comprobante VARCHAR(20),
    @serie_comprobante VARCHAR(7),
    @num_comprobante VARCHAR(10),
    @impuesto DECIMAL(4, 2),
    @total DECIMAL(11, 2),
    @detalle type_detalle_ingreso READONLY
AS
BEGIN
    -- Insertamos en la cabecera
    INSERT INTO
        ingreso (idproveedor, idusuario, tipo_comprobante, serie_comprobante,
        num_comprobante, fecha, impuesto, total, estado)
    VALUES
        (@idproveedor, @idusuario, @tipo_comprobante, @serie_comprobante,
        @num_comprobante, GETDATE(), @impuesto, @total, 'Aceptado');
    
    -- Insertar los detalles
    INSERT INTO
        detalle_ingreso (idingreso, idarticulo, cantidad, precio)
    SELECT
        @@IDENTITY, d.idarticulo, d.cantidad, d.precio
    FROM
        @detalle d;
END
GO
