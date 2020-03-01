using Microsoft.Win32;
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
using System.IO;
namespace Proyecto_de_ProgramacionII_en_wpf
{
    /// <summary>
    /// Lógica de interacción para DatosUsu.xaml
    /// </summary>
    public partial class DatosUsu : UserControl
    {
        public DatosUsu()
        {
            InitializeComponent();
            Cargar_Datos();
           Cargar_Imagen();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog bus = new OpenFileDialog();
            bus.Filter = "JPG (*.jpg)|*.jpg|Png (*png)|";
            bus.FileName = "Imagenes";

            StreamReader leer = File.OpenText("Foto.txt");
            String cadena;
            if (bus.ShowDialog() == true)
            {
                String ruta = bus.FileName;
                cadena = leer.ReadLine();

                if (cadena != null)
                {
                    StreamWriter aux = File.CreateText("AUX_foto.txt");
                    aux.WriteLine(ruta);
                    aux.Close();
                    leer.Close();
                    File.Delete("Foto.txt");
                    File.Move("AUX_foto.txt", "Foto.txt");
                    ImageSource imageSource = new BitmapImage(new Uri(ruta));
                    imagen.Source = imageSource;
                }
                else
                {
                    leer.Close();
                    StreamWriter escri = File.AppendText("Foto.txt");
                    escri.WriteLine(ruta);
                    escri.Close();
                    ImageSource imageSource = new BitmapImage(new Uri(ruta));
                    imagen.Source = imageSource;
                }
                
            }
        }

        public void Cargar_Datos()
        {
            StreamReader leer = File.OpenText("Cuentas.txt");
            String cadenal;
            String[] datos;
            cadenal = leer.ReadLine();
            char[] separador = {','};

            while (cadenal !=null)
            {
                datos = cadenal.Split(separador);
                txbN.Text = datos[0];
                txbA.Text = datos[1];
                txbU.Text = datos[3];
                txbNu.Text = datos[2];
                txbP.Text = datos[4];
                cadenal = leer.ReadLine();
            }
            leer.Close();
        }

        public void Cargar_Imagen()
        {
            String cadena;
            try
            {
                StreamReader leer = File.OpenText("Foto.txt");
                cadena = leer.ReadLine();
                leer.Close();
                ImageSource imageSource = new BitmapImage(new Uri(cadena));
                imagen.Source = imageSource;
            }
            catch (Exception)
            {
                StreamWriter es = File.CreateText("Foto.txt");
                 es.Close();
               
            }

        }

    }
}
