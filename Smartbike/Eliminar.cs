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
    public partial class Eliminar : Form
    {
        public Eliminar()
        {
            InitializeComponent();
        }
       
        private void BuscarFactura()
        {
            try
            {
                using (SQLiteConnection con = conexion.conectar())
                {
                    string query = @"SELECT * FROM facturas
                             WHERE CAST(numfa AS TEXT) LIKE @numfa";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@numfa", "%" + numfac.Text.Trim() + "%");

                        DataTable tabla = new DataTable();

                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                        {
                            da.Fill(tabla);
                        }

                        cua.DataSource = tabla;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }
        void MostrarCuadres()
        {
            // conexion.conectar() ya abre la conexión automáticamente
            using (var con = conexion.conectar())
            {
                string query = @"
            SELECT numfa, fecha, total 
            FROM facturas";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cua.AutoGenerateColumns = true;
                        cua.DataSource = dt;
                    }
                }
            } // Aquí el using se encarga de cerrar todo y liberar el archivo elite.db
        }


        void CargarFacturas()
            {
                using (var con = conexion.conectar())
                {
                    con.Open();

                    string query = "SELECT * FROM cuadres";

                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        using (var da = new SQLiteDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            cua.DataSource = dt;
                        }
                    }
                }
            }
        



        private void Eliminar_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'eliteDataSet1.facturas' Puede moverla o quitarla según sea necesario.
            //this.facturasTableAdapter1.Fill(this.eliteDataSet1.facturas);
            // TODO: esta línea de código carga datos en la tabla 'eliteDataSet.facturas' Puede moverla o quitarla según sea necesario.
          //  this.facturasTableAdapter.Fill(this.eliteDataSet.facturas);
            MostrarCuadres();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                if (cua.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una factura.");
                    return;
                }

                int numfa = Convert.ToInt32(cua.CurrentRow.Cells[0].Value);

                DialogResult r = MessageBox.Show(
                    "¿Seguro que deseas eliminar esta factura y devolver el stock?",
                    "Confirmar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r == DialogResult.No) return;

                using (SQLiteConnection con = conexion.conectar())
                {
                    string borrarFactura = "DELETE FROM facturas WHERE numfa = @numfa";

                    using (SQLiteCommand cmdFactura = new SQLiteCommand(borrarFactura, con))
                    {
                        cmdFactura.Parameters.AddWithValue("@numfa", numfa);
                        cmdFactura.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Factura eliminada.");

                BuscarFactura();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void numfac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                pictureBox5_Click(sender, EventArgs.Empty);
            }

        }
        private void numfac_TextChanged(object sender, EventArgs e)
        {
            BuscarFactura();
        }
        private void cua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
    

