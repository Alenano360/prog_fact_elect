using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PuntoVentaBL
{
    public class XML
    {
        public XmlNode root = null;
        public XmlNode current_node = null;

        public XML()
        {

        }

        public string get_template_Factura()
        {
            string template = "<FacturaElectronica xmlns=\"https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/facturaElectronica\" xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" xmlns:vc=\"http://www.w3.org/2007/XMLSchema-versioning\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">" +
             "<Clave></Clave>" +
         "<NumeroConsecutivo></NumeroConsecutivo>" +
         "<FechaEmision></FechaEmision>" +
         "<Emisor>" +
            "<Nombre></Nombre>" +
            "<Identificacion>" +
               "<Tipo></Tipo>" +
              " <Numero></Numero>" +
            "</Identificacion>" +
            "<NombreComercial/>" +
            "<Ubicacion>" +
               "<Provincia></Provincia>" +
              "<Canton></Canton>" +
              "<Distrito></Distrito>" +
             "<OtrasSenas></OtrasSenas>" +
           "</Ubicacion>" +
           "<CorreoElectronico></CorreoElectronico>" +
         "</Emisor>" +
          "<Receptor>" +
            "<Nombre></Nombre>" +
            "<Identificacion>" +
               "<Tipo></Tipo>" +
              "<Numero></Numero>" +
            "</Identificacion>" +
            "<NombreComercial/>" +
            "<Ubicacion>" +
               "<Provincia></Provincia>" +
              "<Canton></Canton>" +
              "<Distrito></Distrito>" +
             "<OtrasSenas></OtrasSenas>" +
           "</Ubicacion>" +
           "<CorreoElectronico></CorreoElectronico>" +
         "</Receptor>" +
            "<CondicionVenta></CondicionVenta>" +
       "<PlazoCredito/>" +
       "<MedioPago></MedioPago>" +
          "<DetalleServicio>" +
          "</DetalleServicio>" +
             "<ResumenFactura>" +
          "<CodigoMoneda></CodigoMoneda>" +
          "<TipoCambio></TipoCambio>" +
          "<TotalMercanciasGravadas></TotalMercanciasGravadas>" +
          "<TotalMercanciasExentas></TotalMercanciasExentas>" +
          "<TotalGravado></TotalGravado>" +
          "<TotalExento></TotalExento>" +
          "<TotalVenta></TotalVenta>" +
          "<TotalDescuentos></TotalDescuentos>" +
          "<TotalVentaNeta></TotalVentaNeta>" +
          "<TotalImpuesto></TotalImpuesto>" +
          "<TotalComprobante></TotalComprobante>" +
       "</ResumenFactura>" +
       "<Normativa>" +
          "<NumeroResolucion></NumeroResolucion>" +
          "<FechaResolucion></FechaResolucion>" +
       "</Normativa>" +
       "<Otros>" +
         "<OtroTexto/>" +
       "</Otros>" +
       "<ds:Signature xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" Id=\"Signature-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\">" +
          "<ds:SignedInfo>" +
             "<ds:CanonicalizationMethod Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315\"/>" +
             "<ds:SignatureMethod Algorithm=\"http://www.w3.org/2001/04/xmldsig-more#rsa-sha256\"/>" +
             "<ds:Reference Id=\"Reference-6ee46894-f5d3-40d4-bf95-6b818ba9f736\" URI=\"\">" +
                "<ds:Transforms>" +
                   "<ds:Transform Algorithm=\"http://www.w3.org/2000/09/xmldsig#enveloped-signature\"/>" +
                "</ds:Transforms>" +
                "<ds:DigestMethod Algorithm=\"http://www.w3.org/2001/04/xmlenc#sha256\"/>" +
                "<ds:DigestValue/>" +
             "</ds:Reference>" +
             "<ds:Reference Id=\"ReferenceKeyInfo\" URI=\"#KeyInfoId-Signature-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\">" +
                "<ds:DigestMethod Algorithm=\"http://www.w3.org/2001/04/xmlenc#sha256\"/>" +
                "<ds:DigestValue/>" +
             "</ds:Reference>" +
             "<ds:Reference Type=\"http://uri.etsi.org/01903#SignedProperties\" URI=\"#SignedProperties-Signature-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\">" +
                "<ds:DigestMethod Algorithm=\"http://www.w3.org/2001/04/xmlenc#sha256\"/>" +
                "<ds:DigestValue/>" +
             "</ds:Reference>" +
          "</ds:SignedInfo>" +
          "<ds:SignatureValue Id=\"SignatureValue-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\"/>" +
          "<ds:KeyInfo Id=\"KeyInfoId-Signature-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\">" +
             "<ds:X509Data>" +
                "<ds:X509Certificate/>" +
             "</ds:X509Data>" +
             "<ds:KeyValue/>" +
          "</ds:KeyInfo>" +
          "<ds:Object Id=\"XadesObjectId-1fc7521f-203e-4fec-9266-11b4c7a2e51e\">" +
             "<xades:QualifyingProperties xmlns:xades=\"http://uri.etsi.org/01903/v1.3.2#\" Id=\"QualifyingProperties-f9b2eaf1-b962-448b-a11c-c58f4d4d9a94\" Target=\"#Signature-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\">" +
                "<xades:SignedProperties Id=\"SignedProperties-Signature-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\">" +
                   "<xades:SignedSignatureProperties>" +
                      "<xades:SigningTime />" +
                      "<xades:SigningCertificate />" +
                      "<xades:SignaturePolicyIdentifier />" +
                   "</xades:SignedSignatureProperties>" +
                   "<xades:SignedDataObjectProperties>" +
                      "<xades:DataObjectFormat ObjectReference=\"#Reference-6ee46894-f5d3-40d4-bf95-6b818ba9f736\">" +
                         "<xades:MimeType>text/xml</xades:MimeType>" +
                         "<xades:Encoding>UTF-8</xades:Encoding>" +
                      "</xades:DataObjectFormat>" +
                   "</xades:SignedDataObjectProperties>" +
               "</xades:SignedProperties>" +
             "</xades:QualifyingProperties>" +
          "</ds:Object>" +
       "</ds:Signature>" +
       "</FacturaElectronica>";
            return template;
        }

        public string get_template_ticket()
        {
            string template = "<TiqueteElectronico xmlns=\"https://tribunet.hacienda.go.cr/docs/esquemas/2017/v4.2/tiqueteElectronico\" xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" xmlns:vc=\"http://www.w3.org/2007/XMLSchema-versioning\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\">" +
             "<Clave></Clave>" +
         "<NumeroConsecutivo></NumeroConsecutivo>" +
         "<FechaEmision></FechaEmision>" +
         "<Emisor>" +
            "<Nombre></Nombre>" +
            "<Identificacion>" +
               "<Tipo></Tipo>" +
              " <Numero></Numero>" +
            "</Identificacion>" +
            "<NombreComercial/>" +
            "<Ubicacion>" +
               "<Provincia></Provincia>" +
              "<Canton></Canton>" +
              "<Distrito></Distrito>" +
             "<OtrasSenas></OtrasSenas>" +
           "</Ubicacion>" +
           "<CorreoElectronico></CorreoElectronico>" +
         "</Emisor>" +
          
            "<CondicionVenta></CondicionVenta>" +
       "<PlazoCredito/>" +
       "<MedioPago></MedioPago>" +
          "<DetalleServicio>" +
          "</DetalleServicio>" +
             "<ResumenFactura>" +
          "<CodigoMoneda></CodigoMoneda>" +
          "<TipoCambio></TipoCambio>" +
          "<TotalMercanciasGravadas></TotalMercanciasGravadas>" +
          "<TotalMercanciasExentas></TotalMercanciasExentas>" +
          "<TotalGravado></TotalGravado>" +
          "<TotalExento></TotalExento>" +
          "<TotalVenta></TotalVenta>" +
          "<TotalDescuentos></TotalDescuentos>" +
          "<TotalVentaNeta></TotalVentaNeta>" +
          "<TotalImpuesto></TotalImpuesto>" +
          "<TotalComprobante></TotalComprobante>" +
       "</ResumenFactura>" +
       "<Normativa>" +
          "<NumeroResolucion></NumeroResolucion>" +
          "<FechaResolucion></FechaResolucion>" +
       "</Normativa>" +
       "<Otros>" +
         "<OtroTexto/>" +
       "</Otros>" +
       "<ds:Signature xmlns:ds=\"http://www.w3.org/2000/09/xmldsig#\" Id=\"Signature-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\">" +
          "<ds:SignedInfo>" +
             "<ds:CanonicalizationMethod Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315\"/>" +
             "<ds:SignatureMethod Algorithm=\"http://www.w3.org/2001/04/xmldsig-more#rsa-sha256\"/>" +
             "<ds:Reference Id=\"Reference-6ee46894-f5d3-40d4-bf95-6b818ba9f736\" URI=\"\">" +
                "<ds:Transforms>" +
                   "<ds:Transform Algorithm=\"http://www.w3.org/2000/09/xmldsig#enveloped-signature\"/>" +
                "</ds:Transforms>" +
                "<ds:DigestMethod Algorithm=\"http://www.w3.org/2001/04/xmlenc#sha256\"/>" +
                "<ds:DigestValue/>" +
             "</ds:Reference>" +
             "<ds:Reference Id=\"ReferenceKeyInfo\" URI=\"#KeyInfoId-Signature-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\">" +
                "<ds:DigestMethod Algorithm=\"http://www.w3.org/2001/04/xmlenc#sha256\"/>" +
                "<ds:DigestValue/>" +
             "</ds:Reference>" +
             "<ds:Reference Type=\"http://uri.etsi.org/01903#SignedProperties\" URI=\"#SignedProperties-Signature-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\">" +
                "<ds:DigestMethod Algorithm=\"http://www.w3.org/2001/04/xmlenc#sha256\"/>" +
                "<ds:DigestValue/>" +
             "</ds:Reference>" +
          "</ds:SignedInfo>" +
          "<ds:SignatureValue Id=\"SignatureValue-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\"/>" +
          "<ds:KeyInfo Id=\"KeyInfoId-Signature-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\">" +
             "<ds:X509Data>" +
                "<ds:X509Certificate/>" +
             "</ds:X509Data>" +
             "<ds:KeyValue/>" +
          "</ds:KeyInfo>" +
          "<ds:Object Id=\"XadesObjectId-1fc7521f-203e-4fec-9266-11b4c7a2e51e\">" +
             "<xades:QualifyingProperties xmlns:xades=\"http://uri.etsi.org/01903/v1.3.2#\" Id=\"QualifyingProperties-f9b2eaf1-b962-448b-a11c-c58f4d4d9a94\" Target=\"#Signature-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\">" +
                "<xades:SignedProperties Id=\"SignedProperties-Signature-284529e0-d5fd-447d-a0a7-60d2cdbcbf30\">" +
                   "<xades:SignedSignatureProperties>" +
                      "<xades:SigningTime />" +
                      "<xades:SigningCertificate />" +
                      "<xades:SignaturePolicyIdentifier />" +
                   "</xades:SignedSignatureProperties>" +
                   "<xades:SignedDataObjectProperties>" +
                      "<xades:DataObjectFormat ObjectReference=\"#Reference-6ee46894-f5d3-40d4-bf95-6b818ba9f736\">" +
                         "<xades:MimeType>text/xml</xades:MimeType>" +
                         "<xades:Encoding>UTF-8</xades:Encoding>" +
                      "</xades:DataObjectFormat>" +
                   "</xades:SignedDataObjectProperties>" +
               "</xades:SignedProperties>" +
             "</xades:QualifyingProperties>" +
          "</ds:Object>" +
       "</ds:Signature>" +
       "</TiqueteElectronico>";
            return template;
        }

        public void initiate(XmlNode node)
        {
            root = node;
            current_node = node;
        }

        public void edit_node(String Data)
        {
            // Get the attributes of a book.        
            current_node.InnerText = Data;

        }
        public void edit_persona(Persona Data)
        {
            XmlElement bookElement = (XmlElement)current_node;
            //Get the attributes of a book.        
            bookElement["Nombre"].InnerText = Data.Nombre;
            bookElement["Identificacion"]["Tipo"].InnerText = Data.Ident_Tipo;
            bookElement["Identificacion"]["Numero"].InnerText = Data.Ident_Numero;
            bookElement["Ubicacion"]["Provincia"].InnerText = Data.Ubi_Provicia;
            bookElement["Ubicacion"]["Canton"].InnerText = Data.Ubi_Canton;
            bookElement["Ubicacion"]["Distrito"].InnerText = Data.Ubi_Distrito;
            bookElement["Ubicacion"]["OtrasSenas"].InnerText = Data.Ubi_OtrasSenas;
            bookElement["CorreoElectronico"].InnerText = Data.CorreoElectronico;
        }

        public void add_LineasFactura(DetalleServicio Servicio)
        {
            XmlElement bookElement = (XmlElement)current_node;
            XmlDocument doc = new XmlDocument();

            foreach (LineaDetalle Details in Servicio.LineasDetalle)
            {
                XmlNode root = doc.CreateElement("LineaDetalle", current_node.NamespaceURI);
                XmlNode NumLinea = doc.CreateElement("NumeroLinea", current_node.NamespaceURI);
                XmlNode Codigo = doc.CreateElement("Codigo", current_node.NamespaceURI);
                XmlNode Codigo_Tipo = doc.CreateElement("Tipo", current_node.NamespaceURI);
                XmlNode Codigo_Numero = doc.CreateElement("Codigo", current_node.NamespaceURI);
                XmlNode Cantidad = doc.CreateElement("Cantidad", current_node.NamespaceURI);
                XmlNode UnidadMedida = doc.CreateElement("UnidadMedida", current_node.NamespaceURI);
                XmlNode Detalle = doc.CreateElement("Detalle", current_node.NamespaceURI);
                XmlNode PrecioUnitario = doc.CreateElement("PrecioUnitario", current_node.NamespaceURI);
                XmlNode MontoTotal = doc.CreateElement("MontoTotal", current_node.NamespaceURI); 
                XmlNode Descuento = doc.CreateElement("MontoDescuento", current_node.NamespaceURI);
                XmlNode NaturalezaDescuento = doc.CreateElement("NaturalezaDescuento", current_node.NamespaceURI);
                XmlNode SubTotal = doc.CreateElement("SubTotal", current_node.NamespaceURI);

                

                XmlNode Impuesto = doc.CreateElement("Impuesto", current_node.NamespaceURI);
                    XmlNode Imp_Codigo = doc.CreateElement("Codigo", current_node.NamespaceURI);
                    XmlNode Imp_Tarifa = doc.CreateElement("Tarifa", current_node.NamespaceURI);
                    XmlNode Imp_Monto = doc.CreateElement("Monto", current_node.NamespaceURI);

                XmlNode MontoTotalLinea = doc.CreateElement("MontoTotalLinea", current_node.NamespaceURI);

                NumLinea.InnerText = Details.NumeroLinea;
                //Codigo estruct 
                Codigo_Tipo.InnerText = Details.Cod_Tipo;
                Codigo_Numero.InnerText = Details.Cod_Numero;

                Cantidad.InnerText = Details.Cantidad;
                UnidadMedida.InnerText = Details.UnidadMedida;
                Detalle.InnerText = Details.Detalle;
                PrecioUnitario.InnerText = Details.PrecioUnitario;
                MontoTotal.InnerText = Details.MontoTotal;
                SubTotal.InnerText = Details.Subtotal;

               

                MontoTotalLinea.InnerText = Details.MontoTotalLinea;

                root.AppendChild(NumLinea);
                Codigo.AppendChild(Codigo_Tipo);
                Codigo.AppendChild(Codigo_Numero);
                root.AppendChild(Codigo);
                root.AppendChild(Cantidad);
                root.AppendChild(UnidadMedida);
                root.AppendChild(Detalle);
                root.AppendChild(PrecioUnitario);
                root.AppendChild(MontoTotal);
                if (Convert.ToDouble(Details.Descuento) > 0)
                {
                    Descuento.InnerText = Details.Descuento;
                    NaturalezaDescuento.InnerText = "Descuento";
                    root.AppendChild(Descuento);
                    root.AppendChild(NaturalezaDescuento);
                }
                root.AppendChild(SubTotal);

                if (Convert.ToDouble(Details.Impuesto) > 0)
                {
                    //Impuesto estruct
                    Imp_Codigo.InnerText = "01";
                    Imp_Tarifa.InnerText = "13.00";
                    Imp_Monto.InnerText = Details.Impuesto; 

                    Impuesto.AppendChild(Imp_Codigo);
                    Impuesto.AppendChild(Imp_Tarifa);
                    Impuesto.AppendChild(Imp_Monto);
                    root.AppendChild(Impuesto);
                }
                
                root.AppendChild(MontoTotalLinea);

                XmlNode importNode = current_node.OwnerDocument.ImportNode(root, true);

                current_node.AppendChild(importNode);

            }

        }

        public void edit_ResumenFactura(ResumenFactura Data)
        {
            XmlElement bookElement = (XmlElement)current_node;
            //Get the attributes of a book.        
            bookElement["CodigoMoneda"].InnerText = Data.CodigoMoneda;
            bookElement["TipoCambio"].InnerText = Data.TipoCambio;
            bookElement["TotalMercanciasGravadas"].InnerText = Data.TotalMercanciasGravadas;
            bookElement["TotalMercanciasExentas"].InnerText = Data.TotalMercanciasExentas;
            bookElement["TotalGravado"].InnerText = Data.TotalGravado;
            bookElement["TotalExento"].InnerText = Data.TotalExcento;
            bookElement["TotalVenta"].InnerText = Data.TotalVenta;
            bookElement["TotalDescuentos"].InnerText = Data.TotalDescuento;
            bookElement["TotalVentaNeta"].InnerText = Data.TotalVentaNeta;
            bookElement["TotalImpuesto"].InnerText = Data.TotalImpuesto;
            bookElement["TotalComprobante"].InnerText = Data.TotalComprobante;
        }

        public string crear_factura(
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



            //Console.WriteLine(doc.DocumentElement.OuterXml);
        }

        public string crear_factura(
        String Llave,
        String NumeroConsecutivo,
        String FechaEmision,
        Persona Emisor,
        String CondicionVenta,
        String PlazoCredito,
        String MedioPago,
        DetalleServicio DetalleServicio,
        ResumenFactura ResumenFactura,
        String NumeroResol,
        String FechaResolucion)
        {

            XML xml_handler = new XML();
            string template = xml_handler.get_template_ticket();
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
