using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PuntoVentaBL
{
    [Serializable]
    public class DetalleServicio
    {
        [XmlAttribute]
        public List<LineaDetalle> LineasDetalle { get; set; }

        public DetalleServicio()
        {
            LineasDetalle = new List<LineaDetalle>();
        }
    }
}
