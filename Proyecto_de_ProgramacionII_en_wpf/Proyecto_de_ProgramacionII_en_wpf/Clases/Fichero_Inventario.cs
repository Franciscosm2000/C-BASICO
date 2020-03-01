using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Proyecto_de_ProgramacionII_en_wpf.Clases;
namespace Proyecto_de_ProgramacionII_en_wpf.Clases
{
    class Fichero_Inventario
    {
        char[] separador = { ',' };

        public void Agregando(String a, String b, String c, String d)
        {
            StreamWriter escribir = File.AppendText("Inventario.txt");
            escribir.WriteLine(a+","+b+","+c+","+d);
            escribir.Close();
            
        }

        public List<Agregando_Inventario_> Buscar(String tipo, String bus)
        {
            Validar_Numeros va = new Validar_Numeros();
            String[] datos = new String[4];
            bool encontrado = false;
            String cadena;
            List<Agregando_Inventario_> lista = new List<Agregando_Inventario_>();
            StreamReader leer = File.OpenText("Inventario.txt");
            cadena = leer.ReadLine();

            if (tipo.Equals("Marca :"))
            {
            bool B = va.valirdar_SoloLetras(bus);
            if (B == false) { MessageBox.Show("Ingresar Solo Letras"); }
            else
            {
                while (cadena != null && encontrado == false)
                {
                    datos = cadena.Split(separador);

                    if (datos[0].Equals(bus))
                    {
                        encontrado = true;
                    }
                    else
                        cadena = leer.ReadLine();
                }
                leer.Close();
                if (encontrado == false)
                {
                    MessageBox.Show("Nose a Encontrado En Los Regitros...");
                }
                else
                {
                    int x = Convert.ToInt32(datos[2]);
                    int x1 = Convert.ToInt32(datos[3]);
                    MessageBox.Show("Registro Encontrado");
                    lista.Add(new Agregando_Inventario_ { Marca = datos[0], Modelo = datos[1], Precio = x, Cantidad = x1 });
                }
              }
            }

            if (tipo.Equals("Precio :"))
            {
            bool B = va.valirdar_SoloNumeros(bus);
            if (B == false) { MessageBox.Show("Ingresar Solo Numeros"); }
            else
            {
                while (cadena != null && encontrado == false)
                {
                    datos = cadena.Split(separador);

                    if (datos[2].Equals(bus))
                    {
                        encontrado = true;
                    }
                    else
                        cadena = leer.ReadLine();
                }

                if (encontrado == false)
                {
                    MessageBox.Show("Nose a Encontrado En Los Regitros...");
                }
                else
                {
                    int x = Convert.ToInt32(datos[2]);
                    int x1 = Convert.ToInt32(datos[3]);
                    MessageBox.Show("Registro Encontrado");
                    lista.Add(new Agregando_Inventario_ { Marca = datos[0], Modelo = datos[1], Precio = x, Cantidad = x1 });
                    
                }
              }
            }
                return lista;
        }

        public void eliminar(int posicion)
        {
            String[] datos = new String[4];
            String cadena;
            bool encontrado = false;
            int c = 0;

            StreamWriter escribir = File.CreateText("Temp_Inventario.txt");
            StreamReader leer = File.OpenText("Inventario.txt");
            cadena = leer.ReadLine();

            while (cadena != null)
            {
                datos = cadena.Split(separador);

                if (c == posicion)
                {
                    encontrado = true;
                }
                else
                {
                    escribir.WriteLine(cadena);
                }
                cadena = leer.ReadLine();
                c++;
            }
            if (encontrado == false) { MessageBox.Show("Error"); }
            else
            {
                escribir.Close();
                leer.Close();
                MessageBox.Show("Registro Eliminado Correctamente ...");
                File.Delete("Inventario.txt");
                File.Move("Temp_Inventario.txt","Inventario.txt");
            }
        }

        public List<Agregando_Inventario_> MostrarTodo()
        {
            List<Agregando_Inventario_> lista = new List<Agregando_Inventario_>();
            String[] datos = new String[4];
            String cadena;
            StreamReader leer = File.OpenText("Inventario.txt");

            cadena = leer.ReadLine();

            while (cadena!=null)
            {
                datos = cadena.Split(separador);
                lista.Add(new Agregando_Inventario_ { Marca = datos[0], Modelo = datos[1], Precio = Convert.ToInt32(datos[2]),
                 Cantidad = Convert.ToInt32(datos[3])});

                cadena = leer.ReadLine();
            }
            return lista;            
        }

        public List<String> Cargar_Lista()
        {
            List<String> vehiculos = null;
            String cadena;
            String[] datos;
            vehiculos = new List<string>();
            try
            {
                StreamReader leer = File.OpenText("Inventario.txt");
                cadena = leer.ReadLine();

                while (cadena != null)
                {
                    datos = cadena.Split(separador);
                    vehiculos.Add(datos[0] + " " + datos[1] );
                    cadena = leer.ReadLine();
                }
                leer.Close();
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

            return vehiculos;
        }

        public void agregando_Nuevamente(String vehi,String canti)
        {
            String[] datos = new String[4];
            String cadena;
            bool encontrado = false;
            int ant=0, nuevo=0;
            StreamWriter escribir = File.CreateText("Temp_Inventario.txt");
            StreamReader leer = File.OpenText("Inventario.txt");
            cadena = leer.ReadLine();

            while (cadena != null)
            {
                datos = cadena.Split(separador);

                if (vehi.Equals(datos[0]+" "+datos[1]))
                {
                    ant = Convert.ToInt32(datos[3]);
                    nuevo = ant + Convert.ToInt32(canti);
                    escribir.WriteLine(datos[0]+","+datos[1]+","+datos[2]+","+nuevo.ToString());
                    encontrado = true;
                }
                else
                {
                    escribir.WriteLine(cadena);
                }
                cadena = leer.ReadLine();
            }
            if (encontrado == false) { MessageBox.Show("Error"); }
            else
            {
                escribir.Close();
                leer.Close();
                File.Delete("Inventario.txt");
                File.Move("Temp_Inventario.txt", "Inventario.txt");
                MessageBox.Show("Agregado Exitosamente... Antes = "+ant+" Ahora :"+nuevo );
            }
        }

    }
}
