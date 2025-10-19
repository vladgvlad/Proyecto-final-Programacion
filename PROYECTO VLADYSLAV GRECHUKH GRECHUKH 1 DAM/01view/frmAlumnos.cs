using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PROYECTO._02aplication;

namespace PROYECTO._01view
{
    public partial class frmAlumnos : Form
    {
        private GestionAlumnos gestion;

        public frmAlumnos()
        {
            InitializeComponent();
            gestion = new GestionAlumnos();
            CargarLista();
            dgvAlumnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlumnos.CellClick += dgvAlumnos_CellClick;
        }

        private void CargarLista() => dgvAlumnos.DataSource = gestion.GetAll();

        private void MapearNegocioPresentacion()
        {
            txtDni.Text = gestion.Alumno.Dni;
            txtNombre.Text = gestion.Alumno.Nombre;
            txtApellidos.Text = gestion.Alumno.Apellidos;
            txtTelefono.Text = gestion.Alumno.Telefono;
            txtPoblacion.Text = gestion.Alumno.Poblacion;
            DestacarFila(gestion.Alumno.Dni);
        }

        private void DestacarFila(string dni)
        {
            dgvAlumnos.ClearSelection();
            var row = dgvAlumnos.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells["Dni"].Value?.ToString() == dni);
            if (row != null)
            {
                row.Selected = true;
                dgvAlumnos.FirstDisplayedScrollingRowIndex = row.Index;
            }
        }

        private void MapearPresentacionNegocio()
        {
            gestion.Alumno.Dni = txtDni.Text.Trim();
            gestion.Alumno.Nombre = txtNombre.Text.Trim();
            gestion.Alumno.Apellidos = txtApellidos.Text.Trim();
            gestion.Alumno.Telefono = txtTelefono.Text.Trim();
            gestion.Alumno.Poblacion = txtPoblacion.Text.Trim();
        }

        private void btnInicio_Click(object sender, EventArgs e) => Navegar(gestion.Primero);
        private void btnAnterior_Click(object sender, EventArgs e) => Navegar(gestion.Anterior);
        private void btnSiguiente_Click(object sender, EventArgs e) => Navegar(gestion.Siguiente);
        private void btnUltimo_Click(object sender, EventArgs e) => Navegar(gestion.Ultimo);

        private void Navegar(Func<Alumno> fn)
        {
            var a = fn();
            if (a != null)
            {
                gestion.Alumno = a;
                MapearNegocioPresentacion();
            }
        }

        private void dgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = dgvAlumnos.Rows[e.RowIndex];
            gestion.Alumno = new Alumno(
                fila.Cells["Dni"].Value?.ToString() ?? "",
                fila.Cells["Nombre"].Value?.ToString() ?? "",
                fila.Cells["Apellidos"].Value?.ToString() ?? "",
                fila.Cells["Poblacion"].Value?.ToString() ?? "",
                fila.Cells["Telefono"].Value?.ToString() ?? ""
            );
            MapearNegocioPresentacion();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ResetColors();
            var dni = txtDni.Text?.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                txtDni.BackColor = Color.Red;
                return;
            }

            var alumno = gestion.GetById(dni);
            if (alumno != null)
            {
                gestion.Alumno = alumno;
                MapearNegocioPresentacion();
                txtDni.BackColor = Color.Blue;
            }
            else
            {
                MessageBox.Show("Alumno no encontrado.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            ResetColors();
            MapearPresentacionNegocio();
            if (gestion.Insert() > 0)
            {
                CargarLista();
                MapearNegocioPresentacion();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            ResetColors();
            MapearPresentacionNegocio();
            if (gestion.Edit() > 0)
            {
                CargarLista();
                MapearNegocioPresentacion();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (gestion.Remove() > 0)
            {
                CargarLista();
                LimpiarCampos();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ResetColors();
        }

        private bool ValidarCampos()
        {
            foreach (var txt in new[] { txtDni, txtNombre, txtApellidos, txtTelefono, txtPoblacion })
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.BackColor = Color.Red;
                    return false;
                }
            }
            return true;
        }

        private void ResetColors()
        {
            foreach (var txt in new[] { txtDni, txtNombre, txtApellidos, txtTelefono, txtPoblacion })
                txt.BackColor = SystemColors.Window;
        }

        private void LimpiarCampos()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellidos.Clear();
            txtTelefono.Clear();
            txtPoblacion.Clear();
        }

        private void btnPrimero_Click(object sender, EventArgs e) => btnInicio_Click(sender, e);

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
