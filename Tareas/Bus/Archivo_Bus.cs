using Data;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
   public class Archivo_Bus
    {
        Archivo_Data odata = new Archivo_Data();
        public bool Guardar_Adjuntos(List<TareaArchivoAdjunto_Info> lista_file)
        {
            try
            {
                return odata.Guardar_Adjuntos(lista_file);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Guardar_formatos_ISO(string NombreArchivo, byte[] tamanio_file)
        {
            try
            {
                return odata.Guardar_formatos_ISO(NombreArchivo,tamanio_file);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
