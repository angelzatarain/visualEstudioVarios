using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistroAspirantes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bAlta_Click(object sender, RoutedEventArgs e)
        {
            Aspirante a = new Aspirante(tbNombre.Text, tbApellidoPaterno.Text, tbApellidoMaterno.Text, tbSexo.Text, tbFechaDeNacimiento.Text, tbCorreo.Text, (int)cbGrado.SelectedItem, (int)cbPrograma.SelectedIndex);
            MessageBox.Show(a.alta(a));
        }

        private void bModificacion_Click(object sender, RoutedEventArgs e)
        {
            Modificacion w = new Modificacion();
            w.Show();
            this.Hide();
        }

        private void bReporte_Click(object sender, RoutedEventArgs e)
        {
            Reporte w = new Reporte();
            w.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Conexion.llenarComboProgramas(cbPrograma);
            cbGrado.Items.Add(4);
            cbGrado.Items.Add(5);
            cbGrado.Items.Add(6);
            cbGrado.SelectedIndex = 0;
        }
    }
}
