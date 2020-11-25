using Project_Manager.Services.BO;
using System.Collections.Generic;
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
			sql = "Insert into TblClientes(NombreEmpresa ,NombreRepresentante ,ApellidoMRepresentante ,ApellidoPRepresentante ,TelefonoRepresentante ,FKUsuario)" +
			"Values(@NombreEmpresa ,@NombreRepresentante ,@ApellidoMRepresentante ,@ApellidoPRepresentante ,@TelefonoRepresentante ,@FKUsuario);";
			cmd.Parameters.AddWithValue("@NombreEmpresa", datos.NombreEmpresa);
			cmd.Parameters.AddWithValue("@NombreRepresentante", datos.NombreRepresentante);
			cmd.Parameters.AddWithValue("@ApellidoMRepresentante", datos.ApellidoMRepresentante);
			cmd.Parameters.AddWithValue("@ApellidoPRepresentante", datos.ApellidoPRepresentante);
			cmd.Parameters.AddWithValue("@TelefonoRepresentante", datos.TelefonoRepresentante);
			cmd.Parameters.AddWithValue("@FKUsuario", datos.FKUsuario);
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

			TblClienteBO datos = (TblClienteBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "update TblClientes set NombreRepresentante = @NombreRepresentante, ApellidoMRepresentante = @ApellidoMRepresentante, ApellidoPRepresentante = @ApellidoPRepresentante," +
			"TelefonoRepresentante = @TelefonoRepresentante where IDCliente = @IDCliente";
			cmd.Parameters.AddWithValue("@IDCliente", datos.IDCliente);
			cmd.Parameters.AddWithValue("@NombreRepresentante", datos.NombreRepresentante);
			cmd.Parameters.AddWithValue("@ApellidoMRepresentante", datos.ApellidoMRepresentante);
			cmd.Parameters.AddWithValue("@ApellidoPRepresentante", datos.ApellidoPRepresentante);
			cmd.Parameters.AddWithValue("@TelefonoRepresentante", datos.TelefonoRepresentante);
			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}


		public int Eliminar(int id, int status)
		{
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "update TblClientes set Estatus = @Estatus where IDCliente = @IDCliente";
			cmd.Parameters.AddWithValue("@IDCliente", id);
			cmd.Parameters.AddWithValue("@Estatus", status);
			cmd.CommandText = sql;

			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}


		//public DataSet devuelveAlumno(object obj)
		//{
		//	string cadenaWhere = "";
		//	bool edo = false;
		//	TblClienteBO data = (TblClienteBO)obj;
		//	SqlCommand cmd = new SqlCommand();
		//	DataSet ds = new DataSet();
		//	SqlDataAdapter da = new SqlDataAdapter();
		//	cmd.Connection = con2.establecerconexion();
		//	con2.AbrirConexion();

		//	if (data.IDCliente > 0)
		//	{
		//		cadenaWhere = cadenaWhere + " IDCliente = @IDCliente and";
		//		cmd.Parameters.Add("@IDCliente", SqlDbType.Int);
		//		cmd.Parameters["@IDCliente"].Value = data.IDCliente;
		//		edo = true;
		//	}
		//	if (data.NombreCliente != null)
		//	{
		//		cadenaWhere = cadenaWhere + " NombreCliente = @NombreCliente and";
		//		cmd.Parameters.Add("@NombreCliente", SqlDbType.VarChar);
		//		cmd.Parameters["@NombreCliente"].Value = data.NombreCliente;
		//		edo = true;
		//	}
		//	if (data.ApellidoCliente != null)
		//	{
		//		cadenaWhere = cadenaWhere + " ApellidoCliente = @ApellidoCliente and";
		//		cmd.Parameters.Add("@ApellidoCliente", SqlDbType.VarChar);
		//		cmd.Parameters["@ApellidoCliente"].Value = data.ApellidoCliente;
		//		edo = true;
		//	}
		//	if (data.TelefonoCliente != null)
		//	{
		//		cadenaWhere = cadenaWhere + " TelefonoCliente = @TelefonoCliente and";
		//		cmd.Parameters.Add("@TelefonoCliente", SqlDbType.VarChar);
		//		cmd.Parameters["@TelefonoCliente"].Value = data.TelefonoCliente;
		//		edo = true;
		//	}
		//	if (data.GeneroCliente.ToString() != "\0")
		//	{
		//		cadenaWhere = cadenaWhere + " GeneroCliente = @GeneroCliente and";
		//		cmd.Parameters.Add("@GeneroCliente", SqlDbType.Char);
		//		cmd.Parameters["@GeneroCliente"].Value = data.GeneroCliente;
		//		edo = true;
		//	}
		//	if (data.EmpresaCliente != null)
		//	{
		//		cadenaWhere = cadenaWhere + " EmpresaCliente = @EmpresaCliente and";
		//		cmd.Parameters.Add("@EmpresaCliente", SqlDbType.VarChar);
		//		cmd.Parameters["@EmpresaCliente"].Value = data.EmpresaCliente;
		//		edo = true;
		//	}
		//	if (data.RepresentanteCliente != null)
		//	{
		//		cadenaWhere = cadenaWhere + " RepresentanteCliente = @RepresentanteCliente and";
		//		cmd.Parameters.Add("@RepresentanteCliente", SqlDbType.VarChar);
		//		cmd.Parameters["@RepresentanteCliente"].Value = data.RepresentanteCliente;
		//		edo = true;
		//	}

		//	if (edo == true)
		//	{
		//		cadenaWhere = " WHERE " + cadenaWhere.Remove(cadenaWhere.Length - 3, 3);
		//	}
		//	sql = "SELECT * FROM TblCliente" + cadenaWhere;
		//	cmd.CommandText = sql;
		//	da.SelectCommand = cmd;
		//	da.Fill(ds);
		//	con2.CerrarConexion();
		//	return ds;
		//}


		public List<TblClienteBO> ListarTabla()
		{
			List<TblClienteBO> lista = new List<TblClienteBO>();
			sql = "select a.*, b.Correo from TblClientes as a inner Join tblCuenta as b on a.FKUsuario = b.Usuario where a.Estatus = 0;";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblClienteBO obj = new TblClienteBO();
					obj.IDCliente = int.Parse(row["IDCliente"].ToString());
					obj.NombreEmpresa = row["NombreEmpresa"].ToString();
					obj.NombreRepresentante = row["NombreRepresentante"].ToString();
					obj.ApellidoMRepresentante = row["ApellidoMRepresentante"].ToString();
					obj.ApellidoPRepresentante = row["ApellidoPRepresentante"].ToString();
					obj.TelefonoRepresentante = row["TelefonoRepresentante"].ToString();
					obj.Estatus = int.Parse(row["Estatus"].ToString());
					obj.FKUsuario = row["FKUsuario"].ToString();
					obj.correo = row["Correo"].ToString();
					lista.Add(obj);
				}
			}
			return lista;
		}

	}
}
