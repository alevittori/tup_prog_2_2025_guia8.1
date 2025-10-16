namespace Ejercicio1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lbResultados = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(638, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 51);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generar Recibos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(638, 41);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(113, 51);
            this.btnListar.TabIndex = 1;
            this.btnListar.Text = "Ver Empleados";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(638, 105);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(113, 51);
            this.btnImportar.TabIndex = 2;
            this.btnImportar.Text = "Importar Empleados";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(638, 171);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 51);
            this.button4.TabIndex = 3;
            this.button4.Text = "Exportar Empleados";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lbResultados
            // 
            this.lbResultados.FormattingEnabled = true;
            this.lbResultados.Location = new System.Drawing.Point(5, 20);
            this.lbResultados.Name = "lbResultados";
            this.lbResultados.Size = new System.Drawing.Size(573, 394);
            this.lbResultados.TabIndex = 4;
            this.lbResultados.SelectedIndexChanged += new System.EventHandler(this.lbResultados_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbResultados);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 426);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista de Empleados";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(638, 375);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(113, 51);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox lbResultados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
    }
}

