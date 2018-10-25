using Data.General;
using Info;
using Info.Helps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Tarea_det_Data
    {
       
        public List<Tarea_det_Info> get_lis(decimal IdTarea, string IdUsuario)
        {
            try
            {
                List<Tarea_det_Info> Lista = new List<Tarea_det_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.Tarea_det
                             where q.IdTarea== IdTarea
                             && q.IdUsuario==IdUsuario
                             && q.IdEstado==8
                             orderby q.FechaFin ascending
                             select new Tarea_det_Info
                             {
                                 IdTarea = q.IdTarea,
                                 Secuancial = q.Secuancial,
                                 Descripcion=q.Descripcion,
                                 NumHoras=q.NumHoras,
                                 FechaInicio=q.FechaInicio,
                                 FechaFin=q.FechaFin,
                                 IdUsuario=q.IdUsuario,
                                 IdEstado=q.IdEstado
                                

                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Tarea_det_Info> get_lis(decimal IdTarea)
        {
            try
            {
                List<Tarea_det_Info> Lista = new List<Tarea_det_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.Tarea_det
                             where q.IdTarea == IdTarea
                            
                             select new Tarea_det_Info
                             {
                                 IdTarea = q.IdTarea,
                                 Secuancial = q.Secuancial,
                                 Descripcion = q.Descripcion,
                                 NumHoras = q.NumHoras,
                                 FechaInicio = q.FechaInicio,
                                 FechaFin = q.FechaFin,
                                 IdUsuario=q.IdUsuario,
                                 IdEstado=q.IdEstado


                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Tarea_det_Info> get_lis(decimal IdTarea, int Secuencial)
        {
            try
            {
                List<Tarea_det_Info> Lista = new List<Tarea_det_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.Tarea_det
                             where q.IdTarea == IdTarea
                             && q.Secuancial==Secuencial
                             select new Tarea_det_Info
                             {
                                 IdTarea = q.IdTarea,
                                 Secuancial = q.Secuancial,
                                 Descripcion = q.Descripcion,
                                 NumHoras = q.NumHoras,
                                 FechaInicio = q.FechaInicio,
                                 FechaFin = q.FechaFin,
                                 IdUsuario = q.IdUsuario,
                                 IdEstado = q.IdEstado


                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool cambiar_estado(Tarea_det_Info info)
        {
            try
            {
                Tarea_Data odata = new Tarea_Data();
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Tarea_det.Where(v => v.IdTarea == info.IdTarea && v.Secuancial== info.Secuancial).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.Observacion = info.Observacion;
                    Entity.FechaTerminoTarea = DateTime.Now;
                    Entity.IdEstado = info.IdEstado;
                    Context.SaveChanges();
                    var tarea = odata.get_info(info.IdTarea);
                    tarea.list_detalle.AddRange(get_lis(info.IdTarea,info.Secuancial));
                    EnviarCorreo(tarea,"Subtarea cerrada", cl_enumeradores.eCorreo.ENCARGADO);
                    return true;
                }
                }
            catch (Exception)
            {
            
                throw;
            }
        }


        public bool EnviarCorreo(Tarea_Info info, string AsuntoCorreo, cl_enumeradores.eCorreo EnviarA)
        {
            try
            {
                Usuario_Data data_usuario = new Usuario_Data();

                #region variables locales
                var inf_usu_dirigido = data_usuario.get_info(EnviarA == cl_enumeradores.eCorreo.ENCARGADO ? info.IdUsuarioAsignado : info.IdUsuarioSolicitante);
                int sec = 0;
                Parametro_Info infoParametros = new Parametro_Info();
                Parametro_Data data = new Parametro_Data();
                infoParametros = data.get_info();
                #endregion

                using (EntityTareas entity = new EntityTareas())
                {

                    sec++;
                    MailMessage mail = new MailMessage();

                    mail.To.Add(inf_usu_dirigido.Correo);
                    mail.From = new MailAddress(infoParametros.CorreoCuenta);

                    mail.Subject = AsuntoCorreo;

                   
                    string Body = "Estimado compañero, <br/><br/>";
                    Body += info.Saludo + ":";
                    Body += "<br/>";
                    Body += "<br/>";
                    Body += "<td><strong>Asunto de la tarea:</strong></td>";
                    Body += "<br/>";
                    Body += info.AsuntoTarea;
                    Body += "<br/>";
                    Body += "<br/>";
                    //Body += "Descripción tarea: ";
                    Body += "<td><strong>Descripción de la tarea</strong></td>";
                    Body += "<br/>";
                    Body += info.DescripcionTarea;
                    Body += "<br/>";
                    Body += "<br/>";
                    if (info.list_detalle.Count > 0)
                    {
                        // Body += "Detalle de distribución de la tarea:";
                        Body += "<td><strong>Detalle de la distribución de la tarea:</strong></td>";

                        Body += "<br/>";

                        foreach (var item in info.list_detalle)
                        {

                            Body += item.Descripcion + " Fecha inicio " + info.FechaInicio.ToShortDateString() + " Fecha fin " + info.FechaCulmina.ToShortDateString();
                            Body += "<br/>";
                        }
                        Body += "<br/>";
                        Body += "<br/>";
                    }
                    // Body += "Observaciones: ";
                    Body += "<td><strong>Observaciones:</strong></td>";

                    Body += "<br/>";
                    Body += info.ObsevacionModificacion;
                    Body += "<table>";
                    Body += "<tr>";
                    Body += "<td><strong>Fecha inicio:</strong></td>";
                    Body += "<td><strong>" + info.FechaInicio.ToShortDateString() + "</strong></td>";
                    Body += "</tr>";
                    Body += "<tr>";
                    Body += "<td><strong>Fecha fin:</strong></td>";
                    Body += "<td><strong>" + info.FechaCulmina.ToShortDateString() + "</strong></td>";
                    Body += "</tr>";
                    Body += "</table>";
                    Body += "<br/>";
                    Body += "<br/>";
                    Body += "Para para acceder a la tarea acceder al link:<br/><br/>";
                    Body += "<a href='http://tareas.degeremcia.com/General/" + info.Controller + "/" + info.Accion + "?IdTarea=" + info.IdTarea + "'>Tareas</a>";

                    Body += "<br/>";
                    Body += "<br/>";
                    Body += "<table>";
                    Body += "<tr>";
                    Body += "</tr>";
                    Body += "</table>";


                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Body, null, "text/html");
                    mail.AlternateViews.Add(htmlView);

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = infoParametros.Host;
                    smtp.EnableSsl = infoParametros.PermitirSSL;
                    smtp.Port = infoParametros.Puerto;
                    smtp.Credentials = new NetworkCredential(infoParametros.CorreoCuenta, infoParametros.CorreoClave);
                    smtp.Send(mail);


                    entity.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
