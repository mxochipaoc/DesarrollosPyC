using System.Runtime.Serialization;
using System;

namespace Sat.Cfdi.Negocio.ConsultaCfdi.Servicio
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConsultaCFDIServiceClient : System.ServiceModel.ClientBase<IConsultaCFDIService>, IConsultaCFDIService
    {

        public ConsultaCFDIServiceClient()
        {
        }

        public ConsultaCFDIServiceClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public ConsultaCFDIServiceClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public ConsultaCFDIServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public ConsultaCFDIServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public Acuse Consulta(string expresionImpresa)
        {
            return base.Channel.Consulta(expresionImpresa);
        }

        public System.Threading.Tasks.Task<Acuse> ConsultaAsync(string expresionImpresa)
        {
            return base.Channel.ConsultaAsync(expresionImpresa);
        }
    }
}
