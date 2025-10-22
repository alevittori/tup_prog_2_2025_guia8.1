namespace Ejercicio2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnAltaEvento = new Button();
            tbNombreEvento = new TextBox();
            dtpFecha = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            lbDetalles = new ListBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAltaEvento);
            groupBox1.Controls.Add(tbNombreEvento);
            groupBox1.Controls.Add(dtpFecha);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(661, 154);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Nuevo Evento";
            // 
            // btnAltaEvento
            // 
            btnAltaEvento.Location = new Point(494, 55);
            btnAltaEvento.Name = "btnAltaEvento";
            btnAltaEvento.Size = new Size(130, 46);
            btnAltaEvento.TabIndex = 4;
            btnAltaEvento.Text = "Cargar Eventos";
            btnAltaEvento.UseVisualStyleBackColor = true;
            btnAltaEvento.Click += btnAltaEvento_Click;
            // 
            // tbNombreEvento
            // 
            tbNombreEvento.Location = new Point(167, 78);
            tbNombreEvento.Multiline = true;
            tbNombreEvento.Name = "tbNombreEvento";
            tbNombreEvento.Size = new Size(235, 43);
            tbNombreEvento.TabIndex = 3;
            // 
            // dtpFecha
            // 
            dtpFecha.CustomFormat = "dd/MM/yyyy";
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.Location = new Point(167, 37);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(235, 23);
            dtpFecha.TabIndex = 2;
            dtpFecha.Value = new DateTime(2025, 10, 22, 8, 31, 48, 0);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 86);
            label2.Name = "label2";
            label2.Size = new Size(109, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre del Evento";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 43);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Fecha";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lbDetalles);
            groupBox2.Location = new Point(12, 188);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(661, 311);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Administracion de Eventos";
            // 
            // lbDetalles
            // 
            lbDetalles.FormattingEnabled = true;
            lbDetalles.ItemHeight = 15;
            lbDetalles.Location = new Point(6, 22);
            lbDetalles.Name = "lbDetalles";
            lbDetalles.Size = new Size(649, 289);
            lbDetalles.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 511);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dtpFecha;
        private Label label2;
        private Label label1;
        private Button btnAltaEvento;
        private TextBox tbNombreEvento;
        private GroupBox groupBox2;
        private ListBox lbDetalles;
    }
}
