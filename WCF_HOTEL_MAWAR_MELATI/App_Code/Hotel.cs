﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class kamar
{
    public kamar()
    {
        this.pemesanan = new HashSet<pemesanan>();
    }

    public int id { get; set; }
    public string kategori { get; set; }
    public int harga_hari_biasa { get; set; }
    public int harga_akhir_pekan { get; set; }
    public int jumlah_tersedia { get; set; }
    public int free_wifi { get; set; }
    public int free_breakfast { get; set; }
    public int jumlah_guest { get; set; }

    public virtual ICollection<pemesanan> pemesanan { get; set; }
}

public partial class pemesanan
{
    public int id { get; set; }
    public Nullable<int> id_kamar { get; set; }
    public System.DateTime tanggal_booking { get; set; }
    public System.DateTime tanggal_check_in { get; set; }
    public System.DateTime tanggal_check_out { get; set; }
    public string nama_pemesan { get; set; }
    public int total_harga { get; set; }
    public string kode_booking { get; set; }

    public virtual kamar kamar { get; set; }
}

public partial class sysdiagrams
{
    public string name { get; set; }
    public int principal_id { get; set; }
    public int diagram_id { get; set; }
    public Nullable<int> version { get; set; }
    public byte[] definition { get; set; }
}
