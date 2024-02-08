using System;
using System.Collections.Generic;
using System.Text;

namespace Kursovaya
{
     class Films
    {

        public Films(string Name, string Zanr,string Year)
        {
            this.Name = Name;
            this.Zanr = Zanr;
            this.Year = Year;
        }
        public Films()
        {

        }
        public Films(string ID, string Name, string Zanr, string Year, string Time, string Image)
        {
            this.Name = Name;
            this.Zanr = Zanr;
            this.Year = Year;
            this.ID = ID;
            this.Time = Time;
            this.Image = Image;
        }
        public string ID { get; set; }
       
        public string Name { get; set; }
        public string Zanr { get; set; }
        public string Year { get; set; }
        public string Time { get; set; }
        public string Opis { get; set; }
        public string Image { get; set; }
        public int Og { get; set; }

    }
}
