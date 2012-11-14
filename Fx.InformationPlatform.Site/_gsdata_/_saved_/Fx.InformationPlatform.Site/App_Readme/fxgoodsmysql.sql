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
