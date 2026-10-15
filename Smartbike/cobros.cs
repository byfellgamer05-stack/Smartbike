using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Smartbike
{
    public partial class cobros : Form
    {
        public cobros()
        {
            InitializeComponent();
           

        }
        public void RecibirCliente(string id, string nombre, string numero,
                             string cedula, string direccion, string balance)
        {
            clienteid.Text = id;
            nombr.Text = nombre;
            telefon.Text = numero;

            cedul.Text = cedula;
            dire.Text = direccion;
            bal.Text = balance;

            DataTable dt = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("nombre");
            dt.Columns.Add("numero");
            dt.Columns.Add("cedula");
            dt.Columns.Add("direccion");
            dt.Columns.Add("balance");

            dt.Rows.Add(
                id,
                nombre,
                numero,
                cedula,
                direccion,
                balance
            );

            cobr.DataSource = dt;
        }
        void CargarBalance()
        {
            SQLiteConnection con = conexion.conectar();

            string query = "SELECT balance FROM clientes WHERE id = @id";

            SQLiteCommand cmd = new SQLiteCommand(query, con);

            cmd.Parameters.AddWithValue("@id", abon.Text);

            object resultado = cmd.ExecuteScalar();

            if (resultado != null)
            {
                abon.Text = resultado.ToString();
            }

            con.Close();
        }
        void RealizarAbono()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(clienteid.Text))
                {
                    MessageBox.Show("Seleccione un cliente primero.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(bal.Text) ||
                    string.IsNullOrWhiteSpace(abon.Text))
                {
                    MessageBox.Show("Digite el abono.");
                    return;
                }

                decimal balanceActual =
                Convert.ToDecimal(bal.Text.Replace(",", ""));

                decimal abono =
                Convert.ToDecimal(abon.Text.Replace(",", ""));

                decimal nuevoBalance =
                balanceActual - abono;

                if (nuevoBalance < 0)
                {
                    MessageBox.Show("El abono no puede ser mayor al balance.");
                    return;
                }

                using (SQLiteConnection con = conexion.conectar())
                {
                    string query =
                    @"UPDATE clientes
              SET balance=@balance
              WHERE id=@id";

                    using (SQLiteCommand cmd =
                    new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@balance", nuevoBalance);
                        cmd.Parameters.AddWithValue("@id", clienteid.Text.Trim());

                        int filas = cmd.ExecuteNonQuery();

                        if (filas == 0)
                        {
                            MessageBox.Show("No se encontró el cliente.");
                            return;
                        }
                    }
                }

                bal.Text = nuevoBalance.ToString("N2");

                PrintDocument pd = new PrintDocument();

                pd.PrintPage += (s, ev) =>
                {
                    Graphics g = ev.Graphics;

                    Font titulo = new Font("Arial", 16, FontStyle.Bold);
                    Font texto = new Font("Arial", 10);
                    Font negrita = new Font("Arial", 11, FontStyle.Bold);

                    int y = 10;

                    g.DrawString("SMART CYCLING", titulo, Brushes.Black, 45, y);
                    y += 25;

                    g.DrawString("Av. Nagua - San Francisco", texto, Brushes.Black, 20, y);
                    y += 16;

                    g.DrawString("Km 1 y medio", texto, Brushes.Black, 70, y);
                    y += 16;

                    g.DrawString("Tel: 809-496-3066", texto, Brushes.Black, 55, y);
                    y += 25;

                    g.DrawString("RECIBO DE ABONO", negrita, Brushes.Black, 55, y);
                    y += 25;

                    g.DrawString("Cliente: " + nombr.Text, texto, Brushes.Black, 10, y);
                    y += 22;

                    g.DrawString("ID: " + clienteid.Text, texto, Brushes.Black, 10, y);
                    y += 22;

                    g.DrawString("Telefono: " + telefon.Text, texto, Brushes.Black, 10, y);
                    y += 22;

                    g.DrawString("Direccion: " + dire.Text, texto, Brushes.Black, 10, y);
                    y += 22;

                    g.DrawString("Abono: RD$ " + abono.ToString("N2"), texto, Brushes.Black, 10, y);
                    y += 22;

                    g.DrawString("Nuevo Balance: RD$ " + nuevoBalance.ToString("N2"),
                        negrita, Brushes.Black, 10, y);
                    y += 25;

                    g.DrawString("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"),
                        texto, Brushes.Black, 10, y);
                    y += 35;

                    g.DrawString("Firma receptor:", texto, Brushes.Black, 10, y);
                    y += 25;
                    g.DrawLine(Pens.Black, 10, y, 140, y);

                    y += 30;

                    g.DrawString("Firma vendedor:", texto, Brushes.Black, 10, y);
                    y += 25;
                    g.DrawLine(Pens.Black, 10, y, 140, y);

                    y += 30;

                    g.DrawString("Gracias por preferirnos", negrita, Brushes.Black, 35, y);
                };

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = pd;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();

                    MessageBox.Show("Abono guardado correctamente.");

                    clienteid.Clear();
                    nombr.Clear();
                    telefon.Clear();
                    cedul.Clear();
                    dire.Clear();
                    abon.Clear();
                    bal.Clear();

                    cobr.DataSource = null;
                    cobr.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void cobros_Load(object sender, EventArgs e)
        {
          
            cobr.DataSource = null;

        }
        

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Buscar_cliente frm = new Buscar_cliente();
            frm.frmcobros = this;
            frm.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RealizarAbono();
        }

        private void cobr_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
    }

        private void direccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void abon_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                RealizarAbono();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            clienteid.Clear();
            nombr.Clear();
            telefon.Clear();
       cedul.Clear();
            dire.Clear();
            bal.Clear();
            abon.Clear();

            cobr.DataSource = null;

         abon.Focus();
        }
        

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void abon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}









