using Project_Manager.Services.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Manager.Services.DAO
{
    public class DataSessionDAO
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        Conexion con2 = new Conexion();
        string sql;

        //public int IDO { get; private set; }

        public List<DataSessionBO > CargarDatos(object obj)
        {
            string Rol = String.Empty;
            TblCuentaBO datos = (TblCuentaBO)obj;
            List<DataSessionBO> lista = new List<DataSessionBO>();
            cmd.Connection = con2.establecerconexion();
            con2.AbrirConexion();
            sql = ("SELECT * FROM TblCuenta WHERE Usuario='" + datos.Usuario + "' AND Contra='" + datos.Contra + "' AND ESTATUS=0");

            SqlDataAdapter da = new SqlDataAdapter(sql, con2.establecerconexion());
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            if (tabla.Rows.Count > 0)
            {
                foreach(DataRow row in tabla.Rows)
                {
                    Rol = row["Rol"].ToString();
                }
                sql = null;
                switch (Rol)
                {
                    case "Administrador":
                        sql = ("SELECT * FROM TblAdministrador WHERE FKUsuario='" + datos.Usuario + "' AND ContraAdmin='" + datos.Contra + "' AND Estatus=0");
                        SqlDataAdapter daSA = new SqlDataAdapter(sql, con2.establecerconexion());
                        DataTable tablaSA = new DataTable();
                        daSA.Fill(tablaSA);
                        if (tablaSA.Rows.Count > 0)
                        {
                            foreach(DataRow rowsa in tablaSA.Rows)
                            {
                                DataSessionBO bo = new DataSessionBO();
                                bo.ID = int.Parse(rowsa["IDAdmin"].ToString());
                                bo.Nombre = rowsa["NombreAdmin"].ToString();
                                bo.Apellido1 = rowsa["ApellidoPAdmin"].ToString();
                                bo.Apellido2 = rowsa["ApellidoMAdmin"].ToString();
                                bo.Correo = rowsa["CorreoAdmin"].ToString();
                                bo.Contraseña = rowsa["ContraAdmin"].ToString();
                                bo.Usuario = rowsa["FKUsuario"].ToString();
                                bo.Rol = rowsa["FKRol"].ToString();
                                lista.Add(bo);
                            }
                        }
                        break;
                    case "Empleado":
                        sql = ("SELECT * FROM tblEmpleado WHERE FKUsuario='" + datos.Usuario + "' AND ContraEmpleado='" + datos.Contra + "' AND Estatus=0");
                        SqlDataAdapter daSE = new SqlDataAdapter(sql, con2.establecerconexion());
                        DataTable tablaSE = new DataTable();
                        daSE.Fill(tablaSE);
                        if (tablaSE.Rows.Count > 0)
                        {
                            foreach (DataRow rowse in tablaSE.Rows)
                            {
                                DataSessionBO bo = new DataSessionBO();
                                bo.ID = int.Parse(rowse["IDEmpleado"].ToString());
                                bo.Nombre = rowse["NombreEmpleado"].ToString();
                                bo.Apellido1 = rowse["ApellidoPEmpleado"].ToString();
                                bo.Apellido2 = rowse["ApellidoMEmpleado"].ToString();
                                bo.Correo = rowse["CorreoEmpleado"].ToString();
                                bo.Contraseña = rowse["ContraEmpleado"].ToString();
                                bo.Usuario = rowse["FKUsuario"].ToString();
                                bo.Rol = rowse["FKRol"].ToString();
                                lista.Add(bo);
                            }
                        }
                        break;
                }
            }
            return lista;
        }

    }
}
