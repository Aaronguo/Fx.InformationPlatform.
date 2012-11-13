/*
SQLyog 企业版 - MySQL GUI v8.14 
MySQL - 5.1.51-community : Database - fxcar
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`fxcar` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `fxcar`;

/*Table structure for table `carbuyinfo` */

DROP TABLE IF EXISTS `carbuyinfo`;

CREATE TABLE `carbuyinfo` (
  `CarBuyInfoId` int(11) NOT NULL AUTO_INCREMENT,
  `PublishTitle` longtext,
  `CatagroyId` int(11) NOT NULL,
  `Price` int(11) NOT NULL,
  `AreaId` int(11) NOT NULL,
  `CityId` int(11) NOT NULL,
  `CarYear` int(11) NOT NULL,
  `CarMileage` int(11) NOT NULL,
  `PublishUserEmail` longtext,
  `Mark` longtext,
  `Controller` longtext,
  `Action` longtext,
  `UserAccount` longtext,
  `CreatedTime` datetime NOT NULL,
  `IsDelete` tinyint(1) NOT NULL,
  `IsPublish` tinyint(1) NOT NULL,
  `InfoProcessState` int(11) NOT NULL,
  PRIMARY KEY (`CarBuyInfoId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `cartransferinfo` */

DROP TABLE IF EXISTS `cartransferinfo`;

CREATE TABLE `cartransferinfo` (
  `CarTransferInfoId` int(11) NOT NULL AUTO_INCREMENT,
  `PublishTitle` longtext,
  `CatagroyId` int(11) NOT NULL,
  `Price` int(11) NOT NULL,
  `AreaId` int(11) NOT NULL,
  `CityId` int(11) NOT NULL,
  `CarYear` int(11) NOT NULL,
  `CarMileage` int(11) NOT NULL,
  `PublishUserEmail` longtext,
  `Mark` longtext,
  `Controller` longtext,
  `Action` longtext,
  `UserAccount` longtext,
  `CreatedTime` datetime NOT NULL,
  `IsDelete` tinyint(1) NOT NULL,
  `IsPublish` tinyint(1) NOT NULL,
  `InfoProcessState` int(11) NOT NULL,
  PRIMARY KEY (`CarTransferInfoId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `transferpicture` */

DROP TABLE IF EXISTS `transferpicture`;

CREATE TABLE `transferpicture` (
  `TransferPictureId` int(11) NOT NULL AUTO_INCREMENT,
  `TransferPictureCatagroy` int(11) NOT NULL,
  `PhysicalPath` longtext,
  `ImageUrl` longtext,
  `IsCdn` tinyint(1) NOT NULL,
  `CdnUrl` longtext,
  `CarTransferInfo_CarTransferInfoId` int(11) DEFAULT NULL,
  PRIMARY KEY (`TransferPictureId`),
  KEY `CarTransferInfo_CarTransferInfoId` (`CarTransferInfo_CarTransferInfoId`),
  CONSTRAINT `CarTransferInfo_Pictures` FOREIGN KEY (`CarTransferInfo_CarTransferInfoId`) REFERENCES `cartransferinfo` (`CarTransferInfoId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
