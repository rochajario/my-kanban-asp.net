START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Boards` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Description` longtext CHARACTER SET utf8mb4 NOT NULL,
    `UpdatedAt` datetime(6) NOT NULL,
    `Status` int NOT NULL,
    CONSTRAINT `PK_Boards` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Tasks` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Description` longtext CHARACTER SET utf8mb4 NOT NULL,
    `BoardId` int NULL,
    `UpdatedAt` datetime(6) NOT NULL,
    `Status` int NOT NULL,
    CONSTRAINT `PK_Tasks` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Tasks_Boards_BoardId` FOREIGN KEY (`BoardId`) REFERENCES `Boards` (`Id`)
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_Tasks_BoardId` ON `Tasks` (`BoardId`);

COMMIT;