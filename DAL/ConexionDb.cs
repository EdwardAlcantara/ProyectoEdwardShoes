
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class ConexionDb
    {

        public SqlConnection Con;
        public SqlCommand miComando;
        public SqlDataReader miDataReader;
        public SqlDataAdapter adp;
        public DataTable dt;

        
        public void ConectarDB()
        {
            Con = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog= ShoesDb2; Integrated Security=True");
            Con.Open();
        }

        public void DesconectarDB()
        {
            Con.Close();
        }

        
        public bool EjecutarComando(string Query)
        {
            bool mensaje = false;
            ConectarDB();
            miComando = new SqlCommand(Query, Con);
            int FilasAfectadas = miComando.ExecuteNonQuery();

            if (FilasAfectadas > 0)
            {
                mensaje = true;
            }
            else
            {
                mensaje = false;
            }
            DesconectarDB();
            return mensaje;
        }

        
        public DataTable getData(string sql)
        {
            ConectarDB();
            dt = new DataTable();
            adp = new SqlDataAdapter(sql, Con);

            adp.Fill(dt);
            return dt;
        }

        
        public Object getDbValue(string Query)
        {
            ConectarDB();
            SqlCommand cmd = new SqlCommand(Query, Con);
            Object returnValue;
            return returnValue = cmd.ExecuteScalar();
        }

        
        public SqlDataReader getReader(string Comando)
        {
            ConectarDB();
            SqlCommand command = new SqlCommand(Comando, Con);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    }

}