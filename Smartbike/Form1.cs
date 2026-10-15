using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Smartbike
{
    public partial class entrada : Form
    {
        public entrada()
        {
            InitializeComponent();
            this.Shown += Entrada_Shown;
        }

        private void Entrada_Shown(object sender, EventArgs e)
        {
            clave.Focus();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            string user = usuario.Text;
            string pass = clave.Text;

            if (user == "smart" && pass == "123")
            {
                menu frm = new menu();
                frm.Show();

              
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }






        private void entrada_Load(object sender, EventArgs e)
        {
            clave.UseSystemPasswordChar = true;
            clave.Focus();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void clave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (clave.Text == "123")
                {
                    menu frm = new menu();

                    frm.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Clave incorrecta");
                }
            }
        }
    }
    }

