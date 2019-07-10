using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PuntoVentaBL
{
    class Generador_Factura
    {
        public Generador_Factura() {

        }

        public string Factura_Electronica(
            String Llave,
            String NumeroConsecutivo,
            String FechaEmision,
            Persona Emisor,
            Persona Receptor,
            String CondicionVenta,
            String PlazoCredito,
            String MedioPago,
            DetalleServicio DetalleServicio,
            ResumenFactura ResumenFactura,
            String NumeroResol,
            String FechaResolucion)
        {

            XML xml_handler = new XML();
            string template = xml_handler.get_template_Factura();
            //Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(template);


            //set the root
            xml_handler.initiate(doc.DocumentElement.FirstChild);

            //Set the key 
            xml_handler.edit_node(Llave);
            xml_handler.current_node = xml_handler.current_node.NextSibling;

            //Set the numeroconsecutivo
            xml_handler.edit_node(NumeroConsecutivo);
            xml_handler.current_node = xml_handler.current_node.NextSibling;

            //Set the fechaemision
            xml_handler.edit_node(FechaEmision);
            xml_handler.current_node = xml_handler.current_node.NextSibling;

            //Set the emisor
            xml_handler.edit_persona(Emisor);
            xml_handler.current_node = xml_handler.current_node.NextSibling;

            //Set the Receptor
            xml_handler.edit_persona(Receptor);
            xml_handler.current_node = xml_handler.current_node.NextSibling;

            //CondicionVenta 
            xml_handler.edit_node(CondicionVenta);
            xml_handler.current_node = xml_handler.current_node.NextSibling;

            //PlazoCredito 
            xml_handler.edit_node(PlazoCredito);
            xml_handler.current_node = xml_handler.current_node.NextSibling;

            //MedioPago  
            xml_handler.edit_node(MedioPago);
            xml_handler.current_node = xml_handler.current_node.NextSibling;

            //Servicio
            xml_handler.add_LineasFactura(DetalleServicio);
            xml_handler.current_node = xml_handler.current_node.NextSibling;

            //Resumen
            xml_handler.edit_ResumenFactura(ResumenFactura);
            xml_handler.current_node = xml_handler.current_node.NextSibling;

            //Normativa

            XmlElement bookElement = (XmlElement)xml_handler.current_node;
            bookElement["NumeroResolucion"].InnerText = NumeroResol;
            bookElement["FechaResolucion"].InnerText = FechaResolucion;

            return doc.DocumentElement.OuterXml;

        }
    }
}
