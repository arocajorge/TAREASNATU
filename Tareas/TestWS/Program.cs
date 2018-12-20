using Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWS
{
    class Program
    {
        static Tarea_Bus bus_tarea = new Tarea_Bus();

        static void Main(string[] args)
        {
            Tiempo_Elapsed();
        }

        public static void Tiempo_Elapsed()
        {
            try
            {
                bus_tarea = new Tarea_Bus();
                bus_tarea.CerrarTareasServicio();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
