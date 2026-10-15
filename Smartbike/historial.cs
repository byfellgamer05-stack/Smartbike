using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Smartbike
{
    
    public partial class historial : Form
   {
      
        public historial()
        {
            
            
            InitializeComponent();
            

        }
        DataTable dt = new DataTable();
        public delegate void PasarArticulo(string cod, string art, string it, string precio);
        public event PasarArticulo ArticuloSeleccionado;
        public cant frmcant;
        public facturacion frmfacturacion;
        public DataGridView tablafac;
        void CargarDatos()
        {
            try
            {
                using (SQLiteConnection con = conexion.conectar())
                {
                    string query = @"
            SELECT 
            cod,
            cant,
            art,
            pre,
            trans,
            it,
            preciof
            FROM registro";

                    using (SQLiteDataAdapter da = new SQLiteDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        regis.DataSource = null;
                        regis.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message);
            }
        }
        void VerHistorial()
        {
            using (var con = conexion.conectar())
            {
                con.Open();

                string query = "SELECT * FROM registro";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        regis.DataSource = dt;
                    }
                }
            }
        }
        private void CargarRegistros()
        {
            using (var con = conexion.conectar())
            {
                string query = "SELECT * FROM registro";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        dt.Clear();

                        da.Fill(dt);

                        regis.DataSource = dt;
                    }
                }
            }
        }

        private void fac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;           
                e.SuppressKeyPress = true;  

               
                MessageBox.Show("Enter presionado en el grid");

            }
        }


      




        private void regis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dt == null) return;

            string texto = buscar.Text.Trim().Replace("'", "''");

            if (string.IsNullOrWhiteSpace(texto))
            {
                dt.DefaultView.RowFilter = "";
                regis.DataSource = dt;
                return;
            }

            dt.DefaultView.RowFilter =
                $"Convert(art,'System.String') LIKE '%{texto}%' OR " +
                $"Convert(it,'System.String') LIKE '%{texto}%' OR " +
                $"Convert(cod,'System.String') LIKE '%{texto}%'";

            regis.DataSource = dt.DefaultView;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void regis_DoubleClick(object sender, EventArgs e)
        {
        }



        private void regis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = regis.Rows[e.RowIndex];

            if (row == null || row.IsNewRow)
                return;

            string codigo = row.Cells[0].Value?.ToString() ?? "";
            string cantidad = "1";
            string articulo = row.Cells[2].Value?.ToString() ?? "";

            string itbis = row.Cells[3].Value?.ToString() ?? "0";
            string precio = row.Cells[4].Value?.ToString() ?? "0";

            string transporte = regis.Columns.Count > 5
                ? row.Cells[5].Value?.ToString() ?? "0"
                : "0";

            string preciof = regis.Columns.Count > 6
                ? row.Cells[6].Value?.ToString() ?? "0"
                : "0";

            if (frmfacturacion != null)
            {
                frmfacturacion.RecibirProducto(
                    codigo,
                    cantidad,
                    articulo,
                    precio,
                    itbis
                );
            }

            if (frmcant != null)
            {
                frmcant.RecibirProducto(
                    codigo,
                    cantidad,
                    articulo,
                    precio,
                    transporte,
                    itbis,
                    preciof
                );
            }

            this.Close();
        }
        private void regis_KeyDown(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void regis_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void historial_Load(object sender, EventArgs e)
        {
            CargarRegistros();
         
        }
    }
    }
    









