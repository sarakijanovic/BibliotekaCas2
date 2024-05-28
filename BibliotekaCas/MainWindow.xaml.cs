using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace BibliotekaCas
{
    public partial class MainWindow : Window
    {
        // Konstantna promenljiva koja predstavlja putanju do fajla sa podacima o knjigama

        private const string Podaci = @"C:\Users\MAXX\Documents\knjige.txt";
        private List<Knjiga> knjige = new List<Knjiga>();

        public MainWindow()
        {
            InitializeComponent();
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            // Proverava da li fajl postoji

            if (File.Exists(Podaci))
            {
                // Čita sve linije iz fajla
                var lines = File.ReadAllLines(Podaci);

                // Parsira svaku liniju u objekat tipa Knjiga i dodaje ga u listu knjiga
                knjige = lines.Select(line =>
                {
                    var parts = line.Split(',');
                    return new Knjiga(parts[0], parts[1], DateTime.Parse(parts[2]));
                }).ToList();

                // Postavlja listu knjiga kao izvor podataka za DataGrid
                dataGridCentralni.ItemsSource = knjige;
            }
            else
            {
                MessageBox.Show("Fajl nije pronađen");
            }
        }

        // Metoda koja se poziva kada se klikne na dugme "Dodaj"
        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            // Kreira novi objekat Knjiga sa podacima iz unetih polja i trenutnim datumom i vremenom
            var knjiga = new Knjiga(txtNazivKnjige.Text, txtAutor.Text, DateTime.Now);

            // Proverava da li su oba polja (naziv knjige i autor) popunjena
            if (!string.IsNullOrEmpty(knjiga.Naziv) && !string.IsNullOrEmpty(knjiga.Autor))
            {
                // Dodaje novu knjigu u listu knjiga
                knjige.Add(knjiga);

                // Dodaje podatke o novoj knjizi u fajl
                File.AppendAllText(Podaci, $"{knjiga.Naziv},{knjiga.Autor},{knjiga.Datum:yyyy-MM-dd HH:mm:ss}\n");

                // Prikazuje poruku o uspešnom upisu
                MessageBox.Show("Uspešan upis!");
            }
            else
            {
                // Prikazuje poruku o neuspešnom upisu ako su polja prazna
                MessageBox.Show("Neuspešan upis!");
            }

            // Ponovo učitava podatke kako bi se nova knjiga prikazala u DataGrid-u
            UcitajPodatke();
        }
    }
}
