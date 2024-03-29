-- Active: 1646654372192@@127.0.0.1@3306@hospedapp
DROP DATABASE IF EXISTS HospedApp;

CREATE DATABASE HospedApp;

USE HospedApp;

CREATE TABLE
    Hotel(
        idHotel SMALLINT NOT NULL,
        nombre VARCHAR(25) NOT NULL,
        domicilio VARCHAR(25) NOT NULL,
        email VARCHAR(25) NOT NULL,
        contrasenia CHAR(64) NOT NULL,
        estrellas TINYINT UNSIGNED NOT NULL,
        PRIMARY KEY (idHotel)
    );

CREATE TABLE
    cliente(
        idCliente MEDIUMINT NOT NULL,
        nombre VARCHAR(25) NOT NULL,
        apellido VARCHAR(25) NOT NULL,
        email VARCHAR(25) NOT NULL,
        contrasenia CHAR(64) NOT NULL,
        PRIMARY KEY (idCliente)
    );

CREATE TABLE
    Cama(
        idCama TINYINT NOT NULL,
        tipoCama VARCHAR(15) NOT NULL,
        cantPersonas TINYINT NOT NULL,
        PRIMARY KEY (idCama)
    );

CREATE TABLE
    Cuarto(
        numCuarto TINYINT UNSIGNED NOT NULL,
        idHotel SMALLINT NOT NULL,
        idCuarto SMALLINT auto_increment NOT NULL,
        cochera BOOLEAN NOT NULL,
        costoNoche DECIMAL(7, 2) NOT NULL,
        descripcion VARCHAR(60) NULL,
        PRIMARY KEY (idCuarto),
        CONSTRAINT fk_cuarto_idHotel FOREIGN KEY (idHotel) REFERENCES Hotel (idHotel)
    );

CREATE TABLE
    Reserva(
        idReserva INT NOT NULL,
        idHotel SMALLINT NOT NULL,
        inicio DATE NOT NULL,
        fin DATE NOT NULL,
        idCliente MEDIUMINT NOT NULL,
        idCuarto SMALLINT auto_increment NOT NULL,
        costoNoche DECIMAL(7, 2) NOT NULL,
        calificacionCliente TINYINT UNSIGNED NULL,
        calificacionHotel TINYINT UNSIGNED NULL,
        descripcion VARCHAR(60) NULL,
        cancelado BOOLEAN DEFAULT FALSE NOT NULL,
        PRIMARY KEY (idReserva),
        CONSTRAINT fk_Reserva_idhotel FOREIGN KEY(idHotel) REFERENCES Hotel (idHotel),
        CONSTRAINT fk_Reserva_idcliente FOREIGN KEY(idCliente) REFERENCES Cliente (idCliente),
        CONSTRAINT fk_Reserva_idcuarto FOREIGN KEY(idCuarto) REFERENCES Cuarto (idCuarto)
    );

CREATE TABLE
    Tcama(
        idCama TINYINT NOT NULL,
        idcuarto SMALLINT auto_increment NOT NULL,
        cantDeCamas TINYINT NOT NULL,
        PRIMARY KEY (idCama, idCuarto),
        CONSTRAINT fk_Tcama_idCama FOREIGN KEY (idCama) REFERENCES Cama (idCama),
        CONSTRAINT fk_Tcama_idcuarto FOREIGN KEY (idCuarto) REFERENCES Cuarto (idCuarto)
    );
    