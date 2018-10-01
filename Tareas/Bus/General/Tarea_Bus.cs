using Data;
using Info;
using Info.Helps;
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
        public List<Tarea_Info> get_lis(string IdUsuario, cl_enumeradores.eTipoTarea Tipo, DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                return odata.get_lis(IdUsuario, Tipo, FechaInicio, FechaFin);
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
                odata=new Tarea_Data();
               
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
        public bool Aprobar(Tarea_Info info)
        {
            try
            {
                odata = new Tarea_Data();
                return odata.Aprobar(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Desaprobar(Tarea_Info info)
        {
            try
            {
                odata = new Tarea_Data();
                return odata.Desaprobar(info);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Cerrar(Tarea_Info info)
        {
            try
            {
                return odata.Cerrar(info);
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

        public Tarea_Info get_carga_laboral(string IdUsuario, DateTime Fecha)
        {
            try
            {
                return odata.get_carga_laboral(IdUsuario, Fecha);


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

