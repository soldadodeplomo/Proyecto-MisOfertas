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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibreriaMisOfertas
{
    public class administrarOfertasPorCorreo
    {
        CertificadoDescuento cert = new CertificadoDescuento();
        public void enviarCorreoOferta(Consumidor cons)
        {
            if (cons.recibirOferta == 's')
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
                    mensaje.Body = listarOfertasCorreo();
                    smtp.Send(mensaje);
                }
            }
        }
        public Random rnd = new Random();
        public Document generarPDF(Consumidor t)
        {
            Document doc = new Document(PageSize.LETTER);
            if (File.Exists(@"C:\Users\nicolas\Documents\Visual Studio 2015\Projects\webMisOfertasResponsiveWork\webMisOfertasResponsive\webMisOfertasResponsive\tempDocs\cupon_descuento_1_" + t.runConsumidor + ".pdf"))
            {
                File.Delete(@"C:\Users\nicolas\Documents\Visual Studio 2015\Projects\webMisOfertasResponsiveWork\webMisOfertasResponsive\webMisOfertasResponsive\tempDocs\cupon_descuento_1_" + t.runConsumidor + ".pdf");
            }

            generarCodigoBarras(t);

            int random;
            random = rnd.Next(1, 1000000);
            administracionPuntosAcumulados puntosAcumulados = new administracionPuntosAcumulados();

            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\nicolas\Documents\Visual Studio 2015\Projects\webMisOfertasResponsiveWork\webMisOfertasResponsive\webMisOfertasResponsive\tempDocs\cupon_descuento_1_" + t.runConsumidor + ".pdf", FileMode.OpenOrCreate));
            doc.Open();

            puntosAcumulados.obtenerTodoPDF(cert, t);
            PdfPTable table = new PdfPTable(1);

            var logo = iTextSharp.text.Image.GetInstance(@"C:\Users\nicolas\Documents\Visual Studio 2015\Projects\webMisOfertasResponsiveWork\webMisOfertasResponsive\webMisOfertasResponsive\imagenes\test.png");
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

            var barra = iTextSharp.text.Image.GetInstance(@"C:\Users\nicolas\Documents\Visual Studio 2015\Projects\webMisOfertasResponsiveWork\webMisOfertasResponsive\webMisOfertasResponsive\tempDocs\barcode" + t.runConsumidor + ".png");
            var b = new PdfPCell(barra, true);
            c.Border = 0;
            c.VerticalAlignment = Element.ALIGN_TOP;
            c.HorizontalAlignment = Element.ALIGN_MIDDLE;

            table.AddCell(c);
            table.AddCell(b);
            doc.Add(table);
            doc.Close();
            doc.Dispose();
            return doc;
        }

        public void generarCodigoBarras(Consumidor t)
        {
            //Toma el RUN del consumidor guardado en la sesion del consumidor, con el cual se generara el código de barras para el PDF
            string code = t.runConsumidor;
            Barcode39 barcodeImg = new Barcode39();
            barcodeImg.Code = code.ToString();
            barcodeImg.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White).Save(@"C:\Users\nicolas\Documents\Visual Studio 2015\Projects\webMisOfertasResponsiveWork\webMisOfertasResponsive\webMisOfertasResponsive\tempDocs\barcode" + t.runConsumidor + ".png", System.Drawing.Imaging.ImageFormat.Png);

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
                cmd.Parameters.Add("idCons", OracleDbType.Int32, cons.idConsumidor, System.Data.ParameterDirection.Input);
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

        public string mensajeConsumidor = "";

        public StringBuilder listarOfertasPorRubro(PlaceHolder place)
        {
            StringBuilder consulta = new StringBuilder();
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            connection.Open();
            //OracleCommand cmd = new OracleCommand("select a.precio_oferta, a.fecha_inicio, a.fecha_termino, b.sku, b.marca || ' ' || b.nombre_producto, b.precio_producto, b.imagen_producto, d.descripcion_tipo_oferta, b.nombre_producto from misofertasdb.oferta a, misofertasdb.producto b, misofertasdb.detofertaproducto c, misofertasdb.tipooferta d, misofertasdb.experienciaconsumidor e where a.id_oferta=c.id_oferta and b.sku=c.sku and a.id_tipo_oferta=d.id_tipo_oferta and a.id_rubro=e.id_rubro order by e.id_rubro", connection);
            OracleCommand cmd = new OracleCommand("select a.precio_oferta, to_char(a.fecha_inicio,'dd/mm/yyyy'), to_char(a.fecha_termino,'dd/mm/yyyy'), b.sku, b.marca || ' ' || b.nombre_producto, b.precio_producto, b.imagen_producto, d.descripcion_tipo_oferta, b.nombre_producto from misofertasdb.oferta a, misofertasdb.producto b, misofertasdb.detofertaproducto c, misofertasdb.tipooferta d, misofertasdb.experienciaconsumidor e where a.id_oferta=c.id_oferta and b.sku=c.sku and a.id_tipo_oferta=d.id_tipo_oferta and a.id_rubro=e.id_rubro order by e.id_rubro", connection);
            OracleDataReader reader = cmd.ExecuteReader();
            //<asp:Image ID="Image2" runat="server" />
            consulta.Append("<div class='table-responsive'><table border='0' class='table table-striped' style='text-align='center;'>");
            consulta.Append("<tr></tr>");
            consulta.Append("</tr>");

            string carne = "<img src='/imagenes/carne_molida.jpg' height='50px' weight='50px'>";
            string cristal = "<img src='/imagenes/cristal.jpg' height='50px' weight='50px'>";
            string heineken = "<img src='/imagenes/heineken.jpg' height='50px' weight='50px'>";
            string k10 = "<img src='/imagenes/k10.jpg' height='50px' weight='50px'>";
            string lavadora = "<img src='/imagenes/lavadora.jpg' height='50px' weight='50px'>";
            string lenovo = "<img src='/imagenes/lenovo_g4080.png' height='200px' weight='200px'>";
            string pantalon_hombre = "<img src='/imagenes/pantalon_hombre.jpg' height='200px' weight='200px'>";
            string powerade = "<img src='/imagenes/powerade.png' height='50px' weight='50px'>";
            string s9 = "<img src='/imagenes/s9.png' height='200px' weight='200px'>";

            consulta.Append("<tr>");
            if (reader.Read())
            {
                if (reader[8].ToString() != "Lee Pantalon de hombre café XL")
                {
                    consulta.Append("<td>" + pantalon_hombre + "<br>" + reader[4] + "<br>" + reader[7] + " en " + reader[0] + "<br>" + "Precio referencia: $" + reader[5] + "<br>" + "Oferta disponible desde el " + reader[1] + " hasta el " + reader[2] + "</td>");
                }
            }
            if (reader.Read())
            {
                if (reader[8].ToString() != "Lenovo G4080 I7-5500k 4GB RAM DDR3 1TB HDD")
                {
                    consulta.Append("<td>" + lenovo + "<br>" + reader[4] + "<br>" + reader[7] + " en " + reader[0] + "<br>" + "Precio referencia: $" + reader[5] + "<br>" + "Oferta disponible desde el " + reader[1] + " hasta el " + reader[2] + "</td>");
                }
            }
            if (reader.Read())
            {
                if (reader[8].ToString() != "Samsumg Galaxy S9 Plus 128GB USB Tipo C")
                {
                    consulta.Append("<td>" + s9 + "<br>" + reader[4] + "<br>" + reader[7] + " en " + reader[0] + "<br>" + "Precio referencia: $" + reader[5] + "<br>" + "Oferta disponible desde el " + reader[1] + " hasta el " + reader[2] + "</td>");
                }
            }
            consulta.Append("</tr>");
            consulta.Append("</table></div>");
            place.Controls.Add(new Literal { Text = consulta.ToString() });
            reader.Close();

            return consulta;
        }
        public string listarOfertasCorreo()
        {
            StringBuilder consulta = new StringBuilder();
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            connection.Open();

            //OracleCommand cmd = new OracleCommand("select a.precio_oferta, a.fecha_inicio, a.fecha_termino, b.sku, b.marca || ' ' || b.nombre_producto, b.precio_producto, b.imagen_producto, d.descripcion_tipo_oferta, b.nombre_producto from misofertasdb.oferta a, misofertasdb.producto b, misofertasdb.detofertaproducto c, misofertasdb.tipooferta d, misofertasdb.experienciaconsumidor e where a.id_oferta=c.id_oferta and b.sku=c.sku and a.id_tipo_oferta=d.id_tipo_oferta and a.id_rubro=e.id_rubro order by e.id_rubro", connection);
            OracleCommand cmd = new OracleCommand("select a.precio_oferta, to_char(a.fecha_inicio,'dd/mm/yyyy'), to_char(a.fecha_termino,'dd/mm/yyyy'), b.sku, b.marca || ' ' || b.nombre_producto, b.precio_producto, b.imagen_producto, d.descripcion_tipo_oferta, b.nombre_producto from misofertasdb.oferta a, misofertasdb.producto b, misofertasdb.detofertaproducto c, misofertasdb.tipooferta d, misofertasdb.experienciaconsumidor e where a.id_oferta=c.id_oferta and b.sku=c.sku and a.id_tipo_oferta=d.id_tipo_oferta and a.id_rubro=e.id_rubro order by e.id_rubro", connection);
            OracleDataReader reader = cmd.ExecuteReader();
            //<asp:Image ID="Image2" runat="server" />
            consulta.Append("<div class='table-responsive'><table border='0' class='table table-striped' style='text-align='center;'>");
            consulta.Append("<tr></tr>");
            consulta.Append("</tr>");

            string carne = "<img src='/imagenes/carne_molida.jpg' height='50px' weight='50px'>";
            string cristal = "<img src='/imagenes/cristal.jpg' height='50px' weight='50px'>";
            string heineken = "<img src='/imagenes/heineken.jpg' height='50px' weight='50px'>";
            string k10 = "<img src='/imagenes/k10.jpg' height='50px' weight='50px'>";
            string lavadora = "<img src='/imagenes/lavadora.jpg' height='50px' weight='50px'>";
            string lenovo = "<img src='/imagenes/lenovo_g4080.png' height='200px' weight='200px'>";
            string pantalon_hombre = "<img src='/imagenes/pantalon_hombre.jpg' height='200px' weight='200px'>";
            string powerade = "<img src='/imagenes/powerade.png' height='50px' weight='50px'>";
            string s9 = "<img src='/imagenes/s9.png' height='200px' weight='200px'>";

            consulta.Append("<tr>");
            try
            {
                if (reader.Read())
                {
                    if (reader[8].ToString() != "Lee Pantalon de hombre café XL")
                    {
                        consulta.Append("<td>" + pantalon_hombre + "<br>" + reader[4] + "<br>" + reader[7] + " en " + reader[0] + "<br>" + "Precio referencia: $" + reader[5] + "<br>" + "Oferta disponible desde el " + reader[1] + " hasta el " + reader[2] + "</td>");
                    }
                }
                if (reader.Read())
                {
                    if (reader[8].ToString() != "Lenovo G4080 I7-5500k 4GB RAM DDR3 1TB HDD")
                    {
                        consulta.Append("<td>" + lenovo + "<br>" + reader[4] + "<br>" + reader[7] + " en " + reader[0] + "<br>" + "Precio referencia: $" + reader[5] + "<br>" + "Oferta disponible desde el " + reader[1] + " hasta el " + reader[2] + "</td>");
                    }
                }
                if (reader.Read())
                {
                    if (reader[8].ToString() != "Samsumg Galaxy S9 Plus 128GB USB Tipo C")
                    {
                        consulta.Append("<td>" + s9 + "<br>" + reader[4] + "<br>" + reader[7] + " en " + reader[0] + "<br>" + "Precio referencia: $" + reader[5] + "<br>" + "Oferta disponible desde el " + reader[1] + " hasta el " + reader[2] + "</td>");
                    }
                }
                consulta.Append("</tr>");
                consulta.Append("</table></div>");
                reader.Close();
            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }
            return consulta.ToString();
        }

        public int suma = 0;

        public bool ifValoraciones(Consumidor c)
        {
            conexionOracle oracle = new conexionOracle();
            OracleConnection connection = new OracleConnection(oracle.getConnectionString);
            connection.Open();
            OracleCommand cmd = new OracleCommand("select count(id_experiencia_usuario), id_consumidor from misofertasdb.experienciaconsumidor where id_consumidor =:id and rut_consumidor =:rut and correo_consumidor =:correo group by id_consumidor",connection);
            cmd.Parameters.Add(":id",c.idConsumidor);
            cmd.Parameters.Add(":rut",c.runConsumidor);
            cmd.Parameters.Add(":correo",c.correoConsumidor);
            OracleDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                if(Convert.ToInt32(reader[0])==suma)
                {
                    reader.Close();
                    connection.Close();
                    return false;
                }else
                {
                    reader.Close();
                    connection.Close();
                    return true;
                }
            }
            else
            {
                mensajeConsumidor = "¡Valoriza ofertas o compras para recibir ofertas personalizadas!";
                reader.Close();
                connection.Close();
                return false;
            }
        }
    }
}
