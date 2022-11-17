using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Temat_15pd
{
    [Serializable]
    internal class Racer
    {
        //класс «Гонщик» (страна, рейтинг, количество пройденных этапов)
        public string FullName { get; set; } // ФИО
        public DateTime BirthDate { get; set; } // ДР
        public string Country { get; set; } // страна
        public int Rating { get; set; } // рейтинг
        public int NumberOfParticipations { get; set; } // кол-во участий


        public Racer()
        {
            FullName = "Somebody";
            BirthDate = Convert.ToDateTime("01.01.2001");
            Country = "Unknown";
            Rating = 0;
            NumberOfParticipations = 0;
        }
        public Racer(string fullName, string birthDate, string country, int rating, int numberOfParticipations)
        {
            if (String.IsNullOrWhiteSpace(fullName)) throw new Exception();
            if(String.IsNullOrWhiteSpace(birthDate)) throw new Exception();
            if (String.IsNullOrWhiteSpace(country)) throw new Exception();
            if (rating < 0 || rating >= 100) throw new Exception();
            if (numberOfParticipations < 0) throw new Exception();
            FullName = fullName;
            try
            {
                BirthDate = Convert.ToDateTime(birthDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Country = country;
            Rating = rating;
            NumberOfParticipations = numberOfParticipations;
        }
        public void Show()
        {
            Console.WriteLine(
                $"\nFull name: {FullName}" +
                $"\nBirthdate: {BirthDate.ToShortDateString()}" +
                $"\nCountry: {Country}" +
                $"\nRating: {Rating}" +
                $"\nNumber of participations: {NumberOfParticipations}");
        }
    }
}
