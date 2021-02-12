using ControlCalidad.Cliente.AccesoExterno;
using ControlCalidad.Cliente.AccesoExterno.ControlCalidadServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlCalidad.Cliente.Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            List<LineaDto>  lineas = Adaptador.GetLineas().ToList();//ahora si me devuelve objetos

            foreach(var linea in lineas)
            {
                listBox1.Items.Add($"{linea.Numero} - {linea.Descripcion}");
            }
        }
    }
}
