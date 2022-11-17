using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Temat_15pd
{
    internal class RacerList
    {
        private List<Racer> _racers = null;
        public RacerList()
        {
            _racers = new List<Racer>();
        }
        public void Add(Racer obj)
        {
            _racers.Add(obj);
        }
        public void Del(int id)
        {
            _racers.RemoveAt(id);
            Console.WriteLine("\tRacer deleted succesfully!");
        }
        public void EditInfo(int id)
        {
            Racer obj = _racers[id];
            int menu;
            do
            {
                Console.WriteLine("\tMENU FOR CHANGING INFORMATION");
                Console.WriteLine("1) Full name");
                Console.WriteLine("2) Birthdate");
                Console.WriteLine("3) Country");
                Console.WriteLine("4) Rating");
                Console.WriteLine("5) Number of participations");
                Console.WriteLine("6) All info");
                Console.Write("0. Back to the main menu\nChoice: ");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Input full name:");
                            obj.FullName = Console.ReadLine();
                            Console.WriteLine("\tFull name set succesfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 2:
                        try
                        {
                            Console.WriteLine("Input birthdate in format [dd.MM.yyyy]:");
                            obj.BirthDate = Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("\tBirthdate set succesfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 3:
                        try
                        {
                            Console.WriteLine("Input country:");
                            obj.Country = Console.ReadLine();
                            Console.WriteLine("\tCountry set succesfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("Input rating from 1 to 100:");
                            obj.Rating = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\tRating set succesfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                        try
                        {
                            Console.WriteLine("Input number of participations:");
                            obj.NumberOfParticipations = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\tNumber of participations set succesfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 6:
                        try
                        {
                            Console.WriteLine("Input full name:");
                            obj.FullName = Console.ReadLine();

                            Console.WriteLine("Input birthdate in format [dd.MM.yyyy]:");
                            obj.BirthDate = Convert.ToDateTime(Console.ReadLine()); 
                            
                            Console.WriteLine("Input country:");
                            obj.Country = Console.ReadLine();

                            Console.WriteLine("Input rating from 1 to 100:");
                            obj.Rating = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Input number of participations:");
                            obj.NumberOfParticipations = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\tAll information set succesfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    default:
                        if (menu > 6 || menu != 0 || menu < 0) Console.WriteLine("\tWrong menu item selected.\n");
                        break;
                }
            } while (menu != 0);
        }
        //===========================================================================================
        public void SortListByFullName()
        {
            _racers.Sort(SortByFullName);
        }
        public void SortListByAge()
        {
            _racers.Sort(SortByAge);
        }
        public void SortListByCountry()
        {
            _racers.Sort(SortByCountry);
        }
        public void SortListByRating()
        {
            _racers.Sort(SortByRating);
        }
        public void SortListByNumberOfParticipations()
        {
            _racers.Sort(SortByNumberOfParticipations);
        }
        //===================================================================
        private static int SortByFullName(Racer f, Racer s)
        {
            return f.FullName.CompareTo(s.FullName);
        }
        private static int SortByAge(Racer f, Racer s)
        {
            return f.BirthDate.CompareTo(s.BirthDate);
        }
        private static int SortByCountry(Racer f, Racer s)
        {
            return f.Country.CompareTo(s.Country);
        }
        private static int SortByRating(Racer f, Racer s)
        {
            return f.Rating.CompareTo(s.Rating);
        }
        private static int SortByNumberOfParticipations(Racer f, Racer s)
        {
            return f.NumberOfParticipations.CompareTo(s.NumberOfParticipations);
        }
  
        //===========================================================================================
        public int FindRacer(string fullName)
        {
            foreach (Racer r in _racers)
            {
                if (r.FullName == fullName)
                {
                    return _racers.IndexOf(r);
                }
            }
            throw new Exception($"\tThe racer [{fullName}] wasn't found, please check input data.");
        }
        public void ShowRacer(string fullName)
        {
            _racers[FindRacer(fullName)].Show();
        }
        public void ShowAll()
        {
            if (_racers.Count > 0)
            {
                for (int i = 0; i < _racers.Count; i++) // for, не foreach для использовании индексации
                {
                    Console.WriteLine($"\tRacer # {i + 1}"); // Красота, показать индексацию для пользователя
                    _racers[i].Show(); // Вывод инфы
                    Console.WriteLine(); // Отступ между гонщиками, красота
                }
            }
            else
            {
                Console.WriteLine("\tThe list of racers is empty, please first add somebody to it.");
            }

        }
        public void Save(string path)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, _racers);
            }
        }
        public void Load(string path)
        {
            List<Racer> tmp = new List<Racer>();
            try
            {
                using (var fr = new FileStream(path, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    tmp = bf.Deserialize(fr) as List<Racer>;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _racers = tmp;
        }
    }
}
