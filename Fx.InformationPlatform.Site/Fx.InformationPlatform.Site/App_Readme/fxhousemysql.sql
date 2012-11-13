/*
SQLyog 企业版 - MySQL GUI v8.14 
MySQL - 5.1.51-community : Database - fxhouse
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`fxhouse` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `fxhouse`;

/*Table structure for table `housebuyinfo` */

DROP TABLE IF EXISTS `housebuyinfo`;

CREATE TABLE `housebuyinfo` (
  `HouseBuyInfoId` int(11) NOT NULL AUTO_INCREMENT,
  `PublishTitle` longtext,
  `CatagroyId` int(11) NOT NULL,
  `Price` int(11) NOT NULL,
  `AreaId` int(11) NOT NULL,
  `CityId` int(11) NOT NULL,
  `Bill` tinyint(1) NOT NULL,
  `HasFurniture` tinyint(1) NOT NULL,
  `RoomNumber` int(11) NOT NULL,
  `PublishUserEmail` longtext,
  `Mark` longtext,
  `Controller` longtext,
  `Action` longtext,
  `UserAccount` longtext,
  `CreatedTime` datetime NOT NULL,
  `IsDelete` tinyint(1) NOT NULL,
  `IsPublish` tinyint(1) NOT NULL,
  `InfoProcessState` int(11) NOT NULL,
  PRIMARY KEY (`HouseBuyInfoId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `housetransferinfo` */

DROP TABLE IF EXISTS `housetransferinfo`;

CREATE TABLE `housetransferinfo` (
  `HouseTransferInfoId` int(11) NOT NULL AUTO_INCREMENT,
  `PostCode` longtext,
  `RoadName` longtext,
  `PublishTitle` longtext,
  `CatagroyId` int(11) NOT NULL,
  `Price` int(11) NOT NULL,
  `AreaId` int(11) NOT NULL,
  `CityId` int(11) NOT NULL,
  `Bill` tinyint(1) NOT NULL,
  `HasFurniture` tinyint(1) NOT NULL,
  `RoomNumber` int(11) NOT NULL,
  `PublishUserEmail` longtext,
  `Mark` longtext,
  `Controller` longtext,
  `Action` longtext,
  `UserAccount` longtext,
  `CreatedTime` datetime NOT NULL,
  `IsDelete` tinyint(1) NOT NULL,
  `IsPublish` tinyint(1) NOT NULL,
  `InfoProcessState` int(11) NOT NULL,
  PRIMARY KEY (`HouseTransferInfoId`)
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
  `HouseTransferInfo_HouseTransferInfoId` int(11) DEFAULT NULL,
  PRIMARY KEY (`TransferPictureId`),
  KEY `HouseTransferInfo_HouseTransferInfoId` (`HouseTransferInfo_HouseTransferInfoId`),
  CONSTRAINT `HouseTransferInfo_Pictures` FOREIGN KEY (`HouseTransferInfo_HouseTransferInfoId`) REFERENCES `housetransferinfo` (`HouseTransferInfoId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
