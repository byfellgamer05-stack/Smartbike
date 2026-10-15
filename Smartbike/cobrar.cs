using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartbike
{
    
    public partial class cobrar : Form
       
    {
        public DataGridView tablafac;

        public facturacion frmfactura;



        PrintDocument pd = new PrintDocument();

       
        public cobrar(decimal total, facturacion f)
        {
            InitializeComponent();
            
            frmfactura = f;

            tablafac = f.fac;


            totalf.Text = total.ToString("N2");
            paga.Text = total.ToString("N2");
        }

        private void ImprimirFactura(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font titulo = new Font("Arial", 18, FontStyle.Bold);
            Font texto = new Font("Arial", 10);
            Font negrita = new Font("Arial", 10, FontStyle.Bold);
            Font totalFont = new Font("Arial", 13, FontStyle.Bold);

            int y = 10;

            // ENCABEZADO
            g.DrawString(
            "SMART CYCLING",
            titulo,
            Brushes.Black,
            35,
            y);

            y += 30;

            g.DrawString(
            "Av. Nagua - San Francisco",
            texto,
            Brushes.Black,
            20,
            y);

            y += 18;

            g.DrawString(
            "Km 1 y medio",
            texto,
            Brushes.Black,
            70,
            y);

            y += 18;

            g.DrawString(
            "Tel: 809-496-3066",
            texto,
            Brushes.Black,
            50,
            y);

            y += 25;

            g.DrawString(
            "FACTURA CONTADO",
            negrita,
            Brushes.Black,
            55,
            y);

            y += 22;

            g.DrawString(
            "Fecha: "
            + DateTime.Now.ToString(
            "dd/MM/yyyy hh:mm tt"),
            texto,
            Brushes.Black,
            10,
            y);

            y += 20;

            // LINEA
            g.DrawLine(Pens.Black, 10, y, 300, y);

            y += 15;

            // TITULOS
            g.DrawString(
            "Articulo",
            negrita,
            Brushes.Black,
            10,
            y);

            g.DrawString(
            "Cant",
            negrita,
            Brushes.Black,
            150,
            y);

            g.DrawString(
            "Precio",
            negrita,
            Brushes.Black,
            220,
            y);

            y += 20;

            g.DrawLine(Pens.Black, 10, y, 300, y);

            y += 15;

            if (tablafac == null)
            {
                MessageBox.Show(
                "No hay datos para imprimir");
                return;
            }

            // DETALLE
            foreach (DataGridViewRow fila in tablafac.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                string articulo =
                fila.Cells[2].Value?.ToString()
                ?? "";

                string cantidad =
                fila.Cells[1].Value?.ToString()
                ?? "";

                string precio =
                fila.Cells[4].Value?.ToString()
                ?? "";

                if (articulo.Length > 12)
                {
                    articulo =
                    articulo.Substring(0, 12);
                }

                g.DrawString(
                articulo,
                texto,
                Brushes.Black,
                10,
                y);

                g.DrawString(
                cantidad,
                texto,
                Brushes.Black,
                160,
                y);

                g.DrawString(
                precio,
                texto,
                Brushes.Black,
                220,
                y);

                y += 22;
            }

            // LINEA FINAL
            y += 10;

            g.DrawLine(Pens.Black, 10, y, 300, y);

            y += 25;

            // TOTAL
            g.DrawString(
            "TOTAL:",
            totalFont,
            Brushes.Black,
            70,
            y);

            g.DrawString(
            totalf.Text,
            totalFont,
            Brushes.Black,
            160,
            y);

            y += 30;

            // DEVUELTA
            g.DrawString(
            "DEVUELTA:",
            totalFont,
            Brushes.Black,
            45,
            y);

            g.DrawString(
            cambio.Text,
            totalFont,
            Brushes.Black,
            160,
            y);

            y += 35;

            // MENSAJE FINAL
            g.DrawString(
            "Gracias por preferirnos",
            negrita,
            Brushes.Black,
            35,
            y);

            y += 20;

            g.DrawString(
            "Vuelva pronto!",
            texto,
            Brushes.Black,
            85,
            y);
        } 
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cobrar_Load(object sender, EventArgs e)
        {

        }

        private void paga_TextChanged(object sender, EventArgs e)
        {
            decimal total, recibido;

            if (!decimal.TryParse(totalf.Text, out total))
                return;

            if (!decimal.TryParse(paga.Text, out recibido))
            {
                cambio.Text = "";
                return;
            }

            decimal resultado = recibido - total; 

            if (resultado < 0)
            {
                cambio.Text = "0.00";
                return;
            }

            cambio.Text = resultado.ToString("N2");
        }

        private void paga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                cambio.Focus();
            }
        }

        private void paga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

           
        }

        private void cobrar_Shown(object sender, EventArgs e)
        {
            paga.Focus();
            paga.SelectAll(); 
        }

        private void totalf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                cr.Focus();
            }
    }

        private void cambio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                totalf.Focus();
            }
        }

        private void cr_Click(object sender, EventArgs e)
        {
            pd.PrintPage += ImprimirFactura;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();

                frmfactura.GuardarFactura();

              
                frmfactura.NuevaFactura();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}








