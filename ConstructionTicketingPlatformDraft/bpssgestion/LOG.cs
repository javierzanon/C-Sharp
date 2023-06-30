using System;  
using System.IO;  
using System.Text;  

namespace bpssgestion
{
    // Esta clase se utiliza para hacer log en un archivo de texto definido y en la consola
    // El archivo se define en la variable bpsslog_file, dentro del archivo launchSettings.json en la carpeta Properties

    class bpsslog
    {
        public void log(string mensaje)
        {
            try
            {
                // Genero una variable con el datetime del momento
                string tiempo = DateTime.Now.ToString();
                // Obtengo la ubicación del archivo de texto
                bpssdb parametros = new bpssdb();
                string archivo = parametros.logconfig("path");
                // Lo creo si no existe
                if (!File.Exists(archivo))
                {
                    FileStream generador = File.Open(archivo,FileMode.Append);
                    generador.Dispose();    
                }
                // Escribo en el archivo
                FileStream cadena = File.Open(archivo,FileMode.Append);
                byte[] info = new UTF8Encoding(true).GetBytes(tiempo + " " + mensaje + "\r\n");  
                cadena.Write(info, 0, info.Length);
                // Cierro el archivo
                cadena.Dispose();
                // Escribo en la consola
                Console.WriteLine (mensaje);
            } 
            catch (Exception e)
            {
                // En caso de que el proceso de arriba falle
                // Escribo en la consola el error por el cual falló esta función
                // Y a continuación escribo en consola el mensaje que quiso loguear esta función inicialmente
                Console.WriteLine ("-------------------");
                Console.WriteLine (e.ToString());
                Console.WriteLine ("-------------------");
                Console.WriteLine (mensaje);
                Console.WriteLine ("-------------------");
            }
        }
    }
}