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
    /// Lógica de interacción para Buscar_Inventario.xaml
    /// </summary>
    public partial class Buscar_Inventario : UserControl
    {
        public Buscar_Inventario()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String tipo = lblCambio.Content.ToString();
            String busC = txbBus.Text;
            if (busC == null || busC.Equals(""))
                MessageBox.Show("Campo Vacio");
            else
            {

                    Fichero_Inventario fi = new Fichero_Inventario();
                    TablaB_Inventario.ItemsSource = null; 
                    TablaB_Inventario.ItemsSource= fi.Buscar(tipo,busC);
                txbBus.Text = "";
                
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            lblCambio.Content = "Marca :";
            Bus_P.IsChecked = false;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            lblCambio.Content = "Precio :";
            Bus_M.IsChecked = false;
        }
    }
}
