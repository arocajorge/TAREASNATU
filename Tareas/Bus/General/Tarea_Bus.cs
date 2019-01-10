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
        public List<Tarea_Info> get_lis(DateTime FechaiInicio)
        {
            try
            {
                return odata.get_lis(FechaiInicio);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Tarea_Info> get_lis_cargar_combo()
        {
            try
            {
                return odata.get_lis_cargar_combo();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public List<Tarea_Info> get_lis_anulados(string IdUsuarioSolicitante, DateTime FechaiInicio, DateTime FehcaFin)
        {
            try
            {
                return odata.get_lis_anulados(IdUsuarioSolicitante,FechaiInicio, FehcaFin);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Tarea_Info> get_lis(string IdUsuario, cl_enumeradores.eTipoTarea Tipo, DateTime FechaInicio)
        {
            try
            {
                return odata.get_lis(IdUsuario, Tipo, FechaInicio);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Tarea_Info> get_lis_asignar_subtareas(string IdUsuario, cl_enumeradores.eTipoTarea Tipo, DateTime FechaInicio)
        {
            try
            {
                return odata.get_lis_asignar_subtareas(IdUsuario, Tipo, FechaInicio);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool CerrarTareasServicio()
        {
            try
            {
                return odata.CerrarTareasServicio();
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
                return odata.get_lis_x_aprobar(IdUsuario);
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
        public bool Eliminar(Tarea_Info info)
        {
            try
            {
                return odata.Eliminar(info);
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
        public bool CerrarPorSolicitante(Tarea_Info info)
        {
            try
            {
                return odata.CerrarPorSolicitante(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool RechazarTarea(Tarea_Info info)
        {
            try
            {
                return odata.RechazarTarea(info);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Asignacion(Tarea_Info info)
        {
            try
            {
                return odata.Asignacion(info);
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

        public Tarea_Info get_carga_laboral(int IdGrupo, string IdUsuario, DateTime FechaInicio)
        {
            try
            {
                return odata.get_carga_laboral(IdGrupo, IdUsuario, FechaInicio);


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

