-- --------------------------------------------------------
-- Host:                         10.77.76.95
-- Versión del servidor:         Microsoft SQL Server 2019 (RTM-CU8-GDR) (KB4583459) - 15.0.4083.2
-- SO del servidor:              Linux (Ubuntu 18.04.5 LTS) <X64>
-- HeidiSQL Versión:             11.2.0.6213
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES  */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para pong
CREATE DATABASE IF NOT EXISTS "pong";
USE "pong";

-- Volcando estructura para tabla pong.actividad
CREATE TABLE IF NOT EXISTS "actividad" (
	"fecha" DATETIME NOT NULL,
	"dispositivoid" BIGINT NOT NULL,
	"estadoid" BIGINT NOT NULL,
	PRIMARY KEY ("fecha"),
	FOREIGN KEY INDEX "FK_actividad_estado" ("estadoid"),
	FOREIGN KEY INDEX "FK_actividad_dispositivo" ("dispositivoid"),
	CONSTRAINT "FK_actividad_estado" FOREIGN KEY ("estadoid") REFERENCES "estado" ("id") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_actividad_dispositivo" FOREIGN KEY ("dispositivoid") REFERENCES "dispositivo" ("id") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla pong.dispositivo
CREATE TABLE IF NOT EXISTS "dispositivo" (
	"id" BIGINT NOT NULL,
	"dispositivo" VARCHAR(50) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"ip" VARCHAR(20) NOT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	"chequearpreviamenteid" BIGINT NOT NULL,
	"grupoid" BIGINT NOT NULL,
	"eliminado" BIGINT NOT NULL,
	PRIMARY KEY ("id"),
	FOREIGN KEY INDEX "FK_dispositivo_grupo" ("grupoid"),
	FOREIGN KEY INDEX "FK_dispositivo_dispositivo1" ("chequearpreviamenteid"),
	CONSTRAINT "FK_dispositivo_grupo" FOREIGN KEY ("grupoid") REFERENCES "grupo" ("id") ON UPDATE NO_ACTION ON DELETE NO_ACTION,
	CONSTRAINT "FK_dispositivo_dispositivo1" FOREIGN KEY ("chequearpreviamenteid") REFERENCES "dispositivo" ("id") ON UPDATE NO_ACTION ON DELETE NO_ACTION
);

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla pong.estado
CREATE TABLE IF NOT EXISTS "estado" (
	"id" BIGINT NOT NULL,
	"estado" VARCHAR(50) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	PRIMARY KEY ("id")
);

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para tabla pong.grupo
CREATE TABLE IF NOT EXISTS "grupo" (
	"id" BIGINT NOT NULL,
	"grupo" VARCHAR(50) NULL DEFAULT NULL COLLATE 'SQL_Latin1_General_CP1_CI_AS',
	PRIMARY KEY ("id")
);

-- La exportación de datos fue deseleccionada.

-- Volcando estructura para procedimiento pong.procListDispositivo
DELIMITER //
CREATE PROCEDURE procListDispositivo
AS
BEGIN

SELECT d.id AS ID, d.ip AS IP, dd.ip AS chequearPreviamenteIP
FROM pong.[dbo].dispositivo d
inner join pong.[dbo].dispositivo dd on dd.id = d.chequearpreviamenteid
WHERE d.eliminado = 0

END//
DELIMITER ;

-- Volcando estructura para procedimiento pong.procListStatus
DELIMITER //
CREATE PROCEDURE procListStatus
AS
BEGIN

SELECT d.dispositivo, d.ip, e.estado, g.grupo, a.fecha FROM
(SELECT d.id AS dispositivoid, MAX(a.fecha) maxfecha
FROM actividad a 
INNER JOIN dispositivo d ON a.dispositivoid = d.id
GROUP BY d.id) act
INNER JOIN actividad a ON act.maxfecha = a.fecha
INNER JOIN dispositivo d ON a.dispositivoid = d.id
INNER JOIN estado e ON a.estadoid = e.id
INNER JOIN grupo g ON d.grupoid = g.id
WHERE d.eliminado = 0
ORDER BY estado desc, grupo, dispositivo

END//
DELIMITER ;

-- Volcando estructura para procedimiento pong.procListStatusInactivo
DELIMITER //
CREATE PROCEDURE procListStatusInactivo AS 
BEGIN

SELECT d.dispositivo, d.ip, e.estado, g.grupo, a.fecha FROM
(SELECT d.id AS dispositivoid, MAX(a.fecha) maxfecha
FROM actividad a 
INNER JOIN dispositivo d ON a.dispositivoid = d.id
GROUP BY d.id) act
INNER JOIN actividad a ON act.maxfecha = a.fecha
INNER JOIN dispositivo d ON a.dispositivoid = d.id
INNER JOIN estado e ON a.estadoid = e.id
INNER JOIN grupo g ON d.grupoid = g.id
WHERE d.eliminado = 0 AND e.id = 0
ORDER BY estado desc, grupo, dispositivo

END
//
DELIMITER ;

-- Volcando estructura para procedimiento pong.procSetEstadoDispositivo
DELIMITER //
CREATE PROCEDURE procSetEstadoDispositivo
@dispositivoid BIGINT,
@estadoid BIGINT
AS
BEGIN

INSERT INTO pong.[dbo].actividad VALUES (CURRENT_TIMESTAMP,@dispositivoid, @estadoid);

END//
DELIMITER ;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
