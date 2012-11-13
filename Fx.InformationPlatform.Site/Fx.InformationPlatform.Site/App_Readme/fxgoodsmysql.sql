/*
SQLyog 企业版 - MySQL GUI v8.14 
MySQL - 5.1.51-community : Database - fxgoods
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`fxgoods` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `fxgoods`;

/*Table structure for table `buypicture` */

DROP TABLE IF EXISTS `buypicture`;

CREATE TABLE `buypicture` (
  `BuyPictureId` int(11) NOT NULL AUTO_INCREMENT,
  `BuyPictureCatagroy` int(11) NOT NULL,
  `PhysicalPath` longtext,
  `ImageUrl` longtext,
  `IsCdn` tinyint(1) NOT NULL,
  `CdnUrl` longtext,
  `GoodsBuyInfo_GoodsBuyInfoId` int(11) DEFAULT NULL,
  PRIMARY KEY (`BuyPictureId`),
  KEY `GoodsBuyInfo_GoodsBuyInfoId` (`GoodsBuyInfo_GoodsBuyInfoId`),
  CONSTRAINT `GoodsBuyInfo_Pictures` FOREIGN KEY (`GoodsBuyInfo_GoodsBuyInfoId`) REFERENCES `goodsbuyinfo` (`GoodsBuyInfoId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `goodsbuyinfo` */

DROP TABLE IF EXISTS `goodsbuyinfo`;

CREATE TABLE `goodsbuyinfo` (
  `GoodsBuyInfoId` int(11) NOT NULL AUTO_INCREMENT,
  `GoodsconditonId` int(11) NOT NULL,
  `GoodsConditionMsg` longtext,
  `PublishTitle` longtext,
  `CatagroyId` int(11) NOT NULL,
  `Price` int(11) NOT NULL,
  `IsChange` tinyint(1) NOT NULL,
  `ChangeMsg` longtext,
  `AreaId` int(11) NOT NULL,
  `CityId` int(11) NOT NULL,
  `PublishUserEmail` longtext,
  `Mark` longtext,
  `Controller` longtext,
  `Action` longtext,
  `UserAccount` longtext,
  `CreatedTime` datetime NOT NULL,
  `IsDelete` tinyint(1) NOT NULL,
  `IsPublish` tinyint(1) NOT NULL,
  `InfoProcessState` int(11) NOT NULL,
  PRIMARY KEY (`GoodsBuyInfoId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `goodstransferinfo` */

DROP TABLE IF EXISTS `goodstransferinfo`;

CREATE TABLE `goodstransferinfo` (
  `GoodsTransferInfoId` int(11) NOT NULL AUTO_INCREMENT,
  `GoodsconditonId` int(11) NOT NULL,
  `GoodsConditionMsg` longtext,
  `PublishTitle` longtext,
  `CatagroyId` int(11) NOT NULL,
  `Price` int(11) NOT NULL,
  `IsChange` tinyint(1) NOT NULL,
  `ChangeMsg` longtext,
  `AreaId` int(11) NOT NULL,
  `CityId` int(11) NOT NULL,
  `PublishUserEmail` longtext,
  `Mark` longtext,
  `Controller` longtext,
  `Action` longtext,
  `UserAccount` longtext,
  `CreatedTime` datetime NOT NULL,
  `IsDelete` tinyint(1) NOT NULL,
  `IsPublish` tinyint(1) NOT NULL,
  `InfoProcessState` int(11) NOT NULL,
  PRIMARY KEY (`GoodsTransferInfoId`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Table structure for table `transferpicture` */

DROP TABLE IF EXISTS `transferpicture`;

CREATE TABLE `transferpicture` (
  `TransferPictureId` int(11) NOT NULL AUTO_INCREMENT,
  `TransferPictureCatagroy` int(11) NOT NULL,
  `PhysicalPath` longtext,
  `ImageUrl` longtext,
  `IsCdn` tinyint(1) NOT NULL,
  `CdnUrl` longtext,
  `GoodsTransferInfo_GoodsTransferInfoId` int(11) DEFAULT NULL,
  PRIMARY KEY (`TransferPictureId`),
  KEY `GoodsTransferInfo_GoodsTransferInfoId` (`GoodsTransferInfo_GoodsTransferInfoId`),
  CONSTRAINT `GoodsTransferInfo_Pictures` FOREIGN KEY (`GoodsTransferInfo_GoodsTransferInfoId`) REFERENCES `goodstransferinfo` (`GoodsTransferInfoId`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
