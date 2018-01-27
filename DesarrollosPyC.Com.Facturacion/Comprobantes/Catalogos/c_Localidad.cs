namespace DesarrollosPyC.Com.Facturacion.Comprobantes.Catalogos {
	using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

	
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2612.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.sat.gob.mx/sitio_internet/cfd/catalogos")]
    public enum c_Localidad
    {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("01")]
        Item01,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("02")]
        Item02,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("03")]
        Item03,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("04")]
        Item04,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("05")]
        Item05,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("06")]
        Item06,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("07")]
        Item07,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("08")]
        Item08,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("09")]
        Item09,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("10")]
        Item10,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("11")]
        Item11,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("12")]
        Item12,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("13")]
        Item13,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("14")]
        Item14,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("15")]
        Item15,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("16")]
        Item16,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("17")]
        Item17,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("18")]
        Item18,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("19")]
        Item19,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("20")]
        Item20,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("21")]
        Item21,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("22")]
        Item22,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("23")]
        Item23,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("24")]
        Item24,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("25")]
        Item25,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("26")]
        Item26,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("27")]
        Item27,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("28")]
        Item28,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("29")]
        Item29,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("30")]
        Item30,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("31")]
        Item31,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("32")]
        Item32,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("33")]
        Item33,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("34")]
        Item34,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("35")]
        Item35,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("36")]
        Item36,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("37")]
        Item37,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("38")]
        Item38,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("39")]
        Item39,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("40")]
        Item40,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("41")]
        Item41,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("42")]
        Item42,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("43")]
        Item43,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("44")]
        Item44,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("45")]
        Item45,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("46")]
        Item46,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("47")]
        Item47,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("48")]
        Item48,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("49")]
        Item49,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("50")]
        Item50,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("51")]
        Item51,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("52")]
        Item52,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("53")]
        Item53,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("54")]
        Item54,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("55")]
        Item55,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("56")]
        Item56,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("57")]
        Item57,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("58")]
        Item58,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("59")]
        Item59,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("60")]
        Item60,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("61")]
        Item61,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("62")]
        Item62,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("66")]
        Item66,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("67")]
        Item67,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("68")]
        Item68,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("69")]
        Item69,
    }
}