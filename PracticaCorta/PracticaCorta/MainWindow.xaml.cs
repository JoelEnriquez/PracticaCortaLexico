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
                logica.AnalizarExpresion(); //Ejecutar analizador

                tokens = ingreso.Split(' ');
                tipo = logica.getTipoComponentes();

                mostrarTipoTokens(tokens,tipo);
            }           
        }

        private void mostrarTipoTokens(String[] tokens, String[] tipo)
        {
            List<Fila> elementosFila = new List<Fila>();

            for (int i = 0; i < tokens.Length; i++)
            {
                elementosFila.Add(new Fila() { Tokens = tokens[i], Tipo = tipo[i]});
                /* Se crean e insertan objetos de
                tipo fila para mostrarlos luego
                en la list view
                */
            }
            listaComponentesListView.ItemsSource = elementosFila;
        }

        public class Fila
        {
            public string Tokens { get; set; }
            public string Tipo { get; set; }
        }

        private void borrarButton_Click(object sender, RoutedEventArgs e)
        {
            tbIngresoOracion.Clear();

            List<Fila> elementosFila = new List<Fila>();
            listaComponentesListView.ItemsSource = elementosFila;
        }
    }
}
