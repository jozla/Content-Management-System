using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Projekat_HCI
{
    /// <summary>
    /// Interaction logic for AdminUserWindow.xaml
    /// </summary>
    public partial class AdminUserWindow : Window
    {
        private DataIO serializer = new DataIO();
        public static BindingList<HororFilm> Filmovi { get; set; }

        public AdminUserWindow()
        {
            Filmovi = serializer.DeSerializeObject<BindingList<HororFilm>>("filmovi.xml");

            if (Filmovi == null)
            {
                Filmovi = new BindingList<HororFilm>();
            }
            DataContext = this;


            InitializeComponent();

            if (!Indicator.isAdmin)
            {
                deleteButton.IsEnabled = false;
                addButton.IsEnabled = false;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow();
            add.ShowDialog();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Filmovi.Count > 0)
            {

                List<HororFilm> selectedFilms = new List<HororFilm>();
                foreach (HororFilm film in dataGridFilmovi.ItemsSource)
                {
                    if (film.isSelected)
                    {
                        selectedFilms.Add(film);
                    }
                }

                foreach (HororFilm film in selectedFilms)
                {
                    File.Delete(film.datoteka);
                    Filmovi.Remove(film);
                }
            }
            else
            {
                MessageBox.Show("Can't delete from an empty table.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            if (!Indicator.isAdmin)
            {
                UserDescriptionWindow uw = new UserDescriptionWindow((HororFilm)dataGridFilmovi.SelectedItem);
                uw.ShowDialog();
            }
            else
            {              
                DescriptionWindow dw = new DescriptionWindow((HororFilm)dataGridFilmovi.SelectedItem);
                dw.ShowDialog();
            }
        }

        private void save(object sender, CancelEventArgs e)
        {
            serializer.SerializeObject<BindingList<HororFilm>>(Filmovi, "filmovi.xml");
        }
    }
}
