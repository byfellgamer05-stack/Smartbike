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
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Smartbike
{
    public partial class cant : Form
        
    {
        public facturacion frmfacturacion;
      
        public cant()
        {
            InitializeComponent();
            this.KeyPreview = true;
            cod.TabIndex = 0;
            canti.TabIndex = 1;
            art.TabIndex = 2;
            pre.TabIndex = 3;
            trans.TabIndex = 4;
            it.TabIndex = 5;
            preciof.TabIndex = 6;
        }
        public void RecibirProducto(
    string codigo,
    string cantidad,
    string articulo,
    string precio,
    string transporte,
    string itbis,
    string precioff)
        {
            cod.Text = codigo;
            canti.Text = cantidad;
            art.Text = articulo;
            pre.Text = precio;
            trans.Text = transporte;
           it.Text = itbis;
            preciof.Text = precioff;
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Windows.Forms.TextBox text = sender as System.Windows.Forms.TextBox;
            text.BackColor = Color.White;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            
            foreach (Control c in this.Controls)
            {
                if (c is System.Windows.Forms.TextBox)
                {
                    c.BackColor = Color.White;
                }
            }

            
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;
            txt.BackColor = Color.LightBlue;
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;

            if (e.KeyCode == Keys.Escape)
            {
                txt.BackColor = Color.LightBlue;
                txt.SelectAll();
            }

            if (e.KeyCode == Keys.Down)
            {
                this.SelectNextControl(txt, true, true, true, true);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl(txt, false, true, true, true);
                e.Handled = true;
            }
        }
        private void ActivarModoNavegacion()
        {
            if (this.ActiveControl is System.Windows.Forms.TextBox txt)
            {
                txt.BackColor = Color.LightBlue;
                txt.SelectAll();
            }
        }

        DataTable tabla = new DataTable();
        bool codigoBloqueado = false;
        void LimpiarCampos()
        {
            canti.Clear();
            art.Clear();
            pre.Clear();
            it.Clear();
            trans.Clear();
          
            preciof.Clear();
        }
        void GenerarCodigo()
        {
            
            using (var con = conexion.conectar())
            {
                string query = "SELECT COALESCE(MAX(cod), 0) + 1 FROM registro";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    int nuevoCodigo = Convert.ToInt32(cmd.ExecuteScalar());

                    cod.Text = nuevoCodigo.ToString();
                }
            } // Aquí el using cierra la conexión de forma segura
        }
        void VerHistorial()
        {
            using (var con = conexion.conectar())
            {
                con.Open();

                string query = @"
        SELECT * 
        FROM registro
        ORDER BY cod DESC";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        registro.DataSource = dt;
                    }
                }
            }
        }


        void CargarDatos()
        {
              try
                {
                    using (SQLiteConnection con = conexion.conectar())
                    {
                        string query = "SELECT * FROM registro";

                        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                        using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            registro.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }
        private void registro_Load(object sender, EventArgs e)
        {
          
            tabla.Columns.Add("cod");
            tabla.Columns.Add("cant");
            tabla.Columns.Add("art");
            tabla.Columns.Add("pre");
            tabla.Columns.Add("trans");
            tabla.Columns.Add("it");
            tabla.Columns.Add("preciof");

            registro.DataSource = tabla; 
            GenerarCodigo();

            foreach (Control c in this.Controls)
            {
                if (c is System.Windows.Forms.TextBox txt)
                {
                    txt.KeyDown += TextBox_KeyDown;
                    txt.Enter += TextBox_Enter;
                    txt.KeyPress += TextBox_KeyPress; 
                }
            }
        }



        private void prec_TextChanged(object sender, EventArgs e)
        {





        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            try
            {
                decimal precio = Convert.ToDecimal(pre.Text.Trim());

                // ITBIS desde NumericUpDown
                decimal porcItbis = itb.Value;

                decimal itbisCalculado =
                precio * (porcItbis / 100);

                // Transporte escrito por el usuario
                decimal transporteCalculado =
                Convert.ToDecimal(trans.Text.Trim());

                decimal total =
                precio + itbisCalculado + transporteCalculado;

                it.Text = itbisCalculado.ToString("0.00");
                preciof.Text = total.ToString("0.00");
            }
            catch
            {
                MessageBox.Show("Ingrese valores válidos");
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cod.Clear();
            canti.Clear();
            art.Clear();
            pre.Clear();
            trans.Clear();
           
            preciof.Clear();

            cod.Focus(); 
            GenerarCodigo();
        
            LimpiarCampos();
        }

        private void Itbis_Click(object sender, EventArgs e)
        {

        }

        private void cod_TextChanged(object sender, EventArgs e)
    
      
        {
            
        }
        
        


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cod.Text) ||
                    string.IsNullOrWhiteSpace(canti.Text) ||
                    string.IsNullOrWhiteSpace(art.Text) ||
                    string.IsNullOrWhiteSpace(pre.Text) ||
                    string.IsNullOrWhiteSpace(trans.Text) ||
                    string.IsNullOrWhiteSpace(preciof.Text))
                {
                    MessageBox.Show("Complete todos los campos");
                    return;
                }

                decimal precio =
                Convert.ToDecimal(pre.Text.Trim().Replace(",", ""));

                int cantidad =
                Convert.ToInt32(canti.Text.Trim());

                decimal transporteCalculado =
                Convert.ToDecimal(trans.Text.Trim().Replace(",", ""));

                decimal porcItbis = itb.Value;

                decimal itbisCalculado =
                precio * (porcItbis / 100);

                decimal precioFinal =
                Convert.ToDecimal(preciof.Text.Trim().Replace(",", ""));

                it.Text = itbisCalculado.ToString("N2");

                using (SQLiteConnection con = conexion.conectar())
                {
                    string query = @"
        INSERT INTO registro
        (cod, cant, art, pre, trans, it, preciof)
        VALUES
        (@cod, @cant, @art, @pre, @trans, @it, @preciof)";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@cod", cod.Text.Trim());
                        cmd.Parameters.AddWithValue("@cant", cantidad);
                        cmd.Parameters.AddWithValue("@art", art.Text.Trim());
                        cmd.Parameters.AddWithValue("@pre", precio);
                        cmd.Parameters.AddWithValue("@trans", transporteCalculado);
                        cmd.Parameters.AddWithValue("@it", itbisCalculado);
                        cmd.Parameters.AddWithValue("@preciof", precioFinal);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Datos guardados correctamente");

                cod.ReadOnly = false;
                codigoBloqueado = false;

                GenerarCodigo();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            historial h = new historial();

            h.frmcant = this;

            h.ShowDialog();
        }


        private void cod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
        {
            e.Handled = true;
            SendKeys.Send("{TAB}");

        }
        }

        private void canti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void art_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void pre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void trans_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void it_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        private void preciof_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void registro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            registro.Rows.Clear();
        }

        private void cod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // ESC
                if (e.KeyCode == Keys.Escape)
                {
                    cod.BackColor = Color.LightBlue;
                    cod.SelectAll();
                    return;
                }

                // Navegación derecha
                if (e.KeyCode == Keys.Right)
                {
                    this.SelectNextControl(cod, true, true, true, true);
                    e.Handled = true;
                    return;
                }

                // Navegación izquierda
                if (e.KeyCode == Keys.Left)
                {
                    this.SelectNextControl(cod, false, true, true, true);
                    e.Handled = true;
                    return;
                }

                // ENTER = buscar producto
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;

                    using (SQLiteConnection con = conexion.conectar())
                    {
                        string query = "SELECT * FROM registro WHERE cod = @cod";

                        using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@cod", cod.Text.Trim());

                            using (SQLiteDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    canti.Text = dr["cant"].ToString();
                                    art.Text = dr["art"].ToString();
                                    pre.Text = dr["pre"].ToString();
                                    trans.Text = dr["trans"].ToString();
                                   
                                    preciof.Text = dr["preciof"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Artículo no encontrado");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar producto: " + ex.Message);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = conexion.conectar())
            {
                string query = "DELETE FROM registro WHERE cod = @cod";

                using (SQLiteCommand cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@cod", cod.Text.Trim());

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        MessageBox.Show("Registro eliminado correctamente");
                       
                        LimpiarCampos();

                        cod.ReadOnly = false;
                        codigoBloqueado = false;

                        GenerarCodigo();
                        cod.Focus();
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro");
                    }
                }
            }
        }

        private void cant_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.KeyPreview = true;
        }

        private void cant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ActivarModoNavegacion();
            }

            if (e.KeyCode == Keys.Right)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }

            if (e.KeyCode == Keys.Left)
            {
                this.SelectNextControl(this.ActiveControl, false, true, true, true);
            }
        }

        private void canti_KeyDown(object sender, KeyEventArgs e)
        {


            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;

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
        }



        private void art_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;

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
        }



        private void pre_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;

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
        }
        
        

        private void trans_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;

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
        }


        private void it_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;

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
        }


        private void preciof_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void preciof_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;

            if (e.KeyCode == Keys.Right)
            {
                e.SuppressKeyPress = true;

                cod.Focus();
                cod.SelectAll();
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                e.SuppressKeyPress = true;

                trans.Focus();
                trans.SelectAll();
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                pictureBox3_Click(pictureBox3, EventArgs.Empty);
                return;
            }
        }

        private void trans_TextChanged(object sender, EventArgs e)
        {
           
    }

        private void trans_KeyDown_1(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox txt =
sender as System.Windows.Forms.TextBox;

            try
            {
                // Mover a la derecha
                if (e.KeyCode == Keys.Right)
                {
                    this.SelectNextControl(
                    txt, true, true, true, true);

                    e.Handled = true;
                    return;
                }

                // Mover a la izquierda
                if (e.KeyCode == Keys.Left)
                {
                    this.SelectNextControl(
                    txt, false, true, true, true);

                    e.Handled = true;
                    return;
                }

                // ENTER = calcular
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;

                    decimal precio =
                    Convert.ToDecimal(
                    pre.Text.Trim().Replace(",", ""));

                    decimal transporte =
                    Convert.ToDecimal(
                    trans.Text.Trim().Replace(",", ""));

                    decimal porcItbis = itb.Value;

                    decimal itbisCalculado =
                    precio * (porcItbis / 100);

                    decimal total =
                    precio + itbisCalculado + transporte;

                    it.Text =
                    itbisCalculado.ToString("N2");

                    preciof.Text =
                    total.ToString("N2");

                    // Ir a precio final
                    preciof.Focus();
                    preciof.SelectAll();
                }
            }
            catch
            {
                MessageBox.Show("Ingrese valores válidos");
            }

        }

        private void it_KeyDown_1(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;

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
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cod.Text))
                {
                    MessageBox.Show("Ingrese un código");
                    return;
                }

                decimal precio =
                Convert.ToDecimal(pre.Text.Trim().Replace(",", ""));

                decimal transporte =
                Convert.ToDecimal(trans.Text.Trim().Replace(",", ""));

                decimal porcItbis = itb.Value;

                decimal itbisCalculado =
                precio * (porcItbis / 100);

                decimal precioFinal =
                Convert.ToDecimal(preciof.Text.Trim().Replace(",", ""));

                using (SQLiteConnection con = conexion.conectar())
                {
                    string query = @"
        UPDATE registro
        SET
        cant=@cant,
        art=@art,
        pre=@pre,
        trans=@trans,
        it=@it,
        preciof=@preciof
        WHERE cod=@cod";

                    using (SQLiteCommand cmd =
                    new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@cod",
                        cod.Text.Trim());

                        cmd.Parameters.AddWithValue("@cant",
                        canti.Text.Trim());

                        cmd.Parameters.AddWithValue("@art",
                        art.Text.Trim());

                        cmd.Parameters.AddWithValue("@pre",
                        precio);

                        cmd.Parameters.AddWithValue("@trans",
                        transporte);

                        cmd.Parameters.AddWithValue("@it",
                        itbisCalculado);

                        cmd.Parameters.AddWithValue("@preciof",
                        precioFinal);

                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            MessageBox.Show(
                            "Datos modificados correctamente");

                            CargarDatos();

                            LimpiarCampos();

                            GenerarCodigo();
                        }
                        else
                        {
                            MessageBox.Show(
                            "No se encontró el código");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                "Error al modificar: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
    }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox txt = sender as System.Windows.Forms.TextBox;

            if (txt == null)
                return;

            // Flecha abajo: desde cualquier TextBox de arriba baja a Referencia
            if (e.KeyCode == Keys.Down)
            {
                if (txt != re)
                {
                    re.Focus();
                    re.SelectAll();
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            // Flecha arriba: desde Referencia sube a Código
            if (e.KeyCode == Keys.Up)
            {
                if (txt == re)
                {
                    cod.Focus();
                    cod.SelectAll();

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    return;
                }
            }
        }
    }
    }
    
    
    
    






















































