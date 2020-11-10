using Project_Manager.Services.BO;
using System.Data;
using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
    public class TblProyectosDAO
{
	SqlConnection con = new SqlConnection();
	SqlCommand cmd = new SqlCommand();
	Conexion con2 = new Conexion();
	string sql;

		public int Crear(object obj)
	{

		TblProyectosBO datos = (TblProyectosBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "Insert into TblProyectos(NombreProyecto ,DescripcionProyecto ,PrioridadProyecto ,FechaProyecto ,EstadoProyecto ,FKCliente)"+
		"Values(@NombreProyecto ,@DescripcionProyecto ,@PrioridadProyecto ,@FechaProyecto ,@EstadoProyecto ,@FKCliente)";
		cmd.Parameters.Add("@IDProyecto", SqlDbType.Int);
		cmd.Parameters.Add("@NombreProyecto", SqlDbType.VarChar);
		cmd.Parameters.Add("@DescripcionProyecto", SqlDbType.VarChar);
		cmd.Parameters.Add("@PrioridadProyecto", SqlDbType.VarChar);
		cmd.Parameters.Add("@FechaProyecto", SqlDbType.DateTime);
		cmd.Parameters.Add("@EstadoProyecto", SqlDbType.VarChar);
		cmd.Parameters.Add("@FKCliente", SqlDbType.Int);

		cmd.Parameters["@IDProyecto"].Value = datos.IDProyecto;
		cmd.Parameters["@NombreProyecto"].Value = datos.NombreProyecto;
		cmd.Parameters["@DescripcionProyecto"].Value = datos.DescripcionProyecto;
		cmd.Parameters["@PrioridadProyecto"].Value = datos.PrioridadProyecto;
		cmd.Parameters["@FechaProyecto"].Value = datos.FechaProyecto;
		cmd.Parameters["@EstadoProyecto"].Value = datos.EstadoProyecto;
		cmd.Parameters["@FKCliente"].Value = datos.OTblClienteBO.IDCliente;
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

		TblProyectosBO datos = (TblProyectosBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "update TblProyectos"+
		" set "+
		"NombreProyecto = @NombreProyecto,"+
		"DescripcionProyecto = @DescripcionProyecto,"+
		"PrioridadProyecto = @PrioridadProyecto,"+
		"FechaProyecto = @FechaProyecto,"+
		"EstadoProyecto = @EstadoProyecto,"+
		"FKCliente = @FKCliente"+
		" where IDProyecto = @IDProyecto";

		cmd.Parameters.Add("@IDProyecto", SqlDbType.Int);
		cmd.Parameters.Add("@NombreProyecto", SqlDbType.VarChar);
		cmd.Parameters.Add("@DescripcionProyecto", SqlDbType.VarChar);
		cmd.Parameters.Add("@PrioridadProyecto", SqlDbType.VarChar);
		cmd.Parameters.Add("@FechaProyecto", SqlDbType.DateTime);
		cmd.Parameters.Add("@EstadoProyecto", SqlDbType.VarChar);
		cmd.Parameters.Add("@FKCliente", SqlDbType.Int);

		cmd.Parameters["@IDProyecto"].Value = datos.IDProyecto;
		cmd.Parameters["@NombreProyecto"].Value = datos.NombreProyecto;
		cmd.Parameters["@DescripcionProyecto"].Value = datos.DescripcionProyecto;
		cmd.Parameters["@PrioridadProyecto"].Value = datos.PrioridadProyecto;
		cmd.Parameters["@FechaProyecto"].Value = datos.FechaProyecto;
		cmd.Parameters["@EstadoProyecto"].Value = datos.EstadoProyecto;
		cmd.Parameters["@FKCliente"].Value = datos.OTblClienteBO.IDCliente;

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
		TblProyectosBO datos = (TblProyectosBO)obj;
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();
		sql = "DELETE FROM TblProyectos where IDProyecto = @IDProyecto";
		cmd.Parameters.Add("@IDProyecto", SqlDbType.Int);
		cmd.Parameters["@IDProyecto"].Value = datos.IDProyecto;
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
		TblProyectosBO data = (TblProyectosBO)obj;
		SqlCommand cmd = new SqlCommand();
		DataSet ds = new DataSet();
		SqlDataAdapter da = new SqlDataAdapter();
		cmd.Connection = con2.establecerconexion();
		con2.AbrirConexion();

		if (data.IDProyecto > 0)
		{
			cadenaWhere = cadenaWhere + " IDProyecto = @IDProyecto and";
			cmd.Parameters.Add("@IDProyecto", SqlDbType.Int);
			cmd.Parameters["@IDProyecto"].Value = data.IDProyecto;
			edo = true;
		}
		if (data.NombreProyecto !=null)
		{
			cadenaWhere = cadenaWhere + " NombreProyecto = @NombreProyecto and";
			cmd.Parameters.Add("@NombreProyecto", SqlDbType.VarChar);
			cmd.Parameters["@NombreProyecto"].Value = data.NombreProyecto;
			edo = true;
		}
		if (data.DescripcionProyecto !=null)
		{
			cadenaWhere = cadenaWhere + " DescripcionProyecto = @DescripcionProyecto and";
			cmd.Parameters.Add("@DescripcionProyecto", SqlDbType.VarChar);
			cmd.Parameters["@DescripcionProyecto"].Value = data.DescripcionProyecto;
			edo = true;
		}
		if (data.PrioridadProyecto !=null)
		{
			cadenaWhere = cadenaWhere + " PrioridadProyecto = @PrioridadProyecto and";
			cmd.Parameters.Add("@PrioridadProyecto", SqlDbType.VarChar);
			cmd.Parameters["@PrioridadProyecto"].Value = data.PrioridadProyecto;
			edo = true;
		}
		if (data.FechaProyecto.ToString() !="01/01/0001 12:00:00 a. m.")
		{
			cadenaWhere = cadenaWhere + " FechaProyecto = @FechaProyecto and";
			cmd.Parameters.Add("@FechaProyecto", SqlDbType.DateTime);
			cmd.Parameters["@FechaProyecto"].Value = data.FechaProyecto;
			edo = true;
		}
		if (data.EstadoProyecto !=null)
		{
			cadenaWhere = cadenaWhere + " EstadoProyecto = @EstadoProyecto and";
			cmd.Parameters.Add("@EstadoProyecto", SqlDbType.VarChar);
			cmd.Parameters["@EstadoProyecto"].Value = data.EstadoProyecto;
			edo = true;
		}

		if (edo == true)
		{
			 cadenaWhere = " WHERE " +cadenaWhere.Remove(cadenaWhere.Length - 3, 3);
		}
		sql = "SELECT * FROM TblProyectos"  + cadenaWhere;
		cmd.CommandText = sql;
		da.SelectCommand = cmd;
		da.Fill(ds);
		con2.CerrarConexion();
		return ds;
	}


		public DataTable ListarTabla()
	{
		sql = "Select * from TblProyectos";
		SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
		DataTable tabla = new DataTable();
		da.Fill(tabla);
		return tabla;
	}

	}
}
