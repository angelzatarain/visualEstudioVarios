using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sueldo
{
    public partial class sueldo : System.Web.UI.Page
    {
        protected OdbcConnection agregarConexion()
        {
            try
            {
                OdbcConnection conexion = new OdbcConnection("Driver={SQL Server Native Client 11.0};Server=CC102-11\\SA;Uid=sa;Pwd=adminadmin;Database=sueldos;");
                conexion.Open();
                Label1.Text = "conexion exitossa";
                return conexion;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bCalcular_Click(object sender, EventArgs e)
        {
            OdbcConnection conexion = agregarConexion();
            Label1.Text = "entro";
            if (conexion != null)
            {
                OdbcCommand cmd = new OdbcCommand(string.Format("SELECT sueldoBase FROM informacion$ WHERE vendedor = '{0}'", Session["nombre"]), conexion);
                double sueldoBase = double.Parse(cmd.ExecuteScalar().ToString());//ExecuteScalar es para cuando te regresa números
                Label1.Text = "hola " + sueldoBase;
                double sueldoFinal = sueldoBase;
                double ventas = double.Parse(tbVentas.Text);
                if (ventas >= 100 && ventas <= 1000)
                    sueldoFinal = sueldoBase + (ventas * .10);
                Label1.Text = "hola " + sueldoFinal;

                cmd = new OdbcCommand(String.Format("UPDATE informacion$ SET sueldoFinal = '{0}' WHERE vendedor = '{1}' ", sueldoFinal, Session["nombre"]), conexion);
                cmd.ExecuteNonQuery();
            }
        }
    }
}