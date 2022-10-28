USE HospedApp;

-- USUARIO
DROP USER IF EXISTS 'Usuario' @ '%';
CREATE USER 'Usuario' @ '%' IDENTIFIED BY 'passUsuario';
-- Puede ver toda la info del sistema, menos la contraseña de los hoteles.
GRANT SELECT(idHotel, nombre, domicilio, email, estrellas) ON HospedApp.Hotel TO 'Usuario' @ '%';
GRANT SELECT ON HospedApp.Cuarto TO 'Usuario' @ '%';
GRANT SELECT ON HospedApp.Reserva TO 'Usuario' @ '%'; 
GRANT SELECT ON HospedApp.Tcama TO 'Usuario' @ '%';
GRANT SELECT ON HospedApp.Cama TO 'Usuario' @ '%';
GRANT SELECT ON HospedApp.Cliente TO 'Usuario' @ '%';

-- Puede calificar a su estadía/reserva (INSERT y/o UPDATE según corresponda su modelo)
GRANT INSERT(calificacionCliente) ON HospedApp.Reserva TO 'Usuario' @ '%';
GRANT INSERT(calificacionHotel) ON HospedApp.Reserva TO 'Usuario' @ '%';

-- Puede dar de alta reservas y cancelarlas

GRANT INSERT, UPDATE ON HospedApp.Reserva TO 'Usuario' @ '%';

--Pueden modificar sus contraseñas.

GRANT UPDATE(contrasenia) ON HospedApp.Cliente TO 'Usuario' @ '%';

-- -----------------------------------------------------------------------------------
-- HOTELES
DROP USER IF EXISTS 'Hoteles' @ 'localhost';
CREATE USER 'Hoteles' @ 'localhost' IDENTIFIED BY 'passHoteles';

--Pueden ver todo menos las contraseñas de los clientes.

GRANT SELECT ON HospedApp.Hotel TO 'Hoteles' @ 'localhost';
GRANT SELECT ON HospedApp.Cuarto TO 'Hoteles' @ 'localhost';
GRANT SELECT ON HospedApp.Reserva TO 'Hoteles' @ 'localhost';
GRANT SELECT ON HospedApp.Tcama TO 'Hoteles' @ 'localhost';
GRANT SELECT ON HospedApp.Cliente(idCliente, nombre, apellido, email) TO 'Hoteles' @ 'localhost';
GRANT SELECT ON HospedApp.Cama TO 'Hoteles' @ 'localhost';

--Pueden dar de alta cuartos, modificar sus costos por noche.

GRANT INSERT, UPDATE(costoNoche) ON HospedApp.Cuarto TO 'Hoteles' @ 'localhost';

--Pueden modificar su contraseña.

GRANT UPDATE(contrasenia) ON HospedApp.Hotel TO 'Hoteles' @ 'localhost';
-- ---------------------------------------------------------------------------
-- SISTEMA
DROP USER IF EXISTS 'Sistema' @ 'localhost';
CREATE USER 'Sistema' @ 'localhost' IDENTIFIED BY 'passSistema';

--Puede ver todo
GRANT SELECT ON HospedApp.* TO 'Sistema' @ 'localhost';

--Puede dar de alta camas, hoteles y clientes.
GRANT INSERT ON HospedApp.Cama TO 'Sistema' @ 'localhost';
GRANT INSERT ON HospedApp.Hotel TO 'Sistema' @ 'localhost';
GRANT INSERT ON HospedApp.Cliente TO 'Sistema' @ 'localhost';



