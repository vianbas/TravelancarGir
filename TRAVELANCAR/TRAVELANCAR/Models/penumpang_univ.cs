using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TRAVELANCAR.Models
{
    public class penumpang_univ
    {
        public int idPenerbangan { get; set; }
        public string namaMaskapai{ get; set; }
        [Required]
        public string nama { get; set; }
        [Required]
        public string nomor_identitas { get; set; }
    }
}