USE [parking]
GO

--Roles
insert into rol (nombre) values ('Administrador');
insert into rol (nombre) values ('Operario');

--Usuarios
INSERT INTO usuario  (idrol, nombre, tipo_documento, num_documento, direccion, telefono, email, clave, estado)
     VALUES (1, 'juan', 'Cedula', '456', 'españa', '789', 'juan@gmail.com', 0xC91BD9C288C0A7C5CA1BB807CBD5D89C5AB33764862EB46808417733DA2AF873, 1)
GO

INSERT INTO tipovehiculo (tipo, precio) VALUES ('Cicla', 1000);
INSERT INTO tipovehiculo (tipo, precio) VALUES ('Triciclo', 2000);
INSERT INTO tipovehiculo (tipo, precio) VALUES ('Carro', 3000);
INSERT INTO tipovehiculo (tipo, precio) VALUES ('Camion', 4000);
INSERT INTO tipovehiculo (tipo, precio) VALUES ('Tractomula', 5000);
INSERT INTO tipovehiculo (tipo, precio) VALUES ('Volqueta', 6000);
GO
