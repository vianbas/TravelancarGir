/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;

import controller.exceptions.IllegalOrphanException;
import controller.exceptions.NonexistentEntityException;
import entity.Nasabah;
import java.io.Serializable;
import javax.persistence.Query;
import javax.persistence.EntityNotFoundException;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Root;
import entity.Transaksi;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.NoResultException;

/**
 *
 * @author hikennoace
 */
public class NasabahJpaController implements Serializable {

    public NasabahJpaController(EntityManagerFactory emf) {
        this.emf = emf;
        manager = emf.createEntityManager();
    }
    private EntityManagerFactory emf = null;
    private EntityManager manager=null;
    public EntityManager getEntityManager() {
        return emf.createEntityManager();
    }

    public void create(Nasabah nasabah) {
        if (nasabah.getTransaksiCollection() == null) {
            nasabah.setTransaksiCollection(new ArrayList<Transaksi>());
        }
        if (nasabah.getTransaksiCollection1() == null) {
            nasabah.setTransaksiCollection1(new ArrayList<Transaksi>());
        }
        EntityManager em = null;
        try {
            em = getEntityManager();
            em.getTransaction().begin();
            Collection<Transaksi> attachedTransaksiCollection = new ArrayList<Transaksi>();
            for (Transaksi transaksiCollectionTransaksiToAttach : nasabah.getTransaksiCollection()) {
                transaksiCollectionTransaksiToAttach = em.getReference(transaksiCollectionTransaksiToAttach.getClass(), transaksiCollectionTransaksiToAttach.getId());
                attachedTransaksiCollection.add(transaksiCollectionTransaksiToAttach);
            }
            nasabah.setTransaksiCollection(attachedTransaksiCollection);
            Collection<Transaksi> attachedTransaksiCollection1 = new ArrayList<Transaksi>();
            for (Transaksi transaksiCollection1TransaksiToAttach : nasabah.getTransaksiCollection1()) {
                transaksiCollection1TransaksiToAttach = em.getReference(transaksiCollection1TransaksiToAttach.getClass(), transaksiCollection1TransaksiToAttach.getId());
                attachedTransaksiCollection1.add(transaksiCollection1TransaksiToAttach);
            }
            nasabah.setTransaksiCollection1(attachedTransaksiCollection1);
            em.persist(nasabah);
            for (Transaksi transaksiCollectionTransaksi : nasabah.getTransaksiCollection()) {
                Nasabah oldRekeningAsalOfTransaksiCollectionTransaksi = transaksiCollectionTransaksi.getRekeningAsal();
                transaksiCollectionTransaksi.setRekeningAsal(nasabah);
                transaksiCollectionTransaksi = em.merge(transaksiCollectionTransaksi);
                if (oldRekeningAsalOfTransaksiCollectionTransaksi != null) {
                    oldRekeningAsalOfTransaksiCollectionTransaksi.getTransaksiCollection().remove(transaksiCollectionTransaksi);
                    oldRekeningAsalOfTransaksiCollectionTransaksi = em.merge(oldRekeningAsalOfTransaksiCollectionTransaksi);
                }
            }
            for (Transaksi transaksiCollection1Transaksi : nasabah.getTransaksiCollection1()) {
                Nasabah oldRekeningTujuanOfTransaksiCollection1Transaksi = transaksiCollection1Transaksi.getRekeningTujuan();
                transaksiCollection1Transaksi.setRekeningTujuan(nasabah);
                transaksiCollection1Transaksi = em.merge(transaksiCollection1Transaksi);
                if (oldRekeningTujuanOfTransaksiCollection1Transaksi != null) {
                    oldRekeningTujuanOfTransaksiCollection1Transaksi.getTransaksiCollection1().remove(transaksiCollection1Transaksi);
                    oldRekeningTujuanOfTransaksiCollection1Transaksi = em.merge(oldRekeningTujuanOfTransaksiCollection1Transaksi);
                }
            }
            em.getTransaction().commit();
        } finally {
            if (em != null) {
                em.close();
            }
        }
    }

    public void edit(Nasabah nasabah) throws IllegalOrphanException, NonexistentEntityException, Exception {
        EntityManager em = null;
        try {
            em = getEntityManager();
            em.getTransaction().begin();
            Nasabah persistentNasabah = em.find(Nasabah.class, nasabah.getId());
            Collection<Transaksi> transaksiCollectionOld = persistentNasabah.getTransaksiCollection();
            Collection<Transaksi> transaksiCollectionNew = nasabah.getTransaksiCollection();
            Collection<Transaksi> transaksiCollection1Old = persistentNasabah.getTransaksiCollection1();
            Collection<Transaksi> transaksiCollection1New = nasabah.getTransaksiCollection1();
            List<String> illegalOrphanMessages = null;
            for (Transaksi transaksiCollectionOldTransaksi : transaksiCollectionOld) {
                if (!transaksiCollectionNew.contains(transaksiCollectionOldTransaksi)) {
                    if (illegalOrphanMessages == null) {
                        illegalOrphanMessages = new ArrayList<String>();
                    }
                    illegalOrphanMessages.add("You must retain Transaksi " + transaksiCollectionOldTransaksi + " since its rekeningAsal field is not nullable.");
                }
            }
            for (Transaksi transaksiCollection1OldTransaksi : transaksiCollection1Old) {
                if (!transaksiCollection1New.contains(transaksiCollection1OldTransaksi)) {
                    if (illegalOrphanMessages == null) {
                        illegalOrphanMessages = new ArrayList<String>();
                    }
                    illegalOrphanMessages.add("You must retain Transaksi " + transaksiCollection1OldTransaksi + " since its rekeningTujuan field is not nullable.");
                }
            }
            if (illegalOrphanMessages != null) {
                throw new IllegalOrphanException(illegalOrphanMessages);
            }
            Collection<Transaksi> attachedTransaksiCollectionNew = new ArrayList<Transaksi>();
            for (Transaksi transaksiCollectionNewTransaksiToAttach : transaksiCollectionNew) {
                transaksiCollectionNewTransaksiToAttach = em.getReference(transaksiCollectionNewTransaksiToAttach.getClass(), transaksiCollectionNewTransaksiToAttach.getId());
                attachedTransaksiCollectionNew.add(transaksiCollectionNewTransaksiToAttach);
            }
            transaksiCollectionNew = attachedTransaksiCollectionNew;
            nasabah.setTransaksiCollection(transaksiCollectionNew);
            Collection<Transaksi> attachedTransaksiCollection1New = new ArrayList<Transaksi>();
            for (Transaksi transaksiCollection1NewTransaksiToAttach : transaksiCollection1New) {
                transaksiCollection1NewTransaksiToAttach = em.getReference(transaksiCollection1NewTransaksiToAttach.getClass(), transaksiCollection1NewTransaksiToAttach.getId());
                attachedTransaksiCollection1New.add(transaksiCollection1NewTransaksiToAttach);
            }
            transaksiCollection1New = attachedTransaksiCollection1New;
            nasabah.setTransaksiCollection1(transaksiCollection1New);
            nasabah = em.merge(nasabah);
            for (Transaksi transaksiCollectionNewTransaksi : transaksiCollectionNew) {
                if (!transaksiCollectionOld.contains(transaksiCollectionNewTransaksi)) {
                    Nasabah oldRekeningAsalOfTransaksiCollectionNewTransaksi = transaksiCollectionNewTransaksi.getRekeningAsal();
                    transaksiCollectionNewTransaksi.setRekeningAsal(nasabah);
                    transaksiCollectionNewTransaksi = em.merge(transaksiCollectionNewTransaksi);
                    if (oldRekeningAsalOfTransaksiCollectionNewTransaksi != null && !oldRekeningAsalOfTransaksiCollectionNewTransaksi.equals(nasabah)) {
                        oldRekeningAsalOfTransaksiCollectionNewTransaksi.getTransaksiCollection().remove(transaksiCollectionNewTransaksi);
                        oldRekeningAsalOfTransaksiCollectionNewTransaksi = em.merge(oldRekeningAsalOfTransaksiCollectionNewTransaksi);
                    }
                }
            }
            for (Transaksi transaksiCollection1NewTransaksi : transaksiCollection1New) {
                if (!transaksiCollection1Old.contains(transaksiCollection1NewTransaksi)) {
                    Nasabah oldRekeningTujuanOfTransaksiCollection1NewTransaksi = transaksiCollection1NewTransaksi.getRekeningTujuan();
                    transaksiCollection1NewTransaksi.setRekeningTujuan(nasabah);
                    transaksiCollection1NewTransaksi = em.merge(transaksiCollection1NewTransaksi);
                    if (oldRekeningTujuanOfTransaksiCollection1NewTransaksi != null && !oldRekeningTujuanOfTransaksiCollection1NewTransaksi.equals(nasabah)) {
                        oldRekeningTujuanOfTransaksiCollection1NewTransaksi.getTransaksiCollection1().remove(transaksiCollection1NewTransaksi);
                        oldRekeningTujuanOfTransaksiCollection1NewTransaksi = em.merge(oldRekeningTujuanOfTransaksiCollection1NewTransaksi);
                    }
                }
            }
            em.getTransaction().commit();
        } catch (Exception ex) {
            String msg = ex.getLocalizedMessage();
            if (msg == null || msg.length() == 0) {
                Integer id = nasabah.getId();
                if (findNasabah(id) == null) {
                    throw new NonexistentEntityException("The nasabah with id " + id + " no longer exists.");
                }
            }
            throw ex;
        } finally {
            if (em != null) {
                em.close();
            }
        }
    }

    public void destroy(Integer id) throws IllegalOrphanException, NonexistentEntityException {
        EntityManager em = null;
        try {
            em = getEntityManager();
            em.getTransaction().begin();
            Nasabah nasabah;
            try {
                nasabah = em.getReference(Nasabah.class, id);
                nasabah.getId();
            } catch (EntityNotFoundException enfe) {
                throw new NonexistentEntityException("The nasabah with id " + id + " no longer exists.", enfe);
            }
            List<String> illegalOrphanMessages = null;
            Collection<Transaksi> transaksiCollectionOrphanCheck = nasabah.getTransaksiCollection();
            for (Transaksi transaksiCollectionOrphanCheckTransaksi : transaksiCollectionOrphanCheck) {
                if (illegalOrphanMessages == null) {
                    illegalOrphanMessages = new ArrayList<String>();
                }
                illegalOrphanMessages.add("This Nasabah (" + nasabah + ") cannot be destroyed since the Transaksi " + transaksiCollectionOrphanCheckTransaksi + " in its transaksiCollection field has a non-nullable rekeningAsal field.");
            }
            Collection<Transaksi> transaksiCollection1OrphanCheck = nasabah.getTransaksiCollection1();
            for (Transaksi transaksiCollection1OrphanCheckTransaksi : transaksiCollection1OrphanCheck) {
                if (illegalOrphanMessages == null) {
                    illegalOrphanMessages = new ArrayList<String>();
                }
                illegalOrphanMessages.add("This Nasabah (" + nasabah + ") cannot be destroyed since the Transaksi " + transaksiCollection1OrphanCheckTransaksi + " in its transaksiCollection1 field has a non-nullable rekeningTujuan field.");
            }
            if (illegalOrphanMessages != null) {
                throw new IllegalOrphanException(illegalOrphanMessages);
            }
            em.remove(nasabah);
            em.getTransaction().commit();
        } finally {
            if (em != null) {
                em.close();
            }
        }
    }

    public List<Nasabah> findNasabahEntities() {
        return findNasabahEntities(true, -1, -1);
    }

    public List<Nasabah> findNasabahEntities(int maxResults, int firstResult) {
        return findNasabahEntities(false, maxResults, firstResult);
    }

    private List<Nasabah> findNasabahEntities(boolean all, int maxResults, int firstResult) {
        EntityManager em = getEntityManager();
        try {
            CriteriaQuery cq = em.getCriteriaBuilder().createQuery();
            cq.select(cq.from(Nasabah.class));
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

    public Nasabah findNasabah(Integer id) {
        EntityManager em = getEntityManager();
        try {
            return em.find(Nasabah.class, id);
        } finally {
            em.close();
        }
    }

    public int getNasabahCount() {
        EntityManager em = getEntityManager();
        try {
            CriteriaQuery cq = em.getCriteriaBuilder().createQuery();
            Root<Nasabah> rt = cq.from(Nasabah.class);
            cq.select(em.getCriteriaBuilder().count(rt));
            Query q = em.createQuery(cq);
            return ((Long) q.getSingleResult()).intValue();
        } finally {
            em.close();
        }
    }
    
    public Nasabah getnasabah(String nomor , String Pin){
        Nasabah nasabah;
        try{
            //System.out.println("ok");
            nasabah=(Nasabah)manager.createQuery("select t from Nasabah t where t.nomorKartu =:nomor AND t.pin =:pin").setParameter("nomor", nomor).setParameter("pin", Pin).getSingleResult();
        }
        catch(NoResultException e){
            //System.out.println("hhh");
            nasabah = null;
        }
        return nasabah;
    }
    
    public Nasabah ceknasabah(String nomor){
        Nasabah nasabah;
        EntityManager mgr= this.emf.createEntityManager();
        try{
            //System.out.println("ok");
            nasabah=(Nasabah)mgr.createQuery("select t from Nasabah t where t.nomorRekening =:nomor").setParameter("nomor", nomor).getSingleResult();
        }
        catch(NoResultException e){
            //System.out.println("hhh");
            nasabah = null;
        }
        return nasabah;
    }
    
    public int cekNasabah(String nomor_rekening){
        Nasabah nasabah = new Nasabah();
        try
        {
            //System.out.println("ok");
            nasabah=(Nasabah)manager.createQuery("select t from Nasabah t where t.nomorRekening =:nomor").setParameter("nomor", nomor_rekening).getSingleResult();
        }
        catch(Exception e){
            //System.out.println("hhh");
            return 0;
        }
        return nasabah.getId();
    }
}
