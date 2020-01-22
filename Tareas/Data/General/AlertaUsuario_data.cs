using Info.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.General
{
    public class AlertaUsuario_Data
    {
        public List<AlertaUsuario_Info> GetListUsuarios()
        {
            try
            {
                List<AlertaUsuario_Info> Lista;

                using (EntityTareas db = new EntityTareas())
                {
                    Lista = db.vw_UsuarioAlerta.Select(q => new AlertaUsuario_Info
                    {
                        IdUsuario = q.IdUsuarioAsignado,
                        Cont = q.Cont,
                        MinutosUltimaAlarma = q.MinutosUltimaAlarma ?? 0,
                        correo = q.Correo
                    }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AlertaUsuario_Info> GetListTareas(string IdUsuario)
        {
            try
            {
                List<AlertaUsuario_Info> Lista;

                using (EntityTareas db = new EntityTareas())
                {
                    Lista = db.vw_TareaAlerta.Where(q => q.IdUsuarioAsignado == IdUsuario).Select(q => new AlertaUsuario_Info
                    {
                        IdUsuario = q.IdUsuarioAsignado,
                        IdTarea = q.IdTarea,
                        MinutosCaducar = q.MinutosCaducar,
                        AsuntoTarea = q.AsuntoTarea,
                        correo = q.Correo,
                        MinutosUltimaAlarma = q.MinutosUltimaAlarma,
                        FechaEntrega = q.FechaEntrega
                    }).ToList();
                }

                return Lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Guardar(AlertaUsuario_Info info)
        {
            try
            {
                using (EntityTareas db = new EntityTareas())
                {
                    var Entity = db.AlertaUsuario.Where(q => q.IdUsuario == info.IdUsuario).FirstOrDefault();
                    if(Entity == null)
                    {
                        db.AlertaUsuario.Add(new AlertaUsuario
                        {
                            IdUsuario = info.IdUsuario,
                            FechaUltimaAlerta = DateTime.Now,
                            MensajeCorreo = info.MensajeCorreo
                        });
                    }else
                    {
                        Entity.FechaUltimaAlerta = DateTime.Now;
                        Entity.MensajeCorreo = info.MensajeCorreo;
                    }

                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
