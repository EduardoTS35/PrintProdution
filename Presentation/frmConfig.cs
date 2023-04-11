using Domain;
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

namespace Presentation
{
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
            
        }
            UserModel userModel = new UserModel();

        private void btnGuardarProductos_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Estas seguro de guardar los datos?", "Adveritencia", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    userModel.InsertarPRoductos(tboxIDProductos.Text, tboxAreaProductos.Text);
                    MessageBox.Show("Se guardo correctamente el nuevo producto");
                }
                else if (dialogResult == DialogResult.No)
                {
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se insertaron los datos por: " + ex);
            }
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Estas seguro de guardar los datos?", "Adveritencia", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    userModel.InsertarUSuarios(tboxNombre.Text, tboxApellido.Text, tboxUsuario.Text, tboxPass.Text, cmbCargo.Text, cmbArea.Text);
                    MessageBox.Show("Se guardo correctamente el nuevo usuario");
                }
                else if (dialogResult == DialogResult.No)
                {
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se insertaron los datos por: " + ex);
            }
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            if (UserLoginCache.Position != "Administrador")
            {
                btnGuardarUsuario.Enabled = false;
            }
        }
    }
}
