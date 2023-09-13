using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace Projekat_HCI
{
    /// <summary>
    /// Interaction logic for UserDescriptionWindow.xaml
    /// </summary>
    public partial class UserDescriptionWindow : Window
    {

        public HororFilm hf = new HororFilm();
        public UserDescriptionWindow(HororFilm ime)
        {
            hf = ime;
            InitializeComponent();

            this.DataContext = hf;

            using (Stream stream = new FileStream(hf.datoteka, FileMode.Open))
            {
                TextRange range = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
                range.Load(stream, DataFormats.Rtf);
            }
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
