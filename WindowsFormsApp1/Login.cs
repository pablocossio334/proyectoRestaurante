using capaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace capaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            Usuario user = new Usuario();
            user.NomUsuario = this.txtUsuario.Text;
            user.PswUsuario = this.txtPsw.Text;
            user.TipoUsuario = user.ObtengoTipoUsuario();
            if (user.TipoUsuario == -1)
            {
                this.lblInfo.ForeColor = Color.Red;
                this.lblInfo.Text = "ERROR USUARIO O CONTRASENA";
            }
            else
            {
                this.lblInfo.ForeColor = Color.Green;
                this.lblInfo.Text = "LOGIN OK " + user.TipoUsuario;
                if(user.TipoUsuario==1)
                new MenuAdmin().Show();
                if (user.TipoUsuario == 2)
                new formUser().Show();


            }
        }

        private void txtPsw_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
