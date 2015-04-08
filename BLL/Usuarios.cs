using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string Clave { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool EsNulo { get; set; }


        public Usuarios()
        {

        }

        ConexionDb Conexion = new ConexionDb();

        public bool Insertar()
        {
            string sql = "INSERT INTO Usuarios(Alias,Clave,Nombres,Apellidos )" +
               "Values('"+Alias+"','"+Clave+"','"+Nombres+"','"+Apellidos+"')";
            return Conexion.EjecutarComando(sql);
        }

        public bool Modificar()
        {
            string sql = "UPDATE Usuarios set Alias = '" + Alias + "' , Clave = '" + Clave + "', Nombres = '"+Nombres+"', Apellidos = '"+Apellidos+"' WHERE Id = "+Id;
                return Conexion.EjecutarComando(sql);
        }

        public bool Eliminar(int prmIdUsuario)
        {
           return Conexion.EjecutarComando("Delete Usuarios WHERE Id =" + prmIdUsuario);
        }

        public bool Buscar(int prmUsuario)
        {
            SqlDataReader dtr;
            bool Retorno = false;

            dtr = Conexion.getReader("SELECT * FROM Usuarios WHERE Id = " + prmUsuario);

            while (dtr.Read())
            {
                Id = (Int32)dtr["Id"];
                Alias = (String)dtr["Alias"];
                Clave = (String)dtr["Clave"];
                Nombres = (String)dtr["Nombres"];
                Apellidos = (String)dtr["Apellidos"];
                EsNulo = (bool)dtr["EsNulo"];
                Retorno = true;
            }

            dtr.Close();
            return Retorno;
        }

        public static DataTable Listar(string Campos ,string FiltroWhere)
        {
            ConexionDb Conexion = new ConexionDb();
            return Conexion.getData("SELECT "+ Campos +" FROM Usuarios WHERE " + FiltroWhere);
        }

        public int Autenticar(string pAlias, string pClave)
        {
            return Convert.ToInt32(Conexion.getDbValue("SELECT COUNT(Id) from Usuarios where Alias = '" + pAlias +"' and Clave = '"+ pClave +"' and EsNulo = 0"));
        }


    }
}