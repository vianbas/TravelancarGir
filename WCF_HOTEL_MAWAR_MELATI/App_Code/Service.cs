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

    public List<kamar> getKamar()
    {
        List<kamar> kamars = new List<kamar>();
        kamar tmp = new kamar();
        hotel_mawar_melatiEntities2 hotel = new hotel_mawar_melatiEntities2();
        IEnumerable<kamar> daftar = from p in hotel.kamar select p;
        foreach (var k in daftar)
        {
            tmp = new kamar();
            tmp.id = k.id;
            tmp.kategori = k.kategori;
            tmp.jumlah_tersedia = k.jumlah_tersedia;
            tmp.harga_akhir_pekan = k.harga_akhir_pekan;
            tmp.harga_hari_biasa = k.harga_hari_biasa;
            tmp.free_wifi = k.free_wifi;
            tmp.free_breakfast = k.free_breakfast;
            tmp.jumlah_guest = k.jumlah_guest;
            kamars.Add(tmp);
        }
        return kamars;
    }

    public List<pemesanan> getPemesanan(string nama)
    {
        List<pemesanan> pemesanans = new List<pemesanan>();
        pemesanan pesan = new pemesanan();
        hotel_mawar_melatiEntities2 hotel = new hotel_mawar_melatiEntities2();
        IEnumerable<pemesanan> daftar = from p in hotel.pemesanan where p.nama_pemesan == nama select p;
        foreach (var k in daftar)
        {
            pesan = new pemesanan();
            pesan.id = k.id;
            pesan.id_kamar = k.id_kamar;
            pesan.kode_booking = k.kode_booking;
            pesan.nama_pemesan = k.nama_pemesan;
            pesan.tanggal_booking = k.tanggal_booking;
            pesan.tanggal_check_in = k.tanggal_check_in;
            pesan.tanggal_check_out = k.tanggal_check_out;
            pesan.total_harga = k.total_harga;
            pemesanans.Add(pesan);
        }
        return pemesanans;

    }

    public CompositeType booking(DateTime tanggal_check_in, DateTime tanggal_check_out, string nama, int idKamar)
    {
        hotel_mawar_melatiEntities2 hotel = new hotel_mawar_melatiEntities2();
        kamar km = hotel.kamar.Find(idKamar);
        int total = 0;
        int hargaBiasa = km.harga_hari_biasa;
        int hargaPekan = km.harga_akhir_pekan;
        for (DateTime x = tanggal_check_in; x <= tanggal_check_out; x = x.AddDays(1))
        {
            if (x.DayOfWeek.ToString() == "Saturday" || x.DayOfWeek.ToString() == "Sunday")
            {
                total = total + hargaPekan;
            }
            else
            {
                total = total + hargaBiasa;
            }
        }
        km.jumlah_tersedia = km.jumlah_tersedia - 1;
        hotel.SaveChanges();
        pemesanan pesan = new pemesanan();
        pesan.id_kamar = idKamar;
        pesan.nama_pemesan = nama;
        pesan.tanggal_booking = DateTime.Now;
        pesan.tanggal_check_in = tanggal_check_in;
        pesan.tanggal_check_out = tanggal_check_out;
        pesan.total_harga = total;
        string path = Path.GetRandomFileName();
        path = path.Replace(".", "");
        pesan.kode_booking = path;
        hotel.pemesanan.Add(pesan);
        hotel.SaveChanges();

        CompositeType rt = new CompositeType();
        rt.kodeBooking = pesan.kode_booking;
        rt.id = pesan.id;
        return rt;
    }
}