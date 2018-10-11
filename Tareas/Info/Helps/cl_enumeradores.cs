using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info.Helps
{
   public class cl_enumeradores
    {
        public enum eTipoTarea
        {
            ASIGNADA,
            GENERADAS
        }
        public enum eAsuntoCorreo
        {
            NUEVA,
            ACEPTADA,
            CERRADA,
            DEVUELTA,
            TAREA,
            MODIFICADA,
            DISTRIBUIDA
        }
        public enum eCorreo
        {
            SOLICITANTE,
            ENCARGADO
        }
        public enum eController
        {
            AprobarTarea,
            AsignarTarea,
            Buzon,
            MisTareas,
            Tarea
        }
        public enum eAcciones
        {
            Nuevo,
            Modificar,
            Cerrar,
            CerrarPorSolicitante,
            Consultar
        }
    }
}
