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
using System.Threading;

namespace Presentation
{
    public partial class frmSalidas : Form
    {
        UserModel userModel = new UserModel();
        public frmSalidas()
        {
            InitializeComponent();
        }

        private void frmSalidas_Load(object sender, EventArgs e)
        {
            MostrarDatosSalidas();
            CargarcmbClientes();
        }

        public void CargarcmbClientes()
        {           
            cmbClientes.DataSource= userModel.MostrarDatoscmbClientes();
            cmbClientes.DisplayMember = "RazonSocial";
            cmbClientes.ValueMember = "IDCliente";
        }
        public void MostrarDatosSalidas()
        {
            try
            {
                dataGridView1.DataSource = userModel.MostrarDatosS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha ingresado ningun valor en la base de datos: " + ex);
            }

        }

        public void MostrarDatosI(string ID)
        {
            try
            {
                dataGridView2.DataSource = userModel.MostrarDatosI(ID);
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

        private void tboxID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tboxID.Text != null)
                {
                MostrarDatosI(tboxID.Text);
                LeerDatos();
                timer1.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontró ningun producto" + ex);
            }
            

        }

        private void btnCapSQL_Click(object sender, EventArgs e)
        {
            //Mostrar Orden de Salida
            frmRemision ordendeSalida = new frmRemision();
            ordendeSalida.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
            userModel.InsertarSalidas(AppCache.IDI, UserLoginCache.FirstName, AppCache.IDProductoI, AppCache.ProductoI, AppCache.PesoBruto, AppCache.PesoNeto, cmbClientes.SelectedValue.ToString());
            userModel.RestarInventario(tboxID.Text);
            MostrarDatosSalidas();
            tboxID.Clear();
            timer1.Stop();
            }
            catch
            {
                tboxID.Clear();
                timer1.Dispose();
                timer1.Stop();
                MessageBox.Show("No se encontró el producto seleccionado");
            }

        }

        private void tboxIDOrden_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tboxID_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
