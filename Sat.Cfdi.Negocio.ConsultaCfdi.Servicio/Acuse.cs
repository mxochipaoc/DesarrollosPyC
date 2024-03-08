using System.Runtime.Serialization;
using System;

namespace Sat.Cfdi.Negocio.ConsultaCfdi.Servicio
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "Acuse", Namespace = "http://schemas.datacontract.org/2004/07/Sat.Cfdi.Negocio.ConsultaCfdi.Servicio")]
    [System.SerializableAttribute()]
    public partial class Acuse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoEstatusField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EstadoField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodigoEstatus
        {
            get
            {
                return this.CodigoEstatusField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CodigoEstatusField, value) != true))
                {
                    this.CodigoEstatusField = value;
                    this.RaisePropertyChanged("CodigoEstatus");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Estado
        {
            get
            {
                return this.EstadoField;
            }
            set
            {
                if ((object.ReferenceEquals(this.EstadoField, value) != true))
                {
                    this.EstadoField = value;
                    this.RaisePropertyChanged("Estado");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
