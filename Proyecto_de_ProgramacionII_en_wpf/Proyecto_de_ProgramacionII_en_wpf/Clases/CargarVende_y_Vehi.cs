using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_de_ProgramacionII_en_wpf.Clases;
using System.IO;
using System.Windows;

namespace Proyecto_de_ProgramacionII_en_wpf.Clases
{
    class CargarVende_y_Vehi
    {
        char[] separador = {','};
        public List<String> Cargar_Combo()
        {
            List<String> empleados = null;
            String cadena;
            String[] datos;
            empleados = new List<string>();
            StreamReader leer = File.OpenText("Empleados_Agregados.txt");
            cadena = leer.ReadLine();

            while (cadena!=null)
            {
                datos = cadena.Split(separador);
                empleados.Add(datos[0]);
                cadena = leer.ReadLine();
            }
            leer.Close();
            return empleados;
        }
        public List<String> Cargar_Lista()
        {
            List<String> vehiculos = null;
            String cadena;
            String [] datos;
            vehiculos = new List<string>();
            try
            {
                StreamReader leer = File.OpenText("Inventario.txt");
                cadena = leer.ReadLine();

                while (cadena != null)
                {
                    datos = cadena.Split(separador);
                    vehiculos.Add(datos[0] + " " + datos[1] + "-" + datos[2]);
                    cadena = leer.ReadLine();
                }
                leer.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }
            
            return vehiculos;
        }
        public int Canti_Vehiculos(String vehi)
        {
            int can = 0;
            String[] datos;
            String cadena;
            StreamReader leer = File.OpenText("Inventario.txt");
            cadena = leer.ReadLine();
            bool encontrado = false;
       
            while (cadena!=null && encontrado== false)
            {
                datos = cadena.Split(separador);
                String uni = datos[0] + " " + datos[1]; 
                if (uni.Equals(vehi))
                {
                    can = Convert.ToInt32(datos[3]);
                    encontrado = true;   
                }
                    cadena = leer.ReadLine();
            }
            leer.Close();

            return can;
        }

        public List<Ventas> Compras(String [] vehi, String [] canti, String compra, String vende, String total)
        {
            List<Ventas> lista = new List<Ventas>();
            Ventas_Echas ven = new Ventas_Echas();
            for (int i=0; i<vehi.Length; i++)
            {
                StreamReader leer = File.OpenText("Inventario.txt");
                StreamWriter escribir = File.CreateText("Tmp_Inventario_.txt");
                String[] datos;
                String cadena;
                bool encontrado = false;
                String vehiculo = vehi[i];
                String cantidad = canti[i];
                cadena = leer.ReadLine();
                while (cadena!= null)
                {
                    datos = cadena.Split(separador);
                    String union = datos[0] + " " + datos[1];
                    if (vehiculo.Equals(union))
                    {
                        lista.Add(new Ventas { Cliente = compra, Vehiculo = vehiculo, Cantidad = cantidad, Total = datos[2],Vendedor=vende });
                        ven.agregar(compra,vende,vehiculo,cantidad,datos[2]);
                        int nuevo = Convert.ToInt32(datos[3]) - Convert.ToInt32(cantidad);
                        escribir.WriteLine(datos[0]+","+datos[1]+","+datos[2]+","+nuevo.ToString());
                        encontrado = true;
                    }
                    else
                    {
                        escribir.WriteLine(cadena);
                    }
                    cadena = leer.ReadLine();
                }
                if (encontrado == true)
                {
                    leer.Close();
                    escribir.Close();
                    File.Delete("Inventario.txt");
                    File.Move("Tmp_Inventario_.txt", "Inventario.txt");
                }
                else
                {
                    MessageBox.Show("Registro no encontrado....");
                }
            }
            
            return lista;
        }


    }
}
