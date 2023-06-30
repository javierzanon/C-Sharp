using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace bpssgestion
{
    class bpssdbcheck
    {
        public Boolean documentoBloqueado(Int64 documentoid)
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
                sql = "EXEC checkDocumentoBloqueado @documentoid";
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
                return true;
            }
        }
        public Boolean usuarioactivo(String usuario)
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
                sql = "EXEC procUsuarioCheck @usuario";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("usuario", System.Data.SqlDbType.VarChar );
                command.Parameters["usuario"].Value = usuario;
                
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                String resultado = reader.GetString(0);
                if (resultado == "OK")
                    return true;
                else if (resultado == "NO")
                    return false;
                else
                    return false;
                
            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return true;
            }
        }
        public Boolean usuariologin(String usuario, String clave)
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
                sql = "EXEC procUsuarioLoginCheck @usuario, @clave";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("usuario", System.Data.SqlDbType.VarChar );
                command.Parameters["usuario"].Value = usuario;
                command.Parameters.Add("clave", System.Data.SqlDbType.VarChar );
                command.Parameters["clave"].Value = clave;
                
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                String resultado = reader.GetString(0);
                
                if (resultado == "OK")
                    return true;
                else
                    return false;
                
            }
            catch (Exception e)
            {
                bpsslog log = new bpsslog();
                log.log(e.ToString());
                return false;
            }
        }
    }
}