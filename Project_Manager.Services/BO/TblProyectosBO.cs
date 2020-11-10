using System;

namespace Project_Manager.Services.BO
{
    public class TblProyectosBO
{
	string nombreproyecto;
	string descripcionproyecto;
	string prioridadproyecto;
	DateTime fechaproyecto;
	string estadoproyecto;
	int idproyecto;
	TblClienteBO otblClienteBO;

	public string NombreProyecto
	{
		get { return nombreproyecto; }
		set { nombreproyecto = value; }
	}
	public string DescripcionProyecto
	{
		get { return descripcionproyecto; }
		set { descripcionproyecto = value; }
	}
	public string PrioridadProyecto
	{
		get { return prioridadproyecto; }
		set { prioridadproyecto = value; }
	}
	public DateTime FechaProyecto
	{
		get { return fechaproyecto; }
		set { fechaproyecto = value; }
	}
	public string EstadoProyecto
	{
		get { return estadoproyecto; }
		set { estadoproyecto = value; }
	}
	public int IDProyecto
	{
		get { return idproyecto; }
		set { idproyecto = value; }
	}
	public TblClienteBO OTblClienteBO
	{
		get { return otblClienteBO; }
		set { otblClienteBO = value; }
	}
	}
}
