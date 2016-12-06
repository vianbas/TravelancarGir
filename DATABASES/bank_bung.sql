/*
SQLyog Ultimate v8.6 Beta2
MySQL - 5.5.5-10.1.10-MariaDB : Database - bank_bung
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`bank_bung` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `bank_bung`;

/*Table structure for table `migration` */

DROP TABLE IF EXISTS `migration`;

CREATE TABLE `migration` (
  `version` varchar(180) NOT NULL,
  `apply_time` int(11) DEFAULT NULL,
  PRIMARY KEY (`version`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `migration` */

LOCK TABLES `migration` WRITE;

insert  into `migration`(`version`,`apply_time`) values ('m000000_000000_base',1463220078),('m130524_201442_init',1463220080);

UNLOCK TABLES;

/*Table structure for table `nasabah` */

DROP TABLE IF EXISTS `nasabah`;

CREATE TABLE `nasabah` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomor_kartu` varchar(250) DEFAULT NULL,
  `pin` varchar(250) DEFAULT NULL,
  `nomor_rekening` varchar(250) DEFAULT NULL,
  `saldo` int(11) DEFAULT NULL,
  `id_akun` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_akun` (`id_akun`),
  CONSTRAINT `nasabah_ibfk_1` FOREIGN KEY (`id_akun`) REFERENCES `user` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `nasabah` */

LOCK TABLES `nasabah` WRITE;

insert  into `nasabah`(`id`,`nomor_kartu`,`pin`,`nomor_rekening`,`saldo`,`id_akun`) values (1,'11111111','11111111','11111111',3968000,1),(2,'11314062','11314062','11314062',5870000,2);

UNLOCK TABLES;

/*Table structure for table `transaksi` */

DROP TABLE IF EXISTS `transaksi`;

CREATE TABLE `transaksi` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `jenis_transaksi` enum('keluar','masuk') DEFAULT NULL,
  `kode_transaksi` varchar(250) DEFAULT NULL,
  `rekening_asal` int(11) DEFAULT NULL,
  `rekening_tujuan` int(11) DEFAULT NULL,
  `jumlah` int(11) DEFAULT NULL,
  `waktu_tansaksi` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `rekening_asal` (`rekening_asal`),
  KEY `rekening_tujuan` (`rekening_tujuan`),
  CONSTRAINT `transaksi_ibfk_1` FOREIGN KEY (`rekening_asal`) REFERENCES `nasabah` (`id`),
  CONSTRAINT `transaksi_ibfk_2` FOREIGN KEY (`rekening_tujuan`) REFERENCES `nasabah` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;

/*Data for the table `transaksi` */

LOCK TABLES `transaksi` WRITE;

insert  into `transaksi`(`id`,`jenis_transaksi`,`kode_transaksi`,`rekening_asal`,`rekening_tujuan`,`jumlah`,`waktu_tansaksi`) values (12,'keluar','aaaa',2,1,9000,'2016-05-17 04:42:30'),(13,'masuk','aaaa',2,1,9000,'2016-05-17 04:42:30'),(14,'keluar','hhhhh',2,1,9000,'2016-05-17 04:55:38'),(15,'masuk','hhhhh',2,1,9000,'2016-05-17 04:55:38'),(16,'keluar','odvhwg3tshk',2,1,900000,'2016-05-23 01:34:25'),(17,'masuk','odvhwg3tshk',2,1,900000,'2016-05-23 01:34:25'),(18,'keluar','3mzqef5hwmy',2,1,800000,'2016-05-23 04:40:50'),(19,'masuk','3mzqef5hwmy',2,1,800000,'2016-05-23 04:40:50'),(20,'keluar','jkmd5wplwkf',2,1,550000,'2016-05-23 10:04:08'),(21,'masuk','jkmd5wplwkf',2,1,550000,'2016-05-23 10:04:08'),(22,'keluar','vy4eyxy2wqh',2,1,1200000,'2016-05-23 14:46:52'),(23,'masuk','vy4eyxy2wqh',2,1,1200000,'2016-05-23 14:46:52'),(24,'keluar','dctsh5i2ezv',2,1,500000,'2016-05-23 16:27:50'),(25,'masuk','dctsh5i2ezv',2,1,500000,'2016-05-23 16:27:50');

UNLOCK TABLES;

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `auth_key` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `password_hash` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `password_reset_token` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `status` smallint(6) NOT NULL DEFAULT '10',
  `created_at` int(11) NOT NULL,
  `updated_at` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`),
  UNIQUE KEY `email` (`email`),
  UNIQUE KEY `password_reset_token` (`password_reset_token`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

/*Data for the table `user` */

LOCK TABLES `user` WRITE;

insert  into `user`(`id`,`username`,`auth_key`,`password_hash`,`password_reset_token`,`email`,`status`,`created_at`,`updated_at`) values (1,'admin','KHpkhC16HiKN1tG8bYEm6I9r5jh1N6fW','$2y$13$xJ8yBKyF4YSEcz8G1a34v./obXoyuRx4iAoE/v/rgRyCF9da8JE0q',NULL,'admin@admin.admin',10,1463220113,1463220113),(2,'11314062','cDR8-4pJaQqIA5PzOItU55zTWiV9X8qq','$2y$13$/GcSwtbrJLEKddkO1jDrWOf1lCkivCuc1SVOcPYw1mInjpRIhcS7K',NULL,'if314062@gmail.com',10,1463386743,1463386743);

UNLOCK TABLES;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
