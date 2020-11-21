using Project_Manager.Services.BO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
	public class TblEmpleadoDAO
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


		public int Modificar(TblEmpleadoBO datos)
		{
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "update TblEmpleado set NombreEmpleado = @NombreEmpleado ,TelefonoEmpleado = @TelefonoEmpleado where IDEmpleado = @IDEmpleado;";
			cmd.Parameters.AddWithValue("@IDEmpleado", datos.IDEmpleado);
			cmd.Parameters.AddWithValue("@NombreEmpleado", datos.NombreEmpleado);
			cmd.Parameters.AddWithValue("@TelefonoEmpleado", datos.TelefonoEmpleado);
			cmd.CommandText = sql;

			int i = cmd.ExecuteNonQuery();
			con2.CerrarConexion();
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
			sql = "update TblEmpleado set Estatus = @Estatus where IDEmpleado = @IDEmpleado;";
			cmd.Parameters.AddWithValue("@Estatus", status);
			cmd.Parameters.AddWithValue("@IDEmpleado", id);
			cmd.CommandText = sql;

            int i = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            if (i <= 0)
            {
                return 0;
            }
            return 1;
        }


        public DataSet devuelveEmpleado(object obj)
		{
			string cadenaWhere = "";
			bool edo = false;
			TblEmpleadoBO data = (TblEmpleadoBO)obj;
			SqlCommand cmd = new SqlCommand();
			DataSet ds = new DataSet();
			SqlDataAdapter da = new SqlDataAdapter();
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();

			if (data.IDEmpleado > 0)
			{
				cadenaWhere = cadenaWhere + " IDEmpleado = @IDEmpleado and";
				cmd.Parameters.AddWithValue("@IDEmpleado", data.IDEmpleado);
				edo = true;
			}
			if (data.NombreEmpleado != null)
			{
				cadenaWhere = cadenaWhere + " NombreEmpleado = @NombreEmpleado and";
				cmd.Parameters.AddWithValue("@NombreEmpleado", data.NombreEmpleado);
				edo = true;
			}
			if (data.ApellidoPEmpleado != null)
			{
				cadenaWhere = cadenaWhere + " ApellidoPEmpleado = @ApellidoPEmpleado and";
				cmd.Parameters.AddWithValue("@ApellidoPEmpleado", data.ApellidoPEmpleado);
				edo = true;
			}
			if (data.ApellidoMEmpleado != null)
			{
				cadenaWhere = cadenaWhere + " ApellidoMEmpleado = @ApellidoMEmpleado and";
				cmd.Parameters.AddWithValue("@ApellidoMEmpleado", data.ApellidoMEmpleado);
				edo = true;
			}
			if (data.TelefonoEmpleado != null)
			{
				cadenaWhere = cadenaWhere + " TelefonoEmpleado = @TelefonoEmpleado and";
				cmd.Parameters.AddWithValue("@TelefonoEmpleado", data.TelefonoEmpleado);
				edo = true;
			}
			if (data.Nacimiento != null)
			{
				cadenaWhere = cadenaWhere + " Nacimiento = @Nacimiento and";
				cmd.Parameters.AddWithValue("@Nacimiento", data.Nacimiento);
				edo = true;
			}
			if (data.Estatus > 0)
			{
				cadenaWhere = cadenaWhere + " Estatus = @Estatus and";
				cmd.Parameters.AddWithValue("@Estatus", data.Estatus);
				edo = true;
			}
			if (data.GeneroEmpleado.ToString() != "\0")
			{
				cadenaWhere = cadenaWhere + " GeneroEmpleado = @GeneroEmpleado and";
				cmd.Parameters.AddWithValue("@GeneroEmpleado", data.GeneroEmpleado);
				edo = true;
			}
			if (data.FKUsuario != null)
			{
				cadenaWhere = cadenaWhere + " FKUsuario = @FKUsuario and";
				cmd.Parameters.AddWithValue("@FKUsuario", data.FKUsuario);
				edo = true;
			}

			if (edo == true)
			{
				cadenaWhere = " WHERE " + cadenaWhere.Remove(cadenaWhere.Length - 3, 3);
			}
			sql = "SELECT * FROM TblEmpleado" + cadenaWhere;
			cmd.CommandText = sql;
			da.SelectCommand = cmd;
			da.Fill(ds);
			con2.CerrarConexion();
			return ds;
		}


		public List<TblEmpleadoBO> ListarTabla()
		{
			List<TblEmpleadoBO> lista = new List<TblEmpleadoBO>();
			sql = "select a.*, b.Correo from tblEmpleado as a inner Join tblCuenta as b on a.FKUsuario = b.Usuario where a.Estatus = 0;";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
            {
				foreach (DataRow row in tabla.Rows)
				{
					TblEmpleadoBO obj = new TblEmpleadoBO();
					obj.IDEmpleado = int.Parse(row["IDEmpleado"].ToString());
					obj.NombreEmpleado = row["NombreEmpleado"].ToString();
					obj.ApellidoPEmpleado = row["ApellidoPEmpleado"].ToString();
					obj.ApellidoMEmpleado = row["ApellidoMEmpleado"].ToString();
					obj.TelefonoEmpleado = row["TelefonoEmpleado"].ToString();
					obj.Nacimiento = row["Nacimiento"].ToString();
					obj.Estatus = int.Parse(row["Estatus"].ToString());
					obj.GeneroEmpleado = row["GeneroEmpleado"].ToString();
					obj.FKUsuario = row["FKUsuario"].ToString();
					obj.correo = row["Correo"].ToString();
					lista.Add(obj);
				}				
			}
			return lista;
		}

	}
}
