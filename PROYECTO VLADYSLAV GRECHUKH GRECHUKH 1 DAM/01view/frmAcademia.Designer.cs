namespace PROYECTO._01view
{
    partial class frmAcademia
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
            this.btnMantenimientoAlumno = new System.Windows.Forms.Button();
            this.btnMantenimientoCurso = new System.Windows.Forms.Button();
            this.btnMatriculacion = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMantenimientoAlumno
            // 
            this.btnMantenimientoAlumno.Location = new System.Drawing.Point(136, 528);
            this.btnMantenimientoAlumno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMantenimientoAlumno.Name = "btnMantenimientoAlumno";
            this.btnMantenimientoAlumno.Size = new System.Drawing.Size(359, 43);
            this.btnMantenimientoAlumno.TabIndex = 0;
            this.btnMantenimientoAlumno.Text = "Mantenimiento de alumnos";
            this.btnMantenimientoAlumno.UseVisualStyleBackColor = true;
            this.btnMantenimientoAlumno.Click += new System.EventHandler(this.btnAlumnos_Click);
            // 
            // btnMantenimientoCurso
            // 
            this.btnMantenimientoCurso.Location = new System.Drawing.Point(556, 528);
            this.btnMantenimientoCurso.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMantenimientoCurso.Name = "btnMantenimientoCurso";
            this.btnMantenimientoCurso.Size = new System.Drawing.Size(359, 43);
            this.btnMantenimientoCurso.TabIndex = 1;
            this.btnMantenimientoCurso.Text = "Mantenimiento de cursos";
            this.btnMantenimientoCurso.UseVisualStyleBackColor = true;
            this.btnMantenimientoCurso.Click += new System.EventHandler(this.btnCursos_Click);
            // 
            // btnMatriculacion
            // 
            this.btnMatriculacion.Location = new System.Drawing.Point(993, 528);
            this.btnMatriculacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMatriculacion.Name = "btnMatriculacion";
            this.btnMatriculacion.Size = new System.Drawing.Size(359, 43);
            this.btnMatriculacion.TabIndex = 2;
            this.btnMatriculacion.Text = "Matriculación";
            this.btnMatriculacion.UseVisualStyleBackColor = true;
            this.btnMatriculacion.Click += new System.EventHandler(this.btnMatriculas_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PROYECTO.Properties.Resources.Imagen_de_WhatsApp_2025_04_26_a_las_12_59_33_6a3cfcd3;
            this.pictureBox1.Location = new System.Drawing.Point(556, 122);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(398, 264);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // frmAcademia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1473, 642);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnMatriculacion);
            this.Controls.Add(this.btnMantenimientoCurso);
            this.Controls.Add(this.btnMantenimientoAlumno);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAcademia";
            this.Text = "frmAcademia";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMantenimientoAlumno;
        private System.Windows.Forms.Button btnMantenimientoCurso;
        private System.Windows.Forms.Button btnMatriculacion;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}