using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Restaurante_BL
{
    [Serializable]
    public class ResumenFactura
    {
        [XmlAttribute]
        public string CodigoMoneda { get; set; }
        public string TipoCambio { get; set; }
        public string TotalServGravados { get; set; }
        public string TotalServExentos { get; set; }
        public string TotalMercanciasGravadas { get; set; }
        public string TotalMercanciasExentas { get; set; }
        public string TotalGravado { get; set; }
        public string TotalExcento { get; set; }
        public string TotalVenta { get; set; }
        public string TotalDescuento { get; set; }
        public string TotalVentaNeta { get; set; }
        public string TotalImpuesto { get; set; }
        public string TotalComprobante { get; set; }
    }

}
