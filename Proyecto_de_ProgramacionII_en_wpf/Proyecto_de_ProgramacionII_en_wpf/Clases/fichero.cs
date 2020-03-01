using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Proyecto_de_ProgramacionII_en_wpf.Clases
{
    class fichero
    {
        char [] separdor = {','};
        public void agregar(String a, String b, String c, String d, String e)
        {
            String ruta = "Cuentas.txt";

            StreamWriter escribir = File.AppendText(ruta);

            escribir.WriteLine(a+","+b + ","+c + ","+d+","+e);
            escribir.Close();
            MessageBox.Show("Su cuenta a sido creada Exitosamente...");
        }

        public String corroborando_cuenta(String a , String b)
        {
            String h = "Malo";
            try
            {
                bool encontrado = false;
                String[] datos = new String[5];
                String cadena;

                StreamReader leer = File.OpenText("Cuentas.txt");
                cadena = leer.ReadLine();

                while (cadena != null && encontrado== false)
                {
                    datos = cadena.Split(separdor);

                    if (a.Equals(datos[3]) && b.Equals(datos[4]))
                    {
                        Despues_de_Acceder formu = new Despues_de_Acceder(a);
                        formu.Show();                        
                        encontrado = true;
                        h = "Correcto";
                    }
                    else
                        cadena = leer.ReadLine();
                }
                leer.Close();
                if (encontrado == false)
                {
                    MessageBox.Show("El nombre de usuario o El Password estan mal escrito...");
                }
            }
            catch (Exception e) { MessageBox.Show("Error"+ e.Message); }

            return h;
        }

        public void agregar_Empleado(String a, String b, String c, String d)
        {
            StreamWriter agregando = File.AppendText("Empleados_Agregados.txt");

            agregando.WriteLine(a+","+ b + ","+ c+ ","+ d);

            MessageBox.Show("Empleado Registrado Correctamente :) ...");
            agregando.Close();
        }

        public List<agregando_trabajador> buscar_empleado(String Nbus, String tipo_Busqueda)
        {
            bool encontrado = false;
            String[] datos = new String[4];
            String cadena;
            List<agregando_trabajador> lista = new List<agregando_trabajador>();

            StreamReader leer = File.OpenText("Empleados_Agregados.txt");
            cadena = leer.ReadLine();

            if (tipo_Busqueda.Equals("Nombre :"))
            {
                while (cadena != null && encontrado == false)
                {
                    datos = cadena.Split(separdor);

                    if (datos[0].Equals(Nbus))
                    {
                        lista.Add(new agregando_trabajador {Nombre= datos[0], Apellido= datos[1], Cedula1= datos[2], Codigo= datos[3]});
                        MessageBox.Show("Registro Encontrado :) ....");
                        encontrado = true;
                    }
                    else
                    cadena = leer.ReadLine();
                }
                leer.Close();
                if (encontrado == false)
                    MessageBox.Show("El Registro Nose Encuentra En La Base De Datos ...");

                leer.Close();
            }
            ////////////////////////////////////////////////////////////////////////
            else if (tipo_Busqueda.Equals("Codigo :"))
            {
                while (cadena != null && encontrado == false)
                {
                    datos = cadena.Split(separdor);

                    if (datos[3].Equals(Nbus))
                    {
                        lista.Add(new agregando_trabajador { Nombre = datos[0], Apellido = datos[1], Cedula1 = datos[2], Codigo = datos[3] });
                        MessageBox.Show("Registro Encontrado :) ....");
                        encontrado = true;
                    }
                    cadena = leer.ReadLine();
                }
                leer.Close();
                if (encontrado == false)
                    MessageBox.Show("El Registro Nose Encuentra En La Base De Datos ...");

                leer.Close();
            }

            return lista;
        }

        public List<agregando_trabajador> Mostrar_todo()
        {
            List<agregando_trabajador> lista_ = new List<agregando_trabajador>();
            String entrada=null;
            String[] datos = new String[4];
            StreamReader leer = File.OpenText("Empleados_Agregados.txt");
            entrada = leer.ReadLine();

            while (entrada != null)
            {
                datos = entrada.Split(separdor);
                lista_.Add(new agregando_trabajador {Nombre=datos[0],Apellido=datos[1],Cedula1=datos[2],Codigo=datos[3] });
                entrada = leer.ReadLine();
            }
            leer.Close();
            return lista_;
        }

        public void Registros_Eliminar(int indice)
        {
            StreamWriter escribir;
            StreamReader leer;
            String[] datos;
            String cadena;
            int c = 0;
            try
            {
                bool encontrado = false;
                escribir = File.CreateText("Temp_Empleados.txt");
                leer = File.OpenText("Empleados_Agregados.txt");
                cadena = leer.ReadLine();

                 while (cadena != null)
                {
                    datos = cadena.Split(separdor);

                    if (c == indice)
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

                if (encontrado == true)
                { MessageBox.Show("Eliminado Correctamente :) ..."); }
                leer.Close();
                escribir.Close();
                File.Delete("Empleados_Agregados.txt");
                File.Move("Temp_Empleados.txt", "Empleados_Agregados.txt");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
