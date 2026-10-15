namespace Smartbike
{
    partial class buscar_cuadre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
          //  this.eliteDataSet = new Smartbike.eliteDataSet();
            this.facturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
        //    this.facturasTableAdapter = new Smartbike.eliteDataSetTableAdapters.facturasTableAdapter();
            this.cua = new System.Windows.Forms.DataGridView();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         //   this.eliteDataSet1 = new Smartbike.eliteDataSet1();
            this.ingresosBindingSource = new System.Windows.Forms.BindingSource(this.components);
         //   this.ingresosTableAdapter = new Smartbike.eliteDataSet1TableAdapters.ingresosTableAdapter();
        //    ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cua)).BeginInit();
       //     ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingresosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // eliteDataSet
            // 
       //     this.eliteDataSet.DataSetName = "eliteDataSet";
        //    this.eliteDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // facturasBindingSource
            // 
            this.facturasBindingSource.DataMember = "facturas";
       //     this.facturasBindingSource.DataSource = this.eliteDataSet;
            // 
            // facturasTableAdapter
            // 
         //   this.facturasTableAdapter.ClearBeforeFill = true;
            // 
            // cua
            // 
            this.cua.AllowUserToAddRows = false;
            this.cua.AutoGenerateColumns = false;
            this.cua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cua.BackgroundColor = System.Drawing.Color.White;
            this.cua.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.cua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechaDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn});
            this.cua.DataSource = this.ingresosBindingSource;
            this.cua.Location = new System.Drawing.Point(0, 0);
            this.cua.Name = "cua";
            this.cua.RowHeadersVisible = false;
            this.cua.Size = new System.Drawing.Size(797, 242);
            this.cua.TabIndex = 47;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            // 
            // eliteDataSet1
            // 
        //    this.eliteDataSet1.DataSetName = "eliteDataSet1";
        //    this.eliteDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ingresosBindingSource
            // 
            this.ingresosBindingSource.DataMember = "ingresos";
       //     this.ingresosBindingSource.DataSource = this.eliteDataSet1;
            // 
            // ingresosTableAdapter
            // 
       //     this.ingresosTableAdapter.ClearBeforeFill = true;
            // 
            // buscar_cuadre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cua);
            this.Name = "buscar_cuadre";
            this.Text = "buscar_cuadre";
            this.Load += new System.EventHandler(this.buscar_cuadre_Load);
     //      ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cua)).EndInit();
         //   ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingresosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
   //   private eliteDataSet eliteDataSet;
        private System.Windows.Forms.BindingSource facturasBindingSource;
   //   private eliteDataSetTableAdapters.facturasTableAdapter facturasTableAdapter;
        private System.Windows.Forms.DataGridView cua;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;       
   //     private SeliteDataSet1 eliteDataSet1;
        private System.Windows.Forms.BindingSource ingresosBindingSource;
    //    private eliteDataSet1TableAdapters.ingresosTableAdapter ingresosTableAdapter;
    }
}