using System;
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
    public partial class frmReportSalida : Form
    {
        public frmReportSalida()
        {
            InitializeComponent();
        }

        private void frmReportSalida_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void getReport(DateTime startDate, DateTime endDate)
        {
            Reporte reporte = new Reporte();
            reporte.GenerarOrdenReporteS2(startDate, endDate);
            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }

        private void getReportD(DateTime startDate, DateTime endDate)
        {
            ReporteDetails reporteOpen = new ReporteDetails();
            reporteOpen.GenerarOrdenReporteDS(startDate, endDate);
            PruebasLDeBindingSource.DataSource = reporteOpen.pruebasLDe;

        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Today;
            var toDate = DateTime.Today.AddDays(1);

            getReport(fromDate, toDate);
            getReportD(fromDate, toDate);
            this.reportViewer1.RefreshReport();
        }

        private void btnSemana_Click(object sender, EventArgs e)
        {
            var fromDate = DateTime.Today.AddDays(-7);
            var toDate = DateTime.Today.AddDays(1);

            getReport(fromDate, toDate);
            getReportD(fromDate, toDate);
            this.reportViewer1.RefreshReport();
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            var fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var toDate = DateTime.Today.AddDays(1);

            getReport(fromDate, toDate);
            getReportD(fromDate, toDate);
            this.reportViewer1.RefreshReport();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            var fromDate = dtPFromDate.Value.ToShortDateString();
            var toDate = dtPToDate.Value.AddDays(1);

            getReport(Convert.ToDateTime(fromDate), new DateTime(toDate.Year, toDate.Month, toDate.Day, 0, 0, 0));
            getReportD(Convert.ToDateTime(fromDate), new DateTime(toDate.Year, toDate.Month, toDate.Day, 0, 0, 0));
            this.reportViewer1.RefreshReport();
        }
    }
}
