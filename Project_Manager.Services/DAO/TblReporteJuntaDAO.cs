using Project_Manager.Services.BO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.DAO
{
    public class TblReporteJuntaDAO
    {
		public int Crear(object obj)
		{
			SqlConnection con = new SqlConnection();
			SqlCommand cmd = new SqlCommand();
			Conexion con2 = new Conexion();
			string sql;

			TblReporteJuntaBO datos = (TblReporteJuntaBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "INSERT INTO TblReporteJunta(Motivo,Descripcion,FKEmpleado,FKJunta) VALUES(@Motivo,@Descripcion,@FKEmpleado,@FKJunta);";

			cmd.Parameters.AddWithValue("@Motivo", datos.Motivo);
			cmd.Parameters.AddWithValue("@Descripcion", datos.Descripcion);
			cmd.Parameters.AddWithValue("@FKEmpleado", datos.FKEmpleado);
			cmd.Parameters.AddWithValue("@FKJunta", datos.FKJunta);
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
