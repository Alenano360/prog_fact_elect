using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PuntoVentaBL
{
    [Serializable]
    public class LineaDetalle
    {
        [XmlAttribute]
        public string NumeroLinea { get; set; }
        public string Cod_Tipo { get; set; }
        public string Cod_Numero { get; set; }
        public string Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public string UnidadComercial { get; set; }
        public string Detalle { get; set; }
        public string PrecioUnitario { get; set; }
        public string MontoTotal { get; set; }
        public string NaturalezaDescuento { get; set; }
        public string Subtotal { get; set; }
        public string MontoTotalLinea { get; set; }
        public string Descuento { get; set; }
        public string Impuesto{ get; set; }
    }
}
