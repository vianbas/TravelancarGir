package entity;

import entity.Transaksi;
import javax.annotation.Generated;
import javax.persistence.metamodel.CollectionAttribute;
import javax.persistence.metamodel.SingularAttribute;
import javax.persistence.metamodel.StaticMetamodel;

@Generated(value="EclipseLink-2.5.2.v20140319-rNA", date="2016-05-17T11:33:01")
@StaticMetamodel(Nasabah.class)
public class Nasabah_ { 

    public static volatile CollectionAttribute<Nasabah, Transaksi> transaksiCollection;
    public static volatile CollectionAttribute<Nasabah, Transaksi> transaksiCollection1;
    public static volatile SingularAttribute<Nasabah, String> pin;
    public static volatile SingularAttribute<Nasabah, String> nomorRekening;
    public static volatile SingularAttribute<Nasabah, Integer> id;
    public static volatile SingularAttribute<Nasabah, String> nomorKartu;
    public static volatile SingularAttribute<Nasabah, Integer> saldo;

}