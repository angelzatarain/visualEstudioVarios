using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows;

namespace RegistroAspirantes
{
    class Conexion
    {
        public static SqlConnection agregarConexion()
        {
            SqlConnection conexion = new SqlConnection("Data Source=CC102-11\\SA;Initial Catalog=baseAspirantes;User ID=sa;Password=adminadmin");
            conexion.Open();
            return conexion;
        }

        public static void llenarComboProgramas(ComboBox cb)
        {
            try {
                SqlConnection conexion = agregarConexion();
                if (conexion != null) {
                    SqlCommand cmd = new SqlCommand("select nombre from programas", conexion);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                        cb.Items.Add(rd.GetString(0));
                    cb.SelectedIndex = 0; //poner el primer elemento en el combo
                    rd.Close();
                    conexion.Close();
                }
                else
                    MessageBox.Show("No se conenctó");
            }catch(Exception ex) {
                MessageBox.Show("error" + ex); 
            }
        }

    }
}
