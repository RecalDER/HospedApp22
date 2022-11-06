uSE HospedApp;
-- Realizar los SP para dar de alta todas las entidades menos las tablas Cliente y Reserva.

DELIMITER $$
DROP PROCEDURE IF EXISTS AltaHotel $$
CREATE PROCEDURE AltaHotel (unidHotel SMALLINT,
							unnombre VARCHAR(25),
							undomicilio VARCHAR(35),
						    unemail VARCHAR(25),
							uncontrasenia CHAR(64),
							unestrellas TINYINT UNSIGNED)
BEGIN
   INSERT INTO Hotel (idHotel, nombre, domicilio, email, contrasenia, estrellas)
      VALUES(unidHotel, unnombre, undomicilio, unemail, uncontrasenia, unestrellas);

END $$


DELIMITER $$
DROP PROCEDURE IF EXISTS AltaCuarto $$
CREATE PROCEDURE AltaCuarto (unidHotel SMALLINT,
							 unnumCuarto TINYINT UNSIGNED,
							 uncochera BOOLEAN,
							 uncostoNoche DECIMAL(7.2),
							 undescripcion VARCHAR(60), OUT unidCuarto SMALLINT )
BEGIN
    INSERT INTO Cuarto ( idHotel, numCuarto, cochera, costoNoche, descripcion)
    VALUES(unidHotel, unnumCuarto, uncochera, uncostoNoche, undescripcion);

    SET unidCuarto = LAST_INSERT_ID();  

END $$



DELIMITER $$
DROP PROCEDURE IF EXISTS AltaTcama $$
CREATE PROCEDURE AltaTcama (unidTipoCama TINYINT,
							unidCuarto SMALLINT,uncantDeCamas TINYINT)
BEGIN
      INSERT INTO Tcama (idTipoCama, idCuarto, cantDeCamas)
      VALUES(unidTipoCama, unidCuarto, uncantDeCamas);

END $$


DELIMITER $$
DROP PROCEDURE IF EXISTS AltaCama $$
CREATE PROCEDURE AltaCama (unidTipoCama TINYINT,
                           untipoCama VARCHAR (15),
                           uncantPersonas TINYINT)
BEGIN
      INSERT INTO Cama (idTipoCama, tipoCama, cantPersonas)
      VALUES(unidTipoCama, untipoCama, uncantPersonas);

END $$


-- Se pide hacer el SP ‘registrarCliente’ que reciba los datos del cliente. Es importante guardar encriptada la contraseña del cliente usando SHA256.

DELIMITER $$
DROP PROCEDURE IF EXISTS registrarCliente $$
CREATE PROCEDURE registrarCliente (unidCliente MEDIUMINT,
								   unnombre VARCHAR(25),
                                   unapellido VARCHAR(25),
                                   unemail VARCHAR(25),
								   uncontrasenia CHAR(64))
BEGIN
      INSERT INTO Cliente (idCliente, nombre, apellido, email, contrasenia)
      VALUES(unidCliente, unnombre, unapellido, unemail, SHA2(contrasenia, 256));
END $$
                                                                   
-- Se pide hacer el SP ‘altaReserva’ que reciba los datos no opcionales y haga el alta de una estadia. Hacer el SP ‘cerrarEstadiaHotel’ que reciba los parámetros necesarios y una calificación por parte del hotel. Hacer el SP ‘cerrarEstadiaCliente’ que reciba los parámetros necesarios, una calificación por parte del cliente y un comentario. 

DELIMITER $$
DROP PROCEDURE IF EXISTS altaReserva $$
CREATE PROCEDURE altaReserva (unidReserva INT, unidHotel VARCHAR (15), uninicio DATE, unfin DATE, unidCliente MEDIUMINT, unidCuarto SMALLINT, uncostoNoche DECIMAL(7,2))
BEGIN
    INSERT INTO Reserva (idReserva, idHotel, inicio,fin,idCliente,idCuarto,costoNoche)
    VALUES(unidReserva, unidHotel, uninicio,unfin,unidCliente,unidCuarto,uncostoNoche);
END $$


DELIMITER $$
DROP PROCEDURE IF EXISTS cerrarEstadiaHotel $$
CREATE PROCEDURE cerrarEstadiaHotel(unidReserva INT, unidHotel SMALLINT,  uncalificacionHotel TINYINT)

BEGIN
   IF EXISTS (SELECT * FROM Reserva WHERE NOT cancelado AND  idReserva = unidReserva) THEN
    UPDATE Reserva
    SET    calificacionHotel = uncalificacionHotel
    WHERE  idReserva = unidReserva AND idHotel = unidHotel;
end if;
END $$


DELIMITER $$
DROP PROCEDURE IF EXISTS cerrarEstadiaCliente  $$
CREATE PROCEDURE cerrarEstadiaCliente (unidReserva INT, unidHotel SMALLINT,  uncalificacionCliente TINYINT, undescripcion VARCHAR(60))

    
BEGIN
IF EXISTS (SELECT * FROM Reserva WHERE NOT cancelado AND idReserva = unidReserva ) THEN
    UPDATE Reserva
    SET     calificacionCliente = uncalificacionCliente,
            descripcion = undescripcion
    WHERE  idReserva = unidReserva AND idHotel = unidHotel;
    end if;
END $$



-- Se pide hacer el SF ‘CantidadPersonas’ que reciba por parámetro un identificador de cuarto, la función tiene que devolver la cantidad de personas que pueden dormir en el cuarto: CANT PERSONAS = SUMATORIA(PERSONAS POR CAMA).

DELIMITER $$
DROP FUNCTION IF EXISTS CantidadPersonas $$
CREATE FUNCTION CantidadPersonas (unidCuarto SMALLINT)
                                   		RETURNS INT
READS SQL DATA
BEGIN
DECLARE cantPersonitas INT;

    SELECT SUM(cantPersonas * cantDeCamas) INTO cantPersonitas
    FROM Cama C
    JOIN Tcama T ON C.idTipoCama = T.idTipoCama
    WHERE idCuarto =  unidCuarto;
        
    RETURN cantPersonitas;
END $$