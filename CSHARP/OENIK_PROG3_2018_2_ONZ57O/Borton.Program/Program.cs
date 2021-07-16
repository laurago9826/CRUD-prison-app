// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Borton.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Borton.Data;
    using Borton.Logic;

    /// <summary>
    /// Main class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method, prints out the menu points on the console
        /// </summary>
        /// <param name="logic">Expects a Logic instance</param>
        public static void Menu(Logic logic)
        {
            bool valid = false;
            do
            {
                Console.WriteLine("Válasszon menüpontot!");
                Console.Clear();
                Console.WriteLine("___________________________________________________________________________________________");
                Console.WriteLine("|                                                                                          |");
                Console.WriteLine("|   [1] Adatok listázása                                                                   |");
                Console.WriteLine("|                                                                                          |");
                Console.WriteLine("|   [2] Új adatok hozzáadása                                                               |");
                Console.WriteLine("|                                                                                          |");
                Console.WriteLine("|   [3] Adatok módosítása                                                                  |");
                Console.WriteLine("|                                                                                          |");
                Console.WriteLine("|   [4] Adatok törlése                                                                     |");
                Console.WriteLine("|                                                                                          |");
                Console.WriteLine("|   [5] Listázzuk ki, hogy melyik fegyenc milyen bűntettet követett el, illetve hány évet  |\n" +
                                  "|\tkell letöltenie miatta a börtönben  (letöltési idő szerint csökkenő sorrendben).   |");
                Console.WriteLine("|                                                                                          |");
                Console.WriteLine("|   [6] Listázzuk ki a fegyencek nevét,  emeletét, részlegét és cellákát, ahol laknak      |\n" +
                                  "|\t (emelet szerinti növekvő sorrendben).                                             |");
                Console.WriteLine("|                                                                                          |");
                Console.WriteLine("|   [7] Listázzuk ki hányféle bűntettet követtek el a fegyencek, átlagosan hány évre       |\n" +
                                  "|\títélik el ilyen bűncselekményért, illetve a bűntett leírását (a bűntettet          |\n" +
                                  "|\telkövetett fegyencek darabszáma szerint csökkenő sorrendben).                      |");
                Console.WriteLine("|                                                                                          |");
                Console.WriteLine("|   [8] Letöltendő évek alakulása az évek esetén egyes fegyenc esetén (webes adatlekérés)  |");
                Console.WriteLine("|                                                                                          |");
                Console.WriteLine("|   [q] Kilépés                                                                            |");
                Console.WriteLine("|__________________________________________________________________________________________|");
                Console.Write("\nKiválasztott menüpont: ");
                string valasztas = Console.ReadLine();

                if (valasztas == "1" || valasztas == "2" || valasztas == "3" || valasztas == "4")
                {
                    int melyiktabla = MelyikTabla();
                    if (valasztas == "1")
                    {
                        Console.WriteLine(logic.Listing(melyiktabla));
                    }
                    else if (valasztas == "2")
                    {
                        string[] properties = logic.PropertyNamesToString(melyiktabla.ToString());
                        string[] values = new string[properties.Length];
                        Console.WriteLine("Adja meg a megfelelő adatokat! ");
                        for (int i = 0; i < properties.Length; i++)
                        {
                            Console.Write(properties[i] + ": ");
                            values[i] = Console.ReadLine();
                        }

                        logic.Insert(melyiktabla, values);
                    }
                    else if (valasztas == "3")
                    {
                        string[] properties = logic.PropertyNamesToString(melyiktabla.ToString());
                        for (int i = 0; i < properties.Length; i++)
                        {
                            Console.WriteLine(properties[i]);
                        }

                        string propertyNameForFiltering = null;
                        string propertyNameForModifying = null;
                        do
                        {
                            Console.WriteLine("Melyik mező szerint szeretne szűrni (Írja be valamelyiket a felkínáltak közül) ");
                            propertyNameForFiltering = Console.ReadLine();
                        }
                        while (!properties.Contains(propertyNameForFiltering));
                        Console.WriteLine("Írja be, hogy milyen értékre szeretne rászűrni a {0} mezőben! ", propertyNameForFiltering);
                        string filteringValue = Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Milyen mezőt szeretne módosítani a {0} = {1} értékű példányokra? ", propertyNameForFiltering, filteringValue);
                            propertyNameForModifying = Console.ReadLine();
                        }
                        while (!properties.Contains(propertyNameForModifying));
                        Console.WriteLine("Milyen értékre módosítsuk a {0} mezőt? ", propertyNameForModifying);
                        string modifiedValue = Console.ReadLine();

                        logic.Update(melyiktabla, filteringValue, modifiedValue, propertyNameForModifying, propertyNameForFiltering);
                    }
                    else
                    {
                        if (melyiktabla != 5)
                        {
                            Console.Write("Adja meg a törlendő példány azonosítóját! ");
                            string id = Console.ReadLine();
                            logic.Delete(melyiktabla, id);
                        }
                        else
                        {
                            Console.Write("Adja meg a törlendő példány azonosítóit @-al elválasztva! ");
                            string[] azonositok = Console.ReadLine().Split('@');
                            logic.Delete(melyiktabla, azonositok);
                        }
                    }
                }
                else if (valasztas == "5")
                {
                    Console.WriteLine(logic.BuntettekEsFegyencekToString());
                }
                else if (valasztas == "6")
                {
                    logic.FegyencEsElhelyezesKiiras();
                }
                else if (valasztas == "7")
                {
                    Console.WriteLine(logic.HanyfeleBuntettToString());
                }
                else if (valasztas == "8")
                {
                    Console.Write("Adja meg a fegyenc nevét: ");
                    string fegyencnev = Console.ReadLine();
                    Console.Write("Adja meg a fegyenc azonosítóját: ");
                    string fegyenc_id = Console.ReadLine();
                    Console.Write("Adja meg, hogy hány évre ítélték el a fegyencet: ");
                    string letoltendo_ido = Console.ReadLine();
                    Console.WriteLine("\nMegjegyzés: A hátralevő letöltendő időt a fegyenc magaviselete is befolyásolja!");
                    Console.WriteLine(logic.Java(letoltendo_ido, fegyencnev, fegyenc_id));
                }
                else if (valasztas == "q")
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                    Console.WriteLine("\nROSSZ BEMENET!");
                }

                if (valasztas != "q")
                {
                    Console.WriteLine("A folytatáshoz nyomjon egy Entert!");
                    Console.ReadLine();
                }
            }
            while (!valid);
        }

        /// <summary>
        /// Asks from the user, on which table it wants to execute the operation
        /// </summary>
        /// <returns>The table ID</returns>
        public static int MelyikTabla()
        {
            Console.WriteLine("\nMelyik táblán szeretné végrehajtani a műveletet? ");
            Console.WriteLine("[1] Fegyenc");
            Console.WriteLine("[2] Börtonőr");
            Console.WriteLine("[3] Ítélet");
            Console.WriteLine("[4] Bűntett");
            Console.WriteLine("[5] Elhelyezés");
            Console.Write("\nVálasz: ");
            string tabla = Console.ReadLine();
            Console.WriteLine("\n");
            if (tabla == "1" || tabla == "2" || tabla == "3" || tabla == "4" || tabla == "5")
            {
                return int.Parse(tabla);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private static void Main(string[] args)
        {
            try
            {
                Logic logic = new Logic();
                Menu(logic);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("HIBA: Nem megfelelő formátumban adta meg az adatokat!");
            }
            catch (System.Net.WebException)
            {
                Console.WriteLine("HIBA: Nem fut a GlassFish server!\nTipp: próbálja meg egyszer lefuttatni az állományt Netbeans-en keresztül és utána elérhető lesz a böngészőben is...");
            }
            catch (System.InvalidOperationException)
            {
                Console.WriteLine("HIBA: Nem megfelelő formátumban adta meg az adatokat!");
            }
            catch (System.InvalidCastException)
            {
                Console.WriteLine("HIBA: Nem megfelelő formátumban adta meg az adatokat!");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                Console.WriteLine("HIBA: Kulcsütközés történt vagy nem tett eleget a megszorításoknak! )");
            }
            catch (InvalidFilterCriteriaException)
            {
                Console.WriteLine("HIBA: Nem találtunk ilyen azonosítójú példányt! ");
            }
            catch (Exception)
            {
                Console.WriteLine("HIBA: A program nem várt hibába futott");
            }
        }
    }
}
