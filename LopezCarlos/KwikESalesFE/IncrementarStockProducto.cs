using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace KwikESalesFE
{
    public partial class IncrementarStockProducto : Form
    {
        Producto AuxProducto;
        public IncrementarStockProducto()
        {
            InitializeComponent();
        }

        private void IncrementarStockProducto_Load(object sender, EventArgs e)
        {
            dgvListaDeProductos.DataSource = Comercio.listProductos;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            try
            {
                Validaciones.validarEntradaCantidad(txtCantidad.Text);
                int auxCantidadProducto;
                int.TryParse(txtCantidad.Text, out auxCantidadProducto);
                if (auxCantidadProducto > 0)
                {
                    AuxProducto.Cantidad += auxCantidadProducto;
                    dgvListaDeProductos.DataSource = Comercio.listaDeProductos;
                    MessageBox.Show(String.Format("Se modifico correctamente el Stock del Producto: {0}", AuxProducto.Nombre));
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new EmptyImputException("La cantidad no puede ser cero");
                }

            }
            catch (EmptyImputException ex)
            {

                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {

                MessageBox.Show("Verifique los datos ingresados");
            }

        }

        private void btnAltaNuevoProducto_Click(object sender, EventArgs e)
        {
            AltaNuevoProducto auxAltaProducto = new AltaNuevoProducto();
            auxAltaProducto.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                auxAltaProducto.Close();
            }
        }

        private void txtIdProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Validaciones.validarEntradaIdProducto(txtIdProducto.Text);
                int auxIdProdcuto;
                int.TryParse(txtIdProducto.Text, out auxIdProdcuto);
                AuxProducto = Comercio.buscarProductoPorId((auxIdProdcuto));
                lblProductoSeleccionado.Text = AuxProducto.Mostrar();
            }
            catch (EmptyImputException ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
    }
}
