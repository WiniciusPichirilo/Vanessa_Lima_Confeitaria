-- MySQL Workbench Synchronization
-- Generated: 2024-10-02 23:22
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: Fernando

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE TABLE IF NOT EXISTS `Br.Confeitaria.Web`.`Produto` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(150) NULL DEFAULT NULL,
  `Dimensao` VARCHAR(45) NULL DEFAULT NULL,
  `Material` VARCHAR(45) NULL DEFAULT NULL,
  `Descricao` LONGTEXT NULL DEFAULT NULL,
  `Peso` DOUBLE NULL DEFAULT 0,
  `ValorCompra` DOUBLE NULL DEFAULT 0,
  `ValorVenda` DOUBLE NULL DEFAULT 0,
  `Tag` VARCHAR(45) NULL DEFAULT NULL,
  `Status` INT(11) NULL DEFAULT 0,
  `TipoId` INT(11) NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Produto_Tipo1_idx` (`TipoId` ASC),
  CONSTRAINT `fk_Produto_Tipo1`
    FOREIGN KEY (`TipoId`)
    REFERENCES `Br.Confeitaria.Web`.`Tipo` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `Br.Confeitaria.Web`.`Cor` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(150) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `Br.Confeitaria.Web`.`Tamanho` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(150) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `Br.Confeitaria.Web`.`ProdutoDetalhe` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `CorId` INT(11) NOT NULL,
  `TamanhoId` INT(11) NOT NULL,
  `ProdutoId` INT(11) NOT NULL,
  `QtdeCompra` INT(11) NOT NULL,
  `QtdeVenda` INT(11) NOT NULL,
  `Status` INT(11) NULL DEFAULT 0,
  PRIMARY KEY (`Id`),
  INDEX `fk_ProdutoDetalhe_Cor_idx` (`CorId` ASC),
  INDEX `fk_ProdutoDetalhe_Tamanho1_idx` (`TamanhoId` ASC) ,
  INDEX `fk_ProdutoDetalhe_Produto1_idx` (`ProdutoId` ASC) ,
  CONSTRAINT `fk_ProdutoDetalhe_Cor`
    FOREIGN KEY (`CorId`)
    REFERENCES `Br.Confeitaria.Web`.`Cor` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProdutoDetalhe_Tamanho1`
    FOREIGN KEY (`TamanhoId`)
    REFERENCES `Br.Confeitaria.Web`.`Tamanho` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProdutoDetalhe_Produto1`
    FOREIGN KEY (`ProdutoId`)
    REFERENCES `Br.Confeitaria.Web`.`Produto` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `Br.Confeitaria.Web`.`Tipo` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(150) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `Br.Confeitaria.Web`.`Photo` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `ProdutoId` INT(11) NOT NULL,
  `Name` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Photo_Produto1_idx` (`ProdutoId` ASC),
  CONSTRAINT `fk_Photo_Produto1`
    FOREIGN KEY (`ProdutoId`)
    REFERENCES `Br.Confeitaria.Web`.`Produto` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `Br.Confeitaria.Web`.`Newslatter` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `Email` VARCHAR(150) NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `Br.Confeitaria.Web`.`Usuarios` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(150) NOT NULL,
  `Email` VARCHAR(150) NOT NULL,
  `Identidade` VARCHAR(150) NOT NULL,
  `Login` VARCHAR(150) NOT NULL,
  `Senha` VARCHAR(150) NOT NULL,
  `NivelUsuarioId` INT(11) NOT NULL,
  `Status` INT(11) NULL DEFAULT 0,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC),
  INDEX `fk_Usuarios_NivelUsuario1_idx` (`NivelUsuarioId` ASC),
  CONSTRAINT `fk_Usuarios_NivelUsuario1`
    FOREIGN KEY (`NivelUsuarioId`)
    REFERENCES `Br.Confeitaria.Web`.`NivelUsuario` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `Br.Confeitaria.Web`.`NivelUsuario` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `Br.Confeitaria.Web`.`VARCHAR(150)` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(150) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `Br.Confeitaria.Web`.`Modulo` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `Br.Confeitaria.Web`.`Permissoes` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `ModuloId` INT(11) NOT NULL,
  `NivelUsuarioId` INT(11) NOT NULL,
  PRIMARY KEY (`Id`, `ModuloId`),
  INDEX `fk_Permisoes_Modulo1_idx` (`ModuloId` ASC),
  INDEX `fk_Permisoes_NivelUsuario1_idx` (`NivelUsuarioId` ASC),
  CONSTRAINT `fk_Permisoes_Modulo1`
    FOREIGN KEY (`ModuloId`)
    REFERENCES `Br.Confeitaria.Web`.`Modulo` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Permisoes_NivelUsuario1`
    FOREIGN KEY (`NivelUsuarioId`)
    REFERENCES `Br.Confeitaria.Web`.`NivelUsuario` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
