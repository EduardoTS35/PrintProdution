﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace Presentation
{
    public partial class frmReporteInventario : Form
    {
        public frmReporteInventario()
        {
            InitializeComponent();
        }

        private void frmReporteInventario_Load(object sender, EventArgs e)
        {
            getReport();
            getReportD();
            this.reportViewer1.RefreshReport();
        }
        private void getReport()
        {
            Reporte reporte = new Reporte();
            reporte.GenerarOrdenReporteI();
            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }

        private void getReportD()
        {
            ReporteDetails reporteOpen = new ReporteDetails();
            reporteOpen.GenerarOrdenReporteDI();
            PruebasLDeBindingSource.DataSource = reporteOpen.pruebasLDe;

        }

        private void btnGenerarReport_Click(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            getReport();
            getReportD();
        }
    }
}
