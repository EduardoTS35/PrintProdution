using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commun.Cache;
using Domain;

namespace Presentation
{
    public partial class frmConfigE : Form
    {
        UserModel userModel = new UserModel();

        public frmConfigE()
        {
            InitializeComponent();
        }

        public void MostrarDatosI(string ID)
        {
            ID = tboxIdSerial.Text;
            try
            {
                userModel.MostrarDatosI(ID);
                dataGridView2.DataSource = userModel.MostrarDatosI(ID);

            }
            catch (Exception)
            {

            }
        }

        private void tboxIdSerial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tboxIdSerial.Text != null)
                {
                    MostrarDatosI(tboxIdSerial.Text);
                    timer1.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ningun producto" + ex);
            }
        }

        private void tboxIdSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                userModel.RestarInventario(tboxIdSerial.Text);
                userModel.RestarEntrada(tboxIdSerial.Text);
                tboxIdSerial.Clear();
                timer1.Dispose();
                timer1.Stop();
            }
            catch
            {
                tboxIdSerial.Clear();
                timer1.Dispose();
                timer1.Stop();
                MessageBox.Show("No se encontró el producto seleccionado");
            }
        }
    }
}
