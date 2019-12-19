using AutoCompleteComboBoxVB;
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

namespace TestAutoCombox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = this;
            
            if (SelectedItems == null)
                SelectedItems = new List<IAutoCompleteSource>();


            SelectedItems.Add(new AutoCompleteComboBoxSource(1, "HECTOR SANCHEZ SANCHEZ", "XMY1012"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(2, "CARLOS ALBERTO HERNÁNDEZ REYES", "XM01ATT"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(3, "JOSE DAVID SANCHEZ ALONSO", "M50788"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(4, "PATRICIA AGUILAR", "XM010KF"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(5, "MARTIN MONROY MEJIA", "M56345"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(6, "RUBEN REUS URIBE ", "MB73910"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(7, "ALEJANDRO REYNAL HERRERA", "M100099"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(8, "PATRICIA ESQUIVEL SANCHEZ", "M817466"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(9, "CARLOS HERAS TOLEDANO", "M843089"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(10, "Luis Javier Xicotencatl Padrón", "M913015"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(11, "María del Rocío Arellano Martínez", "XM05705"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(12, "Jesus Ruiz Gomez", "MB48131"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(13, "Yoatzin Solis Zuñiga", "M830965"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(14, "Jose Antonio Gonzalez Balderas", "M838469"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(15, "Marco Antonio Espinosa Melendez", "M904249"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(16, "Barbara Grande Trejo", "MB60904"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(17, "Juan Pérez", "M5899399"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(18, "Noemi Mejia Feria", "MB58530"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(19, "Daniela Guerrero Chávez", "MB43315"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(20, "IT Back Office", "DYDGACTV"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(21, "Alan Mauricio Rodriguez Bustamante", "MB20132"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(22, "Leonel Hernandez Ramos", "MH03546"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(23, "Arturo Jimenez Montoya", "M827887"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(24, "Carlos G. Perez Amaya", "M828290"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(25, "Guillermo Solano Tellez", "M841800"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(26, "Sergio  Carrillo Farfan", "MB44250"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(27, "Marco Islas Peralta", "MB64321"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(28, "Juan Carlos Ramos Martinez", "MB65568"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(29, "Maria Teresa Martinez Martinez", "m829537"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(30, "Leticia Gomez", "M827890"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(31, "Diego del Olmo Diaz Castillo", "M839470"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(32, "Fermin Escobedo Fragoso", "M831044"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(33, "Armando Vazquez Alvarado", "M831539"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(34, "Raul Isai Bejarano", "MB54659"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(35, "Jessica Cea Rasso", "M828919"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(36, "Manuel Rodrigo Montoya Zirarte", "M825015"));
            SelectedItems.Add(new AutoCompleteComboBoxSource(37, "El macizo soy yo", "MB95958"));
            autoComple.ItemsSource = SelectedItems;


            //AutoCompleteComboBox.AutoCompleteComboBox  autoComplete = new AutoCompleteComboBox.AutoCompleteComboBox();

            //autoComplete.SearchTypeContent.Add(new AutoCompleteComboBox.AutoCompleteSearchTypes() { SearchType = AutoCompleteComboBox.SearchType.UserName });

            //AutoCompleteComboBox.AutoCompleteComboBox autoComplete2 = new AutoCompleteComboBox.AutoCompleteComboBox();
            //autoComplete2.SearchTypeContent.Add(new AutoCompleteComboBox.AutoCompleteSearchTypes() { SearchType = AutoCompleteComboBox.SearchType.UserName });
        }

        public int IdSelection;
        public List<IAutoCompleteSource> SelectedItems;

        private void AutoComple_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
