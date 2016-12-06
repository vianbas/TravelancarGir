using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TRAVELANCAR.Models
{
    public class CariTiket
    {
        [Required]
        public string kotaAsal { get; set; }
        [Required]
        public string kotaTujuan { get; set; }
        [Required]
        public DateTime tanggalBerangkat { get; set; }
        [Required]
        public int jumlahPenumpang { get; set; }
    }
}