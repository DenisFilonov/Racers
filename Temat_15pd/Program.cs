using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temat_15pd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             На основе созданного класса «Гонщик» (страна, рейтинг, количество пройденных этапов), написать программу “Система управления журналом соревнований”.

            1.Система должна поддерживать следующую функциональность: 

	        - запись в файл информации об участниках гонки (список участников)
	        - чтение из файла информации об участниках
	        - редактирование данных указанного участника в файле, а также основных характеристик соревнований  
	        - удаление данных из файла по указанному критерию (по имени участника, по стране, по рейтингу)
	        - добавление информации об участниках в файл (один участник, команда)

            2.Реализовать интерфейс (меню) осуществления управления через систему.

             */

            RacerList racerList = new RacerList();

            string s1, s2, s3;
            int ival1, ival2;
            int menu;
            do
            {
                Console.WriteLine("\n\tMAIN MENU");
                Console.WriteLine("1. Add a racer");
                Console.WriteLine("2. Delete racer");
                Console.WriteLine("3. Edit racer's info");
                Console.WriteLine("4. Show racer");
                Console.WriteLine("5. Show all info about racers");
                Console.WriteLine("6. Sort racers menu");
                Console.WriteLine("7. Save data");
                Console.WriteLine("8. Load data");
                Console.Write("0. Exit\nChoice: ");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("Input name:");
                            s1 = Console.ReadLine();

                            Console.WriteLine("Input birthdate in format [dd.MM.yyyy]:");
                            s2 = Console.ReadLine();

                            Console.WriteLine("Input country:");
                            s3 = Console.ReadLine();

                            Console.WriteLine("Input rating from 1 to 100:");
                            ival1 = int.Parse(Console.ReadLine());

                            Console.WriteLine("Input number of participations:");
                            ival2 = int.Parse(Console.ReadLine());

                            racerList.Add(new Racer(s1, s2, s3, ival1, ival2));
                            Console.WriteLine("\tNew racer added succesfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 2:
                        Console.WriteLine("Input name:");
                        racerList.Del(racerList.FindRacer(Console.ReadLine()));
                        break;

                    case 3:
                        Console.WriteLine("Input name:");
                        racerList.EditInfo(racerList.FindRacer(Console.ReadLine()));
                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("Input name:");
                            racerList.ShowRacer(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 5:
                        racerList.ShowAll();
                        break;

                    case 6:
                        do
                        {
                            Console.WriteLine("\n\tSORT MENU");
                            Console.WriteLine("1) Sort by name");
                            Console.WriteLine("2) Sort by age");
                            Console.WriteLine("3) Sort by country");
                            Console.WriteLine("4) Sort by rating");
                            Console.WriteLine("5) Sort by number of participations");
                            Console.Write("0. Exit\nChoice: ");
                            menu = int.Parse(Console.ReadLine());

                            switch (menu)
                            {
                                case 1:
                                    racerList.SortListByFullName();
                                    break;

                                case 2:
                                    racerList.SortListByAge();
                                    break;

                                case 3:
                                    racerList.SortListByCountry();
                                    break;

                                case 4:
                                    racerList.SortListByRating();
                                    break;

                                case 5:
                                    racerList.SortListByNumberOfParticipations();
                                    break;

                                default:
                                    if (menu > 5 || menu != 0 || menu < 0) Console.WriteLine("\tWrong menu item selected.\n");
                                    break;
                            }
                        } while (menu != 0);
                        break;

                    case 7:
                        try
                        {
                            Console.WriteLine("Input the name of file for save information:");
                            s1 = Console.ReadLine();
                            s1 += ".bin";
                            racerList.Save(s1);
                            Console.WriteLine("\tInformation saved succesfully.");
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 8:
                        try
                        {
                            Console.WriteLine("\tAttention! \n\tAll unsaved information may be lost, it's recommended to save the information before load.");
                            Console.Write("Input [1] for continue, or [2] to back: ");
                            ival1 = int.Parse(Console.ReadLine());
                            if (ival1 == 1)
                            {
                                Console.WriteLine("Input the name of file for load information:");
                                s1 = Console.ReadLine();
                                s1 += ".bin";
                                racerList.Load(s1);
                                Console.WriteLine("\tInformation loaded succesfully.");
                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    default:
                        if (menu > 8 || menu != 0 || menu < 0) Console.WriteLine("\tWrong menu item selected.\n");
                        break;
                }
            } while (menu != 0);
        }
    }
}


