-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema GardenShop
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema GardenShop
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `GardenShop` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
USE `GardenShop` ;

-- -----------------------------------------------------
-- Table `GardenShop`.`User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GardenShop`.`User` (
  `idUser` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `Surname` VARCHAR(45) NOT NULL,
  `Username` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(45) NOT NULL,
  `PhoneNumber` VARCHAR(45) NOT NULL,
  `isAdmin` TINYINT NOT NULL,
  `Active` TINYINT NOT NULL,
  `Language` INT NOT NULL,
  `Theme` INT NOT NULL,
  PRIMARY KEY (`idUser`))
ENGINE = InnoDB;
-- -----------------------------------------------------
-- Table `GardenShop`.`Bill`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GardenShop`.`Bill` (
  `idBill` INT NOT NULL AUTO_INCREMENT,
  `TotalPrice` DECIMAL(10,2) NOT NULL,
  `Date` DATETIME NOT NULL,
  `User_idUser` INT NOT NULL,
  PRIMARY KEY (`idBill`),
  INDEX `fk_Bill_User1_idx` (`User_idUser` ASC) VISIBLE,
  CONSTRAINT `fk_Bill_User1`
    FOREIGN KEY (`User_idUser`)
    REFERENCES `GardenShop`.`User` (`idUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `GardenShop`.`Category`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GardenShop`.`Category` (
  `idCategory` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idCategory`))
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `GardenShop`.`Article`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GardenShop`.`Article` (
  `idArticle` INT NOT NULL,
  `Name` VARCHAR(100) NOT NULL,
  `Picture` VARCHAR(255) NOT NULL,
  `Description` VARCHAR(1000) NOT NULL,
  `AvailableQuantity` INT NOT NULL,
  `SalePrice` DECIMAL(5,2) NOT NULL,
  `ProcurementPrice` DECIMAL(5,2) NOT NULL,
  `Category_idCategory` INT NOT NULL,
  `isAvailable` TINYINT NOT NULL,
  PRIMARY KEY (`idArticle`),
  INDEX `fk_Artical_Category_idx` (`Category_idCategory` ASC) VISIBLE,
  CONSTRAINT `fk_Artical_Category`
    FOREIGN KEY (`Category_idCategory`)
    REFERENCES `GardenShop`.`Category` (`idCategory`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `GardenShop`.`BillItem`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GardenShop`.`BillItem` (
  `Quantity` INT NOT NULL,
  `Price` DECIMAL(5,2) NOT NULL,
  `Article_idArticle` INT NOT NULL,
  `Bill_idBill` INT NOT NULL,
  PRIMARY KEY (`Article_idArticle`, `Bill_idBill`),
  INDEX `fk_BillItem_Artical1_idx` (`Article_idArticle` ASC) VISIBLE,
  INDEX `fk_BillItem_Bill1_idx` (`Bill_idBill` ASC) VISIBLE,
  CONSTRAINT `fk_BillItem_Artical1`
    FOREIGN KEY (`Article_idArticle`)
    REFERENCES `GardenShop`.`Article` (`idArticle`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_BillItem_Bill1`
    FOREIGN KEY (`Bill_idBill`)
    REFERENCES `GardenShop`.`Bill` (`idBill`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `GardenShop`.`Procurer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GardenShop`.`Procurer` (
  `idProcurer` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  `Surname` VARCHAR(45) NOT NULL,
  `PhoneNumber` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idProcurer`))
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `GardenShop`.`Procurement`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GardenShop`.`Procurement` (
  `idProcurement` INT NOT NULL AUTO_INCREMENT,
  `Date` DATETIME NOT NULL,
  `TotalPrice` DECIMAL(10,2) NOT NULL,
  `User_idUser` INT NOT NULL,
  `Procurer_idProcurer` INT NOT NULL,
  PRIMARY KEY (`idProcurement`),
  INDEX `fk_Procurement_User1_idx` (`User_idUser` ASC) VISIBLE,
  INDEX `fk_Procurement_Procurer1_idx` (`Procurer_idProcurer` ASC) VISIBLE,
  CONSTRAINT `fk_Procurement_User1`
    FOREIGN KEY (`User_idUser`)
    REFERENCES `GardenShop`.`User` (`idUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Procurement_Procurer1`
    FOREIGN KEY (`Procurer_idProcurer`)
    REFERENCES `GardenShop`.`Procurer` (`idProcurer`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `GardenShop`.`ProcurementItem`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GardenShop`.`ProcurementItem` (
  `Quantity` INT NOT NULL,
  `Price` DECIMAL(5,2) NOT NULL,
  `Article_idArticle` INT NOT NULL,
  `Procurement_idProcurement` INT NOT NULL,
  PRIMARY KEY (`Article_idArticle`, `Procurement_idProcurement`),
  INDEX `fk_ProcurementItem_Artical1_idx` (`Article_idArticle` ASC) VISIBLE,
  INDEX `fk_ProcurementItem_Procurement1_idx` (`Procurement_idProcurement` ASC) VISIBLE,
  CONSTRAINT `fk_ProcurementItem_Artical1`
    FOREIGN KEY (`Article_idArticle`)
    REFERENCES `GardenShop`.`Article` (`idArticle`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProcurementItem_Procurement1`
    FOREIGN KEY (`Procurement_idProcurement`)
    REFERENCES `GardenShop`.`Procurement` (`idProcurement`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
