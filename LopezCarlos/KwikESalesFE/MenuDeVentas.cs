﻿using System;
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
using System.IO;

namespace KwikESalesFE
{
    public partial class MenuDeVentas : Form
    {
        int auxcantidad = -1;
        SoundPlayer sonidoCaja;


        public MenuDeVentas()
        {
            InitializeComponent();
        }

        private void MenuDeVentas_Load(object sender, EventArgs e)
        {
            var projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(projectPath, "Resources");
            ddvProductos.DataSource = Comercio.listProductos;
            sonidoCaja = new SoundPlayer();
            sonidoCaja.SoundLocation = Path.Combine(filePath, "cajaRegistradora.wav");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string auxDni;
            auxDni = Comercio.BuscarClientePorDni(this.txtDni.Text);
            lblDatosCliente.Text = auxDni;
        }

        private void ddvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int idProductoSeleccionado = (int)ddvProductos.CurrentRow.Cells[1].Value;
                Producto auxProducto = Comercio.buscarProductoPorId(idProductoSeleccionado);
                Validaciones.validarEntradaDni(txtDni.Text);
                Validaciones.validarEntradaCantidad(txtCantidad.Text);
                if (!buscarProductoRepetido(auxProducto))
                {
                    Comercio.ConfirmarStock(idProductoSeleccionado, auxcantidad);
                    int.TryParse(txtCantidad.Text, out auxcantidad);
                    crearItemCompra(auxProducto);
                    lblMonto.Text = (Comercio.CalcularMontoVenta(Comercio.listaDelCarrito)).ToString();
                }
                else
                {
                    for (int i = 0; i < Comercio.listaDelCarrito.Count; i++)
                    {
                        if (Comercio.listaDelCarrito[i].codigoDeProducto == idProductoSeleccionado)
                        {
                            Comercio.ConfirmarStock(idProductoSeleccionado, (auxcantidad + Comercio.listaDelCarrito[i].cantidad));
                            Comercio.listaDelCarrito[i].cantidad += auxcantidad;
                        }
                    }
                }
                dgvResumenCompra.DataSource = null;
                dgvResumenCompra.DataSource = Comercio.listCarrito;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Producto no encontrado");
            }
            catch (StockException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (EmptyImputException ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }

        public bool buscarProductoRepetido(Producto unProducto)
        {
            bool retValue = false;
            if (Comercio.listaDelCarrito.Count == 0)
            {
                return retValue;

            }

            for (int i = 0; i < Comercio.listaDelCarrito.Count; i++)
            {
                if (unProducto.IdProducto == Comercio.listaDelCarrito[i].codigoDeProducto)
                {
                    retValue = true;
                }
            }
            return retValue;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            int cantidadseleccionada = 0;

            if (int.TryParse(txtCantidad.Text, out cantidadseleccionada))
            {
                auxcantidad = cantidadseleccionada;
            }
        }

        private void dgvResumenCompra_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int auxCodigoProductoSeleccionado = (int)dgvResumenCompra.CurrentRow.Cells[3].Value;
            ItemCompra auxItemCompra = buscarItemCompraPorId(auxCodigoProductoSeleccionado);

            if (Comercio.listaDelCarrito.Count > 0)
            {
                if (auxItemCompra.cantidad > 0)
                {
                    --auxItemCompra.cantidad;
                    if (auxItemCompra.cantidad == 0)
                    {
                        Comercio.listaDelCarrito.Remove(auxItemCompra);
                    }
                }
                dgvResumenCompra.DataSource = null;
                dgvResumenCompra.DataSource = Comercio.listaDelCarrito;
            }
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            string auxDni = txtDni.Text;
            Cliente clienteVentaActual = Comercio.DevolverClientePorDni(auxDni);
            if (!String.IsNullOrEmpty(lblDatosCliente.Text))
            {
                if (lblDatosCliente.Text != "Cliente no Encontrado")
                {
                    if (float.TryParse(lblMonto.Text, out float auxMonto))
                    {
                        if (Comercio.listaDelCarrito != null)
                        {
                            for (int i = 0; i < Comercio.listaDelCarrito.Count; i++)
                            {

                                Comercio.ModificarCantidad(Comercio.listaDelCarrito[i].CodigoItem, Comercio.listaDelCarrito[i].cantidad);
                            }
                            Venta ventaActual = new Venta(clienteVentaActual, Comercio.UsuarioActivo, auxMonto);
                            Comercio.listaDeVentas.Add(ventaActual);
                            ddvProductos.DataSource = null;
                            ddvProductos.DataSource = Comercio.listaDeProductos;
                            lblMonto.Text = Comercio.CalcularDescuentoSimpson(Comercio.listaDelCarrito, clienteVentaActual).ToString();
                            MessageBox.Show("Se aplicó el descuento por se miembro de la familia Simpson");
                            generarTicketCompra(Comercio.listaDelCarrito);
                            sonidoCaja.Play();
                            Comercio.listaDelCarrito.Clear();
                            DialogResult = DialogResult.OK;
                            MessageBox.Show("Gracias!! Vuelva Prontosss!!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Antes de debe agregar al cliente");
                }
            }
            else
            {
                MessageBox.Show("Antes de debe agregar al cliente");
            }
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            AltaNuevoCliente VentanaAltaCliente = new AltaNuevoCliente();
            VentanaAltaCliente.ShowDialog();
            if (VentanaAltaCliente.DialogResult == DialogResult.OK)
            {
                txtDni.Text = Comercio.DniNuevoCliente;
                string auxDniNuevoCliente = Comercio.BuscarClientePorDni(this.txtDni.Text);
                lblDatosCliente.Text = auxDniNuevoCliente;
                MessageBox.Show("Cliente dado de alta!");
                VentanaAltaCliente.Close();
            }
        }

     /*   public Producto buscarProductoPorId(int idProducto)
        {
            Producto auxProducto = null;
            for (int i = 0; i < Comercio.listaDeProductos.Count; i++)
            {
                if (Comercio.listaDeProductos[i].IdProducto == idProducto)
                {
                    auxProducto = Comercio.listaDeProductos[i];
                }
            }
            return auxProducto;
        }*/

        public ItemCompra buscarItemCompraPorId(int idProducto)
        {
            ItemCompra auxItem = null;
            for (int i = 0; i < Comercio.listaDelCarrito.Count; i++)
            {
                if (Comercio.listaDelCarrito[i].codigoDeProducto == idProducto)
                {
                    auxItem = Comercio.listaDelCarrito[i];
                }
            }
            return auxItem;
        }

        public void crearItemCompra(Producto productoSeleccionado)
        {
            string nombre = productoSeleccionado.Nombre;
            float precio = productoSeleccionado.PrecioUnitario;
            int cantidad = auxcantidad;
            string marca = productoSeleccionado.Marca;
            int idProducto = productoSeleccionado.IdProducto;
            Comercio.listaDelCarrito.Add(new ItemCompra(nombre, marca, precio, idProducto, cantidad));
            lblIntruccionEliminarItem.Text = "Para elmininar un item haga doble click";
        }

        public void generarTicketCompra(List<ItemCompra> listaCompraActual)
        {
            string auxMontoVenta = ("Monto total de la venta:  " + lblMonto.Text);
            StreamWriter auxTicket = new StreamWriter(Directory.GetCurrentDirectory() + "/ticketVenta.txt");
            auxTicket.WriteLine("*************************|Kiw-E-Mart|*************************");
            auxTicket.WriteLine(DateTime.Now.ToString());
            auxTicket.WriteLine(lblDatosCliente.Text.Trim());
            auxTicket.WriteLine("--------------------------------------------------");
            auxTicket.WriteLine("Producto            |Marca               |Cantidad            ");
            foreach (ItemCompra item in listaCompraActual)
            {
                auxTicket.WriteLine(String.Format("{0,-20}{1,-20}{2,10}", item.NombreItem, item.marca, item.cantidad));
            }
            auxTicket.WriteLine("--------------------------------------------------");
            auxTicket.WriteLine(auxMontoVenta);
            auxTicket.Close();
        }
    }
}
