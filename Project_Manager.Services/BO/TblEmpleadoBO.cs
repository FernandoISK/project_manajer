using System;

namespace Project_Manager.Services.BO
{
	public class TblEmpleadoBO
	{
		string nombreempleado;
		string apellidoPempleado;
		string apellidoMempleado;
		string telefonoempleado;
		string nacimiento;
		string generoempleado;
		string correoempleado;
		string contraempleado;
		string fkUsuario;
		int idempleado;
		int estatus;
		string fkRol;


		public string NombreEmpleado
		{
			get { return nombreempleado; }
			set { nombreempleado = value; }
		}
		public string ApellidoPEmpleado
		{
			get { return apellidoPempleado; }
			set { apellidoPempleado = value; }
		}
		public string ApellidoMEmpleado
		{
			get { return apellidoMempleado; }
			set { apellidoMempleado = value; }
		}
		public string TelefonoEmpleado
		{
			get { return telefonoempleado; }
			set { telefonoempleado = value; }
		}
		public string Nacimiento
		{
			get { return nacimiento; }
			set { nacimiento = value; }
		}
		public string GeneroEmpleado
		{
			get { return generoempleado; }
			set { generoempleado = value; }
		}
		public string CorreoEmpleado
		{
			get { return correoempleado; }
			set { correoempleado = value; }
		}
		public string ContraEmpleado
		{
			get { return contraempleado; }
			set { contraempleado = value; }
		}
		public string FKUsuario
		{
			get { return fkUsuario; }
			set { fkUsuario = value; }
		}
		public int IDEmpleado
		{
			get { return idempleado; }
			set { idempleado = value; }
		}
		public string FKRol
		{
			get { return fkRol; }
			set { fkRol = value; }
		}

		public int Estatus
		{
			get { return estatus; }
			set { estatus = value; }
		}
	}
}