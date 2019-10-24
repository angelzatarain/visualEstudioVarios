using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace RegistroAspirantes
{
    class Aspirante
    {
        public String nombre, apellidoPaterno, apellidoMaterno, sexo, correo, fechaNac;
        public int grado, programa;

        public Aspirante(string nombre, string apellidoPaterno, string apellidoMaterno, string sexo, string correo, string fechaNac, int grado, int programa)
        {
            this.nombre = nombre;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.sexo = sexo;
            this.correo = correo;
            this.fechaNac = fechaNac;
            this.grado = grado;
            this.programa = programa;
        }

        public Aspirante()
        {
        }

        public String alta(Aspirante a)
        {
            String res = "";
            int i;
            try {
                SqlConnection con = Conexion.agregarConexion();
                SqlCommand cmd = new SqlCommand("select top(1) idAspirante from aspirantes order by idAspirante des", con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read()) {
                    i = rd.GetInt32(0) + 1;
                    rd.Close();
                    SqlCommand cmd2 = new SqlCommand(String.Format("insert into aspirantes values ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', {7}, {8}) ", i, a.nombre, a.apellidoPaterno, a.apellidoMaterno, a.sexo, a.fechaNac, a.correo, a.grado, a.programa), con);
                    cmd2.ExecuteNonQuery();
                }
                else {
                    rd.Close();
                    SqlCommand cmd2 = new SqlCommand(String.Format("insert into aspirantes values ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', {7}, {8}) ", 1, a.nombre, a.apellidoPaterno, a.apellidoMaterno, a.sexo, a.fechaNac, a.correo, a.grado, a.programa), con);
                    cmd2.ExecuteNonQuery();
                }
                res = "alata exitosa";
                con.Close();
            }catch(Exception ex) {
                res = "alta no exitosa" + ex.Message;
            }
            return res;
        }

        public String modifica(int programa, String nombre) {
            String res = "";
            try {
                SqlConnection con = Conexion.agregarConexion();
                SqlCommand cmd = new SqlCommand(String.Format("update aspirantes et clavePrograma = {0} where nombre='{1}'", programa, nombre), con);
                cmd.ExecuteNonQuery();
                res = "modificación exitosa";
            } catch(Exception ex) {
                res = "error" + ex;
            }
            return res;
        }

        public static void llenarComboNombres(ComboBox cb)
        {
            try
            {
                SqlConnection conexion = Conexion.agregarConexion();
                if (conexion != null)
                {
                    SqlCommand cmd = new SqlCommand("select nombre from aspirantes", conexion);
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                        cb.Items.Add(rd.GetString(0));
                    cb.SelectedIndex = 0; //poner el primer elemento en el combo
                    rd.Close();
                    conexion.Close();
                }
                else
                    MessageBox.Show("No se conenctó");
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }

        public String generaReporte(DataGrid dgreporte, int pro)
        {
            String res = "";
            try
            {
                SqlConnection con = Conexion.agregarConexion();
                SqlCommand cmd = new SqlCommand(String.Format("select * from aspirantes where clavePrograma={0}", pro), con);
                SqlDataReader rd = cmd.ExecuteReader();
                dgreporte.ItemsSource = rd;
                res = "reporte exitoso";
                rd.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                res = "error" + ex;
            }
            return res;
        }
    }
}
