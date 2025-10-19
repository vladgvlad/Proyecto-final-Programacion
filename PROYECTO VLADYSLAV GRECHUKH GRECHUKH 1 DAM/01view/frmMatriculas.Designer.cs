namespace PROYECTO._01view
{
    partial class FrmMatriculas
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvCursos;
        private System.Windows.Forms.DataGridView dgvMatriculados;
        private System.Windows.Forms.Button btnVerTodoCurso;
        private System.Windows.Forms.Button btnAlumnosCurso;
        private System.Windows.Forms.Button btnVerTodoAlumno;
        private System.Windows.Forms.Button btnVerCursos;
        private System.Windows.Forms.Button btnMostrarAlumno;
        private System.Windows.Forms.Button btnDesmatricular;
        private System.Windows.Forms.TextBox txtCodigoMatricula;
        private System.Windows.Forms.TextBox txtDniAlumno;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Splitter splitter1;

        /// <summary>  
        /// Limpia los recursos que se estén usando.  
        /// </summary>  
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.dgvCursos = new System.Windows.Forms.DataGridView();
            this.dgvMatriculados = new System.Windows.Forms.DataGridView();
            this.btnVerTodoCurso = new System.Windows.Forms.Button();
            this.btnAlumnosCurso = new System.Windows.Forms.Button();
            this.btnVerTodoAlumno = new System.Windows.Forms.Button();
            this.btnVerCursos = new System.Windows.Forms.Button();
            this.btnMostrarAlumno = new System.Windows.Forms.Button();
            this.btnDesmatricular = new System.Windows.Forms.Button();
            this.txtCodigoMatricula = new System.Windows.Forms.TextBox();
            this.txtDniAlumno = new System.Windows.Forms.TextBox();
            this.txtError = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriculados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCursos
            // 
            this.dgvCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursos.Location = new System.Drawing.Point(36, 86);
            this.dgvCursos.Name = "dgvCursos";
            this.dgvCursos.Size = new System.Drawing.Size(592, 437);
            this.dgvCursos.TabIndex = 0;
            // **Ahora enlazamos al método dgvCursos_CellClick que sí existe**
            this.dgvCursos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCursos_CellClick);
            // 
            // dgvMatriculados
            // 
            this.dgvMatriculados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatriculados.Location = new System.Drawing.Point(843, 86);
            this.dgvMatriculados.Name = "dgvMatriculados";
            this.dgvMatriculados.Size = new System.Drawing.Size(592, 437);
            this.dgvMatriculados.TabIndex = 1;
            // **Enlazamos también al método dgvMatriculados_CellClick**
            this.dgvMatriculados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatriculados_CellClick);
            // 
            // btnVerTodoCurso
            // 
            this.btnVerTodoCurso.Location = new System.Drawing.Point(112, 544);
            this.btnVerTodoCurso.Name = "btnVerTodoCurso";
            this.btnVerTodoCurso.Size = new System.Drawing.Size(208, 43);
            this.btnVerTodoCurso.TabIndex = 2;
            this.btnVerTodoCurso.Text = "Ver todos";
            this.btnVerTodoCurso.UseVisualStyleBackColor = true;
            // **Enlaza al handler btnViewAll_Click que ya tienes**
            this.btnVerTodoCurso.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // btnAlumnosCurso
            // 
            this.btnAlumnosCurso.Location = new System.Drawing.Point(367, 544);
            this.btnAlumnosCurso.Name = "btnAlumnosCurso";
            this.btnAlumnosCurso.Size = new System.Drawing.Size(208, 43);
            this.btnAlumnosCurso.TabIndex = 3;
            this.btnAlumnosCurso.Text = "Ver alumnos del curso";
            this.btnAlumnosCurso.UseVisualStyleBackColor = true;
            // **Enlaza al handler btnAlumnosCurso_Click**
            this.btnAlumnosCurso.Click += new System.EventHandler(this.btnAlumnosCurso_Click);
            // 
            // btnVerTodoAlumno
            // 
            this.btnVerTodoAlumno.Location = new System.Drawing.Point(1172, 544);
            this.btnVerTodoAlumno.Name = "btnVerTodoAlumno";
            this.btnVerTodoAlumno.Size = new System.Drawing.Size(208, 43);
            this.btnVerTodoAlumno.TabIndex = 5;
            this.btnVerTodoAlumno.Text = "Ver todos";
            this.btnVerTodoAlumno.UseVisualStyleBackColor = true;
            // **También reutiliza btnViewAll_Click para “ver todos” alumnos**
            this.btnVerTodoAlumno.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // btnVerCursos
            // 
            this.btnVerCursos.Location = new System.Drawing.Point(903, 544);
            this.btnVerCursos.Name = "btnVerCursos";
            this.btnVerCursos.Size = new System.Drawing.Size(208, 43);
            this.btnVerCursos.TabIndex = 4;
            this.btnVerCursos.Text = "Ver cursos del Alumno";
            this.btnVerCursos.UseVisualStyleBackColor = true;
            // **Enlaza al handler btnVerCursos_Click que has definido**
            this.btnVerCursos.Click += new System.EventHandler(this.btnVerCursos_Click);
            // 
            // btnMostrarAlumno
            // 
            this.btnMostrarAlumno.Location = new System.Drawing.Point(1011, 36);
            this.btnMostrarAlumno.Name = "btnMostrarAlumno";
            this.btnMostrarAlumno.Size = new System.Drawing.Size(208, 43);
            this.btnMostrarAlumno.TabIndex = 6;
            this.btnMostrarAlumno.Text = "Matricular Alumno";
            this.btnMostrarAlumno.UseVisualStyleBackColor = true;
            // **Enlaza a btnMatricular_Click**
            this.btnMostrarAlumno.Click += new System.EventHandler(this.btnMatricular_Click);
            // 
            // btnDesmatricular
            // 
            this.btnDesmatricular.Location = new System.Drawing.Point(1227, 36);
            this.btnDesmatricular.Name = "btnDesmatricular";
            this.btnDesmatricular.Size = new System.Drawing.Size(208, 43);
            this.btnDesmatricular.TabIndex = 7;
            this.btnDesmatricular.Text = "Desmatricular Alumno";
            this.btnDesmatricular.UseVisualStyleBackColor = true;
            // **Enlaza a btnDesmatricular_Click**
            this.btnDesmatricular.Click += new System.EventHandler(this.btnDesmatricular_Click);
            // 
            // txtCodigoMatricula
            // 
            this.txtCodigoMatricula.Location = new System.Drawing.Point(495, 54);
            this.txtCodigoMatricula.Name = "txtCodigoMatricula";
            this.txtCodigoMatricula.Size = new System.Drawing.Size(132, 22);
            this.txtCodigoMatricula.TabIndex = 8;
            // 
            // txtDniAlumno
            // 
            this.txtDniAlumno.Location = new System.Drawing.Point(843, 54);
            this.txtDniAlumno.Name = "txtDniAlumno";
            this.txtDniAlumno.Size = new System.Drawing.Size(132, 22);
            this.txtDniAlumno.TabIndex = 9;
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(55, 54);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(396, 22);
            this.txtError.TabIndex = 10;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 641);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // FrmMatriculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 641);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.txtError);
            this.Controls.Add(this.txtDniAlumno);
            this.Controls.Add(this.txtCodigoMatricula);
            this.Controls.Add(this.btnDesmatricular);
            this.Controls.Add(this.btnMostrarAlumno);
            this.Controls.Add(this.btnVerTodoAlumno);
            this.Controls.Add(this.btnVerCursos);
            this.Controls.Add(this.btnAlumnosCurso);
            this.Controls.Add(this.btnVerTodoCurso);
            this.Controls.Add(this.dgvMatriculados);
            this.Controls.Add(this.dgvCursos);
            this.Name = "FrmMatriculas";
            this.Text = "Matrículas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriculados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
