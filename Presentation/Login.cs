using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;

namespace Presentation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtUser_Enter(object sender, EventArgs e)
        {
            {
                if (txtUser.Text == "USUARIO")
                {
                    txtUser.Text = "";
                    txtUser.ForeColor = Color.DimGray;
                }
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DarkGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.DarkGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DarkGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "USUARIO")
            {
                if (txtPass.Text != "CONTRASEÑA")
                {
                    UserModel user = new UserModel();
                    var validLogin = user.LoginUser(txtUser.Text,txtPass.Text);
                    if (validLogin == true)
                    {
                        Dashboard mainMenu = new Dashboard();
                        mainMenu.FormClosed += Logout;
                        mainMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        msgerror("Usuario o contraseña incorrecta. \n Por favor vuelva a intentralo");
                        txtPass.Text="CONTRASEÑA";
                        txtPass.UseSystemPasswordChar = false;
                        txtUser.Clear();
                        txtUser.Focus();
                    }
                }
                else msgerror("Por favor ingrese su contraseña");
            }
            else msgerror("Por favor ingrese su Usuario");
        }
        
        private void msgerror(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
        }

        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtUser.Text = "USUARIO";
            txtPass.Text= "CONTRASEÑA";
            txtPass.UseSystemPasswordChar = false;
            lblError.Visible = false;
            this.Show();
            txtUser.Focus();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
