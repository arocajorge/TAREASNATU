using Data;
using Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
   public class Tarea_Bus
    {
        Tarea_Data odata = new Tarea_Data();
        public List<Tarea_Info> get_lis(DateTime FechaiInicio, DateTime FehcaFin)
        {
            try
            {
                return odata.get_lis(FechaiInicio, FehcaFin);
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
                return odata.get_lis(IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool guardarDB(Tarea_Info info)
        {
            try
            {
                Grupo_Data data_grupo = new Grupo_Data();
                var grupo = data_grupo.get_info(info.IdGrupo);
                info.IdUsuarioAsignado = grupo.IdUsuario;
                return odata.guardarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool modificarDB(Tarea_Info info)
        {
            try
            {
                return odata.modificarDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool anularDB(Tarea_Info info)
        {
            try
            {
                return odata.anularDB(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Tarea_Info get_info(decimal IdTarea)
        {
            try
            {
                return odata.get_info(IdTarea);


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

