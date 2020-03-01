using Proyecto_de_ProgramacionII_en_wpf.Clases;
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
    /// Lógica de interacción para Formulario_Creadndo_cuenta.xaml
    /// </summary>
    public partial class Formulario_Creadndo_cuenta : Window
    {
        public Formulario_Creadndo_cuenta()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow ma = new MainWindow();
            ma.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String pass = null;
            fichero fi = new fichero();
            if (lblNombre.Text == null || lblNombre.Text.Equals("")) { MessageBox.Show("Obligatorio ingresar el Nombre..."); }
            else
            {
                if (lblApellido.Text == null || lblApellido.Text.Equals("")) { MessageBox.Show("Obligatorio ingresar el Apellido..."); }
                else
                {
                    if ((lblNumero.Text.Length == 8) && ((lblNumero.Text.Substring(0, 1).Equals("8")) || (lblNumero.Text.Substring(0, 1).Equals("7")) || (lblNumero.Text.Substring(0, 1).Equals("5")) || (lblNumero.Text.Substring(0, 1).Equals("2"))))
                    {
                        if (lblN_usuario.Text == null || lblN_usuario.Text.Equals("")) { MessageBox.Show("Obligatorio ingresar el Nombre de usuario..."); }
                        else
                        {
                            pass = lblClave.Password;
                            if (pass.Length >= 8)
                            {
                                fi.agregar(lblNombre.Text, lblApellido.Text, lblNumero.Text,lblN_usuario.Text,pass);
                                lblNombre.Text = "";
                                lblApellido.Text = "";
                                lblClave.Password = "";
                                lblNumero.Text = "";
                                lblN_usuario.Text = "";
                                this.Close();
                                MainWindow ma = new MainWindow();
                                ma.Show();
                            }
                            else
                                MessageBox.Show("El campo esta vacio o no tiene caracteres suficientes minimo de caracter son 8");
                        }
                    }
                    else
                        MessageBox.Show("Numero de telefono no valido...");
                }
            }
                
            
        }
    }
}
