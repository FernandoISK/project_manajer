using Project_Manager.Services.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.Services
{
    public class TblIncidenciasCTRL
    {
		TblIncidenciasDAO metodo = new TblIncidenciasDAO();
		public int Alta(object obj)
		{
			int resultado = 0;
			resultado = metodo.Crear(obj);
			return resultado;
		}
	}
}
