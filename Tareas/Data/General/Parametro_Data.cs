using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.General
{
   public class Parametro_Data
    {
        public bool guardarDB(Parametro_Info info)
        {
            try
            {
                using (EntityTareas Context = new EntityTareas())
                {
                    var Entity = Context.Parametro.FirstOrDefault(v=>v.IdParametro==1);
                    if (Entity==null)
                    {
                        Entity = new Parametro
                        {
                            IdParametro = info.IdParametro = 1,
                            CorreoCuenta = info.CorreoCuenta,
                            CorreoClave = info.CorreoClave,
                            Puerto = info.Puerto,
                            Host = info.Host,
                            PermitirSSL = info.PermitirSSL,
                            FtpUsuario = info.FtpUsuario,
                            FtpClave = info.FtpClave,
                            FtpURLArchivo = info.FtpURLArchivo,
                            FtpURLAdjunto = info.FtpURLAdjunto,
                            IdEstadoAprobarTarea=info.IdEstadoAprobarTarea,
                            IdEstadoCierreTarea=info.IdEstadoCierreTarea,
                            IdEstadoTareaDevuelta=info.IdEstadoTareaDevuelta,
                            IdEstadoCierreSolicitante=info.IdEstadoCierreSolicitante,
                            IntervaloEjecucionMin=info.IntervaloEjecucionMin,
                            IdEstadoTareaVencida=info.IdEstadoTareaVencida,
                            IntervaloEjecucionMinApro = info.IntervaloEjecucionMinApro,
                            UtilizarFechaAutoApro = info.UtilizarFechaAutoApro,
                            IntervaloAlertaMin = info.IntervaloAlertaMin,
                            IntervaloRepetirAlarma = info.IntervaloRepetirAlarma,
                            DiferenciaDiasAceptacionEntrgea = info.DiferenciaDiasAceptacionEntrgea
                        };
                        Context.Parametro.Add(Entity);
                    }
                    else
                    {
                        Entity.CorreoCuenta = info.CorreoCuenta;
                        Entity.CorreoClave = info.CorreoClave;
                        Entity.Puerto = info.Puerto;
                        Entity.Host = info.Host;
                        Entity.PermitirSSL = info.PermitirSSL;
                        Entity.FtpUsuario = info.FtpUsuario;
                        Entity.FtpClave = info.FtpClave;
                        Entity.FtpURLArchivo = info.FtpURLArchivo;
                        Entity.FtpURLAdjunto = info.FtpURLAdjunto;
                        Entity.IdEstadoAprobarTarea = info.IdEstadoAprobarTarea;
                        Entity.IdEstadoCierreTarea = info.IdEstadoCierreTarea;
                        Entity.IdEstadoTareaDevuelta = info.IdEstadoTareaDevuelta;
                        Entity.IdEstadoCierreSolicitante = info.IdEstadoCierreSolicitante;

                        Entity.IntervaloEjecucionMin = info.IntervaloEjecucionMin;
                        Entity.IdEstadoTareaVencida = info.IdEstadoTareaVencida;
                        Entity.IntervaloEjecucionMinApro = info.IntervaloEjecucionMinApro;

                        Entity.UtilizarFechaAutoApro = info.UtilizarFechaAutoApro;
                        Entity.IntervaloAlertaMin = info.IntervaloAlertaMin;
                        Entity.IntervaloRepetirAlarma = info.IntervaloRepetirAlarma;
                        Entity.DiferenciaDiasAceptacionEntrgea = info.DiferenciaDiasAceptacionEntrgea;
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


        public Parametro_Info get_info()
        {
            try
            {
                Parametro_Info info = new Parametro_Info();
                using (EntityTareas Context = new EntityTareas())
                {
                    Parametro Entity = Context.Parametro.FirstOrDefault(q => q.IdParametro == 1);
                    if (Entity == null) return null;

                    info = new Parametro_Info
                    {
                        IdParametro = Entity.IdParametro = 1,
                        CorreoCuenta = Entity.CorreoCuenta,
                        CorreoClave = Entity.CorreoClave,
                        Puerto = Entity.Puerto,
                        Host = Entity.Host,
                        PermitirSSL = Entity.PermitirSSL,
                        FtpUsuario = Entity.FtpUsuario,
                        FtpClave = Entity.FtpClave,
                        FtpURLArchivo = Entity.FtpURLArchivo,
                        FtpURLAdjunto = Entity.FtpURLAdjunto,
                        IdEstadoAprobarTarea = Entity.IdEstadoAprobarTarea,
                        IdEstadoCierreTarea = Entity.IdEstadoCierreTarea,
                        IdEstadoTareaDevuelta = Entity.IdEstadoTareaDevuelta,
                        IntervaloEjecucionMin=Entity.IntervaloEjecucionMin,
                        IdEstadoCierreSolicitante=Entity.IdEstadoCierreSolicitante,
                        IdEstadoTareaVencida=Entity.IdEstadoTareaVencida,
                        IntervaloEjecucionMinApro= Entity.IntervaloEjecucionMinApro,
                        UtilizarFechaAutoApro = Entity.UtilizarFechaAutoApro,
                        IntervaloRepetirAlarma = Entity.IntervaloRepetirAlarma,
                        IntervaloAlertaMin = Entity.IntervaloAlertaMin,
                        DiferenciaDiasAceptacionEntrgea = Entity.DiferenciaDiasAceptacionEntrgea ?? 0
                    };
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
