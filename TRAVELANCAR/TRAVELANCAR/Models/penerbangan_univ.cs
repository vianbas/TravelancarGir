using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRAVELANCAR.Models
{
    public class penerbangan_univ
    {
        public int id { get; set; }
        public string nama_maskapai { get; set; }
        public string kota_asal { get; set; }
        public string kota_tujuan { get; set; }
        public string bandara_asal { get; set; }
        public string bandara_tujuan { get; set; }
        public string kota_transit { get; set; }
        public string bandara_transit { get; set; }
        public System.DateTime tanggal_keberangkatan { get; set; }
        public string jam_keberangkatan { get; set; }
        public string jam_tiba { get; set; }
        public string durasi { get; set; }
        public int bagasi_maksimum { get; set; }
        public int harga { get; set; }

    }
}