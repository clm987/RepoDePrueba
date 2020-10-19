using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado: Persona
    {
        #region Propiedades
        private int empleadoId;
        string usuario;

        public int idEmpleado
        {
            get { return empleadoId; }
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

        public string Usuario
        {
            get { return usuario; }
        }
        #endregion

        #region Enumerado
        /// <summary>
        /// Tipo de dato Enum para area del empleado
        /// </summary>
        public enum EArea
        {
            Gerencia,
            Caja,
            Ventas,
        }
        EArea area;
        #endregion

        #region Constructores
        public Empleado(string nombre, string apellido, int dni, EArea areaEmpleado, string usuario) : base(nombre, apellido, dni)
        {
            this.area = areaEmpleado;
            this.usuario = usuario;
            this.empleadoId = codigoDeEmpleado++;
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Sobrecarga del operador == para validar si dos objetos son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unCliente"></param>
        /// <param name="otroCliente"></param>
        /// <returns></returns>
        public static bool operator ==(Empleado otroEmpleado, Empleado unEmpleado)
        {
            bool retValue = false;
            // for (int i = 0; i < listaEmpleados.Count; i++)
            // {
            if (otroEmpleado.idEmpleado == unEmpleado.idEmpleado)
            {
                retValue = true;
            }
            //  }
            return retValue;
        }

        /// <summary>
        /// Sobrecarga del operador != para validar si dos objetos NO son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unCliente"></param>
        /// <param name="otroCliente"></param>
        /// <returns></returns>
        public static bool operator !=(Empleado otroEmpleado, Empleado unEmpleado)
        {
            return !(otroEmpleado == unEmpleado);
        }
        #endregion

        #region Métodos

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(idEmpleado.ToString());

            return sb.ToString();
        }
        #endregion


    }
}
