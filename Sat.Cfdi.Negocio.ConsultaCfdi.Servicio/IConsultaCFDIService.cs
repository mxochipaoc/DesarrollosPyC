using System.Runtime.Serialization;
using System;

namespace Sat.Cfdi.Negocio.ConsultaCfdi.Servicio
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "Sat.Cfdi.Negocio.ConsultaCfdi.Servicio.IConsultaCFDIService")]
    public interface IConsultaCFDIService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IConsultaCFDIService/Consulta", ReplyAction = "http://tempuri.org/IConsultaCFDIService/ConsultaResponse")]
        Acuse Consulta(string expresionImpresa);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IConsultaCFDIService/Consulta", ReplyAction = "http://tempuri.org/IConsultaCFDIService/ConsultaResponse")]
        System.Threading.Tasks.Task<Acuse> ConsultaAsync(string expresionImpresa);
    }
}
