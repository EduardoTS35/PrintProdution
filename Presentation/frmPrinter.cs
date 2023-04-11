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
using Commun.Cache;
using System.IO.Ports;
using System.Drawing.Printing;
using BarcodeLib;
using System.IO;
using System.Drawing.Imaging;

namespace Presentation
{
    public partial class frmPrinter : Form
    {
        UserModel userModel = new UserModel();
        string dataIN;
        char[] charToTrim = { 'U','S','N', 'T', 'G', '-', ',', '+', 'k', 'g',' ' };

        public frmPrinter()
        {
            InitializeComponent();
        }

        private void frmPrinter_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cmbComport.Items.AddRange(ports);

            btnConectar.Enabled = true;
            btnDesconectar.Enabled = false;

            MostrarDatosPrint();
            MostrarDatoscmbP();
            userModel.MostrarActualId();
            MostrarActualId();
            timer2.Start();
        }
        public void TurnoDiurno()
        {
            lblTurno.Text = "Diurno";
        }

        public void TurnoNocturno1()
        {
            lblTurno.Text = "Nocturno";
        }

        public void TurnoNocturno2()
        {
            lblTurno.Text = "Nocturno";

        }

        public void TurnoCorrespondienteN()
        {
            double hora = Convert.ToDouble(DateTime.Now.ToString("HH.mm"));
            if (hora <= 07)
            {
                if (hora >= 00)
                {
                    TurnoNocturno1();
                }

            }
            else
            {
                TurnoNocturno2();
            }

        }
        public void TurnoCorrespondienteD()
        {
            double hora = Convert.ToDouble(DateTime.Now.ToString("HH.mm"));
            if (hora <= 20)
            {
                if (hora >= 07)
                {
                    TurnoDiurno();
                }
            }
        }

        public void SerialPortCoN()
        {
            if (serialPort1.IsOpen)
            {
                AppCache.StatusPort = 1;
            }
            else AppCache.StatusPort = 0;
        }

        public void MostrarActualId()
        {
            int sigId = Convert.ToInt32(AppCache.ActualId);
            tboxIdS.Text = Convert.ToString(sigId);
        }

        public void MostrarDatosPrint()
        {

            dataGridView1.DataSource = userModel.MostrarDatosPrint();
        }


        public void CapturarData()
        {
            char[] charToTrim = { 'U', 'S', 'N', 'T', 'G', '-', ',', '+', 'k', 'g', ' ' };

            string trimDataIn = tboxDatosB.Text.Trim(charToTrim);
            string dataFinal = trimDataIn.Normalize();
            if (tboxTara.Text == "")
            {
                tboxTara.Text = dataFinal.Remove(4);

                
            }
            else tboxDataIN.Text = dataFinal.Remove(4);
        }
        public void CorregirTara()
        {
            int V = AppCache.ContadorClicks;
            tboxTara.Text = "";
            V = 0;
        }

        public void MostrarDatoscmbP()
        {
            cmbProducto.DataSource = userModel.MostrarDatoscmbP();
            cmbProducto.DisplayMember = "NombreP";
            cmbProducto.ValueMember = "ID";
        }


        public void CalcularPesoNeto()
        {
            string trimDataIn = tboxDatosB.Text.Trim(charToTrim);
            double pesoNeto =Math.Round(Convert.ToSingle(trimDataIn.Remove(4)) - Convert.ToSingle(tboxTara.Text),1);
            tboxPesoNeto.Text = Convert.ToString(pesoNeto);
        }

        private void btnCapSQL_Click(object sender, EventArgs e)
        {
            try
            {
                if(tboxIdS.Text!=null & tboxIDProd.Text!=null & cmbProducto.Text!=null & tboxDataIN.Text!=null & tboxPesoNeto.Text!=null & tboxTara.Text != null)
                {
                    userModel.InsertarPrint(UserLoginCache.FirstName, tboxIDProd.Text, cmbProducto.Text, tboxDataIN.Text, tboxPesoNeto.Text, tboxTara.Text);
                    userModel.InsertarInventario(tboxIdS.Text, UserLoginCache.FirstName, tboxIDProd.Text, cmbProducto.Text, tboxDataIN.Text, tboxPesoNeto.Text);
                    userModel.MostrarActualId();
                    MostrarActualId();
                    MessageBox.Show("Se insertó correctamente");
                    printDocument1 = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    PageSettings pageSettings = new PageSettings();
                    PaperSize paper = new PaperSize("Etiqueta",394, 551);
                    printDocument1.PrinterSettings = ps;
                    pageSettings.PaperSize = paper;
                    printDocument1.PrintPage += Imprimir;
                    printDocument1.Print();

                    tboxDataIN.Clear();
                    tboxPesoNeto.Clear();
                    userModel.MostrarActualId();
                    MostrarActualId();
                }
                else
                {
                    MessageBox.Show("Por favor completa todos los campos","Advertencia");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se insertaron los datos por: " + ex);
            }
            MostrarDatosPrint();

            
        }

        private void ShowData(object sender, EventArgs e)
        {
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            dataIN = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(ShowData));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string trimDataIn = dataIN;
            tboxDatosB.Text = trimDataIn;
        }


        private void Imprimir(object sender, PrintPageEventArgs e)
        {

            Barcode barcode = new Barcode();
            barcode.IncludeLabel = false;
            barcode.Alignment = AlignmentPositions.CENTER;
            barcode.LabelFont = new Font(FontFamily.GenericMonospace, 14, FontStyle.Regular);
            Image img = barcode.Encode(TYPE.CODE128, tboxIdS.Text, Color.Black, Color.White, 240, 60);

            PageSettings pageSettings = new PageSettings();
            PaperSize paper = new PaperSize("Etiqueta", 404, 551);
            pageSettings.PaperSize = paper;
            Font fontT = new Font("Arial", 24, FontStyle.Bold);
            Font font = new Font("Arial", 22, FontStyle.Bold);
            Font fontP = new Font("Arial", 16, FontStyle.Bold);
            Font ftext = new Font("Arial", 15,FontStyle.Bold);
            Font fontS = new Font("Arial", 5);
            Pen blackpen = new Pen(Color.Black,3);
            int ancho = 900;
            int largo = 20;

            e.Graphics.DrawRectangle(blackpen, 5, 5, 543, 375);
            e.Graphics.DrawRectangle(blackpen, 257, 53, 262, 228);
            e.Graphics.DrawLine(blackpen, 256,170,519,170);
            e.Graphics.DrawString(cmbProducto.Text, fontT, Brushes.Black, new RectangleF(7, largo, ancho, 40));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("                      ", fontP, Brushes.Black, new RectangleF(300, largo += 25, ancho, 25));
            e.Graphics.DrawString("ID: " + tboxIDProd.Text, ftext, Brushes.Black, new RectangleF(12, largo += 22, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Número de Lote: " + cmbLote.Text, fontP, Brushes.Black, new RectangleF(260, largo = 97, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Fecha:  " + DateTime.Now.ToShortDateString(), ftext, Brushes.Black, new RectangleF(12, 170, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Neto: " + tboxPesoNeto.Text + " KG", font, Brushes.Black, new RectangleF(260, 200, ancho,40));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Turno:  " + lblTurno.Text, ftext, Brushes.Black, new RectangleF(12, 230, ancho, 22));
            e.Graphics.DrawString("                      ", fontS, Brushes.Black, new RectangleF(0, largo += 10, ancho, 10));
            e.Graphics.DrawString("Número: " + tboxIdS.Text, ftext, Brushes.Black, new RectangleF(12, 300, ancho, 25));
            e.Graphics.DrawImage(img, 260,310);
            e.Graphics.RotateTransform(180);
            e.Graphics.DrawString("Fecha:  " + DateTime.Now.ToString("dd-MM-yyyy hh:mm"), ftext, Brushes.Black, new RectangleF(7, 170, ancho, 22));
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            dataIN = "Desconectado";
            if (dataIN == "Desconectado")
            {
                serialPort1.Close();
                serialPort1.Dispose();
                btnConectar.Enabled = true;
                lblStatus.Text = "DESCONECTADO";
                lblStatus.ForeColor = Color.FromArgb(200, 46, 13);
                timer1.Stop();
                SerialPortCoN();
            }

        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            var mostrarID = user.MostrarID(cmbProducto.Text);
            if (mostrarID == true)
            {
                tboxIDProd.Text = AppCache.IdProducto;
            }
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            try
            {
                AppCache.ContadorClicks += 1;
                CapturarData();
                CalcularPesoNeto();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CorregirTara();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = cmbComport.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = (StopBits)1;
                serialPort1.Parity = (Parity)0;
                serialPort1.Open();
                btnConectar.Enabled = false;
                btnDesconectar.Enabled = true;
                lblStatus.Text = "  CONECTADO";
                lblStatus.ForeColor = Color.FromArgb(61, 200, 13);
                timer1.Start();
                SerialPortCoN();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnConectar.Enabled = true;
                btnDesconectar.Enabled = false;
                lblStatus.Text = "DESCONECTADO";
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            tboxDataIN.Text = "";
            tboxPesoNeto.Text = "";
            tboxDataIN.Clear();
            tboxPesoNeto.Clear();
        }

        private void MostrarTurno()
        {
            TurnoCorrespondienteN();
            TurnoCorrespondienteD();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            MostrarTurno();
        }
    }
}

