using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        #region Atributos y Propiedades
        float montoVenta;
        Empleado unEmpleado;
        Cliente unCliente;

        public int ElEmpleadoId
        {
            get { return unEmpleado.idEmpleado; }
        }

        public string NombreYApellidoCliente
        {
            get { return unCliente.NombreyApellido; }
        }

        public float MontoVenta
        {
            get { return montoVenta; }
        }

        #endregion 

        #region Constructor
        public Venta(Cliente unCliente, Empleado unEmpleado, float monto)
        {
            this.unCliente = unCliente;
            this.unEmpleado = unEmpleado;
            this.montoVenta = monto;
        }
        #endregion

        public virtual string Mostrar()
        {
            return (string)this;
        }

        #region Sobrecarga de Tipo
        /// <summary>
        /// Sobrecarga explicita del tipo string. 
        /// </summary>
        /// <param name="unProducto"></param>
        public static explicit operator string(Venta unaVenta)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre y Apellido del cliente: {unaVenta.unCliente}");
            sb.AppendLine($"Monto de la venta: {unaVenta.montoVenta}");

            return sb.ToString();
        }

        #endregion
        /* #region Sobrecarga de Operadores
         /// <summary>
         /// Sobrecarga del operador == para validar si dos objetos son iguales a partir del atributo Id
         /// </summary>
         /// <param name="unaVenta"></param>
         /// <param name="otraVenta"></param>
         /// <returns></returns>
         public static bool operator ==(Venta unaVenta, Venta otraVenta)
         {
             return (unaVenta.idVenta == otraVenta.idVenta);
         }

         /// <summary>
         /// Sobrecarga del operador != para validar si dos objetos NO son iguales a partir del atributo Id
         /// </summary>
         /// <param name="unaVenta"></param>
         /// <param name="otraVenta"></param>
         /// <returns></returns>
         public static bool operator !=(Venta unaVenta, Venta otraVenta)
         {
             return !(unaVenta.ventaId == otraVenta.ventaId);
         }
         #endregion*/


    }
}
