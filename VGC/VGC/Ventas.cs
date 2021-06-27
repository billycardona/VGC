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
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
            llenarCombo();
        }

        float total = 0;

        private void noDatos()
        {
            lblNombre.Text = "Undefined";
            lblPrecio.Text = "Undefined";
            txtDescripcion.Text = "Undefined";
        }
        private void llenarCombo()
        {
            try
            {
                string consulta = $"select ID, Nombre from vgc.figura_accion where Franquicia = '{txtFranquicia.Text}';";
                DataBase connection = new DataBase();
                txtFigura.DataSource = connection.consultar(consulta);
                txtFigura.DisplayMember = "Nombre";
                txtFigura.ValueMember = "ID";
            }
            catch (Exception)
            {
            }
        }

        private void llenarInfo()
        {
            try
            {
                if (txtFigura.SelectedValue != null && txtFigura.SelectedItem != null)
                {
                    btnComprar.Enabled = true;
                    string consulta = $"select Precio, Descripcion from vgc.figura_accion where ID = {txtFigura.SelectedValue};";
                    DataBase connection = new DataBase();

                    DataTable dt = new DataTable();
                    dt = connection.consultar(consulta);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        lblNombre.Text = txtFigura.Text;
                        lblPrecio.Text = row["Precio"].ToString();
                        txtDescripcion.Text = row["Descripcion"].ToString();
                    }
                }
                else
                {
                    noDatos();
                    btnComprar.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
        }

        private void llenarTabla()
        {
            dgvCompra.Rows.Add(
                txtFranquicia.Text,
                lblNombre.Text,
                txtDescripcion.Text,
                lblPrecio.Text);
            calcularTotal();
        }

        private void calcularTotal()
        {
            total += float.Parse(lblPrecio.Text);
            lblTotal.Text = total.ToString("0.00");
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
        }

        private void txtFranquicia_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarCombo();
            llenarInfo();
        }

        private void txtFigura_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarInfo();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            llenarTabla();
        }
    }
}
