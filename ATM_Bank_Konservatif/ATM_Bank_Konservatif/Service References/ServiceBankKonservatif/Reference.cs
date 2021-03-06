﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ATM_Bank_Konservatif.ServiceBankKonservatif {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://service/")]
    public partial class NonexistentEntityException : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://service/")]
    public partial class Exception : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://service/", ConfigurationName="ServiceBankKonservatif.KonservatifService")]
    public interface KonservatifService {
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://service/KonservatifService/transferRequest", ReplyAction="http://service/KonservatifService/transferResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(ATM_Bank_Konservatif.ServiceBankKonservatif.NonexistentEntityException), Action="http://service/KonservatifService/transfer/Fault/NonexistentEntityException", Name="NonexistentEntityException")]
        [System.ServiceModel.FaultContractAttribute(typeof(ATM_Bank_Konservatif.ServiceBankKonservatif.Exception), Action="http://service/KonservatifService/transfer/Fault/Exception", Name="Exception")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        ATM_Bank_Konservatif.ServiceBankKonservatif.transferResponse transfer(ATM_Bank_Konservatif.ServiceBankKonservatif.transferRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://service/KonservatifService/transferRequest", ReplyAction="http://service/KonservatifService/transferResponse")]
        System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.transferResponse> transferAsync(ATM_Bank_Konservatif.ServiceBankKonservatif.transferRequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://service/KonservatifService/cekTransaksiMasukRequest", ReplyAction="http://service/KonservatifService/cekTransaksiMasukResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukResponse cekTransaksiMasuk(ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://service/KonservatifService/cekTransaksiMasukRequest", ReplyAction="http://service/KonservatifService/cekTransaksiMasukResponse")]
        System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukResponse> cekTransaksiMasukAsync(ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukRequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://service/KonservatifService/loginRequest", ReplyAction="http://service/KonservatifService/loginResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        ATM_Bank_Konservatif.ServiceBankKonservatif.loginResponse login(ATM_Bank_Konservatif.ServiceBankKonservatif.loginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://service/KonservatifService/loginRequest", ReplyAction="http://service/KonservatifService/loginResponse")]
        System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.loginResponse> loginAsync(ATM_Bank_Konservatif.ServiceBankKonservatif.loginRequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://service/KonservatifService/helloRequest", ReplyAction="http://service/KonservatifService/helloResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        ATM_Bank_Konservatif.ServiceBankKonservatif.helloResponse hello(ATM_Bank_Konservatif.ServiceBankKonservatif.helloRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://service/KonservatifService/helloRequest", ReplyAction="http://service/KonservatifService/helloResponse")]
        System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.helloResponse> helloAsync(ATM_Bank_Konservatif.ServiceBankKonservatif.helloRequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://service/KonservatifService/cekSaldoRequest", ReplyAction="http://service/KonservatifService/cekSaldoResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoResponse cekSaldo(ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://service/KonservatifService/cekSaldoRequest", ReplyAction="http://service/KonservatifService/cekSaldoResponse")]
        System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoResponse> cekSaldoAsync(ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="transfer", WrapperNamespace="http://service/", IsWrapped=true)]
    public partial class transferRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int jumlah;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int id_pengirim;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string kode_transaksi;
        
        public transferRequest() {
        }
        
        public transferRequest(int jumlah, int id_pengirim, string kode_transaksi) {
            this.jumlah = jumlah;
            this.id_pengirim = id_pengirim;
            this.kode_transaksi = kode_transaksi;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="transferResponse", WrapperNamespace="http://service/", IsWrapped=true)]
    public partial class transferResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public transferResponse() {
        }
        
        public transferResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="cekTransaksiMasuk", WrapperNamespace="http://service/", IsWrapped=true)]
    public partial class cekTransaksiMasukRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string kode_transaksi;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string batas_waktu;
        
        public cekTransaksiMasukRequest() {
        }
        
        public cekTransaksiMasukRequest(string kode_transaksi, string batas_waktu) {
            this.kode_transaksi = kode_transaksi;
            this.batas_waktu = batas_waktu;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="cekTransaksiMasukResponse", WrapperNamespace="http://service/", IsWrapped=true)]
    public partial class cekTransaksiMasukResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public cekTransaksiMasukResponse() {
        }
        
        public cekTransaksiMasukResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="login", WrapperNamespace="http://service/", IsWrapped=true)]
    public partial class loginRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string nomor_kartu;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string nomor_pin;
        
        public loginRequest() {
        }
        
        public loginRequest(string nomor_kartu, string nomor_pin) {
            this.nomor_kartu = nomor_kartu;
            this.nomor_pin = nomor_pin;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="loginResponse", WrapperNamespace="http://service/", IsWrapped=true)]
    public partial class loginResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public loginResponse() {
        }
        
        public loginResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="hello", WrapperNamespace="http://service/", IsWrapped=true)]
    public partial class helloRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name;
        
        public helloRequest() {
        }
        
        public helloRequest(string name) {
            this.name = name;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="helloResponse", WrapperNamespace="http://service/", IsWrapped=true)]
    public partial class helloResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string @return;
        
        public helloResponse() {
        }
        
        public helloResponse(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="cekSaldo", WrapperNamespace="http://service/", IsWrapped=true)]
    public partial class cekSaldoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int id_nasabah;
        
        public cekSaldoRequest() {
        }
        
        public cekSaldoRequest(int id_nasabah) {
            this.id_nasabah = id_nasabah;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="cekSaldoResponse", WrapperNamespace="http://service/", IsWrapped=true)]
    public partial class cekSaldoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://service/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int @return;
        
        public cekSaldoResponse() {
        }
        
        public cekSaldoResponse(int @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface KonservatifServiceChannel : ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class KonservatifServiceClient : System.ServiceModel.ClientBase<ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService>, ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService {
        
        public KonservatifServiceClient() {
        }
        
        public KonservatifServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public KonservatifServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KonservatifServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public KonservatifServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ATM_Bank_Konservatif.ServiceBankKonservatif.transferResponse ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService.transfer(ATM_Bank_Konservatif.ServiceBankKonservatif.transferRequest request) {
            return base.Channel.transfer(request);
        }
        
        public int transfer(int jumlah, int id_pengirim, string kode_transaksi) {
            ATM_Bank_Konservatif.ServiceBankKonservatif.transferRequest inValue = new ATM_Bank_Konservatif.ServiceBankKonservatif.transferRequest();
            inValue.jumlah = jumlah;
            inValue.id_pengirim = id_pengirim;
            inValue.kode_transaksi = kode_transaksi;
            ATM_Bank_Konservatif.ServiceBankKonservatif.transferResponse retVal = ((ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService)(this)).transfer(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.transferResponse> ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService.transferAsync(ATM_Bank_Konservatif.ServiceBankKonservatif.transferRequest request) {
            return base.Channel.transferAsync(request);
        }
        
        public System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.transferResponse> transferAsync(int jumlah, int id_pengirim, string kode_transaksi) {
            ATM_Bank_Konservatif.ServiceBankKonservatif.transferRequest inValue = new ATM_Bank_Konservatif.ServiceBankKonservatif.transferRequest();
            inValue.jumlah = jumlah;
            inValue.id_pengirim = id_pengirim;
            inValue.kode_transaksi = kode_transaksi;
            return ((ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService)(this)).transferAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukResponse ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService.cekTransaksiMasuk(ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukRequest request) {
            return base.Channel.cekTransaksiMasuk(request);
        }
        
        public int cekTransaksiMasuk(string kode_transaksi, string batas_waktu) {
            ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukRequest inValue = new ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukRequest();
            inValue.kode_transaksi = kode_transaksi;
            inValue.batas_waktu = batas_waktu;
            ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukResponse retVal = ((ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService)(this)).cekTransaksiMasuk(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukResponse> ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService.cekTransaksiMasukAsync(ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukRequest request) {
            return base.Channel.cekTransaksiMasukAsync(request);
        }
        
        public System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukResponse> cekTransaksiMasukAsync(string kode_transaksi, string batas_waktu) {
            ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukRequest inValue = new ATM_Bank_Konservatif.ServiceBankKonservatif.cekTransaksiMasukRequest();
            inValue.kode_transaksi = kode_transaksi;
            inValue.batas_waktu = batas_waktu;
            return ((ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService)(this)).cekTransaksiMasukAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ATM_Bank_Konservatif.ServiceBankKonservatif.loginResponse ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService.login(ATM_Bank_Konservatif.ServiceBankKonservatif.loginRequest request) {
            return base.Channel.login(request);
        }
        
        public int login(string nomor_kartu, string nomor_pin) {
            ATM_Bank_Konservatif.ServiceBankKonservatif.loginRequest inValue = new ATM_Bank_Konservatif.ServiceBankKonservatif.loginRequest();
            inValue.nomor_kartu = nomor_kartu;
            inValue.nomor_pin = nomor_pin;
            ATM_Bank_Konservatif.ServiceBankKonservatif.loginResponse retVal = ((ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService)(this)).login(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.loginResponse> ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService.loginAsync(ATM_Bank_Konservatif.ServiceBankKonservatif.loginRequest request) {
            return base.Channel.loginAsync(request);
        }
        
        public System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.loginResponse> loginAsync(string nomor_kartu, string nomor_pin) {
            ATM_Bank_Konservatif.ServiceBankKonservatif.loginRequest inValue = new ATM_Bank_Konservatif.ServiceBankKonservatif.loginRequest();
            inValue.nomor_kartu = nomor_kartu;
            inValue.nomor_pin = nomor_pin;
            return ((ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService)(this)).loginAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ATM_Bank_Konservatif.ServiceBankKonservatif.helloResponse ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService.hello(ATM_Bank_Konservatif.ServiceBankKonservatif.helloRequest request) {
            return base.Channel.hello(request);
        }
        
        public string hello(string name) {
            ATM_Bank_Konservatif.ServiceBankKonservatif.helloRequest inValue = new ATM_Bank_Konservatif.ServiceBankKonservatif.helloRequest();
            inValue.name = name;
            ATM_Bank_Konservatif.ServiceBankKonservatif.helloResponse retVal = ((ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService)(this)).hello(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.helloResponse> ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService.helloAsync(ATM_Bank_Konservatif.ServiceBankKonservatif.helloRequest request) {
            return base.Channel.helloAsync(request);
        }
        
        public System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.helloResponse> helloAsync(string name) {
            ATM_Bank_Konservatif.ServiceBankKonservatif.helloRequest inValue = new ATM_Bank_Konservatif.ServiceBankKonservatif.helloRequest();
            inValue.name = name;
            return ((ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService)(this)).helloAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoResponse ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService.cekSaldo(ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoRequest request) {
            return base.Channel.cekSaldo(request);
        }
        
        public int cekSaldo(int id_nasabah) {
            ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoRequest inValue = new ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoRequest();
            inValue.id_nasabah = id_nasabah;
            ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoResponse retVal = ((ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService)(this)).cekSaldo(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoResponse> ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService.cekSaldoAsync(ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoRequest request) {
            return base.Channel.cekSaldoAsync(request);
        }
        
        public System.Threading.Tasks.Task<ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoResponse> cekSaldoAsync(int id_nasabah) {
            ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoRequest inValue = new ATM_Bank_Konservatif.ServiceBankKonservatif.cekSaldoRequest();
            inValue.id_nasabah = id_nasabah;
            return ((ATM_Bank_Konservatif.ServiceBankKonservatif.KonservatifService)(this)).cekSaldoAsync(inValue);
        }
    }
}
