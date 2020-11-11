namespace Project_Manager.Services.BO
{
	public class TblClienteBO
	{
		string nombrecliente;
		string apellidocliente;
		string telefonocliente;
		char generocliente;
		string empresacliente;
		string representantecliente;
		int idcliente;
		TblCuentaBO otblCuentaBO;

		public string NombreCliente
		{
			get { return nombrecliente; }
			set { nombrecliente = value; }
		}
		public string ApellidoCliente
		{
			get { return apellidocliente; }
			set { apellidocliente = value; }
		}
		public string TelefonoCliente
		{
			get { return telefonocliente; }
			set { telefonocliente = value; }
		}
		public char GeneroCliente
		{
			get { return generocliente; }
			set { generocliente = value; }
		}
		public string EmpresaCliente
		{
			get { return empresacliente; }
			set { empresacliente = value; }
		}
		public string RepresentanteCliente
		{
			get { return representantecliente; }
			set { representantecliente = value; }
		}
		public int IDCliente
		{
			get { return idcliente; }
			set { idcliente = value; }
		}
		public TblCuentaBO OTblCuentaBO
		{
			get { return otblCuentaBO; }
			set { otblCuentaBO = value; }
		}
	}
}
