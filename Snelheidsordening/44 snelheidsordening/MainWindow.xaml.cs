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

namespace _44_snelheidsordening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int maxArraySize = 5;
        string[] naamAtleten = new string[maxArraySize];
        int[] totSec = new int[maxArraySize];
        int x = 0;

        public MainWindow()
        {
            InitializeComponent();
            TxtNaamAtleet.Focus();
        }

        private void BtnNieuweInvoer_Click(object sender, RoutedEventArgs e)
        {
            if (x < 5)
            {
                naamAtleten[x] = TxtNaamAtleet.Text;
                totSec[x] = int.Parse(TxtAantalSec.Text);
                TxtResult.Text += $"{naamAtleten[x],-20} {totSec[x]}\n";
                TxtAantalSec.Text = "0";
                TxtNaamAtleet.Text = string.Empty;
                TxtNaamAtleet.Focus();
                x++;
            }
            else
            {
                MessageBox.Show("Maximaal aantal atleten bereikt!");
            }
        }

        private void BtnToonVolgorde_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = string.Empty;

            for (int i = 0; i < x; i++)
            {
                int snelste = i;
                for (int j = i + 1; j < x; j++)
                {
                    if (totSec[j] < totSec[snelste])
                    {
                        snelste = j;
                    }
                }

                int tempSnelste = totSec[i];
                totSec[i] = totSec[snelste];
                totSec[snelste] = tempSnelste;

                string tempSnelsteAtleet = naamAtleten[i];
                naamAtleten[i] = naamAtleten[snelste];
                naamAtleten[snelste] = tempSnelsteAtleet;

                TxtResult.Text += $"{naamAtleten[i],-20} {totSec[i]}\n";

            }
        }

        private void BtnOpnieuw_Click(object sender, RoutedEventArgs e)
        {
            TxtNaamAtleet.Clear();
            TxtAantalSec.Text = "0";
            TxtResult.Clear();
            naamAtleten = new string[maxArraySize];
            totSec = new int[maxArraySize];
            x = 0;
            TxtNaamAtleet.Focus();
        }

        private void BtnAfsluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
