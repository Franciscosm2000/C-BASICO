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
    /// Lógica de interacción para Empleados_Agregar.xaml
    /// </summary>
    public partial class Empleados_Agregar : UserControl
    {
        List<agregando_trabajador> lis = new List<agregando_trabajador>();
        public Empleados_Agregar()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nom.Text == null || nom.Text.Equals(""))
                MessageBox.Show("Porfavor ingrese el nombre...");
            else
            {
                if (ape.Text == null || ape.Text.Equals(""))
                    MessageBox.Show("Porfavor ingrese el apellido...");
                else
                {
                    if (ced.Text.Length == 14 && char.IsLetter(ced.Text, 13))
                    {
                        if (cod.Text == null || cod.Text.Equals(""))
                            MessageBox.Show("Porfavor ingresea el codigo");
                        else
                        {
                            String aux_1 = ced.Text.Insert(2, "-");
                            String aux_2 = aux_1.Insert(10, "-");
                            // Agregando elementos a la lista para luego mandarlo al fichero
                            lis.Add(new agregando_trabajador { Nombre = nom.Text, Apellido = ape.Text, Cedula1 = aux_2, Codigo = cod.Text });
                            this.Lista.ItemsSource = null;
                            this.Lista.ItemsSource = lis;
                            String a = nom.Text;
                            String b = ape.Text;
                            String c = cod.Text;
                            // limpiando las casillas de llenar datos
                            nom.Text = "";
                            ape.Text = "";
                            ced.Text = "";
                            cod.Text = "";
                            // Mandando datos al fichero
                            fichero fi = new fichero();
                            fi.agregar_Empleado(a, b,aux_2,c);
                        }
                    }
                    else { MessageBox.Show("Porfavor ingrese el Cedula"); }
                }
                                          
                }
            }
        }
    }

