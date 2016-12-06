using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRAVELANCAR.Models
{
    public class pemesanan_univ
    {
        public int id { get; set; }
        public Nullable<int> id_kamar { get; set; }
        public System.DateTime tanggal_booking { get; set; }
        public System.DateTime tanggal_check_in { get; set; }
        public System.DateTime tanggal_check_out { get; set; }
        public string nama_pemesan { get; set; }
        public string nama_hotel { get; set; }
        public int total_harga { get; set; }
        public string kode_booking { get; set; }
    }
}