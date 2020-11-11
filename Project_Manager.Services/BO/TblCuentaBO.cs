namespace Project_Manager.Services.BO
{
	public class TblCuentaBO
	{
		string correo;
		string contra;
		string usuario;
		string rol;
		int estatus;

		public string Correo
		{
			get { return correo; }
			set { correo = value; }
		}
		public string Contra
		{
			get { return contra; }
			set { contra = value; }
		}
		public string Usuario
		{
			get { return usuario; }
			set { usuario = value; }
		}
		public int Estatus
		{
			get { return estatus; }
			set { estatus = value; }
		}
		public string Rol
		{
			get { return rol; }
			set { rol = value; }
		}
	}
}
