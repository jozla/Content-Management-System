using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat_HCI
{
    public class HororFilm
    {
        public string imeFilma { get; set; }
        public int godinaIzdavanja { get; set; }
        public string slika { get; set; }
        public string datoteka { get; set; }
        public DateTime datum { get; set; }

        public bool isSelected { get; set; }

        public List<string> colors { get; set; }

        public HororFilm() : this("",0,"",DateTime.Now,"", new List<string>(), false)
        {

        }

        public HororFilm(string imeFilma, int godinaIzdavanja, string slika, DateTime datum, string datoteka, List<string> colors, bool isSelected = false)
        {
            this.imeFilma = imeFilma;
            this.godinaIzdavanja = godinaIzdavanja;
            this.slika = slika;
            this.datoteka = datoteka;
            this.datum = datum;
            this.colors = colors;
            this.isSelected = isSelected;
        }

        public HororFilm(HororFilm original)
        {
            this.imeFilma = original.imeFilma;
            this.godinaIzdavanja = original.godinaIzdavanja;
            this.slika = original.slika;
            this.datoteka = original.datoteka;
            this.datum = original.datum;
            this.colors = original.colors;
            this.isSelected = original.isSelected;
        }
    }
}
