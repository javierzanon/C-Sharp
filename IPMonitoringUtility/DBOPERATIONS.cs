using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace pong
{
    class PONGDBOPS
    {
        public List<PONGDB.dbdispositivo> listDispositivo(Boolean debug)
        {
            // String con el contenido de la devolución de la función
            String sql = new String("");
            List<PONGDB.dbdispositivo> listDispositivo = new List<PONGDB.dbdispositivo>();
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = PONGDB.dbconfig.DataSource;
                builder.UserID = PONGDB.dbconfig.UserID;
                builder.Password = PONGDB.dbconfig.Password;
                builder.InitialCatalog = PONGDB.dbconfig.InitialCatalog;
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "EXEC procListDispositivo";
                SqlCommand command = new SqlCommand(sql, connection);
                
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listDispositivo.Add(new PONGDB.dbdispositivo { ID = reader.GetInt64(0), IP = reader.GetString(1), chequearPreviamenteIP = reader.GetString(2) });
                }
                connection.Close();
            }
            catch (Exception e)
            {
                if (debug == true)
                    Console.WriteLine(e.ToString());
            }
            return listDispositivo;
        }
        public void setEstadoDispositivo(Int64 dispositivoid, Int64 estadoid, Boolean debug)
        {
            // String con el contenido de la devolución de la función
            String sql = new String("");
            try
            {

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = PONGDB.dbconfig.DataSource;
                builder.UserID = PONGDB.dbconfig.UserID;
                builder.Password = PONGDB.dbconfig.Password;
                builder.InitialCatalog = PONGDB.dbconfig.InitialCatalog;
                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                sql = "EXEC procSetEstadoDispositivo @dispositivoid, @estadoid";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.Add("dispositivoid", System.Data.SqlDbType.BigInt );
                command.Parameters["dispositivoid"].Value = dispositivoid;
                command.Parameters.Add("estadoid", System.Data.SqlDbType.BigInt );
                command.Parameters["estadoid"].Value = estadoid;
                
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();

            }
            catch (Exception e)
            {
                if (debug == true)
                    Console.WriteLine(e.ToString());
            }
        }
    }
}