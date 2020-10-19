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
using System.Media;

namespace KwikESalesFE
{
    public partial class MenuPrincipal : Form
    {

        public MenuPrincipal()
        {
            InitializeComponent();

        }

        private void menuPrincipal_Load(object sender, EventArgs e)
        {
            cargaInicial();
            Login ventanaLogin = new Login();
            ventanaLogin.ShowDialog();
            if (ventanaLogin.DialogResult == DialogResult.OK)
            {
                MenuPrincipal nuevoInicio = new MenuPrincipal();
            }
            else
            {
                this.Close();
            }

        }

        private void cargaInicial()
        {
            Comercio.Harcodeos();
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            MenuDeVentas AuxMenuDeVentas = new MenuDeVentas();

            AuxMenuDeVentas.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                AuxMenuDeVentas.Close();
            }
        }

        private void btnIngresarProducto_Click(object sender, EventArgs e)
        {
            IncrementarStockProducto auxVentanaIncrementar = new IncrementarStockProducto();
            auxVentanaIncrementar.ShowDialog();
            if(DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Producto ingresado con exito");
                auxVentanaIncrementar.Close();
            }

           
        }

        private void btnReportesVarios_Click(object sender, EventArgs e)
        {
            MenuDeReportes auxMenuDeReportes = new MenuDeReportes();
            auxMenuDeReportes.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                auxMenuDeReportes.Close();
            }
        }

    }
}
