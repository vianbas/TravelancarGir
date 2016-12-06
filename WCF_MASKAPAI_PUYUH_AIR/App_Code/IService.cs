using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
    [OperationContract]
    List<penerbangan> getPenerbangan(string kota_asal, string kota_tujuan, System.DateTime tanggal_keberangkatan);

    [OperationContract]
    int bayar(int id_tiket);

    [OperationContract]
    int booking(int id_penerbangan, List<penumpang> penumpangs, int user_id);

    [OperationContract]
    CompositeType getTiket(int id_tiket);

    [OperationContract]
    List<tiket> getPemesanan(int user_id);
    // TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{
    [DataMember]
    public penerbangan penerbangan_sah;

    [DataMember]
    public tiket tiket_sah;

    [DataMember]
    public List<penumpang> daftarPenumpang;

}




