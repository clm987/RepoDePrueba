using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        protected string nombre;
        protected string marca;
        protected float precioUnitario;
        protected static int codigoDeProducto = 1;
        protected int cantidad;

        public enum ETipoDeProducto
        {
            Kiosco,
            Perecedero,
            Viveres
        }

        public abstract ETipoDeProducto TipoDeProducto
        {
            get;
        }

        public abstract int IdProducto
        {
            get;
        }

        public abstract string Nombre
        {
            get;
        }

        public abstract string Marca
        {
            get;
        }

        public abstract float PrecioUnitario
        {
            get;
        }

       public abstract int Cantidad
      {
           set;
           get;
        }


        #region Constructores
        public Producto(string nombre, float precioUnitario, int cantidad, string marca)
        {
            this.nombre = nombre;
            this.precioUnitario = precioUnitario;
            this.cantidad = cantidad;
            this.marca = marca;
        }
        #endregion

        #region Métodos
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region Sobrecarga de Tipo
        /// <summary>
        /// Sobrecarga explicita del tipo string. 
        /// </summary>
        /// <param name="unProducto"></param>
        public static explicit operator string(Producto unProducto)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre de producto: {unProducto.nombre}");
            sb.AppendLine($"Marca de producto:  {unProducto.marca}");
            sb.AppendLine($"Precio por unidad: {unProducto.precioUnitario.ToString()}");

            return sb.ToString();
        }
        #endregion

        #region Sobrecarga de Operadores

        /// <summary>
        /// Sobrecarga del operador != para validar si dos objetos son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unProductoV"></param>
        /// <param name="otroProductoV"></param>
        /// <returns></returns>
        public static bool operator ==(List<Producto> listaDeProductos, Producto unProducto)
        {
            bool retValue = false;

            for (int i = 0; i < listaDeProductos.Count; i++)
            {
                if (listaDeProductos[i].IdProducto == unProducto.IdProducto)
                {
                    retValue = true;
                }
            }

            return retValue;

        }

        /// <summary>
        /// Sobrecarga del operador != para validar si dos objetos NO son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unProductoV"></param>
        /// <param name="otroProductoV"></param>
        /// <returns></returns>
        public static bool operator !=(List<Producto> listaDeProductos, Producto unProducto)
        {
            return !(listaDeProductos == unProducto);
        }
        #endregion

    }
}
