using System;
using System.Windows.Forms;
using PROYECTO._02aplication;
using PROYECTO._03data; 

namespace PROYECTO._01view
{
    public partial class FrmMatriculas : Form
    {
        private readonly GestionMatriculas gestionMat;
        private readonly GestionCursos gestionCur;

        public FrmMatriculas()
        {
            InitializeComponent();
            gestionMat = new GestionMatriculas();
            gestionCur = new GestionCursos();
            CargarCursos();
            CargarMatriculas();
        }

        private void CargarCursos()
        {
            dgvCursos.DataSource = gestionCur.GetAll();
        }

        private void CargarMatriculas()
        {
            dgvMatriculados.DataSource = gestionMat.GetAll();
        }

        private void MapearPresentacionNegocio()
        {
            gestionMat.Matricula.CodigoCurso = txtCodigoMatricula.Text.Trim();
            gestionMat.Matricula.Dni = txtDniAlumno.Text.Trim();
        }

        private void btnViewAll_Click(object boton, EventArgs e)
        {
            CargarCursos();
            CargarMatriculas();
        }

        private void btnAlumnosCurso_Click(object boton, EventArgs e)
        {
            var codigo = txtCodigoMatricula.Text.Trim();
            dgvMatriculados.DataSource = gestionMat.GetAlumnosPorCurso(codigo);
        }

        private void btnVerCursos_Click(object boton, EventArgs e)
        {
            var dni = txtDniAlumno.Text.Trim();
            dgvMatriculados.DataSource = gestionMat.GetCursosPorAlumno(dni);
        }

        private void btnMatricular_Click(object boton, EventArgs e)
        {
            MapearPresentacionNegocio();
            var salida = gestionMat.Insert();

            if (salida > 0)
            {
                dgvMatriculados.DataSource = gestionMat.GetAlumnosPorCurso(txtCodigoMatricula.Text.Trim());
                MessageBox.Show("Alumno matriculado correctamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo matricular", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtError.Text = gestionMat.Error();
        }


        private void btnDesmatricular_Click(object boton, EventArgs e)
        {
            MapearPresentacionNegocio();
            if (gestionMat.Remove() > 0)
                CargarMatriculas();
            else
                MessageBox.Show("Error al desmatricular", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            txtError.Text = gestionMat.Error();
        }

        private void dgvCursos_CellClick(object boton, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtCodigoMatricula.Text = ((Curso)dgvCursos.Rows[e.RowIndex].DataBoundItem).Codigo;
        }

        private void dgvMatriculados_CellClick(object boton, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var gestion = dgvMatriculados.Rows[e.RowIndex].DataBoundItem;
            switch (gestion)
            {
                case Matricula matricula: txtDniAlumno.Text = matricula.Dni; txtCodigoMatricula.Text = matricula.CodigoCurso;
                    break;
                case Alumno alumno: txtDniAlumno.Text = alumno.Dni;
                    break;
                case Curso curso: txtCodigoMatricula.Text = curso.Codigo;
                    break;
            }
        }

    }
}
