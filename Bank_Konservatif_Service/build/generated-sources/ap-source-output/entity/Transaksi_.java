package entity;

import entity.Nasabah;
import java.util.Date;
import javax.annotation.Generated;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2016-05-17T11:33:01")
@StaticMetamodel(Transaksi.class)
public class Transaksi_ { 

    public static volatile SingularAttribute<Transaksi, Integer> jumlah;
    public static volatile SingularAttribute<Transaksi, Nasabah> rekeningTujuan;
    public static volatile SingularAttribute<Transaksi, Date> waktuTransaksi;
    public static volatile SingularAttribute<Transaksi, Nasabah> rekeningAsal;
    public static volatile SingularAttribute<Transaksi, Integer> id;
    public static volatile SingularAttribute<Transaksi, String> kodeTransaksi;
    public static volatile SingularAttribute<Transaksi, String> jenisRansaksi;

}