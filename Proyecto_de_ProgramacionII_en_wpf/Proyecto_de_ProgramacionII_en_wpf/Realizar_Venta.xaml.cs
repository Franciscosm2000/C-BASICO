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
    /// Lógica de interacción para Realizar_Venta.xaml
    /// </summary>
    public partial class Realizar_Venta : UserControl
    {
        int t,s=0;
        CargarVende_y_Vehi car = new CargarVende_y_Vehi();
        String[] arreglo; String [] arreglo1;
        List<String> lis = new List<string>();
        List<String> lis1 = new List<string>();
        public Realizar_Venta()
        {
            InitializeComponent();
            iniciando_Combo();
            iniciando_ListaVehi();
        }

        public void iniciando_Combo()
        {
            lis = car.Cargar_Combo();
            arreglo = lis.ToArray();

            for (int i=0; i<arreglo.Length;i++)
            {
                cmbV.Items.Add(arreglo[i]);
            }
        }

        public void iniciando_ListaVehi()
        {
            lis1 = car.Cargar_Lista();
            arreglo1 = lis1.ToArray();

            for (int i=0; i<arreglo1.Length;i++)
            {
                lisVehiculo.Items.Add(arreglo1[i]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String seleccionado = null;
            seleccionado=cmbV.SelectedValue.ToString();

            if (seleccionado == null)
                MessageBox.Show("Seleccione un vendedor porfavor...");
            else
            {
                if (tbxC.Text == null || tbxC.Text.Equals(""))
                    MessageBox.Show("Ingrese el nombre del Cliente....");
                else
                {
                    int cantidad_en_la_lista = lisD_A.Items.Count;
                    if (cantidad_en_la_lista == 0)
                        MessageBox.Show("No ah agregado el vehiculo a comprar");
                    else
                    {
                        CargarVende_y_Vehi carg = new CargarVende_y_Vehi();
                        Tabla_Comprar.ItemsSource = null;
                        Tabla_Comprar.ItemsSource = carg.Compras(devolucion(),devolucion_Can(),tbxC.Text,seleccionado,total.Text);
                        lisD_A.Items.Clear();
                        total.Text = "";
                        cantidad.Text = "";
                    }
                }
            }

            
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            char[] separador = {'-'};
            String seleccionado = lisVehiculo.SelectedItem.ToString();
            String[] aux_vehi = seleccionado.Split(separador);
            if (seleccionado == null)
            {
                MessageBox.Show("Ningun Elemento seleccionado de la lista...");
            }
            else
            {
                if (cantidad.Text == null || cantidad.Text.Equals(""))
                {
                    MessageBox.Show("Porfavor Ingresar La cantidad de Vehiculos A Comprar");
                }
                else
                {
                    Validar_Numeros val = new Validar_Numeros();
                    if (val.valirdar_SoloNumeros(cantidad.Text) == false)
                    {
                        MessageBox.Show("Solo ingresar numeros en el campo Cantidad...");
                    }
                    else
                    {
                        int c = Convert.ToInt32(cantidad.Text);
                        int aux = car.Canti_Vehiculos(aux_vehi[0]);
                        if (c > aux)
                            MessageBox.Show("No hay suficientes vehiculos en el inventario..." + aux);

                        else
                        {
                            lisD_A.Items.Add(seleccionado + "-" + c);
                            t = c * Convert.ToInt32(aux_vehi[1]);
                            s += t;
                            total.Text = s.ToString();
                        }
                    }
                }
                
            }
        }

        public String[] devolucion()
        {
            String[] datos;
            char[] separador = {'-'};
            String cadena;
            String [] aux_vehi = new String [lisD_A.Items.Count];
            for (int i = 0; i < lisD_A.Items.Count; i++)
            {
                cadena = lisD_A.Items[i].ToString();
                datos = cadena.Split(separador);
                aux_vehi[i] = datos[0];
            }

            return aux_vehi;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        public String[] devolucion_Can()
        {
            String[] datos;
            char[] separador = { '-' };
            String cadena;
            String[] aux_cantidad = new String[lisD_A.Items.Count];
            for (int i = 0; i < lisD_A.Items.Count; i++)
            {
                cadena = lisD_A.Items[i].ToString();
                datos = cadena.Split(separador);
                aux_cantidad[i] = datos[2];
            }

            return aux_cantidad;
        }

    }
}
