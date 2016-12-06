/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package entity;

import java.io.Serializable;
import java.util.Collection;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author hikennoace
 */
@Entity
@Table(name = "nasabah")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Nasabah.findAll", query = "SELECT n FROM Nasabah n"),
    @NamedQuery(name = "Nasabah.findById", query = "SELECT n FROM Nasabah n WHERE n.id = :id"),
    @NamedQuery(name = "Nasabah.findByNomorKartu", query = "SELECT n FROM Nasabah n WHERE n.nomorKartu = :nomorKartu"),
    @NamedQuery(name = "Nasabah.findByPin", query = "SELECT n FROM Nasabah n WHERE n.pin = :pin"),
    @NamedQuery(name = "Nasabah.findByNomorRekening", query = "SELECT n FROM Nasabah n WHERE n.nomorRekening = :nomorRekening"),
    @NamedQuery(name = "Nasabah.findBySaldo", query = "SELECT n FROM Nasabah n WHERE n.saldo = :saldo")})
public class Nasabah implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "id")
    private Integer id;
    @Size(max = 100)
    @Column(name = "nomor_kartu")
    private String nomorKartu;
    @Size(max = 100)
    @Column(name = "pin")
    private String pin;
    @Size(max = 100)
    @Column(name = "nomor_rekening")
    private String nomorRekening;
    @Column(name = "saldo")
    private Integer saldo;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "rekeningAsal")
    private Collection<Transaksi> transaksiCollection;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "rekeningTujuan")
    private Collection<Transaksi> transaksiCollection1;

    public Nasabah() {
    }

    public Nasabah(Integer id) {
        this.id = id;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getNomorKartu() {
        return nomorKartu;
    }

    public void setNomorKartu(String nomorKartu) {
        this.nomorKartu = nomorKartu;
    }

    public String getPin() {
        return pin;
    }

    public void setPin(String pin) {
        this.pin = pin;
    }

    public String getNomorRekening() {
        return nomorRekening;
    }

    public void setNomorRekening(String nomorRekening) {
        this.nomorRekening = nomorRekening;
    }

    public Integer getSaldo() {
        return saldo;
    }

    public void setSaldo(Integer saldo) {
        this.saldo = saldo;
    }

    @XmlTransient
    public Collection<Transaksi> getTransaksiCollection() {
        return transaksiCollection;
    }

    public void setTransaksiCollection(Collection<Transaksi> transaksiCollection) {
        this.transaksiCollection = transaksiCollection;
    }

    @XmlTransient
    public Collection<Transaksi> getTransaksiCollection1() {
        return transaksiCollection1;
    }

    public void setTransaksiCollection1(Collection<Transaksi> transaksiCollection1) {
        this.transaksiCollection1 = transaksiCollection1;
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
        if (!(object instanceof Nasabah)) {
            return false;
        }
        Nasabah other = (Nasabah) object;
        if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "entity.Nasabah[ id=" + id + " ]";
    }
    
}
