using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekat_HCI
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public List<string> ChosenColors { get; set; }

        public AddWindow()
        {
            InitializeComponent();

            ChosenColors = new List<string>();

            //STARTING DECLARATION 
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontColor.SelectedItem = "Black";


            for (int i = 0; i < (typeof(Colors).GetProperties().Count()); i++)
            {
                cmbFontColor.Items.Add(typeof(Colors).GetProperties()[i].ToString().Split(' ')[1]);
            }

            for (int i = 1; i <= 72; i++)
            {
                cmbFontSize.Items.Add((double)i);
            }
            cmbFontSize.SelectedItem = 12.0;

        }


        //*************************************************************************************************************
        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        //ADDING -------------------------------------------------------------------------
        private void addNewMovie_Click(object sender, RoutedEventArgs e)
        {
            if (add_validate())
            {
                HororFilm film = new HororFilm(nameTextBox.Text, int.Parse(yearTextBox.Text), image.Source.ToString(), DateTime.Now, $"rtf/{nameTextBox.Text.Trim()}.rtf", ChosenColors);
                AdminUserWindow.Filmovi.Add(film);
                using (Stream stream = new FileStream($"rtf/{nameTextBox.Text.Trim()}.rtf", FileMode.Create))
                {
                    TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                    range.Save(stream, DataFormats.Rtf);                
                }
                this.Close();
            }
        }

        public bool add_validate()
        {
            nameError.Content = "";
            yearError.Content = "";
            imageError.Content = "";
            richError.Content = "";
            bool valid = true;
            int value;

            if (!int.TryParse(yearTextBox.Text, out value))
            {
                yearError.Content = "Please enter a number.";
                valid = false;
            }
            else
            {
                if (value < 1888 || value > 2023)
                {
                    yearError.Content = "Please enter a valid year.";
                    valid = false;
                }
            }

            if (nameTextBox.Text.Equals(""))
            {
                nameError.Content = "Please enter a name.";
                valid = false;
            }

            string imagePath = "other_images/image_ph.png";
            if (image.Source.ToString().EndsWith(imagePath))
            {
                imageError.Content = "Please select an image.";
                valid = false;
            }


            if (string.IsNullOrWhiteSpace(new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd).Text))
            {
                richError.Content = "Please enter a description.";
                valid = false;
            }


            if (valid)
                return true;
            else
                return false;
        }




        //IMAGE LOAD --------------------------------------
        private void loadImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string relativePath = @"..\..\images\";
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string absolutePath = System.IO.Path.Combine(basePath, relativePath);
            Directory.SetCurrentDirectory(absolutePath);
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                image.Source = new BitmapImage(fileUri);

            }

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
        }



        //FONT FAMILY --------------------------------------
        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null && !rtbEditor.Selection.IsEmpty)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
            }
        }



        //FONT COLOR--------------------------------------
        private string GetColor(SolidColorBrush brush)
        {
            string result = string.Empty;

            SolidColorBrush stringBrush = null;

            foreach (string s in ChosenColors)
            {
                stringBrush = ((SolidColorBrush)(new BrushConverter().ConvertFrom(s)));

                if ((stringBrush.Color.A == brush.Color.A) && (stringBrush.Color.R == brush.Color.R) && (stringBrush.Color.G == brush.Color.G) && (stringBrush.Color.B == brush.Color.B))
                {
                    result = s;
                }
            }

            return result;
        }

        private void cmbFontColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontColor.SelectedItem != null && !rtbEditor.Selection.IsEmpty)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.ForegroundProperty, (SolidColorBrush)(new BrushConverter().ConvertFrom(cmbFontColor.SelectedValue.ToString())));
                if (!ChosenColors.Contains(cmbFontColor.SelectedValue.ToString()))
                {
                    ChosenColors.Add(cmbFontColor.SelectedValue.ToString());
                }
            }
        }



        //FONT SIZE--------------------------------------
        private void cmbFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontSize.SelectedItem != null && !rtbEditor.Selection.IsEmpty)
            {
                rtbEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.SelectedItem);
            }
        }




        //NUMBER OF WORDS --------------------------------------
        private int getNumberOfWords()
        {
            TextRange textRange = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
            int wordCount = 0;

            foreach (string word in textRange.Text.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                wordCount++;
            }

            return wordCount;
        }

        private void rtbEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            int num = getNumberOfWords();
            numOfWords.Content = num;
        }




        //EDITOR SELECTION CHANGE --------------------------------------
        private void rtbEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtbEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            
            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

            temp = rtbEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;

            temp = rtbEditor.Selection.GetPropertyValue(Inline.ForegroundProperty);
            if (temp != DependencyProperty.UnsetValue)
                cmbFontColor.SelectedItem = GetColor((SolidColorBrush)(new BrushConverter().ConvertFrom(temp.ToString())));

            temp = rtbEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.SelectedItem = temp;
        }
    }
}
