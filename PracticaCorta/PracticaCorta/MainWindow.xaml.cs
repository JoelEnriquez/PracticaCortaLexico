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

namespace PracticaCorta
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private String[] tokens;
        private String[] tipo;

        public MainWindow()
        {
            InitializeComponent();
            //agregarCabeceras();

            String[] asdf = new string[2];
            String[] fdsa = new string[2];

            asdf[0] = "asdfsaf";
            asdf[1] = "wewegweb";
            fdsa[0] = "fwefwef";
            fdsa[1] = "we234234";

            List<Fila> items = new List<Fila>();
            items.Add(new Fila() { Tokens = "John Doe", Tipo = "f"});
            items.Add(new Fila() { Tokens = "Jane Doe", Tipo = "dsdf"});
            items.Add(new Fila() { Tokens = "Sammy Doe", Tipo = "sdf"});

            items.Add(new Fila() { Tokens = asdf[0], Tipo = asdf[1] });
            items.Add(new Fila() { Tokens = fdsa[0], Tipo = fdsa[1] });

            listaComponentesListView.ItemsSource = items;
        }

        private void agregarCabeceras()
        {
            // Se crea gridview para agregarlo a listview
            var gridView = new GridView();
            listaComponentesListView.View = gridView;
            // se agregan columnas

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Tokens",
                DisplayMemberBinding = new Binding("Tokens"),
                Width = 150

            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Tipo",
                DisplayMemberBinding = new Binding("Tipo"),
                Width = 160
            });

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String ingreso = tbIngresoOracion.Text;

            if (ingreso.Equals(""))
            {
                MessageBox.Show("Ingrese una palabra para analizar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                tokens = new string[ingreso.Length];
                tipo = new string[ingreso.Length];

                LogicaAnalizador logica = new LogicaAnalizador(ingreso);
                logica.AnalizarExpresion();
                logica.getTipoComponentes();
            }           
        }

        public class Fila
        {
            public string Tokens { get; set; }
            public string Tipo { get; set; }
        }
    }
}
