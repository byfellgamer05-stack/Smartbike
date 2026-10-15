using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartbike
{
    public partial class Clientes : Form
    {
       
        List<ClienteTemporal> listaSesion = new List<ClienteTemporal>();
        public Clientes()
        {
            InitializeComponent();
        }
        public class ClienteTemporal
        {
            
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Numero { get; set; }
            public string Cedula { get; set; }
            public string Direccion { get; set; }
            public decimal Balance { get; set; }
        }
        public void RecibirCliente(string nombre, string numero, string cedula, string direccion)
        {
            nom.Text = nombre;
            num.Text = numero;
            ced.Text = cedula;
            dir.Text = direccion;
        }
        private void CargarTablaClientes()
        {
            try
            {
                using (SQLiteConnection con = conexion.conectar())
                {
                    string query = @"SELECT id, nombre, numero, cedula, direccion, balance 
                             FROM clientes";

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        fac.DataSource = null;
                        fac.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }
        void CrearTablaClientes()
        {
            using (SQLiteConnection con = conexion.conectar())
            {
                string sql = @"CREATE TABLE IF NOT EXISTS clientes (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            nombre TEXT,
            numero TEXT,
            cedula TEXT,
            direccion TEXT,
            balance REAL DEFAULT 0
        )";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

               
            
        private void pictureBox3_Click(object sender, EventArgs e)
        
        {


            try
            {
                using (SQLiteConnection con = conexion.conectar())
                {
                    string query = @"INSERT INTO clientes
            (nombre, numero, cedula, direccion, balance)
            VALUES
            (@nombre, @numero, @cedula, @direccion, @balance)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nom.Text);
                        cmd.Parameters.AddWithValue("@numero", num.Text);
                        cmd.Parameters.AddWithValue("@cedula", ced.Text);
                        cmd.Parameters.AddWithValue("@direccion", dir.Text);
                        cmd.Parameters.AddWithValue("@balance", 0);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente guardado correctamente");

                nom.Clear();
                num.Clear();
                ced.Clear();
                dir.Clear();
                nom.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message);
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = conexion.conectar();

            try
            {
                if (string.IsNullOrWhiteSpace(ced.Text))
                {
                    MessageBox.Show("Digite la cédula");
                    return;
                }

                DialogResult r = MessageBox.Show(
                    "¿Deseas eliminar este cliente?",
                    "Eliminar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    string query =
                    "DELETE FROM clientes WHERE cedula=@cedula";

                    SQLiteCommand cmd =
                    new SQLiteCommand(query, con);

                    cmd.Parameters.AddWithValue("@cedula",
                    ced.Text);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        MessageBox.Show("Cliente eliminado");

                        nom.Clear();

                        num.Clear();

                        ced.Clear();

                        dir.Clear();

                        nom.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            CrearTablaClientes();
           
            // TODO: esta línea de código carga datos en la tabla 'eliteDataSet1.clientes' Puede moverla o quitarla según sea necesario.
          //  this.clientesTableAdapter.Fill(this.eliteDataSet1.clientes);
            num.Text = "800-000-000";

            ced.Text = "000-0000000-0";
            fac.DataSource = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ced_Enter(object sender, EventArgs e)
        {
            if (ced.Text == "000-0000000-0")
            {
                ced.Clear();
            }
        }

        private void num_Enter(object sender, EventArgs e)
        {
            if (num.Text == "800-000-000")
            {
                num.Clear();

            }
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            try
            {
                CrearTablaClientes();

                using (SQLiteConnection con = conexion.conectar())
                {
                    string query = @"INSERT INTO clientes
        (nombre, numero, cedula, direccion, balance)
        VALUES
        (@nombre, @numero, @cedula, @direccion, @balance)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nom.Text);
                        cmd.Parameters.AddWithValue("@numero", num.Text);
                        cmd.Parameters.AddWithValue("@cedula", ced.Text);
                        cmd.Parameters.AddWithValue("@direccion", dir.Text);
                        cmd.Parameters.AddWithValue("@balance", 0);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Cliente guardado");

                nom.Clear();
                num.Clear();
                ced.Clear();
                dir.Clear();
                nom.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            SQLiteConnection con = conexion.conectar();

            try
            {
                if (string.IsNullOrWhiteSpace(ced.Text))
                {
                    MessageBox.Show("Digite la cédula");
                    return;
                }

                DialogResult r = MessageBox.Show(
                    "¿Deseas eliminar este cliente?",
                    "Eliminar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    string query =
                    "DELETE FROM clientes WHERE cedula=@cedula";

                    SQLiteCommand cmd =
                    new SQLiteCommand(query, con);

                    cmd.Parameters.AddWithValue("@cedula", ced.Text);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        MessageBox.Show("Cliente eliminado");

                        // LIMPIAR CUADROS DE TEXTO
                        nom.Clear();

                        num.Clear();

                        ced.Clear();

                        dir.Clear();

                        nom.Focus();

                        // LIMPIAR LISTA Y REFRESCAR TABLA
                        listaSesion.Clear();

                        CargarTablaClientes();
                    }
                    else
                    {
                        MessageBox.Show("Cliente no encontrado");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Buscar_cliente frm = new Buscar_cliente();
            frm.frmClientes = this;
            frm.ShowDialog();
        }

        private void fac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtenemos la fila completa a la que se le hizo clic
                DataGridViewRow fila = fac.Rows[e.RowIndex];

                // Pasamos los valores usando el número de posición de cada columna
                nom.Text = fila.Cells[1].Value?.ToString(); // Columna 1: nombre
                num.Text = fila.Cells[2].Value?.ToString(); // Columna 2: numero
                ced.Text = fila.Cells[3].Value?.ToString(); // Columna 3: cedula
                dir.Text = fila.Cells[4].Value?.ToString(); // Columna 4: direccion
            }
        }
    }
    }
    

