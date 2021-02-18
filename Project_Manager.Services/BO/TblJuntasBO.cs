using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.BO
{
    public class TblJuntasBO
    {
        public string Juntas { get; set; }
        public string Proyecto { get; set; }
        public string FechaJunta { get; set; }
        public string Motivo { get; set; }
        public int FKEmpresa { get; set; }
        public int Estatus { get; set; }
        public int IDJuntas { get; set; }
    }
}
