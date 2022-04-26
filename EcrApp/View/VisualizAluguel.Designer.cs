namespace EcrApp.View
{
    partial class VisualizAluguel
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkoutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aluguelClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aluguelClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.checkinDataGridViewTextBoxColumn,
            this.checkoutDataGridViewTextBoxColumn,
            this.usuarioDataGridViewTextBoxColumn,
            this.carroDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.aluguelClassBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(776, 369);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "date";
            this.dateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 125;
            // 
            // checkinDataGridViewTextBoxColumn
            // 
            this.checkinDataGridViewTextBoxColumn.DataPropertyName = "checkin";
            this.checkinDataGridViewTextBoxColumn.HeaderText = "checkin";
            this.checkinDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.checkinDataGridViewTextBoxColumn.Name = "checkinDataGridViewTextBoxColumn";
            this.checkinDataGridViewTextBoxColumn.Width = 125;
            // 
            // checkoutDataGridViewTextBoxColumn
            // 
            this.checkoutDataGridViewTextBoxColumn.DataPropertyName = "checkout";
            this.checkoutDataGridViewTextBoxColumn.HeaderText = "checkout";
            this.checkoutDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.checkoutDataGridViewTextBoxColumn.Name = "checkoutDataGridViewTextBoxColumn";
            this.checkoutDataGridViewTextBoxColumn.Width = 125;
            // 
            // usuarioDataGridViewTextBoxColumn
            // 
            this.usuarioDataGridViewTextBoxColumn.DataPropertyName = "usuario";
            this.usuarioDataGridViewTextBoxColumn.HeaderText = "usuario";
            this.usuarioDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.usuarioDataGridViewTextBoxColumn.Name = "usuarioDataGridViewTextBoxColumn";
            this.usuarioDataGridViewTextBoxColumn.Width = 125;
            // 
            // carroDataGridViewTextBoxColumn
            // 
            this.carroDataGridViewTextBoxColumn.DataPropertyName = "carro";
            this.carroDataGridViewTextBoxColumn.HeaderText = "carro";
            this.carroDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.carroDataGridViewTextBoxColumn.Name = "carroDataGridViewTextBoxColumn";
            this.carroDataGridViewTextBoxColumn.Width = 125;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "valor";
            this.valorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.Width = 125;
            // 
            // aluguelClassBindingSource
            // 
            this.aluguelClassBindingSource.DataSource = typeof(EcrApp.Model.AluguelClass);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Voltar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VisualizAluguel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VisualizAluguel";
            this.Text = "VizualizAluguel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aluguelClassBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn checkinDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn checkoutDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn carroDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private BindingSource aluguelClassBindingSource;
    }
}