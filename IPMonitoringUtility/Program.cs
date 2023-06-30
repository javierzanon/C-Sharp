using System;
using System.Collections.Generic;

namespace pong
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PONG!");
            Boolean debug = false;
            if (args.Length > 0)
            {
                if (args[0] == "debug")
                {
                    debug = true;
                    Console.WriteLine ("---- Modo DEBUG activado ----");
                }   
            }
            if (debug == true)
                Console.WriteLine ("-- Obteniendo listado de dispositivos a comprobar --");
            PONGDBOPS database = new PONGDBOPS();
            List<PONGDB.dbdispositivo> listado = new List<PONGDB.dbdispositivo>();
            listado = database.listDispositivo(debug);
            Ping red = new Ping();
            Boolean estado = false;
            if (debug == true)
                Console.WriteLine ("-- Comprobando dispositivos --");
            foreach (PONGDB.dbdispositivo dispositivo in listado)
            {
                if (debug == true)
                {
                    Console.WriteLine ("Iniciando comprobación del dispositivo: " + dispositivo.IP);
                    Console.WriteLine ("Comprobando si la conexión de red se encuentra disponible. Para ello se intentará llegar al host: " + dispositivo.chequearPreviamenteIP);
                }
                    
                // Pingueo la IP que se debe chequear previamente a la IP del dispositivo (para asegurarme de tener conexión de red)
                estado = red.Pinguear(dispositivo.chequearPreviamenteIP, debug);
                if (estado == false)
                {
                    // En caso de que no esté accesible, seteo el estado del dispositivo como que no se puede comprobar
                    database.setEstadoDispositivo(dispositivo.ID, 9, debug);
                    if (debug == true)
                        Console.WriteLine ("El estado dispositivo " + dispositivo.IP + " no se puede verificar. Se comprobó la conexión de red intentando llegar al dispositivo " + dispositivo.chequearPreviamenteIP + " y se ha concluído que no hay red.");
                }                    
                else
                {
                    if (debug == true)
                        Console.WriteLine ("Comprobando el estado del dispositivo: " + dispositivo.IP);
                    estado = red.Pinguear(dispositivo.IP, debug);
                    // Seteo el estado del dispositivo según el resultado del ping
                    if (estado == true)
                    {
                        if (debug == true)
                            Console.WriteLine ("El dispositivo: " + dispositivo.IP + " se encuentra activo.");
                        database.setEstadoDispositivo(dispositivo.ID, 1, debug);
                    }
                    else
                    {
                        if (debug == true)
                            Console.WriteLine ("El dispositivo: " + dispositivo.IP + " está inactivo.");
                        database.setEstadoDispositivo(dispositivo.ID, 0, debug);
                    }
                }
            }
            if (debug == true)
                Console.WriteLine ("-- Listado comprobado --");
            Console.WriteLine ("!GNOP");
        }

    }
}
