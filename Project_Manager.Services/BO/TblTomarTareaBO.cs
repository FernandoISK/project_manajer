using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.BO
{
    public class TblTomarTareaBO
    {
        public int IDToma { get; set; }
        public int FKEmpleado { get; set; }
        public int FKTarea { get; set; }
        public int Estado { get; set; }
        public string FechaToma { get; set; }
        public string FechaFinalizacion { get; set; }
    }
}
