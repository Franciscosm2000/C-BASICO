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
    /// Lógica de interacción para Registro_Eliminar.xaml
    /// </summary>
    public partial class Registro_Eliminar : UserControl
    {
        List<Agregando_Inventario_> lista = new List<Agregando_Inventario_>();
        public Registro_Eliminar()
        {
            InitializeComponent();
            Fichero_Inventario fi = new Fichero_Inventario();
            Tabla_Registros_Inventario.ItemsSource = null;
            Tabla_Registros_Inventario.ItemsSource = fi.MostrarTodo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String pos = null; 
            pos =Tabla_Registros_Inventario.SelectedIndex.ToString();
            int aux = Convert.ToInt32(pos);

            if (pos == null)
            {
                MessageBox.Show("Seleccione Un Elemento Porfavor...");
            }
            else
            {
                Fichero_Inventario fic = new Fichero_Inventario();
                fic.eliminar(aux);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Fichero_Inventario fi = new Fichero_Inventario();
            Tabla_Registros_Inventario.ItemsSource = null;
            Tabla_Registros_Inventario.ItemsSource = fi.MostrarTodo();
        }
    }
}
