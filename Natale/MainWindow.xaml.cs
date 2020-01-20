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
using System.IO;

namespace Natale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cmbOperazioni.Items.Add("Addizione");
            cmbOperazioni.Items.Add("Sottrazione");
            cmbOperazioni.Items.Add("Moltiplicazione");
            cmbOperazioni.Items.Add("Divisione");

        }

        string file = "operazioni.txt";

        private void btnCalcola_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double n1 = double.Parse(txt1.Text);
                if (n1 == double.NaN)
                {
                    throw new Exception("Inserisci il primo numero!");
                }
                double n2 = double.Parse(txt2.Text);
                if (n1 == double.NaN)
                {
                    throw new Exception("Inserisci il secondo numero!");
                }
                string risultato = "";
            
                if (cmbOperazioni.SelectedItem == null)
                {
                    throw new Exception("Devi selezionare un'operazione!");
                }
                if (cmbOperazioni.SelectedIndex == 0)
                {
                    risultato = (n1 + n2).ToString();
                }
                if (cmbOperazioni.SelectedIndex == 1)
                {
                    risultato = (n1 - n2).ToString();
                }
                if (cmbOperazioni.SelectedIndex == 2)
                {
                    risultato = (n1 * n2).ToString();
                }
                if (cmbOperazioni.SelectedIndex == 3)
                {
                    risultato = (n1 / n2).ToString();
                    if (n2 == 0)
                        risultato = "Divisione impossibile";
                    if (n1 == 0 && n2 == 0)
                        risultato = "Divisione indeterminata";
                }
                txtRisultato.Text = $"Il risultato è : {risultato}";
                using (StreamWriter writer = new StreamWriter(file, true))
                {
                    writer.WriteLine(txtRisultato.Text);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
