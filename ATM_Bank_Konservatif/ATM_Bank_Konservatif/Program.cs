using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_Bank_Konservatif.ServiceBankKonservatif;


namespace ATM_Bank_Konservatif
{
    class Program
    {
        static void Main(string[] args)
        {
            int id_pengguna, pilihan;
            string nomor_kartu;
            string pin;
            KonservatifServiceClient klien = new KonservatifServiceClient();
            Console.WriteLine("Selamat Datang di ATM Bank Konservatif!!");
            Console.Write("Silahkan Entri Nomor Kartu Anda : ");
            nomor_kartu = Console.ReadLine();
            Console.Write("Silahkan Entri PIN Anda : ");
            pin = Console.ReadLine();
            id_pengguna =  klien.login(nomor_kartu, pin);
            Console.WriteLine(id_pengguna);
            while ( id_pengguna == 0) {
                Console.WriteLine("Nomor Kartu dan Pin Salah");
                Console.Write("Silahkan Entri Nomor Kartu Anda : ");
                nomor_kartu = Console.ReadLine();
                Console.Write("Silahkan Entri PIN Anda : ");
                pin = Console.ReadLine();
            }
            Console.WriteLine("Silahkan Memilih Menu yang tersedia:");
            Console.WriteLine("1 ==> Bayar Tiket Pesawat");
            Console.WriteLine("2 ==> Cek Saldo");
            Console.WriteLine("3 ==> Exit");
            Console.Write("Entri Pilihan :");
            pilihan = Convert.ToInt32(Console.ReadLine());
            while (pilihan != 3) 
            {
                if (pilihan == 2) 
                {
                    Console.WriteLine("Sisa saldo = " + klien.cekSaldo(id_pengguna));
                    Console.Write("Entri Pilihan :");
                    pilihan = Convert.ToInt32(Console.ReadLine());
                }
                else if (pilihan == 1) 
                {
                    int jumlah;
                    string kode_transaksi;
                    Console.Write("Entri jumlah  :");
                    jumlah =  Convert.ToInt32(Console.ReadLine());
                    Console.Write("Entri Kode Transaksi :");
                    kode_transaksi = Console.ReadLine();

                    if (klien.transfer(jumlah, id_pengguna, kode_transaksi) == 1)
                    {
                        Console.WriteLine("Transaksi Berhasil!!");
                        Console.WriteLine("Sisa Saldo = " + klien.cekSaldo(id_pengguna));
                        Console.WriteLine("Status Transaksi = "+klien.cekTransaksiMasuk(kode_transaksi, "sss"));
                    }
                    else 
                    {
                        Console.WriteLine("Transaksi Pembayaran Gagal!!");

                    }
                    Console.Write("Entri Pilihan :");
                    pilihan = Convert.ToInt32(Console.ReadLine());
                }
                
            }
            Console.ReadKey();

        }
    }
}
