-- CALLS

DELIMITER ;

uSE HospedApp;

-- -------------------

CALL AltaHotel (1,'HotelLol','domicilio??','HotelLol123@gmail.com','contrasenia',5);

SET @idCuarto = NULL;

CALL AltaCuarto(1, 1, TRUE , 9, 'ta caro porq lo vale',@idCuarto);

CALL AltaCama (1,'SEX', 2);

CALL AltaTcama (1, 1, 1);

-- ------------------

CALL registrarCliente(1,'Roberto','Robertinho','elpepe1@gmail.com','contrasenia123'
    );

-- ------------------

CALL altaReserva(1, 1, '2004/10/14','2004/12/14', 1,1, 9);

CALL cerrarEstadiaHotel(1, 1, 10);

CALL cerrarEstadiaCliente(1, 1, 10, 'El hotel está bien');

/********************/

SELECT
    CantidadPersonas (1) 'Cantodidad de personas que se pueden enfiestar en el cuarto 1';

/*pal trigger*/

CALL altaReserva(2, 1, '2004/10/14', '2004/12/14', 1,1, 9);
CALL altaReserva(3, 1, '2004/10/14', '2004/12/14', 1,2, 9);