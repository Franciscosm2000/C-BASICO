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
    /// Lógica de interacción para Agregando_Inventario.xaml
    /// </summary>
    public partial class Agregando_Inventario : UserControl
    {
        Validar_Numeros val = new Validar_Numeros();
        Fichero_Inventario fi = new Fichero_Inventario();
        List<Agregando_Inventario_> lista = new List<Agregando_Inventario_>();
        List<String> lis1 = new List<String>();
        String[] arreglo1;
        public Agregando_Inventario()
        {
            InitializeComponent();
            iniciando_ListaVehi();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String mar = txbMa.Text;
            String mod = txbMo.Text;
            String pre = txbP.Text;
            String cant = txbC.Text;
            Validar_Numeros val = new Validar_Numeros();
            if (mar == null || mar.Equals(""))
                MessageBox.Show("Porfavor ingrese la Marca ....");
            else
            {
                if (mod == null || mod.Equals(""))
                    MessageBox.Show("Porfavor ingrese la Modelo ....");
                else
                {
                    if (pre == null || pre.Equals("") )
                        MessageBox.Show("Porfavor ingrese la Marca ....");
                    else
                    {
                        bool aux = val.valirdar_SoloNumeros(pre);
                        if (aux == false) { MessageBox.Show("Porfavor Ingresar solo Numeros en el campo precio"); }
                        else
                        {
                            if (cant == null || cant.Equals(""))
                                MessageBox.Show("Porfavor ingrese la Cantidad ....");
                            else
                            {
                                bool aux_1 = val.valirdar_SoloNumeros(cant);
                                if (aux_1 == false) { MessageBox.Show("Porfavor Ingresar solo Numeros en el campo Cantidad");}
                                else
                                {
                                    lista.Add( new Agregando_Inventario_ { Marca = mar, Modelo = mod, Precio =Convert.ToInt32(pre),
                                    Cantidad= Convert.ToInt32(cant)});
                                    MessageBox.Show("Agregado Correctamente ...");
                                    Fichero_Inventario fi = new Fichero_Inventario();
                                    fi.Agregando(mar,mod,pre,cant);
                                    TablaInv.ItemsSource = null;
                                    TablaInv.ItemsSource = lista;
                                    //Limpiando
                                    txbMa.Text = "";
                                    txbMo.Text = "";
                                    txbC.Text = "";
                                    txbP.Text = "";
                                }
                            }
                        }
                    }
                   
                }
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            String seleccionado = null;
            if (Agregar.IsChecked == true)
            {
                try
                {
                    seleccionado = Lista.SelectedValue.ToString();
                }
                catch (Exception) { }
                if (seleccionado == null)
                    MessageBox.Show("Ningun Elmento Seleccionado...");
                else
                {
                    txbVehi.Text = seleccionado;
                    txbCanti.IsEnabled = true;
                }
            }
            else
            {
                txbCanti.IsEnabled = false;
                txbVehi.Text = "";
                txbCanti.Text = "";
            }

            
        }

        public void iniciando_ListaVehi()
        {
            lis1 = fi.Cargar_Lista();
            arreglo1 = lis1.ToArray();

            for (int i = 0; i < arreglo1.Length; i++)
            {
                Lista.Items.Add(arreglo1[i]);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (val.valirdar_SoloNumeros(txbCanti.Text) == true)
            {
                fi.agregando_Nuevamente(txbVehi.Text, txbCanti.Text);
                txbVehi.Text = "";
                txbCanti.Text = "";
            }
            else
                MessageBox.Show("Diguitar Solo Numeros...");
        }
    }
}
