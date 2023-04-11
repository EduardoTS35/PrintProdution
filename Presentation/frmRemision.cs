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
    public partial class frmRemision : Form
    {
        UserModel userModel = new UserModel();
        public frmRemision()
        {
            InitializeComponent();
        }

        private void frmRemision_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            CargarcmbClientes();
        }

        public void CargarcmbClientes()
        {
            comboBox1.DataSource = userModel.MostrarDatoscmbClientes();
            comboBox1.DisplayMember = "RazonSocial";
            comboBox1.ValueMember = "IDCliente";
        }

        private void getReport(DateTime startDate, DateTime endDate,int cliente)
        {
            Reporte reporte = new Reporte();
            reporte.GenerarOrdenReporteResumenSC(startDate, endDate,cliente);
            ReporteBindingSource.DataSource = reporte;
            PruebasLBindingSource.DataSource = reporte.pruebasL;
        }

        private void getReportD(DateTime startDate, DateTime endDate,int cliente)
        {
            ReporteDetails reporteOpen = new ReporteDetails();
            reporteOpen.GenerarOrdenReporteDSC(startDate, endDate,cliente);
            PruebasLDeBindingSource.DataSource = reporteOpen.pruebasLDe;

        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            int cliente = Convert.ToInt32(comboBox1.SelectedValue);
            var fromDate = DateTime.Today;
            var toDate = DateTime.Today.AddDays(1);

            getReport(fromDate, toDate,cliente);
            getReportD(fromDate, toDate,cliente);
            this.reportViewer1.RefreshReport();
        }

        private void btnSemana_Click(object sender, EventArgs e)
        {
            int cliente = Convert.ToInt32(comboBox1.SelectedValue);
            var fromDate = DateTime.Today.AddDays(-7);
            var toDate = DateTime.Today.AddDays(1);

            getReport(fromDate, toDate,cliente);
            getReportD(fromDate, toDate,cliente);
            this.reportViewer1.RefreshReport();
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            int cliente = Convert.ToInt32(comboBox1.SelectedValue);
            var fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var toDate = DateTime.Today.AddDays(1);

            getReport(fromDate, toDate,cliente);
            getReportD(fromDate, toDate,cliente);
            this.reportViewer1.RefreshReport();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            int cliente = Convert.ToInt32(comboBox1.SelectedValue);
            var fromDate = dtPFromDate.Value.ToShortDateString();
            var toDate = dtPToDate.Value.AddDays(1);

            getReport(Convert.ToDateTime(fromDate), new DateTime(toDate.Year, toDate.Month, toDate.Day, 0, 0, 0),cliente);
            getReportD(Convert.ToDateTime(fromDate), new DateTime(toDate.Year, toDate.Month, toDate.Day, 0, 0, 0),cliente);
            this.reportViewer1.RefreshReport();
        }
    }
}
