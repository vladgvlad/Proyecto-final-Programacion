using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PROYECTO._02aplication;    
using PROYECTO._03data;          

namespace PROYECTO._01view
{
    public partial class frmCursos : Form
    {
        private readonly GestionCursos gestion;

        public frmCursos()
        {
            InitializeComponent();
            gestion = new GestionCursos();
            dgvCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCursos.CellClick += (boton, e) => dgvCursos_CellClick(boton, e);
            CargarLista();
        }

        private void CargarLista()
        {
            dgvCursos.DataSource = gestion.GetAll();
        }

        private void MapearNegocioPresentacion()
        {
            var curso = gestion.Curso;
            txtCodigo.Text = curso.Codigo;
            txtTitulo.Text = curso.Titulo;
            txtLugar.Text = curso.LugarRealizacion;
            txtNumeroPlazas.Text = curso.NumPlazas.ToString();
            txtPrecio.Text = curso.Precio.ToString("F2");
            DestacarFila(curso.Codigo);
        }

        private void DestacarFila(string codigo)
        {
            dgvCursos.ClearSelection();
            foreach (DataGridViewRow row in dgvCursos.Rows)
            {
                if (row.Cells["Codigo"].Value?.ToString() == codigo)
                {
                    row.Selected = true;
                    dgvCursos.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void MapearPresentacionNegocio()
        {
            var curso = gestion.Curso;
            curso.Codigo = txtCodigo.Text.Trim();
            curso.Titulo = txtTitulo.Text.Trim();
            curso.LugarRealizacion = txtLugar.Text.Trim();
            curso.NumPlazas = int.Parse(txtNumeroPlazas.Text.Trim());
            curso.Precio = decimal.Parse(txtPrecio.Text.Trim());
        }

        private void NavegarCurso(Func<Curso> obtenerCurso)
        {
            var curso = obtenerCurso();
            if (curso != null)
            {
                gestion.Curso = curso;
                MapearNegocioPresentacion();
            }
        }

        private void btnInicio_Click(object boton, EventArgs e) => NavegarCurso(gestion.Primero);
        private void btnAnterior_Click(object boton, EventArgs e) => NavegarCurso(gestion.Anterior);
        private void btnSiguiente_Click(object boton, EventArgs e) => NavegarCurso(gestion.Siguiente);
        private void btnUltimo_Click(object boton, EventArgs e) => NavegarCurso(gestion.Ultimo);

        private void dgvCursos_CellClick(object boton, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = dgvCursos.Rows[e.RowIndex];

            gestion.Curso = new Curso(
                fila.Cells["Codigo"].Value?.ToString() ?? "",
                fila.Cells["Titulo"].Value?.ToString() ?? "",
                fila.Cells["LugarRealizacion"].Value?.ToString() ?? "",
                int.Parse(fila.Cells["NumPlazas"].Value?.ToString() ?? "0"),
                decimal.Parse(fila.Cells["Precio"].Value?.ToString() ?? "0")
            );
            MapearNegocioPresentacion();
        }

        private void btnFind_Click(object boton, EventArgs e)
        {
            ResetColors();
            if (txtCodigo.Text == null || txtCodigo.Text == "")
            {
                txtCodigo.BackColor = Color.Red;
                return;
            }

            var curso = gestion.GetById(txtCodigo.Text.Trim());
            if (curso != null)
            {
                gestion.Curso = curso;
                MapearNegocioPresentacion();
                txtCodigo.BackColor = Color.Blue;
            }
            else
            {
                MessageBox.Show("Curso no encontrado.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnInsert_Click(object boton, EventArgs e) => Ejecutar(gestion.Insert);
        private void btnEdit_Click(object boton, EventArgs e) => Ejecutar(gestion.Edit);
        private void Ejecutar(Func<int> ejec)
        {
            if (!ValidarCampos()) return;
            ResetColors();
            MapearPresentacionNegocio();
            if (ejec() > 0)
            {
                CargarLista();
                MapearNegocioPresentacion();
            }
        }

        private void btnRemove_Click(object boton, EventArgs e)
        {
            if (gestion.Remove() > 0)
            {
                CargarLista();
                LimpiarCampos();
            }
        }

        private void btnClear_Click(object boton, EventArgs e)
        {
            LimpiarCampos();
            ResetColors();
        }

        private bool ValidarCampos()
        {
            foreach (var text in new[] { txtCodigo, txtTitulo, txtLugar, txtNumeroPlazas, txtPrecio })
            {
                if (text.Text == null || text.Text.Trim() == "")
                {
                    text.BackColor = Color.Red;
                    return false;
                }
            }
            return true;
        }

        private void ResetColors()
        {
            foreach (var text in new[] { txtCodigo, txtTitulo, txtLugar, txtNumeroPlazas, txtPrecio }) text.BackColor = SystemColors.Window;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtTitulo.Clear();
            txtLugar.Clear();
            txtNumeroPlazas.Clear();
            txtPrecio.Clear();
        }

        private void txtLugar_TextChanged(object boton, EventArgs e) { }
        private void dgvCursos_CellContentClick(object boton, DataGridViewCellEventArgs e) => dgvCursos_CellClick(boton, e);
        private void frmCursos_Load(object boton, EventArgs e)
        {

        }
    }
}
