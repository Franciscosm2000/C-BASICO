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
    /// Lógica de interacción para Registros_Eliminar.xaml
    /// </summary>
    public partial class Registros_Eliminar : UserControl
    {
        List<agregando_trabajador> lista_ = new List<agregando_trabajador>();
        public Registros_Eliminar()
        {
            InitializeComponent();
            fichero fi = new fichero();
            Tabla_Registros.ItemsSource = null;
            Tabla_Registros.ItemsSource = fi.Mostrar_todo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fichero fic = new fichero();
            Tabla_Registros.ItemsSource = null;
            Tabla_Registros.ItemsSource = fic.Mostrar_todo();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String registro = null ;
            registro = Tabla_Registros.SelectedIndex.ToString();
            int indice = Convert.ToInt32(registro);
            if (registro == null)
            {
                MessageBox.Show("Ningun Registro Seleccionado En La Tabla...");
            }
            else
            {
                MessageBox.Show(indice.ToString());
                fichero fi = new fichero();
                fi.Registros_Eliminar(indice);
            }
        }
    }
}
