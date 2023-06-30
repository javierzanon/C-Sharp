using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace bpssgestion
{
    class bpssdbstorage
    {
        public Int64 DocumentoDescripcionBorrar(bpssdb.dbdocumentodescripcion documentoDescripcion)
        {
            //Esta función determina si un documento se encuentra bloqueado para su edición 
            //El documento luego de finalizada su edición inicial se encontrará bloqueado para siempre
            //De esta manera se evita que los documentos que hayan sido enviados sean modificados de manera inadvertida para los involucrados
            
            String sql = new String("");
            bpssdb dbutils = new bpssdb();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dbutils.dbconfig("DataSource");
                builder.UserID = dbutils.dbconfig("UserID");
                builder.Password = dbutils.dbconfig("Password");
                builder.InitialCatalog = dbutils.dbconfig("InitialCatalog");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "EXEC actDocumentoDescripcionBorrar @documentoid, @documentodescripcionid";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("documentoid", System.Data.SqlDbType.BigInt );
                command.Parameters["documentoid"].Value = documentoDescripcion.documentoId;
                command.Parameters.Add("documentodescripcionid", System.Data.SqlDbType.BigInt );
                command.Parameters["documentodescripcionid"].Value = documentoDescripcion.documentoDescripcionId;
                
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Int64 resultado = reader.GetInt64(0);
                
                return resultado;
            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return -1;
            }
        }
        public String DocumentoDescripcionAgregar(bpssdb.dbdocumentodescripcion documentoDescripcion)
        {
            //Esta función determina si un documento se encuentra bloqueado para su edición 
            //El documento luego de finalizada su edición inicial se encontrará bloqueado para siempre
            //De esta manera se evita que los documentos que hayan sido enviados sean modificados de manera inadvertida para los involucrados
            
            String sql = new String("");
            bpssdb dbutils = new bpssdb();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dbutils.dbconfig("DataSource");
                builder.UserID = dbutils.dbconfig("UserID");
                builder.Password = dbutils.dbconfig("Password");
                builder.InitialCatalog = dbutils.dbconfig("InitialCatalog");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "EXEC actDocumentoDescripcionAgregar @documentoid, @documentodescripcionid, @documentodescripcionnotas";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("documentoid", System.Data.SqlDbType.BigInt );
                command.Parameters["documentoid"].Value = documentoDescripcion.documentoId;
                command.Parameters.Add("documentodescripcionid", System.Data.SqlDbType.BigInt );
                command.Parameters["documentodescripcionid"].Value = documentoDescripcion.documentoDescripcionId;
                command.Parameters.Add("documentodescripcionnotas", System.Data.SqlDbType.VarChar );
                command.Parameters["documentodescripcionnotas"].Value = documentoDescripcion.documentoDescripcionNotas;

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                String resultado = "";
                if (reader.GetInt64(0) > -1)
                    resultado = "{ documentoDescripcionId:" + Convert.ToString(reader.GetInt64(0)) + ", \r\n documentoDescripcion:" + reader.GetString(1) + ", \r\n documentoDescripcionNotas:" + reader.GetString(2) + "}";
                else 
                    resultado = Convert.ToString(reader.GetInt64(0));

                return resultado;
            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return "-3";
            }
        }
        public Boolean DocumentoBloquear(Int64 documentoid)
        {
            //Esta función determina si un documento se encuentra bloqueado para su edición 
            //El documento luego de finalizada su edición inicial se encontrará bloqueado para siempre
            //De esta manera se evita que los documentos que hayan sido enviados sean modificados de manera inadvertida para los involucrados
            
            String sql = new String("");
            bpssdb dbutils = new bpssdb();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = dbutils.dbconfig("DataSource");
                builder.UserID = dbutils.dbconfig("UserID");
                builder.Password = dbutils.dbconfig("Password");
                builder.InitialCatalog = dbutils.dbconfig("InitialCatalog");
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "EXEC actDocumentoBloquear @documentoid";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("documentoid", System.Data.SqlDbType.BigInt );
                command.Parameters["documentoid"].Value = documentoid;
                
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                Int64 resultado = reader.GetInt64(0);
                if (resultado == 0)
                    return false;
                else 
                    return true;
            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return false;
            }
        }
        public Int64 DocumentoAgregar (bpssdb.dbdocumento documento)
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
                sql = "EXEC procDocumentoStore @documentoTipo, @documentoEstado, @fecha, @area, @lote, @bloqueado, @accionusuarioid, @accionfecha";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("documentotipo", System.Data.SqlDbType.BigInt );
                command.Parameters["documentotipo"].Value = documento.documentoTipo;
                command.Parameters.Add("documentoestado", System.Data.SqlDbType.BigInt );
                command.Parameters["documentoestado"].Value = documento.documentoEstado;
                command.Parameters.Add("fecha", System.Data.SqlDbType.DateTime );
                command.Parameters["fecha"].Value = documento.fecha;
                command.Parameters.Add("area", System.Data.SqlDbType.BigInt );
                command.Parameters["area"].Value = documento.area;
                command.Parameters.Add("lote", System.Data.SqlDbType.BigInt );
                command.Parameters["lote"].Value = documento.lote;
                command.Parameters.Add("bloqueado", System.Data.SqlDbType.BigInt );
                command.Parameters["bloqueado"].Value = documento.bloqueado;
                command.Parameters.Add("accionusuarioid", System.Data.SqlDbType.BigInt );
                command.Parameters["accionusuarioid"].Value = documento.accionusuarioid;
                command.Parameters.Add("accionfecha", System.Data.SqlDbType.DateTime );
                command.Parameters["accionfecha"].Value = documento.accionfecha;
                
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                return reader.GetInt64(0);
            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return 0;
            }
        }
    }
}