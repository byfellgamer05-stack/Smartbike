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
    public partial class menu : Form
    {
        Timer t = new Timer();
        public menu()
        {
            InitializeComponent();
        }
        private void menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void T_Tick(object sender, EventArgs e)
        {
           
            {
                GuardarCuadreDiario();
            }
        }
        void CrearTablas()
        {
            using (SQLiteConnection con = conexion.conectar())
            {
                string sql = @"
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
    fecha TEXT PRIMARY KEY,
    total NUMERIC DEFAULT 0,
    numfac INTEGER DEFAULT 0
);
      ";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
      
        void ActualizarBaseDatos()
        {
            using (SQLiteConnection con = conexion.conectar())
            {
                string sql = @"
        CREATE TABLE IF NOT EXISTS detalle_factura (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            numfa INTEGER,
            cod INTEGER,
            cant INTEGER
        );";

                using (SQLiteCommand cmd =
                new SQLiteCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        void GuardarCuadreDiario()
        {
            try
            {
                using (SQLiteConnection con = conexion.conectar())
                {
                    string hoy = DateTime.Today.ToString("yyyy-MM-dd");

                    // Calcular el total de las facturas del día
                    decimal total = 0;

                    string sqlTotal = @"
                SELECT COALESCE(SUM(total),0)
                FROM facturas
                WHERE date(fecha)=@fecha";

                    using (SQLiteCommand cmdTotal = new SQLiteCommand(sqlTotal, con))
                    {
                        cmdTotal.Parameters.AddWithValue("@fecha", hoy);

                        object resultado = cmdTotal.ExecuteScalar();

                        if (resultado != DBNull.Value)
                            total = Convert.ToDecimal(resultado);
                    }

                    // Verificar si ya existe el cuadre
                    string sqlExiste = "SELECT COUNT(*) FROM cuadres WHERE fecha=@fecha";

                    using (SQLiteCommand cmdExiste = new SQLiteCommand(sqlExiste, con))
                    {
                        cmdExiste.Parameters.AddWithValue("@fecha", hoy);

                        long existe = Convert.ToInt64(cmdExiste.ExecuteScalar());

                        if (existe == 0)
                        {
                            // Insertar
                            string sqlInsert = @"
                        INSERT INTO cuadres(fecha,total)
                        VALUES(@fecha,@total)";

                            using (SQLiteCommand cmdInsert = new SQLiteCommand(sqlInsert, con))
                            {
                                cmdInsert.Parameters.AddWithValue("@fecha", hoy);
                                cmdInsert.Parameters.AddWithValue("@total", total);

                                cmdInsert.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Actualizar
                            string sqlUpdate = @"
                        UPDATE cuadres
                        SET total=@total
                        WHERE fecha=@fecha";

                            using (SQLiteCommand cmdUpdate = new SQLiteCommand(sqlUpdate, con))
                            {
                                cmdUpdate.Parameters.AddWithValue("@fecha", hoy);
                                cmdUpdate.Parameters.AddWithValue("@total", total);

                                cmdUpdate.ExecuteNonQuery();
                            }
                        }
                    }

                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n\n" + ex.ToString());
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            facturacion frm = new facturacion();
            frm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            cant frm = new cant();
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            cuadre frm = new cuadre();
            frm.Show();

            
                GuardarCuadreDiario();
            
        }
        private void menu_Load(object sender, EventArgs e)
        {
            CrearTablas();
            t.Interval = 60000;
            t.Tick += T_Tick;
            t.Start();

           
              //  GuardarCuadreDiario();
            

            this.FormClosed += menu_FormClosed;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Eliminar frm = new Eliminar();
            frm.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Clientes frm = new Clientes();
            frm.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            cobros frm = new cobros();
            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    }
    

