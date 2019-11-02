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

namespace ExamenParcial2.UserControls
{
    public partial class LoginPage : UserControl
    {
        private static ADSSingleton _service;

        public delegate void IniciarSesion();
        public event IniciarSesion OnIniciarSesion;

        public delegate void RegistrarUsuario();
        public event RegistrarUsuario OnRegistrarUsuario;

        public LoginPage()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();
            _service = ADSSingleton.GetInstance(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OnIniciarSesion != null)
                OnIniciarSesion();
            //_service.ValidarUsuario(textBox1.Text, textBox2.Text);
            Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (OnRegistrarUsuario != null)
                OnRegistrarUsuario();
            Visible = false;
        }
    }
}
