/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;

import controller.exceptions.NonexistentEntityException;
import java.io.Serializable;
import javax.persistence.Query;
import javax.persistence.EntityNotFoundException;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Root;
import entity.Nasabah;
import entity.Transaksi;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.NoResultException;

/**
 *
 * @author hikennoace
 */
public class TransaksiJpaController implements Serializable {

    public TransaksiJpaController(EntityManagerFactory emf) {
        this.emf = emf;
        manager = emf.createEntityManager();
    }
    private EntityManagerFactory emf = null;
    private EntityManager manager = null;
    public EntityManager getEntityManager() {
        return emf.createEntityManager();
    }

    public void create(Transaksi transaksi) {
        EntityManager em = null;
        try {
            em = getEntityManager();
            em.getTransaction().begin();
            Nasabah rekeningAsal = transaksi.getRekeningAsal();
            if (rekeningAsal != null) {
                rekeningAsal = em.getReference(rekeningAsal.getClass(), rekeningAsal.getId());
                transaksi.setRekeningAsal(rekeningAsal);
            }
            Nasabah rekeningTujuan = transaksi.getRekeningTujuan();
            if (rekeningTujuan != null) {
                rekeningTujuan = em.getReference(rekeningTujuan.getClass(), rekeningTujuan.getId());
                transaksi.setRekeningTujuan(rekeningTujuan);
            }
            em.persist(transaksi);
            if (rekeningAsal != null) {
                rekeningAsal.getTransaksiCollection().add(transaksi);
                rekeningAsal = em.merge(rekeningAsal);
            }
            if (rekeningTujuan != null) {
                rekeningTujuan.getTransaksiCollection().add(transaksi);
                rekeningTujuan = em.merge(rekeningTujuan);
            }
            em.getTransaction().commit();
        } finally {
            if (em != null) {
                em.close();
            }
        }
    }

    public void edit(Transaksi transaksi) throws NonexistentEntityException, Exception {
        EntityManager em = null;
        try {
            em = getEntityManager();
            em.getTransaction().begin();
            Transaksi persistentTransaksi = em.find(Transaksi.class, transaksi.getId());
            Nasabah rekeningAsalOld = persistentTransaksi.getRekeningAsal();
            Nasabah rekeningAsalNew = transaksi.getRekeningAsal();
            Nasabah rekeningTujuanOld = persistentTransaksi.getRekeningTujuan();
            Nasabah rekeningTujuanNew = transaksi.getRekeningTujuan();
            if (rekeningAsalNew != null) {
                rekeningAsalNew = em.getReference(rekeningAsalNew.getClass(), rekeningAsalNew.getId());
                transaksi.setRekeningAsal(rekeningAsalNew);
            }
            if (rekeningTujuanNew != null) {
                rekeningTujuanNew = em.getReference(rekeningTujuanNew.getClass(), rekeningTujuanNew.getId());
                transaksi.setRekeningTujuan(rekeningTujuanNew);
            }
            transaksi = em.merge(transaksi);
            if (rekeningAsalOld != null && !rekeningAsalOld.equals(rekeningAsalNew)) {
                rekeningAsalOld.getTransaksiCollection().remove(transaksi);
                rekeningAsalOld = em.merge(rekeningAsalOld);
            }
            if (rekeningAsalNew != null && !rekeningAsalNew.equals(rekeningAsalOld)) {
                rekeningAsalNew.getTransaksiCollection().add(transaksi);
                rekeningAsalNew = em.merge(rekeningAsalNew);
            }
            if (rekeningTujuanOld != null && !rekeningTujuanOld.equals(rekeningTujuanNew)) {
                rekeningTujuanOld.getTransaksiCollection().remove(transaksi);
                rekeningTujuanOld = em.merge(rekeningTujuanOld);
            }
            if (rekeningTujuanNew != null && !rekeningTujuanNew.equals(rekeningTujuanOld)) {
                rekeningTujuanNew.getTransaksiCollection().add(transaksi);
                rekeningTujuanNew = em.merge(rekeningTujuanNew);
            }
            em.getTransaction().commit();
        } catch (Exception ex) {
            String msg = ex.getLocalizedMessage();
            if (msg == null || msg.length() == 0) {
                Integer id = transaksi.getId();
                if (findTransaksi(id) == null) {
                    throw new NonexistentEntityException("The transaksi with id " + id + " no longer exists.");
                }
            }
            throw ex;
        } finally {
            if (em != null) {
                em.close();
            }
        }
    }

    public void destroy(Integer id) throws NonexistentEntityException {
        EntityManager em = null;
        try {
            em = getEntityManager();
            em.getTransaction().begin();
            Transaksi transaksi;
            try {
                transaksi = em.getReference(Transaksi.class, id);
                transaksi.getId();
            } catch (EntityNotFoundException enfe) {
                throw new NonexistentEntityException("The transaksi with id " + id + " no longer exists.", enfe);
            }
            Nasabah rekeningAsal = transaksi.getRekeningAsal();
            if (rekeningAsal != null) {
                rekeningAsal.getTransaksiCollection().remove(transaksi);
                rekeningAsal = em.merge(rekeningAsal);
            }
            Nasabah rekeningTujuan = transaksi.getRekeningTujuan();
            if (rekeningTujuan != null) {
                rekeningTujuan.getTransaksiCollection().remove(transaksi);
                rekeningTujuan = em.merge(rekeningTujuan);
            }
            em.remove(transaksi);
            em.getTransaction().commit();
        } finally {
            if (em != null) {
                em.close();
            }
        }
    }

    public List<Transaksi> findTransaksiEntities() {
        return findTransaksiEntities(true, -1, -1);
    }

    public List<Transaksi> findTransaksiEntities(int maxResults, int firstResult) {
        return findTransaksiEntities(false, maxResults, firstResult);
    }

    private List<Transaksi> findTransaksiEntities(boolean all, int maxResults, int firstResult) {
        EntityManager em = getEntityManager();
        try {
            CriteriaQuery cq = em.getCriteriaBuilder().createQuery();
            cq.select(cq.from(Transaksi.class));
            Query q = em.createQuery(cq);
            if (!all) {
                q.setMaxResults(maxResults);
                q.setFirstResult(firstResult);
            }
            return q.getResultList();
        } finally {
            em.close();
        }
    }

    public Transaksi findTransaksi(Integer id) {
        EntityManager em = getEntityManager();
        try {
            return em.find(Transaksi.class, id);
        } finally {
            em.close();
        }
    }

    public int getTransaksiCount() {
        EntityManager em = getEntityManager();
        try {
            CriteriaQuery cq = em.getCriteriaBuilder().createQuery();
            Root<Transaksi> rt = cq.from(Transaksi.class);
            cq.select(em.getCriteriaBuilder().count(rt));
            Query q = em.createQuery(cq);
            return ((Long) q.getSingleResult()).intValue();
        } finally {
            em.close();
        }
    }
    
     public Transaksi gettransaksi(String kode_transaksi){
        Transaksi transaksi;
         //System.out.println("000k");
        try{
            transaksi=(Transaksi)manager.createQuery("select t from Transaksi t where t.kodeTransaksi=:kode AND t.jenisRansaksi =:jenis").setParameter("kode", kode_transaksi).setParameter("jenis", "masuk").getSingleResult();
        }
        catch(NoResultException e){
           // System.out.println("sssss");
            transaksi = null;
        }
        return transaksi;
    }
    
}
