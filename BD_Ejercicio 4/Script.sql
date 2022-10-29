-- MySQL Script generated by MySQL Workbench
-- Fri Oct 28 01:48:53 2022
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Ejercicio4BD
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema Ejercicio4BD
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Ejercicio4BD` DEFAULT CHARACTER SET utf8 ;
USE `Ejercicio4BD` ;

-- -----------------------------------------------------
-- Table `Ejercicio4BD`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Ejercicio4BD`.`Usuario` (
  `Codigo` VARCHAR(25) NOT NULL,
  `Correo` VARCHAR(50) NOT NULL,
  `Clave` VARCHAR(40) NOT NULL,
  PRIMARY KEY (`Codigo`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
