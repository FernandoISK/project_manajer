using Project_Manager.Services.BO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.DAO
{
    public class TblIncidenciasDAO
    {
		SqlConnection con = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;

		public int Crear(object obj)
		{

			TblIncidenciasBO datos = (TblIncidenciasBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = " INSERT INTO TblIncidencias(Titulo,Descripcion,Imagen,FKProyecto) VALUES(@Titulo,@Descripcion,@Imagen,@FKProyecto)";

			cmd.Parameters.AddWithValue("@Titulo", datos.Titulo);
			cmd.Parameters.AddWithValue("@Descripcion", datos.Descripcion);
			cmd.Parameters.AddWithValue("@Imagen", datos.Imagen);
			cmd.Parameters.AddWithValue("@FKProyecto", datos.FKProyecto);
			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
	}
}
