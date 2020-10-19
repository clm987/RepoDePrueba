﻿using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KwikESalesFE
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           Comercio.UsuariosHarcodeo();
            txtContraseña.PasswordChar = '*';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Comercio.ValidarLogin(txtUsuario.Text, txtContraseña.Text))
            {
                Empleado auxEmpleado = Comercio.BusacarEmpleadoPorUsuario(txtUsuario.Text);

                if (!(auxEmpleado is null))
                {
                    Comercio.UsuarioActivo = auxEmpleado;
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.txtUsuario.Text = "";
                this.txtContraseña.Text = "";
                MessageBox.Show("Verifique el usuario y la contraseña. \n Respete Mayusculas y Minusculas");
            }
        }
    }
}
