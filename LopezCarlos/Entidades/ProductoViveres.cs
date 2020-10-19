using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoViveres: Producto
    {
        #region Propiedades
        private int productoViveresId;

        public override int IdProducto
        {
            get { return productoViveresId; }
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
            get { return Producto.ETipoDeProducto.Viveres; }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// /Sobrecarga del contructor de la clase base que agrega EUnidades por parámetro y genera el Id único
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipoDeauto"></param>
        public ProductoViveres(string nombre, float precioUnitario, int cantidad, string marca) : base(nombre, precioUnitario, cantidad, marca)
        {
            this.productoViveresId = codigoDeProducto++;

        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Sobrecarga del operador != para validar si dos objetos son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unProductoV"></param>
        /// <param name="otroProductoV"></param>
        /// <returns></returns>
        public static bool operator ==(ProductoViveres unProductoV, ProductoViveres otroProductoV)
        {
            return (unProductoV.IdProducto == otroProductoV.IdProducto);
        }

        /// <summary>
        /// Sobrecarga del operador != para validar si dos objetos NO son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unProductoV"></param>
        /// <param name="otroProductoV"></param>
        /// <returns></returns>
        public static bool operator !=(ProductoViveres unProductoV, ProductoViveres otroProductoV)
        {
            return !(unProductoV.IdProducto == otroProductoV.IdProducto);
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
