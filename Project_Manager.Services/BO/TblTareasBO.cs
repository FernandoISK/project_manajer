using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.BO
{
    public class TblTareasBO
    {
        public string FKProyecto { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public int Estado { get; set; }
        public int ID { get; set; }

        //============================ TABLAS TEMPORALES ================================

        public string NombreProyecto { get; set; }
        public int IDToma { get; set; }

    }
}
