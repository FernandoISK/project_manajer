using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.BO
{
    public class DataSessionBO
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public string Correo { get; set; }

        public string Usuario { get; set; }

        public string Contraseña { get; set; }

        public string Rol { get; set; }

        public static implicit operator List<object>(DataSessionBO v)
        {
            throw new NotImplementedException();
        }
    }
}
