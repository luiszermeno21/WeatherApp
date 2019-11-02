using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using DataAccessLayer;
using Proxy.Models;

namespace ExamenParcial2.UserControls
{
    public partial class RegistarPage : UserControl
    {
        private static ADSSingleton _service;
        string _contraseña;
        string _correo;

        public delegate void RegistrarEIniciarSesion(string correo, string contraseña);
        public event RegistrarEIniciarSesion OnRegistrarEIniciarSesion;

        public RegistarPage()
        {
            InitializeComponent();
            _contraseña = textBox2.Text;
            _correo = textBox1.Text;
            var connectionString = ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();
            _service = ADSSingleton.GetInstance(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OnRegistrarEIniciarSesion != null)
                OnRegistrarEIniciarSesion(_correo, _contraseña);
            Perfil perfil = new Perfil();
            perfil.usuario = _correo;
            perfil.contraseña = _contraseña;
            _service.RegistrarUsuario(perfil);
            Visible = false;
        }
    }
}
