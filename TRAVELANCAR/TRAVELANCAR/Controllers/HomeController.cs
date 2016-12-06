using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using TRAVELANCAR.Filters;
using TRAVELANCAR.Models;

namespace TRAVELANCAR.Controllers
{
     [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        //service
        private TRAVELANCAR.maskapai_itik_air_service.ServiceClient itik = new maskapai_itik_air_service.ServiceClient();
        private TRAVELANCAR.maskapai_pinguin_air_service.ServiceClient pinguin = new maskapai_pinguin_air_service.ServiceClient();
        private TRAVELANCAR.maskapai_puyuh_air_service.ServiceClient puyuh = new maskapai_puyuh_air_service.ServiceClient();
        private TRAVELANCAR.hotel_kasur_empuk_service.ServiceClient kasur_empuk = new hotel_kasur_empuk_service.ServiceClient();
        private TRAVELANCAR.hotel_mawar_melati_service.ServiceClient mawar_melati = new hotel_mawar_melati_service.ServiceClient();
        private TRAVELANCAR.bank_bung_service.frontendcontrollersApiControllerPortClient bank_bung = new bank_bung_service.frontendcontrollersApiControllerPortClient();
        private TRAVELANCAR.bank_konservatif_service.KonservatifServiceClient bank_konservatif = new bank_konservatif_service.KonservatifServiceClient();
        private static string namaMaskapai_univ = "";
        private static int idPenerbangan_univ = 0;
        private static int userId = new int();


        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated) 
            {
                string nama = User.Identity.Name;
                int id = WebSecurity.GetUserId(nama);
                userId = id;
            }
            ViewBag.Message = "Selamat Datang Di Travelancar.";
            CariTiket cari = new CariTiket();
            cari.tanggalBerangkat = DateTime.Now;
            cari.jumlahPenumpang = 1;
          
            return View(cari);
        }

        [HttpPost]
        public ActionResult Index(CariTiket cari)
        {
            ViewBag.Message = cari.jumlahPenumpang;
            List<TRAVELANCAR.maskapai_pinguin_air_service.penerbangan> daftarPinguin = pinguin.getPenerbangan(cari.kotaAsal, cari.kotaTujuan, cari.tanggalBerangkat).ToList();
            List<TRAVELANCAR.maskapai_puyuh_air_service.penerbangan> daftarPuyuh = puyuh.getPenerbangan(cari.kotaAsal, cari.kotaTujuan, cari.tanggalBerangkat).ToList();
            List<TRAVELANCAR.maskapai_itik_air_service.penerbangan> daftarItik = itik.getPenerbangan(cari.kotaAsal, cari.kotaTujuan, cari.tanggalBerangkat).ToList();
            List<penerbangan_univ> daftarPenerbangan = new List<penerbangan_univ>();

            foreach (var a in daftarItik)
            {
                penerbangan_univ p = new penerbangan_univ();
                p.bagasi_maksimum = a.bagasi_maksimum;
                p.bandara_asal = a.bandara_asal;
                p.bandara_transit = a.bandara_transit;
                p.bandara_tujuan = a.bandara_tujuan;
                p.durasi = a.durasi;
                p.harga = a.harga;
                p.id = a.id;
                p.jam_keberangkatan = a.jam_keberangkatan;
                p.jam_tiba = a.jam_tiba;
                p.kota_asal = a.kota_asal;
                p.kota_transit = a.kota_transit;
                p.kota_tujuan = a.kota_tujuan;
                p.nama_maskapai = a.nama_maskapai;
                p.tanggal_keberangkatan = a.tanggal_keberangkatan;
                daftarPenerbangan.Add(p);

            }

            foreach (var a in daftarPinguin)
            {
                penerbangan_univ p = new penerbangan_univ();
                p.bagasi_maksimum = a.bagasi_maksimum;
                p.bandara_asal = a.bandara_asal;
                p.bandara_transit = a.bandara_transit;
                p.bandara_tujuan = a.bandara_tujuan;
                p.durasi = a.durasi;
                p.harga = a.harga;
                p.id = a.id;
                p.jam_keberangkatan = a.jam_keberangkatan;
                p.jam_tiba = a.jam_tiba;
                p.kota_asal = a.kota_asal;
                p.kota_transit = a.kota_transit;
                p.kota_tujuan = a.kota_tujuan;
                p.nama_maskapai = a.nama_maskapai;
                p.tanggal_keberangkatan = a.tanggal_keberangkatan;
                daftarPenerbangan.Add(p);

            }
            foreach (var a in daftarPuyuh)
            {
                penerbangan_univ p = new penerbangan_univ();
                p.bagasi_maksimum = a.bagasi_maksimum;
                p.bandara_asal = a.bandara_asal;
                p.bandara_transit = a.bandara_transit;
                p.bandara_tujuan = a.bandara_tujuan;
                p.durasi = a.durasi;
                p.harga = a.harga;
                p.id = a.id;
                p.jam_keberangkatan = a.jam_keberangkatan;
                p.jam_tiba = a.jam_tiba;
                p.kota_asal = a.kota_asal;
                p.kota_transit = a.kota_transit;
                p.kota_tujuan = a.kota_tujuan;
                p.nama_maskapai = a.nama_maskapai;
                p.tanggal_keberangkatan = a.tanggal_keberangkatan;
                daftarPenerbangan.Add(p);

            }
            List<penerbangan_univ> recommended = daftarPenerbangan.OrderBy(p => p.jam_keberangkatan).ThenBy(p => p.harga).ToList();
            return View("daftarpenerbangan", recommended);
        }


        public ActionResult Hotel()
        {
            List<TRAVELANCAR.hotel_kasur_empuk_service.kamar> kamarKasurEmpuk = kasur_empuk.getKamar().ToList();
            List<TRAVELANCAR.hotel_mawar_melati_service.kamar> kamarMawarMelati = mawar_melati.getKamar().ToList();
            List<kamar_univ> daftarKasurEmpuk = new List<kamar_univ>();
            foreach (var k in kamarKasurEmpuk)
            {
                kamar_univ kamar = new kamar_univ();
                if (k.free_breakfast == 1)
                {
                    kamar.free_breakfast = "YA";
                }
                else
                {
                    kamar.free_breakfast = "Tidak";
                }
                if (k.free_wifi == 1)
                {
                    kamar.free_wifi = "YA";
                }
                else
                {
                    kamar.free_wifi = "Tidak";
                }
                kamar.harga_akhir_pekan = k.harga_akhir_pekan;
                kamar.harga_hari_biasa = k.harga_hari_biasa;
                kamar.id = k.id;
                kamar.jumlah_guest = k.jumlah_guest;
                kamar.jumlah_tersedia = k.jumlah_tersedia;
                kamar.kategori = k.kategori;
                daftarKasurEmpuk.Add(kamar);

            }

            List<kamar_univ> daftarMawarMelati = new List<kamar_univ>();
            foreach (var k in kamarMawarMelati)
            {
                kamar_univ kamar = new kamar_univ();
                if (k.free_breakfast == 1)
                {
                    kamar.free_breakfast = "YA";
                }
                else
                {
                    kamar.free_breakfast = "Tidak";
                }
                if (k.free_wifi == 1)
                {
                    kamar.free_wifi = "YA";
                }
                else
                {
                    kamar.free_wifi = "Tidak";
                }
                kamar.harga_akhir_pekan = k.harga_akhir_pekan;
                kamar.harga_hari_biasa = k.harga_hari_biasa;
                kamar.id = k.id;
                kamar.jumlah_guest = k.jumlah_guest;
                kamar.jumlah_tersedia = k.jumlah_tersedia;
                kamar.kategori = k.kategori;
                daftarMawarMelati.Add(kamar);

            }
            perbandinganhotel banding = new perbandinganhotel();
            banding.daftarKamarHotelKasurEmpuk = daftarKasurEmpuk;
            banding.daftarKamarHotelMawarMelati = daftarMawarMelati;

            return View(banding);
        }

        public ActionResult DaftarHotel()
        {
            List<TRAVELANCAR.hotel_kasur_empuk_service.pemesanan> pesanKasurEmpuk = kasur_empuk.getPemesanan(User.Identity.Name).ToList();
            List<TRAVELANCAR.hotel_mawar_melati_service.pemesanan> pesanMawarMelati = mawar_melati.getPemesanan(User.Identity.Name).ToList();
            List<pemesanan_univ> daftarPesan = new List<pemesanan_univ>();
            foreach (var p in pesanKasurEmpuk)
            {
                pemesanan_univ pesan = new pemesanan_univ();
                pesan.id = p.id;
                pesan.id_kamar = p.id_kamar;
                pesan.kode_booking = p.kode_booking;
                pesan.tanggal_booking = p.tanggal_booking;
                pesan.tanggal_check_in = p.tanggal_check_in;
                pesan.tanggal_check_out = p.tanggal_check_out;
                pesan.total_harga = p.total_harga;
                pesan.nama_hotel = "Kasur Empuk";
                daftarPesan.Add(pesan);
            }
            foreach (var p in pesanMawarMelati)
            {
                pemesanan_univ pesan = new pemesanan_univ();
                pesan.id = p.id;
                pesan.id_kamar = p.id_kamar;
                pesan.kode_booking = p.kode_booking;
                pesan.tanggal_booking = p.tanggal_booking;
                pesan.tanggal_check_in = p.tanggal_check_in;
                pesan.tanggal_check_out = p.tanggal_check_out;
                pesan.total_harga = p.total_harga;
                pesan.nama_hotel = "Mawar Melati";
                daftarPesan.Add(pesan);
            }
            daftarPesan = daftarPesan.OrderByDescending(p => p.tanggal_booking).ToList();
            return View("daftarpesanhotel", daftarPesan);
        }

        public ActionResult BookingKamar(int id, string hotel)
        {
            ViewBag.Id = id;
            ViewBag.Hotel = hotel;
            BookingKamar book = new BookingKamar();
            book.tanggalCheckIn = DateTime.Now;
            book.tanggalCheckOut = DateTime.Now.AddDays(1);
            book.idKamar = id;
            book.namaHotel = hotel;
            return View(book);
        }

        [HttpPost]
        public ActionResult BookingKamar(BookingKamar book)
        {
            string user = User.Identity.Name;
            if (book.namaHotel == "hotel_kasur_empuk")
            {
                TRAVELANCAR.hotel_kasur_empuk_service.CompositeType respon = kasur_empuk.booking(book.tanggalCheckIn, book.tanggalCheckOut, user, book.idKamar);
                ViewBag.Kode = respon.kodeBooking;
            }
            else
            {
                TRAVELANCAR.hotel_mawar_melati_service.CompositeType respon = mawar_melati.booking(book.tanggalCheckIn, book.tanggalCheckOut, user, book.idKamar);
                ViewBag.Kode = respon.kodeBooking;
            }
            return View("pesanbookingkamar", new BookingKamar());
        }


        public ActionResult DaftarTiket()
        {
            //Response.Write(bank_konservatif.cekTransaksiMasuk("dctsh5i2ezv", 500000));
            //Response.End();
            List<TRAVELANCAR.maskapai_itik_air_service.tiket> daftarItik = itik.getPemesanan(userId).ToList();
            List<TRAVELANCAR.maskapai_puyuh_air_service.tiket> daftarPuyuh = puyuh.getPemesanan(userId).ToList();
            List<TRAVELANCAR.maskapai_pinguin_air_service.tiket> daftarPinguin = pinguin.getPemesanan(userId).ToList();

            List<tiket_univ> daftarTiket = new List<tiket_univ>();
            foreach (var t in daftarItik)
            {
                tiket_univ tkt = new tiket_univ();
                tkt.batas_waktu_bayar_atm = t.batas_waktu_bayar_atm;
                tkt.batas_waktu_bayar_internet_banking = t.batas_waktu_bayar_internet_banking;
                tkt.id = t.id;
                tkt.id_penerbangan = t.id_penerbangan;
                tkt.kode_bayar = t.kode_bayar;
                tkt.kode_booking = t.kode_booking;
                tkt.total_harga = t.total_harga;
                if (t.status == "Belum Bayar")
                {
                    //Response.Write(bank_bung.getIndex(tkt.kode_bayar, tkt.total_harga));
                    if (bank_bung.getIndex(tkt.kode_bayar, tkt.total_harga) == "1" || bank_konservatif.cekTransaksiMasuk(tkt.kode_bayar,(int)tkt.total_harga)==1)
                    {
                        int res = itik.bayar(tkt.id);
                        tkt.status = "Lunas";
                    }
                    else
                    {
                        tkt.status = t.status;
                    }
                }
                else
                {
                    tkt.status = t.status;
                }
                tkt.waktu_booking = t.waktu_booking;
                tkt.namaMaskapai = "itik_air";
                daftarTiket.Add(tkt);
                //Response.Write(tkt.kode_bayar +"   "+tkt.status +"  "+ tkt.total_harga +"\n");
            }
            foreach (var t in daftarPinguin)
            {
                tiket_univ tkt = new tiket_univ();
                tkt.batas_waktu_bayar_atm = t.batas_waktu_bayar_atm;
                tkt.batas_waktu_bayar_internet_banking = t.batas_waktu_bayar_internet_banking;
                tkt.id = t.id;
                tkt.id_penerbangan = t.id_penerbangan;
                tkt.kode_bayar = t.kode_bayar;
                tkt.kode_booking = t.kode_booking;
                tkt.total_harga = t.total_harga;
                if (t.status=="Belum Bayar")
                {
                    //Response.Write(bank_bung.getIndex(tkt.kode_bayar, tkt.total_harga));
                    if (bank_bung.getIndex(tkt.kode_bayar, tkt.total_harga) == "1" || bank_konservatif.cekTransaksiMasuk(tkt.kode_bayar, (int)tkt.total_harga) == 1)
                    {
                        int res = pinguin.bayar(tkt.id);
                        tkt.status = "Lunas";
                    }
                    else
                    {
                        tkt.status = t.status;
                    }
                }
                else
                {
                    tkt.status = t.status;
                }
                tkt.waktu_booking = t.waktu_booking;
                tkt.namaMaskapai = "pinguin_air";
                daftarTiket.Add(tkt);
                //Response.Write(tkt.kode_bayar + "   " + tkt.status + "  " + tkt.total_harga + "\n");
            }
            foreach (var t in daftarPuyuh)
            {
                tiket_univ tkt = new tiket_univ();
                tkt.batas_waktu_bayar_atm = t.batas_waktu_bayar_atm;
                tkt.batas_waktu_bayar_internet_banking = t.batas_waktu_bayar_internet_banking;
                tkt.id = t.id;
                tkt.id_penerbangan = t.id_penerbangan;
                tkt.kode_bayar = t.kode_bayar;
                tkt.kode_booking = t.kode_booking;
                tkt.total_harga = t.total_harga;
                if (t.status == "Belum Bayar")
                {
                    //Response.Write(bank_bung.getIndex(tkt.kode_bayar, tkt.total_harga));
                    if (bank_bung.getIndex(tkt.kode_bayar, tkt.total_harga) == "1" || bank_konservatif.cekTransaksiMasuk(tkt.kode_bayar, (int)tkt.total_harga) == 1)
                    {
                        int res = puyuh.bayar(tkt.id);
                        tkt.status = "Lunas";
                    }
                    else
                    {
                        tkt.status = t.status;
                    }
                }
                else 
                {
                    tkt.status = t.status;
                }
                tkt.waktu_booking = t.waktu_booking;
                tkt.namaMaskapai = "puyuh_air";
                daftarTiket.Add(tkt);
                //Response.Write(t.kode_bayar + "   " + tkt.status + "  " + tkt.total_harga + "\n");
            }
            //Response.End();
            daftarTiket = daftarTiket.OrderByDescending(t => t.waktu_booking).ToList();
            return View(daftarTiket);
        }

        public ActionResult TampilkanTiket(int id, string maskapai)
        {

            if (maskapai == "itik_air")
            {
                TRAVELANCAR.maskapai_itik_air_service.CompositeType ct = itik.getTiket(id);
                return View("tiketitikair", ct);
            }
            else if (maskapai == "pinguin_air")
            {
                TRAVELANCAR.maskapai_pinguin_air_service.CompositeType ct = pinguin.getTiket(id);
                return View("tiketpinguinair", ct);
            }
            else
            {
                TRAVELANCAR.maskapai_puyuh_air_service.CompositeType ct = puyuh.getTiket(id);
                return View("tiketpuyuhair", ct);
            }
        }

        public ActionResult PesanTiket(int idPenerbangan, string maskapai, int jumlahPenumpang)
        {
            List<penumpang_univ> penumpangs = new List<penumpang_univ>();
            namaMaskapai_univ = maskapai;
            idPenerbangan_univ = idPenerbangan;
            for (int i = 0; i < jumlahPenumpang; i++)
            {
                penumpang_univ p = new penumpang_univ();
                p.idPenerbangan = idPenerbangan;
                p.namaMaskapai = maskapai;
                p.nomor_identitas = "-";
                p.nama = "-";
                penumpangs.Add(p);
            }
            return View(penumpangs);
        }

        [HttpPost]
        public ActionResult PesanTiket(IList<penumpang_univ> daftarPenumpang)
        {
            int res = 0;
            daftarPenumpang = daftarPenumpang ?? new List<penumpang_univ>();
            if (namaMaskapai_univ == "itik_air")
            {
                TRAVELANCAR.maskapai_itik_air_service.penumpang pen;
                List<TRAVELANCAR.maskapai_itik_air_service.penumpang> penumpangs = new List<maskapai_itik_air_service.penumpang>();
                foreach (var p in daftarPenumpang)
                {
                    pen = new maskapai_itik_air_service.penumpang();
                    pen.nama = p.nama;
                    pen.nomor_identitas = p.nomor_identitas;
                    penumpangs.Add(pen);
                }
                res = itik.booking(idPenerbangan_univ, penumpangs.ToArray(), userId);
            }
            else if (namaMaskapai_univ == "puyuh_air")
            {
                TRAVELANCAR.maskapai_puyuh_air_service.penumpang pen;
                List<TRAVELANCAR.maskapai_puyuh_air_service.penumpang> penumpangs = new List<maskapai_puyuh_air_service.penumpang>();
                foreach (var p in daftarPenumpang)
                {
                    pen = new maskapai_puyuh_air_service.penumpang();
                    pen.nama = p.nama;
                    pen.nomor_identitas = p.nomor_identitas;
                    penumpangs.Add(pen);
                }
                res = puyuh.booking(idPenerbangan_univ, penumpangs.ToArray(), userId);
            }
            else
            {
                TRAVELANCAR.maskapai_pinguin_air_service.penumpang pen;
                List<TRAVELANCAR.maskapai_pinguin_air_service.penumpang> penumpangs = new List<maskapai_pinguin_air_service.penumpang>();
                foreach (var p in daftarPenumpang)
                {
                    pen = new maskapai_pinguin_air_service.penumpang();
                    pen.nama = p.nama;
                    pen.nomor_identitas = p.nomor_identitas;
                    penumpangs.Add(pen);
                }
                res = pinguin.booking(idPenerbangan_univ, penumpangs.ToArray(), userId);
            }
            return View("pesanbookingtiket");
        }

        public ActionResult BayarAtm(string kodeBayar, int jumlah, DateTime batas) 
        {
            ViewBag.kode = kodeBayar;
            ViewBag.jumlah = jumlah;
            ViewBag.batas = batas;
            return View();
        }
    }
}
