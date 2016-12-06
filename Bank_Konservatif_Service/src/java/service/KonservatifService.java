/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package service;

import controller.NasabahJpaController;
import controller.TransaksiJpaController;
import controller.exceptions.NonexistentEntityException;
import entity.Nasabah;
import entity.Transaksi;
import java.sql.Date;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

/**
 *
 * @author hikennoace
 */
@WebService(serviceName = "KonservatifService")
public class KonservatifService {

    private EntityManagerFactory emf = Persistence.createEntityManagerFactory("Bank_Konservatif_ServicePU");
    private NasabahJpaController nb = new NasabahJpaController(emf);
    private TransaksiJpaController tr = new TransaksiJpaController(emf);

    /**
     * This is a sample web service operation
     */
    @WebMethod(operationName = "hello")
    public String hello(@WebParam(name = "name") String txt) {
        return "Hello " + txt + " !";
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "login")
    public int login(@WebParam(name = "nomor_kartu") String nomor_kartu, @WebParam(name = "nomor_pin") String nomor_pin) {
        Nasabah nasabah = nb.getnasabah(nomor_kartu, nomor_pin);
        //System.out.println("ok");
        if (nasabah == null) {
            return 0;
        } else {
            //System.out.println(nasabah.getId());
            return nasabah.getId();
        }
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "cekTransaksiMasuk")
    public int cekTransaksiMasuk(@WebParam(name = "kode_transaksi") String kode_transaksi, @WebParam(name = "jumlah") int jumlah) {
        Transaksi transaksi = tr.gettransaksi(kode_transaksi);
        if (transaksi == null) {
            return 0;
        } else {
            if(transaksi.getJumlah()<jumlah)
            {
                return 0;
            }
            return 1;
        }
    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "transfer")
    public int transfer(@WebParam(name = "jumlah") int jumlah, @WebParam(name = "id_pengirim") int id_pengirim, @WebParam(name = "kode_transaksi") String kode_transaksi) throws NonexistentEntityException, Exception {
        //TODO write your implementation code here:
        EntityManagerFactory managerFactory = managerFactory = Persistence.createEntityManagerFactory("Bank_Konservatif_ServicePU");
        EntityManager manager = managerFactory.createEntityManager();

        Nasabah pengirim = nb.findNasabah(id_pengirim);
        Nasabah tujuan = nb.findNasabah(2);
        //saldo tidak cukup
        if (pengirim.getSaldo() < jumlah) {
            return 0;
        } else {
            Transaksi tran = new Transaksi();
            tran.setJenisRansaksi("keluar");
            tran.setJumlah(jumlah);
            tran.setKodeTransaksi(kode_transaksi);
            tran.setRekeningAsal(pengirim);
            tran.setRekeningTujuan(tujuan);
            java.util.Date dt = new java.util.Date();
            java.text.SimpleDateFormat sdf = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
            String currentTime = sdf.format(dt);
            tran.setWaktuTransaksi(dt);
            tr.create(tran);

            tran = new Transaksi();
            tran.setJenisRansaksi("masuk");
            tran.setJumlah(jumlah);
            tran.setKodeTransaksi(kode_transaksi);
            tran.setRekeningAsal(pengirim);
            tran.setRekeningTujuan(tujuan);
            tran.setWaktuTransaksi(dt);
            tr.create(tran);

            manager.getTransaction().begin();
            Nasabah  a= manager.find(Nasabah.class, id_pengirim);
            a.setSaldo(a.getSaldo()-jumlah);
            manager.merge(a);
            Nasabah  t= manager.find(Nasabah.class, 2);
            t.setSaldo(t.getSaldo()+jumlah);
            manager.merge(t);
            manager.getTransaction().commit();
            return 1;
        }

    }

    /**
     * Web service operation
     */
    @WebMethod(operationName = "cekSaldo")
    public int cekSaldo(@WebParam(name = "id_nasabah") int id_nasabah) {
        //TODO write your implementation code here:
        Nasabah nas = nb.findNasabah(id_nasabah);
        return nas.getSaldo();
    }
}
