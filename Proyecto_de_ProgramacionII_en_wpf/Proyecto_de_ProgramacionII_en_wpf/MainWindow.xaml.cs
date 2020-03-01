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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gracias por usar este sistema :)...");
            this.Close();
        }

        private void Evento_salir(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String resultado = null;
            String nom = lblNombre.Text;
            String pas = lblPass.Password;

            if (nom == null || nom.Equals(""))
            {
                MessageBox.Show("Ingreasar el nombre de usuario porfavor...");
            }
            else
            {
                if (pas == null || pas.Equals(""))
                {
                    MessageBox.Show("Ingresar la clave porfavor...");
                }
                else
                {
                    fichero fi = new fichero();
                  resultado = fi.corroborando_cuenta(nom, pas);
                    if (resultado.Equals("Correcto"))
                        this.Close(); 
                }
            }
        }
    }
}
