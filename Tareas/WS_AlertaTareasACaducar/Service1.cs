using Bus;
using Bus.General;
using Info;
using Info.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WS_AlertaTareasACaducar
{
    public partial class Service1 : ServiceBase
    {
        AlertaUsuario_Bus bus_alerta = new AlertaUsuario_Bus();
        public Service1()
        {
            InitializeComponent();
        }

        private void Tiempo_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var ListaUsuarios = bus_alerta.GetListUsuarios();
                string mensaje = "";
                foreach (var item in ListaUsuarios)
                {
                    EnviarCorreo(bus_alerta.GetListTareas(item.IdUsuario), "Alerta de tareas por caducar", item.correo, item.Cont ?? 0, ref mensaje);
                    bus_alerta.Guardar(new AlertaUsuario_Info
                    {
                        IdUsuario = item.IdUsuario,
                        MensajeCorreo = mensaje
                    });
                }
            }
            catch (Exception)
            {

            }
        }

        public void EnviarCorreo(List<AlertaUsuario_Info> Listado, string AsuntoCorreo, string correo, int Cont, ref string MensajeCorreo)
        {
            try
            {
                #region variables locales
                Parametro_Info infoParametros = new Parametro_Info();
                Parametro_Bus data = new Parametro_Bus();
                infoParametros = data.get_info();
                #endregion

                string[] correos = correo.Split(';');
                if (correos == null)
                    return;

                MailMessage mail = new MailMessage();
                foreach (var item in correos)
                {
                    if (!string.IsNullOrEmpty(item))
                        mail.To.Add(item);
                }
                if (mail.To.Count() == 0)
                    return;

                mail.From = new MailAddress(infoParametros.CorreoCuenta);
                mail.Subject = AsuntoCorreo;

                string Body = "Estimado compañero, <br/><br/>";
                Body += "<p>Estimado colaborador</p>";
                Body += "<p>Por medio de la presente se le notifica que posee "+Cont.ToString()+" tareas en curso que no han sido entregadas próximas a caducar:</p>";
                Body += "<table style = 'float: left;' border = '1' cellpadding = '5'>";
                Body += "<tbody>";
                Body += "<tr>";
                Body += "<td>";
                Body += "<h3><strong># Tarea</strong></h3>";
                Body += "</td>";
                Body += "<td>";
                Body += "<h3><strong> Asunto </strong></h3>";
                Body += "</td>";
                Body += "<td>";
                Body += "<h3><strong> Fecha de entrega</strong></h3>";
                Body += "</td>";
                Body += "<td>";
                Body += "<h3><strong> Horas restantes <br /></strong></h3>";
                Body += "</td>";
                Body += "</tr>";
                
                foreach (var item in Listado)
                {
                    Body += "<tr>";
                    Body += "<td>"+item.IdTarea.ToString()+"</td>";
                    Body += "<td>"+item.AsuntoTarea+"</td>";
                    Body += "<td>"+item.FechaEntrega.ToString("dd/MM/yyyy")+"</td>";
                    Body += "<td>"+Math.Round((Convert.ToDouble(item.MinutosCaducar)/60.00),2,MidpointRounding.AwayFromZero).ToString()+"</td>";
                    Body += "</tr>";
                }
                
                Body += "</tbody>";
                Body += "</table>";
                MensajeCorreo = Body;

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Body, null, "text/html");
                mail.AlternateViews.Add(htmlView);

                SmtpClient smtp = new SmtpClient();
                smtp.Host = infoParametros.Host;
                smtp.EnableSsl = infoParametros.PermitirSSL;
                smtp.Port = infoParametros.Puerto;
                smtp.Credentials = new NetworkCredential(infoParametros.CorreoCuenta, infoParametros.CorreoClave);
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MensajeCorreo = ex.Message;
            }
        }

        protected override void OnStart(string[] args)
        {
            Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(Tiempo_Elapsed);
            aTimer.Interval = TimeSpan.FromMinutes(5).TotalMilliseconds;
            aTimer.Enabled = true;
        }

        protected override void OnStop()
        {
        }
    }
}
