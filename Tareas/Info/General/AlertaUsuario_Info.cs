using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.General
{
    public class AlertaUsuario_Info
    {
        #region Campos en la tabla
        public string IdUsuario { get; set; }
        public Nullable<System.DateTime> FechaUltimaAlerta { get; set; }
        public string MensajeCorreo { get; set; }
        #endregion

        #region Vista detalle de tareas
        public decimal IdTarea { get; set; }
        public Nullable<int> MinutosCaducar { get; set; }
        public string AsuntoTarea { get; set; }
        public string correo { get; set; }
        public int MinutosUltimaAlarma { get; set; }
        public System.DateTime FechaEntrega { get; set; }
        #endregion

        #region Vista usuarios para alerta
        public Nullable<int> Cont { get; set; }
        #endregion
    }
}
