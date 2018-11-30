using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using DatosMisOfertas;
using BarcodeLib;
using System.Drawing;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using Oracle.DataAccess.Client;
using LibreriaMisOfertas;

namespace LibreriaMisOfertas
{
    public class administrarOfertasPorCorreo
    {
        CertificadoDescuento cert = new CertificadoDescuento();
        public void enviarCorreoOferta(Consumidor cons)
        {
            var from = new MailAddress("misofertaswebcontact@gmail.com", "Mis Ofertas Bot");
            var to = new MailAddress(cons.correoConsumidor, cons.nombreConsumidor);              
            const string pass = "hods6bf8";
            const string subject = "Prueba de envio de correo";
            const string body = "ESTO ES UNA PRUEBA DE CORREO DESDE C#";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(from.Address, pass)
                };
                using (var mensaje = new MailMessage(from, to))
                {
                    mensaje.Subject = subject;
                    mensaje.Body = body;
                    smtp.Send(mensaje);
                }                        
            }
        public Random rnd = new Random();
        public Document generarPDF(Consumidor t)
        {
            generarCodigoBarras(t);

            int random;
            random = rnd.Next(1, 1000000);
            administracionPuntosAcumulados puntosAcumulados = new administracionPuntosAcumulados();

            Document doc = new Document(PageSize.LETTER);

            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\nicolas\Documents\Visual Studio 2015\Projects\webMisOfertasResponsive\webMisOfertasResponsive\tempDocs\cupon_descuento_1_" + t.runConsumidor+ ".pdf", FileMode.OpenOrCreate));
            doc.Open();

            puntosAcumulados.obtenerTodoPDF(cert, t);
            PdfPTable table = new PdfPTable(1);

            var logo = iTextSharp.text.Image.GetInstance(@"C:\Users\nicolas\Documents\Visual Studio 2015\Projects\webMisOfertasResponsive\webMisOfertasResponsive\imagenes\test.png");
            logo.ScaleToFit(150, 30);
            var c = new PdfPCell(logo, true);

            iTextSharp.text.Paragraph titulo = new Paragraph("Descarga este cupón para utilizarlo en nuestras tiendas");
            titulo.Alignment = 1;

            Paragraph nombreConsumidor = new Paragraph("Nombre consumidor: " + t.nombreConsumidor);
            Paragraph rutConsumidor = new Paragraph("R.U.N consumidor: " + t.runConsumidor);
            Paragraph correoConsumidor = new Paragraph("Correo consumidor: " + t.correoConsumidor);
            Paragraph idCertificado = new Paragraph("ID certificado: " + cert.idCertificado);
            Paragraph puntosTotales = new Paragraph("Puntos disponibles: " + cert.puntosDescuentos);
            Paragraph topeCompra = new Paragraph("Tope de compra: $" + cert.topeDinero);
            Paragraph porcentaje = new Paragraph("Porcentaje descuento: " + cert.porcentaje + "%");
            Paragraph rubroCompra = new Paragraph("Rubro compra disponible/s: " + cert.rubro);

            doc.Add(titulo);
            doc.Add(Chunk.NEWLINE);

            doc.Add(nombreConsumidor);
            doc.Add(rutConsumidor);
            doc.Add(correoConsumidor);
            doc.Add(idCertificado);
            doc.Add(puntosTotales);
            doc.Add(topeCompra);
            doc.Add(porcentaje);
            doc.Add(rubroCompra);

            var barra = iTextSharp.text.Image.GetInstance(@"C:\Users\nicolas\Documents\Visual Studio 2015\Projects\webMisOfertasResponsive\webMisOfertasResponsive\tempDocs\barcode" + t.runConsumidor + ".png");
            var b = new PdfPCell(barra, true);
            c.Border = 0;
            c.VerticalAlignment = Element.ALIGN_TOP;
            c.HorizontalAlignment = Element.ALIGN_MIDDLE;

            table.AddCell(c);
            table.AddCell(b);
            doc.Add(table);
            doc.Close();
            return doc;
        }

        public void generarCodigoBarras(Consumidor t)
        {
            //Toma el RUN del consumidor guardado en la sesion del consumidor, con el cual se generara el código de barras para el PDF
            string code = t.runConsumidor;
            Barcode39 barcodeImg = new Barcode39();
            barcodeImg.Code = code.ToString();
            barcodeImg.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White).Save(@"C:\Users\nicolas\Documents\Visual Studio 2015\Projects\webMisOfertasResponsive\webMisOfertasResponsive\tempDocs\barcode" + t.runConsumidor + ".png", System.Drawing.Imaging.ImageFormat.Png);
        }

        public void insertarBitacora(Consumidor cons)
        {
            conexionOracle oracle = new conexionOracle();
            OracleConnection connecion = new OracleConnection(oracle.getConnectionString);
            try
            {
                connecion.Open();
                OracleCommand cmd = new OracleCommand("misOfertasDB.insertarBitacora", connecion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("rutCons", OracleDbType.Varchar2, cons.runConsumidor, System.Data.ParameterDirection.Input);
                cmd.Parameters.Add("correoCons", OracleDbType.Varchar2, cons.correoConsumidor, System.Data.ParameterDirection.Input);
                cmd.ExecuteNonQuery();
                connecion.Close();
            } 
            catch (OracleException ex)
            {
                string mensaje = ex.Message;
                connecion.Close();
            }
        }
    }
}
