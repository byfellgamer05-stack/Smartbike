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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Smartbike
{
    public partial class buscar_cuadre : Form
    {
        public buscar_cuadre()
        {
            InitializeComponent();
        }
        void CargarHistorialCuadres()
        {
            using (var con = conexion.conectar())
            {
                string sql = @"
        SELECT 
        fecha AS Fecha,
        total AS Total
        FROM ingresos
        ORDER BY fecha DESC";

                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cua.DataSource = dt;
            }
        }
      

        private void buscar_cuadre_Load(object sender, EventArgs e)
        {
            CargarHistorialCuadres();
           
          
            // TODO: esta línea de código carga datos en la tabla 'eliteDataSet1.ingresos' Puede moverla o quitarla según sea necesario.
            //  this.ingresosTableAdapter.Fill(this.eliteDataSet1.ingresos);
            // TODO: esta línea de código carga datos en la tabla 'eliteDataSet.facturas' Puede moverla o quitarla según sea necesario.
            // this.facturasTableAdapter.Fill(this.eliteDataSet.facturas);

        }
    }
}
