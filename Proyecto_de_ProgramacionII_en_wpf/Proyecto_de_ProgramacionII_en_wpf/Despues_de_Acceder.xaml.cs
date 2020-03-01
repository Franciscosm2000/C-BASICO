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
using System.Windows.Shapes;


namespace Proyecto_de_ProgramacionII_en_wpf
{
    /// <summary>
    /// Lógica de interacción para Despues_de_Acceder.xaml
    /// </summary>
    public partial class Despues_de_Acceder : Window
    {
        public Despues_de_Acceder(String a)
        {
            InitializeComponent();
            agregar( new Inicio());
           // lblUsuario.Content = a;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void agregar(UserControl user)
        {
            this.pn1.Children.Clear();
            this.pn1.Children.Add(user);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            agregar(new Buscar_Empleado_Agregado());
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            agregar(new Inicio());
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            agregar(new Registros_Eliminar());
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            agregar(new Agregando_Inventario());
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            agregar(new Buscar_Inventario());
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            agregar(new Registro_Eliminar());
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            agregar(new Realizar_Venta());
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            agregar( new mostrar_Registros_Ventas());
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Echo por : Francisco Javier Sandoval Maldonado \n Proyecto de Programacion II Echo en WPF \n Espero disfrute el Sistema :) ... Saludos");
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            agregar(new DatosUsu());
        }
    }
    }

