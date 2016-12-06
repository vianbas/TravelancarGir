/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package entity;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author hikennoace
 */
@Entity
@Table(name = "transaksi")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Transaksi.findAll", query = "SELECT t FROM Transaksi t"),
    @NamedQuery(name = "Transaksi.findById", query = "SELECT t FROM Transaksi t WHERE t.id = :id"),
    @NamedQuery(name = "Transaksi.findByJenisRansaksi", query = "SELECT t FROM Transaksi t WHERE t.jenisRansaksi = :jenisRansaksi"),
    @NamedQuery(name = "Transaksi.findByKodeTransaksi", query = "SELECT t FROM Transaksi t WHERE t.kodeTransaksi = :kodeTransaksi"),
    @NamedQuery(name = "Transaksi.findByJumlah", query = "SELECT t FROM Transaksi t WHERE t.jumlah = :jumlah"),
    @NamedQuery(name = "Transaksi.findByWaktuTransaksi", query = "SELECT t FROM Transaksi t WHERE t.waktuTransaksi = :waktuTransaksi")})
public class Transaksi implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "id")
    private Integer id;
    @Size(max = 6)
    @Column(name = "jenis_ransaksi")
    private String jenisRansaksi;
    @Size(max = 250)
    @Column(name = "kode_transaksi")
    private String kodeTransaksi;
    @Column(name = "jumlah")
    private Integer jumlah;
    @Column(name = "waktu_transaksi")
    @Temporal(TemporalType.TIMESTAMP)
    private Date waktuTransaksi;
    @JoinColumn(name = "rekening_asal", referencedColumnName = "id")
    @ManyToOne(optional = false)
    private Nasabah rekeningAsal;
    @JoinColumn(name = "rekening_tujuan", referencedColumnName = "id")
    @ManyToOne(optional = false)
    private Nasabah rekeningTujuan;

    public Transaksi() {
    }

    public Transaksi(Integer id) {
        this.id = id;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getJenisRansaksi() {
        return jenisRansaksi;
    }

    public void setJenisRansaksi(String jenisRansaksi) {
        this.jenisRansaksi = jenisRansaksi;
    }

    public String getKodeTransaksi() {
        return kodeTransaksi;
    }

    public void setKodeTransaksi(String kodeTransaksi) {
        this.kodeTransaksi = kodeTransaksi;
    }

    public Integer getJumlah() {
        return jumlah;
    }

    public void setJumlah(Integer jumlah) {
        this.jumlah = jumlah;
    }

    public Date getWaktuTransaksi() {
        return waktuTransaksi;
    }

    public void setWaktuTransaksi(Date waktuTransaksi) {
        this.waktuTransaksi = waktuTransaksi;
    }

    public Nasabah getRekeningAsal() {
        return rekeningAsal;
    }

    public void setRekeningAsal(Nasabah rekeningAsal) {
        this.rekeningAsal = rekeningAsal;
    }

    public Nasabah getRekeningTujuan() {
        return rekeningTujuan;
    }

    public void setRekeningTujuan(Nasabah rekeningTujuan) {
        this.rekeningTujuan = rekeningTujuan;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (id != null ? id.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Transaksi)) {
            return false;
        }
        Transaksi other = (Transaksi) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "entity.Transaksi[ id=" + id + " ]";
    }
    
}
