using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smartbike
{
    public partial class cuadre : Form
    {
        Timer t = new Timer();
        public cuadre()
        {
            InitializeComponent();
        }
        void GuardarIngresoDiario()
        {
            using (var con = conexion.conectar())
            {
                try
                {
                    con.Open();

                    decimal totalFactura = Convert.ToDecimal(cuadret.Text);

                    string sql = @"
            INSERT INTO ingresos (fecha, total)
            VALUES (date('now'), @total)
            ON CONFLICT(fecha)
            DO UPDATE SET total = total + @total;
            ";

                    using (var cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@total", totalFactura);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        void ImprimirCuadre(string fecha, decimal total)
        {
            PrintDocument pd = new PrintDocument();

            pd.PrintPage += (s, e) =>
            {
                Font titulo = new Font("Arial", 16, FontStyle.Bold);
                Font normal = new Font("Arial", 10);

                int y = 20;

                e.Graphics.DrawString(
                    "SMART CYCLING",
                    titulo,
                    Brushes.Black,
                    80,
                    y);

                y += 40;

                e.Graphics.DrawString(
                    "CUADRE DIARIO",
                    titulo,
                    Brushes.Black,
                    70,
                    y);

                y += 50;

                e.Graphics.DrawString(
                    "Fecha: " + fecha,
                    normal,
                    Brushes.Black,
                    20,
                    y);

                y += 30;

                e.Graphics.DrawString(
                    "Total generado:",
                    normal,
                    Brushes.Black,
                    20,
                    y);

                e.Graphics.DrawString(
                    total.ToString("N2"),
                    normal,
                    Brushes.Black,
                    150,
                    y);

                y += 50;

                e.Graphics.DrawString(
                    "________________________",
                    normal,
                    Brushes.Black,
                    20,
                    y);

                y += 20;

                e.Graphics.DrawString(
                    "Firma Responsable",
                    normal,
                    Brushes.Black,
                    50,
                    y);
            };

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }
        void GuardarCuadreDiario()
        {
            using (SQLiteConnection con = conexion.conectar())
            {
                try
                {
                   

                    string hoy = DateTime.Today.ToString("yyyy-MM-dd");

                    
                    string totalQuery = @"
                SELECT COALESCE(SUM(total),0)
                FROM facturas
                WHERE date(fecha)=@fecha";

                    decimal total = 0;

                    using (SQLiteCommand totalCmd = new SQLiteCommand(totalQuery, con))
                    {
                        totalCmd.Parameters.AddWithValue("@fecha", hoy);
                        total = Convert.ToDecimal(totalCmd.ExecuteScalar());
                    }

                   
                    string verificar = @"
                SELECT COUNT(*)
                FROM cuadres
                WHERE date(fecha)=@fecha";

                    using (SQLiteCommand checkCmd = new SQLiteCommand(verificar, con))
                    {
                        checkCmd.Parameters.AddWithValue("@fecha", hoy);

                        long existe = Convert.ToInt64(checkCmd.ExecuteScalar());

                        if (existe == 0)
                        {
                          
                            string insert = @"
                        INSERT INTO cuadres(fecha,total)
                        VALUES(@fecha,@total)";

                            using (SQLiteCommand cmd = new SQLiteCommand(insert, con))
                            {
                                cmd.Parameters.AddWithValue("@fecha", hoy);
                                cmd.Parameters.AddWithValue("@total", total);

                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string update = @"
                        UPDATE cuadres
                        SET total=@total
                        WHERE date(fecha)=@fecha";

                            using (SQLiteCommand cmd = new SQLiteCommand(update, con))
                            {
                                cmd.Parameters.AddWithValue("@fecha", hoy);
                                cmd.Parameters.AddWithValue("@total", total);

                                cmd.ExecuteNonQuery();
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
         











        private void T_Tick(object sender, EventArgs e)
        {
           GuardarCuadreDiario();

            CargarFacturasHoy();
        }
        private void cuadres_Load(object sender, EventArgs e)
        {
            CargarFacturasHoy();

            t.Interval = 60000;
            t.Tick += T_Tick;
            t.Start();
        }
        void CargarFacturasHoy()
        {
            
            using (var con = conexion.conectar())
            {
                string hoy = DateTime.Today.ToString("yyyy-MM-dd");

                
                string query = @"
            SELECT numfa, fecha, total 
            FROM facturas 
            WHERE date(fecha) = @fecha";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@fecha", hoy);

                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cua.DataSource = dt;
                    }
                }
            } 
        }
        void CargarCuadre()
        {
            
            using (var con = conexion.conectar())
            {
                string query = "SELECT COALESCE(SUM(total), 0) FROM facturas";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    decimal total = Convert.ToDecimal(cmd.ExecuteScalar());

                  
                    cuadret.Text = total.ToString("N2");
                }
            }
        }

        void MostrarCuadre()
        {
            
            using (var con = conexion.conectar())
            {
                
                string query = @"
            SELECT COALESCE(SUM(total), 0)
            FROM facturas
            WHERE date(fecha) = date('now', 'localtime')";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    decimal total = Convert.ToDecimal(cmd.ExecuteScalar());

                    cuadret.Text = total.ToString("N2");
                }
            } 
        }
        void LimpiarCuadresAntiguos()
        {
            using (var con = conexion.conectar())
            {
                try
                {
                    string sql = @"
            DELETE FROM ingresos
            WHERE fecha < date('now','-30 day');
            ";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error eliminando cuadres: " + ex.Message);
                }
            }
        }
        private void cuadre_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.cuadres' Puede moverla o quitarla según sea necesario.
            this.cuadresTableAdapter.Fill(this.dataSet1.cuadres);
            LimpiarCuadresAntiguos();

            CargarCuadre();
            MostrarCuadre();
            CargarFacturasHoy();

            t.Interval = 60000;
            t.Tick += T_Tick;
            t.Start();
        }


        private void Buscar_Click(object sender, EventArgs e)
        {
            buscar_cuadre frm = new buscar_cuadre();

            frm.Show();
        }

        private void cua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            try
            {
                decimal totalDia;

                if (!decimal.TryParse(cuadret.Text.Replace(",", ""), out totalDia))
                {
                    MessageBox.Show("El total es inválido.");
                    return;
                }

                string fecha = DateTime.Today.ToString("yyyy-MM-dd");

                ImprimirCuadre(fecha, totalDia);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}















