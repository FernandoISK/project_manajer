namespace Project_Manager.Services.BO
{
	public class TblAdministradorBO
	{
		int idadmin;
		string nombreadmin;
		string apellidopadmin;
		string apellidomadmin;
		int estatus;
		string correoadmin;
		string contraadmin;
		string fkusuario;
		string fkrol;

		public int IDAdmin
		{
			get { return idadmin; }
			set { idadmin = value; }
		}
		public string NombreAdmin
		{
			get { return nombreadmin; }
			set { nombreadmin = value; }
		}
		public string ApellidoPAdmin
		{
			get { return apellidopadmin; }
			set { apellidopadmin = value; }
		}
		public string ApellidoMAdmin
		{
			get { return apellidomadmin; }
			set { apellidomadmin = value; }
		}
		public int Estatus
		{
			get { return estatus; }
			set { estatus = value; }
		}
		public string CorreoAdmin
		{
			get { return correoadmin; }
			set { correoadmin = value; }
		}
		public string ContraAdmin
		{
			get { return contraadmin; }
			set { contraadmin = value; }
		}
		public string FKUsuario
		{
			get { return fkusuario; }
			set { fkusuario = value; }
		}
		public string FKRol
		{
			get { return fkrol; }
			set { fkrol = value; }
		}
	}
}
