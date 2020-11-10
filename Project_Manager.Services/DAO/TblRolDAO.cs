using Project_Manager.Services.BO;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
    public class TblRolDAO
{
	SqlConnection con = new SqlConnection();
	SqlCommand cmd = new SqlCommand();
	Conexion con2 = new Conexion();
	string sql;

		public int Crear(object obj)
	{

		TblRolBO datos = (TblRolBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "Insert into TblRol(Rol)"+
		"Values(@Rol)";
		cmd.Parameters.Add("@IDRol", SqlDbType.Int);
		cmd.Parameters.Add("@Rol", SqlDbType.VarChar);

		cmd.Parameters["@IDRol"].Value = datos.IDRol;
		cmd.Parameters["@Rol"].Value = datos.Rol;
		cmd.CommandText = sql;


		int i = cmd.ExecuteNonQuery();
		cmd.Parameters.Clear();

		if(i <= 0)
		{
			return 0;
		}
		return 1;
	}


		public int Modificar(object obj)
	{

		TblRolBO datos = (TblRolBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "update TblRol"+
		" set "+
		"Rol = @Rol"+
		" where IDRol = @IDRol";

		cmd.Parameters.Add("@IDRol", SqlDbType.Int);
		cmd.Parameters.Add("@Rol", SqlDbType.VarChar);

		cmd.Parameters["@IDRol"].Value = datos.IDRol;
		cmd.Parameters["@Rol"].Value = datos.Rol;

		cmd.CommandText = sql;

		int i = cmd.ExecuteNonQuery();
		cmd.Parameters.Clear();

		if(i <= 0)
		{
			return 0;
		}
		return 1;
	}


		public int Eliminar(object obj)
	{
		TblRolBO datos = (TblRolBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "DELETE FROM TblRol where IDRol = @IDRol";
		cmd.Parameters.Add("@IDRol", SqlDbType.Int);
		cmd.Parameters["@IDRol"].Value = datos.IDRol;
		cmd.CommandText = sql;

		int i = cmd.ExecuteNonQuery();
		cmd.Parameters.Clear();

		if(i <= 0)
		{
			return 0;
		}
		return 1;
	}


		public DataSet devuelveAlumno(object obj)
	{
		string cadenaWhere = "";
		bool edo = false;
		TblRolBO data = (TblRolBO)obj;
		SqlCommand cmd = new SqlCommand();
		DataSet ds = new DataSet();
		SqlDataAdapter da = new SqlDataAdapter();
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();

		if (data.IDRol > 0)
		{
			cadenaWhere = cadenaWhere + " IDRol = @IDRol and";
			cmd.Parameters.Add("@IDRol", SqlDbType.Int);
			cmd.Parameters["@IDRol"].Value = data.IDRol;
			edo = true;
		}
		if (data.Rol !=null)
		{
			cadenaWhere = cadenaWhere + " Rol = @Rol and";
			cmd.Parameters.Add("@Rol", SqlDbType.VarChar);
			cmd.Parameters["@Rol"].Value = data.Rol;
			edo = true;
		}

		if (edo == true)
		{
			 cadenaWhere = " WHERE " +cadenaWhere.Remove(cadenaWhere.Length - 3, 3);
		}
		sql = "SELECT * FROM TblRol"  + cadenaWhere;
		cmd.CommandText = sql;
		da.SelectCommand = cmd;
		da.Fill(ds);
		con2.CerrarConexion();
		return ds;
	}


		public DataTable ListarTabla()
	{
		sql = "Select * from TblRol";
		SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
		DataTable tabla = new DataTable();
		da.Fill(tabla);
		return tabla;
	}

	}
}
