using System.Data.SqlClient;

namespace Project_Manager.Services.DAO
{
    public class Conexion
	{
		SqlConnection con;
		public SqlConnection establecerconexion()
		{
			string cadena = "SERVER=DESKTOP-27FSFUB\\SQLEXPRESS;Initial Catalog=BD_APManager;Integrated Security=True";
			con = new SqlConnection(cadena);
			return con;
		}
		public void AbrirConexion()
		{
			con.Open();
		}
		public void CerrarConexion()
		{
			con.Close();
		}
	}
}

