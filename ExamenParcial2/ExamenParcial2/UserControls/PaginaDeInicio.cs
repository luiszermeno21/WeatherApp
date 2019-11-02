using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using System.Configuration;
using Proxy.Models;
using Proxy.Services;

namespace ExamenParcial2.UserControls
{
    public partial class PaginaDeInicio : UserControl
    {
        private static ADSSingleton _service;
        List<RootObject> ciudadesbuscadas;
        List<Lista> ciudades;
        public PaginaDeInicio()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["SQLConnection"].ToString();
            _service = ADSSingleton.GetInstance(connectionString);
            ciudades = new List<Lista>();
            ciudadesbuscadas = new List<RootObject>();
            dataGridView1.DataSource = new BindingSource(ciudadesbuscadas, null);
            dataGridView1.DataSource = typeof(List<RootObject>);
            dataGridView1.DataSource = ciudadesbuscadas;
            dataGridView2.DataSource = new BindingSource(ciudades, null);
            dataGridView2.DataSource = typeof(List<Lista>);
            dataGridView2.DataSource = ciudades;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RootObject aux = new RootObject();
            aux = ciudadesbuscadas[e.RowIndex];
            ciudades.Add(_service.UnaCiudad(aux.name));
            dataGridView2.DataSource = new BindingSource(ciudades, null);
            dataGridView2.DataSource = typeof(List<Lista>);
            dataGridView2.DataSource = ciudades;
            dataGridView2.Update();
            dataGridView2.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IProxy proxy = new CProxy();
            ciudadesbuscadas = proxy.paises();
            foreach (RootObject a in ciudadesbuscadas)
                _service.AddCapitales(a);
            dataGridView1.DataSource = new BindingSource(ciudadesbuscadas, null);
            dataGridView1.DataSource = typeof(List<RootObject>);
            dataGridView1.DataSource = ciudadesbuscadas;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _service.DeleteCity(ciudades[e.RowIndex].name);
            dataGridView2.DataSource = new BindingSource(ciudades, null);
            dataGridView2.DataSource = typeof(List<Lista>);
            dataGridView2.DataSource = ciudades;
            dataGridView2.Update();
            dataGridView2.Refresh();
        }
    }
}
