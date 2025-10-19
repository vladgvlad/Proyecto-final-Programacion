using System;
using System.Windows.Forms;

namespace PROYECTO._01view
{
    public partial class frmAcademia : Form
    {
        public frmAcademia()
        {
            InitializeComponent();
        }
        private void btnAlumnos_Click(object boton, EventArgs e)
        {
            using (var frm = new frmAlumnos()) frm.ShowDialog();
        }

        private void btnCursos_Click(object boton, EventArgs e)
        {
            using (var frm = new frmCursos()) frm.ShowDialog();
        }

        private void btnMatriculas_Click(object boton, EventArgs e)
        {
            using (var frm = new FrmMatriculas()) frm.ShowDialog();
        }

        private void frmAcademia_Load(object boton, EventArgs e)
        {

        }
    }
}
