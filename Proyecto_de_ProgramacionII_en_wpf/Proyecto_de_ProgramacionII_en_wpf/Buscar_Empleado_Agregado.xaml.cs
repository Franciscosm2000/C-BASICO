using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Proyecto_de_ProgramacionII_en_wpf.Clases;

namespace Proyecto_de_ProgramacionII_en_wpf
{
    /// <summary>
    /// Lógica de interacción para Buscar_Empleado_Agregado.xaml
    /// </summary>
    public partial class Buscar_Empleado_Agregado : UserControl
    {
        public Buscar_Empleado_Agregado()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            lblCambio.Content = "Nombre :";
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            lblCambio.Content = "Codigo :";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String bus = txbBus.Text;

            if (lblCambio.Content.Equals("Nombre :"))
            {
                if (txbBus.Text == null || txbBus.Text.Equals(""))
                {
                    MessageBox.Show("Campo de Busqueda Vacio :( ...");
                }
                else
                {
                    fichero fi = new fichero();
                    //fi.buscar_empleado(bus,lblCambio.Content.ToString());
                    Lista_.ItemsSource = null;
                    Lista_.ItemsSource = fi.buscar_empleado(bus, lblCambio.Content.ToString());
                    txbBus.Text = "";
                }
            }
            else if (lblCambio.Content.Equals("Codigo :"))
            {
                if (txbBus.Text == null || txbBus.Text.Equals(""))
                {
                    MessageBox.Show("Campo de Busqueda Vacio :( ...");
                }
                else
                {
                    fichero fi = new fichero();
                    //fi.buscar_empleado(bus,lblCambio.Content.ToString());
                    Lista_.ItemsSource = null;
                    Lista_.ItemsSource = fi.buscar_empleado(bus, lblCambio.Content.ToString());
                    txbBus.Text = "";
                }
            }       
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
