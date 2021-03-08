using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.Services
{
    public class TblRequisitosCTRL
	{
		TblRequisitosDAO metodo = new TblRequisitosDAO();
		public int Alta(object obj)
		{
			int resultado = 0;
			resultado = metodo.Crear(obj);
			return resultado;
		}
		public List<TblRequisitosBO> GetMyRequisitos(int id)
		{
			List<TblRequisitosBO> datos = new List<TblRequisitosBO>();
			datos = metodo.GetMyRequisitos(id);
			return datos;
		}
		public TblRequisitosBO GetRequisitos(int Id)
		{
			TblRequisitosBO data = new TblRequisitosBO();
			data = metodo.UnRequisito(Id);
			return data;
		}
	}
	
}
