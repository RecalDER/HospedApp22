-- CALLS
DELIMITER ;
uSE HospedApp;
-- -------------------
CALL AltaHotel (1, 'HotelLol', 'domicilio??', 'HotelLol123@gmail.com', 'contrasenia', 5 );
CALL AltaCuarto(1, 1, 1, TRUE , 9, 'ta caro porq lo vale');
CALL AltaCama (1,'SEX', 2);
CALL AltaTcama (1, 1, 1);

-- ------------------

CALL registrarCliente(1,'Roberto', 'Robertinho', 'elpepe1@gmail.com', 'contrasenia123' );

-- ------------------

CALL altaReserva(1, 1, 14/10/2004,14/12/2004, 1,1, 9);
CALL cerrarEstadiaHotel(1, 1, 10);
CALL cerrarEstadiaCliente(1, 1, 10, 'se portaba bn');


/********************/
SELECT CantidadPersonas (1) 'Cantodidad de personas que se pueden enfiestar en el cuarto 1';