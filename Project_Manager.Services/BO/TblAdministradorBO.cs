namespace Project_Manager.Services.BO
{
    public class TblAdministradorBO
{
	string nombreadmin;
	string apellidoadmin;
	int idadmin;
	TblCuentaBO otblCuentaBO;
	TblRolBO otblRolBO;

	public string NombreAdmin
	{
		get { return nombreadmin; }
		set { nombreadmin = value; }
	}
	public string ApellidoAdmin
	{
		get { return apellidoadmin; }
		set { apellidoadmin = value; }
	}
	public int IDAdmin
	{
		get { return idadmin; }
		set { idadmin = value; }
	}
	public TblCuentaBO OTblCuentaBO
	{
		get { return otblCuentaBO; }
		set { otblCuentaBO = value; }
	}
	public TblRolBO OTblRolBO
	{
		get { return otblRolBO; }
		set { otblRolBO = value; }
	}
	}
}
