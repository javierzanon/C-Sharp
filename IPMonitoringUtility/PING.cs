using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace pong
{
    public class Ping
    {
        public Boolean Pinguear (string ip, Boolean debug)
        {
            Boolean resultado = false;
            
            if (debug == true)
                Console.WriteLine(">>Pingueando " + ip);            
            try
            {
                resultado = ComprobarIP(ip, debug);
                if (resultado == false)
                {
                    if (debug == true)
                        Console.WriteLine(">>Primer ping fallido. Intentando un segundo ping.");
                    resultado = ComprobarIP(ip, debug);
                    if (resultado == false)
                    {
                        Console.WriteLine(">>Segundo ping fallido. Intentando un tercer ping.");
                        resultado = ComprobarIP(ip, debug);
                    }
                }
            }
            catch
            {
                if (debug == true)
                    Console.WriteLine(">>Se produjo un error. Compruebe la dirección IP.");
            }
            if (resultado == true)
            {
                if (debug == true)
                    Console.WriteLine(">>Comprobación satisfactoria.");
            }
            else
            {
                if (debug == true)
                    Console.WriteLine(">>No se pudo contactar con el host.");
            }
            return resultado;
        }
        public Boolean ComprobarIP (string ip, Boolean debug)
        {
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping ();
            PingOptions options = new PingOptions ();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes (data);
            int timeout = 120;
            PingReply reply = pingSender.Send (ip, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                if (debug == true)
                {
                    Console.WriteLine (">>>>Address: {0}", reply.Address.ToString ());
                    Console.WriteLine (">>>>RoundTrip time: {0}", reply.RoundtripTime);
                    Console.WriteLine (">>>>Time to live: {0}", reply.Options.Ttl);
                    Console.WriteLine (">>>>Don't fragment: {0}", reply.Options.DontFragment);
                    Console.WriteLine (">>>>Buffer size: {0}", reply.Buffer.Length);
                }
                return(true);
            }
            else
            {
                return(false);
            }
        }
    }
}