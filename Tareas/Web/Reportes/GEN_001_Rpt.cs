using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Bus.General;
using Info.General;
using System.Collections.Generic;

namespace Web.Reportes
{
    public partial class GEN_001_Rpt : DevExpress.XtraReports.UI.XtraReport
    {
        public GEN_001_Rpt()
        {
            InitializeComponent();
        }

        private void GEN_001_Rpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string IdUsuario = p_IdUsuario.Value == null ? "" : Convert.ToString(p_IdUsuario.Value);
            decimal IdTarea = string.IsNullOrEmpty( p_IdTarea.Value.ToString()) ? 0 : Convert.ToDecimal(p_IdTarea.Value);
            DateTime fechaInicio = p_fechaInicio.Value == null ? DateTime.Now : Convert.ToDateTime(p_fechaInicio.Value);
            DateTime fechaFin = p_fechaFin.Value == null ? DateTime.Now : Convert.ToDateTime(p_fechaFin.Value);


            GEN_001_Bus bus_rpt = new GEN_001_Bus();
            List<GEN_001_Info> lst_rpt = bus_rpt.get_list(IdUsuario, IdTarea, fechaInicio, fechaFin);
            this.DataSource = lst_rpt;
        }
    }
}
