/*Se pide desarrollar un trigger para que al momento de ingresar una reserva, 
si la fecha de inicio se encuentra entre la fecha de inicio y fin de otra reserva 
para el mismo cuarto con reserva no cancelada, no se debe permitir el INSERT mostrando
la leyenda “Fecha Superpuesta”. 

También se tiene que tener en cuenta que un cliente 
no puede tener propias sin cancelar de manera superpuestas, es decir, al momento de 
reservar se tiene que verificar que ese mismo cliente no posea reservas propias no 
canceladas en otros lados, en ese caso también se tiene que mostrar la leyenda “El cliente ya posee otra reserva para esa fecha”.*/

DELIMITER $$
CREATE TRIGGER befInsReserva BEFORE INSERT ON Reserva
FOR EACH ROW
BEGIN

    IF (EXISTS  (SELECT *
                FROM    Reserva
                WHERE   NEW.inicio BETWEEN inicio AND fin 
                AND     NEW.idCuarto = idCuarto AND NOT cancelado AND NEW.idCliente = idCliente)) THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Fecha Superpuesta';
	END IF;
    	    IF (EXISTS  (SELECT *
                FROM    Reserva
                WHERE   NEW.inicio BETWEEN inicio AND fin 
                AND NOT cancelado AND NEW.idCliente = idCliente)) THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'El cliente ya posee otra reserva para esa fecha';
	END IF;
END $$

