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

namespace PrimerEjemplo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox objTextBox = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double grados;
                //si escribió en la caja de texto de txt centígrados pasará lo siguiente
                if (objTextBox == txCentigrados)
                {
                    MessageBox.Show("escribiste en la caja de texto de grados centígrados");
                    grados = Convert.ToDouble(txCentigrados.Text) * 9.0 / 5.0 + 32.0;
                    txFarenheit.Text = String.Format("{0:F2}", grados);
                }
                else
                //si escribió en la caja de txtFarenheit   
                    if (objTextBox == txFarenheit)
                    {
                        MessageBox.Show("escribiste en la caja de texto de grados Farenheit");
                        grados = (Convert.ToDouble(txFarenheit.Text) - 32.0) * 5.0 / 9.0;
                        txCentigrados.Text = String.Format("{0:F2}", grados);
                    }
            } catch (FormatException) {
                txCentigrados.Text = "0.0";
                txFarenheit.Text = "32.0";
            } 
        }

        private void TxCentigrados_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            objTextBox = sender as TextBox;
        }

        private void TxFarenheit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            objTextBox = sender as TextBox;
        }
    }
}
