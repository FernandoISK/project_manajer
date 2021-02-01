using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System.Collections.Generic;
using System.Data;

namespace Project_Manager.Services.Services
{
    public class TblProyectosCTRL
	{
        TblProyectosDAO metodo = new TblProyectosDAO();
        public int Alta(object obj)
        {
            int resultado = 0;
            resultado = metodo.Crear(obj);
            return resultado;
        }
        public object GetAll()
        {
            List<TblProyectosBO> datos = new List<TblProyectosBO>();
            datos = (List<TblProyectosBO>)metodo.TraerTodoProyecto();
            return datos;
        }
        public List<TblProyectosBO> GetIDProyecto()
        {
            List<TblProyectosBO> datos = new List<TblProyectosBO>();
            datos = metodo.TraerProyecto();
            return datos;
        }
        public int Baja(string folio, int status)
        {
            int resultado = 0;
            resultado = metodo.Eliminar(folio, status);
            return resultado;
        }
        public TblProyectosBO GetOne(string folio)
        {
            TblProyectosBO data = new TblProyectosBO();
            data = metodo.TraeUnProyecto(folio);
            return data;
        }

        public int Cambio(TblProyectosBO obj)
        {
            int resultado = 0;
            resultado = metodo.Actualizar(obj);
            return resultado;
        }
    }
}

