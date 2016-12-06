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
    List<kamar> getKamar();

    [OperationContract]
    List<pemesanan> getPemesanan(string nama);

    [OperationContract]
    CompositeType booking(System.DateTime tanggal_check_in, System.DateTime tanggal_check_out, string nama, int idKamar);

    // TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{

    [DataMember]
    public int id;

    [DataMember]
    public string kodeBooking;
}