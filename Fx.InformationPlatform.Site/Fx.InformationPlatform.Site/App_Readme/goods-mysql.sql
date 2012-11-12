

CREATE TABLE `goodstransferinfo` (
  `GoodsTransferInfoId` int(11) NOT NULL AUTO_INCREMENT,
  `IsChange` tinyint(1) NOT NULL,
  `ChangeMsg` longtext,
  `GoodsconditonId` int(11) NOT NULL,
  `GoodsConditionMsg` longtext,
  `IsDelete` tinyint(1) NOT NULL,
  `IsPublish` tinyint(1) NOT NULL,
  `PublishUserEmail` varchar(128) DEFAULT NULL,
  `PublishTitle` varchar(128) DEFAULT NULL,
  `Price` int(11) NOT NULL,
  `Mark` varchar(128) DEFAULT NULL,
  `Controller` longtext,
  `Action` longtext,
  `AreaId` int(11) NOT NULL,
  `CityId` int(11) NOT NULL,
  `UserAccount` longtext,
  `CreatedTime` datetime NOT NULL,
  PRIMARY KEY (`GoodsTransferInfoId`)
) 

/*Table structure for table `transferpictures` */

DROP TABLE IF EXISTS `transferpictures`;

CREATE TABLE `transferpictures` (
  `TransferPictureId` int(11) NOT NULL AUTO_INCREMENT,
  `PhysicalPath` longtext,
  `ImageUrl` longtext,
  `IsCdn` tinyint(1) NOT NULL,
  `CdnUrl` longtext,
  `GoodsTransferInfo_GoodsTransferInfoId` int(11) DEFAULT NULL,
  PRIMARY KEY (`TransferPictureId`),
  KEY `GoodsTransferInfo_GoodsTransferInfoId` (`GoodsTransferInfo_GoodsTransferInfoId`),
  CONSTRAINT `GoodsTransferInfo_Pictures` FOREIGN KEY (`GoodsTransferInfo_GoodsTransferInfoId`) REFERENCES `goodstransferinfo` (`GoodsTransferInfoId`)
) 
