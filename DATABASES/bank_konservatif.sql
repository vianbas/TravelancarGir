/*
SQLyog Ultimate v8.6 Beta2
MySQL - 5.5.5-10.1.10-MariaDB : Database - bank_konservatif
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`bank_konservatif` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `bank_konservatif`;

/*Table structure for table `nasabah` */

DROP TABLE IF EXISTS `nasabah`;

CREATE TABLE `nasabah` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nomor_kartu` varchar(100) DEFAULT NULL,
  `pin` varchar(100) DEFAULT NULL,
  `nomor_rekening` varchar(100) DEFAULT NULL,
  `saldo` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `nasabah` */

LOCK TABLES `nasabah` WRITE;

insert  into `nasabah`(`id`,`nomor_kartu`,`pin`,`nomor_rekening`,`saldo`) values (1,'11314062','11314062','11314062',1000000),(2,'11111111','11111111','11111111',0),(3,'11314061','11314061','11314061',9000000),(4,'11414013','11414013','11414013',8000000);

UNLOCK TABLES;

/*Table structure for table `transaksi` */

DROP TABLE IF EXISTS `transaksi`;

CREATE TABLE `transaksi` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `jenis_ransaksi` enum('masuk','keluar') DEFAULT NULL,
  `kode_transaksi` varchar(250) DEFAULT NULL,
  `rekening_asal` int(100) NOT NULL,
  `rekening_tujuan` int(100) NOT NULL,
  `jumlah` int(11) DEFAULT NULL,
  `waktu_transaksi` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `rekening_asal` (`rekening_asal`),
  KEY `rekening_tujuan` (`rekening_tujuan`),
  CONSTRAINT `transaksi_ibfk_1` FOREIGN KEY (`rekening_asal`) REFERENCES `nasabah` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `transaksi_ibfk_2` FOREIGN KEY (`rekening_tujuan`) REFERENCES `nasabah` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Data for the table `transaksi` */

LOCK TABLES `transaksi` WRITE;

insert  into `transaksi`(`id`,`jenis_ransaksi`,`kode_transaksi`,`rekening_asal`,`rekening_tujuan`,`jumlah`,`waktu_transaksi`) values (1,'masuk','dctsh5i2ezv',3,2,500000,'0000-00-00 00:00:00');

UNLOCK TABLES;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
