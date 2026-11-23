-- MySQL dump 10.13  Distrib 8.0.45, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: property_management_db
-- ------------------------------------------------------
-- Server version	8.0.45

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `billing`
--

DROP TABLE IF EXISTS `billing`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `billing` (
  `BILLING_ID` int NOT NULL AUTO_INCREMENT,
  `LEASE_ID` int NOT NULL,
  `BILL_TYPE` enum('Rent','Utilities','Penalty','Association Dues','Other') NOT NULL DEFAULT 'Rent',
  `BILL_DATE` date NOT NULL,
  `DUE_DATE` date NOT NULL,
  `AMOUNT` decimal(12,2) NOT NULL,
  `CANCELLED` tinyint NOT NULL DEFAULT '0',
  `PERSONNEL_ID` int DEFAULT NULL,
  `CREATED_AT` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UPDATED_AT` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`BILLING_ID`),
  KEY `LEASE_ID_idx` (`LEASE_ID`),
  KEY `PERSONNEL_ID_idx` (`PERSONNEL_ID`),
  KEY `idx_billing_due_date` (`DUE_DATE`),
  CONSTRAINT `fk_billing_lease` FOREIGN KEY (`LEASE_ID`) REFERENCES `lease` (`LEASE_ID`),
  CONSTRAINT `fk_billing_personnel` FOREIGN KEY (`PERSONNEL_ID`) REFERENCES `personnel` (`PERSONNEL_ID`),
  CONSTRAINT `chk_billing_amt` CHECK ((`AMOUNT` > 0)),
  CONSTRAINT `chk_billing_dates` CHECK ((`DUE_DATE` >= `BILL_DATE`))
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `billing`
--

LOCK TABLES `billing` WRITE;
/*!40000 ALTER TABLE `billing` DISABLE KEYS */;
INSERT INTO `billing` VALUES (1,45,'Rent','2026-10-25','2026-11-05',12000.00,0,1,'2026-11-15 15:29:36','2026-11-15 15:29:36'),(2,46,'Rent','2026-10-25','2026-11-05',18000.00,0,1,'2026-11-15 15:29:36','2026-11-22 19:11:11'),(3,47,'Rent','2026-10-25','2026-11-05',12000.00,0,3,'2026-11-15 15:29:36','2026-11-15 15:29:36'),(4,47,'Penalty','2026-11-10','2026-11-25',600.00,0,3,'2026-11-15 15:29:36','2026-11-22 08:08:09'),(5,48,'Rent','2026-11-01','2026-11-15',18000.00,0,3,'2026-11-15 15:29:36','2026-11-22 08:04:47'),(6,51,'Utilities','2026-11-01','2026-11-20',1850.75,0,1,'2026-11-15 15:29:36','2026-11-22 08:03:51'),(7,50,'Other','2026-06-15','2026-06-30',2500.00,1,1,'2026-11-15 15:29:36','2026-11-15 15:29:36'),(8,47,'Rent','2026-11-22','2026-12-02',1000.00,0,NULL,'2026-11-22 08:00:26','2026-11-22 08:00:38'),(9,47,'Penalty','2026-11-23','2026-12-03',10000.00,0,NULL,'2026-11-23 00:11:17','2026-11-23 00:13:47'),(10,56,'Other','2026-11-23','2026-12-03',1000.00,0,NULL,'2026-11-23 08:27:53','2026-11-23 08:27:53'),(11,51,'Utilities','2026-09-01','2026-10-01',12000.00,0,NULL,'2026-11-23 08:58:58','2026-11-23 09:00:23');
/*!40000 ALTER TABLE `billing` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lease`
--

DROP TABLE IF EXISTS `lease`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lease` (
  `LEASE_ID` int NOT NULL AUTO_INCREMENT,
  `START_DATE` date NOT NULL,
  `END_DATE` date NOT NULL,
  `UNIT_ID` int NOT NULL,
  `RESIDENT_ID` int NOT NULL,
  `MONTHLY_RENT` decimal(12,2) NOT NULL,
  `DEPOSIT` decimal(12,2) NOT NULL DEFAULT '0.00',
  `STATUS` enum('Pending','Active','Expired','Terminated') NOT NULL DEFAULT 'Pending',
  `EMPLOYEE_NO` varchar(20) DEFAULT NULL,
  `CREATED_AT` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UPDATED_AT` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`LEASE_ID`),
  KEY `idx_lease_unit_dates` (`UNIT_ID`,`START_DATE`,`END_DATE`),
  KEY `RESIDENT_ID_idx` (`RESIDENT_ID`),
  KEY `idx_lease_employee` (`EMPLOYEE_NO`),
  CONSTRAINT `fk_lease_employee` FOREIGN KEY (`EMPLOYEE_NO`) REFERENCES `personnel` (`EMPLOYEE_NO`) ON UPDATE CASCADE,
  CONSTRAINT `fk_lease_resident` FOREIGN KEY (`RESIDENT_ID`) REFERENCES `resident` (`RESIDENT_ID`),
  CONSTRAINT `fk_lease_unit` FOREIGN KEY (`UNIT_ID`) REFERENCES `units` (`UNIT_ID`),
  CONSTRAINT `chk_lease_dates` CHECK ((`END_DATE` > `START_DATE`)),
  CONSTRAINT `chk_lease_rent` CHECK ((`MONTHLY_RENT` >= 0))
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lease`
--

LOCK TABLES `lease` WRITE;
/*!40000 ALTER TABLE `lease` DISABLE KEYS */;
INSERT INTO `lease` VALUES (45,'2026-01-01','2026-12-31',151,73,12000.00,24000.00,'Active','2026-12773','2026-11-07 17:46:45','2026-11-07 17:46:45'),(46,'2026-03-01','2027-02-28',152,74,18000.00,36000.00,'Active','2026-12773','2026-11-07 17:46:45','2026-11-07 17:46:45'),(47,'2025-11-15','2026-11-14',153,75,12000.00,24000.00,'Expired','2026-12773','2026-11-07 17:46:45','2026-11-23 13:58:33'),(48,'2025-12-01','2026-11-30',154,77,18000.00,36000.00,'Active','2026-12773','2026-11-07 17:46:45','2026-11-07 17:46:45'),(49,'2026-12-01','2027-11-30',155,76,18000.00,36000.00,'Pending','2026-12773','2026-11-07 17:46:45','2026-11-07 17:46:45'),(50,'2025-07-01','2026-06-30',157,78,18000.00,36000.00,'Expired','2026-12773','2026-11-07 17:46:45','2026-11-07 17:46:45'),(51,'2026-02-01','2027-01-31',161,79,12000.00,24000.00,'Active','2026-12773','2026-11-15 15:29:36','2026-11-15 15:29:36'),(52,'2026-05-15','2027-05-14',162,80,18000.00,36000.00,'Active','2026-59087','2026-11-15 15:29:36','2026-11-15 15:29:36'),(53,'2026-08-01','2027-07-31',163,81,26000.00,52000.00,'Active','2026-59087','2026-11-15 15:29:36','2026-11-15 15:29:36'),(54,'2026-12-15','2027-12-14',156,82,26000.00,52000.00,'Active','2026-12773','2026-11-15 15:29:36','2026-11-23 08:08:01'),(55,'2025-09-01','2026-08-31',158,83,26000.00,52000.00,'Terminated','2026-12773','2026-11-15 15:29:36','2026-11-23 08:09:01'),(56,'2026-11-23','2027-11-23',164,84,12000.00,24000.00,'Active','2026-12773','2026-11-23 08:25:18','2026-11-23 08:25:18');
/*!40000 ALTER TABLE `lease` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `maintenance_request`
--

DROP TABLE IF EXISTS `maintenance_request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `maintenance_request` (
  `REPORT_ID` int NOT NULL AUTO_INCREMENT,
  `UNIT_ID` int DEFAULT NULL,
  `RESIDENT_ID` int DEFAULT NULL,
  `DATE_REPORTED` date NOT NULL,
  `PRIORITY` enum('Low','Medium','High','Urgent') NOT NULL DEFAULT 'Medium',
  `STATUS` enum('Open','In Progress','Resolved','Closed') NOT NULL DEFAULT 'Open',
  `PROBLEM` varchar(255) NOT NULL,
  `MAINTENANCE_TYPE` enum('Plumbing','Electrical','Appliance','Structural','Other') NOT NULL DEFAULT 'Other',
  `PERSONNEL_ID` int DEFAULT NULL,
  `DATE_COMPLETED` date DEFAULT NULL,
  `COST` decimal(12,2) NOT NULL DEFAULT '0.00',
  `REPAIR_DETAILS` varchar(255) DEFAULT NULL,
  `CREATED_AT` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UPDATED_AT` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`REPORT_ID`),
  KEY `UNIT_ID_idx` (`UNIT_ID`),
  KEY `RESIDENT_ID_idx` (`RESIDENT_ID`),
  KEY `idx_reports_status` (`STATUS`),
  KEY `idx_request_personnel` (`PERSONNEL_ID`),
  CONSTRAINT `fk_reports_resident` FOREIGN KEY (`RESIDENT_ID`) REFERENCES `resident` (`RESIDENT_ID`),
  CONSTRAINT `fk_reports_unit` FOREIGN KEY (`UNIT_ID`) REFERENCES `units` (`UNIT_ID`),
  CONSTRAINT `fk_request_personnel` FOREIGN KEY (`PERSONNEL_ID`) REFERENCES `personnel` (`PERSONNEL_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `maintenance_request`
--

LOCK TABLES `maintenance_request` WRITE;
/*!40000 ALTER TABLE `maintenance_request` DISABLE KEYS */;
INSERT INTO `maintenance_request` VALUES (1,151,73,'2026-10-28','Medium','Closed','Leaking kitchen faucet','Plumbing',3,'2026-10-30',450.00,'Replaced faucet cartridge and washer.','2026-11-15 15:29:36','2026-11-23 13:24:05'),(2,152,74,'2026-11-02','High','Open','Air conditioner not cooling','Appliance',3,'2026-11-23',0.00,'Technician scheduled; checking refrigerant level.','2026-11-15 15:29:36','2026-11-23 07:05:48'),(3,153,75,'2026-11-05','Low','Open','Hallway light flickers','Electrical',NULL,NULL,0.00,NULL,'2026-11-15 15:29:36','2026-11-23 06:52:14'),(4,154,77,'2026-11-08','Urgent','In Progress','Water leak from bathroom ceiling','Plumbing',1,NULL,0.00,'Water supply shut off; inspecting plumbing above.','2026-11-15 15:29:36','2026-11-23 06:52:14'),(5,161,79,'2026-10-15','Medium','Closed','Door lock jammed','Structural',1,'2026-10-16',1200.00,'Replaced door lock set; two new keys issued.','2026-11-15 15:29:36','2026-11-23 06:52:14'),(6,162,80,'2026-11-10','Low','Open','Cracked bathroom wall tile','Structural',NULL,NULL,0.00,NULL,'2026-11-15 15:29:36','2026-11-23 06:52:14'),(7,160,NULL,'2026-11-01','High','In Progress','Water damage on bedroom ceiling and wall','Structural',1,'2026-11-23',0.00,'Repainting and waterproofing underway.','2026-11-15 15:29:36','2026-11-23 07:04:28');
/*!40000 ALTER TABLE `maintenance_request` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payment` (
  `PAYMENT_ID` int NOT NULL AUTO_INCREMENT,
  `BILLING_ID` int NOT NULL,
  `AMOUNT` decimal(12,2) NOT NULL,
  `PAYMENT_DATE` date NOT NULL,
  `PAYMENT_MODE` enum('Cash','Bank Transfer','Credit Card','Debit Card','E-Wallet','Check') NOT NULL,
  `REF_NO` varchar(45) NOT NULL,
  `STATUS` enum('Completed','Refunded') NOT NULL DEFAULT 'Completed',
  `PERSONNEL_ID` int DEFAULT NULL,
  `CREATED_AT` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`PAYMENT_ID`),
  UNIQUE KEY `uq_payment_ref_no` (`REF_NO`),
  KEY `idx_payment_billing` (`BILLING_ID`),
  KEY `idx_payment_date` (`PAYMENT_DATE`),
  KEY `fk_payment_personnel` (`PERSONNEL_ID`),
  CONSTRAINT `fk_payment_billing` FOREIGN KEY (`BILLING_ID`) REFERENCES `billing` (`BILLING_ID`),
  CONSTRAINT `fk_payment_personnel` FOREIGN KEY (`PERSONNEL_ID`) REFERENCES `personnel` (`PERSONNEL_ID`),
  CONSTRAINT `chk_payment_amt` CHECK ((`AMOUNT` > 0))
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
INSERT INTO `payment` VALUES (1,1,12000.00,'2026-11-03','Bank Transfer','BT-20261103-0001','Completed',NULL,'2026-11-23 00:29:09'),(2,2,16000.00,'2026-11-22','E-Wallet','EW-20261122-0005','Completed',NULL,'2026-11-23 00:29:09'),(3,4,500.00,'2026-11-22','Cash','CS-20261122-0004','Completed',NULL,'2026-11-23 00:29:09'),(4,5,8000.00,'2026-11-22','Bank Transfer','BT-20261122-0003','Completed',NULL,'2026-11-23 00:29:09'),(5,6,1850.75,'2026-11-22','Bank Transfer','BT-20261122-0002','Completed',NULL,'2026-11-23 00:29:09'),(6,8,1000.00,'2026-11-22','Bank Transfer','MIG-000008','Completed',NULL,'2026-11-23 00:29:09'),(7,9,10000.00,'2026-11-23','Cash','CS-20261123-0007','Completed',NULL,'2026-11-23 00:29:09'),(8,2,500.00,'2026-11-23','Cash','CS-20261123-0008','Completed',1,'2026-11-23 00:41:32'),(9,5,7500.00,'2026-11-23','Bank Transfer','BT-20261123-0009','Completed',1,'2026-11-23 00:52:51'),(10,5,2500.00,'2026-11-23','Cash','CS-20261123-0010','Completed',4,'2026-11-23 01:01:52'),(11,3,12000.00,'2026-11-23','Cash','CS-20261123-0011','Completed',1,'2026-11-23 07:47:47'),(12,10,1000.00,'2026-11-23','Cash','CS-20261123-0012','Completed',1,'2026-11-23 08:28:01');
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `personnel` (
  `PERSONNEL_ID` int NOT NULL AUTO_INCREMENT,
  `EMPLOYEE_NO` varchar(20) NOT NULL,
  `FIRST_NAME` varchar(45) NOT NULL,
  `LAST_NAME` varchar(45) NOT NULL,
  `POSITION` varchar(45) DEFAULT NULL,
  `CONTACT_NO` varchar(20) DEFAULT NULL,
  `EMAIL` varchar(100) DEFAULT NULL,
  `EMPLOYMENT_STATUS` enum('Active','On Leave','Resigned','Terminated') NOT NULL DEFAULT 'Active',
  `CREATED_AT` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UPDATED_AT` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`PERSONNEL_ID`),
  UNIQUE KEY `PERSONNEL_NO_UNIQUE` (`EMPLOYEE_NO`),
  UNIQUE KEY `uq_personnel_email` (`EMAIL`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personnel`
--

LOCK TABLES `personnel` WRITE;
/*!40000 ALTER TABLE `personnel` DISABLE KEYS */;
INSERT INTO `personnel` VALUES (1,'2026-12773','Ve','Dal','Administrator','09816525899','vedal@gmail.com','Active','2026-10-31 19:05:43','2026-11-23 15:03:55'),(3,'2026-59087','E','Vil','Clerk','09123456789','evil@gmail.com','Active','2026-11-01 13:21:36','2026-11-23 15:03:55'),(4,'2026-02122','Neuro','Sama','CEO','09123456789','neuro@gmail.com','Active','2026-11-22 22:37:28','2026-11-23 15:03:55');
/*!40000 ALTER TABLE `personnel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resident`
--

DROP TABLE IF EXISTS `resident`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `resident` (
  `RESIDENT_ID` int NOT NULL AUTO_INCREMENT,
  `FIRST_NAME` varchar(45) NOT NULL,
  `LAST_NAME` varchar(45) NOT NULL,
  `CONTACT_NO` varchar(20) DEFAULT NULL,
  `EMAIL` varchar(100) DEFAULT NULL,
  `BIRTHDATE` date DEFAULT NULL,
  `EMERGENCY_CONTACT_NO` varchar(20) DEFAULT NULL,
  `CREATED_AT` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UPDATED_AT` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`RESIDENT_ID`),
  UNIQUE KEY `uq_resident_email` (`EMAIL`)
) ENGINE=InnoDB AUTO_INCREMENT=85 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resident`
--

LOCK TABLES `resident` WRITE;
/*!40000 ALTER TABLE `resident` DISABLE KEYS */;
INSERT INTO `resident` VALUES (73,'Maria','Santos','09170000101','maria.santos@example.com','1990-03-14','09180000101','2026-11-07 17:46:45','2026-11-07 17:46:45'),(74,'Jose','Reyes','09170000102','jose.reyes@example.com','1985-07-22','09180000102','2026-11-07 17:46:45','2026-11-07 17:46:45'),(75,'Angela','Cruz','09170000103','angela.cruz@example.com','1995-11-05','09180000103','2026-11-07 17:46:45','2026-11-07 17:46:45'),(76,'Mark','Villanueva','09170000104','mark.villanueva@example.com','1992-01-30','09180000104','2026-11-07 17:46:45','2026-11-07 17:46:45'),(77,'Carlo','Dizon','09170000105','carlo.dizon@example.com','1988-09-12','09180000105','2026-11-07 17:46:45','2026-11-07 17:46:45'),(78,'Joy','Tan','09170000106','joy.tan@example.com','1991-06-25','09180000106','2026-11-07 17:46:45','2026-11-07 17:46:45'),(79,'Patricia','Gonzales','09170000107','patricia.gonzales@example.com','1993-08-18','09180000107','2026-11-15 15:29:36','2026-11-15 15:29:36'),(80,'Miguel','Ramos','09170000108','miguel.ramos@example.com','1987-12-02','09180000108','2026-11-15 15:29:36','2026-11-15 15:29:36'),(81,'Sofia','Mendoza','09170000109','sofia.mendoza@example.com','1996-04-09','09180000109','2026-11-15 15:29:36','2026-11-15 15:29:36'),(82,'Rafael','Aquino','09170000110','rafael.aquino@example.com','1983-10-27','09180000110','2026-11-15 15:29:36','2026-11-15 15:29:36'),(83,'Bianca','Flores','09170000111','bianca.flores@example.com','1994-02-16','09180000111','2026-11-15 15:29:36','2026-11-15 15:29:36'),(84,'wyne','constantino','09816525899','wyneconstantino12@gmail.com','2007-09-11','09123456789','2026-11-23 08:11:50','2026-11-23 13:07:07');
/*!40000 ALTER TABLE `resident` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `system_user`
--

DROP TABLE IF EXISTS `system_user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `system_user` (
  `USER_ID` int NOT NULL AUTO_INCREMENT,
  `PERSONNEL_ID` int NOT NULL,
  `USERNAME` varchar(45) NOT NULL,
  `PASSWORD` varchar(255) NOT NULL,
  `ROLE` enum('Admin','Manager','Staff') NOT NULL DEFAULT 'Staff',
  `LAST_LOGIN` datetime DEFAULT NULL,
  `ACCOUNT_STATUS` enum('Active','Inactive','Suspended','Locked') NOT NULL DEFAULT 'Active',
  `DATE_CREATED` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`USER_ID`),
  UNIQUE KEY `uq_system_user_username` (`USERNAME`),
  UNIQUE KEY `uq_system_user_personnel` (`PERSONNEL_ID`),
  CONSTRAINT `fk_system_user_personnel` FOREIGN KEY (`PERSONNEL_ID`) REFERENCES `personnel` (`PERSONNEL_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `system_user`
--

LOCK TABLES `system_user` WRITE;
/*!40000 ALTER TABLE `system_user` DISABLE KEYS */;
INSERT INTO `system_user` VALUES (1,1,'admin1','$2a$11$mvo2rocxJGGhFeQ54W8Qi.gWSR8qBObnCITEAD1SsNLbU5TFpe4hm','Admin','2026-11-23 15:02:46','Active','2026-10-31 19:08:50'),(2,3,'staff1','$2a$11$ck8E0SxpxmHRlljxdLxcgOeVHVTbrufBE.i4o.D0CKz/j5cse.uqS','Staff','2026-11-23 13:19:35','Active','2026-11-03 17:36:40'),(3,4,'manager1','$2a$11$w1D80vbMSgfGP47Ilu5yo.DgHBJaCGgdEh1aagQq0vTnVou9HEabm','Manager','2026-11-23 09:04:28','Active','2026-11-22 22:38:42');
/*!40000 ALTER TABLE `system_user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `units`
--

DROP TABLE IF EXISTS `units`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `units` (
  `UNIT_ID` int NOT NULL AUTO_INCREMENT,
  `UNIT_NO` varchar(10) NOT NULL,
  `FLOOR_NO` int DEFAULT NULL,
  `UNIT_TYPE` enum('Unfurnished','Semi-Furnished','Fully Furnished') NOT NULL DEFAULT 'Unfurnished',
  `STATUS` enum('Vacant','Occupied','Under Maintenance') NOT NULL DEFAULT 'Vacant',
  `BASE_RENT` decimal(12,2) NOT NULL,
  `PHOTO` mediumblob,
  PRIMARY KEY (`UNIT_ID`),
  UNIQUE KEY `uq_unit_no` (`UNIT_NO`)
) ENGINE=InnoDB AUTO_INCREMENT=166 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `units`
--

LOCK TABLES `units` WRITE;
/*!40000 ALTER TABLE `units` DISABLE KEYS */;
INSERT INTO `units` VALUES (151,'101',1,'Unfurnished','Occupied',12000.00,NULL),(152,'102',1,'Semi-Furnished','Occupied',18000.00,NULL),(153,'201',2,'Unfurnished','Vacant',12000.00,NULL),(154,'202',2,'Semi-Furnished','Occupied',18000.00,NULL),(155,'301',3,'Semi-Furnished','Vacant',18000.00,NULL),(156,'302',3,'Fully Furnished','Occupied',26000.00,_binary 'ÿ\Øÿ\à\0JFIF\0\0x\0x\0\0ÿ\Û\0C\0\n\n\n\r\rÿ\Û\0C		\r\rÿÀ\0\0\ç\0\ì\"\0ÿ\Ä\0\0\0\0\0\0\0\0\0\0\0	\nÿ\Ä\0µ\0\0\0}\0!1AQa\"q2‘¡#B±ÁR\Ñğ$3br‚	\n\Z%&\'()*456789:CDEFGHIJSTUVWXYZcdefghijstuvwxyzƒ„…†‡ˆ‰Š’“”•–—˜™š¢£¤¥¦§¨©ª²³´µ¶·¸¹º\Â\Ã\Ä\Å\Æ\Ç\È\É\Ê\Ò\Ó\Ô\Õ\Ö\×\Ø\Ù\Ú\á\â\ã\ä\å\æ\ç\è\é\êñòóôõö÷øùúÿ\Ä\0\0\0\0\0\0\0\0	\nÿ\Ä\0µ\0\0w\0!1AQaq\"2B‘¡±Á	#3Rğbr\Ñ\n$4\á%ñ\Z&\'()*56789:CDEFGHIJSTUVWXYZcdefghijstuvwxyz‚ƒ„…†‡ˆ‰Š’“”•–—˜™š¢£¤¥¦§¨©ª²³´µ¶·¸¹º\Â\Ã\Ä\Å\Æ\Ç\È\É\Ê\Ò\Ó\Ô\Õ\Ö\×\Ø\Ù\Ú\â\ã\ä\å\æ\ç\è\é\êòóôõö÷øùúÿ\Ú\0\0\0?\0ıS¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢ôªšµ®3uy¯¼\Ò,ú\0hQ^;­ş\Õ\ß<9­]iZŸ\Ä]F\ÚFŠX>Ó¹¢o\î¶\Ú\Åo\Ú\ÃI0ø\â\ÌGı\\\ĞøjvŠUşVş\ëP¾Q^\n¿\Zş\"\ë#\íşø5ª_\è²ÿ\0Ç´ú®¯o¦\Ü\íş-\Öò.\èÿ\0\àUNO\ÚW\Å~\Ôş\Ë\ã/ƒ>+\Ó\"–\ßÍ¶›@1\ëq\ÈÛ¶´m\ä\íò\Ûı\ê\0ú\ZŠ\à|ñ‹Â¾?\Óf»\ÓuX¢6Ò¥µÕ\×\î.l¦d\İ\ä\Ï}\Ù?Ù®\á€&¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¢Š(\0¨]\éÒ¶+\æ½b\Ş\ëöªñ‰|+yı«¥ü+\Ğ\åKio4ûŸ\'şKµm\ÒF³/\Íöh¶ª¶\ßõŒ\Íı\Ú\0\èu\ïx—\ã¹w\á\ï‡Z\Ñğ\î‰d^+\ï}š;Ÿ2\á~V·´O–M¿ò\ÒOº¿u~j<û)øgNğTzu\rCâ¬Ÿikß¶ø¾_´´o·o\î—\îÆ»»^Á¢\è\Ó-t\í2\Ö;h\Ö(¡‹\åH\Ñ…kSe\0p¾ø/\à_‡\Ó\Ã\áŸh\ÚW%d”iöQ\Å\æ2ÿ\0{û\ÕÛ¢SÒŸ@\ÙF\Ê}\Åx\ã\á/„>$i±Yø›\ÃZv½k¿iûuuóv\í\İş÷ûU\äP\ê:ı|Y4ZÌ²ø³\àÙ¶C¥\×\Ş\Ú\Ûv\ÏüW|\ß\ë>òªü\ß*\×\Ò\'¥e\êze®·¦\İ\é÷°\Çuiu\Û\Ü\Ã(Ü²#.\ÖVÿ\0e–€§\ßE©[Cw±\ÜZ\Ë\Z\Ë\Ñ|\Ë\"·Ì¬­ıİµ¤:W\È/Œb«K©¬ş\Ïâ¿ñ_Eû›«­º—†\á‘ö²\Æ\Íò\Í\n³.\İÍ¹V¾¯µ½‡RµŠhdhd$r\Äw)Vû¬¦€4(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0(¢˜\ïŠ\0òÏ\Ş:ºğ‚Ÿ£I\'ü%^!—û#GŠ\"«/\Ú$V\İ${¾Vh£Yf\Ú\ß{Ë®‹á‚tÿ\0†\ŞÒ¼9¦ˆ\Äv1s\å|‹$­óI&\ß\áó$goøy™ÿ\0„ÿ\0öª¿—ñ/ğ6’‘y2şö+‹»\ÆÜ³Gü1\É\Z\Ä\Ê\ß\Åû\Ê÷¤ 	¨¦o£}\0>Šfú}\0QLw\Å\0>Šfú§>£knd\Ó$Q|¼\ÊUW\æû´C\Å\Óü[\á\ÍCD\Ô\áK«\ëw¶–µ¾F]­÷«\Ï|¢|_\r|/›Q\Ö%ò¬„zf¥­le¹\nvıf]«\æF»~_\îÿ\0z½.\Ã[\Óõ/7\ìz…½÷”q\'•*\É\å·û[~\ípÿ\0ş\ËñÀ3Ã¦\È-uı2DÕ´{\Ï/\Í6×°ü\ÑÈ«üM÷—ş@”š}p	>!CñCÀZ~¹_eºyWVF]\ÒY]\Çò\Ïo.\ß\âM\Ê\Õ\ß\ĞEPEPEPEPEPEPEP\\Ç¼U§ø#\ÂZ®¿ªM\åiúmœ×·2¹¶F»›jÿ\0O»]úù\ÃÅ±ZşĞ¿-¼)¡$¾ğ5\ÊjZ\à\Óî¶­Îª­şc?÷•W÷Í·ø—kPMû&\éW¶\ß4oXµ¸µñ/‰¥—[\Õ>\×•,—6\í\Íü³\İ\Z\Çòÿ\0\rw?|Y¨øOD–]E—\ÄZÜ§Ê±\Ób>ZI/ğ´’7\ËküM]‚%|«ñ\Æ\ë\Å~\nøû§ø®ö\é/¾\Z\Üør]\ìrù‹z”Í¶?o\İY\Ûl^g\İ_\â ‹ş-ÁH~/ø\Æú…|so¡x–\ÆK7X³´¶‚\æ\Ê\æ\â9[\æ¶ó?yş\Î\Öû\ÛkŒğ\Ç\í]ñ«\ã\Ì_\Ûÿ\0ôÿ\0jº<’\êzeœ¶\Ëm¥4?z&\å_\îª\ÉòµeMñ\'\àı\Ï\Æ\Ï\Úx\çÀ—\r4ÿ\02\Ê\Æ\Öo\rG\ZÏ¢\\Zù‹v­$m»l’7ú\Åù™v×’x\ÏR\Ñ<}\á?Dğ—‚¤ºñW‡\ïZ\Æ_xn\ÖEƒV°‘¶\Â\Ó\Ã÷¼\æo—s}\ê\0ı§ı>;j?.o\í<Kaÿ\0\æ«$Q\\\Ø\è\×v3\Û]ıŸo\ïšO\İ\Ü|\ßò\Ò—\æ¯yG\Í~føK\âN«¦ş\Ç>\nÒµ8n?\ák[[\\j~›O±¹¹–\Ú\Öv\ÆÒ´*Ì»—tl²}\í\ß5}\ïğ[Ç³|Oø[\á¯^i÷\Z]Ö¥d’\Íg•<Rı\ÖV_\áù•¨¾ª\Ó\\Eone”ˆ\â¯û53×Œü\Ô<C¨iºƒü3¡ku\âhî¢—^´\r·MŠ8¼\Érÿ\0\Ëi\åøwP\Îÿ\0´_ü#ş‹]Zo	\érj–¶\É-µ\å¯\Ì\Ç÷ª«q>\ï•m$oİ¯ü´“\ï/\Ë_5ücı¿ş\"\ëv\ßk²Õ¾Õ§\êeÿ\0„wû?\Ãñ®‘-\Ül­?™öµi¤’)6\íhş]\Ûk—ø\éğ›Føoû+iV³]\Û\èºÖ¥­7ˆ5\rK\Ì\Ô\ìmä£°†Xfı\ã*ÿ\0\ËO÷·W„i¿³ÿ\0ü·–’x\î\î\Ú\Æ\ê\ÇGğ\İß¶š²|°5²¯ú\Æş%_\ïm ¢~ş\Øş/øo©\ê·~\ZğV\ã\Ïk’M©øš+G¹´¹¶··o™™cı\Ë}\ér¯\Şû\Õúyû<ş\Ñ~ı¦||K\áI®<˜¤û-\Ô7Q´r[\\yj\Íû[w}\êü\ÌıŒ?foÿ\0¿hÿ\0\nxƒ_ğıæƒ¢XÄ—:Æ¥-\Ê\ÇØ¦‰›lü_2\îeş\â¯føAûG\ÍğN\×À±xK\Ã7-\Ğ<M­xƒûsşX£¹\æ÷\í?¸ÿ\0i|¸ö³7\İ\Ú\Ë@P½¬ÿ\0ş:‹¿\í\0>ø\æ_(\ÙùK\r¶“ª\ÏM\ßİ¹û»ŠOš¾ˆJóô\ïµ¿\njq_\Û*mŠ\ím.\İ\ÑÈ¿\í+}Ú‡\à7¥ñ\ï€-&¼„Z\ëZ\\¤j–qH\Ò-µ\í¿\î\åwñ½@£EPEPEPEPEPE‡¥\0-RIşÎ¦YH1ÿ\0 ×x\Ûã® m áŸ†¿\áe_I¨ı†\æk[ÕƒO²Ú»™\ç¸ù¾]¬¿uZ€5~<|P—\áw„„ºf“>½\âMN\át\İH´‘VK›‰>UoöV?¼\Íü+Z¿¾Zü.ğM¦–wz¤»®uMK\ÊXå¾½“\æši?\Úf¬Ÿ‡\ß\r\î\íµ\Çñ¯Œ¦û\Æ\×Qùx‡\æ¶\Òm\Û\æû$¦\é>ôş\Ï\Ë^®:P]3^9ûFü3\×ş(x\ÚxOQ°¶Õ­¥I>Ç«DÍ§\êVÿ\0ò\Ò\Î}¿7–ÿ\0\Ş_™YV½šŠ\0ü¿Ô¿\à˜şøÅ¬ˆ,ôO|!şÈ·ò\îf»B\rJV‘™¤Šo3\Ìe_º»•~Pµ\í?	ÿ\0\àŸ÷_¼\àQñş(ıL³\ê\ÙZ$v:¥\ïÍ¹U®÷3*¯û¿v¾\Ô\ÙF\Ê\0óo…ÿ\0´_„ö\Ó;CT¾º\Û\çjZµ\Ï\Ún\äH\Æ\Ø\ãİµv«÷UV»Ë›øt\Ûo6o\İESM ·\å6ñ7öÇ•¿º‹ÿ\0Cşõ§n<e^Xa\â;\rKıLµ«\ÔW‚Y\ê·ZuÇ›µ\ì>\Öµ¦\Ç/ü´«;qùw\Ôıè†¡\àıS¸ûUî‹§]\İôóåµI6ÿ\0¼\Ë_+x³ş	£ğ\ÛS¸\Ô.ü3ªøƒÁ7W:´:Ø‹Oº_³[\ÜG&\íñF\Ëò¶\İ\Û~o—u}O¨<S\ä\roömñ¦·ªxƒE\Ö|I\â\r{\á\İÕ³	b\Ô5ö½»Ô¢]­\ä¬>\\kŒË·\Ì\İ÷~_\â¯]ø3ğ†\Ã\áİ¹›M´:‰%ºfxZ;h\àƒIV]\ÒÛ¹šffm\Ònû»Wøk×¼¡J‰Š\0«o\æıš/;÷s\ßKº¼.\ÎCğ¿ö˜\ÔE\Ùÿ\0‰7\Ä+x¾\Ë1;V+ûX\ÛıUŠH÷\Ì\Ò±^ı²¼Wö©øSñ\'\á¿\Úü?ÿ\0#¯†n\\Ğ¦ù·}ª›\ËùY\Ö.\èÿ\0\àT\ì\èõ5p?>\"\ÃñG\áş‹\âX!–\Ò[«dûU\Ô~T¶Ò¯\Ë$r/ğ²¶ï–»\ê\0(¢Š\0(¢Š\0(¢Š\0(¢Š\0)ø¡\ß\ç¿|a‚|¨]\rPh·÷;,,u³5\ÊE{p\ŞLÑ¯\Ş_1—u\0r~#Ô­>5øº\ïÁvcP“\Ãz%\ÏüOu->\åc¶–\áv·ös}\åi6\í\Ûò«}\êõmÃºW†´k]+FÓ¬ô½>\Øb+;H–8¢_öU~U®w\á\Ã\ËO‡‡JŒ‰¯\å?jÔ¯\æ’ú\é•|\é¤fù™™¿ñİ«]\í\01)ô\Ê}\0Sñ\\\ïü&\Úü%¿ğŠÿ\0kYÿ\0\ÂCö_¶ÿ\0fy\ËöŸ+\îù_÷h¥¨]\éôÇ 3\Æzÿ\0Ù­¥Š¼·­SøÉ£üQÓ¼{g­øN\Ò?xV\ê&¶¿ğß™\rÍ³¯İ¸‚\á¾V\İüJ\ßğ\Z§\àÿ\0\éş6ğŞŸ­\égö}\Ôò\×\åm\êÌ¬¬¿ì²²ÕŸq”\ÕÃ¨r\Ç\â61^‹ğ\Êø}šXOHø\ç\ï½^]ª\êš~‡¦Í¨jwvö\Z}¯\ï.o.¥ò¢‰?¼\Íü5[\á÷Æ¿\Ü\ê7r\éš\Ôz§•l÷1C§\Æ\ÒË©D¿zKE_øøUo•™‹u¹´\éN—,¤}5¾¦ª–\ï\ç\ÛE×¢õùZ¬%AğC\é”Q¾€\nŸHzPÏº×„eø\ã\í\Çz6ŸwªxW\Ä2¥×‰tØ‹I-”\Ëÿ\0/ğGüKÿ\0=W\ï|ª\Ë÷k\Öü\ã\Çş´\Öü5ª\ÚkºM\Ï^\ØK\æDvı\ï›ÿ\0e®‰Ò¼CÅŸ\"ğC_ø¿\á™ÿ\0„wZ¶\ß}.k»û7Rû\Í\"\Él¿/™\'üö_›r­\0{’>iõ\Íø3_“Å¾Òµi´\ë\Zk«h®$\Ónÿ\0\×\Û3/ú¹?\ÚZ\è\ÇJ\0Z(¢€\n(¢€\n(¢€ô¯Ÿ¾)™|[ûG|,\Ğ,Ï•ıö¿\İxIaTû/–«ÿ\0=<\ÉÕ¾o\áZ÷‹™Eµ¹“Ò¾}ø&¡ñC\â?Œ>*\Ş\Å¾ºÙ¦x>q\'šÿ\0Ù±ÿ\0®™º³Èª\Û[\æùh\è”LPô\ãÒ›@QE\ÄüR¼ñNŸ\à½FOiñ\ßø…öEl%‘Ub\Ü\ê­7\Í÷¼µfm¿Å·m`\éğ\ßÀ/\ê\Ú\İ\ï\Ú\ï\ä¶óoµ}\\\Ä\×7×\ß\ë&m«»ş¿*ªÿ\0³^¢õ\à?µ\ì\ÙwûK\è¶zPñÖ±\á;h\æ\Ì\Z_Ê²\\6\ß.I>efU_3\åş-\Ô\Öüı¤~şĞºv¡u\à}~=tXÈ±\Ü\Ä#h¤‹w\İo-¾m¿\íWªW\æ÷?\àš0ıš5;¿|9ø©$¾%\ÓmH´\ë­7Ê¶¾Eù¾\Ï>\×û­¶¾\Æø7ñ\ÓDø§\à=;[ó \Ó5Qd“jz<\Ò7\Úl_\î´rFÁdÛ»\î³/\Í@r¢ö‘\\b®\Zÿ\0\àÿ\0‡5ÿ\0\ÂI\åOm¨o±J\"•£†\å\îù‘ı\Öeù¶·ûM^€’Sˆ\ÍÆ¤\á\ïDóüğÿ\0‹4\Ï\ì­R\Ò\âûO¹¹_µY\Å&Ø®SşyÎ¿ò\Ò\ï-vz?†4Ÿ\ri¶¶šfŸicia\Ù\ía†%m\Óû«ıÕ­Ş”Œq@T«9û\Ó\Z‰O¦LõóG\íûCø—L¶Õ¼)ğOI³ñ\ç\Äû’\ßi¿yt\Ø[şZI÷U›ø|½Û¾j>š\ß\\ÿ\0‹u¹¼9\á½CP³\Ó\îu›«X¼Ï±\Úmó¥\Ûü+»\å\İ_˜2~ÚŸµ%·‰5o\rø¯@ƒÁ\×vÑ¶o‡Ù ‰ş]\Í%\ÃK\åÆ«4›·7Ìªµõ\Âÿ\0Ù«\Åş#\ZNµ\âoş$ø\à«\ëtºş\Èû2\ÚAzŒª\Ñ\î‘~o/ø¶ü´õ†õ\È|G¢Xj¶ğ\ÜE\ìKqº‰¢+veo™[ıšÙ¦B•)\é@Lz}2€<\à’Zñß…b\Ğ/4­\'GÖœ\Ø\Ş]\\\Ë;j_j_´O\"´ŸÂ²JËµ~U\Û^\Ä:W\É2øó¤ü7ı³´\í?S\Z¥Í§ˆt›_Z‹_õj{MóFÌ¿/—\"şñU¿»_[”\0´QE\0QE\0Ç§\Óñ@)ûOkò\Üx\0x;K–H|I\ãI?²,>\É.Ù£Fÿ\0]t¿\ŞX#ı\ã³^›\áxoO\Ò\àò\ãŠ\Ö\Ú(s–¿*\íÜ«ü=7W\"Mñöª’_øú\Ñ|¦ù½ı\Û[j·J­¹ç¢µ£º­^õ²€ôQO QC\Ñ@\Ó²õ»Yµ-6\î\Ú\Ò\êK	¥‰\âŠ\î-¬ñ;/\Ë\"«|»—\ï|\Õ\ä^	ø‘\ã	x’/\n|Rµ°Š[ëŸ³h^$\Óÿ\0\ã\ÛRU_–9\×şX\Ü7\Íòı\Öù¶\Ğ\ï\Úw_Ö¼\'ğ’ÿ\0V\Ñf–\Ú)]N\î\Ó÷—v\Ö[¿}$üS/ğÿ\0À«È¼O¦\Ë\ã\ëmÆ¾Ö´»_\Çõ¯‰<¯=obò¶¬2²ÿ\0¬¾\ë+}\ß\á\Ú\Õõ\Ã$S\æ#ûÁş~Zó[¾ğØ¾ÿ\0„kOCŠ\êU”\ÚZü°D\ê»~Hş\ì\Şm¿y«H­(K–¯\Âp¾ı¦&\Ñ³ô¯Š6ğ\ê\Ò\ìŠ-f›û.õÙ¾U‰¾fF_½}\ß\ïWºh¾!Ó¼Gh.´\Ëø5r\ÑùÖ’¬«½~ò\î_—ux\æ·\á\Ém­¥´\Ô\í#–\Ö\æ7Š_7÷±H÷•¿Ù¯1¿ø	à«›Ÿô->óA‡ş|ô\rJ\çM¶ÿ\0{É…•wµHõ\'•ª\Şõ	a=Ê\Î?\ïªó¿üğ\Ãû{YµŸ[B%¸{Xü’\ÓşõWsF\Ş^\í­şõ|ıkû?xR\Ú\æ)`ºñG›\É?\äi½o[şºWy¥iZ~‰ö¿\ì\Í>\ÏKûu\Ï\Ún¾\É\Åö™[\ïH\ß\Şoö©ò™\Ã%—ü½e-wâ¯ş#\Û}—\Ãúü+\í_ù‰\ëQyº”©÷Yc¶_–ş%‘·/û5o\àüöš/O‚¼3¢ikd\×:Æ³	\Üñ\\n_.–ošI¤Vi7nÜ¿\ì\×{\áŸ\0Í©;R[Eÿ\0<‹ş]W¼¢ü8ğ\ìZN‹hmm|Æ”şñ¥’Y[,\ÒI#|\Ì\Íı\æ«8ñ£FÊ—¼k\ê\Ú=†¹¦Í§\êvv÷ö1yRY\İ\Ç\æE*u£o•ªÅœ\Ú[E1\ÇQ.8¢Wjÿ\0\n­|Ï¢üZ?µ\Æø+\Ã> Š/\0xS\ì¿\ÚwšW™\İõ\îö\İn³}Õ…v®\æ_›økÓ¾<|z\Ğ>øn\Ö\ïS»·ş\Õ\Ô\î~Í¦Y\Í/–·ÿ\0´\ß\Ã\Zÿ\0ñU\äwŠ¼i¢x*\ÚgUKŠ\æU¶„\Ì6ù\ßuWü\í_\â®s\áW\Å\Ïø[3\ër\Ø\è—v:-‰†;]Jğ)ûL¬­\çG·û\Ñ7\Ê\ÛY•·|­^+\á/>&ø¢m<_\ãùc¿–]E/­tWÌ8¢o–fh\ão—Ì‡÷kn\ß.\ßõ»š¾£\ÑtM?Ãºe®¦Y\Û\Øiö±¬V\Öv±,qD‹÷UT}\Ú\0Õ¡è¢€>Dı±<	wm\ã_|@ğı­¯Š\ã\ã\Ãv\Z”Ád–+Û­«eµ[rª¬cnş\Õõ…‚Mö[_?ıw–gûû~jó\ÚS\Â7ş5ø\'\â½?LòÆ¶,\Ş\çLšI<¶¶¸\æYO\áeù¶µu¿\r|ga\ãÿ\0\0ø\Ä:d²M§jv1\\\Å$¿,›Y‰h¯¢t¥ Š( ¡›­MX¾\'[³\á\ÍC\ì;ş\×öi|¯\ïnò\Ûoş=¶€>TıuC\Çÿ\0~7ø—Sº¹\ê\Ã_\Ë?%µ\ê\Âß¸¹hÿ\0†E|\Ë÷—\ïW\ØUò¯ì™®ø¾\ë\Çş4\Ğ<e\â;T\Ò4\í:\r×”ó\Çu%¢µ\Í\ËH¿3no•¿‡u}U@>™BP\ëÅ¾#üVñ\ß\Âÿ\0E$ş\nM{\á\Í\Ï\Ù\âş\ØÒ®\Ó4\Öi6\É%\Ì-÷¡_½º?º¿z½¡\Ğ\\jd¶\â\áz\0öû\Ô\0\Øf\ê\Ş9aKœ\ç\ï)Zó¿Ò¼mğ›ÄºV³ı£ıŸ5³y¿\ÙqI%\ç\ÊÛ• Xşf‘[k.\Ú\ìmt\ì\íJ[¨%1\Ã/2\Ú}\ä\ßı\åş\íx\ß\Ç=\'V\Ñ4\Õñ€\Ô5	5/Qy,5*\Ç\ÌşÍ´eù¡¹[uÕ³2ü\ÛW\Ìù•—\î\Ğû;ş\Ñwúv¥¢ø\â.ªš\Õğÿ\0Šg\ÆÀùPø‚%ù|™\×şX\Ş\Ç÷d¾ó-}^’W\Ãpx\á\×\íOs«iömyğ\×â¥±‡Wó\ìe\Û\ìÑ¯\îo£_»qo¹Y~Y\æó>j\Úğ\í1\ã„·?ğ|Rğ}•§\èò¥¶©¬i7-\"\ÙDÍ¶‡…¾o³H\ß6\è÷,j\Û[\æ °®laº·ò¦‹Í¹\Ëÿ\0‡ZUÇ›,1Ik,Ÿó\Ëÿ\0‰­Ÿø—Iñn—«£jš¦Ÿ(ı\ÕİŒ«,rº\ËZ¾aô Ú•Z´ş	]¿\Â\í.\Ü~÷}\Ï\ÖMµ«¦ø/J\ÓFaµo¬¿3VÔ³\Çnq\Óÿ\0®\"\Û\ão\ÃıF\ê;[/x~\îò_\İ\Å\r®§²Hÿ\0\İUV\Ü\Íş\Í\ËZóex\Ä?—z×‰µo|-ŠOø\æ\ÆHb\Ô\å‹j\Ù\èñHûZY\äo•¤Uù–ù™€\İò\ÔZ\Åïˆ¿\ÏöW¾\êš\r¥÷ü{x\ÃÄZ\ÚEüöû6\ï9™—\î\ÆÊ¿7Ş­¿xÀ²·€<¯\í}*1\äº\Ôu	?}p\ß37÷¤‘›øWs\n\Ğs\Z^	ğgƒÿ\0f…÷QA<v\ZU®û\ëıF]ª\×W>\é$m¿zI¾Uÿ\0iUk\Ì<\'ğUø\ë\â\áñ/\âÄ·Có\Å\á\ï\Å#Emc§³\Ë\Ìò\ÒI\×kH­÷~Uş\Z\î¼1\á}W\âÎ»i\ãO\Ù\Éa¢[I\æø{Â·_ò\Ëû··+üSv?ùf¿\íWµ\ì \Å·_*!ùÔ©E\0QENhcº¶–9¼¹at?2\íş*ñÙ¾\â_\rj>\Í$’ÿ\0\Â3­<–¦!¶\Ú+K\Í\×ö\Ğ/ğ¬1ü»\ïš÷ºğO‹r‡?ü\ã­\Æ\ÛI¿‘ü7®\Í/\Í•\'\Íiû¿ù\è\×>ZùŸİ })i‰O Š( ¡zš˜ô\â?´;_~\Ğ\ßå¼»\Òÿ\0¶üC–¥m_5\ÏØ¡mÙ¤ù~Uó—\î\î¯n¯ñ¾/‡>5øW\Ç_j‚>\æ\Éü5©ı®Vû’K\æ[y\n«ş±¦ù[øv×²%\0>Š( )ô\Ê}\01\ê“Û´yÙ’?§Ê¿ğ*ºõ\Éx\ï\â7†¾\éqj\Ş*Õ­ô-:[”µwRmÍ“\î«7ğ\Ğ“|aı”´ÿ\0\Ü\Øk~\r\Ô#ğOŒ,o¥¾µ\Ö!µó\Ö)fUYdò÷/Íµ~_\á\Ü\ÌÌ­º¼‡\Æß´–µğ\Ú\æo\r|Xğ~¯Km+\Ø\êzôQµ´Z’H\ŞtV0\íf¸™£\Ú\Í\å]\ß-}¹\Şzù£Yürµ\Îø\ÇÀš\'4Ág¯i\Ö÷ğ\â/4~ò&a·tR}\è\Ûı¥ù¨\æ?X|0ı¡´Xtÿ\0…Ÿ5Ï…ò\Û\\=\Í÷…´Rº}\ÌW²~ñš{iv\å\Û÷W\å«	\á_\Ú?\ÂZt\Ú\'„ş-øC\â.¡mpÿ\0jÿ\0„ª\ÇÊ»¶I?Õ«y-ÿ\0²ÕŸÿ\0Á7>ø\æ-CF‡\Ä\rñW/sı½¢\ê\ÓıºMËµ·I#7ÿ\0^{ğ÷ö\Zø\ëğš\ßU´ğo\Çû}*\Öúõ\î®f›\Ã\ésyrÿ\0\Â\Ó\Í#n‘¶\Ğ\ëÿ\0¿j\ïzœºOş%ø\Â^º³û-õŸ„#i<\ÕİŸº\ß2³}\İÛ«©øCğ\'ökøñb\ê\î\ézÇ\ì¢Ib—[\Ô\à’{•<¿—n\ÕVùŞ­\Û\ï\Ø\Û\Å^>\Ñt¯øO~:x\ãT\Ö\ìKH%\Ğ$‡M¶\r»\ï,j»›\î¯\Şf«÷Ÿ±­\İKÿ\0	/ŠuX\\\È\æş\Òÿ\0I\Ócûj·\Şó&\İd]\ß\ŞV\İ@¿¿o\Ï\èzl?ğƒZ\Şxö\î\ê\æc=¬REie\æ7ß¶ù\Ë\İÌ¬±²·÷«K\àÿ\0ÁŸ|Gñm¯Ä¯‹÷q\ë\Z…oøFt²ù\ÚlMÿ\0/C¹—\í-ı\ï\á_÷«\×ş\Züğ‡Á\İ2;OhiñEÙ„ÿ\04“ù[·,^k|\ŞZÿ\0\n\îÚµ\ß\ì )õ\á\Ş5ø÷«[jWvğ­¿Œ¢\Ó%û6§©_\êñ\évQ\\\Ï\ç‘Yd“ûÊ¿wr×¬xsUş\Û\ĞôûüA\æ\Í™bµ¹Y\â‰öüÈ²/\Ê\Û[\å\İ@4QE\0QE\0óü_\Ô|7û3ø—U\Ñ\ì#º\Ôln-e¶–[V—ì®³¯úB…ş(şò·\İ_â¯§k\Ékù6\ï‰ö.^ÿ\0\èº\0\ïü)<—^\Ò\æO6im¢\Ì~ôŒÑ«3Võs¿ÿ\0\äIğÿ\0ıƒmôR\×E@Q@Q@^#\Ñ ñ‰w¥]KqWQ´^m¤\Í£w÷dS¹[ıªó¯…ÿ\04/ˆ>?ñ·‚t{k´¹ğe\Ô]Üœı¥\Ì>\ß÷¼\ßzŠ(\×è¢Š\0(¢Š\0¾søõ\ãøMñ>©\â¿øo\Ç\í\â_;G‡r\êe\ß$¾w\îdTş\êü\ÍEKö5ñô>?\Ñ<hú4—gÁ6\ZÈ¶ğ\ìz‡úÈ­Œ\n\æ<\îf\Ø›b·\İ\\-}9E\0\Ê(¢€\n(¢€Lz( ­ÿ\0co‡¢óO]f;ÿ\0\éze\Ë\\\éš.¡r\Íal¬\ì\ÛZ»6×•\Ût»›\çÿ\0f½£\Â\Ş\Òü¢\Ú\é:.•i£\év¡ü«;H–8c\ËnùUh¢€7h¢Š\0(¢Š\0+\Âmoişı™ş#]\ê2\ÉR\éY\Æ\"qJ<¸\Ïıô\ÔQ@±\à4ÿ\0Š\'\Ãÿ\0ö\r·ÿ\0\ÑK]\rPÿ\Ù'),(157,'401',4,'Semi-Furnished','Vacant',18000.00,NULL),(158,'402',4,'Fully Furnished','Vacant',26000.00,NULL),(159,'501',5,'Fully Furnished','Vacant',26000.00,NULL),(160,'502',5,'Fully Furnished','Under Maintenance',26000.00,NULL),(161,'103',1,'Unfurnished','Occupied',12000.00,NULL),(162,'203',2,'Semi-Furnished','Occupied',18000.00,NULL),(163,'303',3,'Fully Furnished','Occupied',26000.00,NULL),(164,'403',4,'Unfurnished','Occupied',12000.00,NULL),(165,'503',5,'Semi-Furnished','Under Maintenance',18000.00,NULL);
/*!40000 ALTER TABLE `units` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `v_billing`
--

DROP TABLE IF EXISTS `v_billing`;
/*!50001 DROP VIEW IF EXISTS `v_billing`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `v_billing` AS SELECT 
 1 AS `BILLING_ID`,
 1 AS `LEASE_ID`,
 1 AS `BILL_TYPE`,
 1 AS `BILL_DATE`,
 1 AS `DUE_DATE`,
 1 AS `AMOUNT`,
 1 AS `AMOUNT_PAID`,
 1 AS `LAST_PAYMENT_DATE`,
 1 AS `LAST_PAYMENT_MODE`,
 1 AS `LAST_REF_NO`,
 1 AS `CANCELLED`,
 1 AS `PERSONNEL_ID`,
 1 AS `CREATED_AT`,
 1 AS `UPDATED_AT`,
 1 AS `BALANCE`,
 1 AS `STATUS`*/;
SET character_set_client = @saved_cs_client;

--
-- Final view structure for view `v_billing`
--

/*!50001 DROP VIEW IF EXISTS `v_billing`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `v_billing` AS select `b`.`BILLING_ID` AS `BILLING_ID`,`b`.`LEASE_ID` AS `LEASE_ID`,`b`.`BILL_TYPE` AS `BILL_TYPE`,`b`.`BILL_DATE` AS `BILL_DATE`,`b`.`DUE_DATE` AS `DUE_DATE`,`b`.`AMOUNT` AS `AMOUNT`,coalesce(`p`.`PAID`,0.00) AS `AMOUNT_PAID`,`p`.`PAYMENT_DATE` AS `LAST_PAYMENT_DATE`,`p`.`PAYMENT_MODE` AS `LAST_PAYMENT_MODE`,`p`.`REF_NO` AS `LAST_REF_NO`,`b`.`CANCELLED` AS `CANCELLED`,`b`.`PERSONNEL_ID` AS `PERSONNEL_ID`,`b`.`CREATED_AT` AS `CREATED_AT`,`b`.`UPDATED_AT` AS `UPDATED_AT`,(`b`.`AMOUNT` - coalesce(`p`.`PAID`,0.00)) AS `BALANCE`,(case when (`b`.`CANCELLED` = 1) then 'Cancelled' when (coalesce(`p`.`PAID`,0) >= `b`.`AMOUNT`) then 'Paid' when (`b`.`DUE_DATE` < curdate()) then 'Overdue' when (coalesce(`p`.`PAID`,0) > 0) then 'Partially Paid' else 'Unpaid' end) AS `STATUS` from (`billing` `b` left join (select `payment`.`BILLING_ID` AS `BILLING_ID`,`payment`.`PAYMENT_DATE` AS `PAYMENT_DATE`,`payment`.`PAYMENT_MODE` AS `PAYMENT_MODE`,`payment`.`REF_NO` AS `REF_NO`,sum(`payment`.`AMOUNT`) OVER (PARTITION BY `payment`.`BILLING_ID` )  AS `PAID`,row_number() OVER (PARTITION BY `payment`.`BILLING_ID` ORDER BY `payment`.`PAYMENT_DATE` desc,`payment`.`PAYMENT_ID` desc )  AS `rn` from `payment` where (`payment`.`STATUS` = 'Completed')) `p` on(((`p`.`BILLING_ID` = `b`.`BILLING_ID`) and (`p`.`rn` = 1)))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-11-23 15:04:25
