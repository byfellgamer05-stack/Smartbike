namespace Smartbike
{
    partial class Buscar_cliente
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
            this.clientesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
     //       this.eliteDataSet1 = new Smartbike.eliteDataSet1();
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ced = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
    //        this.clientesTableAdapter = new Smartbike.eliteDataSet1TableAdapters.clientesTableAdapter();
            this.clientesBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.buscarc = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cedulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientesBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource1)).BeginInit();
         //   ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buscarc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // clientesBindingSource1
            // 
            this.clientesBindingSource1.DataMember = "clientes";
         //   this.clientesBindingSource1.DataSource = this.eliteDataSet1;
            // 
            // eliteDataSet1
            // 
         //   this.eliteDataSet1.DataSetName = "eliteDataSet1";
        //    this.eliteDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataMember = "clientes";
      //      this.clientesBindingSource.DataSource = this.eliteDataSet1;
            // 
            // ced
            // 
            this.ced.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ced.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ced.Location = new System.Drawing.Point(161, 6);
            this.ced.Name = "ced";
            this.ced.Size = new System.Drawing.Size(342, 29);
            this.ced.TabIndex = 101;
            this.ced.TextChanged += new System.EventHandler(this.ced_TextChanged);
            this.ced.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ced_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(-604, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1399, 0);
            this.panel1.TabIndex = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 24);
            this.label4.TabIndex = 99;
            this.label4.Text = "Buscar cliente";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // clientesTableAdapter
            // 
         //   this.clientesTableAdapter.ClearBeforeFill = true;
            // 
            // clientesBindingSource2
            // 
            this.clientesBindingSource2.DataMember = "clientes";
       //     this.clientesBindingSource2.DataSource = this.eliteDataSet1;
            // 
            // buscarc
            // 
            this.buscarc.AllowUserToAddRows = false;
            this.buscarc.AllowUserToOrderColumns = true;
            this.buscarc.AutoGenerateColumns = false;
            this.buscarc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.buscarc.BackgroundColor = System.Drawing.Color.White;
            this.buscarc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.buscarc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.buscarc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.numeroDataGridViewTextBoxColumn,
            this.cedulaDataGridViewTextBoxColumn,
            this.direccionDataGridViewTextBoxColumn,
            this.balanceDataGridViewTextBoxColumn});
            this.buscarc.DataSource = this.clientesBindingSource3;
            this.buscarc.Location = new System.Drawing.Point(2, 41);
            this.buscarc.Name = "buscarc";
            this.buscarc.RowHeadersVisible = false;
            this.buscarc.Size = new System.Drawing.Size(1137, 397);
            this.buscarc.TabIndex = 102;
            this.buscarc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.buscarc_CellContentClick);
            this.buscarc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.buscarc_CellDoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // numeroDataGridViewTextBoxColumn
            // 
            this.numeroDataGridViewTextBoxColumn.DataPropertyName = "numero";
            this.numeroDataGridViewTextBoxColumn.HeaderText = "numero";
            this.numeroDataGridViewTextBoxColumn.Name = "numeroDataGridViewTextBoxColumn";
            // 
            // cedulaDataGridViewTextBoxColumn
            // 
            this.cedulaDataGridViewTextBoxColumn.DataPropertyName = "cedula";
            this.cedulaDataGridViewTextBoxColumn.HeaderText = "cedula";
            this.cedulaDataGridViewTextBoxColumn.Name = "cedulaDataGridViewTextBoxColumn";
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "direccion";
            this.direccionDataGridViewTextBoxColumn.HeaderText = "direccion";
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            // 
            // balanceDataGridViewTextBoxColumn
            // 
            this.balanceDataGridViewTextBoxColumn.DataPropertyName = "balance";
            this.balanceDataGridViewTextBoxColumn.HeaderText = "balance";
            this.balanceDataGridViewTextBoxColumn.Name = "balanceDataGridViewTextBoxColumn";
            // 
            // clientesBindingSource3
            // 
            this.clientesBindingSource3.DataMember = "clientes";
       //     this.clientesBindingSource3.DataSource = this.eliteDataSet1;
            // 
            // Buscar_cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1141, 450);
            this.Controls.Add(this.buscarc);
            this.Controls.Add(this.ced);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Name = "Buscar_cliente";
            this.Text = "Buscar_cliente";
            this.Load += new System.EventHandler(this.Buscar_cliente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Buscar_cliente_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource1)).EndInit();
          //  ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buscarc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
  //      private eliteDataSet1 eliteDataSet1;
        private System.Windows.Forms.TextBox ced;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource clientesBindingSource;
  //      private eliteDataSet1TableAdapters.clientesTableAdapter clientesTableAdapter;
        private System.Windows.Forms.BindingSource clientesBindingSource1;
        private System.Windows.Forms.BindingSource clientesBindingSource2;
        private System.Windows.Forms.DataGridView buscarc;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cedulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource clientesBindingSource3;
    }
}