﻿using Project_Manager.Services.BO;
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
		public List<TblIncidenciasBO> GetMyIncidencias(int id)
		{
			List<TblIncidenciasBO> datos = new List<TblIncidenciasBO>();
			datos = metodo.GetMyIncidencias(id);
			return datos;
		}
		public TblIncidenciasBO GetIncidencia(int Id)
		{
			TblIncidenciasBO data = new TblIncidenciasBO();
			data = metodo.UnaIncidencia(Id);
			return data;
		}
	}
	
}
