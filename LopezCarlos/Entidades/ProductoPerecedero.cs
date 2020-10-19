using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoPerecedero: Producto
    {
        #region Propiedades
        private int productoPerecederoId;

        public override int IdProducto
        {
            get { return productoPerecederoId; }
        }

        public override string Marca
        {
            get { return base.marca; }
        }

        public override string Nombre
        {
            get { return base.nombre; }
        }

        public override float PrecioUnitario
        {
            get { return base.precioUnitario; }
        }

       public override int Cantidad
       {
          get { return base.cantidad; }
           set { this.cantidad = value; }
       }

        public override ETipoDeProducto TipoDeProducto
        {
            get { return Producto.ETipoDeProducto.Perecedero; }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// /Sobrecarga del contructor de la clase base que genera el Id único
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="precioUnitario"></param>
        /// <param name="cantidad"></param>
        /// <param name="marca"></param>
        public ProductoPerecedero(string nombre, float precioUnitario, int cantidad, string marca) : base(nombre, precioUnitario, cantidad, marca)
        {
            this.productoPerecederoId = codigoDeProducto++;
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Sobrecarga del operador != para validar si dos objetos son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unProductoV"></param>
        /// <param name="otroProductoV"></param>
        /// <returns></returns>
        public static bool operator ==(ProductoPerecedero unProductoP, ProductoPerecedero otroProductoP)
        {
            return (unProductoP.productoPerecederoId == otroProductoP.productoPerecederoId);
        }

        /// <summary>
        /// Sobrecarga del operador != para validar si dos objetos NO son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unProductoV"></param>
        /// <param name="otroProductoV"></param>
        /// <returns></returns>
        public static bool operator !=(ProductoPerecedero unProductoP, ProductoPerecedero otroProductoP)
        {
            return !(unProductoP.productoPerecederoId == otroProductoP.productoPerecederoId);
        }
        #endregion

        #region Métodos
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(IdProducto.ToString());

            return sb.ToString();
        }
        #endregion

    }
}
