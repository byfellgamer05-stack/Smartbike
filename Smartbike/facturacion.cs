using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Smartbike;
using static System.Net.Mime.MediaTypeNames;


namespace Smartbike
{
   
    public partial class facturacion : Form
       
    {
        bool esCredito = false;

    
        PrintDocument pd = new PrintDocument();
        public facturacion()
        {
        
        InitializeComponent();
         


            cod.KeyDown += cod_KeyDown;

            fac.DataSource = null;
            fac.AutoGenerateColumns = false;
            fac.Rows.Clear();
            fac.Columns.Clear();

            fac.Columns.Add("cod", "Código");
            fac.Columns.Add("cant", "Cantidad");
            fac.Columns.Add("art", "Artículo");
            fac.Columns.Add("precio", "Precio");
            fac.Columns.Add("total", "Total");



        }

        public string idcliente = "";
        public string nombrecliente = "";


        public void NuevaFactura()
        {
            cod.Clear();
            art.Clear();
            pr.Clear();
            it.Clear();
            can.Clear();

            nomb.Clear();
            iden.Clear();
            nume.Clear();

            total.Clear();

            tabla.Clear();

            idcliente = "";
            fac.Rows.Clear();

            cod.Focus();
        }

        decimal CalcularTotalFactura()
        {
            decimal suma = 0;

            foreach (DataGridViewRow fila in fac.Rows)
            {
                if (fila.IsNewRow) continue;

                decimal valor = 0;

                decimal.TryParse(
                    fila.Cells[4].Value?.ToString().Replace(",", ""),
                    out valor
                );

                suma += valor;
            }

            return suma;
        } 
        public void RecibirProducto(
string codigo,
string cantidad,
string articulo,
string precio,
string itbis)
        {
            cod.Text = codigo;
            can.Text = cantidad;
            art.Text = articulo;
            pr.Text = precio;
            it.Text = itbis;
        }
        void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Imprimir(sender, e, false);
        }

        void Imprimir(object sender, PrintPageEventArgs e, bool esCredito)
        {
            Graphics g = e.Graphics;

            Font titulo =
            new Font("Arial", 16, FontStyle.Bold);

            Font texto =
            new Font("Arial", 10);

            Font negrita =
            new Font("Arial", 11, FontStyle.Bold);

            Font totalFont =
            new Font("Arial", 14, FontStyle.Bold);

            int y = 10;

            // ENCABEZADO
            g.DrawString(
            "SMART CYCLING",
            titulo,
            Brushes.Black,
            45,
            y);

            y += 25;

            g.DrawString(
            "Av. Nagua - San Francisco",
            texto,
            Brushes.Black,
            20,
            y);

            y += 16;

            g.DrawString(
            "Km 1 y medio",
            texto,
            Brushes.Black,
            70,
            y);

            y += 16;

            g.DrawString(
            "Tel: 809-496-3066",
            texto,
            Brushes.Black,
            55,
            y);

            y += 22;

           
            g.DrawString(
            esCredito
            ? "FACTURA CRÉDITO"
            : "FACTURA CONTADO",

            negrita,
            Brushes.Black,
            45,
            y);

            y += 25;

            // FECHA
            g.DrawString(
            "Fecha: "
            + DateTime.Now.ToString(
            "dd/MM/yyyy hh:mm tt"),

            texto,
            Brushes.Black,
            10,
            y);

            y += 22;

            // CLIENTE
            g.DrawString(
            "Cliente: "
            + nomb.Text,

            texto,
            Brushes.Black,
            10,
            y);

            y += 25;

           
            g.DrawLine(
            Pens.Black,
            10,
            y,
            300,
            y);

            y += 15;

            
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
            145,
            y);

            g.DrawString(
            "Total",
            negrita,
            Brushes.Black,
            220,
            y);

            y += 20;

            g.DrawLine(
            Pens.Black,
            10,
            y,
            300,
            y);

            y += 15;

           
            foreach (DataGridViewRow row in fac.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string articulo =
                row.Cells[2].Value?.ToString()
                ?? "";

                string cantidad =
                row.Cells[1].Value?.ToString()
                ?? "";

                string totalLinea =
                row.Cells[4].Value?.ToString()
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
                155,
                y);

                g.DrawString(
                totalLinea,
                texto,
                Brushes.Black,
                220,
                y);

                y += 22;
            }

            y += 15;

            g.DrawLine(
            Pens.Black,
            10,
            y,
            300,
            y);

            y += 25;

            // TOTAL
            g.DrawString(
            "TOTAL: RD$ "
            + total.Text,

            totalFont,
            Brushes.Black,
            20,
            y);

            y += 40;

            // SOLO SI ES CRÉDITO
            if (esCredito)
            {
                g.DrawString(
                "Firma receptor:",
                texto,
                Brushes.Black,
                10,
                y);

                y += 25;

                g.DrawLine(
                Pens.Black,
                10,
                y,
                140,
                y);

                y += 30;

                g.DrawString(
                "Firma vendedor:",
                texto,
                Brushes.Black,
                10,
                y);

                y += 25;

                g.DrawLine(
                Pens.Black,
                10,
                y,
                140,
                y);

                y += 35;
            }

            
            g.DrawString(
            "Gracias por preferirnos",

            negrita,
            Brushes.Black,
            35,
            y);

            y += 18;

            g.DrawString(
            "Vuelva pronto!",

            texto,
            Brushes.Black,
            85,
            y);
        }
        void ImprimirFactura(bool credito)
        {
            PrintDocument pd = new PrintDocument();

            pd.PrintPage += (sender, e) =>
            {
                Imprimir(sender, e, credito);
            };


            PrintDialog dialogo = new PrintDialog();
            dialogo.Document = pd;

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }
        void ActualizarBalanceCliente()
        {
            try
            {
                MessageBox.Show(
                "ID Cliente = " + idcliente +
                "\nTotal = " + total.Text);

                SQLiteConnection con = conexion.conectar();

                string query = @"UPDATE clientes
                         SET balance = IFNULL(balance,0) + @monto
                         WHERE id = @id";

                SQLiteCommand cmd =
                new SQLiteCommand(query, con);

                cmd.Parameters.AddWithValue("@monto",
                Convert.ToDecimal(total.Text));

                cmd.Parameters.AddWithValue("@id",
                Convert.ToInt32(idcliente));

                int filas = cmd.ExecuteNonQuery();

                MessageBox.Show(
                "Filas afectadas: " + filas);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }   
        public void RecibirCliente(string id, string nombre, string cedula, string telefono)
        {
            idcliente = id;

            nomb.Text = nombre;

            iden.Text = cedula;

            nume.Text = telefono;
        }

       
           
        private void GenerarNumeroFactura()
        {
            using (SQLiteConnection con = conexion.conectar())
            {
               
                string query = "SELECT IFNULL(MAX(id), 0) + 1 FROM facturas";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    int numeroFactura = Convert.ToInt32(cmd.ExecuteScalar());
                    numfac.Text = numeroFactura.ToString("000000");
                }
            } 
        }

        public void GuardarFactura()
        {
            using (SQLiteConnection con = conexion.conectar())
            {
                try
                {
                    string facturaQuery = @"
            INSERT INTO facturas(fecha,total)
            VALUES(@fecha,@total);
            SELECT last_insert_rowid();";

                    using (SQLiteCommand facturaCmd = new SQLiteCommand(facturaQuery, con))
                    {
                        facturaCmd.Parameters.AddWithValue("@fecha", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        facturaCmd.Parameters.AddWithValue("@total", Convert.ToDecimal(total.Text.Replace(",", "")));

                        int numeroFactura = Convert.ToInt32(facturaCmd.ExecuteScalar());
                        numfac.Text = numeroFactura.ToString("000000");
                    }

                    foreach (DataGridViewRow fila in fac.Rows)
                    {
                        if (fila.IsNewRow) continue;

                        string codigo = fila.Cells[0].Value?.ToString().Trim() ?? "";
                        int cantVendida = Convert.ToInt32(fila.Cells[1].Value);

                        if (codigo == "")
                        {
                            MessageBox.Show("Código vacío en la factura");
                            continue;
                        }

                        string update = @"
                UPDATE registro
                SET cant = cant - @cant
                WHERE cod = @cod";

                        using (SQLiteCommand cmd = new SQLiteCommand(update, con))
                        {
                            cmd.Parameters.AddWithValue("@cant", cantVendida);
                            cmd.Parameters.AddWithValue("@cod", codigo);

                            int filas = cmd.ExecuteNonQuery();

                            if (filas == 0)
                            {
                                MessageBox.Show("Ese código no existe en registro: " + codigo);
                            }
                        }

                        string stockQuery =
                        "SELECT cant FROM registro WHERE cod=@cod";

                        using (SQLiteCommand stockCmd = new SQLiteCommand(stockQuery, con))
                        {
                            stockCmd.Parameters.AddWithValue("@cod", codigo);

                            int stockActual = Convert.ToInt32(stockCmd.ExecuteScalar());

                            if (stockActual <= 5)
                            {
                                MessageBox.Show(
                                "⚠ Pocas unidades del artículo " +
                                codigo +
                                "\nQuedan: " +
                                stockActual);
                            }
                        }
                    }

                    MessageBox.Show("Factura guardada correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar factura: " + ex.Message);
                }
            }
        }








        void AbrirCobrar()
        {
            decimal totalValor;

            if (!decimal.TryParse(total.Text, out totalValor))
            {
                MessageBox.Show("Total inválido");
                return;
            }

            cobrar frm = new cobrar(totalValor, this);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                GuardarFactura();
                NuevaFactura();
            }
        }

        public void MostrarSiguienteFactura()
        {
            SQLiteConnection con = conexion.conectar();

            string query = "SELECT IFNULL(MAX(numfa),0) + 1 FROM facturas";

            SQLiteCommand cmd = new SQLiteCommand(query, con);

            int siguiente = Convert.ToInt32(cmd.ExecuteScalar());

            numfac.Text = siguiente.ToString("000000");

            con.Close();
        }

        void LimpiarTodo()
        {
            cod.Clear();
            art.Clear();
            pr.Clear();
            it.Clear();
            nomb.Clear();
            iden.Clear();
            nume.Clear();

            
            if (fac.CurrentRow != null &&
                !fac.CurrentRow.IsNewRow)
            {
                fac.Rows.Remove(fac.CurrentRow);
            }

            CalcularTotal();

            cod.Focus();
        }
        void LimpiarCampos()
        {
            cod.Clear();
            art.Clear();
            pr.Clear();
            it.Clear();
            can.Clear();
            total.Clear();
            

            cod.Focus();
        }

        DataTable tb = new DataTable();
        public delegate void PasarArticulo(string cod, string art, string it, string precio);
        public event PasarArticulo ArticuloSeleccionado;
        private void RecibirArticulo(string codR, string artR, string itR, string precioR)
        {
            cod.Text = codR;
            art.Text = artR;
            it.Text = itR;
            pr.Text = precioR;

            can.Text = "1";
            can.Focus();
            can.SelectAll();
        }


        void LimpiarCamposs()
        {
            cod.Clear();
            can.Clear();
            art.Clear();
           pr.Clear();
            it.Clear();
            
        }

        private void BuscarArticulo()
        {
            if (string.IsNullOrWhiteSpace(cod.Text))
                return;

            SQLiteConnection con = conexion.conectar();

            string query = "SELECT * FROM registro WHERE cod = @cod";

            SQLiteCommand cmd = new SQLiteCommand(query, con);

            cmd.Parameters.AddWithValue("@cod", cod.Text);

            SQLiteDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                art.Text = dr["art"].ToString();

                it.Text = dr["it"].ToString();

                
                pr.Text = dr["preciof"].ToString();

                can.Text = "1";

                can.Focus();

                can.SelectAll();
            }
            else
            {
                MessageBox.Show("Artículo no encontrado");
            }

            con.Close();
        }
        private void cod_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.IsInputKey = true;
            }
        }

        private void GenerarFactura()
        {
            SQLiteConnection con = conexion.conectar();

            string query = "SELECT IFNULL(MAX(factura),0) + 1 FROM registro";

            SQLiteCommand cmd = new SQLiteCommand(query, con);

            int nuevoCodigo = Convert.ToInt32(cmd.ExecuteScalar());

            numfac.Text = nuevoCodigo.ToString("000000");

            con.Close();
        }
        void AgregarAFactura()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cod.Text) ||
                    string.IsNullOrWhiteSpace(can.Text) ||
                    string.IsNullOrWhiteSpace(art.Text) ||
                    string.IsNullOrWhiteSpace(pr.Text))
                {
                    
                    return;
                }

                int cantidad = Convert.ToInt32(can.Text);
                decimal precio = Convert.ToDecimal(pr.Text.Replace(",", ""));
                decimal totalFila = cantidad * precio;

                bool existe = false;

                foreach (DataGridViewRow row in fac.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.Cells["cod"].Value?.ToString() == cod.Text.Trim())
                    {
                       
                        row.Cells["cant"].Value = cantidad;
                        row.Cells["precio"].Value = precio;
                        row.Cells["total"].Value = totalFila;

                        existe = true;
                        break;
                    }
                }

                if (!existe)
                {
                    fac.Rows.Add(
                        cod.Text.Trim(),
                        cantidad,
                        art.Text.Trim(),
                        precio,
                        totalFila
                    );
                }

                CalcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message);
            }
        }


        private void CalcularTotal()
        {
            decimal totalGeneral = 0;

            foreach (DataGridViewRow row in fac.Rows)
            {
                if (row.IsNewRow) continue;

                decimal valor;

                if (row.Cells["total"].Value != null &&
                    decimal.TryParse(
                    row.Cells["total"].Value.ToString(),
                    out valor))
                {
                    totalGeneral += valor;
                }
            }

            total.Text = totalGeneral.ToString("N2");
        }
        private void cant_Load(object sender, EventArgs e)
        {
            fac.AllowUserToAddRows = false;

           

        }

        void GenerarCodigo()
        {
            SQLiteConnection con = conexion.conectar();

            string query = "SELECT IFNULL(MAX(cod), 0) + 1 FROM registro";

            SQLiteCommand cmd = new SQLiteCommand(query, con);

            int nuevoCodigo = Convert.ToInt32(cmd.ExecuteScalar());

            cod.Text = nuevoCodigo.ToString();

            con.Close();
        }
        DataTable tabla = new DataTable();
        bool codigoBloqueado = false;
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox text = sender as System.Windows.Forms.TextBox;
            text.BackColor = Color.White;
        }


      


        private void ActivarModoNavegacion()
        {
            if (this.ActiveControl is System.Windows.Forms.TextBox txt)
            {
                txt.BackColor = Color.LightBlue;
                txt.SelectAll();
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Control txt = (Control)sender;

            if (txt == pr)
            {
                if (e.KeyCode == Keys.Left)
                {
                    e.Handled = true;
                    return;
                }

                if (e.KeyCode == Keys.Right)
                {
                    cod.Focus();
                    cod.SelectAll();
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                this.SelectNextControl(txt, true, true, true, true);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                this.SelectNextControl(txt, false, true, true, true);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.BackColor = Color.LightBlue;
            txt.SelectAll();
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.BackColor = Color.White;
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt != null)
            {
                txt.BackColor = Color.White; 
            }
        }
        public void NuevaFacturaa ()
        {
            LimpiarCampos();
            GenerarNumeroFactura();
        }
        void AgregarEventos(Control contenedor)
        {
            foreach (Control c in contenedor.Controls)
            {
                if (c is TextBox txt)
                {
                    
                    if (txt != cod && txt != can)
                    {
                        txt.KeyDown += TextBox_KeyDown;
                    }

                    txt.Enter += TextBox_Enter;
                    txt.Leave += TextBox_Leave;
                }

                if (c.HasChildren)
                {
                    AgregarEventos(c);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void facturacion_Load(object sender, EventArgs e)
        {
            
         

            fac.AutoGenerateColumns = true;
            fac.DataSource = tabla;
           
            AgregarEventos(this);
            cod.Focus();

            fac.DataSource = null;

            fac.Columns.Clear();

            fac.Columns.Add("cod", "Codigo");
            fac.Columns.Add("cant", "Cantidad");
            fac.Columns.Add("art", "Articulo");
            fac.Columns.Add("precio", "Precio");
            fac.Columns.Add("total", "Total");

            MostrarSiguienteFactura();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void cod_KeyDown(object sender, KeyEventArgs e)
       
        {
            
                if (e.KeyCode == Keys.Right)
            {
                can.Focus();
                can.SelectAll();
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                pr.Focus();
                pr.SelectAll();
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                BuscarArticulo();

                return;
            }

            if (e.KeyCode == Keys.Escape)
            {
                cod.BackColor = Color.LightBlue;
                cod.SelectAll();
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                AgregarAFactura();

                if (fac.Rows.Count > 0)
                {
                    int ultimaFila = fac.Rows.Count - 1;

                    fac.ClearSelection();

                    fac.Rows[ultimaFila].Selected = true;

                    fac.CurrentCell = fac.Rows[ultimaFila].Cells[0];

                    
                }

                LimpiarCamposs();

                cod.Focus();
                cod.SelectAll();

                return;
            }
        }



        private void cod_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cod.Clear();
            can.Clear();
            art.Clear();
            pr.Clear();
            it.Clear();
         

            cod.Focus();
            LimpiarCamposs();

          
        }

        private void can_KeyDown(object sender, KeyEventArgs e)
        {

            TextBox txt = sender as TextBox;

            if (e.KeyCode == Keys.F7)
            {
                historial frm = new historial();

                frm.ArticuloSeleccionado += RecibirArticulo;

                frm.ShowDialog();

                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                AgregarAFactura();

                LimpiarCamposs();

                cod.Focus();
                cod.SelectAll();

                return;
            }

            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                AgregarAFactura();

                if (fac.Rows.Count > 0)
                {
                    int ultimaFila = fac.Rows.Count - 1;

                    fac.ClearSelection();
                    fac.Rows[ultimaFila].Selected = true;
                    fac.CurrentCell = fac.Rows[ultimaFila].Cells[0];

                   
                }

                LimpiarCamposs();

                cod.Focus();
                cod.SelectAll();

                return;
            }

            if (e.KeyCode == Keys.Right)
            {
                this.SelectNextControl(txt, true, true, true, true);
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                this.SelectNextControl(txt, false, true, true, true);
                e.SuppressKeyPress = true;
                return;
            }
        }





        private void pictureBox4_Click(object sender, EventArgs e)
        {
            historial h = new historial();

            h.frmfacturacion = this;

            h.ShowDialog();

        }

        private void facturacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                historial h = new historial();

                h.frmfacturacion = this;
                h.ArticuloSeleccionado += RecibirArticulo;

                h.ShowDialog();
            }

            if (e.KeyCode == Keys.F12)
            {
               

                AbrirCobrar();
               
            }
            if (e.KeyCode == Keys.F6)
            {
                Buscar_cliente frm = new Buscar_cliente();
                frm.ShowDialog();
            }
        }
    

        private void fac_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
            }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

           
           LimpiarTodo();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            decimal totalGeneral;
            if (!decimal.TryParse(total.Text, out totalGeneral))
            {
                MessageBox.Show("Total inválido"); return;
            }
            cobrar frm = new cobrar(totalGeneral, this); frm.ShowDialog();
        }
        
        private void total_TextChanged(object sender, EventArgs e)
        {

        }

        private void pr_TextChanged(object sender, EventArgs e)
        {

        }

        private void art_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (e.KeyCode == Keys.Right)
            {
                this.SelectNextControl(txt, true, true, true, true);
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                can.Focus();
                can.SelectAll();
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                AgregarAFactura();

                LimpiarCamposs();

                cod.Focus();
                cod.SelectAll();

                return;
            }

            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                AgregarAFactura();

                if (fac.Rows.Count > 0)
                {
                    int ultimaFila = fac.Rows.Count - 1;

                    fac.ClearSelection();
                    fac.Rows[ultimaFila].Selected = true;
                    fac.CurrentCell = fac.Rows[ultimaFila].Cells[0];
                }

                LimpiarCamposs();

                cod.Focus();
                cod.SelectAll();

                return;
            }
        }
        private void it_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (e.KeyCode == Keys.Right)
            {
                pr.Focus(); 
                pr.SelectAll();

                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                can.Focus(); 
                can.SelectAll();

                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                AgregarAFactura();

                LimpiarCamposs();

                cod.Focus();
                cod.SelectAll();

                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                AgregarAFactura();

                LimpiarCamposs();

                cod.Focus();
                cod.SelectAll();

                return;
            }
        }


        private void fac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow fila = fac.Rows[e.RowIndex];
                cod.Text = fila.Cells[0].Value.ToString();
                can.Text = fila.Cells[1].Value.ToString();
                art.Text = fila.Cells[2].Value.ToString();
                it.Text = fila.Cells[3].Value.ToString();
                pr.Text = fila.Cells[4].Value.ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void fac_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
        private void pr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                cod.Focus();
                cod.SelectAll();
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                art.Focus();
                art.SelectAll();
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                can.Focus();
                can.SelectAll();
                e.SuppressKeyPress = true;
                return;
            }

            if (e.KeyCode == Keys.Up)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;

                AgregarAFactura();

                LimpiarCamposs();

                cod.Focus();
                cod.SelectAll();

                return;
            }
        }

        private void pr_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Buscar_cliente frm = new Buscar_cliente();
            frm.frmfacturacion = this;
            frm.ShowDialog();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)

        {
            try
            {
                CalcularTotal();

                if (string.IsNullOrEmpty(idcliente))
                {
                    MessageBox.Show("Seleccione un cliente");
                    return;
                }

                if (string.IsNullOrWhiteSpace(total.Text) || Convert.ToDecimal(total.Text) <= 0)
                {
                    MessageBox.Show("No hay artículos en la factura");
                    return;
                }

                GuardarFactura();
                ActualizarBalanceCliente();

                ImprimirFactura(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar crédito: " + ex.Message);
            }
            finally
            {
                LimpiarTodo();

                cod.Focus();
                cod.SelectAll();
            }
        }
        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void fac_KeyDown(object sender, KeyEventArgs e)
        {
            if (fac.CurrentRow == null) return;

            int filaActual = fac.CurrentRow.Index;

            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;

                if (filaActual > 0)
                {
                    fac.CurrentCell = fac.Rows[filaActual - 1].Cells[0];
                }
            }

            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;

                if (filaActual < fac.Rows.Count - 1)
                {
                    fac.CurrentCell = fac.Rows[filaActual + 1].Cells[0];
                }
            }
        }
    }
}























