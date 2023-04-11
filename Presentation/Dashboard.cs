using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Commun.Cache;
using System.IO.Ports;

namespace Presentation
{
    public partial class Dashboard : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
             int nLeftRect,
             int nTopRect,
             int nRightRect,
             int nBottomRect,
             int nWidthEllipse,
                int nHeightEllipse
            );

        public Dashboard()
        {
            InitializeComponent();
            openChildForm(new frmDashboard());

        }
       

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                
            activeForm.Close();
            activeForm = childForm;
            childForm.Dock = DockStyle.Fill;
            childForm.TopLevel = false;
            childForm.TopMost = true;
            childForm.FormBorderStyle = FormBorderStyle.None;
            pnlFormloader.Controls.Add(childForm);
            pnlFormloader.Tag = childForm;
            childForm.Show();
        }

        private void hideSubMenu()
        {
            if (pnlSubMenuE.Visible == true)
                pnlSubMenuE.Visible = false;
            if (pnlSubMenuS.Visible == true)
                pnlSubMenuS.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            loadUserData();
            Restricciones();
        }

        private void Restricciones()
        {
            if (UserLoginCache.Position != "Administrador")
            {
                btnConfigE.Enabled = false;
                btnConfigE.Visible = false;
                btnCancelarS.Enabled = false;
                btnCancelarS.Visible = false;
            }
        }

        private void loadUserData()
        {
            lblName.Text= UserLoginCache.FirstName+" "+ UserLoginCache.LastName;
            lblArea.Text = UserLoginCache.Area;
            lblCharge.Text = UserLoginCache.Position;
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(46, 51, 76);
            if (AppCache.StatusPort == 1) 
            {
                MessageBox.Show("Por favor desconecte la báscula");
            }
            else
            {
            openChildForm(new frmDashboard());
            hideSubMenu();
            }

            
        }

        //inicio menu entradas
        private void btnQuality_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuE);
        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 1)
            {
                MessageBox.Show("Por favor desconecte la báscula");
            }
            else
            {
                btnEntradas.BackColor = Color.FromArgb(46, 51, 76);
                openChildForm(new frmPrinter());
                hideSubMenu();
            }
        }

        private void btnReporteE_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 1)
            {
                MessageBox.Show("Por favor desconecte la báscula");
            }
            else
            {
                btnReporteE.BackColor = Color.FromArgb(46, 51, 76);
                openChildForm(new frmReportView());
                hideSubMenu();
     
            }
        }

        private void btnConfigE_Click(object sender, EventArgs e)
        {
            { if (AppCache.StatusPort == 1)
                {
                    MessageBox.Show("Por favor desconecte la báscula");
                }
                else
                {
                    btnConfigE.BackColor = Color.FromArgb(46, 51, 76);
                    openChildForm(new frmConfigE());
                    hideSubMenu();
                }
            }
        }
               
        //fin menú entradas

        //inicio menú salidas
        private void btnSubMenuS_Click(object sender, EventArgs e)
        {
            showSubMenu(pnlSubMenuS);
        }
        
        private void btnSalida_Click(object sender, EventArgs e)
            {
                if (AppCache.StatusPort == 1)
                {
                    MessageBox.Show("Por favor desconecte la báscula");
                }
                else
                {
                    btnSalida.BackColor = Color.FromArgb(46, 51, 76);
                    openChildForm(new frmSalidas());
                    hideSubMenu();
                }
            }
        private void btnReporteSa_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 1)
            {
                MessageBox.Show("Por favor desconecte la báscula");
            }
            else
            {
                btnReporteSa.BackColor = Color.FromArgb(46, 51, 76);
                openChildForm(new frmReportSalida());
                hideSubMenu();
            }
        }

        private void btnCancelarS_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 1)
            {
                MessageBox.Show("Por favor desconecte la báscula");
            }
            else
            {
                btnCancelarS.BackColor = Color.FromArgb(46, 51, 76);
                openChildForm(new frmConfigS());
                hideSubMenu();
            }
        }
        //fin menú salidas
        private void btnInventario_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 1)
            {
                MessageBox.Show("Por favor desconecte la báscula");
            }
            else
            {
                btnInventario.BackColor = Color.FromArgb(41, 58, 84);
                openChildForm(new frmReporteInventario());
                hideSubMenu();
                AppCache.StatusPort = 0;
            }
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 1)
            {
                MessageBox.Show("Por favor desconecte la báscula");
            }
            else
            {
                btnContact.BackColor = Color.FromArgb(46, 51, 76);
                openChildForm(new frmContact());
                hideSubMenu();
            }
        }
        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (AppCache.StatusPort == 1)
            {
                MessageBox.Show("Por favor desconecte la báscula");
            }
            else
            {
                btnConfig.BackColor = Color.FromArgb(46, 51, 76);
                openChildForm(new frmConfig());
                hideSubMenu();
            }
        }
          private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Estás seguro de cerrar sesión?", "Adveritencia", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
            }
            AppCache.StatusPort = 0;
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(41, 58, 84);
        }

        private void btnQuality_Leave(object sender, EventArgs e)
        {
            btnSubMenuE.BackColor = Color.FromArgb(41, 58, 84);
        }

        private void btnContact_Leave(object sender, EventArgs e)
        {
            btnContact.BackColor = Color.FromArgb(41, 58, 84);
        }

        private void btnConfig_Leave(object sender, EventArgs e)
        {
            btnConfig.BackColor = Color.FromArgb(41, 58, 84);
        }

        private void btnEntradas_Leave(object sender, EventArgs e)
        {
            btnEntradas.BackColor = Color.FromArgb(41, 58, 84);
        }

        private void btnReporteE_Leave(object sender, EventArgs e)
        {
            btnReporteE.BackColor = Color.FromArgb(41, 58, 84);
        }

        private void btnConfigE_Leave(object sender, EventArgs e)
        {
            btnConfigE.BackColor = Color.FromArgb(41, 58, 84);
        }

        private void btnSubMenuS_Leave(object sender, EventArgs e)
        {
            btnSubMenuS.BackColor = Color.FromArgb(41, 58, 84);
        }

        private void btnSalida_Leave(object sender, EventArgs e)
        {
            btnSalida.BackColor = Color.FromArgb(41, 58, 84);
        }

        private void btnReporteSa_Leave(object sender, EventArgs e)
        {
            btnReporteSa.BackColor = Color.FromArgb(41, 58, 84);
        }

        private void btnCancelarS_Leave(object sender, EventArgs e)
        {
            btnCancelarS.BackColor = Color.FromArgb(41, 58, 84);
        }

        private void btnInventario_Leave(object sender, EventArgs e)
        {
            btnInventario.BackColor = Color.FromArgb(41, 58, 84);
        }

        public void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Estás seguro de cerrar el programa?", "Adveritencia", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                    Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {

                if (AppCache.StatusPort==1)
                {
                    DialogResult dialogResult = MessageBox.Show("Por favor deconecte la báscula", "Adveritencia", MessageBoxButtons.OK);
                    if (dialogResult == DialogResult.OK)
                    {
                        e.Cancel = true;
                    }
                }
            
        }
    }
}
