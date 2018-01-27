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


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.mx/sitio_internet/cfd/catalogos/Nomina", IsNullable = false)]
    public enum c_Estado
    {

        /// <comentarios/>
        [Description("AGUASCALIENTES")]
        AGU,

        /// <comentarios/>
        [Description("BAJA CALIFORNIA")]
        BCN,

        /// <comentarios/>
        [Description("BAJA CALIFORNIA SUR")]
        BCS,

        /// <comentarios/>
        [Description("CAMPECHE")]
        CAM,

        /// <comentarios/>
        [Description("CHIAPAS")]
        CHP,

        /// <comentarios/>
        [Description("CHIHUAHUA")]
        CHH,

        /// <comentarios/>
        [Description("COAHUILA")]
        COA,

        /// <comentarios/>
        [Description("COLIMA")]
        COL,

        /// <comentarios/>
        [Description("DISTRITO FEDERAL")]
        DIF,

        /// <comentarios/>
        [Description("DURANGO")]
        DUR,

        /// <comentarios/>
        [Description("GUANAJUATO")]
        GUA,

        /// <comentarios/>
        [Description("GUERRERO")]
        GRO,

        /// <comentarios/>
        [Description("HIDALGO")]
        HID,

        /// <comentarios/>
        [Description("JALISCO")]
        JAL,

        /// <comentarios/>
        [Description("MEXICO")]
        MEX,

        /// <comentarios/>
        [Description("MICHOACAN")]
        MIC,

        /// <comentarios/>
        [Description("MORELOS")]
        MOR,

        /// <comentarios/>
        [Description("NAYARIT")]
        NAY,

        /// <comentarios/>
        [Description("NUEVO LEON")]
        NLE,

        /// <comentarios/>
        [Description("OAXACA")]
        OAX,

        /// <comentarios/>
        [Description("PUEBLA")]
        PUE,

        /// <comentarios/>
        [Description("QUERETARO")]
        QUE,

        /// <comentarios/>
        [Description("QUINTANA ROO")]
        ROO,

        /// <comentarios/>
        [Description("SAN LUIS POTOSI")]
        SLP,

        /// <comentarios/>
        [Description("SINALOA")]
        SIN,

        /// <comentarios/>
        [Description("SONORA")]
        SON,

        /// <comentarios/>
        [Description("TABASCO")]
        TAB,

        /// <comentarios/>
        [Description("TAMAULIPAS")]
        TAM,

        /// <comentarios/>
        [Description("TLAXCALA")]
        TLA,

        /// <comentarios/>
        [Description("VERACRUZ")]
        VER,

        /// <comentarios/>
        [Description("YUCATAN")]
        YUC,

        /// <comentarios/>
        [Description("ZACATECAS")]
        ZAC,

        /// <comentarios/>
        [Description("Alabama")]
        AL,

        /// <comentarios/>
        [Description("Alaska")]
        AK,

        /// <comentarios/>
        [Description("Arizona")]
        AZ,

        /// <comentarios/>
        [Description("Arkansas")]
        AR,

        /// <comentarios/>
        [Description("California")]
        CA,

        /// <comentarios/>
        [Description("Carolina del Norte")]
        NC,

        /// <comentarios/>
        [Description("Carolina del Sur")]
        SC,

        /// <comentarios/>
        [Description("Colorado")]
        CO,

        /// <comentarios/>
        [Description("Connecticut")]
        CT,

        /// <comentarios/>
        [Description("Dakota del Norte")]
        ND,

        /// <comentarios/>
        [Description("Dakota del Sur")]
        SD,

        /// <comentarios/>
        [Description("Delaware")]
        DE,

        /// <comentarios/>
        [Description("Florida")]
        FL,

        /// <comentarios/>
        [Description("Georgia")]
        GA,

        /// <comentarios/>
        [Description("Hawái")]
        HI,

        /// <comentarios/>
        [Description("Idaho")]
        ID,

        /// <comentarios/>
        [Description("Illinois")]
        IL,

        /// <comentarios/>
        [Description("Indiana")]
        IN,

        /// <comentarios/>
        [Description("Iowa")]
        IA,

        /// <comentarios/>
        [Description("Kansas")]
        KS,

        /// <comentarios/>
        [Description("Kentucky")]
        KY,

        /// <comentarios/>
        [Description("Luisiana")]
        LA,

        /// <comentarios/>
        [Description("Maine")]
        ME,

        /// <comentarios/>
        [Description("Maryland")]
        MD,

        /// <comentarios/>
        [Description("Massachusetts")]
        MA,

        /// <comentarios/>
        [Description("Míchigan")]
        MI,

        /// <comentarios/>
        [Description("Minnesota")]
        MN,

        /// <comentarios/>
        [Description("Misisipi")]
        MS,

        /// <comentarios/>
        [Description("Misuri")]
        MO,

        /// <comentarios/>
        [Description("Montana")]
        MT,

        /// <comentarios/>
        [Description("Nebraska")]
        NE,

        /// <comentarios/>
        [Description("Nevada")]
        NV,

        /// <comentarios/>
        [Description("Nueva Jersey")]
        NJ,

        /// <comentarios/>
        [Description("Nueva York")]
        NY,

        /// <comentarios/>
        [Description("Nuevo Hampshire")]
        NH,

        /// <comentarios/>
        [Description("Nuevo México")]
        NM,

        /// <comentarios/>
        [Description("Ohio")]
        OH,

        /// <comentarios/>
        [Description("Oklahoma")]
        OK,

        /// <comentarios/>
        [Description("Oregón")]
        OR,

        /// <comentarios/>
        [Description("Pensilvania")]
        PA,

        /// <comentarios/>
        [Description("Rhode Island")]
        RI,

        /// <comentarios/>
        [Description("Tennessee")]
        TN,

        /// <comentarios/>
        [Description("Texas")]
        TX,

        /// <comentarios/>
        [Description("Utah")]
        UT,

        /// <comentarios/>
        [Description("Vermont")]
        VT,

        /// <comentarios/>
        [Description("Virginia")]
        VA,

        /// <comentarios/>
        [Description("Virginia Occidental")]
        WV,

        /// <comentarios/>
        [Description("Washington")]
        WA,

        /// <comentarios/>
        [Description("Wisconsin")]
        WI,

        /// <comentarios/>
        [Description("Wyoming")]
        WY,

        /// <comentarios/>
        [Description("Ontario ")]
        ON,

        /// <comentarios/>
        [Description("Quebec ")]
        QC,

        /// <comentarios/>
        [Description("Nueva Escocia")]
        NS,

        /// <comentarios/>
        [Description("Nuevo Brunswick ")]
        NB,

        /// <comentarios/>
        [Description("Manitoba")]
        MB,

        /// <comentarios/>
        [Description("Columbia Británica")]
        BC,

        /// <comentarios/>
        [Description("Isla del Príncipe Eduard")]
        PE,

        /// <comentarios/>
        [Description("Saskatchewan")]
        SK,

        /// <comentarios/>
        [Description("Alberta")]
        AB,

        /// <comentarios/>
        [Description("Terranova y Labrador")]
        NL,

        /// <comentarios/>
        [Description("Territorios del Noroeste")]
        NT,

        /// <comentarios/>
        [Description("Yukón")]
        YT,

        /// <comentarios/>
        [Description("Nunavut")]
        UN,
    }
}