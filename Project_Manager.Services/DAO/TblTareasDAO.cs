﻿using Project_Manager.Services.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.DAO
{
    public class TblTareasDAO
    {
		SqlConnection con = new SqlConnection();
		SqlCommand cmd = new SqlCommand();
		Conexion con2 = new Conexion();
		string sql;
		public int Crear(object obj)
		{

			TblTareasBO datos = (TblTareasBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "EXEC NuevaTarea @Titulo ,@Descripcion ,@FKProyecto";

			cmd.Parameters.AddWithValue("@Titulo", datos.Titulo);
			cmd.Parameters.AddWithValue("@Descripcion", datos.Descripcion);
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

		public List<TblTareasBO> GetAll(string folio)
		{
			List<TblTareasBO> lista = new List<TblTareasBO>();
			sql = "SELECT * FROM TblTareas WHERE FKProyecto = '" + folio + "';";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblTareasBO obj = new TblTareasBO();
					obj.ID = int.Parse(row["ID"].ToString());
					obj.Titulo = row["Titulo"].ToString();
					obj.Descripcion = row["Descripcion"].ToString();
					obj.FKProyecto = row["FKProyecto"].ToString();
					obj.Estado = int.Parse(row["Estado"].ToString());
					lista.Add(obj);
				}
			}
			return lista;
		}
		public int Eliminar(int id)
		{
			TblTareasBO datos = new TblTareasBO();
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "DELETE FROM TblTareas WHERE ID = " + id + ";";
			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
		public List<TblTareasBO> GetMyTask(int id)
		{
			List<TblTareasBO> lista = new List<TblTareasBO>();
			sql = "SELECT b.*, c.NombreProyecto, a.IDToma  FROM TblTomarTarea a INNER JOIN TblTareas b ON a.FKTarea = b.ID INNER JOIN TblProyectos C ON b.FKProyecto = c.Folio WHERE a.Estado = 0 AND b.Estado = 1 AND a.FKEmpleado = " + id + "; ";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblTareasBO obj = new TblTareasBO();
					obj.ID = int.Parse(row["ID"].ToString());
					obj.Titulo = row["Titulo"].ToString();
					obj.Descripcion = row["Descripcion"].ToString();
					obj.FKProyecto = row["FKProyecto"].ToString();
					obj.Estado = int.Parse(row["Estado"].ToString());
					obj.NombreProyecto = row["NombreProyecto"].ToString();
					obj.IDToma = int.Parse(row["IDToma"].ToString());
					lista.Add(obj);
				}
			}
			return lista;
		}
		public List<TblIncidenciasBO> GetMyIncidencias(int id)
		{
			List<TblIncidenciasBO> lista = new List<TblIncidenciasBO>();
			sql = " SELECT a.*, b.NombreProyecto FROM TblIncidencias a INNER JOIN TblProyectos b on a.FKProyecto = b.Folio INNER JOIN TblProyectoEmpleado c ON b.Folio = c.FKProyecto Where c.FKEmpleado = " + id + "; ";
			SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
			DataTable tabla = new DataTable();
			da.Fill(tabla);
			if (tabla.Rows.Count > 0)
			{
				foreach (DataRow row in tabla.Rows)
				{
					TblIncidenciasBO obj = new TblIncidenciasBO();
					obj.IdIncidencia = int.Parse(row["IdIncidencia"].ToString());
					obj.Titulo = row["Titulo"].ToString();
					obj.Descripcion = row["Descripcion"].ToString();
					obj.FKProyecto = row["FKProyecto"].ToString();
					obj.Estatus = int.Parse(row["Estatus"].ToString());
					obj.NombreProyecto = row["NombreProyecto"].ToString();
					lista.Add(obj);
				}
			}
			return lista;
		}
		public int TomarTarea(object obj)
		{

			TblTomarTareaBO datos = (TblTomarTareaBO)obj;
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "INSERT INTO TblTomarTarea(FKEmpleado,FKTarea,FechaToma) VALUES(@FKEmpleado,@FKTarea,@FechaToma);";

			cmd.Parameters.AddWithValue("@FKEmpleado", datos.FKEmpleado);
			cmd.Parameters.AddWithValue("@FKTarea", datos.FKTarea);
			cmd.Parameters.AddWithValue("@FechaToma", datos.FechaToma);

			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
		public int ActualizasEstatus(int id)
		{

			TblTomarTareaBO datos = new TblTomarTareaBO();
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "update TblTareas set Estado = 1 where ID = " + id +";";
			cmd.CommandText = sql;
			int i = cmd.ExecuteNonQuery();
			cmd.Parameters.Clear();

			if (i <= 0)
			{
				return 0;
			}
			return 1;
		}
		public int FinalizarTarea(int idTarea, int idToma)
		{

			TblTomarTareaBO datos = new TblTomarTareaBO();
			cmd.Connection = con2.establecerconexion();
			con2.AbrirConexion();
			sql = "EXEC PA_Finalizar_Tarea " + idTarea + ","+ idToma + ";";
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
