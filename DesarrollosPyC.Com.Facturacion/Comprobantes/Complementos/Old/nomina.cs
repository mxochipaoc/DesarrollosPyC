﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.38967
//    <NameSpace>DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Old</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net35</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>False</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos.Old
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;


    /// <summary>
    /// Complemento al Comprobante Fiscal Digital a través de Internet (CFDI) para el manejo de datos de Nómina.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.6411")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.mx/nomina", IsNullable = false)]
    public partial class Nomina
    {

        private NominaPercepciones percepcionesField;

        private NominaDeducciones deduccionesField;

        private List<NominaIncapacidad> incapacidadesField;

        private List<NominaHorasExtra> horasExtrasField;

        private string versionField;

        private string registroPatronalField;

        private string numEmpleadoField;

        private string cURPField;

        private int tipoRegimenField;

        private string numSeguridadSocialField;

        private System.DateTime fechaPagoField;

        private System.DateTime fechaInicialPagoField;

        private System.DateTime fechaFinalPagoField;

        private decimal numDiasPagadosField;

        private string departamentoField;

        private string cLABEField;

        private string bancoField;

        private bool bancoFieldSpecified;

        private System.DateTime fechaInicioRelLaboralField;

        private bool fechaInicioRelLaboralFieldSpecified;

        private int antiguedadField;

        private bool antiguedadFieldSpecified;

        private string puestoField;

        private string tipoContratoField;

        private string tipoJornadaField;

        private string periodicidadPagoField;

        private decimal salarioBaseCotAporField;

        private bool salarioBaseCotAporFieldSpecified;

        private int riesgoPuestoField;

        private bool riesgoPuestoFieldSpecified;

        private decimal salarioDiarioIntegradoField;

        private bool salarioDiarioIntegradoFieldSpecified;

        public Nomina()
        {
            this.versionField = "1.1";
        }

        /// <summary>
        /// Nodo opcional para expresar las percepciones aplicables
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public NominaPercepciones Percepciones
        {
            get
            {
                return this.percepcionesField;
            }
            set
            {
                this.percepcionesField = value;
            }
        }

        /// <summary>
        /// Nodo opcional para expresar las deducciones aplicables
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public NominaDeducciones Deducciones
        {
            get
            {
                return this.deduccionesField;
            }
            set
            {
                this.deduccionesField = value;
            }
        }

        /// <summary>
        /// Nodo opcional para expresar las incapacidades aplicables
        /// </summary>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Incapacidad", IsNullable = false)]
        public List<NominaIncapacidad> Incapacidades
        {
            get
            {
                return this.incapacidadesField;
            }
            set
            {
                this.incapacidadesField = value;
            }
        }

        /// <summary>
        /// Nodo opcional para expresar las horas extras aplicables
        /// </summary>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("HorasExtra", IsNullable = false)]
        public List<NominaHorasExtra> HorasExtras
        {
            get
            {
                return this.horasExtrasField;
            }
            set
            {
                this.horasExtrasField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para la expresión de la versión del complemento
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <summary>
        /// Atributo opcional para expresar el registro patronal a 20 posiciones máximo
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RegistroPatronal
        {
            get
            {
                return this.registroPatronalField;
            }
            set
            {
                this.registroPatronalField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para expresar el número de empleado de 1 a 15 posiciones
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NumEmpleado
        {
            get
            {
                return this.numEmpleadoField;
            }
            set
            {
                this.numEmpleadoField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para la expresión de la CURP del trabajador
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CURP
        {
            get
            {
                return this.cURPField;
            }
            set
            {
                this.cURPField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para la expresión de la clave del régimen por el cual se tiene contratado al trabajador, conforme al catálogo publicado en el portal del SAT en internet
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TipoRegimen
        {
            get
            {
                return this.tipoRegimenField;
            }
            set
            {
                this.tipoRegimenField = value;
            }
        }

        /// <summary>
        /// Atributo opcional para la expresión del número de seguridad social aplicable al trabajador
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NumSeguridadSocial
        {
            get
            {
                return this.numSeguridadSocialField;
            }
            set
            {
                this.numSeguridadSocialField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para la expresión de la fecha efectiva de erogación del gasto. Se expresa en la forma aaaa-mm-dd, de acuerdo con la especificación ISO 8601.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime FechaPago
        {
            get
            {
                return this.fechaPagoField;
            }
            set
            {
                this.fechaPagoField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para la expresión de la fecha inicial del pago. Se expresa en la forma aaaa-mm-dd, de acuerdo con la especificación ISO 8601.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime FechaInicialPago
        {
            get
            {
                return this.fechaInicialPagoField;
            }
            set
            {
                this.fechaInicialPagoField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para la expresión de la fecha final del pago. Se expresa en la forma aaaa-mm-dd, de acuerdo con la especificación ISO 8601.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime FechaFinalPago
        {
            get
            {
                return this.fechaFinalPagoField;
            }
            set
            {
                this.fechaFinalPagoField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para la expresión del número de días pagados
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal NumDiasPagados
        {
            get
            {
                return this.numDiasPagadosField;
            }
            set
            {
                this.numDiasPagadosField = value;
            }
        }

        /// <summary>
        /// Atributo opcional para la expresión del departamento o área a la que pertenece el trabajador
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Departamento
        {
            get
            {
                return this.departamentoField;
            }
            set
            {
                this.departamentoField = value;
            }
        }

        /// <summary>
        /// Atributo opcional para la expresión de la CLABE
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string CLABE
        {
            get
            {
                return this.cLABEField;
            }
            set
            {
                this.cLABEField = value;
            }
        }

        /// <summary>
        /// Atributo opcional para la expresión del Banco conforme al catálogo, donde se realiza un depósito de nómina
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Banco
        {
            get
            {
                return this.bancoField;
            }
            set
            {
                this.bancoField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BancoSpecified
        {
            get
            {
                return this.bancoFieldSpecified;
            }
            set
            {
                this.bancoFieldSpecified = value;
            }
        }

        /// <summary>
        /// Atributo opcional para expresar la fecha de inicio de la relación laboral entre el empleador y el empleado
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime FechaInicioRelLaboral
        {
            get
            {
                return this.fechaInicioRelLaboralField;
            }
            set
            {
                this.fechaInicioRelLaboralField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FechaInicioRelLaboralSpecified
        {
            get
            {
                return this.fechaInicioRelLaboralFieldSpecified;
            }
            set
            {
                this.fechaInicioRelLaboralFieldSpecified = value;
            }
        }

        /// <summary>
        /// Número de semanas que el empleado ha mantenido relación laboral con el empleador
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Antiguedad
        {
            get
            {
                return this.antiguedadField;
            }
            set
            {
                this.antiguedadField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AntiguedadSpecified
        {
            get
            {
                return this.antiguedadFieldSpecified;
            }
            set
            {
                this.antiguedadFieldSpecified = value;
            }
        }

        /// <summary>
        /// Puesto asignado al empleado o actividad que realiza
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Puesto
        {
            get
            {
                return this.puestoField;
            }
            set
            {
                this.puestoField = value;
            }
        }

        /// <summary>
        /// Tipo de contrato que tiene el trabajador: Base, Eventual, Confianza, Sindicalizado, a prueba, etc.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TipoContrato
        {
            get
            {
                return this.tipoContratoField;
            }
            set
            {
                this.tipoContratoField = value;
            }
        }

        /// <summary>
        /// Tipo de jornada que cubre el trabajador: Diurna, nocturna, mixta, por hora, reducida, continuada, partida, por turnos, etc.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TipoJornada
        {
            get
            {
                return this.tipoJornadaField;
            }
            set
            {
                this.tipoJornadaField = value;
            }
        }

        /// <summary>
        /// Forma en que se establece el pago del salario: diario, semanal, quincenal, catorcenal mensual, bimestral, unidad de obra, comisión, precio alzado, etc.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PeriodicidadPago
        {
            get
            {
                return this.periodicidadPagoField;
            }
            set
            {
                this.periodicidadPagoField = value;
            }
        }

        /// <summary>
        /// Retribución otorgada al trabajador, que se integra por los pagos hechos en efectivo por cuota diaria, gratificaciones, percepciones, alimentación, habitación, primas, comisiones, prestaciones en especie y cualquiera otra cantidad o prestación que se entregue al trabajador por su trabajo
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal SalarioBaseCotApor
        {
            get
            {
                return this.salarioBaseCotAporField;
            }
            set
            {
                this.salarioBaseCotAporField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SalarioBaseCotAporSpecified
        {
            get
            {
                return this.salarioBaseCotAporFieldSpecified;
            }
            set
            {
                this.salarioBaseCotAporFieldSpecified = value;
            }
        }

        /// <summary>
        /// Clave conforme a la Clase en que deben inscribirse los patrones, de acuerdo a las actividades que desempeñan sus trabajadores, según lo previsto en el artículo 196 del Reglamento en Materia de Afiliación Clasificación de Empresas, Recaudación y Fiscalización. Catálogo publicado en el portal del SAT en internet
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int RiesgoPuesto
        {
            get
            {
                return this.riesgoPuestoField;
            }
            set
            {
                this.riesgoPuestoField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RiesgoPuestoSpecified
        {
            get
            {
                return this.riesgoPuestoFieldSpecified;
            }
            set
            {
                this.riesgoPuestoFieldSpecified = value;
            }
        }

        /// <summary>
        /// Salario diario integrado
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal SalarioDiarioIntegrado
        {
            get
            {
                return this.salarioDiarioIntegradoField;
            }
            set
            {
                this.salarioDiarioIntegradoField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool SalarioDiarioIntegradoSpecified
        {
            get
            {
                return this.salarioDiarioIntegradoFieldSpecified;
            }
            set
            {
                this.salarioDiarioIntegradoFieldSpecified = value;
            }
        }
    }

    /// <summary>
    /// Nodo opcional para expresar las percepciones aplicables
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.6411")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina")]
    public partial class NominaPercepciones
    {

        private List<NominaPercepcionesPercepcion> percepcionField;

        private decimal totalGravadoField;

        private decimal totalExentoField;

        /// <summary>
        /// Nodo para expresar la información detallada de una percepción
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Percepcion", Order = 0)]
        public List<NominaPercepcionesPercepcion> Percepcion
        {
            get
            {
                return this.percepcionField;
            }
            set
            {
                this.percepcionField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para expresar el total de percepciones gravadas que se relacionan en el comprobante
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalGravado
        {
            get
            {
                return this.totalGravadoField;
            }
            set
            {
                this.totalGravadoField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para expresar el total de percepciones exentas que se relacionan en el comprobante
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalExento
        {
            get
            {
                return this.totalExentoField;
            }
            set
            {
                this.totalExentoField = value;
            }
        }
    }

    /// <summary>
    /// Nodo para expresar la información detallada de una percepción
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.6411")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina")]
    public partial class NominaPercepcionesPercepcion
    {

        private string tipoPercepcionField;

        private string claveField;

        private string conceptoField;

        private decimal importeGravadoField;

        private decimal importeExentoField;

        /// <summary>
        /// Clave agrupadora. Clasifica la percepción conforme al catálogo publicado en el portal del SAT en internet
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TipoPercepcion
        {
            get
            {
                return this.tipoPercepcionField;
            }
            set
            {
                this.tipoPercepcionField = value;
            }
        }

        /// <summary>
        /// Atributo requerido, representa la clave de percepción de nómina propia de la contabilidad de cada patrón, puede conformarse desde 3 hasta 15 caracteres
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Clave
        {
            get
            {
                return this.claveField;
            }
            set
            {
                this.claveField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para la descripción del concepto de percepción
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Concepto
        {
            get
            {
                return this.conceptoField;
            }
            set
            {
                this.conceptoField = value;
            }
        }

        /// <summary>
        /// Atributo requerido, representa el importe gravado de un concepto de percepción
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImporteGravado
        {
            get
            {
                return this.importeGravadoField;
            }
            set
            {
                this.importeGravadoField = value;
            }
        }

        /// <summary>
        /// Atributo requerido, representa el importe exento de un concepto de percepción
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImporteExento
        {
            get
            {
                return this.importeExentoField;
            }
            set
            {
                this.importeExentoField = value;
            }
        }
    }

    /// <summary>
    /// Nodo opcional para expresar las deducciones aplicables
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.6411")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina")]
    public partial class NominaDeducciones
    {

        private List<NominaDeduccionesDeduccion> deduccionField;

        private decimal totalGravadoField;

        private decimal totalExentoField;

        /// <summary>
        /// Nodo para expresar la información detallada de una deducción
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Deduccion", Order = 0)]
        public List<NominaDeduccionesDeduccion> Deduccion
        {
            get
            {
                return this.deduccionField;
            }
            set
            {
                this.deduccionField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para expresar el total de deducciones gravadas que se relacionan en el comprobante
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalGravado
        {
            get
            {
                return this.totalGravadoField;
            }
            set
            {
                this.totalGravadoField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para expresar el total de deducciones exentas que se relacionan en el comprobante
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TotalExento
        {
            get
            {
                return this.totalExentoField;
            }
            set
            {
                this.totalExentoField = value;
            }
        }
    }

    /// <summary>
    /// Nodo para expresar la información detallada de una deducción
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.6411")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina")]
    public partial class NominaDeduccionesDeduccion
    {

        private string tipoDeduccionField;

        private string claveField;

        private string conceptoField;

        private decimal importeGravadoField;

        private decimal importeExentoField;

        /// <summary>
        /// Clave agrupadora. Clasifica la deducción conforme al catálogo publicado en el portal del SAT en internet
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TipoDeduccion
        {
            get
            {
                return this.tipoDeduccionField;
            }
            set
            {
                this.tipoDeduccionField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para la clave de deducción de nómina propia de la contabilidad de cada patrón, puede conformarse desde 3 hasta 15 caracteres
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Clave
        {
            get
            {
                return this.claveField;
            }
            set
            {
                this.claveField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para la descripción del concepto de deducción
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Concepto
        {
            get
            {
                return this.conceptoField;
            }
            set
            {
                this.conceptoField = value;
            }
        }

        /// <summary>
        /// Atributo requerido, representa el importe gravado de un concepto de deducción
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImporteGravado
        {
            get
            {
                return this.importeGravadoField;
            }
            set
            {
                this.importeGravadoField = value;
            }
        }

        /// <summary>
        /// Atributo requerido, representa el importe exento de un concepto de deducción
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImporteExento
        {
            get
            {
                return this.importeExentoField;
            }
            set
            {
                this.importeExentoField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.6411")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina")]
    public partial class NominaIncapacidad
    {

        private decimal diasIncapacidadField;

        private int tipoIncapacidadField;

        private decimal descuentoField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal DiasIncapacidad
        {
            get
            {
                return this.diasIncapacidadField;
            }
            set
            {
                this.diasIncapacidadField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int TipoIncapacidad
        {
            get
            {
                return this.tipoIncapacidadField;
            }
            set
            {
                this.tipoIncapacidadField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Descuento
        {
            get
            {
                return this.descuentoField;
            }
            set
            {
                this.descuentoField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.6411")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina")]
    public partial class NominaHorasExtra
    {

        private int diasField;

        private NominaHorasExtraTipoHoras tipoHorasField;

        private int horasExtraField;

        private decimal importePagadoField;

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Dias
        {
            get
            {
                return this.diasField;
            }
            set
            {
                this.diasField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public NominaHorasExtraTipoHoras TipoHoras
        {
            get
            {
                return this.tipoHorasField;
            }
            set
            {
                this.tipoHorasField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int HorasExtra
        {
            get
            {
                return this.horasExtraField;
            }
            set
            {
                this.horasExtraField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ImportePagado
        {
            get
            {
                return this.importePagadoField;
            }
            set
            {
                this.importePagadoField = value;
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.6411")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/nomina")]
    public enum NominaHorasExtraTipoHoras
    {

        /// <remarks/>
        Dobles,

        /// <remarks/>
        Triples,
    }
}