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
using Data.General;
namespace Data
{
   public class Tarea_Data
    {
        #region variables
        Grupo_Usuario_Data data_usuarios_grup = new Grupo_Usuario_Data();
        Usuario_Data data_usuario = new Usuario_Data();
        TareaEstado_Data odta_estado = new TareaEstado_Data();
        Parametro_Info info_parametro = new Parametro_Info();
        Parametro_Data data_parametro = new Parametro_Data();
        Usuario_Data usuario_data = new Usuario_Data();
        #endregion
        public List<Tarea_Info> get_lis_cargar_combo()
        {
            try
            {
                List<Tarea_Info> Lista = new List<Tarea_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.vw_Tarea

                             select new Tarea_Info
                             {
                                 IdTarea = q.IdTarea,
                                 AsuntoTarea=q.AsuntoTarea
                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List< Tarea_Info> get_lis(DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                FechaInicio = Convert.ToDateTime(FechaInicio.ToShortDateString());
                FechaFin = Convert.ToDateTime(FechaFin.ToShortDateString());

                List< Tarea_Info> Lista = new List< Tarea_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.vw_Tarea
                             where q.FechaEntrega >= FechaInicio


                             select new  Tarea_Info
                             {
                                 IdTarea = q.IdTarea,
                                 IdUsuarioSolicitante=q.IdUsuarioSolicitante,
                                 IdGrupo=q.IdGrupo,
                                 IdUsuarioAsignado=q.IdUsuarioAsignado,
                                 EstadoActual=q.EstadoActual,
                                 FechaEntrega=q.FechaEntrega,
                                 AsuntoTarea=q.AsuntoTarea,
                                 DescripcionTarea=q.DescripcionTarea,
                                 IdEstadoPrioridad=q.IdEstadoPrioridad,
                                 TareaConcurrente=q.TareaConcurrente,
                                 Estado=q.Estado,
                                 AprobadoSolicitado=q.AprobadoSolicitado,
                                 AprobadoEncargado=q.AprobadoEncargado,
                                 DiasIntervaloProximaTarea=q.DiasIntervaloProximaTarea,
                                 FechaFinConcurrencia=q.FechaFinConcurrencia,

                                 solicitante=q.solicitante,
                                 Asignado=q.Asignado,
                                 Prioridad=q.Prioridad,
                                 EstadoTarea=q.EstadoTarea,
                                 NombreGrupo=q.NombreGrupo,
                                 FechaCierreEncargado=q.FechaCierreEncargado,
                                 FechaCierreSolicitante=q.FechaCierreSolicitante
                                 

                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Tarea_Info> get_lis_anulados(string IdUsuarioSolicitante, DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                FechaInicio = Convert.ToDateTime(FechaInicio.ToShortDateString());
                FechaFin = Convert.ToDateTime(FechaFin.ToShortDateString());

                List<Tarea_Info> Lista = new List<Tarea_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.vw_Tarea
                             where q.FechaEntrega >= FechaInicio
                             && q.Estado==false
                             && q.IdUsuarioSolicitante== IdUsuarioSolicitante
                             select new Tarea_Info
                             {
                                 IdTarea = q.IdTarea,
                                 IdUsuarioSolicitante = q.IdUsuarioSolicitante,
                                 IdGrupo = q.IdGrupo,
                                 IdUsuarioAsignado = q.IdUsuarioAsignado,
                                 EstadoActual = q.EstadoActual,
                                 FechaEntrega = q.FechaEntrega,
                                 AsuntoTarea = q.AsuntoTarea,
                                 DescripcionTarea = q.DescripcionTarea,
                                 IdEstadoPrioridad = q.IdEstadoPrioridad,
                                 TareaConcurrente = q.TareaConcurrente,
                                 Estado = q.Estado,
                                 AprobadoSolicitado = q.AprobadoSolicitado,
                                 AprobadoEncargado = q.AprobadoEncargado,
                                 DiasIntervaloProximaTarea = q.DiasIntervaloProximaTarea,
                                 FechaFinConcurrencia = q.FechaFinConcurrencia,

                                 solicitante = q.solicitante,
                                 Asignado = q.Asignado,
                                 Prioridad = q.Prioridad,
                                 EstadoTarea = q.EstadoTarea,
                                 NombreGrupo = q.NombreGrupo,
                                 FechaCierreEncargado = q.FechaCierreEncargado,
                                 FechaCierreSolicitante = q.FechaCierreSolicitante


                             }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Tarea_Info> get_lis(string IdUsuario,  cl_enumeradores.eTipoTarea Tipo, DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                FechaInicio = Convert.ToDateTime(FechaInicio.ToShortDateString());
                FechaFin = Convert.ToDateTime(FechaFin.ToShortDateString());
                List<Tarea_Info> Lista = new List<Tarea_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    if(Tipo==cl_enumeradores.eTipoTarea.ASIGNADA)// se muestra en bizon de entrada
                        Lista = (from q in Context.vw_Tarea
                                 where q.IdUsuarioAsignado == IdUsuario
                                 && q.EstadoActual != 5//Diferente de devuelta
                                 && q.FechaEntrega >= FechaInicio
                               && q.FechaEntrega <= FechaFin
                               && q.Estado==true
                                 select new Tarea_Info
                             {
                                 IdTarea = q.IdTarea,
                                 IdUsuarioSolicitante = q.IdUsuarioSolicitante,
                                 IdGrupo = q.IdGrupo,
                                 IdUsuarioAsignado = q.IdUsuarioAsignado,
                                 EstadoActual = q.EstadoActual,
                                 FechaEntrega = q.FechaEntrega,
                                 AsuntoTarea = q.AsuntoTarea,
                                 DescripcionTarea = q.DescripcionTarea,
                                 IdEstadoPrioridad = q.IdEstadoPrioridad,
                                 TareaConcurrente = q.TareaConcurrente,
                                 Estado = q.Estado,
                                 AprobadoEncargado=q.AprobadoEncargado,
                                 AprobadoSolicitado=q.AprobadoSolicitado,

                                 solicitante = q.solicitante,
                                 Asignado = q.Asignado,
                                 Prioridad = q.Prioridad,
                                 EstadoTarea = q.EstadoTarea,
                                 NombreGrupo = q.NombreGrupo,
                                 FechaCierreSolicitante = q.FechaCierreSolicitante,
                                 FechaCierreEncargado=q.FechaCierreEncargado,
                                 NumSubtarea=q.NumSubtarea,
                                 NumSubtareasAbiertas=q.NumSubtareasAbiertas,
                                EstadoCumplimiento = q.EstadoCumplimiento




                                 }).ToList();
                    else// se muestra en buzon de salida
                        Lista = (from q in Context.vw_Tarea
                                 where q.IdUsuarioSolicitante == IdUsuario
                               && q.FechaEntrega >= FechaInicio
                               && q.FechaEntrega <= FechaFin
                               && q.Estado==true
                                 select new Tarea_Info
                                 {
                                     IdTarea = q.IdTarea,
                                     IdUsuarioSolicitante = q.IdUsuarioSolicitante,
                                     IdGrupo = q.IdGrupo,
                                     IdUsuarioAsignado = q.IdUsuarioAsignado,
                                     EstadoActual = q.EstadoActual,
                                     FechaEntrega = q.FechaEntrega,
                                     AsuntoTarea = q.AsuntoTarea,
                                     DescripcionTarea = q.DescripcionTarea,
                                     IdEstadoPrioridad = q.IdEstadoPrioridad,
                                     TareaConcurrente = q.TareaConcurrente,
                                     Estado = q.Estado,
                                     AprobadoEncargado = q.AprobadoEncargado,
                                     AprobadoSolicitado = q.AprobadoSolicitado,

                                     solicitante = q.solicitante,
                                     Asignado = q.Asignado,
                                     Prioridad = q.Prioridad,
                                     EstadoTarea = q.EstadoTarea,
                                     NombreGrupo = q.NombreGrupo,
                                     FechaCierreSolicitante = q.FechaCierreSolicitante,
                                     FechaCierreEncargado = q.FechaCierreEncargado,
                                     NumSubtarea = q.NumSubtarea,
                                     NumSubtareasAbiertas = q.NumSubtareasAbiertas,
                                     EstadoCumplimiento=q.EstadoCumplimiento




                                 }).ToList();
                }

                return Lista;

                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Tarea_Info> get_lis_x_aprobar(string IdUsuario)
        {
            try
            {
                List<Tarea_Info> Lista = new List<Tarea_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                        Lista = (from q in Context.sp_tareas_por_aprobar(IdUsuario)
                                 where 
                                    q.Estado == true
                                 select new Tarea_Info
                                 {
                                     IdTarea = q.IdTarea,
                                     IdUsuarioSolicitante = q.IdUsuarioSolicitante,
                                     IdGrupo = q.IdGrupo,
                                     IdUsuarioAsignado = q.IdUsuarioAsignado,
                                     EstadoActual = q.EstadoActual,
                                     FechaEntrega = q.FechaEntrega,
                                     AsuntoTarea = q.AsuntoTarea,
                                     DescripcionTarea = q.DescripcionTarea,
                                     IdEstadoPrioridad = q.IdEstadoPrioridad,
                                     TareaConcurrente = q.TareaConcurrente,
                                     Estado = q.Estado,
                                     AprobadoEncargado = q.AprobadoEncargado,
                                     AprobadoSolicitado = q.AprobadoSolicitado,

                                     solicitante = q.solicitante,
                                     Asignado = q.Asignado,
                                     Prioridad = q.Prioridad,
                                     EstadoTarea = q.EstadoTarea,
                                     NombreGrupo = q.NombreGrupo,
                                     FechaCierreSolicitante = q.FechaCierreSolicitante,
                                     FechaCierreEncargado = q.FechaCierreEncargado,
                                     NumSubtarea = q.NumSubtarea,
                                     Buzon=q.Buzon



                                 }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Tarea_Info> get_lis_asignar_subtareas(string IdUsuario, cl_enumeradores.eTipoTarea Tipo, DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                FechaInicio = Convert.ToDateTime(FechaInicio.ToShortDateString());
                FechaFin = Convert.ToDateTime(FechaFin.ToShortDateString());
                List<Tarea_Info> Lista = new List<Tarea_Info>();
                using (EntityTareas Context = new EntityTareas())
                {
                        Lista = (from q in Context.vw_Tarea_asignar_subtarea
                                 where q.IdUsuarioAsignado == IdUsuario
                                 && q.FechaEntrega >= FechaInicio
                                 && q.FechaEntrega <= FechaFin
                                
                                 && q.Estado == true
                                 select new Tarea_Info
                                 {
                                     IdTarea = q.IdTarea,
                                     IdUsuarioSolicitante = q.IdUsuarioSolicitante,
                                     IdGrupo = q.IdGrupo,
                                     IdUsuarioAsignado = q.IdUsuarioAsignado,
                                     EstadoActual = q.EstadoActual,
                                     FechaEntrega = q.FechaEntrega,
                                     AsuntoTarea = q.AsuntoTarea,
                                     DescripcionTarea = q.DescripcionTarea,
                                     IdEstadoPrioridad = q.IdEstadoPrioridad,
                                     TareaConcurrente = q.TareaConcurrente,
                                     Estado = q.Estado,
                                     AprobadoEncargado = q.AprobadoEncargado,
                                     AprobadoSolicitado = q.AprobadoSolicitado,

                                     solicitante = q.solicitante,
                                     Asignado = q.Asignado,
                                     Prioridad = q.Prioridad,
                                     EstadoTarea = q.EstadoTarea,
                                     NombreGrupo = q.NombreGrupo,
                                     FechaCierreSolicitante = q.FechaCierreSolicitante,
                                     FechaCierreEncargado = q.FechaCierreEncargado,
                                     NumSubtarea = q.NumSubtarea,
                                     NumSubtareasAbiertas = q.NumSubtareasAbiertas



                                 }).ToList();
                   
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<Tarea_Info> get_lis(string IdUsuario)
        {
            try
            {
               

                List<Tarea_Info> Lista = new List<Tarea_Info>();

                using (EntityTareas Context = new EntityTareas())
                {
                    Lista = (from q in Context.sp_Tareas_X_Usuarios(IdUsuario)
                             
                             select new Tarea_Info
                             {
                                 IdTarea = q.IdTarea,
                                 IdUsuarioSolicitante = q.IdUsuarioSolicitante,
                                 IdGrupo = q.IdGrupo,
                                 IdUsuarioAsignado = q.IdUsuarioAsignado,
                                 EstadoActual = q.EstadoActual,
                                 FechaEntrega = q.FechaEntrega,
                                 AsuntoTarea = q.AsuntoTarea,
                                 DescripcionTarea=q.DescripcionTarea,
                                 IdEstadoPrioridad = q.IdEstadoPrioridad,
                                 TareaConcurrente = q.TareaConcurrente,
                                 Estado = q.Estado,
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
                        EstadoActual = info.EstadoActual,// ESTADO INICIADA,
                        FechaEntrega = info.FechaEntrega,
                        AsuntoTarea = info.AsuntoTarea,
                        DescripcionTarea=info.DescripcionTarea,
                        IdEstadoPrioridad = info.IdEstadoPrioridad,
                        TareaConcurrente = info.TareaConcurrente,
                        AprobadoEncargado=info.AprobadoEncargado,
                        AprobadoSolicitado=info.AprobadoSolicitado,
                        DiasIntervaloProximaTarea=info.DiasIntervaloProximaTarea,
                        FechaFinConcurrencia=info.FechaFinConcurrencia,
                        FechaTransaccion = DateTime.Now,
                        IdUsuario = info.IdUsuario,
                        Estado = true,
                        IdTareaPadre=info.IdTareaPadre
                    };
                    Context.Tarea.Add(Entity);
                    #endregion

                  
                    #region adjuntos
                    foreach (var item in info.list_adjuntos)
                    {
                        TareaArchivoAdjunto det = new TareaArchivoAdjunto
                        {
                            IdTarea = info.IdTarea,
                            Secuencial = secuencia,
                            NombreArchivo = item.NombreArchivo,
                            Archivo=item.Archivo,
                            TipoArchivo=item.TipoArchivo

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
                            Observacion=info.DescripcionTarea==null?" ":info.DescripcionTarea,
                            IdEstado=info.EstadoActual,
                            FechaModificacion=DateTime.Now,
                            

                        };
                        Context.TareaEstado.Add(New_estado);
                    
                    #endregion


                    Context.SaveChanges();
                }
               
                try
                {
                    info.Saludo = "Se encomiendo la siguiente tarea";
                    EnviarCorreo(info, cl_enumeradores.eAsuntoCorreo.NUEVA.ToString()+" "+cl_enumeradores.eAsuntoCorreo.TAREA.ToString(), cl_enumeradores.eCorreo.ENCARGADO);
                }
                catch (Exception)
                {

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
                int secuencia = 0;
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context. Tarea.Where(v => v.IdTarea == info.IdTarea).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.IdGrupo = info.IdGrupo;
                    Entity.IdUsuarioAsignado = info.IdUsuarioAsignado;
                    Entity.EstadoActual = info.EstadoActual=1;
                    Entity.FechaEntrega = info.FechaEntrega;
                    Entity.AsuntoTarea = info.AsuntoTarea;
                    Entity.DescripcionTarea = info.DescripcionTarea;
                    Entity.IdEstadoPrioridad = info.IdEstadoPrioridad;
                    Entity.TareaConcurrente = info.TareaConcurrente;
                    Entity.AprobadoSolicitado = info.AprobadoSolicitado;
                    Entity.AprobadoEncargado = info.AprobadoEncargado;
                    Entity.FechaModificacion = DateTime.Now;
                    Entity.IdUsuarioModifica = info.IdUsuarioModifica;
                    Entity.FechaFinConcurrencia = info.FechaFinConcurrencia;
                    Entity.DiasIntervaloProximaTarea = info.DiasIntervaloProximaTarea;

                   

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
                            Archivo = item.Archivo,
                            TipoArchivo = item.TipoArchivo


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
                        IdUsuario = info.IdUsuarioModifica,
                        Observacion = info.ObsevacionModificacion==null?" ":info.ObsevacionModificacion,
                        IdEstado = info.EstadoActual,
                        FechaModificacion = DateTime.Now


                    };
                    Context.TareaEstado.Add(New_estado);

                    #endregion
                    Context.SaveChanges();
                    try
                    {
                        info.Saludo = "La tarea fue modificada";

                        EnviarCorreo(info, cl_enumeradores.eAsuntoCorreo.TAREA.ToString() + " " + cl_enumeradores.eAsuntoCorreo.MODIFICADA.ToString(), cl_enumeradores.eCorreo.ENCARGADO);
                    }
                    catch (Exception)
                    {

                    }
                }

                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public bool anularDB(Tarea_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Tarea.Where(v => v.IdTarea == info.IdTarea).FirstOrDefault();
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
        public bool Aprobar(Tarea_Info info)
        {
            try
            {
                info_parametro = data_parametro.get_info();
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Tarea.Where(v => v.IdTarea == info.IdTarea).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.AprobadoEncargado = true;
                    Entity.FechaAprobacion = DateTime.Now;
                    Entity.EstadoActual = info_parametro.IdEstadoAprobarTarea;
                    Entity.FechaEntrega = info.FechaEntrega;
                    #region Estado tarea

                    TareaEstado New_estado = new TareaEstado
                    {
                        IdTarea = info.IdTarea,
                        Secuancial = odta_estado.get_id(info.IdTarea),
                        IdUsuario = info.IdUsuario,
                        Observacion = info.ObsevacionModificacion =info.ObsevacionModificacion,
                        IdEstado = Entity.EstadoActual,
                        FechaModificacion = DateTime.Now,


                    };
                    Context.TareaEstado.Add(New_estado);

                    #endregion


                    Context.SaveChanges();
                    try
                    {
                        info.Saludo = "Su tarea ha sido aprobada";

                        EnviarCorreo(info, cl_enumeradores.eAsuntoCorreo.TAREA.ToString() + " " + cl_enumeradores.eAsuntoCorreo.ACEPTADA.ToString(), cl_enumeradores.eCorreo.SOLICITANTE);
                    }
                    catch (Exception)
                    {

                    }
                }

                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public bool Desaprobar(Tarea_Info info)
        {
            try
            {
                info_parametro = data_parametro.get_info();
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Tarea.Where(v => v.IdTarea == info.IdTarea).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.AprobadoSolicitado = false;
                    Entity.EstadoActual = info_parametro.IdEstadoTareaDevuelta;
                    #region Estado tarea

                    TareaEstado New_estado = new TareaEstado
                    {
                        IdTarea = info.IdTarea,
                        Secuancial = odta_estado.get_id(info.IdTarea),
                        IdUsuario = info.IdUsuario,
                        Observacion = info.ObsevacionModificacion = info.ObsevacionModificacion,
                        IdEstado = info.EstadoActual,
                        FechaModificacion = DateTime.Now,


                    };
                    Context.TareaEstado.Add(New_estado);

                    #endregion

                    Context.SaveChanges();
                    try
                    {
                        info.Saludo = "Le estoy rechazando la tarea, por la cual se detalla en las observaciones ";
                        EnviarCorreo(info, cl_enumeradores.eAsuntoCorreo.TAREA.ToString() + " " + cl_enumeradores.eAsuntoCorreo.DEVUELTA.ToString(), cl_enumeradores.eCorreo.SOLICITANTE);
                    }
                    catch (Exception)
                    {

                    }
                }

                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public bool Cerrar(Tarea_Info info)
        {
            try
            {
                info_parametro = data_parametro.get_info();
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Tarea.Where(v => v.IdTarea == info.IdTarea).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.FechaCierreEncargado = DateTime.Now;
                    Entity.EstadoActual = info_parametro.IdEstadoCierreTarea;
                    #region Estado tarea

                    TareaEstado New_estado = new TareaEstado
                    {
                        IdTarea = info.IdTarea,
                        Secuancial = odta_estado.get_id(info.IdTarea),
                        IdUsuario = info.IdUsuario,
                        Observacion = info.ObsevacionModificacion,
                        IdEstado = info.EstadoActual=info_parametro.IdEstadoCierreTarea,
                        FechaModificacion = DateTime.Now,


                    };
                    Context.TareaEstado.Add(New_estado);

                    #endregion

                    Context.SaveChanges();
                    try
                    {
                        info.Saludo = "Su tarea fue cerrada, favor ayudarme con la revisión";
                        EnviarCorreo(info, cl_enumeradores.eAsuntoCorreo.TAREA.ToString() + " " + cl_enumeradores.eAsuntoCorreo.CERRADA.ToString(), cl_enumeradores.eCorreo.SOLICITANTE);
                    }
                    catch (Exception)
                    {

                    }
                   
                   
                }

                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public bool CerrarPorSolicitante(Tarea_Info info)
        {
            try
            {
                info_parametro = data_parametro.get_info();
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Tarea.Where(v => v.IdTarea == info.IdTarea).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.FechaCierreSolicitante = DateTime.Now;
                    Entity.FechaCierreEncargado = DateTime.Now;
                    Entity.EstadoActual = info_parametro.IdEstadoCierreSolicitante;
                    #region Estado tarea

                    TareaEstado New_estado = new TareaEstado
                    {
                        IdTarea = info.IdTarea,
                        Secuancial = odta_estado.get_id(info.IdTarea),
                        IdUsuario = info.IdUsuario,
                        Observacion = info.ObsevacionModificacion,
                        IdEstado = info.EstadoActual =info_parametro.IdEstadoCierreSolicitante,
                        FechaModificacion = DateTime.Now,


                    };
                    Context.TareaEstado.Add(New_estado);

                    #endregion

                    Context.SaveChanges();
                    try
                    {
                        info.Saludo = "La tarea que le encomende ha sido cerrada";

                        EnviarCorreo(info, cl_enumeradores.eAsuntoCorreo.TAREA.ToString() + " " + cl_enumeradores.eAsuntoCorreo.CERRADA.ToString(), cl_enumeradores.eCorreo.ENCARGADO);
                    }
                    catch (Exception)
                    {

                    }
                    if (info.TareaConcurrente)
                    {
                        if (info.FechaFinConcurrencia >= DateTime.Now.Date)
                        {
                            try
                            {
                                Context.sp_crear_tarea_concurrente(info.IdTarea);
                                EnviarCorreo(info, cl_enumeradores.eAsuntoCorreo.NUEVA.ToString() + " " + cl_enumeradores.eAsuntoCorreo.TAREA.ToString(), cl_enumeradores.eCorreo.ENCARGADO);
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }

                }

                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public bool RechazarTarea(Tarea_Info info)
        {
            try
            {
                info_parametro = data_parametro.get_info();
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Tarea.Where(v => v.IdTarea == info.IdTarea).FirstOrDefault();
                    if (Entity == null)
                        return false;
                    Entity.FechaCierreSolicitante = DateTime.Now;
                    Entity.FechaCierreEncargado = DateTime.Now;
                    Entity.EstadoActual = info_parametro.IdEstadoCierreSolicitante;
                    #region Estado tarea

                    TareaEstado New_estado = new TareaEstado
                    {
                        IdTarea = info.IdTarea,
                        Secuancial = odta_estado.get_id(info.IdTarea),
                        IdUsuario = info.IdUsuario,
                        Observacion = info.ObsevacionModificacion,
                        IdEstado = info.EstadoActual = info_parametro.IdEstadoCierreSolicitante,
                        FechaModificacion = DateTime.Now,


                    };
                    Context.TareaEstado.Add(New_estado);

                    #endregion

                    Context.SaveChanges();
                    try
                    {
                        info.Saludo = "La tarea que le encomende no ha sido aceptada";

                        EnviarCorreo(info, cl_enumeradores.eAsuntoCorreo.TAREA.ToString() + " " + cl_enumeradores.eAsuntoCorreo.CERRADA.ToString(), cl_enumeradores.eCorreo.ENCARGADO);
                    }
                    catch (Exception)
                    {

                    }
                    if (info.TareaConcurrente)
                    {
                        if (info.FechaFinConcurrencia >= DateTime.Now.Date)
                        {
                            try
                            {
                                Context.sp_crear_tarea_concurrente(info.IdTarea);
                                EnviarCorreo(info, cl_enumeradores.eAsuntoCorreo.NUEVA.ToString() + " " + cl_enumeradores.eAsuntoCorreo.TAREA.ToString(), cl_enumeradores.eCorreo.ENCARGADO);
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }

                }

                return true;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public bool Asignacion(Tarea_Info info)
        {
            try
            {
                info_parametro = data_parametro.get_info();
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Tarea.Where(v => v.IdTarea == info.IdTarea).FirstOrDefault();
                    if (Entity == null)
                        return false;

                      try
                    {
                        info.Saludo = "Su tarea ha sido distribuida";
                        EnviarCorreo(info, cl_enumeradores.eAsuntoCorreo.TAREA.ToString() + " " + cl_enumeradores.eAsuntoCorreo.DISTRIBUIDA.ToString(), cl_enumeradores.eCorreo.SOLICITANTE);
                    }
                    catch (Exception)
                    {

                    }
                }

                return true;
            }
            catch (Exception e)
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
                    vw_Tarea Entity = Context. vw_Tarea.FirstOrDefault(q => q.IdTarea == IdTarea);
                    if (Entity == null) return null;

                    info = new  Tarea_Info
                    {
                        
                        IdTarea =Entity.IdTarea,
                        IdUsuarioSolicitante = Entity.IdUsuarioSolicitante,
                        IdGrupo = Entity.IdGrupo,
                        IdUsuarioAsignado = Entity.IdUsuarioAsignado,
                        EstadoActual = Entity.EstadoActual,
                        FechaEntrega = Entity.FechaEntrega,
                        AsuntoTarea = Entity.AsuntoTarea,
                        DescripcionTarea=Entity.DescripcionTarea,
                        IdEstadoPrioridad = Entity.IdEstadoPrioridad,
                        TareaConcurrente = Entity.TareaConcurrente,
                        AprobadoEncargado = Entity.AprobadoEncargado,
                        AprobadoSolicitado = Entity.AprobadoSolicitado,
                        nomb_jef_grupo=Entity.Asignado,
                        DiasIntervaloProximaTarea=Entity.DiasIntervaloProximaTarea,
                        FechaFinConcurrencia=Entity.FechaFinConcurrencia,
                        IdTareaPadre=Entity.IdTareaPadre,
                        NumSubtareasAbiertas=Entity.NumSubtareasAbiertas

                    };
                }
                return info;
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
                

                #region variables locales
                var inf_usu_dirigido = data_usuario.get_info(EnviarA== cl_enumeradores.eCorreo.ENCARGADO?info.IdUsuarioAsignado:info.IdUsuarioSolicitante);
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
                   
                    mail.Subject = AsuntoCorreo;
                   
                    try
                    {
                        foreach (var item in info.list_adjuntos)
                        {
                            mail.Attachments.Add(new Attachment(new MemoryStream(item.Archivo), item.NombreArchivo));
                        }
                    }
                    catch (Exception)
                    {

                        
                    }
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
                   
                   // Body += "Observaciones: ";
                    Body += "<td><strong>Observaciones:</strong></td>";

                    Body += "<br/>";
                    Body += info.ObsevacionModificacion;
                    Body += "<table>";
                    Body += "<tr>";
                    Body += "<td><strong>Fecha entrega:</strong></td>";
                    Body += "<td><strong>" + info.FechaEntrega.ToShortDateString() + "</strong></td>";
                    Body += "</tr>";
                    Body += "<tr>";
                  
                    Body += "</tr>";
                    Body += "</table>";
                    Body += "<br/>";
                    Body += "<br/>";
                    Body += "Para para acceder a la tarea acceder al link:<br/><br/>";
                    Body += "<a href='http://tareas.degeremcia.com/General/"+info.Controller+"/"+info.Accion+"?IdTarea=" + info.IdTarea+"'>Tareas</a>";

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
                    smtp.EnableSsl =  infoParametros.PermitirSSL;
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
        public Tarea_Info get_carga_laboral(int IdGrupo, string IdUsuario, DateTime fechaInicio)
        {
            try
            {
                Tarea_Info info = new Tarea_Info();
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.sp_carga_laboral(IdUsuario, fechaInicio, IdGrupo).FirstOrDefault();
                    if (Entity == null)
                        return new Tarea_Info();
                    else
                    {
                        info.NumTareaPorAprobar = Entity.NumTareaPorAprobar;
                        info.NumTareaVencidas = Entity.NumTareaVencidas;
                        info.TotalTareaPendiente = Entity.TotalTareaPendiente;
                        info.TotalTareaResueltas = Entity.TotalTareaResueltas;

                        info.FechaInicio = fechaInicio;
                        info.IdUsuario = IdUsuario;
                        info.IdGrupoFiltro = IdGrupo;
                    }
                  }
                return info;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
