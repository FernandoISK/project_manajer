using Project_Manager.Services.BO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
	public class TblAdministradorDAO
	{
		SqlConnection con = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;

		public int Crear(object obj)
		{

			TblAdministradorBO datos = (TblAdministradorBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			string sql = "Insert into TblAdministrador(NombreAdmin,ApellidoPAdmin,ApellidoMAdmin,CorreoAdmin,ContraAdmin,FKUsuario,FKRol)" +
			"Values(@NombreAdmin,@ApellidoPAdmin,@ApellidoMAdmin,@CorreoAdmin,@ContraAdmin,@FKUsuario,@FKRol)";

			cmd.Parameters.AddWithValue("@NombreAdmin", datos.NombreAdmin);
			cmd.Parameters.AddWithValue("@ApellidoPAdmin", datos.ApellidoPAdmin);
			cmd.Parameters.AddWithValue("@ApellidoMAdmin", datos.ApellidoMAdmin);

			cmd.Parameters.AddWithValue("@CorreoAdmin", datos.CorreoAdmin);
			cmd.Parameters.AddWithValue("@ContraAdmin", datos.ContraAdmin);
			cmd.Parameters.AddWithValue("@FKUsuario", datos.FKUsuario);
			cmd.Parameters.AddWithValue("@FKRol", datos.FKRol);

			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}

		public List<TblAdministradorBO> ListarTabla()
		{
			List<TblAdministradorBO> lista = new List<TblAdministradorBO>();
			sql = "select * from TblAdministrador where Estatus = 0;";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblAdministradorBO obj = new TblAdministradorBO();
					obj.IDAdmin = int.Parse(row["IDAdmin"].ToString());
					obj.NombreAdmin = row["NombreAdmin"].ToString();
					obj.ApellidoPAdmin = row["ApellidoPAdmin"].ToString();
					obj.ApellidoMAdmin = row["ApellidoMAdmin"].ToString();
					obj.Estatus = int.Parse(row["Estatus"].ToString());
					obj.CorreoAdmin = row["CorreoAdmin"].ToString();
					obj.ContraAdmin = row["ContraAdmin"].ToString();
					obj.FKUsuario = row["FKUsuario"].ToString();
					obj.FKRol = row["FKRol"].ToString();
					lista.Add(obj);
				}
			}
			return lista;
		}

		public int Eliminar(int id, int status)
		{
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "UPDATE TblAdministrador SET Estatus = @Estatus WHERE IDAdmin = @IDAdmin;";
			cmd.Parameters.AddWithValue("@Estatus", status);
			cmd.Parameters.AddWithValue("@IDAdmin", id);
			cmd.CommandText = sql;

			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}



		public int Modificar(object obj)
		{

			TblAdministradorBO datos = (TblAdministradorBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "update TblAdministrador" +
			" set " +
			"NombreAdmin = @NombreAdmin," +
			"ApellidoAdmin = @ApellidoAdmin," +
			"FKRol = @FKRol," +
			"FKCuenta = @FKCuenta" +
			" where IDAdmin = @IDAdmin";

			cmd.Parameters.Add("@IDAdmin", SqlDbType.Int);
			cmd.Parameters.Add("@NombreAdmin", SqlDbType.VarChar);
			cmd.Parameters.Add("@ApellidoAdmin", SqlDbType.VarChar);
			cmd.Parameters.Add("@FKRol", SqlDbType.Int);
			cmd.Parameters.Add("@FKCuenta", SqlDbType.Int);

			cmd.Parameters["@IDAdmin"].Value = datos.IDAdmin;
			cmd.Parameters["@NombreAdmin"].Value = datos.NombreAdmin;
			cmd.Parameters["@ApellidoAdmin"].Value = datos.ApellidoMAdmin;
			//cmd.Parameters["@FKCuenta"].Value = datos.OTblCuentaBO.IDCuenta;

			cmd.CommandText = sql;

			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
		public DataSet devuelveAlumno(object obj)
		{
			string cadenaWhere = "";
			bool edo = false;
			TblAdministradorBO data = (TblAdministradorBO)obj;
			SqlCommand cmd = new SqlCommand();
			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter();
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();


			if (edo == true)
			{
				cadenaWhere = " WHERE " + cadenaWhere.Remove(cadenaWhere.Length - 3, 3);
			}
			sql = "SELECT * FROM TblAdministrador" + cadenaWhere;
			cmd.CommandText = sql;
			da.SelectCommand = cmd;
			da.Fill(ds);
			con2.CerrarConexion();
			return ds;
		}
		//public DataTable ListarTabla()
		//{
		//	sql = "Select * from TblAdministrador";
		//	SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
		//	DataTable tabla = new DataTable();
		//	da.Fill(tabla);
		//	return tabla;
		//}
	}
}
