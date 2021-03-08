using Project_Manager.Services.BO;
using Project_Manager.Services.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.Services
{
    public class TblComentarioCTRL
    {
        TblComentarioDAO metodo = new TblComentarioDAO();

        public int AgregarComentario(TblComentarioBO dato)
        {
            int resultado = 0;
            resultado = metodo.AgregarComentario(dato);
            return resultado;
        }

        public List<TblComentarioBO> ListaComentario(string folio, string tarea)
        {
            List<TblComentarioBO> ListaCom = new List<TblComentarioBO>();
            ListaCom = metodo.TraerComentarios(folio, tarea);
            return ListaCom;
        }


        #region ComentariosRequisitos
        public int AgregarComentarioRequisitos(TblComentarioBO dato)
        {
            int resultado = 0;
            resultado = metodo.AgregarComentarioRequisitos(dato);
            return resultado;
        }

        public List<TblComentarioBO> ListaComentarioRequisitos(string folio, string requisito)
        {
            List<TblComentarioBO> ListaCom = new List<TblComentarioBO>();
            ListaCom = metodo.TraerComentariosRequisitos(folio, requisito);
            return ListaCom;
        }
        #endregion

        #region ComentariosIncidencias
        public int AgregarComentarioIncidencias(TblComentarioBO dato)
        {
            int resultado = 0;
            resultado = metodo.AgregarComentarioIncidencias(dato);
            return resultado;
        }

        public List<TblComentarioBO> ListaComentarioIncidencias(string folio, string incidencia)
        {
            List<TblComentarioBO> ListaCom = new List<TblComentarioBO>();
            ListaCom = metodo.TraerComentariosIncidencias(folio, incidencia);
            return ListaCom;
        }
        #endregion
    }
}
