using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace bpssgestion
{
    class bpssdblist
    {
        public List<bpssdb.dbusuario> listUsuario()
        {
            // String con el contenido de la devolución de la función
            String sql = new String("");
            bpssdb dbutils = new bpssdb();
            List<bpssdb.dbusuario> listUsuario = new List<bpssdb.dbusuario>();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dbutils.dbconfig("DataSource");
                builder.UserID = dbutils.dbconfig("UserID");
                builder.Password = dbutils.dbconfig("Password");
                builder.InitialCatalog = dbutils.dbconfig("InitialCatalog");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "SELECT usuarioid, usuario, usuarionombre FROM usuario;";
                SqlCommand command = new SqlCommand(sql, connection);
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listUsuario.Add(new bpssdb.dbusuario { usuarioid = reader.GetInt64(0), usuario = reader.GetString(1),  usuarioNombre = reader.GetString(2) });
                }

            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return null;
            }
            return listUsuario;
        }
        public List<bpssdb.dbusuario> getUsuario(bpssdb.dbusuario paramusuario)
        {
            // String con el contenido de la devolución de la función
            String sql = new String("");
            bpssdb dbutils = new bpssdb();
            List<bpssdb.dbusuario> listUsuario = new List<bpssdb.dbusuario>();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dbutils.dbconfig("DataSource");
                builder.UserID = dbutils.dbconfig("UserID");
                builder.Password = dbutils.dbconfig("Password");
                builder.InitialCatalog = dbutils.dbconfig("InitialCatalog");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "EXEC procUsuarioList @usuarioid, @usuario, @clave, @accionidusuario, @accionfecha";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("usuarioid", System.Data.SqlDbType.BigInt );
                command.Parameters["usuarioid"].Value = paramusuario.usuarioid;
                command.Parameters.Add("usuario", System.Data.SqlDbType.NVarChar );
                command.Parameters["usuario"].Value = paramusuario.usuario;
                command.Parameters.Add("clave", System.Data.SqlDbType.NVarChar );
                command.Parameters["clave"].Value = paramusuario.clave;
                command.Parameters.Add("accionidusuario", System.Data.SqlDbType.BigInt );
                command.Parameters["accionidusuario"].Value = paramusuario.accionidusuario;
                command.Parameters.Add("accionfecha", System.Data.SqlDbType.DateTime );
                command.Parameters["accionfecha"].Value = paramusuario.accionfecha;
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listUsuario.Add(new bpssdb.dbusuario { usuarioid = reader.GetInt64(0),  usuario = reader.GetString(1),  clave = reader.GetString(2), accionidusuario = reader.GetInt64(3), accionfecha = reader.GetDateTime(4) });
                }

            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return null;
            }
            return listUsuario;
        }
        public List<bpssdb.dbdocumentoExtendido> listDocumentoExtendido(Int64 areaid, Int64 loteid, Int64 documentotipoid, Int64 documentoestadoid, DateTime fechainicio, DateTime fechafin, Int64 usuarioid)
        {
            // String con el contenido de la devolución de la función
            String sql = new String("");
            bpssdb dbutils = new bpssdb();
            List<bpssdb.dbdocumentoExtendido> listadoDocumento = new List<bpssdb.dbdocumentoExtendido>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dbutils.dbconfig("DataSource");
                builder.UserID = dbutils.dbconfig("UserID");
                builder.Password = dbutils.dbconfig("Password");
                builder.InitialCatalog = dbutils.dbconfig("InitialCatalog");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "EXEC procDocumentoExtendidoList @areaid, @loteid, @documentotipoid, @documentoestadoid, @fechainicio, @fechafin, @usuarioid";
                SqlCommand command = new SqlCommand(sql, connection);

                //Si la fecha viene vacía cargo la fecha considerada Null en los procedimientos y stored procedures
                if (fechainicio.ToString() == "01/01/0001 0:00:00")
                {
                    fechainicio = DateTime.Parse(dbutils.dbconfig("FechaNull"));
                }
                    
                if (fechafin.ToString() == "01/01/0001 0:00:00")
                {
                    fechafin = DateTime.Parse(dbutils.dbconfig("FechaNull"));
                }
                
                command.Parameters.Add("areaid", System.Data.SqlDbType.BigInt );
                command.Parameters["areaid"].Value = areaid;
                command.Parameters.Add("loteid", System.Data.SqlDbType.BigInt );
                command.Parameters["loteid"].Value = loteid;
                command.Parameters.Add("documentotipoid", System.Data.SqlDbType.BigInt );
                command.Parameters["documentotipoid"].Value = documentotipoid;
                command.Parameters.Add("documentoestadoid", System.Data.SqlDbType.BigInt );
                command.Parameters["documentoestadoid"].Value = documentoestadoid;
                command.Parameters.Add("fechainicio", System.Data.SqlDbType.DateTime );
                command.Parameters["fechainicio"].Value = fechainicio;
                command.Parameters.Add("fechafin", System.Data.SqlDbType.DateTime );
                command.Parameters["fechafin"].Value = fechafin;
                command.Parameters.Add("usuarioid", System.Data.SqlDbType.BigInt );
                command.Parameters["usuarioid"].Value = usuarioid;
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listadoDocumento.Add (
                        new bpssdb.dbdocumentoExtendido {
                            documentoId = reader.GetInt64(0),
                            documentoTipoId = reader.GetInt64(1),
                            documentoTipo = reader.GetString(2),
                            documentoEstadoId = reader.GetInt64(3),
                            documentoEstado = reader.GetString(4),
                            fecha = reader.GetDateTime(5),
                            areaId = reader.GetInt64(6),
                            area = reader.GetString(7),
                            loteId = reader.GetInt64(8),
                            lote = reader.GetString(9),
                            bloqueado = reader.GetInt64(10),
                            accionusuarioid = reader.GetInt64(11),
                            accionusuario = reader.GetString(12),
                            accionfecha = reader.GetDateTime(13)});
                }
            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return null;
            }
            return listadoDocumento;
        }
        public bpssdb.dbdocumentoExtendido DocumentoExtendido(Int64 LaGaaarra)
        {
            // String con el contenido de la devolución de la función
            String sql = new String("");
            bpssdb dbutils = new bpssdb();
            bpssdb.dbdocumentoExtendido cabeceraDocumento = new bpssdb.dbdocumentoExtendido();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dbutils.dbconfig("DataSource");
                builder.UserID = dbutils.dbconfig("UserID");
                builder.Password = dbutils.dbconfig("Password");
                builder.InitialCatalog = dbutils.dbconfig("InitialCatalog");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "EXEC procDocumentoExtendidoShow @documentoid";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("documentoid", System.Data.SqlDbType.BigInt );
                command.Parameters["documentoid"].Value = LaGaaarra;
                
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                cabeceraDocumento.documentoId = reader.GetInt64(0);
                cabeceraDocumento.documentoTipoId = reader.GetInt64(1);
                cabeceraDocumento.documentoTipo = reader.GetString(2);
                cabeceraDocumento.documentoEstadoId = reader.GetInt64(3);
                cabeceraDocumento.documentoEstado = reader.GetString(4);
                cabeceraDocumento.fecha = reader.GetDateTime(5);
                cabeceraDocumento.areaId = reader.GetInt64(6);
                cabeceraDocumento.area = reader.GetString(7);
                cabeceraDocumento.loteId = reader.GetInt64(8);
                cabeceraDocumento.lote = reader.GetString(9);
                cabeceraDocumento.bloqueado = reader.GetInt64(10);
                cabeceraDocumento.accionusuarioid = reader.GetInt64(11);
                cabeceraDocumento.accionusuario = reader.GetString(12);
                cabeceraDocumento.accionfecha = reader.GetDateTime(13);
            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return null;
            }
            return cabeceraDocumento;
        }
        
        public List<bpssdb.dbdocumentotipo> listDocumentoTipo()
        {
            // String con el contenido de la devolución de la función
            String sql = new String("");
            bpssdb dbutils = new bpssdb();
            List<bpssdb.dbdocumentotipo> listDocumentoTipo = new List<bpssdb.dbdocumentotipo>();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dbutils.dbconfig("DataSource");
                builder.UserID = dbutils.dbconfig("UserID");
                builder.Password = dbutils.dbconfig("Password");
                builder.InitialCatalog = dbutils.dbconfig("InitialCatalog");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "SELECT documentotipoid, documentotipo FROM documentotipo;";
                SqlCommand command = new SqlCommand(sql, connection);
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listDocumentoTipo.Add(new bpssdb.dbdocumentotipo { documentotipoid = reader.GetInt64(0),  documentotipo = reader.GetString(1) });
                }

            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return null;
            }
            return listDocumentoTipo;
        }
        public List<bpssdb.dbdocumentoestado> listDocumentoEstado()
        {
            // String con el contenido de la devolución de la función
            String sql = new String("");
            bpssdb dbutils = new bpssdb();
            List<bpssdb.dbdocumentoestado> listDocumentoEstado = new List<bpssdb.dbdocumentoestado>();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dbutils.dbconfig("DataSource");
                builder.UserID = dbutils.dbconfig("UserID");
                builder.Password = dbutils.dbconfig("Password");
                builder.InitialCatalog = dbutils.dbconfig("InitialCatalog");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "SELECT documentoestadoid, documentoestado FROM documentoestado;";
                SqlCommand command = new SqlCommand(sql, connection);
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listDocumentoEstado.Add(new bpssdb.dbdocumentoestado { documentoestadoid = reader.GetInt64(0),  documentoestado = reader.GetString(1) });
                }

            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return null;
            }
            return listDocumentoEstado;
        }
        public List<bpssdb.dbdocumentodescripcion> listDescripcion()
        {
            // String con el contenido de la devolución de la función
            String sql = new String("");
            bpssdb dbutils = new bpssdb();
            List<bpssdb.dbdocumentodescripcion> listDocumentoDescripcion = new List<bpssdb.dbdocumentodescripcion>();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dbutils.dbconfig("DataSource");
                builder.UserID = dbutils.dbconfig("UserID");
                builder.Password = dbutils.dbconfig("Password");
                builder.InitialCatalog = dbutils.dbconfig("InitialCatalog");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "SELECT documentodescripcionid, documentodescripcion FROM documentoDescripcion;";
                SqlCommand command = new SqlCommand(sql, connection);
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listDocumentoDescripcion.Add(new bpssdb.dbdocumentodescripcion { documentoDescripcionId = reader.GetInt64(0),  documentoDescripcion = reader.GetString(1) });
                }

            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return null;
            }
            return listDocumentoDescripcion;
        }
        public List<bpssdb.dbdocumentodescripcion> listDocumentoDescripcion(Int64 LaGaaarra)
        {
            // String con el contenido de la devolución de la función
            String sql = new String("");
            bpssdb dbutils = new bpssdb();
            List<bpssdb.dbdocumentodescripcion> listDocumentoDescripcion = new List<bpssdb.dbdocumentodescripcion>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dbutils.dbconfig("DataSource");
                builder.UserID = dbutils.dbconfig("UserID");
                builder.Password = dbutils.dbconfig("Password");
                builder.InitialCatalog = dbutils.dbconfig("InitialCatalog");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "EXEC procDocumentoDescripcionList @documentoid";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("documentoid", System.Data.SqlDbType.BigInt );
                command.Parameters["documentoid"].Value = LaGaaarra;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listDocumentoDescripcion.Add(new bpssdb.dbdocumentodescripcion { documentoDescripcionId = reader.GetInt64(0),  documentoDescripcion = reader.GetString(1),  documentoDescripcionNotas = reader.GetString(2) });
                }

            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return null;
            }
            return listDocumentoDescripcion;
        }
        public List<bpssdb.dbarea> listArea()
        {
            // String con el contenido de la devolución de la función
            String sql = new String("");
            bpssdb dbutils = new bpssdb();
            List<bpssdb.dbarea> listArea = new List<bpssdb.dbarea>();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dbutils.dbconfig("DataSource");
                builder.UserID = dbutils.dbconfig("UserID");
                builder.Password = dbutils.dbconfig("Password");
                builder.InitialCatalog = dbutils.dbconfig("InitialCatalog");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "SELECT areaid, area FROM area;";
                SqlCommand command = new SqlCommand(sql, connection);
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listArea.Add(new bpssdb.dbarea { areaid = reader.GetInt64(0),  area = reader.GetString(1) });
                }

            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return null;
            }
            return listArea;
        }
        public List<bpssdb.dblote> listLote(Int64 areaSeleccionada)
        {
            // String con el contenido de la devolución de la función
            String sql = new String("");
            bpssdb dbutils = new bpssdb();
            List<bpssdb.dblote> listLote = new List<bpssdb.dblote>();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dbutils.dbconfig("DataSource");
                builder.UserID = dbutils.dbconfig("UserID");
                builder.Password = dbutils.dbconfig("Password");
                builder.InitialCatalog = dbutils.dbconfig("InitialCatalog");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "EXEC procLoteList @areaid;";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("areaid", System.Data.SqlDbType.BigInt );
                command.Parameters["areaid"].Value = areaSeleccionada;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listLote.Add(new bpssdb.dblote { loteid = reader.GetInt64(0),  lote = reader.GetString(1) });
                }

            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return null;
            }
            return listLote;
        }
    }

}