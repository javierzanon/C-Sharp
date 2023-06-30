
using System;
using System.Data.SqlClient;

namespace bpssgestion
{
    public class bpssdb
    {
        public string dbconfig(string tipo)
        {
            // Estas son los datos de acceso a la base de datos. Estan ubicados en el archivo launchSettings.json dentro de la carpeta Properties
            switch (tipo)
            {
                case "DataSource": return "";  
                case "UserID": return "";         
                case "Password": return "";     
                case "InitialCatalog": return "";
                case "FotosPath": return "C:\\BPSSGestionIMG";
                case "FechaNull": return "1945-09-02 00:00:00";
                default: return "";
            }
            
        }
        public string encryptconfig(string tipo)
        {
            switch(tipo)
            {
                case "aes_key": return "45-A7-19-07-EA-38-0B-1C-4D-1A-37-9E-DB-A2-1A-24-F6-58-4F-05-46-CB-5C-38-AD-9C-6C-2B-DF-9E-32-00";
                case "aes_IV": return "92-3C-B2-37-0A-44-5E-9D-06-05-D7-F7-BC-58-50-E6";
                case "ofusca": return "wallaby42";
                default: return "";
            }
        }
        public string logconfig(string tipo)
        {
            // Estas son los datos de ubicación del archivo de log.
            switch (tipo)
            {
                case "path": return "C:\\BPSSGestionLOG\\BPSSGestionLog.txt";
                default: return "";
            }
        }
        public string documentoview(Int64 tipo)
        {
            // Esta función decide que vista se debe elegir para ver el documento, según el ID de su tipo
            switch (tipo)
            {
                case 1: return "EstadoActa";
                case 2: return "EstadoMulta";
                default: return "Lista";
            }
        }
        // Esta clase corresponde a los datos de la tabla usuario en db        
        public class dbusuario
        {
            public Int64? usuarioid;
            public string usuario;

            public string usuarioNombre;
            public string clave;
            public Int64? accionidusuario;
            public DateTime? accionfecha;
 
        }
        // Esta clase corresponde a los datos de la tabla permiso en db
        public class dbpermiso
        {
            public Int64 permisoid;
            public string nombre;
            public string descripcion;
            public Int64 accionidusuario;
            public DateTime accionidfecha;
 
        }
        // Esta clase corresponde a los datos de ña tabla relusuariopermiso en db
        public class relusuariopermiso
        {
            public Int64 usuarioid;
            public Int64 permisoid;
            public Int64 accionidusuario;
            public DateTime accionidfecha;
        }

        public class dbdocumentotipo
        {
            public Int64 documentotipoid;
            public string documentotipo;
        }
        public class dbdocumentoestado
        {
            public Int64 documentoestadoid;
            public string documentoestado;
        }
        public class dbarea
        {
            public Int64 areaid;
            public string area;
        }

        public class dblote
        {
            public Int64 loteid;
            public string lote;
        }   
        public class dbdocumento
        {
            public Int64 documentoId;
            public Int64 documentoTipo;
            public Int64 documentoEstado;
            public DateTime fecha;
            public Int64 area;
            public Int64 lote;
            public Int64 bloqueado;
            public Int64 accionusuarioid;
            public DateTime accionfecha;
        }
        
        public class dbdocumentoExtendido
        {
            public Int64 documentoId;
            public Int64 documentoTipoId;
            public String documentoTipo;
            public Int64 documentoEstadoId;
            public String documentoEstado;
            public DateTime fecha;
            public Int64 areaId;
            public String area;
            public Int64 loteId;
            public String lote;
            public Int64 bloqueado;
            public Int64 accionusuarioid;
            public String accionusuario;
            public DateTime accionfecha;
        }
        public class dbdocumentodescripcion
        {
            public Int64 documentoId;
            public Int64 documentoDescripcionId;
            public String documentoDescripcion;
            public String documentoDescripcionNotas;

        }
    }
}