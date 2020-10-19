using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente: Persona
    {
        #region Propiedades
        private int clienteId;

        public int idCliente
        {
            get { return clienteId; }
        }

        public int dniCliente
        {
            get { return base.dni; }
        }

        public override int Dni
        {
            get { return this.dni; }
        }

        public override string NombreyApellido
        {
            get { return String.Concat(this.nombre, this.apellido); }
        }

        public override string Apellido
        {
            get { return this.apellido; }
        }

        #endregion

        #region Constructores
        public Cliente(string nombre, string apellido, int dni) : base(nombre, apellido, dni)
        {
            this.clienteId = codigoDeCliente++;
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Sobrecarga del operador == para validar si dos objetos son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unCliente"></param>
        /// <param name="otroCliente"></param>
        /// <returns></returns>
        public static bool operator ==(Cliente unCliente, Cliente otroCliente)
        {
            return (unCliente.clienteId == otroCliente.clienteId);
        }

        /// <summary>
        /// Sobrecarga del operador != para validar si dos objetos NO son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unCliente"></param>
        /// <param name="otroCliente"></param>
        /// <returns></returns>
        public static bool operator !=(Cliente unCliente, Cliente otroCliente)
        {
            return !(unCliente.clienteId == otroCliente.clienteId);
        }
        #endregion

        #region Métodos

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            return sb.ToString();
        }
        #endregion
    }
}
