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
    public partial class frmConfigS : Form
    {
        UserModel userModel = new UserModel();
        public frmConfigS()
        {
            InitializeComponent();
        }

        public void MostrarDatosS(string ID)
        {
            ID = tboxIdSerial.Text;
            try
            {
                userModel.MostrarDatosS(ID);
                dataGridView2.DataSource = userModel.MostrarDatosS(ID);

            }
            catch (Exception)
            {

            }
        }


        public void LeerDatos()
        {
            DataGridViewRow row = dataGridView2.Rows[0];

            string ID = Convert.ToString(row.Cells[0].Value);
            string IDProducto = Convert.ToString(row.Cells[3].Value);
            string Producto = Convert.ToString(row.Cells[4].Value);
            string PesoBruto = Convert.ToString(row.Cells[5].Value);
            string PesoNeto = Convert.ToString(row.Cells[6].Value);
            AppCache.IDI = ID;
            AppCache.IDProductoI = IDProducto;
            AppCache.ProductoI = Producto;
            AppCache.PesoBruto = PesoBruto;
            AppCache.PesoNeto = PesoNeto;
        }


        private void tboxIdOrden_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxIdSerial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tboxIdSerial.Text != null)
                {
                    MostrarDatosS(tboxIdSerial.Text);
                    LeerDatos();
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
                userModel.InsertarInventario(AppCache.IDI, UserLoginCache.FirstName, AppCache.IDProductoI, AppCache.ProductoI, AppCache.PesoBruto, AppCache.PesoNeto);
                userModel.RestarSalida(tboxIdSerial.Text);
                tboxIdSerial.Clear();
                timer1.Dispose();
                timer1.Stop();
                MessageBox.Show("Se realizo exitosamente el cambio");
            }
            catch
            {
                tboxIdSerial.Clear();
                timer1.Dispose();
                timer1.Stop();
                MessageBox.Show("No se encontró el producto seleccionado");
            }
        }

        private void frmConfigS_Load(object sender, EventArgs e)
        {

        }
    }
}
