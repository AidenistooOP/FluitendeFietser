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
using System.Windows.Threading;

namespace Project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window

    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StartTimer();
        }
        DispatcherTimer timer = new DispatcherTimer();
        int time = 60;
        private void StartTimer()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timertick;
            timer.Start();
        }
        private void timertick(object sender, EventArgs e)
        {
            time -= 1;
            loadingbar.Value = time;
        }
        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Fietsen.SelectedItem == null)
            {
                MessageBox.Show("Er is geen optie geselecteerd. Selecteer een optie en probeer het opnieuw.");
                return;
            }
            else if (Verzekering.SelectedItem == null)
            {
                MessageBox.Show("Er is geen optie geselecteerd. Selecteer een optie en probeer het opnieuw.");
                return;
            }
            else if (Services.SelectedItem == null)
            {
                MessageBox.Show("Er is geen optie geselecteerd. Selecteer een optie en probeer het opnieuw.");
                return;
            }
            if (Fietsen.SelectedItem == null || Verzekering.SelectedItem == null || Services.SelectedItem == null)
            {
                MessageBox.Show("Er is geen optie geselecteerd. Selecteer een optie en probeer het opnieuw.");
                return;
            }

            // Declare variables
            ComboBoxItem selectedItem = (ComboBoxItem)Fietsen.SelectedItem;
            string artikel = selectedItem.Content.ToString();
            double prijs = 0.0;
           
            switch (Fietsen.SelectedIndex)
            {
                case 0:
                    artikel += "Aanhangfiets";
                    prijs = 20.0;
                    break;
                case 1:
                    artikel += "Bakfiets";
                    prijs = 35.0;
                    break;
                case 2:
                    artikel += "Driewielfiets";
                    prijs = 30.0;
                    break;
                case 3:
                    artikel += "Elektrische fiets";
                    prijs = 30.0;
                    break;
                case 4:
                    artikel += "Kinderfiets";
                    prijs = 15.0;
                    break;
                case 5:
                    artikel += "Ligfiets";
                    prijs = 45.0;
                    break;
                case 6:
                    artikel += "Oma fiets";
                    prijs = 12.5;
                    break;
                case 7:
                    artikel += "Racefiets";
                    prijs = 15.0;
                    break;
                case 8:
                    artikel += "Speed pedelec";
                    prijs = 15.0;
                    break;
                case 9:
                    artikel += "Stadsfiets";
                    prijs = 12.5;
                    break;
                case 10:
                    artikel += "Vouwfiets";
                    prijs = 10.0;
                    break;
                case 11:
                    artikel += "Zitfiets";
                    prijs = 15.0;
                    break;

                default:
                    break;
            }

           

            // Get the price of the selected insurance
            switch (Verzekering.SelectedIndex)
            {
                case 0:
                    artikel += " + Beschadigingen";
                    prijs += 5.0;
                    break;
                case 1:
                    artikel += " + Diefstal";
                    prijs += 10.0;
                    break;
                case 2:
                    artikel += " + Rechtsbijstand";
                    prijs += 5.0;
                    break;
                case 3:
                    artikel += " + Ongevallen";
                    prijs += 2.50;
                    break;

                default:
                    break;
            }
          

            // Get the price of the selected service
            switch (Services.SelectedIndex)
            {
                case 0:
                    artikel += " + Ophaalservice";
                    prijs += 15.0;
                    break;
                case 1:
                    artikel += " + Regenpak";
                    prijs += 10.0;
                    break;
                case 2:
                    artikel += "+ Lunchpakket basis";
                    prijs += 12.50;
                    break;
                case 3:
                    artikel += "+ Lunchpakket uitgebreid";
                    prijs += 20.00;
                    break;
                case 4:
                    artikel += "+ Fietskaart";
                    prijs += 5.00;
                    break;
                case 5:
                    artikel += "+ Fietstas";
                    prijs += 7.50;
                    break;
                case 6:
                    artikel += "+ Fietsbel";
                    prijs += 2.50;
                    break;

                default:
                    break;
            }
          

            // Get the number of days from the days TextBox
            if (!int.TryParse(tbDagen.Text, out int dagen))
            {
                MessageBox.Show("Voer een geldig aantal dagen in.");
                return;
            }

          
            // Calculate the total price of the order
            double totaalPrijs = prijs * dagen;

            // Add the order to the overview
            listbox.Items.Add($"{artikel} ({dagen} dagen) = €{totaalPrijs}");


        }

       
    }
}


