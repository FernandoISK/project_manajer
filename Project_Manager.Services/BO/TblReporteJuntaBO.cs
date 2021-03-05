using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.BO
{
    public class TblReporteJuntaBO
    {
        public string Motivo { get; set; }
        public string Descripcion { get; set; }
        public int IdReporte { get; set; }
        public int Aprobacion { get; set; }
        public int FKEmpleado { get; set; }
        public int FKJunta { get; set; }
    }
}
