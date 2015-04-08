using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DAL;

namespace BLL
{
    public class CalzadosDetalle
    {
        public int IdCalzadoDetalle { get; set; }
        public int IdTipo { get; set; }
        public int IdCalzado { get; set; }
        public int IdColor { get; set; }
        public int IdSize { get; set; }
        public int Existencia { get; set; }
        public int IdClasificacion { get; set; }
        public string Imagen { get; set; }
        public Double Precio { get; set; }
        public Double Costo { get; set; }
        public bool EsNulo { get; set; }

        ConexionDb Conexion = new ConexionDb();

        public CalzadosDetalle()
        {

        }

        public CalzadosDetalle(int IdTipo, int IdCalzado, int IdColor, int IdSize, int Existencia, int IdClasificacion, string Imagen, float Precio, float Costo)
        {
            this.IdTipo = IdTipo;
            this.IdCalzado = IdCalzado;
            this.IdColor = IdColor;
            this.IdSize = IdSize;
            this.Existencia = Existencia;
            this.IdClasificacion = IdClasificacion;
            this.Imagen = Imagen;
            this.Precio = Precio;
            this.Costo = Costo;    
        }

        public bool Insertar()
        {
            return Conexion.EjecutarComando("INSERT INTO CalzadoDetalle(IdTipo, IdCalzado, IdColor, IdSize, IdClasificacion, Imagen, Existencia, Costo , Precio)"
           + "VALUES('" + IdTipo + "','" + IdCalzado + "','" + IdColor + "','" + IdSize + "','" + IdClasificacion + "','" + Imagen + "','" + Existencia + "','" + Costo + "', '" + Precio + "')");
        }

        public bool Modificar()
        {
            return Conexion.EjecutarComando("UPDATE CalzadoDetalle SET IdTipo = '" + IdTipo + "', IdCalzado = '" + IdCalzado + "',IdColor = '" + IdColor +
                "',IdSize = '" + IdSize + "',IdClasificacion = '" + IdClasificacion + "',Imagen = '" + Imagen + "',Existencia = '" + Existencia + "', Costo = '" + Costo + "', Precio = '" + Precio + "' WHERE IdCalzadoDetalle = " + IdCalzadoDetalle);
        }

        public bool Eliminar(int prmIdCalzadoDetalle)
        {
            return Conexion.EjecutarComando("UPDATE CalzadoDetalle SET esNulo = 1 WHERE IdCalzadoDetalle = " + prmIdCalzadoDetalle);
        }

        public static bool ReducirExistencia(int IdCalzadoDetalle, int Existencia)
        {
            ConexionDb Conexion = new ConexionDb();
            return Conexion.EjecutarComando("UPDATE CalzadoDetalle SET Existencia -= '" + Existencia + "' WHERE IdCalzadoDetalle = " + IdCalzadoDetalle);
        }

        public bool Buscar(int IdCalzadoDetalle)
        {
            SqlDataReader dtr;
            bool Retorno = false;
            dtr = Conexion.getReader("SELECT * FROM CalzadoDetalle WHERE IdCalzadoDetalle =" + IdCalzadoDetalle);

            while (dtr.Read())
            {
                IdCalzadoDetalle = (Int32)dtr["IdCalzadoDetalle"];
                IdCalzado = (Int32)dtr["IdCalzado"];
                IdColor = (Int32)dtr["IdColor"];
                IdSize = (Int32)dtr["IdSize"];
                IdTipo = (Int32)dtr["IdTipo"];                
                Imagen = (String)dtr["Imagen"];
                Existencia = (Int32)dtr["Existencia"];
                Precio = (Double)dtr["Precio"];
                Costo = (Double)dtr["Costo"];
                IdClasificacion = (Int32)dtr["IdClasificacion"];
                EsNulo = (bool)dtr["EsNulo"];
                Retorno = true;
            }

            dtr.Close();
            return Retorno;
        }

        public static DataTable Listar(string Campos, string FiltroWhere, string OrderBy)
        {
            ConexionDb Conexion = new ConexionDb();
            return Conexion.getData("SELECT " + Campos + " FROM CalzadoDetalle WHERE " + FiltroWhere + " Order By " + OrderBy);
        }

        public DataTable CargarTodos()
        {
            return Conexion.getData("SELECT *, co.Descripcion as Color, m.Descripcion as Marca FROM CalzadoDetalle d INNER JOIN Calzados c ON c.IdCalzado = d.IdCalzado INNER JOIN Marca m ON c.IdMarca = m.IdMarca INNER JOIN Color co ON co.IdColor = d.IdColor WHERE c.esNulo = 0 ORDER BY IdCalzadoDetalle DESC ");
        }

        public DataTable CargarTodos(int Clasificacion)
        {
            return Conexion.getData("SELECT *, co.Descripcion as Color, m.Descripcion as Marca FROM CalzadoDetalle d INNER JOIN Calzados c ON c.IdCalzado = d.IdCalzado INNER JOIN Marca m ON c.IdMarca = m.IdMarca INNER JOIN Color co ON co.IdColor = d.IdColor WHERE c.esNulo = 0 and d.IdClasificacion = " + Clasificacion + " ORDER BY IdCalzadoDetalle DESC ");
        }
    }
}