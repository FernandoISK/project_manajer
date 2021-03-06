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
					byte[] imagen = null;
					try
					{
						imagen = (byte[])row["Imagen"];
					}
					catch
					{ }
					obj.IdIncidencia = int.Parse(row["IdIncidencia"].ToString());
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
		public TblIncidenciasBO UnaIncidencia(int id)
		{
			TblIncidenciasBO obj = new TblIncidenciasBO();
			sql = "Select * FROM TblIncidencias Where IdIncidencia = " + id + ";";
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
					obj.IdIncidencia = int.Parse(row["IdIncidencia"].ToString());
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
			sql = " Select Imagen FROM TblIncidencias Where IdIncidencia = " + id + ";";
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
