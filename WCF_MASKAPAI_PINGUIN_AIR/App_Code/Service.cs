using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    public List<penerbangan> getPenerbangan(string kota_asal, string kota_tujuan, DateTime tanggal_keberangkatan)
    {
        List<penerbangan> penerbangans = new List<penerbangan>();
        penerbangan tmp = new penerbangan();
        pinguin_airEntities3 pinguin = new pinguin_airEntities3();
        IEnumerable<penerbangan> daftar = from p in pinguin.penerbangan where ((p.kota_asal == kota_asal) && (p.kota_tujuan == kota_tujuan) && p.tanggal_keberangkatan == tanggal_keberangkatan) select p;
        if (daftar.Count() == 0)
        {
            penerbangan a = new penerbangan();
            a.kota_asal = "NULL";
            penerbangans.Add(a);
            return penerbangans;
        }
        foreach (var k in daftar)
        {
            penerbangan pr = new penerbangan();
            pr.id = k.id;
            pr.harga = k.harga;
            pr.jam_keberangkatan = k.jam_keberangkatan;
            pr.jam_tiba = k.jam_tiba;
            pr.kota_asal = k.kota_asal;
            pr.kota_transit = k.kota_transit;
            pr.kota_tujuan = k.kota_tujuan;
            pr.nama_maskapai = k.nama_maskapai;
            pr.tanggal_keberangkatan = k.tanggal_keberangkatan;
            pr.bagasi_maksimum = k.bagasi_maksimum;
            pr.bandara_asal = k.bandara_asal;
            pr.bandara_transit = k.bandara_transit;
            pr.bandara_tujuan = k.bandara_tujuan;
            pr.durasi = k.durasi;
            penerbangans.Add(pr);
        }
        return penerbangans;
    }

    public int bayar(int id_tiket)
    {
        pinguin_airEntities3 pinguin = new pinguin_airEntities3();
        tiket tkt = pinguin.tiket.Find(id_tiket);
        tkt.status = "Lunas";
        string path = Path.GetRandomFileName();
        path = path.Replace(".", "");
        tkt.kode_booking = path;
        pinguin.SaveChanges();
        return 1;
    }



    public CompositeType getTiket(int id_tiket)
    {
        pinguin_airEntities3 pinguin = new pinguin_airEntities3();
        //tiket
        var tik = (from u in pinguin.tiket
                   where u.id == id_tiket
                   select u).FirstOrDefault();
        tiket t = new tiket();
        t.batas_waktu_bayar_atm = tik.batas_waktu_bayar_atm;
        t.batas_waktu_bayar_internet_banking = t.batas_waktu_bayar_internet_banking;
        t.id = tik.id;
        t.id_penerbangan = tik.id_penerbangan;
        t.kode_bayar = tik.kode_bayar;
        t.kode_booking = tik.kode_booking;
        //t.penerbangan = tik.penerbangan;
        //t.penumpang = tik.penumpang;
        t.status = tik.status;
        t.user_id = tik.user_id;
        t.waktu_booking = tik.waktu_booking;
        t.total_harga = tik.total_harga;

        //daftar penumpang
        IEnumerable<penumpang> daftarPenumpang = from p in pinguin.penumpang where p.id_tiket == id_tiket select p;
        penumpang pn;
        List<penumpang> penumpangs = new List<penumpang>();
        foreach (var a in daftarPenumpang)
        {
            pn = new penumpang();
            pn.id_tiket = id_tiket;
            pn.nama = a.nama;
            pn.nomor_identitas = a.nomor_identitas;
            penumpangs.Add(pn);
        }

        //penerbangan
        penerbangan k = pinguin.penerbangan.Find(t.id_penerbangan);
        penerbangan pr = new penerbangan();
        pr.id = k.id;
        pr.harga = k.harga;
        pr.jam_keberangkatan = k.jam_keberangkatan;
        pr.jam_tiba = k.jam_tiba;
        pr.kota_asal = k.kota_asal;
        pr.kota_transit = k.kota_transit;
        pr.kota_tujuan = k.kota_tujuan;
        pr.nama_maskapai = k.nama_maskapai;
        pr.tanggal_keberangkatan = k.tanggal_keberangkatan;
        pr.bagasi_maksimum = k.bagasi_maksimum;
        pr.bandara_asal = k.bandara_asal;
        pr.bandara_transit = k.bandara_transit;
        pr.bandara_tujuan = k.bandara_tujuan;
        pr.durasi = k.durasi;

        CompositeType composit = new CompositeType();
        composit.penerbangan_sah = pr;
        composit.tiket_sah = t;
        composit.daftarPenumpang = penumpangs;

        return composit;
    }

    public List<tiket> getPemesanan(int user_id)
    {
        List<tiket> tikets = new List<tiket>();
        tiket tmp = new tiket();
        pinguin_airEntities3 pinguin = new pinguin_airEntities3();
        IEnumerable<tiket> daftar = from t in pinguin.tiket where t.user_id == user_id select t;
        if (daftar.Count() == 0)
        {
            tiket a = new tiket();
            a.kode_bayar = "NULL";
            tikets.Add(a);
            return tikets;
        }
        foreach (var k in daftar)
        {
            tiket tk = new tiket();
            tk.id = k.id;
            tk.id_penerbangan = k.id_penerbangan;
            tk.kode_bayar = k.kode_bayar;
            tk.kode_booking = k.kode_booking;
            tk.status = k.status;
            tk.total_harga = k.total_harga;
            tk.user_id = k.user_id;
            tk.waktu_booking = k.waktu_booking;
            tk.batas_waktu_bayar_atm = k.batas_waktu_bayar_atm;
            tk.batas_waktu_bayar_internet_banking = k.batas_waktu_bayar_internet_banking;
            tikets.Add(tk);
        }
        return tikets;
    }


    public int booking(int id_penerbangan, List<penumpang> penumpangs, int user_id)
    {
        pinguin_airEntities3 pinguin = new pinguin_airEntities3();
        tiket tkt = new tiket();
        tkt.id_penerbangan = id_penerbangan;
        string path = Path.GetRandomFileName();
        path = path.Replace(".", "");
        tkt.kode_bayar = path;
        tkt.kode_booking = "NULL";
        tkt.status = "Belum Bayar";
        tkt.user_id = user_id;
        tkt.waktu_booking = DateTime.Now;
        tkt.batas_waktu_bayar_atm = DateTime.Now.AddMinutes(60);
        tkt.batas_waktu_bayar_internet_banking = DateTime.Now.AddMinutes(30);

        penerbangan p = pinguin.penerbangan.Find(id_penerbangan);
        tkt.total_harga = penumpangs.Count() * p.harga;
        pinguin.tiket.Add(tkt);
        pinguin.SaveChanges();

        penumpang pn;
        foreach (var a in penumpangs)
        {
            pn = new penumpang();
            pn.id_tiket = tkt.id;
            pn.nama = a.nama;
            pn.nomor_identitas = a.nomor_identitas;
            pinguin.penumpang.Add(pn);
            pinguin.SaveChanges();
        }
        return 0;
    }
}
