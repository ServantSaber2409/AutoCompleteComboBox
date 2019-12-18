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

namespace AutoCompleteComboBox
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class AutoCompleteComboBox : UserControl
    {

        #region DependecyProperty        
        public static readonly DependencyProperty ItemSourceProperty = DependencyProperty.Register("ItemsSource", typeof(List<IAutoCompleteSource>), typeof(AutoCompleteComboBox), new PropertyMetadata(new List<IAutoCompleteSource>()));
        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register("SelectedValue", typeof(int), typeof(AutoCompleteComboBox), new PropertyMetadata(0));
        public static readonly DependencyProperty AutoStyleProperty = DependencyProperty.Register("Estilo", typeof(Style), typeof(AutoCompleteComboBox), new FrameworkPropertyMetadata(null, PropertyChangedCallback));
        public static readonly DependencyProperty SearchTypeProperty = DependencyProperty.Register("SearchTypeContent", typeof(List<AutoCompleteSearchTypes>), typeof(AutoCompleteComboBox), new PropertyMetadata(new List<AutoCompleteSearchTypes>()));
        #endregion


        public static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {

        }

        public static void PropertyChangedCallbackSearchType(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e) { }

        #region Properties
        public List<IAutoCompleteSource> ItemsSource
        {
            set => SetValue(ItemSourceProperty, value);
            get => (List<IAutoCompleteSource>)GetValue(ItemSourceProperty);
        }

        public int SelectedValue
        {
            set => SetValue(SelectedValueProperty, value);
            get => (int)GetValue(SelectedValueProperty);
        }

        public Style Estilo
        {
            get => (Style)GetValue(AutoStyleProperty);
            set => SetValue(AutoStyleProperty, value);
        }

        public List<AutoCompleteSearchTypes> SearchTypeContent
        {
            set => SetValue(SearchTypeProperty, value);
            get => (List<AutoCompleteSearchTypes>)GetValue(SearchTypeProperty);
        }

        #endregion


        public AutoCompleteComboBox()
        {
            InitializeComponent();

            autoTextBox.TextChanged += new TextChangedEventHandler(AutoTexBox_TextChanged);
            autoTextBox.PreviewKeyDown += new KeyEventHandler(AutoTexBox_PreviewKeyDown);
            suggestionListBox.SelectionChanged += new SelectionChangedEventHandler(SuggestionListBox_SelectionChanged);
            SearchTypeContent = new List<AutoCompleteSearchTypes>();
        }

        #region Methods

        private void AutoTexBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (autoTextBox.Text.Length > 0)
            {
                string condition = string.Format("{0}", autoTextBox.Text);
                List<IAutoCompleteSource> result = null;

                for (int i = 0; i < SearchTypeContent.Count; i++)
                {
                    List<IAutoCompleteSource> temp = null;
                    switch (SearchTypeContent[i].SearchType)
                    {
                        case SearchType.UserName:
                            temp = ItemsSource.Where(x => x.UserName.Contains(condition)).ToList();
                            if (result != null)
                                result.AddRange(temp);
                            else
                                result = temp;
                            break;
                        case SearchType.UserNet:
                            temp = ItemsSource.Where(x => x.UserNet.Contains(condition)).ToList();
                            if (result != null)
                                result.AddRange(temp);
                            else
                                result = temp;
                            break;
                    }
                }

                if (result.Count() > 0)
                {
                    suggestionListBox.ItemsSource = result.Distinct();
                    suggestionListBox.DisplayMemberPath = "UserName";
                    suggestionListBox.SelectedValue = "Id";
                    suggestionListBox.Visibility = Visibility.Visible;
                }
                else
                {
                    suggestionListBox.Visibility = Visibility.Collapsed;
                    suggestionListBox.ItemsSource = null;
                }
            }
            else
            {
                suggestionListBox.Visibility = Visibility.Collapsed;
                suggestionListBox.ItemsSource = null;
            }
        }

        private void AutoTexBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                if (suggestionListBox.SelectedIndex < suggestionListBox.Items.Count)                
                    suggestionListBox.SelectedIndex = suggestionListBox.SelectedIndex + 1;                
            }
            if (e.Key == Key.Up)
            {
                if (suggestionListBox.SelectedIndex > -1)                
                    suggestionListBox.SelectedIndex = suggestionListBox.SelectedIndex - 1;                
            }
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                // Commit the selection
                suggestionListBox.Visibility = Visibility.Collapsed;
                e.Handled = (e.Key == Key.Enter);
            }

            if (e.Key == Key.Escape)
            {
                // Cancel the selection
                suggestionListBox.ItemsSource = null;
                suggestionListBox.Visibility = Visibility.Collapsed;
            }
        }

        private void SuggestionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            autoTextBox.TextChanged -= new TextChangedEventHandler(AutoTexBox_TextChanged);            
            if (suggestionListBox.ItemsSource != null)
            {
                autoTextBox.Text = suggestionListBox.SelectedItem != null ? (suggestionListBox.SelectedItem as IAutoCompleteSource).UserName : null;
                SelectedValue = suggestionListBox.SelectedItem != null ? (suggestionListBox.SelectedItem as IAutoCompleteSource).Id : 0;
            }
            autoTextBox.TextChanged += new TextChangedEventHandler(AutoTexBox_TextChanged);
        }
        #endregion

    }
}
