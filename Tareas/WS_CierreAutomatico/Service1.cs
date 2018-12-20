using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Bus.General;
using System.Timers;
using Bus;

namespace WS_CierreAutomatico
{
    
    public partial class Service1 : ServiceBase
    {
        public Tarea_Bus bus_tarea;

        public Service1()
        {
            InitializeComponent();
        }

        private void Tiempo_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                using (DB_TAREASEntities db = new DB_TAREASEntities())
                {
                    db.CierreTareaAutomatico();
                }
            }
            catch (Exception)
            {
                
            }            
        }

        protected override void OnStart(string[] args)
        {
            Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(Tiempo_Elapsed);
            aTimer.Interval = TimeSpan.FromSeconds(20).TotalMilliseconds;
            aTimer.Enabled = true;
        }

        protected override void OnStop()
        {
        }
    }
}
