﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.4.0.38967
//    <NameSpace>DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><IncludeSerializeMethod>True</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net35</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><EnableInitializeFields>False</EnableInitializeFields>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace DesarrollosPyC.Com.Facturacion.Comprobantes.Complementos
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;


    /// <summary>
    /// Complemento concepto para la expedición de comprobantes fiscales por parte de Instituciones Educativas Privadas, para los efectos del artículo primero y cuarto del decreto por el que se otorga un estímulo fiscal a las personas físicas en relación con los pagos por servicios educativos
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.6411")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/iedu")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.mx/iedu", IsNullable = false)]
    public partial class instEducativas
    {

        private string versionField;

        private string nombreAlumnoField;

        private string cURPField;

        private instEducativasNivelEducativo nivelEducativoField;

        private string autRVOEField;

        private string rfcPagoField;

        private static System.Xml.Serialization.XmlSerializer serializer;

        public instEducativas()
        {
            this.versionField = "1.0";
        }

        /// <summary>
        /// Atributo requerido con valor prefijado a 1.0 que indica la versión del estándar bajo el que se encuentra expresado el complemento concepto al comprobante.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version
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
        /// Atributo requerido para indicar el nombre del Alumno
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string nombreAlumno
        {
            get
            {
                return this.nombreAlumnoField;
            }
            set
            {
                this.nombreAlumnoField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para indicar la CURP del alumno de la institución educativa
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
        /// Atributo requerido para indicar el nivel educativo que cursa el alumno
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public instEducativasNivelEducativo nivelEducativo
        {
            get
            {
                return this.nivelEducativoField;
            }
            set
            {
                this.nivelEducativoField = value;
            }
        }

        /// <summary>
        /// Atributo requerido para especificar la clave del centro de trabajo o el reconocimiento de validez oficial de estudios en los términos de la Ley General de Educación que tenga la institución educativa privada donde se realiza el pago.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string autRVOE
        {
            get
            {
                return this.autRVOEField;
            }
            set
            {
                this.autRVOEField = value;
            }
        }

        /// <summary>
        /// Atributo opcional para indicar el RFC de quien realiza el pago cuando sea diferente a quien recibe el servicio
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string rfcPago
        {
            get
            {
                return this.rfcPagoField;
            }
            set
            {
                this.rfcPagoField = value;
            }
        }

        private static System.Xml.Serialization.XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new System.Xml.Serialization.XmlSerializer(typeof(instEducativas));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current instEducativas object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if ((streamReader != null))
                {
                    streamReader.Dispose();
                }
                if ((memoryStream != null))
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an instEducativas object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output instEducativas object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out instEducativas obj, out System.Exception exception)
        {
            exception = null;
            obj = default(instEducativas);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out instEducativas obj)
        {
            System.Exception exception = null;
            return Deserialize(xml, out obj, out exception);
        }

        public static instEducativas Deserialize(string xml)
        {
            System.IO.StringReader stringReader = null;
            try
            {
                stringReader = new System.IO.StringReader(xml);
                return ((instEducativas)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
            }
            finally
            {
                if ((stringReader != null))
                {
                    stringReader.Dispose();
                }
            }
        }

        /// <summary>
        /// Serializes current instEducativas object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out System.Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (System.Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                System.IO.FileInfo xmlFile = new System.IO.FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                if ((streamWriter != null))
                {
                    streamWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an instEducativas object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output instEducativas object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out instEducativas obj, out System.Exception exception)
        {
            exception = null;
            obj = default(instEducativas);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (System.Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out instEducativas obj)
        {
            System.Exception exception = null;
            return LoadFromFile(fileName, out obj, out exception);
        }

        public static instEducativas LoadFromFile(string fileName)
        {
            System.IO.FileStream file = null;
            System.IO.StreamReader sr = null;
            try
            {
                file = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new System.IO.StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                if ((file != null))
                {
                    file.Dispose();
                }
                if ((sr != null))
                {
                    sr.Dispose();
                }
            }
        }
        #endregion
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.6411")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/iedu")]
    public enum instEducativasNivelEducativo
    {

        /// <remarks/>
        [Description("Preescolar")]
        Preescolar,

        /// <remarks/>
        [Description("Primaria")]
        Primaria,

        /// <remarks/>
        [Description("Secundaria")]
        Secundaria,

        /// <remarks/>
        [Description("Profesional técnico")]
        [System.Xml.Serialization.XmlEnumAttribute("Profesional técnico")]
        Profesionaltécnico,

        /// <remarks/>
        [Description("Bachillerato o su equivalente")]
        [System.Xml.Serialization.XmlEnumAttribute("Bachillerato o su equivalente")]
        Bachilleratoosuequivalente,
    }
}