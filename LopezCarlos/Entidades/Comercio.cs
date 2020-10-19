using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Comercio
    {
        public static List<Producto> listaDeProductos;
        public static List<Persona> listaDePersonas;
        public static List<Cliente> listaDeClientes;
        public static List<Empleado> listaDeEmpleados;
        public static Dictionary<string, string> usuarios;
        public static List<Venta> listaDeVentas;
        public static List<ItemCompra> listaDelCarrito;

        public enum ETipoDeProducto
        {
            Kiosco,
            Perecedero,
            Viveres
        }

        public static ETipoDeProducto tipoDeProducto;

        public static ETipoDeProducto TipoDeProducto
        {
            get { return tipoDeProducto; }
        }



        public static string dniNuevoCliente;

        public static string DniNuevoCliente
        {
            get { return dniNuevoCliente; }
            set { dniNuevoCliente = value; }
        }

        public static Empleado user;

        public static Empleado UsuarioActivo
        {
            get { return user; }
            set { user = value; }
        }

        public static Empleado empleadoSeleccionadoId;

        public static Empleado EmpleadoSelect
        {
            get { return empleadoSeleccionadoId; }
        }


        static Comercio()
        {
            listaDeProductos = new List<Producto>();
            listaDePersonas = new List<Persona>();
            listaDeClientes = new List<Cliente>();
            listaDeEmpleados = new List<Empleado>();
            usuarios = new Dictionary<string, string>();
            listaDeVentas = new List<Venta>();
            listaDelCarrito = new List<ItemCompra>();
        }
        /// <summary>
        /// Obtiene la lista de productos
        /// </summary>
        public static List<ItemCompra> listCarrito
        {
            get { return listaDelCarrito; }
        }

        /// <summary>
        /// Obtiene la lista de productos
        /// </summary>
        public static List<Venta> listVentas
        {
            get { return listaDeVentas; }
        }

        /// <summary>
        /// Obtiene la lista de productos
        /// </summary>
        public static List<Empleado> listEmpleados
        {
            get { return listaDeEmpleados; }
        }

        /// <summary>
        /// Obtiene la lista de productos
        /// </summary>
        public static List<Producto> listProductos
        {
            get { return listaDeProductos; }
        }

        public static void MostrarListaProductos()
        {
            foreach (Producto item in listaDeProductos)
            {
                item.Mostrar();
            }
        }

        public static bool MostrarListaPersonas(List<Persona> listaDePersonas)
        {
            bool retValue = false;

            foreach (Persona item in listaDePersonas)
            {
                item.Mostrar();
                retValue = true;
            }

            return retValue;
        }
        #region Harcodeos
        public static void Harcodeos()
        {
            Cliente PrimerCliente = new Cliente("Homero", "simpson", 32425312);
            Cliente SegundoCliente = new Cliente("Ned", "flanders", 25789632);
            Cliente TercerCliente = new Cliente("March", "simpson", 14526325);
            listaDeClientes.Add(PrimerCliente);
            listaDeClientes.Add(SegundoCliente);
            listaDeClientes.Add(TercerCliente);

            Empleado PrimerEmpleado = new Empleado("Fineas", "Grant", 32456987, Empleado.EArea.Caja, "fagrant");
            Empleado SegundoEmpleado = new Empleado("Lola", "Palooza", 25418745, Empleado.EArea.Ventas, "lpalooza");
            Empleado TercerEmpleado = new Empleado("Nasha", "Yeloso", 32456987, Empleado.EArea.Gerencia, "Nyeloso");

            listaDeEmpleados.Add(PrimerEmpleado);
            listaDeEmpleados.Add(SegundoEmpleado);
            listaDeEmpleados.Add(TercerEmpleado);

            Producto PrimerProducto = new ProductoPerecedero("Leche", 125, 0, "La veronica");
            Producto SegundoProducto = new ProductoPerecedero("Manteca", 12, 12, "Girasol");
            Producto TercerProducto = new ProductoPerecedero("Jamon", 125, 12, "El cerdito");
            Producto CuartoProducto = new ProductoViveres("Arroz", 49.5f, 2, "3 hermanos");
            Producto QuintoProducto = new ProductoViveres("Azucar", 35.5f, 2, "La dulsura");
            Producto SextoProducto = new ProductoViveres("Harina", 49.5f, 5, "Salinas");
            Producto SeptimoProducto = new ProductoKiosko("Dulce de Leche", 125.2f, 12, "Vauquita");
            Producto OctavoProducto = new ProductoKiosko("Chocolate", 80, 12, "Cacao");
            Producto NovenoProducto = new ProductoKiosko("Alfajor lalala", 45, 1, "Guaymayen");

            listaDeProductos.Add(PrimerProducto);
            listaDeProductos.Add(SegundoProducto);
            listaDeProductos.Add(TercerProducto);
            listaDeProductos.Add(CuartoProducto);
            listaDeProductos.Add(QuintoProducto);
            listaDeProductos.Add(SextoProducto);
            listaDeProductos.Add(SeptimoProducto);
            listaDeProductos.Add(OctavoProducto);
            listaDeProductos.Add(NovenoProducto);

            Venta PrimeraVenta = new Venta(PrimerCliente, PrimerEmpleado, 1235);
            Venta SegundaVenta = new Venta(SegundoCliente, SegundoEmpleado, 1352);
            Venta TerceraVenta = new Venta(TercerCliente, TercerEmpleado, 1500);
            listaDeVentas.Add(PrimeraVenta);
            listaDeVentas.Add(SegundaVenta);
            listaDeVentas.Add(TerceraVenta);


        }

        public static void UsuariosHarcodeo()
        {
            usuarios.Add("fagrant", "1234");
            usuarios.Add("lpalooza", "1111");
            usuarios.Add("Nyeloso", "1111");
        }
        #endregion

        public static string BuscarClientePorDni(string dniCliente)
        {
            string retValue = "Cliente no Encontrado";

            foreach (Cliente item in listaDeClientes)
            {

                if (int.TryParse(dniCliente, out int auxDni))
                {

                    if (item.dniCliente == auxDni)
                    {
                        retValue = item.Mostrar();
                        break;
                    }

                }

            }

            return retValue;
        }

        public static Cliente DevolverClientePorDni(string dniCliente)
        {
            Cliente retValue = null;

            foreach (Cliente item in listaDeClientes)
            {

                if (int.TryParse(dniCliente, out int auxDni))
                {

                    if (item.dniCliente == auxDni)
                    {
                        retValue = item;
                        return retValue;
                    }

                }

            }

            return retValue;
        }

        public static bool ValidarLogin(string usuario, string contrasenia)
        {
            bool retValue = false;

            foreach (var item in usuarios)
            {

                if (item.Key == usuario && item.Value == contrasenia)
                {
                    retValue = true;
                    return retValue;
                }

            }

            return retValue;
        }

        public static bool ModificarCantidad(int productoseleccionadoId, int cantidadamodificar)
        {
            bool retValue = false;

            if (productoseleccionadoId > 0 && cantidadamodificar > 0)
            {

                for (int i = 0; i < Comercio.listaDeProductos.Count; i++)
                {
                    if(Comercio.listaDeProductos[i].IdProducto == productoseleccionadoId)
                    {
                        Comercio.listaDeProductos[i].Cantidad -= cantidadamodificar;
                    }
                }
                retValue = true;
            }

            return retValue;
        }

        public static Producto buscarProductoPorId(int idProducto)
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
        }

        public static float CalcularMontoVenta(List<ItemCompra> productosSeleccionadosCarrito)
        {
            float total = 0;
            for (int i = 0; i < productosSeleccionadosCarrito.Count; i++)
            {
                total += productosSeleccionadosCarrito[i].cantidad * productosSeleccionadosCarrito[i].PrecioItem;
            }

            return total;
        }

        public static float CalcularDescuentoSimpson(List<ItemCompra> productosSeleccionadosCarrito, Cliente clienteActual)
        {
            float total = 0;
            for (int i = 0; i < productosSeleccionadosCarrito.Count; i++)
            {
                total += productosSeleccionadosCarrito[i].cantidad * productosSeleccionadosCarrito[i].PrecioItem;
            }

            if(clienteActual.Apellido == "simpson")
            {
                total = total * 0.87F;
            }
            return total;
        }

        public static Empleado BusacarEmpleadoPorUsuario(string usuario)
        {
            Empleado auxEmpleado = null;

            foreach (Empleado item in listaDeEmpleados)
            {

                if (item.Usuario == usuario)
                {
                    auxEmpleado = item;
                }
            }
            return auxEmpleado;
        }

        public static void ConfirmarStock(int idProductoAValidar, int cantidaProductoSeleccionado)
        {
            StockException ex = new StockException("No hay suficiente stock");

            foreach (Producto item in listProductos)
            {
                if (item.IdProducto == idProductoAValidar)
                {
                    if (item.Cantidad > 0)
                    {
                        if (cantidaProductoSeleccionado <= item.Cantidad)
                        {
                            continue;
                        }
                        else
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
        }

        public static void ActualizarStock(List<Producto> unalistaDeProductos, Producto unProducto)
        {
            for (int i = 0; i < unalistaDeProductos.Count; i++)
            {
                if (unalistaDeProductos[i].IdProducto == unProducto.IdProducto)
                {
                    int auxcant1 = unProducto.Cantidad;
                    int auxcant2 = listaDeProductos[i].Cantidad;


                    unalistaDeProductos[i].Cantidad -= unProducto.Cantidad;
                    break;
                }
            }
        }

        public static bool AltaDeProductoPorTipo(string nombre, float precioUnitario, int cantidad, string marca, string tipoDeProducto, List<Producto> listaAñadirProducto)
        {
            bool retValue = false;
            switch (tipoDeProducto)
            {
                case ("Kiosco"):
                    ProductoKiosko nuevoProductoKiosko = new ProductoKiosko(nombre, precioUnitario, cantidad, marca);
                    listaAñadirProducto.Add(nuevoProductoKiosko);
                    retValue = true;
                    break;
                case ("Perecedero"):
                    ProductoPerecedero nuevoProductoPerecedero = new ProductoPerecedero(nombre, precioUnitario, cantidad, marca);
                    listaAñadirProducto.Add(nuevoProductoPerecedero);
                    retValue = true;
                    break;
                case ("Viveres"):
                    ProductoViveres nuevoProductoViveres = new ProductoViveres(nombre, precioUnitario, cantidad, marca);
                    listaAñadirProducto.Add(nuevoProductoViveres);
                    retValue = true;
                    break;
                default:
                    retValue = false;
                    break;
            }
            return retValue;
        }
    }
}
