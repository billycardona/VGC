using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VGC
{
    public partial class btnActualizar : Form
    {
        public btnActualizar()
        {
            InitializeComponent();
        }

        int id;

        private void limpiar()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Value = 1;
            txtExistencia.Text = "En Existencia";
        }

        private void cargarTabla()
        {
            string consulta = $"select * from vgc.figura_accion where Franquicia = '{txtFranquicia.Text}';";
            DataBase connection = new DataBase();
            dgvFigura.DataSource = connection.consultar(consulta);
        }

        private void agregarFigura(Figura figura)
        {
            string consulta = "insert into vgc.figura_accion(Franquicia, Nombre, Descripcion, Precio, Existencia)" +
                $"values('{figura.franquicia}','{figura.nombre}', '{figura.descripcion}',{figura.precio}, '{figura.existencia}');";

            DataBase connection = new DataBase();
            connection.insertar(consulta);
            cargarTabla();
            limpiar();
        }

        private void actualizarTabla(Figura figura)
        {

            string update = "update vgc.figura_accion set " +
                $"Franquicia = '{figura.franquicia}', " +
                $"Nombre = '{figura.nombre}', " +
                $"Descripcion = '{figura.descripcion}', " +
                $"Precio = {figura.precio}, " +
                $"Existencia = '{figura.existencia}' " +
                $"where ID = {id};";

            DataBase connection = new DataBase();
            connection.insertar(update);
            limpiar();
        }

        private void label2_Click(object sender, EventArgs e)
        {
          
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Figura figura = new Figura(txtFranquicia.Text, txtNombre.Text, txtDescripcion.Text, float.Parse(txtPrecio.Text), txtExistencia.Text);

            agregarFigura(figura);
        }

        private void btnActualizar_Load(object sender, EventArgs e)
        {
            //Cargar una tabla general al iniciar
            string consulta = $"select * from vgc.figura_accion;";
            DataBase connection = new DataBase();
            dgvFigura.DataSource = connection.consultar(consulta);
        }

        private void txtFranquicia_SelectedIndexChanged(object sender, EventArgs e)
        { 
            cargarTabla();
        }

        private void dgvFigura_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgvFigura.SelectedRows[0];
            id = int.Parse(row.Cells[0].Value.ToString());
            txtNombre.Text = row.Cells[2].Value.ToString();
            txtDescripcion.Text = row.Cells[3].Value.ToString();
            txtPrecio.Text = row.Cells[4].Value.ToString();
            txtExistencia.Text = row.Cells[5].Value.ToString();
            txtFranquicia.Text = row.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Figura figura = new Figura(txtFranquicia.Text, txtNombre.Text, txtDescripcion.Text, float.Parse(txtPrecio.Text), txtExistencia.Text);

            actualizarTabla(figura);
            cargarTabla();
        }
    }
}
