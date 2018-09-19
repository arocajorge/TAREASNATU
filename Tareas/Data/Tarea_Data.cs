using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Tarea_Data
    {
        public List< Tarea_Info> get_lis()
        {
            try
            {
                List< Tarea_Info> Lista = new List< Tarea_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.Tarea
                             select new  Tarea_Info
                             {
                                 IdTarea = q.IdTarea,
                                 IdUsuarioSolicitante=q.IdUsuarioSolicitante,
                                 IdGrupo=q.IdGrupo,
                                 IdUsuarioAsignado=q.IdUsuarioAsignado,
                                 EstadoActual=q.EstadoActual,
                                 FechaInicio=q.FechaInicio,
                                 FechaCulmina=q.FechaCulmina,
                                 Observacion=q.Observacion,
                                 IdEstadoPrioridad=q.IdEstadoPrioridad,
                                 IdTareaPadre=q.IdTareaPadre,
                                 TareaConcurrente=q.TareaConcurrente,
                                 Estado=q.Estado

                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool guardarDB( Tarea_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                     Tarea Entity = new  Tarea
                    {
                         IdTarea = info.IdTarea=get_id(),
                         IdUsuarioSolicitante = info.IdUsuarioSolicitante,
                         IdGrupo = info.IdGrupo,
                         IdUsuarioAsignado = info.IdUsuarioAsignado,
                         EstadoActual = info.EstadoActual,
                         FechaInicio = info.FechaInicio,
                         FechaCulmina = info.FechaCulmina,
                         Observacion = info.Observacion,
                         IdEstadoPrioridad = info.IdEstadoPrioridad,
                         IdTareaPadre = info.IdTareaPadre,
                         TareaConcurrente = info.TareaConcurrente,
                         FechaTransaccion=DateTime.Now,
                         IdUsuario=info.IdUsuario,
                         Estado=true
                     };
                    Context. Tarea.Add(Entity);
                    foreach (var item in info.list_detalle)
                    {
                        Tarea_det det = new Tarea_det
                        {
                            IdTarea = info.IdTarea,
                            Secuancial=item.Secuancial,
                            Descripcion=item.Descripcion,
                            OrdenEjecuacion=item.OrdenEjecuacion,
                            FechaInicio=item.FechaInicio,
                            FechaFin=item.FechaFin
                        
                        };
                        Context.Tarea_det.Add(det);
                    }
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public bool modificarDB( Tarea_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context. Tarea.Where(v => v.IdTarea == info.IdTarea).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.IdTareaPadre = info.IdTareaPadre;
                    Entity.IdUsuarioSolicitante = info.IdUsuarioSolicitante;
                    Entity.IdGrupo = info.IdGrupo;
                    Entity.IdUsuarioAsignado = info.IdUsuarioAsignado;
                    Entity.EstadoActual = info.EstadoActual;
                    Entity.FechaInicio = info.FechaInicio;
                    Entity.FechaCulmina = info.FechaCulmina;
                    Entity.Observacion = info.Observacion;
                    Entity.IdEstadoPrioridad = info.IdEstadoPrioridad;
                    Entity.TareaConcurrente = info.TareaConcurrente;
                    Entity.FechaModificacion = DateTime.Now;
                    Entity.IdUsuarioModifica = info.IdUsuarioModifica;

                    var resul = Context.Tarea_det.Where(v => v.IdTarea==info.IdTarea);
                    Context.Tarea_det.RemoveRange(resul);
                    foreach (var item in info.list_detalle)
                    {
                        Tarea_det det = new Tarea_det
                        {
                            IdTarea = info.IdTarea,
                            Secuancial = item.Secuancial,
                            Descripcion = item.Descripcion,
                            OrdenEjecuacion = item.OrdenEjecuacion,
                            FechaInicio = item.FechaInicio,
                            FechaFin = item.FechaFin

                        };
                        Context.Tarea_det.Add(det);
                    }

                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB( Tarea_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context. Tarea.Where(v => v.IdTarea == info.IdTarea).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.Estado = false;
                    Entity.IdUsuarioAnula = info.IdUsuarioAnula;
                    Entity.FechaAnulacion = DateTime.Now;
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public decimal get_id()
        {
            try
            {
                decimal ID = 1;
                using (EntityTareas Context = new EntityTareas())
                {
                    var lst = from q in Context. Tarea
                              select q;
                    if (lst.Count() > 0)
                        ID = lst.Max(q => q.IdTarea) + 1;
                }
                return ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  Tarea_Info get_info(decimal IdTarea)
        {
            try
            {
                 Tarea_Info info = new  Tarea_Info();
                using (EntityTareas Context = new EntityTareas())
                {
                     Tarea Entity = Context. Tarea.FirstOrDefault(q => q.IdTarea == IdTarea);
                    if (Entity == null) return null;

                    info = new  Tarea_Info
                    {
                        IdTarea = info.IdTarea,
                        IdUsuarioSolicitante = info.IdUsuarioSolicitante,
                        IdGrupo = info.IdGrupo,
                        IdUsuarioAsignado = info.IdUsuarioAsignado,
                        EstadoActual = info.EstadoActual,
                        FechaInicio = info.FechaInicio,
                        FechaCulmina = info.FechaCulmina,
                        Observacion = info.Observacion,
                        IdEstadoPrioridad = info.IdEstadoPrioridad,
                        IdTareaPadre = info.IdTareaPadre,
                        TareaConcurrente = info.TareaConcurrente,

                    };
                }
                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool EnviarCorreo(Tarea_Info item)
        {
            try
            {
                Usuario_Data odta_usuario = new Usuario_Data();
               var info_usuario = odta_usuario.get_info(item.IdUsuarioAsignado);
                int sec = 0;
                Parametro_Info infoParametros = new Parametro_Info();
                Parametro_Data data = new Parametro_Data();

                infoParametros = data.get_info();

                using (EntityTareas entity = new EntityTareas())
                {

                    sec++;
                    MailMessage mail = new MailMessage();
                    mail.To.Add(info_usuario.Correo);
                    mail.From = new MailAddress(info_usuario.Clave);

                    mail.Subject = "Evaluación de personal";

                    string Body = "Estimado colaborador <br/><br/>";
                    Body += "Degeremcia le encomienda la tarea:"+item.Observacion;
                    Body += "<br/>";
                    Body += "<br/>";
                    Body += "<table>";
                    Body += "<tr>";
                    Body += "<td><strong>Fecha inicio:</strong></td>";
                    Body += "<td><strong>" + item.FechaInicio.ToShortDateString() + "</strong></td>";
                    Body += "</tr>";
                    Body += "<tr>";
                    Body += "<td><strong>Fecha fin:</strong></td>";
                    Body += "<td><strong>" + item.FechaCulmina.ToShortDateString() + "</strong></td>";
                    Body += "</tr>";
                    Body += "</table>";
                    Body += "<br/>";
                    Body += "<br/>";
                    Body += "Para para acceder a la tarea acceder al link:<br/><br/>";
                   // Body += "<a href='http://evaluaciones.degeremcia.com/" + "Resolucion_formulario/LoginID?p1=" + item.IdEmpleado + "'>Encuestar colaboradores</a>";
                    Body += "<br/>";
                    Body += "<br/>";
                    Body += "<table>";
                    Body += "<tr>";
                    Body += "<td><strong>Usuario:</strong></td>";
                    Body += "<td>" + item.nomb_jef_grupo + "</td>";
                    Body += "</tr>";
                    Body += "<tr>";
                    Body += "<td><strong>Contraseña:</strong></td>";
                    Body += "<td>" + item.nomb_jef_grupo + "</td>";
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
