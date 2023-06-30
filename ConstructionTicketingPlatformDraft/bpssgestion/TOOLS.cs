using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace bpssgestion
{
    public class bpsstools
    {
        public Boolean LoginSet(ISession sesiones, String usuario, String clave)
        {
            bpssdb config = new bpssdb();
            bpssdbcheck chequeo = new bpssdbcheck();       
            Boolean resultado = chequeo.usuariologin(usuario, config.encryptconfig("ofusca") + clave);
            if (resultado == true)
            {
                DateTime localDate = DateTime.Now;
                var culture = new CultureInfo("fr-FR");
                String hora = localDate.ToString(culture);
                sesiones.Set("gandalf", Encriptar(hora + " " + usuario));
                return true;
            }
            else 
            {
                sesiones.Remove("gandalf");
                return false;
            }
        }
        public Boolean LoginGet(ISession sesiones)
        {
            if (! string.IsNullOrEmpty(sesiones.GetString("gandalf")))
            {
                byte[] btSesion = sesiones.Get("gandalf");
                String strSesion = Desencriptar(btSesion);
                String usuario = strSesion.Substring(20);
                bpssdbcheck chequeo = new bpssdbcheck();       
                Boolean respuesta = chequeo.usuarioactivo(usuario);
                if (respuesta == false)
                {
                    sesiones.Remove("gandalf");
                    return false;
                }
                else 
                {
                    DateTime localDate = DateTime.Now;
                    var culture = new CultureInfo("fr-FR");
                    String hora = localDate.ToString(culture);
                    sesiones.Set("gandalf", Encriptar(hora + " " + usuario));
                    return true;
                }

            }
            else 
            {
                return false;
            }
        }
        public string Desencriptar(byte[] encrypted)
        {
            // Create a new instance of the Aes
            // class.  This generates a new key and initialization
            // vector (IV).
            // Aes myAes = Aes.Create()
            bpssdb configdata = new bpssdb();

            String strKey = configdata.encryptconfig("aes_key");
            String[] arrKey=strKey.Split('-');
            byte[] key=new byte[arrKey.Length];
            for(int i=0; i<arrKey.Length; i++) key[i]=Convert.ToByte(arrKey[i],16);

            String strIV = configdata.encryptconfig("aes_IV");
            String[] arrIV=strIV.Split('-');
            byte[] IV=new byte[arrIV.Length];
            for(int i=0; i<arrIV.Length; i++) IV[i]=Convert.ToByte(arrIV[i],16);

            // Decrypt the bytes to a string.
            string original = DecryptStringFromBytes_Aes(encrypted, key, IV);
            return original;
        }
        public byte[] Encriptar(String original)
        {
            
            // Create a new instance of the Aes
            // class.  This generates a new key and initialization
            // vector (IV).
            //Aes myAes = Aes.Create()
            
            // Encrypt the string to an array of bytes.
            bpssdb configdata = new bpssdb();
            
            String strKey = configdata.encryptconfig("aes_key");
            String[] arrKey=strKey.Split('-');
            byte[] key=new byte[arrKey.Length];
            for(int i=0; i<arrKey.Length; i++) key[i]=Convert.ToByte(arrKey[i],16);

            String strIV = configdata.encryptconfig("aes_IV");
            String[] arrIV=strIV.Split('-');
            byte[] IV=new byte[arrIV.Length];
            for(int i=0; i<arrIV.Length; i++) IV[i]=Convert.ToByte(arrIV[i],16);


            byte[] bytesEncrypted = EncryptStringToBytes_Aes(original, key, IV);
            return bytesEncrypted;
        }
        private byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        private string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
        
        public String jsonLote (List<bpssdb.dblote> listaLote)
        {
            String jsonFinal = "";
            String jsonSegmento;
            bool esPrimero = true;
            try
            {
                foreach (bpssdb.dblote lote in listaLote)
                {
                    jsonSegmento = $"\"loteid\": \"{lote.loteid}\", \r\n \"lote\": \"{lote.lote}\"";
                    jsonSegmento = "{" + jsonSegmento + "}";
                    if (esPrimero)
                    {
                        esPrimero = false;
                    }
                    else 
                    {
                        jsonSegmento = ",\r\n" + jsonSegmento;
                    }
                    jsonFinal += jsonSegmento;
                    
                }
            } 
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
            }
            jsonFinal = "{\r\n\"lotes\":\r\n[\r\n" + jsonFinal + "\r\n]\r\n}";
            return jsonFinal;
        }
    }
}