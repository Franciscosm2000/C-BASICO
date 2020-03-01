using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
namespace Proyecto_de_ProgramacionII_en_wpf.Clases
{
    class Ventas_Echas
    {
        char[] separador = { ',' };
        public void agregar(String cliente, String vendedor, String vehiculo, String cantidad, String total)
        {
            StreamWriter escribir = File.AppendText("Ventas_"+vendedor+".txt");
            escribir.WriteLine(cliente+","+vendedor + "," +vehiculo + "," +cantidad + "," +total);
            escribir.Close();
        }

        public List<Ventas> mostrar_registros()
        {
            String cadena;
            String[] datos;
            List<Ventas> lista = new List<Ventas>();
            List<String> lista_ = new List<String>();
            StreamReader leer = File.OpenText("Empleados_Agregados.txt");
            cadena = leer.ReadLine();
            while (cadena!=null)
            {
                datos = cadena.Split(separador);
                lista_.Add(datos[0]);
                cadena = leer.ReadLine();
            }

            for (int i=0; i<lista_.Count;i++)
            {
                try
                {
                    StreamReader leerDatos = File.OpenText("Ventas_" + lista_[i].ToString() + ".txt");
                    String cadena1;
                    String[] datos1;
                    cadena1 = leerDatos.ReadLine();

                    if (cadena1 != null)
                    {
                        while (cadena1 != null)
                        {
                            datos1 = cadena1.Split(separador);
                            lista.Add(new Ventas { Cliente = datos1[0], Vendedor = datos1[1], Vehiculo = datos1[2], Cantidad = datos1[3], Total = datos1[4] });
                            cadena1 = leerDatos.ReadLine();
                        }
                        leerDatos.Close();
                    }
                }
                catch (Exception e) { }
            }
            return lista;
        }

        public String [] empleado_MNV()
        {
            String[] datos;
            List<String> empleados = new List<string>();
            String cadena;
            List<int> datos_Extraidos = new List<int>();
            String[] may = new String[2];
            try
            {
                StreamReader leer = File.OpenText("Empleados_Agregados.txt");
                cadena = leer.ReadLine();

                while (cadena!=null)
                {
                    datos = cadena.Split(separador);
                    empleados.Add(datos[0]);
                    cadena = leer.ReadLine();
                }
                leer.Close();

                //////////////////////////////////////////////////////
                int max = 0, pos = 0, a = 0,suma=0;
                while (empleados.Count > a)
                {
                    String[] datos_Nuevos;
                    String cadena1;
                    StreamReader leer_CU = File.OpenText("Ventas_" + empleados[a] + ".txt");
                    cadena1 = leer_CU.ReadLine();
                    if (cadena1 != null)
                    {
                        suma = 0;
                        int cantidad = 0;
                        while (cadena1 != null)
                        {
                            datos_Nuevos = cadena1.Split(separador);
                            cantidad = Convert.ToInt32(datos_Nuevos[3]);
                            suma += cantidad;
                            cadena1 = leer_CU.ReadLine();
                        }
                        datos_Extraidos.Add(suma);
                        leer_CU.Close();

                        if (datos_Extraidos[a] > max)
                        {
                            max = datos_Extraidos[a];
                            pos = a;
                        }
                        
                        may[0] = empleados[pos];
                        may[1] = max.ToString();
                    }
                    else
                    {
                        suma = datos_Extraidos[a];
                    }
                    a++;
                }
            }
            catch (Exception e) { /*MessageBox.Show(e.Message);*/ }
            return may;
        }

        public String[] empleado_MGV()
        {
            String[] datos;
            List<String> empleados = new List<string>();
            String cadena;
            List<int> datos_Extraidos = new List<int>();
            String[] may = new String[2];
            try
            {
                StreamReader leer = File.OpenText("Empleados_Agregados.txt");
                cadena = leer.ReadLine();

                while (cadena != null)
                {
                    datos = cadena.Split(separador);
                    empleados.Add(datos[0]);
                    cadena = leer.ReadLine();
                }
                leer.Close();

                //////////////////////////////////////////////////////
                int max = 0, pos = 0, a = 0, suma = 0;
                while (empleados.Count > a)
                {
                    String[] datos_Nuevos;
                    String cadena1;
                    StreamReader leer_CU = File.OpenText("Ventas_" + empleados[a] + ".txt");
                    cadena1 = leer_CU.ReadLine();
                    if (cadena1 != null)
                    {
                        suma = 0;
                        int cantidad = 0;
                        while (cadena1 != null)
                        {
                            datos_Nuevos = cadena1.Split(separador);
                            cantidad = Convert.ToInt32(datos_Nuevos[4]);
                            suma += cantidad;
                            cadena1 = leer_CU.ReadLine();
                        }
                        datos_Extraidos.Add(suma);
                        leer_CU.Close();

                        if (datos_Extraidos[a] > max)
                        {
                            max = datos_Extraidos[a];
                            pos = a;
                        }

                        may[0] = empleados[pos];
                        may[1] = max.ToString();
                    }
                    else
                    {
                        suma = datos_Extraidos[a];
                    }
                    a++;
                }
            }
            catch (Exception e) { /*MessageBox.Show(e.Message);*/ }
            return may;
        }

        public int totalDeVehiculo()
        {
            String[] datos;
            String cadena;
            int suma=0;
            List<String> empleados = new List<string>();

            try
            {
                StreamReader leer = File.OpenText("Empleados_Agregados.txt");
                cadena = leer.ReadLine();

                while (cadena != null)
                {
                    datos = cadena.Split(separador);
                    empleados.Add(datos[0]);
                    cadena = leer.ReadLine();
                }

                for (int i = 0; i < empleados.Count; i++)
                {
                    String cadena1;
                    String[] datos1;
                    StreamReader leerUPU = File.OpenText("Ventas_" + empleados[i] + ".txt");
                    cadena1 = leerUPU.ReadLine();

                    while (cadena1 != null)
                    {
                        datos1 = cadena1.Split(separador);
                        suma += Convert.ToInt32(datos1[3]);
                        cadena1 = leerUPU.ReadLine();
                    }
                    leerUPU.Close();
                }
            }

            catch (Exception e)
            {  }

            return suma;
        }

        public int totalDeGananciasVehiculo()
        {
            String[] datos;
            String cadena;
            int suma = 0;
            List<String> empleados = new List<string>();

            try
            {
                StreamReader leer = File.OpenText("Empleados_Agregados.txt");
                cadena = leer.ReadLine();

                while (cadena != null)
                {
                    datos = cadena.Split(separador);
                    empleados.Add(datos[0]);
                    cadena = leer.ReadLine();
                }

                for (int i = 0; i < empleados.Count; i++)
                {
                    String cadena1;
                    String[] datos1;
                    StreamReader leerUPU = File.OpenText("Ventas_" + empleados[i] + ".txt");
                    cadena1 = leerUPU.ReadLine();

                    while (cadena1 != null)
                    {
                        datos1 = cadena1.Split(separador);
                        suma += Convert.ToInt32(datos1[4]);
                        cadena1 = leerUPU.ReadLine();
                    }
                    leerUPU.Close();
                }
            }

            catch (Exception e)
            { }

            return suma;
        }
    }
}
