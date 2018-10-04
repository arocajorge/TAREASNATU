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

                            IntervaloEjecucionMin=info.IntervaloEjecucionMin,
                           
                           

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

                        Entity.IntervaloEjecucionMin = info.IntervaloEjecucionMin;
                      
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
                        IdEstadoTareaDevuelta = Entity.IdEstadoTareaDevuelta
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
