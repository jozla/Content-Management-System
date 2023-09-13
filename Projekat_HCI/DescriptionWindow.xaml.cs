using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Projekat_HCI
{


    public partial class DescriptionWindow : Window
    {

        public List<string> ChosenColors { get; set; }
        public HororFilm hf = new HororFilm();       
        public HororFilm save = new HororFilm();
        public DescriptionWindow(HororFilm ime)
        {
            hf = new HororFilm(ime);
            save = ime;

            InitializeComponent();

            using (Stream stream = new FileStream(hf.datoteka, FileMode.Open))
            {
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Load(stream, DataFormats.Rtf);
            }


            this.DataContext = hf;

            ChosenColors = hf.colors;


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


            if (!Indicator.isAdmin)
            {
                nameTextBox.IsReadOnly = true;
                yearTextBox.IsReadOnly = true;
                loadImageButton.IsEnabled = false;
                MainToolbar.IsEnabled = false;
                rtbEditor.IsReadOnly = true;
                addNewMovie.IsEnabled = false;
            }
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
        private void SaveMovie_Click(object sender, RoutedEventArgs e)
        {
            if (add_validate())
            {
                string path = hf.datoteka;

                AdminUserWindow.Filmovi.Remove(save);
                hf = new HororFilm(nameTextBox.Text, int.Parse(yearTextBox.Text), image.Source.ToString(), DateTime.Now, $"rtf/{nameTextBox.Text.Trim()}.rtf", ChosenColors);
                AdminUserWindow.Filmovi.Add(hf);

                if (path.Equals($"rtf/{nameTextBox.Text.Trim()}.rtf"))
                {
                    using (Stream stream = new FileStream(path, FileMode.Open))
                    {
                        TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                        range.Save(stream, DataFormats.Rtf);
                    }

                }
                else
                {
                    using (Stream stream = new FileStream($"rtf/{nameTextBox.Text.Trim()}.rtf", FileMode.Create))
                    {
                        TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                        range.Save(stream, DataFormats.Rtf);
                    }
                    File.Delete(path);
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
