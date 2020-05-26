DELIMITER $$
	CREATE PROCEDURE CrearConferencia(nombre VARCHAR(100))
	BEGIN
	
	SET @cod_conferencia= CONCAT('CLM', (SELECT `AUTO_INCREMENT` FROM  INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'db_expressjs' AND   TABLE_NAME   = 'conferenciaslm';));

	INSERT INTO db_expressjs.conferenciaslm (conferencia, cod_conferencia)	VALUES (nombre,@cod_conferencia);

	END $$
DELIMITER ;

CALL CrearConferencia('Seminario actualización en programación');

