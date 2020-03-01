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
    /// Lógica de interacción para mostrar_Registros_Ventas.xaml
    /// </summary>
    public partial class mostrar_Registros_Ventas : UserControl
    {
        Ventas_Echas rea = new Ventas_Echas();
        int c = 0;
        public mostrar_Registros_Ventas()
        {
            InitializeComponent();

            Tabla_Registros.ItemsSource = null;
            Tabla_Registros.ItemsSource = rea.mostrar_registros();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int vend,gana;
            c++;   
            if (c == 1)
            {
                Ventas_Echas ven = new Ventas_Echas();

                String[] vector = ven.empleado_MNV();
                lisB_MayorN.Items.Add("Vendedor : " + vector[0]);
                lisB_MayorN.Items.Add("Total de Ventas : " + vector[1]);
                String[] vector2 = ven.empleado_MGV();
                lisB_MayorG.Items.Add("Vendedor : " + vector2[0]);
                lisB_MayorG.Items.Add("Total $ por ventas : " + vector2[1]);
                vend = ven.totalDeVehiculo();
                gana = ven.totalDeGananciasVehiculo();
                CVPT.Content = vend.ToString();
                TDPV.Content = "$"+gana.ToString();

            }
            else
            {
                MessageBox.Show("Los Registros Ya Estan En Pantalla...");
            }
        }
    }
}
