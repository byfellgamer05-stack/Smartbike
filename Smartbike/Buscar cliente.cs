using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartbike
{
    public partial class Buscar_cliente : Form
    {
        DataTable dt = new DataTable();
        public Clientes frmClientes;
        public cobros frmcobros;
        public facturacion frmfacturacion;
      private Clientes formClientes;
        public Buscar_cliente()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        void CrearTablas()
        {
            using (SQLiteConnection con = conexion.conectar())
            {
                string sql = @"
        CREATE TABLE IF NOT EXISTS clientes (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            nombre TEXT NOT NULL,
            numero TEXT,
            cedula TEXT,
            direccion TEXT,
            balance NUMERIC DEFAULT 0
        );

        CREATE TABLE IF NOT EXISTS facturas (
            numfa INTEGER PRIMARY KEY AUTOINCREMENT,
            fecha TEXT,
            total NUMERIC
        );

        CREATE TABLE IF NOT EXISTS ingresos (
            fecha TEXT PRIMARY KEY,
            total NUMERIC DEFAULT 0
        );

        CREATE TABLE IF NOT EXISTS cuadres (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            fecha TEXT,
            total NUMERIC,
            numfac INTEGER
        );

        CREATE TABLE IF NOT EXISTS registro (
            cod INTEGER,
            cant NUMERIC,
            art TEXT,
            pre NUMERIC,
            trans TEXT,
            it TEXT,
            preciof NUMERIC,
            numfac INTEGER,
            fecha TEXT
        );";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        void CargarClientes()
        {
            using (SQLiteConnection con = conexion.conectar())
            {
                string query =
                "SELECT id,nombre,numero,cedula,direccion,balance FROM clientes";

                using (SQLiteCommand cmd =
                new SQLiteCommand(query, con))
                {
                    using (SQLiteDataAdapter da =
                    new SQLiteDataAdapter(cmd))
                    {
                        dt.Clear();

                        da.Fill(dt);

                        buscarc.DataSource = dt;
                    }
                }
            }
        }
        
        private void Buscar_cliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'eliteDataSet1.clientes' Puede moverla o quitarla según sea necesario.
            // this.clientesTableAdapter.Fill(this.eliteDataSet1.clientes);
            CrearTablas();
            CargarClientes();
        }

        private void buscarc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (frmfacturacion != null)
            {
                frmfacturacion.RecibirCliente(
                    buscarc.CurrentRow.Cells[0].Value.ToString(),
                    buscarc.CurrentRow.Cells[1].Value.ToString(),
                    buscarc.CurrentRow.Cells[2].Value.ToString(),
                    buscarc.CurrentRow.Cells[3].Value.ToString()
                );
            }

            if (frmcobros != null)
            {
                frmcobros.RecibirCliente(
              buscarc.CurrentRow.Cells[0].Value.ToString(), // id
              buscarc.CurrentRow.Cells[1].Value.ToString(), // nombre
              buscarc.CurrentRow.Cells[2].Value.ToString(), // numero
              buscarc.CurrentRow.Cells[3].Value.ToString(), // cedula
              buscarc.CurrentRow.Cells[4].Value.ToString(), // direccion
              buscarc.CurrentRow.Cells[5].Value.ToString()  // balance
                  );
            }

            if (frmClientes != null)
            {
                frmClientes.RecibirCliente(
                    buscarc.CurrentRow.Cells[1].Value.ToString(), // nombre
                    buscarc.CurrentRow.Cells[2].Value.ToString(), // numero
                    buscarc.CurrentRow.Cells[3].Value.ToString(), // cedula
                    buscarc.CurrentRow.Cells[4].Value.ToString()  // direccion
                );
            
        }

            this.Close();
        }

        private void Buscar_cliente_KeyDown(object sender, KeyEventArgs e)
        {
            this.KeyPreview = true;
        }

        private void buscarc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void ced_TextChanged(object sender, EventArgs e)
        {
            if (dt == null) return;

            string texto =
            ced.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(texto))
            {
                dt.DefaultView.RowFilter = "";
                buscarc.DataSource = dt;
                return;
            }

            dt.DefaultView.RowFilter =
                $"Convert(id,'System.String') LIKE '%{texto}%' OR " +
                $"Convert(nombre,'System.String') LIKE '%{texto}%' OR " +
                $"Convert(numero,'System.String') LIKE '%{texto}%' OR " +
                $"Convert(cedula,'System.String') LIKE '%{texto}%' OR " +
                $"Convert(direccion,'System.String') LIKE '%{texto}%'";

            buscarc.DataSource = dt.DefaultView;
        }

        private void ced_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
    }

    }

