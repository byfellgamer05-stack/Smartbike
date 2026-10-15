namespace Smartbike
{
    partial class cuadre
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eliteDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cua = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuadresBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Smartbike.DataSet1();
            this.facturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cuadret = new System.Windows.Forms.TextBox();
            this.Buscar = new System.Windows.Forms.Button();
            this.eliteDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eliteDataSet1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.cuadresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cuadresTableAdapter = new Smartbike.DataSet1TableAdapters.cuadresTableAdapter();
            this.cuadresBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cuadresBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.cuadresBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliteDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadresBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadresBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadresBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadresBindingSource4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(229, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total generado el día de hoy";
            // 
            // cua
            // 
            this.cua.AllowUserToAddRows = false;
            this.cua.AllowUserToOrderColumns = true;
            this.cua.AutoGenerateColumns = false;
            this.cua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cua.BackgroundColor = System.Drawing.Color.White;
            this.cua.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.cua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.cua.DataSource = this.cuadresBindingSource4;
            this.cua.Location = new System.Drawing.Point(0, 63);
            this.cua.Name = "cua";
            this.cua.RowHeadersVisible = false;
            this.cua.Size = new System.Drawing.Size(871, 242);
            this.cua.TabIndex = 46;
            this.cua.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cua_CellContentClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "fecha";
            this.dataGridViewTextBoxColumn1.HeaderText = "fecha";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "total";
            this.dataGridViewTextBoxColumn2.HeaderText = "total";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // cuadresBindingSource3
            // 
            this.cuadresBindingSource3.DataMember = "cuadres";
            this.cuadresBindingSource3.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // facturasBindingSource
            // 
            this.facturasBindingSource.DataMember = "facturas";
            // 
            // cuadret
            // 
            this.cuadret.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cuadret.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuadret.Location = new System.Drawing.Point(664, 386);
            this.cuadret.Name = "cuadret";
            this.cuadret.Size = new System.Drawing.Size(164, 44);
            this.cuadret.TabIndex = 47;
            // 
            // Buscar
            // 
            this.Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscar.Location = new System.Drawing.Point(215, 396);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(128, 42);
            this.Buscar.TabIndex = 48;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 42);
            this.button1.TabIndex = 49;
            this.button1.Text = "Guardar cuadre";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cuadresBindingSource
            // 
            this.cuadresBindingSource.DataMember = "cuadres";
            this.cuadresBindingSource.DataSource = this.dataSet1;
            // 
            // cuadresTableAdapter
            // 
            this.cuadresTableAdapter.ClearBeforeFill = true;
            // 
            // cuadresBindingSource1
            // 
            this.cuadresBindingSource1.DataMember = "cuadres";
            this.cuadresBindingSource1.DataSource = this.dataSet1;
            // 
            // cuadresBindingSource2
            // 
            this.cuadresBindingSource2.DataMember = "cuadres";
            this.cuadresBindingSource2.DataSource = this.dataSet1;
            // 
            // cuadresBindingSource4
            // 
            this.cuadresBindingSource4.DataMember = "cuadres";
            this.cuadresBindingSource4.DataSource = this.dataSet1;
            // 
            // cuadre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(874, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.cuadret);
            this.Controls.Add(this.cua);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "cuadre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuadre";
            this.Load += new System.EventHandler(this.cuadre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliteDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadresBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eliteDataSet1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadresBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadresBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cuadresBindingSource4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource eliteDataSetBindingSource;
  //     private eliteDataSet eliteDataSet;
   //    private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
   //     private eliteDataSet1 eliteDataSet1;
        private System.Windows.Forms.BindingSource eliteDataSet1BindingSource;
        private System.Windows.Forms.BindingSource eliteDataSet1BindingSource1;
    //   private eliteDataSet1 eliteDataSet11;
        private System.Windows.Forms.BindingSource facturasBindingSource;
     //  private eliteDataSet1TableAdapters.facturasTableAdapter facturasTableAdapter;
        private System.Windows.Forms.DataGridView cua;
        private System.Windows.Forms.TextBox cuadret;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn numfaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource cuadresBindingSource;
        private DataSet1TableAdapters.cuadresTableAdapter cuadresTableAdapter;
        private System.Windows.Forms.BindingSource cuadresBindingSource2;
        private System.Windows.Forms.BindingSource cuadresBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource cuadresBindingSource3;
        private System.Windows.Forms.BindingSource cuadresBindingSource4;
    }
}