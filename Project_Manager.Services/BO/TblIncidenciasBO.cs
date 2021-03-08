﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.BO
{
    public class TblIncidenciasBO
    {
        public int IdIncidencia { get; set; }
        public int Estatus { get; set; }
        public string FKProyecto { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }


        //================================= TABLA TEMPORALES=====================================
        public string NombreProyecto  { get; set; }
    }
}
