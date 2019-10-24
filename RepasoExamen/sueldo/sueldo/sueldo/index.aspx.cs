using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sueldo
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bSiguiente_Click(object sender, EventArgs e)
        {
            Session["nombre"] = tbNombre.Text;
            Response.Redirect("sueldo.aspx");
        }

        protected void bReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("reporte.aspx");
        }
    }
}