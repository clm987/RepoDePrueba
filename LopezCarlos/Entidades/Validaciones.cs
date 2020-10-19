﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Validaciones
    {
        public static EmptyImputException ex = null;

        public static void validarEntradaDni(string dniIngresado)
        {
            if (String.IsNullOrWhiteSpace(dniIngresado))
            {
                throw ex = new EmptyImputException("Debe ingresar un Dni Valido");
            }
            else
            {
                if(dniIngresado.Length >= 5)
                {
                    for (int i = 0; i < dniIngresado.Length; i++)
                    {
                        if (Char.IsLetter(dniIngresado[i]))
                        {
                            throw ex = new EmptyImputException("Debe ingresar un Dni Valido");
                        }
                    }
                }
                else
                {
                    throw ex = new EmptyImputException("Debe ingresar un Dni Valido");
                }
               
            }
        }

        public static void validarEntradaCantidad(string cantidadIngresada)
        {

            if (String.IsNullOrWhiteSpace(cantidadIngresada))
            {
                throw ex = new EmptyImputException("Debe ingresar una cantidad mayor a cero");
            }
            else
            {
                for (int i = 0; i < cantidadIngresada.Length; i++)
                {
                    if (Char.IsLetter(cantidadIngresada[i]))
                    {
                        throw ex = new EmptyImputException("Debe ingresar una cantidad valida");
                    }
                }
            }
        }

        public static void validarEntradaNombrePersona(string NombreIngresado)
        {
            if (String.IsNullOrWhiteSpace(NombreIngresado))
            {
                throw ex = new EmptyImputException("Verifique los datos ingresados");
            }
            else
            {
                for (int i = 0; i < NombreIngresado.Length; i++)
                {
                    if (!Char.IsLetter(NombreIngresado[i]))
                    {
                        throw ex = new EmptyImputException("Verifique los datos ingresados");
                    }
                }
            }
        }

        public static void validarEntradaNombreProducto(string NombreIngresado)
        {
            if (String.IsNullOrWhiteSpace(NombreIngresado))
            {
                throw ex = new EmptyImputException("Verifique los datos ingresados");
            }
        }

        public static void validarEntradaMarca(string MarcaIngresada)
        {
            if (String.IsNullOrWhiteSpace(MarcaIngresada))
            {
                throw ex = new EmptyImputException("Verifique los datos ingresados");
            }
        }

        public static void validarEntradaPrecio(string PrecioIngresado)
        {
            if (String.IsNullOrWhiteSpace(PrecioIngresado))
            {
                throw ex = new EmptyImputException("Verifique los datos ingresados");
            }
            else
            {
                for (int i = 0; i < PrecioIngresado.Length; i++)
                {
                    if (Char.IsLetter(PrecioIngresado[i]))
                    {
                        throw ex = new EmptyImputException("Debe ingresar un precio valido");
                    }
                }
            }
        }

        public static void validarEntradaIdProducto(string idProductoIngresada)
        {
            bool flagIdencontrado = false;
            if (String.IsNullOrWhiteSpace(idProductoIngresada))
            {
                throw ex = new EmptyImputException("Debe ingresar un Id válido");
            }
            else
            {
                for (int i = 0; i < idProductoIngresada.Length; i++)
                {
                    if (Char.IsLetter(idProductoIngresada[i]))
                    {
                        throw ex = new EmptyImputException("Debe ingresar un Id válido");
                    }
                }

                if(int.TryParse(idProductoIngresada, out int auxIdProudcto))
                {
                    for (int i = 0; i < Comercio.listaDeProductos.Count; i++)
                    {
                        if(Comercio.listaDeProductos[i].IdProducto == auxIdProudcto)
                        {
                            flagIdencontrado = true;
                            break;
                        }
                    }
                    if(flagIdencontrado == false)
                    {
                        throw ex = new EmptyImputException("Debe ingresar un Id válido");
                    }
                }
                else
                {
                    throw ex = new EmptyImputException("Debe ingresar un Id válido");
                }
                
            }
        }
    }
}
