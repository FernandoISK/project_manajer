using Project_Manager.Services.BO;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
    public class TblClienteDAO
{
	SqlConnection con = new SqlConnection();
	SqlCommand cmd = new SqlCommand();
	Conexion con2 = new Conexion();
	string sql;

		public int Crear(object obj)
	{

		TblClienteBO datos = (TblClienteBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "Insert into TblCliente(NombreCliente ,ApellidoCliente ,TelefonoCliente ,GeneroCliente ,EmpresaCliente ,RepresentanteCliente ,FKRol ,FKCuenta)"+
		"Values(@NombreCliente ,@ApellidoCliente ,@TelefonoCliente ,@GeneroCliente ,@EmpresaCliente ,@RepresentanteCliente ,@FKRol ,@FKCuenta)";
		cmd.Parameters.Add("@IDCliente", SqlDbType.Int);
		cmd.Parameters.Add("@NombreCliente", SqlDbType.VarChar);
		cmd.Parameters.Add("@ApellidoCliente", SqlDbType.VarChar);
		cmd.Parameters.Add("@TelefonoCliente", SqlDbType.VarChar);
		cmd.Parameters.Add("@GeneroCliente", SqlDbType.Char);
		cmd.Parameters.Add("@EmpresaCliente", SqlDbType.VarChar);
		cmd.Parameters.Add("@RepresentanteCliente", SqlDbType.VarChar);
		cmd.Parameters.Add("@FKRol", SqlDbType.Int);
		cmd.Parameters.Add("@FKCuenta", SqlDbType.Int);

		cmd.Parameters["@IDCliente"].Value = datos.IDCliente;
		cmd.Parameters["@NombreCliente"].Value = datos.NombreCliente;
		cmd.Parameters["@ApellidoCliente"].Value = datos.ApellidoCliente;
		cmd.Parameters["@TelefonoCliente"].Value = datos.TelefonoCliente;
		cmd.Parameters["@GeneroCliente"].Value = datos.GeneroCliente;
		cmd.Parameters["@EmpresaCliente"].Value = datos.EmpresaCliente;
		cmd.Parameters["@RepresentanteCliente"].Value = datos.RepresentanteCliente;
		cmd.Parameters["@FKCuenta"].Value = datos.OTblCuentaBO.IDCuenta;
		cmd.Parameters["@FKRol"].Value = datos.OTblRolBO.IDRol;
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

		TblClienteBO datos = (TblClienteBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "update TblCliente"+
		" set "+
		"NombreCliente = @NombreCliente,"+
		"ApellidoCliente = @ApellidoCliente,"+
		"TelefonoCliente = @TelefonoCliente,"+
		"GeneroCliente = @GeneroCliente,"+
		"EmpresaCliente = @EmpresaCliente,"+
		"RepresentanteCliente = @RepresentanteCliente,"+
		"FKRol = @FKRol,"+
		"FKCuenta = @FKCuenta"+
		" where IDCliente = @IDCliente";

		cmd.Parameters.Add("@IDCliente", SqlDbType.Int);
		cmd.Parameters.Add("@NombreCliente", SqlDbType.VarChar);
		cmd.Parameters.Add("@ApellidoCliente", SqlDbType.VarChar);
		cmd.Parameters.Add("@TelefonoCliente", SqlDbType.VarChar);
		cmd.Parameters.Add("@GeneroCliente", SqlDbType.Char);
		cmd.Parameters.Add("@EmpresaCliente", SqlDbType.VarChar);
		cmd.Parameters.Add("@RepresentanteCliente", SqlDbType.VarChar);
		cmd.Parameters.Add("@FKRol", SqlDbType.Int);
		cmd.Parameters.Add("@FKCuenta", SqlDbType.Int);

		cmd.Parameters["@IDCliente"].Value = datos.IDCliente;
		cmd.Parameters["@NombreCliente"].Value = datos.NombreCliente;
		cmd.Parameters["@ApellidoCliente"].Value = datos.ApellidoCliente;
		cmd.Parameters["@TelefonoCliente"].Value = datos.TelefonoCliente;
		cmd.Parameters["@GeneroCliente"].Value = datos.GeneroCliente;
		cmd.Parameters["@EmpresaCliente"].Value = datos.EmpresaCliente;
		cmd.Parameters["@RepresentanteCliente"].Value = datos.RepresentanteCliente;
		cmd.Parameters["@FKCuenta"].Value = datos.OTblCuentaBO.IDCuenta;
		cmd.Parameters["@FKRol"].Value = datos.OTblRolBO.IDRol;

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
		TblClienteBO datos = (TblClienteBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "DELETE FROM TblCliente where IDCliente = @IDCliente";
		cmd.Parameters.Add("@IDCliente", SqlDbType.Int);
		cmd.Parameters["@IDCliente"].Value = datos.IDCliente;
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
		TblClienteBO data = (TblClienteBO)obj;
		SqlCommand cmd = new SqlCommand();
		DataSet ds = new DataSet();
		SqlDataAdapter da = new SqlDataAdapter();
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();

		if (data.IDCliente > 0)
		{
			cadenaWhere = cadenaWhere + " IDCliente = @IDCliente and";
			cmd.Parameters.Add("@IDCliente", SqlDbType.Int);
			cmd.Parameters["@IDCliente"].Value = data.IDCliente;
			edo = true;
		}
		if (data.NombreCliente !=null)
		{
			cadenaWhere = cadenaWhere + " NombreCliente = @NombreCliente and";
			cmd.Parameters.Add("@NombreCliente", SqlDbType.VarChar);
			cmd.Parameters["@NombreCliente"].Value = data.NombreCliente;
			edo = true;
		}
		if (data.ApellidoCliente !=null)
		{
			cadenaWhere = cadenaWhere + " ApellidoCliente = @ApellidoCliente and";
			cmd.Parameters.Add("@ApellidoCliente", SqlDbType.VarChar);
			cmd.Parameters["@ApellidoCliente"].Value = data.ApellidoCliente;
			edo = true;
		}
		if (data.TelefonoCliente !=null)
		{
			cadenaWhere = cadenaWhere + " TelefonoCliente = @TelefonoCliente and";
			cmd.Parameters.Add("@TelefonoCliente", SqlDbType.VarChar);
			cmd.Parameters["@TelefonoCliente"].Value = data.TelefonoCliente;
			edo = true;
		}
		if (data.GeneroCliente.ToString() !="\0")
		{
			cadenaWhere = cadenaWhere + " GeneroCliente = @GeneroCliente and";
			cmd.Parameters.Add("@GeneroCliente", SqlDbType.Char);
			cmd.Parameters["@GeneroCliente"].Value = data.GeneroCliente;
			edo = true;
		}
		if (data.EmpresaCliente !=null)
		{
			cadenaWhere = cadenaWhere + " EmpresaCliente = @EmpresaCliente and";
			cmd.Parameters.Add("@EmpresaCliente", SqlDbType.VarChar);
			cmd.Parameters["@EmpresaCliente"].Value = data.EmpresaCliente;
			edo = true;
		}
		if (data.RepresentanteCliente !=null)
		{
			cadenaWhere = cadenaWhere + " RepresentanteCliente = @RepresentanteCliente and";
			cmd.Parameters.Add("@RepresentanteCliente", SqlDbType.VarChar);
			cmd.Parameters["@RepresentanteCliente"].Value = data.RepresentanteCliente;
			edo = true;
		}

		if (edo == true)
		{
			 cadenaWhere = " WHERE " +cadenaWhere.Remove(cadenaWhere.Length - 3, 3);
		}
		sql = "SELECT * FROM TblCliente"  + cadenaWhere;
		cmd.CommandText = sql;
		da.SelectCommand = cmd;
		da.Fill(ds);
		con2.CerrarConexion();
		return ds;
	}


		public DataTable ListarTabla()
	{
		sql = "Select * from TblCliente";
		SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
		DataTable tabla = new DataTable();
		da.Fill(tabla);
		return tabla;
	}

	}
}
