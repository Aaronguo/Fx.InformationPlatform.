

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

