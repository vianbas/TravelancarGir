using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRAVELANCAR.Models
{
    public class kamar_univ
    {
        public int id { get; set; }
        public string kategori { get; set; }
        public int harga_hari_biasa { get; set; }
        public int harga_akhir_pekan { get; set; }
        public int jumlah_tersedia { get; set; }
        public string free_wifi { get; set; }
        public string free_breakfast { get; set; }
        public int jumlah_guest { get; set; }
    }
}