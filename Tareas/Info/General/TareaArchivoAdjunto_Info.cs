using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Info
{
   public class TareaArchivoAdjunto_Info
    {
        public decimal IdTarea { get; set; }
        public int Secuencial { get; set; }
        public string NombreArchivo { get; set; }
        public byte[] Archivo { get; set; }
        public string TipoArchivo { get; set; }


    }
}
