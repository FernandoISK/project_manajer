using Project_Manager.Services.BO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.DAO
{
    public class TblJuntasDAO
    {
		SqlConnection con = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;
		public int Crear(object obj)
		{

			TblEmpleadoBO datos = (TblEmpleadoBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "Insert into TblEmpleado(NombreEmpleado ,ApellidoPEmpleado ,ApellidoMEmpleado, TelefonoEmpleado  ,Nacimiento ,GeneroEmpleado ,FKUsuario)" +
			"Values(@NombreEmpleado ,@ApellidoPEmpleado, @ApellidoMEmpleado ,@TelefonoEmpleado ,@Nacimiento ,@GeneroEmpleado ,@FKUsuario)";

			cmd.Parameters.AddWithValue("@NombreEmpleado", datos.NombreEmpleado);
			cmd.Parameters.AddWithValue("@ApellidoPEmpleado", datos.ApellidoPEmpleado);
			cmd.Parameters.AddWithValue("@TelefonoEmpleado", datos.TelefonoEmpleado);
			cmd.Parameters.AddWithValue("@Nacimiento", datos.Nacimiento);
			cmd.Parameters.AddWithValue("@GeneroEmpleado", datos.GeneroEmpleado);
			cmd.Parameters.AddWithValue("@FKUsuario", datos.FKUsuario);
			cmd.Parameters.AddWithValue("@ApellidoMEmpleado", datos.ApellidoMEmpleado);
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
