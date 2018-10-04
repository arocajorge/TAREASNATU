﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Bus.General;
using Info.General;
using System.Collections.Generic;

namespace Web.Reportes
{
    public partial class GEN_002_Rpt : DevExpress.XtraReports.UI.XtraReport
    {
        public GEN_002_Rpt()
        {
            InitializeComponent();
        }

        private void GEN_002_Rpt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string IdUsuario = p_IdUsuario.Value == null ? "" : Convert.ToString(p_IdUsuario.Value);
            DateTime fechaInicio = p_fechaInicio.Value == null ? DateTime.Now : Convert.ToDateTime(p_fechaInicio.Value);
            DateTime fechaFin = p_fechaFin.Value == null ? DateTime.Now : Convert.ToDateTime(p_fechaFin.Value);


            GEN_002_Bus bus_rpt = new GEN_002_Bus();
            List<GEN_002_Info> lst_rpt = bus_rpt.get_list(IdUsuario, fechaInicio, fechaFin);
            this.DataSource = lst_rpt;
        }
    }
}
