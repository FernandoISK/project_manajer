using Project_Manager.Services.BO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
    public class TblRequisitosDAO
	{
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;

		public int Crear(object obj)
		{

			TblRequisitosBO datos = (TblRequisitosBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = " INSERT INTO TblRequisitos(Titulo,Descripcion,Imagen,FKProyecto) VALUES(@Titulo,@Descripcion,@Imagen,@FKProyecto)";

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
		public List<TblRequisitosBO> GetMyRequisitos(int id)
		{
			List<TblRequisitosBO> lista = new List<TblRequisitosBO>();
			sql = " SELECT a.*, b.NombreProyecto FROM TblRequisitos a INNER JOIN TblProyectos b on a.FKProyecto = b.Folio INNER JOIN TblProyectoEmpleado c ON b.Folio = c.FKProyecto Where c.FKEmpleado = " + id + "; ";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblRequisitosBO obj = new TblRequisitosBO();
					byte[] imagen = null;
					try
					{
						imagen = (byte[])row["Imagen"];
					}
					catch
					{ }
					obj.IdRequisito = int.Parse(row["IdRequisito"].ToString());
					obj.Titulo = row["Titulo"].ToString();
					obj.Descripcion = row["Descripcion"].ToString();
					obj.FKProyecto = row["FKProyecto"].ToString();
					obj.Estatus = int.Parse(row["Estatus"].ToString());
					obj.NombreProyecto = row["NombreProyecto"].ToString();
					obj.Imagen = imagen;
					lista.Add(obj);
				}
			}
			return lista;
		}
		public TblRequisitosBO UnRequisito(int id)
		{
			TblRequisitosBO obj = new TblRequisitosBO();
			sql = "Select * FROM TblRequisitos Where IdRequisito = " + id + ";";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					byte[] imagen = null;
					try
					{
						imagen = (byte[])row["Imagen"];
					}
					catch
					{ }
					obj.IdRequisito = int.Parse(row["IdRequisito"].ToString());
					obj.Titulo = row["Titulo"].ToString();
					obj.Descripcion = row["Descripcion"].ToString();
					obj.FKProyecto = row["FKProyecto"].ToString();
					obj.Estatus = int.Parse(row["Estatus"].ToString());
					obj.Imagen = imagen;
				}
			}
			return obj;
		}
		public byte[] GetImagen(int id)
		{
			byte[] imagen = null;
			sql = " Select Imagen FROM TblRequisitos Where IdRequisito = " + id + ";";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{

					try
					{
						imagen = (byte[])row["Imagen"];
					}
					catch
					{ }
				}
			}
			return imagen;
		}
	}
}
