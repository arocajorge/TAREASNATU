using Info;
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
   public class Tarea_Data
    {
        Grupo_Usuario_Data data_usuarios_grup = new Grupo_Usuario_Data();
        Usuario_Data data_usuario = new Usuario_Data();
        TareaEstado_Data odta_estado = new TareaEstado_Data();
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
                int secuencia = 1;
                using (EntityTareas Context = new EntityTareas())
                {
                    #region tarea
                    Tarea Entity = new Tarea
                    {
                        IdTarea = info.IdTarea = get_id(),
                        IdUsuarioSolicitante = info.IdUsuarioSolicitante,
                        IdGrupo = info.IdGrupo,
                        IdUsuarioAsignado = info.IdUsuarioAsignado,
                        EstadoActual = info.EstadoActual,
                        FechaInicio = info.FechaInicio,
                        FechaCulmina = info.FechaCulmina,
                        Observacion = info.Observacion,
                        IdEstadoPrioridad = info.IdEstadoPrioridad,
                        TareaConcurrente = info.TareaConcurrente,
                        FechaTransaccion = DateTime.Now,
                        IdUsuario = info.IdUsuario,
                        Estado = true
                    };
                    Context.Tarea.Add(Entity);
                    #endregion

                    #region detalle
                    foreach (var item in info.list_detalle)
                    {
                        Tarea_det det = new Tarea_det
                        {
                            IdTarea = info.IdTarea,
                            Secuancial = item.Secuancial,
                            Descripcion = item.Descripcion,
                            OrdenEjecuacion = item.OrdenEjecuacion,
                            FechaInicio = item.FechaInicio,
                            FechaFin = item.FechaFin,
                            IdUsuario=item.IdUsuario,
                            FechaUltimaModif=DateTime.Now,
                            IdEstadoEstado=item.IdEstadoEstado,
                           

                        };
                        Context.Tarea_det.Add(det);
                    }
                    #endregion

                    #region adjuntos
                    foreach (var item in info.list_adjuntos)
                    {
                        TareaArchivoAdjunto det = new TareaArchivoAdjunto
                        {
                            IdTarea = info.IdTarea,
                            Secuencial = secuencia,
                            NombreArchivo = item.NombreArchivo,


                        };
                        secuencia++;
                        Context.TareaArchivoAdjunto.Add(det);
                    }
                    #endregion

                    #region Estado tarea
                    
                        TareaEstado New_estado = new TareaEstado
                        {
                            IdTarea = info.IdTarea,
                            Secuancial = odta_estado.get_id(info.IdTarea),
                            IdUsuario = info.IdUsuario,
                            Observacion=info.Observacion,
                            IdEstado=info.EstadoActual,
                            FechaModificacion=DateTime.Now,
                            IdUsuarioModifica=info.IdUsuario
                            

                        };
                        Context.TareaEstado.Add(New_estado);
                    
                    #endregion


                    Context.SaveChanges();
                }
               // EnviarCorreo(info);
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
                int secuencia = 0;
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context. Tarea.Where(v => v.IdTarea == info.IdTarea).FirstOrDefault();
                    if (Entity == null)
                        return false;
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

                    #region adjuntos
                    var resul_adjunto = Context.TareaArchivoAdjunto.Where(v => v.IdTarea == info.IdTarea);
                    Context.TareaArchivoAdjunto.RemoveRange(resul_adjunto);
                    foreach (var item in info.list_adjuntos)
                    {
                        TareaArchivoAdjunto det = new TareaArchivoAdjunto
                        {
                            IdTarea = info.IdTarea,
                            Secuencial = secuencia,
                            NombreArchivo = item.NombreArchivo,


                        };
                        secuencia++;
                        Context.TareaArchivoAdjunto.Add(det);
                    }
                    #endregion

                    #region Estado tarea

                    TareaEstado New_estado = new TareaEstado
                    {
                        IdTarea = info.IdTarea,
                        Secuancial = odta_estado.get_id(info.IdTarea),
                        IdUsuario = info.IdUsuario,
                        Observacion = info.Observacion,
                        IdEstado = info.EstadoActual,
                        FechaModificacion = DateTime.Now


                    };
                    Context.TareaEstado.Add(New_estado);

                    #endregion
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
                        IdTarea = Entity.IdTarea,
                        IdUsuarioSolicitante = Entity.IdUsuarioSolicitante,
                        IdGrupo = Entity.IdGrupo,
                        IdUsuarioAsignado = Entity.IdUsuarioAsignado,
                        EstadoActual = Entity.EstadoActual,
                        FechaInicio = Entity.FechaInicio,
                        FechaCulmina = Entity.FechaCulmina,
                        Observacion = Entity.Observacion,
                        IdEstadoPrioridad = Entity.IdEstadoPrioridad,
                        TareaConcurrente = Entity.TareaConcurrente,

                    };
                }
                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool EnviarCorreo(Tarea_Info info)
        {
            try
            {
                #region variables locales
                var inf_usu_dirigido = data_usuario.get_info(info.IdUsuarioAsignado);
                var lisr_usuarios_miembro_grup = data_usuarios_grup.get_lis_usuario_x_grupo(info.IdGrupo);
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
                   
                    mail.Subject = "Nueva tarea";
                    foreach (var item in lisr_usuarios_miembro_grup)
                    {
                        mail.CC.Add(item.Correo);
                    }
                    try
                    {
                        foreach (var item in info.list_adjuntos)
                        {
                            mail.Attachments.Add(new Attachment(new MemoryStream(item.tamanio_file), item.NombreArchivo));

                        }
                    }
                    catch (Exception)
                    {

                        
                    }
                    string Body = "Estimado colaborador <br/><br/>";
                    Body += "Degeremcia le encomienda la tarea: "+info.Observacion;
                    Body += "<br/>";
                    Body += "<br/>";
                    foreach (var item in info.list_detalle)
                    {
                        
                        Body += item.Descripcion+" Fecha inicio"+ info.FechaInicio.ToShortDateString()+"Fecha fin "+ info.FechaCulmina.ToShortDateString();
                        Body += "<br/>";
                    }
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
                   // Body += "<a href='http://evaluaciones.degeremcia.com/" + "Resolucion_formulario/LoginID?p1=" + item.IdEmpleado + "'>Encuestar colaboradores</a>";
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
                    smtp.EnableSsl = true;// infoParametros.PermitirSSL;
                    smtp.Port = infoParametros.Puerto;
                    smtp.Credentials = new NetworkCredential(infoParametros.CorreoCuenta, "xxxxxxx");
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
